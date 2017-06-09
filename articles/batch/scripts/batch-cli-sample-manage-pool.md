---
title: Azure CLI Script Sample - Managing Pools in Batch | Microsoft Docs
description: Azure CLI Script Sample - Managing Pools in Batch
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

# Managing Azure Batch pools with Azure CLI

These script demonstrates some of the tools available in the Azure CLI to create and
manage pools of compute nodes in the Azure Batch service.

Running these scripts assumes that a Batch account has already been set up and an application
configured. For more information, please see the [sample scripts](../batch-cli-samples.md) covering
each of these topics.

> [!NOTE]
> The commands in this sample create Azure virtual machines. Running VMs will accrue charges to your account. To minimize these charges, delete the VMs once you're done running the sample. See [Clean up pools](#clean-up-pools).

If needed, install the Azure CLI using the instructions found in the [Azure CLI installation guide](https://docs.microsoft.com/cli/azure/install-azure-cli), 
and then run `az login` to log into Azure.

Batch pools can be configured in two ways, either with a Cloud Services configuration (Windows only),
or a Virtual Machine configuration (Windows and Linux).

## Pool with cloud service configuration sample script
```azurecli
#!/bin/bash

# Authenticate Batch account CLI session.
az batch account login -g myresource group -n mybatchaccount

# We want to add an application package reference to the pool, so first
# we'll list the available applications.
az batch application summary list

# Create a new Windows cloud service platform pool with 3 Standard A1 VMs.
# The pool has an application package reference (taken from the output of the
# above command) and a start task that will copy the application files to a shared directory.
az batch pool create \
    --id mypool-windows \
    --os-family 4 \
    --target-dedicated 3 \
    --vm-size small \
    --start-task-command-line "cmd /c xcopy %AZ_BATCH_APP_PACKAGE_MYAPP% %AZ_BATCH_NODE_SHARED_DIR%" \
    --start-task-wait-for-success \
    --application-package-references myapp

# We can add some metadata to the pool.
az batch pool set --pool-id mypool-windows --metadata IsWindows=true VMSize=StandardA1

# Let's change the pool to enable automatic scaling of compute nodes.
# This autoscale formula specifies that the number of nodes should be adjusted according
# to the number of active tasks, up to a maximum of 10 compute nodes.
az batch pool autoscale enable \
    --pool-id mypool-windows \
    --auto-scale-formula "$averageActiveTaskCount = avg($ActiveTasks.GetSample(TimeInterval_Minute * 15));$TargetDedicated = min(10, $averageActiveTaskCount);"

# We can monitor the resizing of the pool.
az batch pool show --pool-id mypool-windows

# Once we no longer require the pool to automatically scale, we can disable it.
az batch pool autoscale disable --pool-id mypool-windows
```

## Pool with virtual machine configuration sample script
```azurecli
#!/bin/bash

# Authenticate Batch account CLI session.
az batch account login -g myresource group -n mybatchaccount

# Retrieve a list of available images and node agent SKUs.
az batch pool node-agent-skus list

# Create a new Linux pool with a virtual machine configuration. The image reference 
# and node agent SKUs ID can be selected from the ouptputs of the above list command.
# The image reference is in the format: {publisher}:{offer}:{sku}:{version} where {version} is
# optional and will default to 'latest'.
az batch pool create \
    --id mypool-linux \
    --vm-size Standard_A1 \
    --image canonical:ubuntuserver:16.04.0-LTS \
    --node-agent-sku-id batch.node.ubuntu 16.04

# Now let's resize the pool to start up some VMs.
az batch pool resize --pool-id mypool-linux --target-dedicated 5

# We can check the status of the pool to see when it has finished resizing.
az batch pool show --pool-id mypool-linux

# List the compute nodes running in a pool.
az batch node list --pool-id mypool-linux

# If a particular node in the pool is having issues, it can be rebooted or reimaged.
# The ID of the node can be retrieved with the list command above.
# A typical node ID will be in the format 'tvm-xxxxxxxxxx_1-<timestamp>'.
az batch node reboot --pool-id mypool-linux --node-id tvm-123_1-20170316t000000z

# Alternatively, one or more compute nodes can be deleted from the pool, and any
# work already assigned to it can be re-allocated to another node.
az batch node delete \
    --pool-id mypool-linux \
    --node-list tvm-123_1-20170316t000000z tvm-123_2-20170316t000000z \
    --node-deallocation-option requeue
```

## Clean up pools

After you run the above sample script, run the following command to delete the pools.
```azurecli
az batch pool delete --pool-id mypool-windows
az batch pool delete --pool-id mypool-linux
```

## Script explanation

This script uses the following commands to create and manipulate Batch pools.
Each command in the table links to command-specific documentation.

| Command | Notes |
|---|---|
| [az batch account login](https://docs.microsoft.com/cli/azure/batch/account#login) | Authenticate against a Batch account.  |
| [az batch application summary list](https://docs.microsoft.com/cli/azure/batch/application/summary#list) | List the available applications in the Batch account.  |
| [az batch pool create](https://docs.microsoft.com/cli/azure/batch/pool#create) | Create a pool of VMs.  |
| [az batch pool set](https://docs.microsoft.com/cli/azure/batch/pool#set) | Update properties of a pool.  |
| [az batch pool node-agent-skus list](https://docs.microsoft.com/cli/azure/batch/pool/node-agent-skus#list) | List available node agent SKUs and image information.  |
| [az batch pool resize](https://docs.microsoft.com/cli/azure/batch/pool#resize) | Resize the number of running VMs in the specified pool.  |
| [az batch pool show](https://docs.microsoft.com/cli/azure/batch/pool#show) | Display the properties of a pool.  |
| [az batch pool delete](https://docs.microsoft.com/cli/azure/batch/pool#delete) | Delete the specified pool.  |
| [az batch pool autoscale enable](https://docs.microsoft.com/cli/azure/batch/pool/autoscale#enable) | Enable auto-scaling on a pool and apply a formula.  |
| [az batch pool autoscale disable](https://docs.microsoft.com/cli/azure/batch/pool/autoscale#disable) | Disable auto-scaling on a pool.  |
| [az batch node list](https://docs.microsoft.com/cli/azure/batch/node#list) | List all the compute node in the specified pool.  |
| [az batch node reboot](https://docs.microsoft.com/cli/azure/batch/node#reboot) | Reboot the specified compute node.  |
| [az batch node delete](https://docs.microsoft.com/cli/azure/batch/node#delete) | Delete the listed nodes from the specified pool.  |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional Batch CLI script samples can be found in the [Azure Batch CLI documentation](../batch-cli-samples.md).


