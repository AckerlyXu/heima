---
title: Azure CLI Script Sample - Rotate storage account access keys | Microsoft Docs
description: Create an Azure Storage account, then retrieve and rotate its account access keys.
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
origin.date: 06/22/2017
ms.date: 10/23/2017
ms.author: v-johch
---

# Create a storage account and rotate its account access keys

This script creates an Azure Storage account, displays the new storage account's access keys, then renews (rotates) the keys.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurecli
#!/bin/bash

# Create a resource group
az group create --name myResourceGroup --location chinaeast

# Create a general-purpose standard storage account
az storage account create \
    --name mystorageaccount \
    --resource-group myResourceGroup \
    --location chinaeast \
    --sku Standard_RAGRS \
    --encryption blob

# List the storage account access keys
az storage account keys list \
    --resource-group myResourceGroup \
    --account-name mystorageaccount 

# Renew (rotate) the PRIMARY access key
az storage account keys renew \
    --resource-group myResourceGroup \
    --account-name mystorageaccount \
    --key primary

# Renew (rotate) the SECONDARY access key
az storage account keys renew \
    --resource-group myResourceGroup \
    --account-name mystorageaccount \
    --key secondary
```

## Clean up deployment 

Run the following command to remove the resource group, storage account, and all related resources.

```azurecli
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands to create the storage account and retrieve and rotate its access keys. Each item in the table links to command-specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.microsoft.com/cli/azure/group#create) | Creates a resource group in which all resources are stored. |
| [az storage account create](https://docs.microsoft.com/cli/azure/storage/account#create) | Creates an Azure Storage account in the specified resource group. |
| [az storage account keys list](https://docs.microsoft.com/cli/azure/storage/account/keys#list) | Displays the storage account access keys for the specified account. |
| [az storage account keys renew](https://docs.microsoft.com/cli/azure/storage/account/keys#renew) | Regenerates the primary or secondary storage account access key. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional storage CLI script samples can be found in the [Azure CLI samples for Azure Blob storage](../blobs/storage-samples-blobs-cli.md).
