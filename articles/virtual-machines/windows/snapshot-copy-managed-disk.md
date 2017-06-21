---
title: Create a copy of an Azure Managed Disk for back up | Azure
description: Learn how to create a copy of an Azure Managed Disk to use for back up or troubleshooting disk issues.
documentationcenter: ''
author: cwatsonMSFT
manager: timlt
editor: ''
tags: azure-resource-manager

ms.assetid: 15eb778e-fc07-45ef-bdc8-9090193a6d20
ms.service: virtual-machines-windows
ms.workload: infrastructure-services
ms.tgt_pltfrm: vm-windows
ms.devlang: na
ms.topic: article
origin.date: 02/09/2017
ms.date: 06/20/2017
ms.author: v-dazen

---
# Create a copy of a VHD stored as an Azure Managed Disk by using Managed Snapshots
Take a snapshot of a Managed Disk for backup or create a Managed Disk from the snapshot and attach it to a test virtual machine to troubleshoot. A Managed Snapshot is a full point-in-time copy of a VM Managed Disk. It creates a read-only copy of your VHD and, by default, stores it as a Standard Managed Disk. For more information about Managed Disks, see [Azure Managed Disks overview](../../storage/storage-managed-disks-overview.md?toc=%2fvirtual-machines%2fwindows%2ftoc.json)

For information about pricing, see [Azure Storage Pricing](https://www.azure.cn/pricing/details/managed-disks/). 

## Before you begin
If you use PowerShell, make sure that you have the latest version of the AzureRM.Compute PowerShell module. Run the following command to install it.

```
Install-Module AzureRM.Compute -RequiredVersion 2.6.0
```
For more information, see [Azure PowerShell Versioning](https://docs.microsoft.com/powershell/azure/overview).

## Copy the VHD with a snapshot
Use PowerShell to take a snapshot of the Managed Disk.

### Use PowerShell to take a snapshot
The following steps show you how to get the VHD disk to be copied, create the snapshot configurations, and take a snapshot of the disk by using the New-AzureRmSnapshot cmdlet<!--Add link to cmdlet when available-->. 

1. Set some parameters. 

    ```powershell
    $resourceGroupName = 'myResourceGroup' 
    $location = 'chinaeast' 
    $dataDiskName = 'ContosoMD_datadisk1' 
    $snapshotName = 'ContosoMD_datadisk1_snapshot1'  
    ```
    Replace the parameter values:

    -  "myResourceGroup" with the VM's resource group.
    -  "chinaeast" with the geographic location where you want your Managed Snapshot stored. <!---How do you look these up? -->
    -  "ContosoMD_datadisk1" with the name of the VHD disk that you want to copy.
    -  "ContosoMD_datadisk1_snapshot1" with the name you want to use for the new snapshot.

2. Get the VHD disk to be copied.

    ```powershell
    $disk = Get-AzureRmDisk -ResourceGroupName $resourceGroupName -DiskName $dataDiskName 
    ```
3. Create the snapshot configurations. 

    ```powershell
    $snapshot =  New-AzureRmSnapshotConfig -SourceUri $disk.Id -CreateOption Copy -Location $location 
    ```
4. Take the snapshot.

    ```powershell
    New-AzureRmSnapshot -Snapshot $snapshot -SnapshotName $snapshotName -ResourceGroupName $resourceGroupName 
    ```
If you plan to use the snapshot to create a Managed Disk and attach it a VM that needs to be high performing, use the parameter `-AccountType Premium_LRS` with the New-AzureRmSnapshot command. The parameter creates the snapshot so that it's stored as a Premium Managed Disk. Premium Managed Disks are more expensive than Standard. So be sure you really need Premium before using that parameter.