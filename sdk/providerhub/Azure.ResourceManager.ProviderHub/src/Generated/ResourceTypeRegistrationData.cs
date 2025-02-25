// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ProviderHub.Models;

namespace Azure.ResourceManager.ProviderHub
{
    /// <summary> A class representing the ResourceTypeRegistration data model. </summary>
    public partial class ResourceTypeRegistrationData : ResourceData
    {
        /// <summary> Initializes a new instance of ResourceTypeRegistrationData. </summary>
        public ResourceTypeRegistrationData()
        {
        }

        /// <summary> Initializes a new instance of ResourceTypeRegistrationData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"></param>
        internal ResourceTypeRegistrationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ResourceTypeRegistrationProperties properties) : base(id, name, resourceType, systemData)
        {
            Properties = properties;
        }

        /// <summary> Gets or sets the properties. </summary>
        public ResourceTypeRegistrationProperties Properties { get; set; }
    }
}
