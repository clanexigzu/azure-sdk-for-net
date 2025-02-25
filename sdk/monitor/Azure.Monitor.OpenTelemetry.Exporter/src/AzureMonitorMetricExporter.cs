﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class AzureMonitorMetricExporter : BaseExporter<Metric>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;
        private AzureMonitorResource? _resource;
        private bool _disposed;

        public AzureMonitorMetricExporter(AzureMonitorExporterOptions options) : this(TransmitterFactory.Instance.Get(options))
        {
        }

        internal AzureMonitorMetricExporter(ITransmitter transmitter)
        {
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;
        }

        internal AzureMonitorResource? MetricResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource(_instrumentationKey);

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Metric> batch)
        {
            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            var exportResult = ExportResult.Failure;

            try
            {
                // In case of metrics, export is called
                // even if there are no items in batch
                if (batch.Count > 0)
                {
                    var telemetryItems = MetricHelper.OtelToAzureMonitorMetrics(batch, MetricResource, _instrumentationKey);
                    if (telemetryItems.Count > 0)
                    {
                        if (MetricResource?.MetricTelemetry != null)
                        {
                            telemetryItems.Add(MetricResource.MetricTelemetry);
                        }
                        exportResult = _transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();
                    }
                }
                else
                {
                    exportResult = ExportResult.Success;
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteError("FailedToExport", ex);
            }

            return exportResult;
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transmitter?.Dispose();
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
