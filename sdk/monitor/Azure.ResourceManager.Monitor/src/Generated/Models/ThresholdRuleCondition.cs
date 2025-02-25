// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> A rule condition based on a metric crossing a threshold. </summary>
    public partial class ThresholdRuleCondition : AlertRuleCondition
    {
        /// <summary> Initializes a new instance of ThresholdRuleCondition. </summary>
        /// <param name="operator"> the operator used to compare the data and the threshold. </param>
        /// <param name="threshold"> the threshold value that activates the alert. </param>
        public ThresholdRuleCondition(MonitorConditionOperator @operator, double threshold)
        {
            Operator = @operator;
            Threshold = threshold;
            OdataType = "Microsoft.Azure.Management.Insights.Models.ThresholdRuleCondition";
        }

        /// <summary> Initializes a new instance of ThresholdRuleCondition. </summary>
        /// <param name="odataType"> specifies the type of condition. This can be one of three types: ManagementEventRuleCondition (occurrences of management events), LocationThresholdRuleCondition (based on the number of failures of a web test), and ThresholdRuleCondition (based on the threshold of a metric). </param>
        /// <param name="dataSource">
        /// the resource from which the rule collects its data. For this type dataSource will always be of type RuleMetricDataSource.
        /// Please note <see cref="RuleDataSource"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="RuleManagementEventDataSource"/> and <see cref="RuleMetricDataSource"/>.
        /// </param>
        /// <param name="operator"> the operator used to compare the data and the threshold. </param>
        /// <param name="threshold"> the threshold value that activates the alert. </param>
        /// <param name="windowSize"> the period of time (in ISO 8601 duration format) that is used to monitor alert activity based on the threshold. If specified then it must be between 5 minutes and 1 day. </param>
        /// <param name="timeAggregation"> the time aggregation operator. How the data that are collected should be combined over time. The default value is the PrimaryAggregationType of the Metric. </param>
        internal ThresholdRuleCondition(string odataType, RuleDataSource dataSource, MonitorConditionOperator @operator, double threshold, TimeSpan? windowSize, ThresholdRuleConditionTimeAggregationType? timeAggregation) : base(odataType, dataSource)
        {
            Operator = @operator;
            Threshold = threshold;
            WindowSize = windowSize;
            TimeAggregation = timeAggregation;
            OdataType = odataType ?? "Microsoft.Azure.Management.Insights.Models.ThresholdRuleCondition";
        }

        /// <summary> the operator used to compare the data and the threshold. </summary>
        public MonitorConditionOperator Operator { get; set; }
        /// <summary> the threshold value that activates the alert. </summary>
        public double Threshold { get; set; }
        /// <summary> the period of time (in ISO 8601 duration format) that is used to monitor alert activity based on the threshold. If specified then it must be between 5 minutes and 1 day. </summary>
        public TimeSpan? WindowSize { get; set; }
        /// <summary> the time aggregation operator. How the data that are collected should be combined over time. The default value is the PrimaryAggregationType of the Metric. </summary>
        public ThresholdRuleConditionTimeAggregationType? TimeAggregation { get; set; }
    }
}
