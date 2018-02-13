---
title: Azure PowerShell Script Sample - Scale the service instance
description: Azure PowerShell Script Sample - Scale the service instance
services: api-management
documentationcenter: ''
author: juliako
manager: cfowler
editor: ''

ms.service: api-management
ms.workload: mobile
ms.devlang: na
ms.topic: sample
origin.date: 11/16/2017
ms.date: 02/26/2018
ms.author: v-yiso
ms.custom: mvc
---

# Scale the service instance

This sample script scales and adds region to the API Management service instance.


If you choose to install and use the PowerShell locally, this tutorial requires the Azure PowerShell module version 3.6 or later. Run ` Get-Module -ListAvailable AzureRM` to find the version. If you need to upgrade, see [Install Azure PowerShell module](https://docs.microsoft.com/en-us/powershell/azure/install-azurerm-ps). If you are running PowerShell locally, you also need to run `Login-AzureRmAccount -Environment AzureChinaCloud` to create a connection with Azure.

## Sample script

```powershell
##########################################################
#  Script to create an apim service and scale to premium 
#  with an additional region.
###########################################################

$random = (New-Guid).ToString().Substring(0,8)

#Azure specific details
$subscriptionId = "my-azure-subscription-id"

# Api Management service specific details
$apimServiceName = "apim-$random"
$resourceGroupName = "apim-rg-$random"
$location = "China East"
$organisation = "Contoso"
$adminEmail = "admin@contoso.com"

# Set the context to the subscription Id where the cluster will be created
Select-AzureRmSubscription -SubscriptionId $subscriptionId

# Create a resource group.
New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

# Create the Api Management service. Since the SKU is not specified, it creates a service with Developer SKU. 
New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apimServiceName -Location $location -Organization $organisation -AdminEmail $adminEmail

# Scale master region to 'Premium' 1
$sku = "Premium"
$capacity = 1

# Add new 'Premium' region 1 unit
$additionLocation = Get-ProviderLocations "Microsoft.ApiManagement/service" | Where-Object {$_ -ne $location} | Select-Object -First 1

Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apimServiceName |
Update-AzureRmApiManagementRegion -Sku $sku -Capacity $capacity |
Add-AzureRmApiManagementRegion -Location $additionLocation -Sku $sku |
Update-AzureRmApiManagementDeployment

Get-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apimServiceName
```

## Clean up resources

When no longer needed, you can use the [Remove-AzureRmResourceGroup](https://docs.microsoft.com/en-us/powershell/module/azurerm.resources/remove-azurermresourcegroup) command to remove the resource group and all related resources.

```azurepowershell
Remove-AzureRmResourceGroup -Name myResourceGroup
```

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional Azure Powershell samples for Azure API Management can be found in the [PowerShell samples](../powershell-samples.md).
