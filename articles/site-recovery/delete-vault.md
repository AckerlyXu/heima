---
title: Delete Recovery Services vault
service: site-recovery
documentationcenter: ''
author: rockboyfor
manager: digimobile
editor: ''

ms.assetid:
ms.service: site-recovery
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: storage-backup-recovery
origin.date: 07/04/2017
ms.date: 07/31/2017
ms.author: v-yeche

---
# Delete Recovery Services vault
Dependencies prevent you from deleting recovery services vault and the actions you need to take varies based on the type of Azure Site Recovery scenario – VMWare to Azure, Hyper-V (with and without VMM) to Azure,  and Azure Backup. To delete a vault used in Azure Backup, check [this](../backup/backup-azure-delete-vault.md) link.

>[!Important]
>If you are testing the product, and want to rapidly delete the vault and are not concerned about data loss, then you can use the force delete method to remove vault and all its dependencies.

> Please note that the PowerShell command will delete all the contents of the vault and is not a reversible step

## Force delete vault using Powershell

Follow below steps to delete Site Recovery vault even if there are protected items

    Login-AzureRmAccount -EnvironmentName AzureChinaCloud

    Select-AzureRmSubscription -SubscriptionName "XXXXX"

    $vault = Get-AzureRmSiteRecoveryVault -Name "vaultname"

    Remove-AzureRmSiteRecoveryVault -Vault $vault

Follow recommended steps (in given order) for your scenario to delete the vault

<!-- Not Available ## Delete Vault, used in Site Recovery for protecting VMWare VMs to Azure: -->


## Delete Vault, used in Site Recovery for protecting Hyper-V VMs (with VMM) to Azure:
1.  Ensure all Protected VMs are deleted, see [how to](site-recovery-manage-registration-and-protection.md##disable-protection-for-a-vmware-vm-or-physical-server).
- Ensure all replication policies are deleted.
-	Delete references to VMM Servers, see [how to](site-recovery-manage-registration-and-protection.md##unregister-a-connected-vmm-server)
-	Now try deleting the vault.
<!-- Not Available (site-recovery-setup-replication-settings-vmware.md##delete-a-replication-policy) -->

## Delete Vault, used in Site Recovery  for protecting Hyper-V VMs (without VMM) to Azure:
1. Ensure all Protected VMs are deleted, see [how to](site-recovery-manage-registration-and-protection.md##disable-protection-for-a-vmware-vm-or-physical-server).
- Ensure all replication policies are deleted.
-	Delete references to Hyper-V Servers, see [how to](/site-recovery-manage-registration-and-protection.md##unregister-a-hyper-v-host-in-a-hyper-v-site).
-	Delete Hyper-V site.
-	Now try deleting the vault.
<!-- Not Available (site-recovery-setup-replication-settings-vmware.md##delete-a-replication-policy) -->
