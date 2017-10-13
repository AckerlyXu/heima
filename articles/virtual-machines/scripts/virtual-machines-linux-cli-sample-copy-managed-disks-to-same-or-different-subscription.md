---
title: Azure CLI Script Sample - Copy (move) managed disks to same or different subscription | Azure
description: Azure CLI Script Sample - Copy (move) managed disks to same or different subscription
services: virtual-machines-linux
documentationcenter: storage
author: rockboyfor
manager: digimobile
editor: tysonn
tags: azure-service-management

ms.assetid:
ms.service: virtual-machines-linux
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: vm-linux
ms.workload: infrastructure
origin.date: 05/19/2017
ms.date: 10/16/2017
ms.author: v-yeche
ms.custom: mvc
---

# Copy managed disks to same or different subscription with CLI

This script copies a managed disk to same or different subscription but in the same region. 

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurecli
#Provide the subscription Id of the subscription where managed disk exists
sourceSubscriptionId=<your_subscription_id>

#Provide the name of your resource group where managed disk exists
sourceResourceGroupName=mySourceResourceGroupName

#Provide the name of the managed disk
managedDiskName=myDiskName

#Set the context to the subscription Id where managed disk exists
az account set --subscription $sourceSubscriptionId

#Get the managed disk Id 
managedDiskId=$(az disk show --name $managedDiskName --resource-group $sourceResourceGroupName --query [id] -o tsv)

#If managedDiskId is blank then it means that managed disk does not exist.
echo 'source managed disk Id is: ' $managedDiskId

#Provide the subscription Id of the subscription where managed disk will be copied to
targetSubscriptionId=<target_subscription_id>

#Name of the resource group where managed disk will be copied to
targetResourceGroupName=mytargetResourceGroupName

#Set the context to the subscription Id where managed disk will be copied to
az account set --subscription $targetSubscriptionId

#Copy managed disk to different subscription using managed disk Id
az disk create --resource-group $targetResourceGroupName --name $managedDiskName --source $managedDiskId

```

## Script explanation

This script uses following commands to create a new managed disk in the target subscription using the Id of the source managed disk. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az disk show](https://docs.microsoft.com/cli/azure/disk#az_disk_show) | Gets all the properties of a managed disk using the name and resource group properties of the managed disk. Id property is used to copy the managed disk to different subscription.  |
| [az disk create](https://docs.microsoft.com/cli/azure/disk#az_disk_create) | Copies a managed disk by creating a new managed disk in different subscription using Id and name the parent managed disk.  |

## Next steps

[Create a virtual machine from a managed disk](./virtual-machines-linux-cli-sample-create-vm-from-managed-os-disks.md?toc=%2fpowershell%2fmodule%2ftoc.json)

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional virtual machine and managed disks CLI script samples can be found in the [Azure Linux VM documentation](../../app-service-web/app-service-cli-samples.md?toc=%2fvirtual-machines%2flinux%2ftoc.json).

<!--Update_Description: update link-->