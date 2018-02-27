---
title: Azure PowerShell Script Sample - Backup and restore service
description: Azure PowerShell Script Sample - Backup and restore service
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

# Backup and restore service

This sample shown in this article shows how to backup and restore the API Management service instance. 


If you choose to install and use the PowerShell locally, this tutorial requires the Azure PowerShell module version 3.6 or later. Run ` Get-Module -ListAvailable AzureRM` to find the version. If you need to upgrade, see [Install Azure PowerShell module](https://docs.microsoft.com/en-us/powershell/azure/install-azurerm-ps). If you are running PowerShell locally, you also need to run `Login-AzureRmAccount -Environment AzureChinaCloud` to create a connection with Azure.

## Sample script

```powershell
##########################################################
#  Script to backup and restore api management service.
###########################################################

$random = (New-Guid).ToString().Substring(0,8)

#Azure specific details
$subscriptionId = "my-azure-subscription-id"
 

# Api Management service specific details
$apiManagementName = "apim-$random"
$resourceGroupName = "apim-rg-$random"
$location = "China East"
$organisation = "Contoso"
$adminEmail = "admin@contoso.com"
 
# Storage Account details
$storageAccountName = "backup$random"
$containerName = "backups"
$backupName = $apiManagementName + ".apimbackup"
 
# Select into the ResourceGroup
Select-AzureRmSubscription -SubscriptionId $subscriptionId
 
# Create a Resource Group 
New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
 
# Create storage account    
New-AzureRmStorageAccount -StorageAccountName $storageAccountName -Location $location -ResourceGroupName $resourceGroupName -Type Standard_LRS
$storageKey = (Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName)[0].Value
$storageContext = New-AzureStorageContext -StorageAccountName $storageAccountName -StorageAccountKey $storageKey
 
# Create API Management service
New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Location $location -Name $apiManagementName -Organization $organisation -AdminEmail $adminEmail
 
# Backup API Management service.
Backup-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName -StorageContext $storageContext -TargetContainerName $containerName -TargetBlobName $backupName
 
# Restore API Management service
Restore-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName -StorageContext $storageContext -SourceContainerName $containerName -SourceBlobName $backupName
```

## Clean up resources

When no longer needed, you can use the [Remove-AzureRmResourceGroup](https://docs.microsoft.com/en-us//powershell/module/azurerm.resources/remove-azurermresourcegroup) command to remove the resource group and all related resources.

```azurepowershell
Remove-AzureRmResourceGroup -Name myResourceGroup
```

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional Azure Powershell samples for Azure API Management can be found in the [PowerShell samples](../powershell-samples.md).
