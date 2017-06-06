---
title: Attach a data disk to a Windows VM in Azure using PowerShell | Azure
description: How to attach new or existing data disk to a Windows VM using PowerShell with the Resource Manager deployment model.
services: virtual-machines-windows
documentationcenter: ''
author: cynthn
manager: timlt
editor: ''
tags: azure-resource-manager

ms.assetid: 
ms.service: virtual-machines-windows
ms.workload: infrastructure-services
ms.tgt_pltfrm: vm-windows
ms.devlang: na
ms.topic: article
ms.date: 02/07/2017
wacn.date: ''
ms.author: cynthn

---

# Attach a data disk to a Windows VM using PowerShell

This article shows you how to attach both new and existing disks to a Windows virtual machine using PowerShell. You can attach unmanaged data disks to a VM that uses unmanaged disks in a storage account.

>[!NOTE]
> Azure China does not support Managed Disk yet.

Before you do this, review these tips:
* The size of the virtual machine controls how many data disks you can attach. For details, see [Sizes for virtual machines](sizes.md?toc=%2fvirtual-machines%2fwindows%2ftoc.json).
* To use Premium storage, you'll need a Premium Storage enabled VM size like the DS-series or GS-series virtual machine. You can use disks from both Premium and Standard storage accounts with these virtual machines. Premium storage is available in certain regions. For details, see [Premium Storage: High-Performance Storage for Azure Virtual Machine Workloads](../../storage/storage-premium-storage.md?toc=%2fvirtual-machines%2fwindows%2ftoc.json).

## Before you begin
If you use PowerShell, make sure that you have the latest version of the AzureRM.Compute PowerShell module. Run the following command to install it.

```powershell
Install-Module AzureRM.Compute -RequiredVersion 2.6.0
```

For more information, see [Azure PowerShell Versioning](https://docs.microsoft.com/powershell/azure/overview).

## Add an empty data disk to a virtual machine

This example shows how to add an empty data disk to an existing virtual machine.

### Using unmanaged disks in a storage account

```powershell
    $vm = Get-AzureRmVM -ResourceGroupName $rgName -Name $vmName
    Add-AzureRmVMDataDisk -VM $vm -Name "disk-name" -VhdUri "https://mystore1.blob.core.chinacloudapi.cn/vhds/datadisk1.vhd" -LUN 0 -Caching ReadWrite -DiskSizeinGB 1 -CreateOption Empty
    Update-AzureRmVM -ResourceGroupName $rgName -VM $vm
```

### Initialize the disk

After you add an empty disk, you need to initialize it. To initialize the disk, you can log in to a VM and use disk management. If you enabled WinRM and a certificate on the VM when you created it, you can use remote PowerShell to initialize the disk. You can also use a custom script extension: 

```powershell
    $location = "location-name"
    $scriptName = "script-name"
    $fileName = "script-file-name"
    Set-AzureRmVMCustomScriptExtension -ResourceGroupName $rgName -Location $locName -VMName $vmName -Name $scriptName -TypeHandlerVersion "1.4" -StorageAccountName "mystore1" -StorageAccountKey "primary-key" -FileName $fileName -ContainerName "scripts"
```

The script file can contain something like this code to initialize the disks:

```powershell
    $disks = Get-Disk | Where partitionstyle -eq 'raw' | sort number

    $letters = 70..89 | ForEach-Object { [char]$_ }
    $count = 0
    $labels = "data1","data2"

    foreach ($disk in $disks) {
        $driveLetter = $letters[$count].ToString()
        $disk | 
        Initialize-Disk -PartitionStyle MBR -PassThru |
        New-Partition -UseMaximumSize -DriveLetter $driveLetter |
        Format-Volume -FileSystem NTFS -NewFileSystemLabel $labels[$count] -Confirm:$false -Force
	$count++
    }
```

## Attach an existing data disk to a VM

You can also attach an existing VHD as a managed data disk to a virtual machine. 

### Using unmanaged disks

```powershell
$vm = Get-AzureRmVM -ResourceGroupName $rgName -Name $vmName
Add-AzureRmVMDataDisk -VM $vm -Name "disk-name" -VhdUri "https://mystore1.blob.core.chinacloudapi.cn/vhds/datadisk1.vhd" -LUN 0 -Caching ReadWrite -DiskSizeinGB 1 -CreateOption Attach
Update-AzureRmVM -ResourceGroupName $rgName -VM $vm
```
