---
title: Prepare Azure resources to replicate on-premises physical servers to Azure using Azure Site Recovery| Azure
description: Describes what you need in place in Azure before you start replicating on-premises servers to Azure, using the Azure Site Recovery service
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
origin.date: 06/25/2017
ms.date: 07/31/2017
ms.author: v-yeche

---
# Step 5: Prepare Azure resources for physical server replication to Azure

Use the instructions in this article to prepare Azure resources so that you can replicate on-premises servers to Azure using the [Azure Site Recovery](site-recovery-overview.md) service.



## Before you start

Make sure you've read the [prerequisites](physical-walkthrough-prerequisites.md).

## Set up an Azure account

- Get a [Azure account](http://azure.microsoft.com/).
- You can start with a [trial](https://www.azure.cn/pricing/1rmb-trial/).
- Check the supported regions for Site Recovery, under **Geographic Availability** in [Azure Site Recovery Pricing Details](https://www.azure.cn/pricing/details/site-recovery/).
- Learn about [Site Recovery pricing](site-recovery-faq.md#pricing), and get the [pricing details](https://www.azure.cn/pricing/details/site-recovery/).

## Set up an Azure network

- Set up an Azure network. Azure VMs are placed in this network when they're created after failover.
- Site Recovery in the Azure portal can use networks set up in [Resource Manager](../resource-manager-deployment-model.md), or in classic mode.
- The network should be in the same region as the Recovery Services vault.
- Learn about [virtual network pricing](https://www.azure.cn/pricing/details/networking/).
- Learn more about [Azure VM connectivity](physical-walkthrough-network.md) after failover.

## Set up an Azure storage account

- Site Recovery replicates on-premises servers to Azure storage. Azure VMs are created from the storage after failover occurs.
- Set up an [Azure storage account](../storage/storage-create-storage-account.md#create-a-storage-account) for replicated data.
- Site Recovery in the Azure portal can use storage accounts set up in Resource Manager, or in classic mode.
- The storage account can be standard or [premium](../storage/storage-premium-storage.md).
- If you set up a premium account, you will also need an additional standard account for log data.

## Next steps

Go to [Step 6: Set up a vault](physical-walkthrough-create-vault.md)

<!--Update_Description: new article about walkthrought prepare azure from physical to azure -->