---
title: Azure PowerShell Script Sample - Set up rate limit policy
description: Azure PowerShell Script Sample - Set up rate limit policy
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

# Set up rate limit policy

This sample script sets up  rate limit policy. 

[!INCLUDE [cloud-shell-powershell.md](../../../includes/cloud-shell-powershell.md)]

If you choose to install and use the PowerShell locally, this tutorial requires the Azure PowerShell module version 3.6 or later. Run ` Get-Module -ListAvailable AzureRM` to find the version. If you need to upgrade, see [Install Azure PowerShell module](https://docs.microsoft.com/en-us/powershell/azure/install-azurerm-ps). If you are running PowerShell locally, you also need to run `Login-AzureRmAccount -Environment AzureChinaCloud` to create a connection with Azure.

## Sample script

```powershell
##########################################################
#  Script to apply Rate Limit to Policy at the Product Level 
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

# create a rate-limit product level policy
$productValid = '<policies><inbound><rate-limit calls="5" renewal-period="60" /><quota calls="100" renewal-period="604800" /><base /></inbound><outbound><base /></outbound></policies>'
$product = Get-AzureRmApiManagementProduct -Context $context -Title 'Unlimited' | Select-Object -First 1

# setup Policy at the Product Level. Policies can be applied at entire API Management Service Scope, Api Scope, Product Scope and Api Operation Scope
Set-AzureRmApiManagementPolicy -Context $context  -Policy $productValid -ProductId $product.ProductId -PassThru
```

## Clean up resources

When no longer needed, you can use the [Remove-AzureRmResourceGroup](https://docs.microsoft.com/en-us/powershell/module/azurerm.resources/remove-azurermresourcegroup) command to remove the resource group and all related resources.

```azurepowershell-interactive
Remove-AzureRmResourceGroup -Name myResourceGroup
```
## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional Azure Powershell samples for Azure API Management can be found in the [PowerShell samples](../powershell-samples.md).
