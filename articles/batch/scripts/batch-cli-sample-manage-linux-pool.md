---
title: Azure CLI Script Example - Linux Pool in Batch | Microsoft Docs
description: Azure CLI Script Example - Create and manage a Linux Pool in Batch
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

# CLI example: Create and manage a Linux pool in Azure Batch

These script demonstrates some of the commands available in the Azure CLI to create and
manage a pool of Linux compute nodes in Azure Batch.

If you choose to install and use the CLI locally, this quickstart requires that you are running the Azure CLI version 2.0.20 or later. Run `az --version` to find the version. If you need to install or upgrade, see [Install Azure CLI 2.0](/cli/install-azure-cli). 

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

# Authenticate Batch account CLI session.
az batch account login \
    --resource-group myResourceGroup \
    --name mybatchaccount
    --shared-key-auth

# Retrieve a list of available images and node agent SKUs.
az batch pool node-agent-skus list

# Create a new Linux pool with a virtual machine configuration. The image reference 
# and node agent SKUs ID can be selected from the ouptputs of the above list command.
# The image reference is in the format: {publisher}:{offer}:{sku}:{version} where {version} is
# optional and defaults to 'latest'.
az batch pool create \
    --id mypool-linux \
    --vm-size Standard_A1 \
    --image canonical:ubuntuserver:16.04.0-LTS \
    --node-agent-sku-id "batch.node.ubuntu 16.04"

# Resize the pool to start some VMs.
az batch pool resize \
    --pool-id mypool-linux \
    --target-dedicated 5

# Check the status of the pool to see when it has finished resizing.
az batch pool show \
    --pool-id mypool-linux

# List the compute nodes running in a pool.
az batch node list \
    --pool-id mypool-linux

# If a particular node in the pool is having issues, it can be rebooted or reimaged.
# The ID of the node can be retrieved with the list command above.
# A typical node ID is in the format 'tvm-xxxxxxxxxx_1-<timestamp>'.
az batch node reboot \
    --pool-id mypool-linux \
    --node-id tvm-123_1-20170316t000000z

# One or more compute nodes can be deleted from the pool, and any
# work already assigned to it can be re-allocated to another node.
az batch node delete \
    --pool-id mypool-linux \
    --node-list tvm-123_1-20170316t000000z tvm-123_2-20170316t000000z \
    --node-deallocation-option requeue
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
| [az batch account login](/cli/batch/account#az_batch_account_login) | Authenticates against the specified Batch account for further CLI interaction.  |
| [az batch pool node-agent-skus list](/cli/batch/pool/node-agent-skus#az_batch_pool_node_agent_skus_list) | Lists available node agent SKUs and image information.  |
| [az batch pool create](/cli/batch/pool#az_batch_pool_create) | Creates a pool of compute nodes.  |
| [az batch pool resize](/cli/batch/pool#az_batch_pool_resize) | Resizes the number of running VMs in the specified pool.  |
| [az batch pool show](/cli/batch/pool#az_batch_pool_show) | Displays the properties of a pool.  |
| [az batch node list](/cli/batch/node#az_batch_node_list) | Lists all the compute node in the specified pool.  |
| [az batch node reboot](/cli/batch/node#az_batch_node_reboot) | Reboots the specified compute node.  |
| [az batch node delete](/cli/batch/node#az_batch_node_delete) | Deletes the listed nodes from the specified pool.  |
| [az group delete](/cli/group#az_group_delete) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](/cli/overview).

