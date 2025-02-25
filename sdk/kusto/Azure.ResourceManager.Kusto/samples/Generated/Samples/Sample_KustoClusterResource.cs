// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Kusto;
using Azure.ResourceManager.Kusto.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Kusto.Samples
{
    public partial class Sample_KustoClusterResource
    {
        // KustoClustersGet
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_KustoClustersGet()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClustersGet.json
            // this example is just showing the usage of "Clusters_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation
            KustoClusterResource result = await kustoCluster.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            KustoClusterData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // KustoClustersUpdate
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_KustoClustersUpdate()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClustersUpdate.json
            // this example is just showing the usage of "Clusters_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster2";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation
            KustoClusterPatch patch = new KustoClusterPatch(new AzureLocation("westus"));
            string ifMatch = "*";
            ArmOperation<KustoClusterResource> lro = await kustoCluster.UpdateAsync(WaitUntil.Completed, patch, ifMatch: ifMatch);
            KustoClusterResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            KustoClusterData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // KustoClustersDelete
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Delete_KustoClustersDelete()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClustersDelete.json
            // this example is just showing the usage of "Clusters_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster2";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation
            await kustoCluster.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }

        // KustoClustersStop
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Stop_KustoClustersStop()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClustersStop.json
            // this example is just showing the usage of "Clusters_Stop" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster2";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation
            await kustoCluster.StopAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }

        // KustoClustersStart
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Start_KustoClustersStart()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClustersStart.json
            // this example is just showing the usage of "Clusters_Start" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster2";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation
            await kustoCluster.StartAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }

        // KustoClusterListFollowerDatabases
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetFollowerDatabases_KustoClusterListFollowerDatabases()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClusterListFollowerDatabases.json
            // this example is just showing the usage of "Clusters_ListFollowerDatabases" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation and iterate over the result
            await foreach (KustoFollowerDatabaseDefinition item in kustoCluster.GetFollowerDatabasesAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine($"Succeeded");
        }

        // KustoClusterDetachFollowerDatabases
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task DetachFollowerDatabases_KustoClusterDetachFollowerDatabases()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClusterDetachFollowerDatabases.json
            // this example is just showing the usage of "Clusters_DetachFollowerDatabases" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation
            KustoFollowerDatabaseDefinition followerDatabaseToRemove = new KustoFollowerDatabaseDefinition(new ResourceIdentifier("/subscriptions/12345678-1234-1234-1234-123456789098/resourceGroups/kustorptest/providers/Microsoft.Kusto/clusters/kustoCluster2"), "attachedDatabaseConfigurationsTest");
            await kustoCluster.DetachFollowerDatabasesAsync(WaitUntil.Completed, followerDatabaseToRemove);

            Console.WriteLine($"Succeeded");
        }

        // KustoClusterDiagnoseVirtualNetwork
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task DiagnoseVirtualNetwork_KustoClusterDiagnoseVirtualNetwork()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClustersDiagnoseVirtualNetwork.json
            // this example is just showing the usage of "Clusters_DiagnoseVirtualNetwork" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation
            ArmOperation<DiagnoseVirtualNetworkResult> lro = await kustoCluster.DiagnoseVirtualNetworkAsync(WaitUntil.Completed);
            DiagnoseVirtualNetworkResult result = lro.Value;

            Console.WriteLine($"Succeeded: {result}");
        }

        // KustoClustersList
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetKustoClusters_KustoClustersList()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClustersList.json
            // this example is just showing the usage of "Clusters_List" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation and iterate over the result
            await foreach (KustoClusterResource item in subscriptionResource.GetKustoClustersAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                KustoClusterData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }

        // KustoClustersListSkus
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetKustoEligibleSkus_KustoClustersListSkus()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClustersListSkus.json
            // this example is just showing the usage of "Clusters_ListSkus" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation and iterate over the result
            await foreach (KustoSkuDescription item in subscriptionResource.GetKustoEligibleSkusAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine($"Succeeded");
        }

        // KustoClustersCheckNameAvailability
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CheckKustoClusterNameAvailability_KustoClustersCheckNameAvailability()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClustersCheckNameAvailability.json
            // this example is just showing the usage of "Clusters_CheckNameAvailability" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation
            AzureLocation location = new AzureLocation("westus");
            KustoClusterNameAvailabilityContent content = new KustoClusterNameAvailabilityContent("kustoCluster");
            KustoNameAvailabilityResult result = await subscriptionResource.CheckKustoClusterNameAvailabilityAsync(location, content);

            Console.WriteLine($"Succeeded: {result}");
        }

        // KustoClustersListResourceSkus
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetAvailableSkus_KustoClustersListResourceSkus()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClustersListResourceSkus.json
            // this example is just showing the usage of "Clusters_ListSkusByResource" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation and iterate over the result
            await foreach (KustoAvailableSkuDetails item in kustoCluster.GetAvailableSkusAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine($"Succeeded");
        }

        // Get Kusto cluster outbound network dependencies
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetOutboundNetworkDependenciesEndpoints_GetKustoClusterOutboundNetworkDependencies()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoOutboundNetworkDependenciesList.json
            // this example is just showing the usage of "Clusters_ListOutboundNetworkDependenciesEndpoints" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "34adfa4f-cedf-4dc0-ba29-b6d1a69ab345";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation and iterate over the result
            await foreach (OutboundNetworkDependenciesEndpoint item in kustoCluster.GetOutboundNetworkDependenciesEndpointsAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine($"Succeeded");
        }

        // KustoClusterListLanguageExtensions
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetLanguageExtensions_KustoClusterListLanguageExtensions()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClusterListLanguageExtensions.json
            // this example is just showing the usage of "Clusters_ListLanguageExtensions" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation and iterate over the result
            await foreach (KustoLanguageExtension item in kustoCluster.GetLanguageExtensionsAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine($"Succeeded");
        }

        // KustoClusterAddLanguageExtensions
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task AddLanguageExtensions_KustoClusterAddLanguageExtensions()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClusterAddLanguageExtensions.json
            // this example is just showing the usage of "Clusters_AddLanguageExtensions" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation
            KustoLanguageExtensionList languageExtensionsToAdd = new KustoLanguageExtensionList()
            {
                Value =
{
new KustoLanguageExtension()
{
LanguageExtensionName = KustoLanguageExtensionName.Python,
},new KustoLanguageExtension()
{
LanguageExtensionName = KustoLanguageExtensionName.R,
}
},
            };
            await kustoCluster.AddLanguageExtensionsAsync(WaitUntil.Completed, languageExtensionsToAdd);

            Console.WriteLine($"Succeeded");
        }

        // KustoClusterRemoveLanguageExtensions
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task RemoveLanguageExtensions_KustoClusterRemoveLanguageExtensions()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClusterRemoveLanguageExtensions.json
            // this example is just showing the usage of "Clusters_RemoveLanguageExtensions" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation
            KustoLanguageExtensionList languageExtensionsToRemove = new KustoLanguageExtensionList()
            {
                Value =
{
new KustoLanguageExtension()
{
LanguageExtensionName = KustoLanguageExtensionName.Python,
},new KustoLanguageExtension()
{
LanguageExtensionName = KustoLanguageExtensionName.R,
}
},
            };
            await kustoCluster.RemoveLanguageExtensionsAsync(WaitUntil.Completed, languageExtensionsToRemove);

            Console.WriteLine($"Succeeded");
        }

        // KustoClusterPrincipalAssignmentsCheckNameAvailability
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CheckKustoClusterPrincipalAssignmentNameAvailability_KustoClusterPrincipalAssignmentsCheckNameAvailability()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoClusterPrincipalAssignmentsCheckNameAvailability.json
            // this example is just showing the usage of "ClusterPrincipalAssignments_CheckNameAvailability" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation
            KustoClusterPrincipalAssignmentNameAvailabilityContent content = new KustoClusterPrincipalAssignmentNameAvailabilityContent("kustoprincipal1");
            KustoNameAvailabilityResult result = await kustoCluster.CheckKustoClusterPrincipalAssignmentNameAvailabilityAsync(content);

            Console.WriteLine($"Succeeded: {result}");
        }

        // KustoDatabasesCheckNameAvailability
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CheckKustoDatabaseNameAvailability_KustoDatabasesCheckNameAvailability()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoDatabasesCheckNameAvailability.json
            // this example is just showing the usage of "Databases_CheckNameAvailability" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation
            KustoDatabaseNameAvailabilityContent content = new KustoDatabaseNameAvailabilityContent("database1", KustoDatabaseResourceType.MicrosoftKustoClustersDatabases);
            KustoNameAvailabilityResult result = await kustoCluster.CheckKustoDatabaseNameAvailabilityAsync(content);

            Console.WriteLine($"Succeeded: {result}");
        }

        // KustoAttachedDatabaseConfigurationCheckNameAvailability
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CheckKustoAttachedDatabaseConfigurationNameAvailability_KustoAttachedDatabaseConfigurationCheckNameAvailability()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoAttachedDatabaseConfigurationCheckNameAvailability.json
            // this example is just showing the usage of "AttachedDatabaseConfigurations_CheckNameAvailability" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation
            KustoAttachedDatabaseConfigurationNameAvailabilityContent content = new KustoAttachedDatabaseConfigurationNameAvailabilityContent("adc1");
            KustoNameAvailabilityResult result = await kustoCluster.CheckKustoAttachedDatabaseConfigurationNameAvailabilityAsync(content);

            Console.WriteLine($"Succeeded: {result}");
        }

        // KustoManagedPrivateEndpointsCheckNameAvailability
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CheckKustoManagedPrivateEndpointNameAvailability_KustoManagedPrivateEndpointsCheckNameAvailability()
        {
            // Generated from example definition: specification/azure-kusto/resource-manager/Microsoft.Kusto/stable/2022-12-29/examples/KustoManagedPrivateEndpointsCheckNameAvailability.json
            // this example is just showing the usage of "ManagedPrivateEndpoints_CheckNameAvailability" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this KustoClusterResource created on azure
            // for more information of creating KustoClusterResource, please refer to the document of KustoClusterResource
            string subscriptionId = "12345678-1234-1234-1234-123456789098";
            string resourceGroupName = "kustorptest";
            string clusterName = "kustoCluster";
            ResourceIdentifier kustoClusterResourceId = KustoClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            KustoClusterResource kustoCluster = client.GetKustoClusterResource(kustoClusterResourceId);

            // invoke the operation
            KustoManagedPrivateEndpointNameAvailabilityContent content = new KustoManagedPrivateEndpointNameAvailabilityContent("pme1");
            KustoNameAvailabilityResult result = await kustoCluster.CheckKustoManagedPrivateEndpointNameAvailabilityAsync(content);

            Console.WriteLine($"Succeeded: {result}");
        }
    }
}
