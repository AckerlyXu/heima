---
title: Azure PowerShell Script Sample - Rotate storage account access key | Microsoft Docs
description: Create an Azure Storage account, then retrieve and rotate one of its account access keys.
services: storage
documentationcenter: na
author: forester123
manager: digimobile
editor: tysonn

ms.assetid:
ms.custom: mvc
ms.service: storage
ms.workload: storage
ms.tgt_pltfrm: na
ms.devlang: azurecli
ms.topic: sample
origin.date: 06/13/2017
ms.date: 10/23/2017
ms.author: v-johch
---

# Create a storage account and rotate its account access keys

This script creates an Azure Storage account, displays the new storage account's primary access key, then renews (rotates) the key.

[!INCLUDE [sample-powershell-install](../../../includes/sample-powershell-install-no-ssh.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```powershell
# this script will show how to rotate one of the access keys for a storage account

# get list of locations and pick one
Get-AzureRmLocation | select Location

# save the location you want to use  
$location = "China East"

# create a resource group
$resourceGroup = "rotatekeystestrg"
New-AzureRmResourceGroup -Name $resourceGroup -Location $location 

# create a standard general-purpose storage account 
$storageAccountName = "contosotestkeys"
New-AzureRmStorageAccount -ResourceGroupName $resourceGroup `
  -Name $storageAccountName `
  -Location $location `
  -SkuName Standard_LRS `

# retrieve the first storage account key and display it 
$storageAccountKey = (Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroup -Name $storageAccountName).Value[0]

Write-Host "storage account key 1 = " $storageAccountKey

# re-generate the key
New-AzureRmStorageAccountKey -ResourceGroupName $resourceGroup `
    -Name $storageAccountName `
    -KeyName key1

# retrieve it again and display it 
$storageAccountKey = (Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroup -Name $storageAccountName).Value[0]
Write-Host "storage account key 1 = " $storageAccountKey
```

## Clean up deployment 

Run the following command to remove the resource group, storage account, and all related resources.

```powershell
Remove-AzureRmResourceGroup -Name rotatekeystestrg
```

## Script explanation

This script uses the following commands to create the storage account and retrieve and rotate one of its access keys. Each item in the table links to command-specific documentation.

| Command | Notes |
|---|---|
| [Get-AzureRmLocation](https://docs.microsoft.com/powershell/module/azurerm.resources/get-azurermlocation) | Gets all locations and the supported resource providers for each location. |
| [New-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/new-azurermresourcegroup) | Creates an Azure resource group. |
| [New-AzureRmStorageAccount](https://docs.microsoft.com/powershell/module/azurerm.storage/new-azurermstorageaccount) | Creates a Storage account. |
| [Get-AzureRmStorageAccountKey](https://docs.microsoft.com/powershell/module/azurerm.storage/get-azurermstorageaccountkey) | Gets the access keys for an Azure Storage account. |
| [New-AzureRmStorageAccountKey](https://docs.microsoft.com/powershell/module/azurerm.storage/new-azurermstorageaccountkey) | Regenerates an access key for an Azure Storage account. |

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional storage PowerShell script samples can be found in [PowerShell samples for Azure Blob storage](../blobs/storage-samples-blobs-powershell.md).
