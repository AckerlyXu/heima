---
title: Frequently Asked Questions (FAQ) about Azure IaaS VM Disks | Azure
description: Frequently asked questions about Azure IaaS VM disks and premium disks (managed and unmanaged)
services: storage
documentationcenter: ''
author: robinsh
manager: timlt
editor: tysonn

ms.assetid: e2a20625-6224-4187-8401-abadc8f1de91
ms.service: storage
ms.workload: storage
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
ms.date: 03/19/2017
ms.author: robinsh

---
# Frequently Asked Questions about Azure IaaS VM Disks and unmanaged premium disks

In this article, we'll visit some of the frequently asked questions about Managed Disks and Premium Storage.


## Premium Disks – unmanaged

**If a VM uses a size series that supports Premium storage, such as a DSv2, can I attach both premium and standard data disks?** 

Yes.

**Can I attach both premium and standard data disks to a size series that does not support Premium storage, such as D, Dv2, or F series?**

No. You can only attach standard data disks to VMs that do not use a size series that supports Premium storage.

**If I create a premium data disk from an existing VHD that was 80 GB in size, how much will that cost me?**

A premium data disk created from 80 GB VHD will be treated as the next available premium disk size, which is a P10 disk. You will be charged as per the P10 disk pricing.

**Are there transaction costs when using Premium Storage?**

There is a fixed cost for each disk size which comes provisioned with specific limits on IOPS and throughput. The other costs are outbound bandwidth and snapshot capacity, if applicable. Please check the [pricing page](https://www.azure.cn/pricing/details/storage/) for details.

**What are the limits for IOPS and throughput that can I get from the disk cache?**

The combined limits for cache and local SSD for a DS series are 4000 IOPS per core and 33 MB per second per core. 

**Is there any repercurssions on using TRIM on Premium Disks?**

There is no downside of using TRIM on Azure Disks on either Premium or Standard Disks.

## What if my question isn't answered here?

If your question isn't listed here, let us know and we'll help you find an answer. You can post a question at the end of this article in the comments or in the MSDN [Azure Storage forum](https://social.msdn.microsoft.com/forums/azure/home?forum=windowsazuredata) to engage with the Azure Storage team and other community members about this article.

