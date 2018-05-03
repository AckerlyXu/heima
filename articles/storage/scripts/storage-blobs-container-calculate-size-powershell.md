---
title: Azure PowerShell Script Sample - Calculate blob container size | Microsoft Docs
description: Calculate the size of a container in Azure Blob storage by totaling the size of each of its blobs.
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
ms.devlang: powershell
ms.topic: sample
origin.date: 11/07/2017
ms.date: 05/07/2017
ms.author: v-johch
---

# Calculate the size of a Blob storage container

This script calculates the size of a container in Azure Blob storage by totaling the size of the blobs in the container.

[!INCLUDE [sample-powershell-install](../../../includes/sample-powershell-install-no-ssh.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

> [!IMPORTANT]
> This PowerShell script provides an estimated size for the container and should not be used for billing calculations. For a script that calculates container size for billing purposes, see [Calculate the size of a Blob storage container for billing purposes](../scripts/storage-blobs-container-calculate-billing-size-powershell.md). 

## Sample script
```powershell
# this script will show how to get the total size of the blobs in a container
# before running this, you need to create a storage account, create a container,
#    and upload some blobs into the container 
# note: this retrieves all of the blobs in the container in one command 
#       if you are going to run this against a container with a lot of blobs
#       (more than a couple hundred), use continuation tokens to retrieve
#       the list of blobs. We will be adding a sample showing that scenario in the future.

# these are for the storage account to be used
$resourceGroup = "bloblisttestrg"
$storageAccountName = "contosobloblisttest"
$containerName = "listtestblobs"

# get a reference to the storage account and the context
$storageAccount = Get-AzureRmStorageAccount `
  -ResourceGroupName $resourceGroup `
  -Name $storageAccountName
$ctx = $storageAccount.Context 

# get a list of all of the blobs in the container 
$listOfBLobs = Get-AzureStorageBlob -Container $ContainerName -Context $ctx 

# zero out our total
$length = 0

# this loops through the list of blobs and retrieves the length for each blob
#   and adds it to the total
$listOfBlobs | ForEach-Object {$length = $length + $_.Length}

# output the blobs and their sizes and the total 
Write-Host "List of Blobs and their size (length)"
Write-Host " " 
$listOfBlobs | select Name, Length
Write-Host " "
Write-Host "Total Length = " $length
```

## Clean up deployment 

Run the following command to remove the resource group, container, and all related resources.

```powershell
Remove-AzureRmResourceGroup -Name bloblisttestrg
```

## Script explanation

This script uses the following commands to calculate the size of the Blob storage container. Each item in the table links to command-specific documentation.

| Command | Notes |
|---|---|
| [Get-AzureRmStorageAccount](https://docs.microsoft.com/powershell/module/azurerm.storage/get-azurermstorageaccount) | Gets a specified Storage account or all of the Storage accounts in a resource group or the subscription. |
| [Get-AzureStorageBlob](https://docs.microsoft.com/powershell/module/azure.storage/get-azurestorageblob) | Lists blobs in a container. ||

## Next steps

For a script that calculates container size for billing purposes, see [Calculate the size of a Blob storage container for billing purposes](../scripts/storage-blobs-container-calculate-billing-size-powershell.md).

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional storage PowerShell script samples can be found in [PowerShell samples for Azure Storage](../blobs/storage-samples-blobs-powershell.md).
