---
title: Prepare Azure resources to replicate on-premises VMware VMs to Azure using Azure Site Recovery | Azure
description: Describes what you need in place in Azure before you start replicating on-premises VMware VMs to Azure using Azure Site Recovery
services: site-recovery
documentationcenter: ''
author: rockboyfor
manager: digimobile
editor: ''

ms.assetid: 4e320d9b-8bb8-46bb-ba21-77c5d16748ac
ms.service: site-recovery
ms.workload: storage-backup-recovery
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 06/27/2017
ms.date: 08/28/2017
ms.author: v-yeche

---
# Step 5: Prepare Azure resources for VMWare replication to Azure

Use the instructions in this article to prepare Azure resources so that you can replicate on-premises machines to Azure using the [Azure Site Recovery](site-recovery-overview.md) service.

Post comments and questions at the bottom of this article, or on the [Azure Recovery Services Forum](https://social.msdn.microsoft.com/Forums/en-US/home?forum=hypervrecovmgr).

## Before you start

Make sure you've read the [prerequisites](vmware-walkthrough-prerequisites.md)

## Set up an Azure account

- Get a [Azure account](https://www.azure.cn/pricing/1rmb-trial-full/).
- You can start with a [trial](https://www.azure.cn/pricing/1rmb-trial/).
- Check the supported regions for Site Recovery, Under Geographic Availability in [Azure Site Recovery Pricing Details](https://www.azure.cn/pricing/details/site-recovery/).
- Learn about [Site Recovery pricing](site-recovery-faq.md#pricing), and get the [pricing details](https://www.azure.cn/pricing/details/site-recovery/).

## Set up an Azure network

- Set up an Azure network. Azure VMs are placed in this network when they're created after failover.
- Site Recovery in the Azure portal can use networks set up in [Resource Manager](../resource-manager-deployment-model.md), or in classic mode.
- The network should be in the same region as the Recovery Services vault
- Learn about [virtual network pricing](https://www.azure.cn/pricing/details/networking/).
- Learn more about [Azure VM connectivity](site-recovery-network-design.md) after failover.

## Set up an Azure storage account

- Site Recovery replicates on-premises machines to Azure storage. Azure VMs are created from the storage after failover occurs.
- Set up an [Azure storage account](../storage/common/storage-create-storage-account.md#create-a-storage-account) for replicated data.
- Site Recovery in the Azure portal can use storage accounts set up in Resource Manager, or in classic mode.
- The storage account can be standard or [premium](../storage/common/storage-premium-storage.md).
- If you set up a premium account, you will also need an additional standard account for log data.

## Next steps

Go to [Step 6: Prepare VMware resources](vmware-walkthrough-prepare-vmware.md)

<!--Update_Description: new articles on site recovery prepare azure from vmware to azure-->