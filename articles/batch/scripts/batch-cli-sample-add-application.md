---
title: Azure CLI Script Example - Add an Application in Batch | Microsoft Docs
description: Azure CLI Script Example - Add an Application in Batch
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

# CLI example: Add an application to an Azure Batch account

This script demonstrates how to add an application for use with an Azure Batch
pool or task. To set up an application to add to your Batch account, package your executable, together with any dependencies, into a zip file. 


If you choose to install and use the CLI locally, this article requires that you are running the Azure CLI version 2.0.20 or later. Run `az --version` to find the version. If you need to install or upgrade, see [Install Azure CLI 2.0](/cli/install-azure-cli). 

## Example script

```azurecli
#!/bin/bash

# Create a resource group.
az group create --name myResourceGroup --location chinanorth

# Create a general-purpose storage account in your resource group.
az storage account create \
    --resource-group myResourceGroup \
    --name mystorageaccount \
    --location chinanorth \
    --sku Standard_LRS

# Create a Batch account.
az batch account create \
    --name mybatchaccount \
    --storage-account mystorageaccount \
    --resource-group myResourceGroup \
    --location chinanorth

# Authenticate against the account directly for further CLI interaction.
az batch account login \
    --name mybatchaccount \
    --resource-group myResourceGroup \
    --shared-key-auth

# Create a new application.
az batch application create \
    --resource-group myResourceGroup \
    --name mybatchaccount \
    --application-id myapp \
    --display-name "My Application"

# An application can reference multiple application executable packages
# of different versions. The executables and any dependencies need
# to be zipped up for the package. Once uploaded, the CLI attempts
# to activate the package so that it's ready for use.
az batch application package create \
    --resource-group myResourceGroup \
    --name mybatchaccount \
    --application-id myapp \
    --package-file my-application-exe.zip \
    --version 1.0

# Update the application to assign the newly added application
# package as the default version.
az batch application set \
    --resource-group myResourceGroup \
    --name mybatchaccount \
    --application-id myapp \
    --default-version 1.0
```
## Clean up deployment

Run the following command to remove the
resource group and all resources associated with it.

```azurecli
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands.
Each command in the table links to command-specific documentation.

| Command | Notes |
|---|---|
| [az group create](/cli/group#az_group_create) | Creates a resource group in which all resources are stored. |
| [az storage account create](/cli/storage/account#az_storage_account_create) | Creates a storage account. |
| [az batch account create](/cli/batch/account#az_batch_account_create) | Creates the Batch account. |
| [az batch account login](/cli/batch/account#az_batch_account_login) | Authenticates against the specified Batch account for further CLI interaction.  |
| [az batch application create](/cli/batch/application#az_batch_application_create) | Creates an application.  |
| [az batch application package create](/cli/batch/application/package#az_batch_application_package_create) | Adds an application package to the specified application.  |
| [az batch application set](/cli/batch/application#az_batch_application_set) | Updates properties of an application.  |
| [az group delete](/cli/group#az_group_delete) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](/cli/overview).

