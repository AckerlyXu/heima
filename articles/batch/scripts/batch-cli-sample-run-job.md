---
title: Azure CLI Script Example - Run a Batch job | Microsoft Docs
description: Azure CLI Script Example - Run a job with Batch
services: batch
documentationcenter: ''
author: dlepow
manager: jeconnoc
editor: tysonn

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

# CLI example: Run a job and tasks with Azure Batch

This script creates a Batch job and adds a series of tasks to the job. It also demonstrates
how to monitor a job and its tasks. 

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

# Create a new Linux pool with a virtual machine configuration. 
az batch pool create \
    --id mypool \
    --vm-size Standard_A1 \
    --target-dedicated 2
    --image canonical:ubuntuserver:16.04.0-LTS \
    --node-agent-sku-id "batch.node.ubuntu 16.04"


# Create a new job to encapsulate the tasks that are added.
az batch job create \
    --id myjob \
    --pool-id mypool

# Add tasks to the job. Here the task is a basic shell command.
az batch task create \
    --job-id myjob \
    --task-id task1 \
    --command-line "/bin/bash -c 'printenv AZ_BATCH_TASK_WORKING_DIR'"

# To add many tasks at once, specify the tasks
# in a JSON file, and pass it to the command. See tasks.json for formatting.
az batch task create \
    --job-id myjob \
    --json-file tasks.json

# Update the job so that it is automatically
# marked as completed once all the tasks are finished.
az batch job set \
--job-id myjob \
--on-all-tasks-complete terminateJob

# Monitor the status of the job.
az batch job show --job-id myjob

# Monitor the status of a task.
az batch task show \
    --job-id myjob \
    --task-id task1
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
| [az batch pool create](/cli/batch/pool#az_batch_pool_create) | Creates a pool of compute nodes.  |
| [az batch job create](/cli/batch/job#az_batch_job_create) | Creates a Batch job.  |
| [az batch task create](/cli/batch/task#az_batch_task_create) | Adds a task to the specified Batch job.  |
| [az batch job set](/cli/batch/job#az_batch_job_set) | Updates properties of a Batch job.  |
| [az batch job show](/cli/batch/job#az_batch_job_show) | Retrieves details of a specified Batch job.  |
| [az batch task show](/cli/batch/task#az_batch_task_show) | Retrieves the details of a task from the specified Batch job.  |
| [az group delete](/cli/group#az_group_delete) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](/cli/overview).

