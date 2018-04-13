---
title: Azure CLI Script Sample - Copy (move) snapshot of a managed disk to same or different subscription with CLI| Azure
description: Azure CLI Script Sample - Copy (move) snapshot of a managed disk to same or different subscription with CLI
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
ms.date: 04/16/2018
ms.author: v-yeche
ms.custom: mvc
---

# Copy snapshot of a managed disk to same or different subscription with CLI

This script copies a snapshot of a managed disk to same or different subscription. Use this script to move a snapshot to different subscription in the same region as the parent snapshot.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurecli
#Provide the subscription Id of the subscription where snapshot exists
sourceSubscriptionId=<your_subscription_id>

#Provide the name of your resource group where snapshot exists
sourceResourceGroupName=mySourceResourceGroupName

#Provide the name of the snapshot
snapshotName=mySnapshotName

#Set the context to the subscription Id where snapshot exists
az account set --subscription $sourceSubscriptionId

#Get the snapshot Id 
snapshotId=$(az snapshot show --name $snapshotName --resource-group $sourceResourceGroupName --query [id] -o tsv)

#If snapshotId is blank then it means that snapshot does not exist.
echo 'source snapshot Id is: ' $snapshotId

#Provide the subscription Id of the subscription where snapshot will be copied to
#If snapshot is copied to the same subscription then you can skip this step
targetSubscriptionId=<target_subscription_id>

#Name of the resource group where snapshot will be copied to
targetResourceGroupName=mytargetResourceGroupName

#Set the context to the subscription Id where snapshot will be copied to
#If snapshot is copied to the same subscription then you can skip this step
az account set --subscription $targetSubscriptionId

#Copy snapshot to different subscription using the snapshot Id
az snapshot create --resource-group $targetResourceGroupName --name $snapshotName --source $snapshotId


```

## Script explanation

This script uses following commands to create a snapshot in the target subscription using the Id of the source snapshot. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az snapshot show](https://docs.azure.cn/zh-cn/cli/snapshot?view=azure-cli-latest#az_snapshot_show) | Gets all the properties of a snapshot using the name and resource group properties of the snapshot. Id property is used to copy the snapshot to different subscription.  |
| [az snapshot create](https://docs.azure.cn/zh-cn/cli/snapshot?view=azure-cli-latest#az_snapshot_create) | Copies a snapshot by creating a snapshot in different subscription using the Id and name of the parent snapshot.  |

## Next steps

[Create a virtual machine from a snapshot](./virtual-machines-linux-cli-sample-create-vm-from-snapshot.md?toc=%2fpowershell%2fmodule%2ftoc.json)

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-latest).

Additional virtual machine and managed disks CLI script samples can be found in the [Azure Linux VM documentation](../../app-service/app-service-cli-samples.md?toc=%2fvirtual-machines%2flinux%2ftoc.json).

<!--Update_Description: update meta properties -->