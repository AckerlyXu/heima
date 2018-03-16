---
title: Create a snapshot of a VHD in Azure | Azure
description: Learn how to create a copy of an Azure VM to use as a back up or for troubleshooting issues.
documentationcenter: ''
author: rockboyfor
manager: digimobile
editor: ''
tags: azure-resource-manager

ms.assetid: 15eb778e-fc07-45ef-bdc8-9090193a6d20
ms.service: virtual-machines-windows
ms.workload: infrastructure-services
ms.tgt_pltfrm: vm-windows
ms.devlang: na
ms.topic: article
origin.date: 10/09/2017
ms.date: 03/19/2018
ms.author: v-yeche

---
# Create a snapshot

Take a snapshot of an OS or data disk VHD for backup or to troubleshoot VM issues. A snapshot is a full, read-only copy of a VHD. 

## Use Azure portal to take a snapshot 

1. Sign in to the [Azure portal](https://portal.azure.cn).
2. Starting in the upper left, click **Create a resource** and search for **snapshot**.
3. In the Snapshot blade, click **Create**.
4. Enter a **Name** for the snapshot.
5. Select an existing [Resource group](../../azure-resource-manager/resource-group-overview.md#resource-groups) or type the name for a new one. 
6. Select an Azure datacenter Location.  
7. For **Source disk**, select the Managed Disk to snapshot.
8. Select the **Account type** to use to store the snapshot. We recommend **Standard_LRS** unless you need it stored on a high performing disk.
9. Click **Create**.

## Use PowerShell to take a snapshot
The following steps show you how to get the VHD disk to be copied, create the snapshot configurations, and take a snapshot of the disk by using the [New-AzureRmSnapshot](https://docs.microsoft.com/powershell/module/azurerm.compute/new-azurermsnapshot) cmdlet. 

Make sure that you have the latest version of the AzureRM.Compute PowerShell module installed. Run the following command to install it.

```
Install-Module AzureRM.Compute -MinimumVersion 2.6.0
```
For more information, see [Azure PowerShell Versioning](https://docs.microsoft.com/powershell/azure/overview).

1. Set some parameters. 

    ```powershell
    $resourceGroupName = 'myResourceGroup' 
    $location = 'chinaeast' 
    $dataDiskName = 'myDisk' 
    $snapshotName = 'mySnapshot'  
    ```

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

## Next steps

Create a virtual machine from a snapshot by creating a managed disk from a snapshot and then attaching the new managed disk as the OS disk. For more information, see the [Create a VM from a snapshot](./../scripts/virtual-machines-windows-powershell-sample-create-vm-from-snapshot.md?toc=%2fpowershell%2fmodule%2ftoc.json) sample.
<!--Update_Description: update meta properties, update link-->
