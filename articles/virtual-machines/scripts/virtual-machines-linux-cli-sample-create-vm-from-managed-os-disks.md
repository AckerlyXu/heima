---
title: Azure CLI Script Sample - Create a VM by attaching a managed disk as OS disk | Azure
description: Azure CLI Script Sample - Create a VM by attaching a managed disk as OS disk
services: virtual-machines-linux
documentationcenter: virtual-machines
author: rockboyfor
manager: digimobile
editor: ramankum
tags: azure-service-management

ms.assetid:
ms.service: virtual-machines-linux
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: vm-linux
ms.workload: infrastructure
origin.date: 05/10/2017
ms.date: 10/16/2017
ms.author: v-yeche
ms.custom: mvc
---

# Create a virtual machine using an existing managed OS disk with CLI

This script creates a virtual machine by attaching an existing managed disk as OS disk. Use this script in preceding scenarios:
* Create a VM from an existing managed OS disk that was copied from a managed disk in different subscription
* Create a VM from an existing managed disk that was created from a specialized VHD file 
* Create a VM from an existing managed OS disk that was created from a snapshot 

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurecli
#Provide the subscription Id
subscriptionId=6492b1f7-f219-446b-b509-314e17e1efb0

#Provide the name of your resource group
resourceGroupName=myResourceGroupName

#Provide the name of the Managed Disk
managedDiskName=myDiskName

#Provide the OS type
osType=linux

#Provide the name of the virtual machine
virtualMachineName=myVirtualMachineName123

#Set the context to the subscription Id where Managed Disk exists and where VM will be created
az account set --subscription $subscriptionId

#Get the resource Id of the managed disk
managedDiskId=$(az disk show --name $managedDiskName --resource-group $resourceGroupName --query [id] -o tsv)

#Create VM by attaching existing managed disks as OS
az vm create --name $virtualMachineName --resource-group $resourceGroupName --attach-os-disk $managedDiskId --os-type $osType

```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources.

```azurecli 
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands to get managed disk properties, attach a managed disk to a new VM and create a VM. Each item in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az disk show](https://docs.microsoft.com/cli/azure/disk#az_disk_show) | Gets managed disk properties using disk name and resource group name. Id property is used to attach a managed disk to a new VM |
| [az vm create](https://docs.microsoft.com/cli/azure/vm#az_vm_create) | Creates a VM using a managed OS disk |
## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional virtual machine CLI script samples can be found in the [Azure Linux VM documentation](../linux/cli-samples.md?toc=%2fvirtual-machines%2flinux%2ftoc.json).

<!--Update_Description: update link-->