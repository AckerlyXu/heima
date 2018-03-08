---
title: Azure CLI Script Example - Create Batch account - Batch service | Microsoft Docs
description: Azure CLI Script Example - Create a Batch account in Batch service mode
services: batch
documentationcenter: ''
author: dlepow
manager: jeconnoc
editor: 

ms.assetid:
ms.service: batch
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: multiple
ms.workload: na
origin.date: 01/29/2018
ms.date: 03/05/2018
ms.author: v-junlch
---

# CLI example: Create a Batch account in Batch service mode

This script creates an Azure Batch account in Batch service mode and shows how to query or update various properties of the account. When you create a Batch account in the default Batch service mode, its compute nodes are assigned internally by the Batch
service. Allocated compute nodes are subject to a separate vCPU (core) quota and the account can be 
authenticated either via shared key credentials or an Azure Active Directory token.

If you choose to install and use the CLI locally, this article requires that you are running the Azure CLI version 2.0.20 or later. Run `az --version` to find the version. If you need to install or upgrade, see [Install Azure CLI 2.0](/cli/install-azure-cli). 

## Example script
```azurecli
#!/bin/bash

# Create a resource group.
az group create --name myResourceGroup --location chinanorth

# Create a Batch account.
az batch account create \
    --resource-group myResourceGroup \
    --name mybatchaccount \
    --location chinanorth

# Display the details of the created account.
az batch account show \
    --resource-group myResourceGroup \ 
    --name mybatchaccount

# Add a storage account reference to the Batch account for use as 'auto-storage'
# for applications. Start by creating the storage account.
az storage account create \
    --resource-group myResourceGroup \
    --name mystorageaccount \
    --location chinanorth \
    --sku Standard_LRS

# Update the Batch account with the either the name (if they exist in
# the same resource group) or the full resource ID of the storage account.
az batch account set \
    --resource-group myResourceGroup \
    --name mybatchaccount \
    --storage-account mystorageaccount

# View the access keys to the Batch Account for future client authentication.
az batch account keys list \
    --resource-group myResourceGroup \
    --name mybatchaccount

# Authenticate against the account directly for further CLI interaction.
az batch account login \
    --resource-group myResourceGroup \
    --name mybatchaccount \
    --shared-key-auth
```
## Clean up deployment

Run the following command to remove the
resource group and all resources associated with it.

```azurecli
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands. Each command in the table links to command-specific documentation.

| Command | Notes |
|---|---|
| [az group create](/cli/group#az_group_create) | Creates a resource group in which all resources are stored. |
| [az batch account create](/cli/batch/account#az_batch_account_create) | Creates the Batch account. |
| [az storage account create](/cli/storage/account#az_storage_account_create) | Creates a storage account. |
| [az batch account set](/cli/batch/account#az_batch_account_set) | Updates properties of the Batch account.  |
| [az batch account show](/cli/batch/account#az_batch_account_show) | Retrieves details of the specified Batch account.  |
| [az batch account keys list](/cli/batch/account/keys#az_batch_account_keys_list) | Retrieves the access keys of the specified Batch account.  |
| [az batch account login](/cli/batch/account#az_batch_account_login) | Authenticates against the specified Batch account for further CLI interaction.  |
| [az group delete](/cli/group#az_group_delete) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](/cli/overview).

