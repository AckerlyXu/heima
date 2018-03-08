---
title: Azure CLI Script Example - Create Batch account - user subscription | Microsoft Docs
description: Azure CLI Script Example - Create a Batch account in user subscription mode
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

# CLI example: Create a Batch account in user subscription mode

This script creates an Azure Batch account in user subscription mode. An account that allocates compute nodes into your subscription must be authenticated via an Azure Active Directory token. The compute nodes allocated count toward your subscription's vCPU (core) quota. 

If you choose to install and use the CLI locally, this article requires that you are running the Azure CLI version 2.0.20 or later. Run `az --version` to find the version. If you need to install or upgrade, see [Install Azure CLI 2.0](/cli/install-azure-cli). 

## Example script
```azurecli
#!/bin/bash

# Allow Azure Batch to access the subscription (one-time operation).
az role assignment create \
    --assignee MicrosoftAzureBatch 
    --role contributor

# Create a resource group.
az group create --name myResourceGroup --location chinanorth

# Create an Azure Key Vault. A Batch account that allocates pools in the user's subscription 
# must be configured with a Key Vault located in the same region. 
az keyvault create \
    --resource-group myResourceGroup \
    --name mykevault \
    --location chinanorth \
    --enabled-for-deployment true \
    --enabled-for-disk-encryption true \
    --enabled-for-template-deployment true

# Add an access policy to the Key Vault to allow access by the Batch Service.
az keyvault set-policy \
    --resource-group myResourceGroup \
    --name mykevault \
    --spn ddbf3205-c6bd-46ae-8127-60eb93363864 \
    --key-permissions all \
    --secret-permissions all

# Create the Batch account, referencing the Key Vault either by name (if they
# exist in the same resource group) or by its full resource ID.
az batch account create \
    --resource-group myResourceGroup \
    --name mybatchaccount \
    --location chinanorth \
    --keyvault mykevault

# Authenticate directly against the account for further CLI interaction.
# Batch accounts that allocate pools in the user's subscription must be
# authenticated via an Azure Active Directory token.
az batch account login -g myResourceGroup -n mybatchaccount
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
| [az role assignment create](/cli/role#az_role_assignment_create) | Create a new role assignment for a user, group, or service principal. |
| [az group create](/cli/group#az_group_create) | Creates a resource group in which all resources are stored. |
| [az keyvault create](/cli/keyvault#az_keyvault_create) | Creates a key vault. |
| [az keyvault set-policy](/cli/keyvault#az_keyvault_set_policy) | Update the security policy of the specified key vault. |
| [az batch account create](/cli/batch/account#az_batch_account_create) | Creates the Batch account.  |
| [az batch account login](/cli/batch/account#az_batch_account_login) | Authenticates against the specified Batch account for further CLI interaction.  |
| [az group delete](/cli/group#az_group_delete) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](/cli/overview).

