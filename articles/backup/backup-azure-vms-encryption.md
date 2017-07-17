---
title: Backup and restore encrypted VMs using Azure Backup
description: This article talks about the backup and restore experience for VMs encrypted using Azure Disk Encryption.
services: backup
documentationcenter: ''
author: alexchen2016
manager: digimobile
editor: ''

ms.assetid: 8387f186-7d7b-400a-8fc3-88a85403ea63
ms.service: backup
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: storage-backup-recovery
origin.date: 04/24/2017
ms.date: 06/29/2017
ms.author: v-junlch
ms.custom: H1Hack27Feb2017

---
# How to back up and restore encrypted virtual machines with Azure Backup
This article talks about steps to backup and restore virtual machines using Azure Backup. It also provides details about supported scenarios, pre-requisites, and troubleshooting steps for error cases.

## Supported Scenarios
> [!NOTE]
> 1. Backup and restore of encrypted VMs is supported only for Resource Manager deployed virtual machines. It is not supported for Classic virtual machines. <br>
> 2. It is supported for both Windows and Linux virtual machines using Azure Disk Encryption, which leverages the industry standard BitLocker feature of Windows and DM-Crypt feature of Linux to provide encryption of disks. <br>
> 3. It is supported only for virtual machines encrypted using BitLocker Encryption Key and Key Encryption Key both. It is not supported for virtual machines encrypted using BitLocker Encryption Key only. <br>
>
>

## Pre-requisites
1. Virtual machine has been encrypted using Azure Disk Encryption. It should be encrypted using BitLocker Encryption Key and Key Encryption Key both.
2. Recovery services vault has been created and storage replication set using steps mentioned in the article [Prepare your environment for backup](backup-azure-arm-vms-prepare.md).

## Restore encrypted VM
To restore encrypted VM, first Restore Disks using steps mentioned in section **Restore backed up disks** in Choosing VM restore configuration. After that, you can use one of the following options:
- Use the PowerShell steps mentioned in [Create a VM from restored disks](backup-azure-vms-automation.md#create-a-vm-from-restored-disks) to create full VM from restored disks.
- OR, Use template generated as part of Restore Disks to create VMs from restored disks. Templates can be used only for recovery points created after 26 April 2017.

## Troubleshooting errors
| Operation | Error details | Resolution |
| --- | --- | --- |
| Backup |Validation failed as virtual machine is encrypted with BEK alone. Backups can be enabled only for virtual machines encrypted with both BEK and KEK. |Virtual machine should be encrypted using BEK and KEK. First decrypt the VM and encrypt it using both BEK and KEK. Enable backup once VM is encrypted using both BEK and KEK.  |
| Restore |You cannot restore this encrypted VM since key vault associated with this VM does not exist. |Create key vault using [Get Started with Azure Key Vault](../key-vault/key-vault-get-started.md). Refer the article [Restore key vault key and secret using Azure Backup](backup-azure-restore-key-secret.md) to restore key and secret if they are not present. |
| Restore |You cannot restore this encrypted VM since key and secret associated with this VM do not exist. |Refer the article [Restore key vault key and secret using Azure Backup](backup-azure-restore-key-secret.md) to restore key and secret if they are not present. |
| Restore |Backup Service does not have authorization to access resources in your subscription. |As mentioned above, Restore Disks first, using steps mentioned in section **Restore backed up disks** in Choosing VM restore configuration. After that, user PowerShell to [Create a VM from restored disks](backup-azure-vms-automation.md#create-a-vm-from-restored-disks). |
|Backup | Azure Backup Service does not have sufficient permissions to Key Vault for Backup of Encrypted Virtual Machines | Virtual machine should be encrypted using both BitLocker Encryption Key and Key Encryption Key. After that, backup should be enabled.  Backup service hould be provided these permissions in PowerShell using steps mentioned in the **Enable protection** section of the PowerShell documentation at [Use AzureRM.RecoveryServices.Backup cmdlets to back up virtual machines](backup-azure-vms-automation.md). |  

