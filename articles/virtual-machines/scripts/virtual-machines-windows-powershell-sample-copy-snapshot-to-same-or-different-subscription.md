---
title: Azure PowerShell Script Sample -  Copy (move) snapshot of a managed disk to same or different subscription | Azure
description: Azure PowerShell Script Sample -  Copy (move) snapshot of a managed disk to same or different subscription
services: virtual-machines-windows
documentationcenter: storage
author: hayley244
manager: digimobile
editor: tysonn
tags: azure-service-management

ms.assetid:
ms.service: virtual-machines-windows
ms.devlang: na
ms.topic: sample
ms.tgt_pltfrm: vm-windows
ms.workload: infrastructure
origin.date: 06/06/2017
ms.date: 08/28/2017
ms.author: v-haiqya
---

# Copy snapshot of a managed disk in same subscription or different subscription with PowerShell

This script creates a copy of a snapshot in the same same subscription or different subscription. Use this script to move a snapshot to different subscription for data retention. Storing snapshots in different subscription protect you from accidental deletion of snapshots in your main subscription. 

[!INCLUDE [sample-powershell-install](../../../includes/sample-powershell-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```powershell
#Provide the subscription Id of the subscription where snapshot exists
$sourceSubscriptionId='yourSourceSubscriptionId'

#Provide the name of your resource group where snapshot exists
$sourceResourceGroupName='yourResourceGroupName'

#Provide the name of the snapshot
$snapshotName='yourSnapshotName'

#Set the context to the subscription Id where snapshot exists
Select-AzureRmSubscription -SubscriptionId $sourceSubscriptionId

#Get the source snapshot
$snapshot= Get-AzureRmSnapshot -ResourceGroupName $sourceResourceGroupName -Name $snapshotName

#Provide the subscription Id of the subscription where snapshot will be copied to
#If snapshot is copied to the same subscription then you can skip this step
$targetSubscriptionId='yourTargetSubscriptionId'

#Name of the resource group where snapshot will be copied to
$targetResourceGroupName='yourTargetResourceGroupName'

#Set the context to the subscription Id where snapshot will be copied to
#If snapshot is copied to the same subscription then you can skip this step
Select-AzureRmSubscription -SubscriptionId $targetSubscriptionId

$snapshotConfig = New-AzureRmSnapshotConfig -SourceResourceId $snapshot.Id -Location $snapshot.Location -CreateOption Copy 

#Create a new snapshot in the target subscription and resource group
New-AzureRmSnapshot -Snapshot $snapshotConfig -SnapshotName $snapshotName -ResourceGroupName $targetResourceGroupName
```

## Script explanation

This script uses following commands to create a snapshot in the target subscription using the Id of the source snapshot. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [New-AzureRmSnapshotConfig](https://docs.microsoft.com/powershell/module/azurerm.compute/New-AzureRmSnapshotConfig) | Creates snapshot configuration that is used for snapshot creation. It includes the resource Id of the parent snapshot and location that is same as the parent snapshot.  |
| [New-AzureRmSnapshot](https://docs.microsoft.com/powershell/module/azurerm.compute/New-AzureRmDisk) | Creates a snapshot using snapshot configuration, snapshot name, and resource group name passed as parameters. |

## Next steps

[Create a virtual machine from a snapshot](./virtual-machines-windows-powershell-sample-create-vm-from-snapshot.md?toc=%2fpowershell%2fmodule%2ftoc.json)

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional virtual machine PowerShell script samples can be found in the [Azure Windows VM documentation](../../virtual-machines/windows/powershell-samples.md?toc=%2fvirtual-machines%2fwindows%2ftoc.json).
