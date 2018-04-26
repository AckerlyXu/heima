---
title: Azure CLI 2.0 Samples - Use a custom VM image | Microsoft Docs
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

# Create a virtual machine scale set from a custom VM image with the Azure CLI 2.0
This script creates a virtual machine scale set that uses a custom VM image as the source for the VM instances.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

If you don't have an Azure subscription, create a [trial account](https://www.azure.cn/pricing/1rmb-trial) before you begin.

## Sample script
```azurecli
#!/bin/bash

# Create a resource group
az group create --name myResourceGroup --location chinanorth

# Create a scale set

# Custom VM image must already exist in your subscription
# See https://docs.microsoft.com/en-us/azure/virtual-machine-scale-sets/tutorial-use-custom-image-cli

# Network resources such as an Azure load balancer are automatically created
az vmss create `
  --resource-group myResourceGroup `
  --name myScaleSet `
  --image myImage `
  --upgrade-policy-mode automatic `
  --admin-username azureuser `
  --generate-ssh-keys `
  --vm-sku Standard_DS1
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
| [az group delete](/cli/ad/group#delete) | Deletes a resource group including all nested resources. |

## Next steps
For more information on the Azure CLI 2.0, see [Azure CLI 2.0 documentation](/cli/).

Additional virtual machine scale set Azure CLI 2.0 script samples can be found in the [Azure virtual machine scale set documentation](../cli-samples.md).

