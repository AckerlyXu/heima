---
title: Create an Azure Virtual Network - Azure CLI | Azure
description: Quickly learn to create a virtual network using the Azure CLI. A virtual network enables Azure resources, such as virtual machines, to communicate privately with each other, and with the internet.
services: virtual-network
documentationcenter: virtual-network
author: rockboyfor
manager: digimobile
editor: ''
tags: azure-resource-manager

ms.assetid: 
ms.service: virtual-network
ms.devlang: azurecli
ms.topic: 
ms.tgt_pltfrm: virtual-network
ms.workload: infrastructure
origin.date: 03/09/2018
ms.date: 04/02/2018
ms.author: v-yeche
ms.custom:
---

# Create a virtual network using the Azure CLI

A virtual network enables Azure resources, such as virtual machines (VM), to communicate privately with each other and with the Internet. In this article, you learn how to create a virtual network. After creating a virtual network, you deploy two VMs into the virtual network. You then connect to one VM from the internet, and communicate privately with the other VM.

If you don't have an Azure subscription, create a [trial account](https://www.azure.cn/pricing/1rmb-trial) before you begin.

[!INCLUDE [azure-cli-2-azurechinacloud-environment-parameter](../../includes/azure-cli-2-azurechinacloud-environment-parameter.md)]

If you choose to install and use the CLI locally, this article requires that you are running the Azure CLI version 2.0.28 or later. To find the installed version, run `az --version`. If you need to install or upgrade, see [Install Azure CLI 2.0](https://docs.azure.cn/zh-cn/cli/install-azure-cli?view=azure-cli-latest). 

## Create a virtual network

Before you can create a virtual network, you must create a resource group to contain the virtual network. Create a resource group with [az group create](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az_group_create). The following example creates a resource group named *myResourceGroup* in the *chinaeast* location:

```azurecli 
az group create --name myResourceGroup --location chinaeast
```

Create a virtual network with [az network vnet create](https://docs.azure.cn/zh-cn/cli/network/vnet?view=azure-cli-latest#az_network_vnet_create). The following example creates a default virtual network named *myVirtualNetwork* with one subnet named *default*:

```azurecli 
az network vnet create \
  --name myVirtualNetwork \
  --resource-group myResourceGroup \
  --subnet-name default
```

## Create virtual machines

Create two VMs in the virtual network:

### Create the first VM

Create a VM with [az vm create](https://docs.azure.cn/zh-cn/cli/vm?view=azure-cli-latest#az_vm_create). If SSH keys do not already exist in a default key location, the command creates them. To use a specific set of keys, use the `--ssh-key-value` option. The `--no-wait` option creates the VM in the background, so that you can continue to the next step. The following example creates a VM named *myVm1*:

```azurecli 
az vm create \
  --resource-group myResourceGroup \
  --name myVm1 \
  --image UbuntuLTS \
  --generate-ssh-keys \
  --no-wait
```

### Create the second VM

```azurecli 
az vm create \
  --resource-group myResourceGroup \
  --name myVm2 \
  --image UbuntuLTS \
  --generate-ssh-keys
```

The VM takes a few minutes to create. After the VM is created, the Azure CLI returns output similar to the following example: 

```azurecli 
{
  "fqdns": "",
  "id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Compute/virtualMachines/myVm1",
  "location": "chinaeast",
  "macAddress": "00-0D-3A-23-9A-49",
  "powerState": "VM running",
  "privateIpAddress": "10.0.0.5",
  "publicIpAddress": "40.68.254.142",
  "resourceGroup": "myResourceGroup"
}
```

Take note of the **publicIpAddress**. This address is used to connect to the VM from the Internet in the next step.

## Connect to a VM from the internet

Replace `<publicIpAddress>` with the public IP address of your *myVm2* VM in the command the follows, and then enter the following command:

```bash 
ssh <publicIpAddress>
```

## Communicate privately between VMs

To confirm private communication between the *myVm2* and *myVm1* VMs, enter the following command:

```bash
ping myVm1 -c 4
```

You receive four replies from *10.0.0.4*.

Exit the SSH session with the *myVm2* VM.

## Clean up resources

When no longer needed, you can use [az group delete](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az_group_delete) to remove the resource group and all of the resources it contains:

```azurecli 
az group delete --name myResourceGroup --yes
```

## Next steps

In this article, you created a default virtual network and two VMs. You connected to one VM from the Internet and communicated privately between the VM and another VM. To learn more about virtual network settings, see [Manage a virtual network](manage-virtual-network.md). 

By default, Azure allows unrestricted private communication between virtual machines, but only allows inbound SSH sessions to Linux VMs from the Internet. To learn how to allow or restrict different types of network communication to and from VMs, advance to the next tutorial.

> [!div class="nextstepaction"]
> [Filter network traffic](virtual-networks-create-nsg-arm-cli.md)

<!-- Update_Description: update meta properties, wording update, update link -->