---
title: Azure CLI Script Sample - Create a Linux VM with NGINX| Azure
description: Azure CLI Script Sample - Create a Linux VM with NGINX
services: virtual-machines-linux
documentationcenter: virtual-machines
author: rockboyfor
manager: digimobile
editor: tysonn
tags: azure-resource-manager

ms.assetid:
ms.service: virtual-machines-linux
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: vm-linux
ms.workload: infrastructure
origin.date: 02/27/2017
ms.date: 10/16/2017
ms.author: v-yeche
ms.custom: mvc
---

# Create a VM with NGINX

This script creates an Azure Virtual Machine and uses the Azure Virtual Machine Custom Script Extension to install NGINX. After running the script, you can access a demo website on the public IP address of the virtual machine.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurecli
#!/bin/bash

# Create a resource group.
az group create --name myResourceGroup --location chinanorth

# Create a new virtual machine, this creates SSH keys if not present.
az vm create --resource-group myResourceGroup --name myVM --image UbuntuLTS --generate-ssh-keys

# Open port 80 to allow web traffic to host.
az vm open-port --port 80 --resource-group myResourceGroup --name myVM 

# Use CustomScript extension to install NGINX.
az vm extension set \
  --publisher Microsoft.Azure.Extensions \
  --version 2.0 \
  --name CustomScript \
  --vm-name myVM \
  --resource-group myResourceGroup \
  --settings '{"commandToExecute":"apt-get -y update && apt-get -y install nginx"}'
```

## Custom Script Extension

The custom script extension copies this script onto the virtual machine. The script is then run to install and configure an NGINX web server. 

```bash
#!/bin/bash

# update package source
apt-get -y update

# install NGINX
apt-get -y install nginx
```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources.

```azurecli 
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands to create a resource group, virtual machine, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.microsoft.com/cli/azure/group#az_group_create) | Creates a resource group in which all resources are stored. |
| [az vm create](https://docs.microsoft.com/cli/azure/vm#az_vm_create) | Creates the virtual machine. This command also specifies the virtual machine image to be used, and administrative credentials.  |
| [az vm open-port](https://docs.microsoft.com/cli/azure/network/nsg/rule#az_network_nsg_rule_create) | Creates a network security group rule to allow inbound traffic. In this sample, port 80 is opened for HTTP traffic. |
| [azure vm extension set](https://docs.microsoft.com/cli/azure/vm/extension#az_vm_extension_set) | Adds and runs a virtual machine extension to a VM. In this sample, the custom script extension is used to install NGINX.|
| [az group delete](https://docs.microsoft.com/cli/azure/vm/extension#az_vm_extension_set) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional virtual machine CLI script samples can be found in the [Azure Linux VM documentation](../linux/cli-samples.md?toc=%2fvirtual-machines%2flinux%2ftoc.json).

<!--Update_Description: update link-->