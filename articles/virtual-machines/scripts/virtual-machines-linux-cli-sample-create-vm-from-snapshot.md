---
title: Azure CLI Script Sample - Create a VM from a snapshot | Azure
description: Azure CLI Script Sample - Create a VM from a snapshot
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
ms.date: 04/16/2018
ms.author: v-yeche
ms.custom: mvc
---

# Create a virtual machine from a snapshot with CLI

This script creates a virtual machine from a snapshot of an OS disk.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurecli
#Provide the subscription Id of the subscription where you want to create Managed Disks
subscriptionId=dd80b94e-0463-4a65-8d04-c94f403879dc

#Provide the name of your resource group
resourceGroupName=myResourceGroupName

#Provide the name of the snapshot that will be used to create Managed Disks
snapshotName=mySnapshotName

#Provide the name of the Managed Disk
osDiskName=myOSDiskName

#Provide the size of the disks in GB. It should be greater than the VHD file size.
diskSize=128

#Provide the storage type for Managed Disk. Premium_LRS or Standard_LRS.
storageType=Premium_LRS

#Provide the OS type
osType=linux

#Provide the name of the virtual machine
virtualMachineName=myVirtualMachineName

#Set the context to the subscription Id where Managed Disk will be created
az account set --subscription $subscriptionId

#Get the snapshot Id 
snapshotId=$(az snapshot show --name $snapshotName --resource-group $resourceGroupName --query [id] -o tsv)

#Create a new Managed Disks using the snapshot Id
az disk create --resource-group $resourceGroupName --name $osDiskName --sku $storageType --size-gb $diskSize --source $snapshotId 

#Create VM by attaching created managed disks as OS
az vm create --name $virtualMachineName --resource-group $resourceGroupName --attach-os-disk $osDiskName --os-type $osType

```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources.

```azurecli 
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands to create a managed disk, virtual machine, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az snapshot show](https://docs.azure.cn/zh-cn/cli/snapshot?view=azure-cli-latest#az_snapshot_show) | Gets snapshot using snapshot name and resource group name. Id property of the returned object is used to create a managed disk.  |
| [az disk create](https://docs.azure.cn/zh-cn/cli/disk?view=azure-cli-latest#az_disk_create) | Creates managed disks from a snapshot using snapshot Id, disk name, storage type, and size  |
| [az vm create](https://docs.azure.cn/zh-cn/cli/vm?view=azure-cli-latest#az_vm_create) | Creates a VM using a managed OS disk |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-latest).

Additional virtual machine CLI script samples can be found in the [Azure Linux VM documentation](../linux/cli-samples.md?toc=%2fvirtual-machines%2flinux%2ftoc.json).

<!--Update_Description: update meta properties -->