---
title: Windows VM sizes in Azure | Azure
description: Lists the different sizes available for Windows virtual machines in Azure.
services: virtual-machines-windows
documentationcenter: ''
author: rockboyfor
manager: digimobile
editor: ''
tags: azure-resource-manager,azure-service-management

ms.assetid: aabf0d30-04eb-4d34-b44a-69f8bfb84f22
ms.service: virtual-machines-windows
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: vm-windows
ms.workload: infrastructure-services
origin.date: 03/01/2018
ms.date: 05/21/2018
ms.author: v-yeche
---

# Sizes for Windows virtual machines in Azure

This article describes the available sizes and options for the Azure virtual machines you can use to run your Windows apps and workloads. It also provides deployment considerations to be aware of when you're planning to use these resources.  This article is also available for [Linux virtual machines](../linux/sizes.md?toc=%2fvirtual-machines%2flinux%2ftoc.json).

<!--PENDING FOR Dv3, Ev3 and B-SERIES GA ANOUNCEMENT -->
| Type                     | Sizes           |    Description       |
|--------------------------|-------------------|------------------------------------------------------------------------------------------------------------------------------------|
| [General purpose](sizes-general.md)          | B, Dsv3, Dv3, DSv2, Dv2, DS, D, Av2, A0-7 | Balanced CPU-to-memory ratio. Ideal for testing and development, small to medium databases, and low to medium traffic web servers. |
| [Compute optimized](sizes-compute.md)        | Fs, F             | High CPU-to-memory ratio. Good for medium traffic web servers, network appliances, batch processes, and application servers.        |
| [Memory optimized](../virtual-machines-windows-sizes-memory.md)         | Esv3, Ev3, DSv2, DS, Dv2, D   | High memory-to-CPU ratio. Great for relational database servers, medium to large caches, and in-memory analytics.                 |
<!--PENDING FOR Dv3, Ev3 and B-SERIES GA ANOUNCEMENT -->
<!-- Not Available M, Gs, G series -->
<!-- Not Available [Storage optimized] Ls -->
<!-- Not Available [GPU] NV, NC, N-series  -->
<!-- Not Available [High performance compute] H, A8-11 -->

<br> 

- For information about pricing of the various sizes, see [Virtual Machines Pricing](https://www.azure.cn/pricing/details/virtual-machines/#Windows). 
- To see general limits on Azure VMs, see [Azure subscription and service limits, quotas, and constraints](../../azure-subscription-service-limits.md).
- Storage costs are calculated separately based on used pages in the storage account. For details, [Azure Storage Pricing](https://www.azure.cn/pricing/details/storage/).
- Learn more about how [Azure compute units (ACU)](acu.md) can help you compare compute performance across Azure SKUs.

## REST API

For information on using the REST API to query for VM sizes, see the following:

- [List available virtual machine sizes for resizing](https://docs.microsoft.com/rest/api/compute/virtualmachines/virtualmachines-list-sizes-for-resizing)
- [List available virtual machine sizes for a subscription](https://docs.microsoft.com/rest/api/compute/virtualmachines/virtualmachines-list-sizes-region)
- [List available virtual machine sizes in an availability set](https://docs.microsoft.com/rest/api/compute/virtualmachines/virtualmachines-list-sizes-availability-set)

## ACU

Learn more about how [Azure compute units (ACU)](acu.md) can help you compare compute performance across Azure SKUs.

## Benchmark scores

Learn more about compute performance for Windows VMs using the [CoreMark benchmark scores](compute-benchmark-scores.md).

## Next steps

Learn more about the different VM sizes that are available:
- [General purpose](sizes-general.md)
- [Compute optimized](sizes-compute.md)
- [Memory optimized](../virtual-machines-windows-sizes-memory.md)
<!-- Not Available on - [Storage optimized](../virtual-machines-windows-sizes-storage.md) -->
<!-- Not Available on - [GPU optimized](sizes-gpu.md) -->
<!-- Not Available on - [High performance compute](sizes-hpc.md)-->

<!--Update_Description: update meta properties, update link, add benchmark scores -->
<!--PENDING FOR Dv3, Ev3 and B-SERIES GA ANOUNCEMENT -->