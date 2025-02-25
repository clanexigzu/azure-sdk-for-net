// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> The effective network security group association. </summary>
    public partial class EffectiveNetworkSecurityGroupAssociation
    {
        /// <summary> Initializes a new instance of EffectiveNetworkSecurityGroupAssociation. </summary>
        internal EffectiveNetworkSecurityGroupAssociation()
        {
        }

        /// <summary> Initializes a new instance of EffectiveNetworkSecurityGroupAssociation. </summary>
        /// <param name="networkManager"> The ID of the Azure network manager if assigned. </param>
        /// <param name="subnet"> The ID of the subnet if assigned. </param>
        /// <param name="networkInterface"> The ID of the network interface if assigned. </param>
        internal EffectiveNetworkSecurityGroupAssociation(WritableSubResource networkManager, WritableSubResource subnet, WritableSubResource networkInterface)
        {
            NetworkManager = networkManager;
            Subnet = subnet;
            NetworkInterface = networkInterface;
        }

        /// <summary> The ID of the Azure network manager if assigned. </summary>
        internal WritableSubResource NetworkManager { get; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier NetworkManagerId
        {
            get => NetworkManager?.Id;
        }

        /// <summary> The ID of the subnet if assigned. </summary>
        internal WritableSubResource Subnet { get; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier SubnetId
        {
            get => Subnet?.Id;
        }

        /// <summary> The ID of the network interface if assigned. </summary>
        internal WritableSubResource NetworkInterface { get; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier NetworkInterfaceId
        {
            get => NetworkInterface?.Id;
        }
    }
}
