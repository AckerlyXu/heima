---
title: Azure CLI Script Example - Windows Pool in Batch | Microsoft Docs
description: Azure CLI Script Example - Create and manage a Windows pool in Batch
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

# CLI example: Create and manage a Windows pool in Azure Batch

This script demonstrates some of the commands available in the Azure CLI to create and
manage a pool of Windows compute nodes in Azure Batch. A Windows pool can be configured in two ways, with either a Cloud Services configuration 
or a Virtual Machine configuration. This example shows how to create a Windows pool with the Cloud Services configuration.

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

# Authenticate Batch account CLI session.
az batch account login \
    --resource-group myResourceGroup \
    --name mybatchaccount
    --shared-key-auth

# Create a new Windows cloud service platform pool with 3 Standard A1 VMs.
# The pool has a start task that runs a basic shell command. Typically a 
# start task copies application files to the pool nodes.
az batch pool create \
    --id mypool-windows \
    --os-family 4 \
    --target-dedicated 3 \
    --vm-size small \
    --start-task-command-line "cmd /c dir /s" \
    --start-task-wait-for-success \
    --application-package-references myapp

# Add some metadata to the pool.
az batch pool set --pool-id mypool-windows --metadata IsWindows=true VMSize=StandardA1

# Change the pool to enable automatic scaling of compute nodes.
# This autoscale formula specifies that the number of nodes should be adjusted according
# to the number of active tasks, up to a maximum of 10 compute nodes.
az batch pool autoscale enable \
    --pool-id mypool-windows \
    --auto-scale-formula "$averageActiveTaskCount = avg($ActiveTasks.GetSample(TimeInterval_Minute * 15));$TargetDedicated = min(10, $averageActiveTaskCount);"

# Monitor the resizing of the pool.
az batch pool show --pool-id mypool-windows

# Disable autoscaling when we no longer require the pool to automatically scale.
az batch pool autoscale disable \
    --pool-id mypool-windows
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
| [az batch account login](/cli/batch/account#az_batch_account_login) | Authenticates against the specified Batch account for further CLI interaction. |
| [az batch pool create](/cli/batch/pool#az_batch_pool_create) | Creates a pool of compute nodes.  |
| [az batch pool set](/cli/batch/pool#az_batch_pool_set) | Updates the properties of a pool.  |
| [az batch pool autoscale enable](/cli/batch/pool/autoscale#az_batch_pool_autoscale_enable) | Enables auto-scaling on a pool and applies a formula.  |
| [az batch pool show](/cli/batch/pool#az_batch_pool_show) | Displays the properties of a pool.  |
| [az batch pool autoscale disable](/cli/batch/pool/autoscale#az_batch_pool_autoscale_disable) | Disables auto-scaling on a pool. |
| [az group delete](/cli/group#az_group_delete) | Deletes a resource group including all nested resources. |


## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](/cli/overview).

