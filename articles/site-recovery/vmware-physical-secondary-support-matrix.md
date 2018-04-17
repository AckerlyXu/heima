---
title: Support matrix for replication of VMware VMs or physical servers to a secondary VMware site with Azure Site Recovery | Azure
description: Summarizes the support for VMware/physical server replication to a secondary site with Azure Site Recovery
services: site-recovery
author: rockboyfor
manager: digimobile
ms.service: site-recovery
ms.topic: article
origin.date: 03/05/2018
ms.date: 04/02/2018
ms.author: v-yeche
---

# Support matrix for replication of VMware VMs and physical servers to a secondary site

This article summarizes what's supported when you use the [Azure Site Recovery](site-recovery-overview.md) service to replicate VMware VMs or Windows/Linux physical servers to a secondary VMware site.

- If you want to replicate VMware VMs or physical servers to Azure, review [this support matrix](vmware-physical-azure-support-matrix.md).
- If you want to replicate Hyper-V VMs to a secondary site, review [this support matrix](hyper-v-azure-support-matrix.md).

> [!NOTE]
> Replication of on-premises VMware VMs and physical servers is provided by InMage Scout. InMage Scout is included in Azure Site Recovery service subscription.

## Host servers

**Operating system** | **Details**
--- | ---
vCenter server | vCenter 5.5, 6.0 and 6.5<br/><br/> If you run 6.0 or 6.5, note that only 5.5 features are supported.

## Replicated VM support

The following table summarizes operating system support for machines replicated with Site Recovery. Any workload can be running on the supported operating system.

**Operating system** | **Details**
--- | ---
Windows Server | 64-bit Windows Server 2016, Windows Server 2012 R2, Windows Server 2012, Windows Server 2008 R2 with at least SP1.
Linux | Centos 6.5, 6.6, 6.7, 6.8, 6.9, 7.0, 7.1, 7.2 <br/><br/>  SUSE Linux Enterprise Server 11 SP3, 11 SP4 
<!-- Not Available on Red Hat Enterprise Linux: 5.2 to 5.11, 6.1 to 6.9, 7.0 to 7.4<br/><br/> -->
<!-- Not Available on Oracle Enterprise Linux 6.4, 6.5, 6.8 running the Red Hat compatible kernel, or Unbreakable Enterprise Kernel Release 3 (UEK3) <br/><br/> -->

## Linux machine storage

Only Linux machines with the following storage can be replicated:

- File system (EXT3, ETX4, ReiserFS, XFS).
- Multipath software-device Mapper.
- Volume manager (LVM2).
- Physical servers with HP CCISS controller storage are not supported.
- The ReiserFS file system is supported only on SUSE Linux Enterprise Server 11 SP3.

## Network configuration - Host/Guest VM

**Configuration** | **Supported**  
--- | --- 
Host - NIC teaming | Yes 
Host - VLAN | Yes 
Host - IPv4 | Yes 
<!-- Not Avaialable on Host - IPv6 | No -->
Guest VM - NIC teaming | No
Guest VM - IPv4 | Yes
<!-- Not Avaialable on Guest VM - IPv6 | No -->
Gues VM - Windows/Linux - Static IP address | Yes
Guest VM - Multi-NIC | Yes

## Storage

### Host storage

**Storage (host)** | **Supported** 
--- | --- 
NFS | Yes 
SMB 3.0 | N/A 
SAN (ISCSI) | Yes 
Multi-path (MPIO) | Yes 

### Guest or physical server storage

**Configuration** | **Supported** 
--- | --- 
VMDK | Yes 
VHD/VHDX | N/A 
Gen 2 VM | N/A 
Shared cluster disk | Yes 
Encrypted disk | No 
UEFI| Yes 
NFS | No 
SMB 3.0 | No 
RDM | Yes 
Disk > 1 TB | Yes 
Volume with striped disk > 1 TB<br/><br/> LVM | Yes 
Storage Spaces | No 
Hot add/remove disk | Yes 
Exclude disk | Yes 
Multi-path (MPIO) | N/A 

## Vaults

**Action** | **Supported** 
--- | --- 
Move vaults across resource groups (within or across subscriptions) | No 
Move storage, network, Azure VMs across resource groups (within or across subscriptions) | No 

## Mobility service and updates

The Mobility service coordinates replication between on-premises VMware servers or physical servers, and the secondary site. When you set up replication, you should make sure you have the latest version of the Mobility service, and of other components.

**Update** | **Details** 
--- | --- 
Scout updates | [Learn about and download](vmware-physical-secondary-disaster-recovery.md#updates) the latest Scout updates | Scout updates are cumulative.
<!-- Notice: Archor should be (vmware-physical-secondary-disaster-recovery.md#updates)-->
Component updates | Scout updates include updates for all components, including the RX server, configuration server, process and master target servers, vContinuum servers, and source servers you want to protect.<br/><br/> [Learn more](vmware-physical-secondary-disaster-recovery.md#download-and-install-component-updates).

## Next steps

Download the [InMage Scout user guide](https://aka.ms/asr-scout-user-guide)

- [Replicate Hyper-V VMs in VMM clouds to a secondary site](tutorial-vmm-to-vmm.md)
- [Replicate VMware VMs and physical servers to a secondary site](tutorial-vmware-to-vmware.md)

<!-- Update_Description: update meta properties, wording update, update link -->
