---
title: How does on-premises machine replication to a secondary on-premises site work in Azure Site Recovery? | Azure
description: This article provides an overview of components and architecture used when replicating on-premises VMs and physical servers to a secondary site with the Azure Site Recovery service.
services: site-recovery
documentationcenter: ''
author: rockboyfor
manager: digimobile
editor: ''

ms.assetid: c413efcd-d750-4b22-b34b-15bcaa03934a
ms.service: site-recovery
ms.workload: storage-backup-recovery
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: get-started-article
origin.date: 05/29/2017
ms.date: 07/10/2017
ms.author: v-yeche

---
# How does on-premises machine replication to a secondary site work in Site Recovery?

This article describes the components and processes involved when replicating on-premises virtual machines and physical servers to Azure, using the [Azure Site Recovery](site-recovery-overview.md) service.

You can replicate the following to a secondary on-premises site:
- On-premises Hyper-V VMs Hyper-V VMs on Hyper-V clusters and standalone hosts that are managed in System Center Virtual Machine Manager (VMM) clouds.
<!-- Not Available - On-premises VMware VMs and Windows/Linux physical servers. In this scenario replication is managed by Scout. -->

## Replicate Hyper-V VMs to a secondary on-premises site

### Architectural components

Here's what you need for replicating Hyper-V VMs to a secondary site.

**Component** | **Location** | **Details**
--- | --- | ---
**Azure** | You need an account in Microsoft. |
**VMM server** | We recommend a VMM server in the primary site, and one in the secondary site | Each VMM server should be connected to the internet.<br/><br/> Each server should have at least one VMM private cloud, with the Hyper-V capability profile set.<br/><br/> You install the Azure Site Recovery Provider on the VMM server. The Provider coordinates and orchestrates replication with the Site Recovery service over the internet. Communications between the Provider and Azure are secure and encrypted.
**Hyper-V server** |  One or more Hyper-V host servers in the primary and secondary VMM clouds.<br/><br/> Servers should be connected to the internet.<br/><br/> Data is replicated between the primary and secondary Hyper-V host servers over the LAN or VPN, using Kerberos or certificate authentication.  
**Hyper-V VMs** | Located on the source Hyper-V host server. | The source host server should have at least one VM that you want to replicate.

### Replication process

1. You set up the Azure account.
2. You create a Replication Services vault for Site Recovery, and configure vault settings, including:

    - The replication source and target (primary and secondary sites).
    - Installation of the Azure Site Recovery Provider and the Azure Recovery Services agent. The Provider is installed on VMM servers, and the agent on each Hyper-V host.
    - You create a replication policy for source VMM cloud. The policy is applied to all VMs located on hosts in the cloud.
    - You enable replication for Hyper-V VMs. Initial replication occurs in accordance with the replication policy settings.
4. Data changes are tracked, and replication of delta changes to begins after the initial replication finishes. Tracked changes for an item are held in a .hrl file.
5. You run a test failover to make sure everything's working.

**Figure 1: VMM to VMM replication**

![On-premises to on-premises](./media/site-recovery-components/arch-onprem-onprem.png)

### Failover and failback process

1. You can run a planned or unplanned [failover](site-recovery-failover.md) between on-premises sites. If you run a planned failover, then source VMs are shut down to ensure no data loss.
2. You can fail over a single machine, or create [recovery plans](site-recovery-create-recovery-plans.md) to orchestrate failover of multiple machines.
4. If you perform an unplanned failover to a secondary site, after the failover machines in the secondary location aren't enabled for protection or replication. If you ran a planned failover, after the failover, machines in the secondary location are protected.
5. Then, you commit the failover to start accessing the workload from the replica VM.
6. When your primary site is available again, you initiate reverse replication to replicate from the secondary site to the primary. Reverse replication brings the virtual machines into a protected state, but the secondary datacenter is still the active location.
7. To make the primary site into the active location again, you initiate a planned failover from secondary to primary, followed by another reverse replication.

<!-- Not Available ## Replicate VMware VMs/physical servers to a secondary site -->



## Next steps

Review the [support matrix](site-recovery-support-matrix-to-sec-site.md)