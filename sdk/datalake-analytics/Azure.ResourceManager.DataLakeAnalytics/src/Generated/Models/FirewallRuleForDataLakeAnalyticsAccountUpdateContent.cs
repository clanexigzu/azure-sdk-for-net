// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Net;
using Azure.Core;

namespace Azure.ResourceManager.DataLakeAnalytics.Models
{
    /// <summary>
    /// The parameters used to update a firewall rule while updating a Data Lake Analytics account.
    /// Serialized Name: UpdateFirewallRuleWithAccountParameters
    /// </summary>
    public partial class FirewallRuleForDataLakeAnalyticsAccountUpdateContent
    {
        /// <summary> Initializes a new instance of FirewallRuleForDataLakeAnalyticsAccountUpdateContent. </summary>
        /// <param name="name">
        /// The unique name of the firewall rule to update.
        /// Serialized Name: UpdateFirewallRuleWithAccountParameters.name
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public FirewallRuleForDataLakeAnalyticsAccountUpdateContent(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary>
        /// The unique name of the firewall rule to update.
        /// Serialized Name: UpdateFirewallRuleWithAccountParameters.name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The start IP address for the firewall rule. This can be either ipv4 or ipv6. Start and End should be in the same protocol.
        /// Serialized Name: UpdateFirewallRuleWithAccountParameters.properties.startIpAddress
        /// </summary>
        public IPAddress StartIPAddress { get; set; }
        /// <summary>
        /// The end IP address for the firewall rule. This can be either ipv4 or ipv6. Start and End should be in the same protocol.
        /// Serialized Name: UpdateFirewallRuleWithAccountParameters.properties.endIpAddress
        /// </summary>
        public IPAddress EndIPAddress { get; set; }
    }
}
