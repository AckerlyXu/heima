---
title: Azure PowerShell Script Sample - Delete containers by prefix | Microsoft Docs
description: Delete Azure Storage blob containers based on a container name prefix.
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

# Delete containers based on container name prefix

This script deletes containers in Azure Blob storage based on a prefix in the container name.

[!INCLUDE [sample-powershell-install](../../../includes/sample-powershell-install-no-ssh.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```powershell
# this script will show how to delete containers with a specific prefix 
# the prefix this will search for is "image". 
# before running this, you need to create a storage account, create some containers,
#    some having the same prefix so you can test this
# note: this retrieves all of the matching containers in one command 
#       if you are going to run this against a storage account with a lot of containers
#       (more than a couple hundred), use continuation tokens to retrieve
#       the list of containers. We will be adding a sample showing that scenario in the future.

# these are for the storage account to be used
#   and the prefix for which to search
$resourceGroup = "containerdeletetestrg"
$location = "China East"
$storageAccountName = "containerdeletetest"
$prefix = "image"

# get a reference to the storage account and the context
$storageAccount = Get-AzureRmStorageAccount `
  -ResourceGroupName $resourceGroup `
  -Name $storageAccountName
$ctx = $storageAccount.Context 

# list all containers in the storage account 
Write-Host "All containers"
Get-AzureStorageContainer -Context $ctx | select Name

# retrieve list of containers to delete
$listOfContainersToDelete = Get-AzureStorageContainer -Context $ctx -Prefix $prefix

# write list of containers to be deleted 
Write-Host "Containers to be deleted"
$listOfContainersToDelete | select Name

# delete the containers; this pipes the result of the listing of the containers to delete
#    into the Remove-AzureStorageContainer command. It handles all of the containers in the list.
Write-Host "Deleting containers"
$listOfContainersToDelete | Remove-AzureStorageContainer -Context $ctx 

# show list of containers not deleted 
Write-Host "All containers not deleted"
Get-AzureStorageContainer -Context $ctx | select Name
```

## Clean up deployment 

Run the following command to remove the resource group, remaining containers, and all related resources.

```powershell
Remove-AzureRmResourceGroup -Name containerdeletetestrg
```

## Script explanation

This script uses the following commands to delete containers based on container name prefix. Each item in the table links to command-specific documentation.

| Command | Notes |
|---|---|
| [Get-AzureRmStorageAccount](https://docs.microsoft.com/powershell/module/azurerm.storage/get-azurermstorageaccount) | Gets a specified Storage account or all of the Storage accounts in a resource group or the subscription. |
| [Get-AzureStorageContainer](https://docs.microsoft.com/powershell/module/azure.storage/get-azurestoragecontainer) | Lists the storage containers associated with a storage account. |
| [Remove-AzureStorageContainer](https://docs.microsoft.com/powershell/module/azure.storage/remove-azurestoragecontainer) | Removes the specified storage container. |

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional storage PowerShell script samples can be found in [PowerShell samples for Azure Blob storage](../blobs/storage-samples-blobs-powershell.md).
