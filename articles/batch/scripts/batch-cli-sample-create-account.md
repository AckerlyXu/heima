---
title: Azure CLI Script Sample - Create a Batch account | Microsoft Docs
description: Azure CLI Script Sample - Create a Batch account
services: batch
documentationcenter: ''
author: annatisch
manager: daryls
editor: tysonn

ms.assetid:
ms.service: batch
ms.devlang: azurecli
ms.topic: article
ms.tgt_pltfrm: multiple
ms.workload: na
ms.date: 03/20/2017
ms.author: v-junlch
---

# Create a Batch account with the Azure CLI

This script creates an Azure Batch account and shows how various properties of the account 
can be queried and updated.

If needed, install the Azure CLI using the instructions found in the [Azure CLI installation guide](https://docs.microsoft.com/cli/azure/install-azure-cli), 
and then run `az login` to log into Azure.

## Batch account sample script

When you create a Batch account, by default its compute nodes are assigned internally by the Batch
service. Allocated compute nodes will be subject to a separate core quota and the account can be 
authenticated either via Shared Key credentials or an Azure Active Dirctory token.

```azurecli
#!/bin/bash

# Authenticate CLI session.
az login

# Create a resource group.
az group create --name myresourcegroup --location westeurope

# Create a Batch account.
az batch account create -g myresourcegroup -n mybatchaccount -l westeurope

# Now we can display the details of our created account.
az batch account show -g myresourcegroup -n mybatchaccount

# Let's add a storage account reference to the Batch account for use as 'auto-storage'
# for applications. We'll start by creating the storage account.
az storage account create -g myresourcegroup -n mystorageaccount -l westeurope --sku Standard_LRS

# And then update the Batch account with the either the name (if they exist in
# the same resource group) or the full resource ID of the storage account.
az batch account set -g myresourcegroup -n mybatchaccount --storage-account mystorageaccount

# We can view the access keys to the Batch Account for future client authentication.
az batch account keys list

# Or we can authenticate against the account directly for further CLI interaction.
az batch account login -g myresourcegroup -n mybatchaccount --shared-key-auth
```

## Batch account using user subscription sample script

You can also opt to have Batch create its compute nodes in your own Azure subscription.
Accounts that allocate compute nodes into your subscription must be authenticated via an Azure Active
Directory token and the compute nodes allocated will count towards your subscription quota. To create 
an account in this mode, one must specify a Key Vault reference when creating the account.

```azurecli
#!/bin/bash

# Authenticate CLI session.
az login

# Create a resource group.
az group create --name myresourcegroup --location westeurope

# A Batch account that will allocate pools in the user's subscription must be configured
# with a Key Vault located in the same region. Let's create this first.
az keyvault create \
    --resource-group myresourcegroup \
    --name mykevault \
    --location westeurope \
    --enabled-for-deployment true \
    --enabled-for-disk-encryption true \
    --enabled-for-template-deployment true

# We will add an access-policy to the Key Vault to allow access by the Batch Service.
az keyvault set-policy \
    --resource-group myresourcegroup \
    --name mykevault \
    --object-id f520d84c-3fd3-4cc8-88d4-2ed25b00d27a \
    --key-permissions all \
    --secret-permissions all

# Now we can create the Batch account, referencing the Key Vault either by name (if they
# exist in the same resource group) or by its full resource ID.
az batch account create \
    --resource-group myresourcegroup \
    --name mybatchaccount \
    --location westeurope \
    --keyvault mykevault

# We can now authenticate directly against the account for further CLI interaction.
# Note that Batch accounts that allocate pools in the user's subscription must be
# authenticated via an Azure Active Directory token.
az batch account login -g myresourcegroup -n mybatchaccount
```

## Clean up deployment

After you run either of the above sample scripts, run the following command to remove the
resource group and all related resources (including Batch accounts, Azure Storage accounts and Azure key vaults).

```azurecli
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands to create a resource group, Batch account, and all related resources. Each command in the table links to command-specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.microsoft.com/cli/azure/group#create) | Creates a resource group in which all resources are stored. |
| [az batch account create](https://docs.microsoft.com/cli/azure/batch/account#create) | Creates the Batch account.  |
| [az batch account set](https://docs.microsoft.com/cli/azure/batch/account#set) | Updates properties of the Batch account.  |
| [az batch account show](https://docs.microsoft.com/cli/azure/batch/account#show) | Retrieves details of the specified Batch account.  |
| [az batch account keys list](https://docs.microsoft.com/cli/azure/batch/account/keys#list) | Retrieves the access keys of the specified Batch account.  |
| [az batch account login](https://docs.microsoft.com/cli/azure/batch/account#login) | Authenticates against the specified Batch account for further CLI interaction.  |
| [az storage account create](https://docs.microsoft.com/cli/azure/storage/account#create) | Creates a storage account. |
| [az keyvault create](https://docs.microsoft.com/cli/azure/keyvault#create) | Creates a key vault. |
| [az keyvault set-policy](https://docs.microsoft.com/cli/azure/keyvault#set-policy) | Update the security policy of the specified key vault. |
| [az group delete](https://docs.microsoft.com/cli/azure/group#delete) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional Batch CLI script samples can be found in the [Azure Batch CLI documentation](../batch-cli-samples.md).

