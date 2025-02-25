// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Peering;

namespace Azure.ResourceManager.Peering.Models
{
    /// <summary> The paginated list of peer ASNs. </summary>
    internal partial class PeerAsnListResult
    {
        /// <summary> Initializes a new instance of PeerAsnListResult. </summary>
        internal PeerAsnListResult()
        {
            Value = new ChangeTrackingList<PeerAsnData>();
        }

        /// <summary> Initializes a new instance of PeerAsnListResult. </summary>
        /// <param name="value"> The list of peer ASNs. </param>
        /// <param name="nextLink"> The link to fetch the next page of peer ASNs. </param>
        internal PeerAsnListResult(IReadOnlyList<PeerAsnData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of peer ASNs. </summary>
        public IReadOnlyList<PeerAsnData> Value { get; }
        /// <summary> The link to fetch the next page of peer ASNs. </summary>
        public string NextLink { get; }
    }
}
