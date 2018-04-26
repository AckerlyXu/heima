---
title: Azure CLI 2.0 Samples - Attach and use data disks | Microsoft Docs
description: Azure CLI 2.0 Samples
services: virtual-machine-scale-sets
documentationcenter: ''
author: iainfoulds
manager: jeconnoc
editor: ''
tags: azure-resource-manager

ms.assetid:
ms.service: virtual-machine-scale-sets
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: na
ms.workload: na
origin.date: 03/27/2018
ms.date: 04/25/2018
ms.author: v-junlch
ms.custom: mvc

---

# Attach and use data disks with a virtual machine scale set with the Azure CLI 2.0
This script creates a virtual machine scale set and attaches and prepares data disks.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

If you don't have an Azure subscription, create a [trial account](https://www.azure.cn/pricing/1rmb-trial) before you begin.

## Sample script
```azurecli
#!/bin/bash

# Create a resource group
az group create --name myResourceGroup --location chinanorth

# Create a scale set
# Network resources such as an Azure load balancer are automatically created
# Two data disks are created and attach - a 64Gb disk and a 128Gb disk
az vmss create `
  --resource-group myResourceGroup `
  --name myScaleSet `
  --image UbuntuLTS `
  --upgrade-policy-mode automatic `
  --admin-username azureuser `
  --generate-ssh-keys `
  --vm-sku Standard_DS1 `
  --data-disk-sizes-gb 64 128

# Attach an additional 128Gb data disk
az vmss disk attach `
  --resource-group myResourceGroup `
  --name myScaleSet `
  --size-gb 128

# Install the Azure Custom Script Extension to run a script that prepares the data disks
az vmss extension set `
  --publisher Microsoft.Azure.Extensions `
  --version 2.0 `
  --name CustomScript `
  --resource-group myResourceGroup `
  --vmss-name myScaleSet `
  --settings "{'fileUris':['https://raw.githubusercontent.com/Azure-Samples/compute-automation-configurations/master/prepare_vm_disks.sh'],'commandToExecute':'./prepare_vm_disks.sh'}"
```

## Clean up deployment
Run the following command to remove the resource group, scale set, and all related resources.

```azurecli
az group delete --name myResourceGroup
```

## Script explanation
This script uses the following commands to create a resource group, virtual machine scale set, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](/cli/ad/group#az_ad_group_create) | Creates a resource group in which all resources are stored. |
| [az vmss create](/cli/vmss#az_vmss_create) | Creates the virtual machine scale set and connects it to the virtual network, subnet, and network security group. A load balancer is also created to distribute traffic to multiple VM instances. This command also specifies the VM image to be used and administrative credentials.  |
| [az vmss disk attach](/cli/vmss/disk#az_vmss_disk_attach) | Creates and attaches a data disk to the virtual machine scale set. |
| [az vmss extension set](/cli/vmss/extension#az_vmss_extension_set) | Installs the Azure Custom Script Extension to run a script that prepares the data disks on each VM instance. |
| [az group delete](/cli/ad/group#delete) | Deletes a resource group including all nested resources. |

## Next steps
For more information on the Azure CLI 2.0, see [Azure CLI 2.0 documentation](/cli/?view=azure-cli-latest).

Additional virtual machine scale set Azure CLI 2.0 script samples can be found in the [Azure virtual machine scale set documentation](../cli-samples.md).

