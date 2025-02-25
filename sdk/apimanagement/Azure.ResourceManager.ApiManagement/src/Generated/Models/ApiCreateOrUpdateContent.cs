// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.ApiManagement.Models
{
    /// <summary> API Create or Update Parameters. </summary>
    public partial class ApiCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of ApiCreateOrUpdateContent. </summary>
        public ApiCreateOrUpdateContent()
        {
            Protocols = new ChangeTrackingList<ApiOperationInvokableProtocol>();
        }

        /// <summary> Description of the API. May include HTML formatting tags. </summary>
        public string Description { get; set; }
        /// <summary> Collection of authentication settings included into this API. </summary>
        public AuthenticationSettingsContract AuthenticationSettings { get; set; }
        /// <summary> Protocols over which API is made available. </summary>
        public SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get; set; }
        /// <summary> Type of API. </summary>
        public ApiType? ApiType { get; set; }
        /// <summary> Describes the revision of the API. If no value is provided, default revision 1 is created. </summary>
        public string ApiRevision { get; set; }
        /// <summary> Indicates the version identifier of the API if the API is versioned. </summary>
        public string ApiVersion { get; set; }
        /// <summary> Indicates if API revision is current api revision. </summary>
        public bool? IsCurrent { get; set; }
        /// <summary> Indicates if API revision is accessible via the gateway. </summary>
        public bool? IsOnline { get; }
        /// <summary> Description of the API Revision. </summary>
        public string ApiRevisionDescription { get; set; }
        /// <summary> Description of the API Version. </summary>
        public string ApiVersionDescription { get; set; }
        /// <summary> A resource identifier for the related ApiVersionSet. </summary>
        public ResourceIdentifier ApiVersionSetId { get; set; }
        /// <summary> Specifies whether an API or Product subscription is required for accessing the API. </summary>
        public bool? IsSubscriptionRequired { get; set; }
        /// <summary> A URL to the Terms of Service for the API. MUST be in the format of a URL. </summary>
        public Uri TermsOfServiceUri { get; set; }
        /// <summary> Contact information for the API. </summary>
        public ApiContactInformation Contact { get; set; }
        /// <summary> License information for the API. </summary>
        public ApiLicenseInformation License { get; set; }
        /// <summary> API identifier of the source API. </summary>
        public ResourceIdentifier SourceApiId { get; set; }
        /// <summary> API name. Must be 1 to 300 characters long. </summary>
        public string DisplayName { get; set; }
        /// <summary> Absolute URL of the backend service implementing this API. Cannot be more than 2000 characters long. </summary>
        public Uri ServiceUri { get; set; }
        /// <summary> Relative URL uniquely identifying this API and all of its resource paths within the API Management service instance. It is appended to the API endpoint base URL specified during the service instance creation to form a public URL for this API. </summary>
        public string Path { get; set; }
        /// <summary> Describes on which protocols the operations in this API can be invoked. </summary>
        public IList<ApiOperationInvokableProtocol> Protocols { get; }
        /// <summary> Version set details. </summary>
        public ApiVersionSetContractDetails ApiVersionSet { get; set; }
        /// <summary> Content value when Importing an API. </summary>
        public string Value { get; set; }
        /// <summary> Format of the Content in which the API is getting imported. </summary>
        public ContentFormat? Format { get; set; }
        /// <summary> Criteria to limit import of WSDL to a subset of the document. </summary>
        public ApiCreateOrUpdatePropertiesWsdlSelector WsdlSelector { get; set; }
        /// <summary>
        /// Type of API to create. 
        ///  * `http` creates a REST API 
        ///  * `soap` creates a SOAP pass-through API  
        ///  * `websocket` creates websocket API 
        ///  * `graphql` creates GraphQL API.
        /// </summary>
        public SoapApiType? SoapApiType { get; set; }
    }
}
