---
title: Azure PowerShell Script Sample - Add a user
description: Azure PowerShell Script Sample - Add a user
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
ms.author: apimpm
ms.custom: mvc
---

# Add a user

This sample script creates a user in API Management and gets a subscription key.

[!INCLUDE [cloud-shell-powershell.md](../../../includes/cloud-shell-powershell.md)]

If you choose to install and use the PowerShell locally, this tutorial requires the Azure PowerShell module version 3.6 or later. Run ` Get-Module -ListAvailable AzureRM` to find the version. If you need to upgrade, see [Install Azure PowerShell module](https://docs.microsoft.com/en-us/powershell/azure/install-azurerm-ps). If you are running PowerShell locally, you also need to run `Login-AzureRmAccount -Environment AzureChinaCloud` to create a connection with Azure.

## Sample script

```powershell
##########################################################
#  Script to create a user in api management and get a subscription key
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

# User specific details
$userEmail = "user@contoso.com"
$userFirstName = "userFirstName"
$userLastName = "userLastName"
$userPassword = "userPassword"
$userNote = "fellow trying out my apim instance"
$userState = "Active"

# Subscription Name details
$subscriptionName = "subscriptionName"
$subscriptionState = "Active"

# Set the context to the subscription Id where the cluster will be created
Select-AzureRmSubscription -SubscriptionId $subscriptionId

# Create a resource group.
New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

# Create the Api Management service. Since the SKU is not specified, it creates a service with Developer SKU. 
New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apimServiceName -Location $location -Organization $organisation -AdminEmail $adminEmail

# Create the api management context
$context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $apimServiceName

# create a new user in api management
$user = New-AzureRmApiManagementUser -Context $context -FirstName $userFirstName -LastName $userLastName `
    -Password $userPassword -State $userState -Note $userNote -Email $userEmail

# get the details of the 'Starter' product in api management, which is created by default
$product = Get-AzureRmApiManagementProduct -Context $context -Title 'Starter' | Select-Object -First 1

# generate a subscription key for the user to call apis which are part of the 'Starter' product
New-AzureRmApiManagementSubscription -Context $context -UserId $user.UserId `
    -ProductId $product.ProductId -Name $subscriptionName -State $subscriptionState
```

## Clean up resources

When no longer needed, you can use the [Remove-AzureRmResourceGroup](https://docs.microsoft.com/en-us/powershell/module/azurerm.resources/remove-azurermresourcegroup) command to remove the resource group and all related resources.

```azurepowershell-interactive
Remove-AzureRmResourceGroup -Name myResourceGroup
```

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional Azure Powershell samples for Azure API Management can be found in the [PowerShell samples](../powershell-samples.md).
