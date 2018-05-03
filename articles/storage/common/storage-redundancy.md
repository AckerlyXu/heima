---
title: Data replication in Azure Storage | Microsoft Docs
description: Data in your Azure Storage account is replicated for durability and high availability. Replication options include locally redundant storage (LRS), zone-redundant storage (ZRS), geo-redundant storage (GRS), and read-access geo-redundant storage (RA-GRS).
services: storage
author: forester123
manager: josefree

ms.service: storage
ms.topic: article
origin.date: 01/21/2018
ms.date: 05/07/2018
ms.author: v-johch
---

# Azure Storage replication

The data in your Azure storage account is always replicated to ensure durability and high availability. Azure Storage replication copies your data so that it is protected from planned and unplanned events ranging from transient hardware failures, network or power outages, massive natural disasters, and so on. You can choose to replicate your data within the same data center and even across regions.

Replication ensures that your storage account meets the [Service-Level Agreement (SLA) for Storage](https://www.azure.cn/zh-cn/support/sla/storage/) even in the face of failures. See the SLA for information about Azure Storage guarantees for durability and availability.

## Choosing a replication option

When you create a storage account, you can select one of the following replication options:

* [Locally redundant storage (LRS)](storage-redundancy-lrs.md)
* [Geo-redundant storage (GRS)](storage-redundancy-grs.md)
* [Read-access geo-redundant storage (RA-GRS)](storage-redundancy-grs.md#read-access-geo-redundant-storage)

The following table provides a quick overview of the scope of durability and availability that each replication strategy will provide you for a given type of event (or event of similar impact).

| Scenario | LRS | GRS | RA-GRS |
|:--- |:--- |:--- |:--- |
| Node unavailability within a data center |Yes |Yes |Yes
| An entire data center (zonal or non-zonal) becomes unavailable |No |Yes |Yes |
| A region-wide outage |No |Yes |Yes |
| Read access to your data (in a remote, geo-replicated region) in the event of region-wide unavailability |No |No |Yes |
| Designed to provide ___ durability of objects over a given year |at least 99.999999999% (11 9's)|at least 99.99999999999999% (16 9's)|at least 99.99999999999999% (16 9's)|
| Available in ___ storage account types |GPv1, Blob |GPv1, Blob |GPv1, Blob

See [Azure Storage Pricing](https://www.azure.cn/pricing/details/storage/) for pricing information on the different redundancy options.

> [!NOTE]
> Premium Storage supports only locally redundant storage (LRS). For information about Premium Storage, see [Premium Storage: High-Performance Storage for Azure Virtual Machine Workloads](../../virtual-machines/windows/premium-storage.md).

## Changing replication strategy
We allow you to change your storage account's replication strategy by using the [Azure portal](https://portal.azure.cn/), [Azure Powershell](storage-powershell-guide-full.md), [Azure CLI](/cli/install-azure-cli?view=azure-cli-latest), or one of the many [Azure client libraries](https://docs.azure.cn/index?view=azure-dotnet#pivot=sdkstools). Changing the replication type of your storage account does not result in down time.

### Are there any costs to changing my account's replication strategy?
It depends on your conversion path. Ordering from cheapest to the most expensive redundancy offering we have LRS, GRS, and RA-GRS. For example, going *from* LRS to anything will incur additional charges because you are going to a more sophisticated redundancy level. Going *to* GRS or RA-GRS will incur an egress bandwidth charge because your data (in your primary region) is being replicated to your remote secondary region. This is a one-time charge at initial setup. After the data is copied, there are no further conversion charges. You will only be charged for replicating any new or updates to existing data. For details on bandwidth charges, see [Azure Storage Pricing page](https://www.azure.cn/pricing/details/storage/blobs/).

If you change from GRS to LRS, there is no additional cost, but your replicated data is deleted from the secondary location.

## See also

- [Locally-redundant storage (LRS): Low-cost data redundancy for Azure Storage](storage-redundancy-lrs.md)
- [Geo-redundant storage (GRS): Cross-regional replication for Azure Storage](storage-redundancy-grs.md)
- [Azure Storage scalability and performance targets](storage-scalability-targets.md)
- [Designing highly available applications using RA-GRS Storage](../storage-designing-ha-apps-with-ragrs.md)
- [Azure Storage redundancy options and read access geo redundant storage ](http://blogs.msdn.com/b/windowsazurestorage/archive/2013/12/11/introducing-read-access-geo-replicated-storage-ra-grs-for-windows-azure-storage.aspx)
- [SOSP Paper - Azure Storage: A highly available cloud storage service with strong consistency](http://blogs.msdn.com/b/windowsazurestorage/archive/2011/11/20/windows-azure-storage-a-highly-available-cloud-storage-service-with-strong-consistency.aspx)
<!--Update_Description: main content struture update-->