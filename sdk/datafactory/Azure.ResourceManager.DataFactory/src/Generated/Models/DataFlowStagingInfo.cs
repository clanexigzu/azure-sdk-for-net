// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> Staging info for execute data flow activity. </summary>
    public partial class DataFlowStagingInfo
    {
        /// <summary> Initializes a new instance of DataFlowStagingInfo. </summary>
        public DataFlowStagingInfo()
        {
        }

        /// <summary> Initializes a new instance of DataFlowStagingInfo. </summary>
        /// <param name="linkedService"> Staging linked service reference. </param>
        /// <param name="folderPath"> Folder path for staging blob. Type: string (or Expression with resultType string). </param>
        internal DataFlowStagingInfo(FactoryLinkedServiceReference linkedService, BinaryData folderPath)
        {
            LinkedService = linkedService;
            FolderPath = folderPath;
        }

        /// <summary> Staging linked service reference. </summary>
        public FactoryLinkedServiceReference LinkedService { get; set; }
        /// <summary>
        /// Folder path for staging blob. Type: string (or Expression with resultType string)
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formated json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BinaryData FolderPath { get; set; }
    }
}
