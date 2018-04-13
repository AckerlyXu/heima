---
title: Azure CLI Script Sample - Quick Create a Windows Server 2016 VM | Azure
description: Azure CLI Script Sample - Quick Create a Windows Server 2016 VM 
services: virtual-machines-Windows
documentationcenter: virtual-machines
author: rockboyfor
manager: digimobile
editor: tysonn
tags: 

ms.assetid:
ms.service: virtual-machines-Windows
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: vm-Windows
ms.workload: infrastructure
origin.date: 02/23/2017
ms.date: 04/16/2018
ms.author: v-yeche
ms.custom: mvc
---

# Quick Create a virtual machine with the Azure CLI

This script creates an Azure Virtual Machine running Windows Server 2016. After running the script, you can access the virtual machine through a Remote Desktop connection.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurecli
#!/bin/bash

# Update for your admin password
AdminPassword=ChangeYourAdminPassword1

# Create a resource group.
az group create --name myResourceGroup --location chinanorth

# Create a virtual machine. 
az vm create \
    --resource-group myResourceGroup \
    --name myVM \
    --image win2016datacenter \
    --admin-username azureuser \
    --admin-password $AdminPassword \
    --no-wait
```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources.

```azurecli 
az group delete --name myResourceGroup --yes
```

## Script explanation

This script uses the following commands to create a resource group, virtual machine, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az_group_create) | Creates a resource group in which all resources are stored. |
| [az vm create](https://docs.azure.cn/zh-cn/cli/vm?view=azure-cli-latest#az_vm_create) | Creates the virtual machine and connects it to the network card, virtual network, subnet, and network security group. This command also specifies the virtual machine image to be used and administrative credentials.  |
| [az group delete](https://docs.azure.cn/zh-cn/cli/vm/extension?view=azure-cli-latest#az_vm_extension_set) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-latest).

Additional virtual machine CLI script samples can be found in the [Azure Windows VM documentation](../windows/cli-samples.md?toc=%2fvirtual-machines%2fwindows%2ftoc.json).

<!--Update_Description: update link-->