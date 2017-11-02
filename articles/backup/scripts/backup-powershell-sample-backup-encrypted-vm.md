---
title: Azure PowerShell Script Sample - Back up an Azure virtual machine | Microsoft Docs
description: Azure PowerShell Script Sample - Back up an Azure virtual machine 
services: backup
documentationcenter: 
author: alexchen2016
manager: digimobile
editor:
tags:

ms.assetid:
ms.service: backup
ms.devlang: na
ms.topic: sample
ms.tgt_pltfrm: na
ms.workload: storage-backup-recovery
origin.date: 09/07/2017
ms.date: 11/02/2017
ms.author: v-junlch
ms.custom: mvc
---

# Back up an encrypted Azure virtual machine with PowerShell

This script creates a Recovery Services vault with Geo-redundant storage (GRS) for an encrypted Azure virtual machine. The default protection policy is applied to the vault. The policy generates a daily backup for the virtual machine, and retains each backup for 30 days. The script also triggers the initial recovery point for the virtual machine and retains that recovery point for 365 days. 

[!INCLUDE [sample-powershell-install](../../../includes/sample-powershell-install-no-ssh.md)]

[!INCLUDE [quickstarts-1rmb-trial-note](../../../includes/quickstarts-1rmb-trial-note.md)]

## Sample script

```powershell
# Edit these global variables with your unique Recovery Services Vault name, resource group name and location
$rsVaultName = "myRsVault"
$rgName = "myResourceGroup"
$location = "chinanorth"

# Register the Recovery Services provider and create a resource group
Register-AzureRmResourceProvider -ProviderNamespace "Microsoft.RecoveryServices"
New-AzureRmResourceGroup -Location $location -Name $rgName

# Create a Recovery Services Vault and set its storage redundancy type
New-AzureRmRecoveryServicesVault `
    -Name $rsVaultName `
    -ResourceGroupName $rgName `
    -Location $location 
$vault1 = Get-AzureRmRecoveryServicesVault –Name $rsVaultName
Set-AzureRmRecoveryServicesBackupProperties ` 
    -Vault $vault1 `
    -BackupStorageRedundancy GeoRedundant
    
# Set Recovery Services Vault context and create protection policy
Get-AzureRmRecoveryServicesVault -Name $rsVaultName | Set-AzureRmRecoveryServicesVaultContext 
$schPol = Get-AzureRmRecoveryServicesBackupSchedulePolicyObject -WorkloadType "AzureVM"
$retPol = Get-AzureRmRecoveryServicesBackupRetentionPolicyObject -WorkloadType "AzureVM"
New-AzureRmRecoveryServicesBackupProtectionPolicy `
    -Name "NewPolicy" `
    -WorkloadType "AzureVM" ` 
    -RetentionPolicy $retPol `
    -SchedulePolicy $schPol
    
# Provide permissions to Azure Backup to access key vault and enable backup on the VM
Set-AzureRmKeyVaultAccessPolicy `
    -VaultName "KeyVaultName" `
    -ResourceGroupName "KyeVault-RGName" ` 
    -PermissionsToKeys backup,get,list `
    -PermissionsToSecrets backup,get,list ` 
    -ServicePrincipalName 262044b1-e2ce-469f-a196-69ab7ada62d3
$pol = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name "NewPolicy" `
Enable-AzureRmRecoveryServicesBackupProtection `
    -Policy $pol `
    -Name "myVM" `
    -ResourceGroupName "VM-RGName" 
    
# Modify protection policy
$retPol = Get-AzureRmRecoveryServicesBackupRetentionPolicyObject -WorkloadType "AzureVM"
$retPol.DailySchedule.DurationCountInDays = 365
$pol = Get-AzureRmRecoveryServicesBackupProtectionPolicy -Name "NewPolicy"
Set-AzureRmRecoveryServicesBackupProtectionPolicy `
    -Policy $pol `
    -RetentionPolicy $RetPol
    
# Trigger a backup and monitor backup job
$namedContainer = Get-AzureRmRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -FriendlyName "myVM"
$item = Get-AzureRmRecoveryServicesBackupItem -Container $namedContainer -WorkloadType "AzureVM"
$job = Backup-AzureRmRecoveryServicesBackupItem -Item $item
$joblist = Get-AzureRmRecoveryservicesBackupJob –Status "InProgress"
Wait-AzureRmRecoveryServicesBackupJob `
        -Job $joblist[0] `
        -Timeout 43200
```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources.

```powershell
Remove-AzureRmResourceGroup -Name myResourceGroup
```

## Script explanation

This script uses the following commands to create the deployment. Each item in the table links to command specific documentation.

| Command | Notes | 
|---|---| 
| [New-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/new-azurermresourcegroup) | Creates a resource group in which all resources are stored. | 
| [New-AzureRmRecoveryServicesVault](https://docs.microsoft.com/powershell/module/azurerm.recoveryservices/New-AzureRmRecoveryServicesVault) | Creates a recovery services vault to store backups. | 
| [Set-AzureRmRecoveryServicesBackupProperties](https://docs.microsoft.com/powershell/module/azurerm.recoveryservices/Set-AzureRmRecoveryServicesBackupProperties) | Sets backup storage properties on Recovery Services vault. | 
| [New-AzureRmRecoveryServicesBackupProtectionPolicy](https://docs.microsoft.com/powershell/module/azurerm.recoveryservices.backup/new-azurermrecoveryservicesbackupprotectionpolicy)| Creates protection policy using schedule policy and retention policy in Recovery Services vault. | 
| [Set-AzureRmKeyVaultAccessPolicy](https://docs.microsoft.com/powershell/module/azurerm.keyvault/set-azurermkeyvaultaccesspolicy) | Sets permissions on the Key Vault to grant the service principal access to encryption keys. | 
| [Enable-AzureRmRecoveryServicesBackupProtection](https://docs.microsoft.com/powershell/module/azurerm.recoveryservices.backup/enable-azurermrecoveryservicesbackupprotection) | Enables backup for an item with a specified Backup protection policy. | 
| [Set-AzureRmRecoveryServicesBackupProtectionPolicy](https://docs.microsoft.com/powershell/module/azurerm.recoveryservices.backup/set-azurermrecoveryservicesbackupprotectionpolicy)| Modifies an existing Backup protection policy. | 
| [Backup-AzureRmRecoveryServicesBackupItem](https://docs.microsoft.com/powershell/module/azurerm.recoveryservices.backup/backup-azurermrecoveryservicesbackupitem) | Starts a backup for a protected Azure Backup item that is not tied to the backup schedule. |
| [Wait-AzureRmRecoveryServicesBackupJob](https://docs.microsoft.com/powershell/module/azurerm.recoveryservices.backup/wait-azurermrecoveryservicesbackupjob) | Waits for an Azure Backup job to finish. | 
| [Remove-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/remove-azurermresourcegroup) | Removes a resource group and all resources contained within. | 

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).


