// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Network default admin rule. </summary>
    public partial class ActiveDefaultSecurityAdminRule : ActiveBaseSecurityAdminRule
    {
        /// <summary> Initializes a new instance of ActiveDefaultSecurityAdminRule. </summary>
        internal ActiveDefaultSecurityAdminRule()
        {
            Sources = new ChangeTrackingList<AddressPrefixItem>();
            Destinations = new ChangeTrackingList<AddressPrefixItem>();
            SourcePortRanges = new ChangeTrackingList<string>();
            DestinationPortRanges = new ChangeTrackingList<string>();
            Kind = EffectiveAdminRuleKind.Default;
        }

        /// <summary> Initializes a new instance of ActiveDefaultSecurityAdminRule. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="commitOn"> Deployment time string. </param>
        /// <param name="region"> Deployment region. </param>
        /// <param name="configurationDescription"> A description of the security admin configuration. </param>
        /// <param name="ruleCollectionDescription"> A description of the rule collection. </param>
        /// <param name="ruleCollectionAppliesToGroups"> Groups for rule collection. </param>
        /// <param name="ruleGroups"> Effective configuration groups. </param>
        /// <param name="kind"> Whether the rule is custom or default. </param>
        /// <param name="description"> A description for this rule. Restricted to 140 chars. </param>
        /// <param name="flag"> Default rule flag. </param>
        /// <param name="protocol"> Network protocol this rule applies to. </param>
        /// <param name="sources"> The CIDR or source IP ranges. </param>
        /// <param name="destinations"> The destination address prefixes. CIDR or destination IP ranges. </param>
        /// <param name="sourcePortRanges"> The source port ranges. </param>
        /// <param name="destinationPortRanges"> The destination port ranges. </param>
        /// <param name="access"> Indicates the access allowed for this particular rule. </param>
        /// <param name="priority"> The priority of the rule. The value can be between 1 and 4096. The priority number must be unique for each rule in the collection. The lower the priority number, the higher the priority of the rule. </param>
        /// <param name="direction"> Indicates if the traffic matched against the rule in inbound or outbound. </param>
        /// <param name="provisioningState"> The provisioning state of the resource. </param>
        internal ActiveDefaultSecurityAdminRule(string id, DateTimeOffset? commitOn, string region, string configurationDescription, string ruleCollectionDescription, IReadOnlyList<NetworkManagerSecurityGroupItem> ruleCollectionAppliesToGroups, IReadOnlyList<NetworkConfigurationGroup> ruleGroups, EffectiveAdminRuleKind kind, string description, string flag, SecurityConfigurationRuleProtocol? protocol, IReadOnlyList<AddressPrefixItem> sources, IReadOnlyList<AddressPrefixItem> destinations, IReadOnlyList<string> sourcePortRanges, IReadOnlyList<string> destinationPortRanges, SecurityConfigurationRuleAccess? access, int? priority, SecurityConfigurationRuleDirection? direction, NetworkProvisioningState? provisioningState) : base(id, commitOn, region, configurationDescription, ruleCollectionDescription, ruleCollectionAppliesToGroups, ruleGroups, kind)
        {
            Description = description;
            Flag = flag;
            Protocol = protocol;
            Sources = sources;
            Destinations = destinations;
            SourcePortRanges = sourcePortRanges;
            DestinationPortRanges = destinationPortRanges;
            Access = access;
            Priority = priority;
            Direction = direction;
            ProvisioningState = provisioningState;
            Kind = kind;
        }

        /// <summary> A description for this rule. Restricted to 140 chars. </summary>
        public string Description { get; }
        /// <summary> Default rule flag. </summary>
        public string Flag { get; }
        /// <summary> Network protocol this rule applies to. </summary>
        public SecurityConfigurationRuleProtocol? Protocol { get; }
        /// <summary> The CIDR or source IP ranges. </summary>
        public IReadOnlyList<AddressPrefixItem> Sources { get; }
        /// <summary> The destination address prefixes. CIDR or destination IP ranges. </summary>
        public IReadOnlyList<AddressPrefixItem> Destinations { get; }
        /// <summary> The source port ranges. </summary>
        public IReadOnlyList<string> SourcePortRanges { get; }
        /// <summary> The destination port ranges. </summary>
        public IReadOnlyList<string> DestinationPortRanges { get; }
        /// <summary> Indicates the access allowed for this particular rule. </summary>
        public SecurityConfigurationRuleAccess? Access { get; }
        /// <summary> The priority of the rule. The value can be between 1 and 4096. The priority number must be unique for each rule in the collection. The lower the priority number, the higher the priority of the rule. </summary>
        public int? Priority { get; }
        /// <summary> Indicates if the traffic matched against the rule in inbound or outbound. </summary>
        public SecurityConfigurationRuleDirection? Direction { get; }
        /// <summary> The provisioning state of the resource. </summary>
        public NetworkProvisioningState? ProvisioningState { get; }
    }
}
