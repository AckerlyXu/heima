---
title: Azure PowerShell Script Sample - Copy (move) managed disks to same or different subscription | Microsoft Docs
description: Azure PowerShell Script Sample - Copy (move) managed disks to same or different subscription
services: managed-disks-windows
documentationcenter: storage
author: forester123
manager: digimobile
editor: ramankum
tags: azure-service-management

ms.assetid:
ms.service: managed-disks-windows
ms.devlang: na
ms.topic: sample
ms.tgt_pltfrm: vm-windows
ms.workload: infrastructure
origin.date: 06/06/2017
ms.date: 06/26/2017
ms.author: v-johch
---

# Copy managed disks in the same subscription or different subscription with PowerShell

This script creates a copy of an existing managed disk in the same subscription or different subscription. The new disk is created in the same region as the parent managed disk.   

[!INCLUDE [sample-powershell-install](../../../includes/sample-powershell-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```PowerShell
#Provide the subscription Id of the subscription where managed disk exists
$sourceSubscriptionId='yourSourceSubscriptionId'

#Provide the name of your resource group where managed disk exists
$sourceResourceGroupName='mySourceResourceGroupName'

#Provide the name of the managed disk
$managedDiskName='myDiskName'

#Set the context to the subscription Id where Managed Disk exists
Select-AzureRmSubscription -SubscriptionId $sourceSubscriptionId

#Get the source managed disk
$managedDisk= Get-AzureRMDisk -ResourceGroupName $sourceResourceGroupName -DiskName $managedDiskName

#Provide the subscription Id of the subscription where managed disk will be copied to
#If managed disk is copied to the same subscription then you can skip this step
$targetSubscriptionId='yourTargetSubscriptionId'

#Name of the resource group where snapshot will be copied to
$targetResourceGroupName='myTargetResourceGroupName'

#Set the context to the subscription Id where managed disk will be copied to
#If snapshot is copied to the same subscription then you can skip this step
Select-AzureRmSubscription -SubscriptionId $targetSubscriptionId

$diskConfig = New-AzureRmDiskConfig -SourceResourceId $managedDisk.Id -Location $managedDisk.Location -CreateOption Copy 

#Create a new managed disk in the target subscription and resource group
New-AzureRmDisk -Disk $diskConfig -DiskName $managedDiskName -ResourceGroupName $targetResourceGroupName
```


## Script explanation

This script uses following commands to create a new managed disk in the target subscription using the Id of the source managed disk. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [New-AzureRmDiskConfig](https://docs.microsoft.com/powershell/module/azurerm.compute/New-AzureRmDiskConfig) | Creates disk configuration that is used for disk creation. It includes the resource Id of the parent disk and location that is same as the location of parent disk.  |
| [New-AzureRmDisk](https://docs.microsoft.com/powershell/module/azurerm.compute/New-AzureRmDisk) | Creates a disk using disk configuration, disk name, and resource group name passed as parameters. |


## Next steps

[Create a virtual machine from a managed disk](./../../virtual-machines/scripts/virtual-machines-windows-powershell-sample-create-vm-from-managed-os-disks.md?toc=%2fpowershell%2fmodule%2ftoc.json)

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional virtual machine PowerShell script samples can be found in the [Azure Windows VM documentation](../../virtual-machines/windows/powershell-samples.md?toc=%2fvirtual-machines%2fwindows%2ftoc.json).