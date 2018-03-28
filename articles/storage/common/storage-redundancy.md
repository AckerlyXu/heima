---
title: Data replication in Azure Storage | Microsoft Docs
description: Data in your Azure Storage account is replicated for durability and high availability. Replication options include locally redundant storage (LRS), zone-redundant storage (ZRS), geo-redundant storage (GRS), and read-access geo-redundant storage (RA-GRS).
services: storage
author: yunan2016
manager: digimobile

ms.service: storage
ms.workload: storage
ms.topic: article
origin.date: 01/21/2018
ms.date: 3/5/2018
ms.author: v-nany
---

# Azure Storage replication

The data in your Microsoft Azure storage account is always replicated to ensure durability and high availability. Replication copies your data so that it is protected from transient hardware failures, preserving your application up-time. 

You can choose to replicate your data within the same data center, across data centers within the same region, or across regions. If your data is replicated across multiple data centers or across regions, it's also protected from a catastrophic failure in a single location.

Replication ensures that your storage account meets the [Service-Level Agreement (SLA) for Storage](https://www.azure.cn/support/sla/storage/) even in the face of failures. See the SLA for information about Azure Storage guarantees for durability and availability.

When you create a storage account, you can select one of the following replication options:

* [Locally redundant storage (LRS)](#locally-redundant-storage)
* [Geo-redundant storage (GRS)](#geo-redundant-storage)
* [Read-access geo-redundant storage (RA-GRS)](#read-access-geo-redundant-storage)

Read-access geo-redundant storage (RA-GRS) is the default option when you create a storage account.

The following table provides a quick overview of the differences between LRS, ZRS, GRS, and RA-GRS. Subsequent sections of this article address each type of replication in more detail.

| Replication strategy | LRS | GRS | RA-GRS |
|:--- |:--- |:--- |:--- |
| Data is replicated across multiple datacenters. |No |Yes |Yes |
| Data can be read from a secondary location as well as the primary location. |No |No |Yes |
| Designed to provide ___ durability of objects over a given year. |at least 99.999999999% (11 9's)|at least 99.99999999999999% (16 9's)|at least 99.99999999999999% (16 9's)|

See [Azure Storage Pricing](https://www.azure.cn/pricing/details/storage/) for pricing information for the different redundancy options.

> [!NOTE]
> Premium Storage supports only locally redundant storage (LRS). For information about Premium Storage, see [Premium Storage: High-Performance Storage for Azure Virtual Machine Workloads](../../virtual-machines/windows/premium-storage.md).
>

## Locally redundant storage
[!INCLUDE [storage-common-redundancy-LRS](../../../includes/storage-common-redundancy-LRS.md)]


## <a name="geo-redundant-storage"></a>Geo-redundant storage
[!INCLUDE [storage-common-redundancy-GRS](../../../includes/storage-common-redundancy-GRS.md)]

## Read-access geo-redundant storage
Read-access geo-redundant storage (RA-GRS) maximizes availability for your storage account. RA-GRS provides read-only access to the data in the secondary location, in addition to geo-replication across two regions.

When you enable read-only access to your data in the secondary region, your data is available on a secondary endpoint as well as on  the primary endpoint for your storage account. The secondary endpoint is similar to the primary endpoint, but appends the suffix `-secondary` to the account name. For example, if your primary endpoint for the Blob service is `myaccount.blob.core.chinacloudapi.cn`, then your secondary endpoint is `myaccount-secondary.blob.core.chinacloudapi.cn`. The access keys for your storage account are the same for both the primary and secondary endpoints.

Some considerations to keep in mind when using RA-GRS:

* Your application has to manage which endpoint it is interacting with when using RA-GRS.
* Since asynchronous replication involves a delay, changes that have not yet been replicated to the secondary region may be lost if data cannot be recovered from the primary region, for example in the event of a regional disaster.
* If Azure initiates failover to the secondary region, you will have read and write access to that data after the failover has completed. For more information, please see [Disaster Recovery Guidance](../storage-disaster-recovery-guidance.md). 
* RA-GRS is intended for high-availability purposes. For scalability guidance, please review the [performance checklist](../storage-performance-checklist.md).

## Frequently asked questions

<a id="howtochange"></a>
#### 1. How can I change the geo-replication type of my storage account?

   You can change the geo-replication type of your storage account by using the [Azure portal](https://portal.azure.cn/), [Azure Powershell](storage-powershell-guide-full.md), or one of the Azure Storage client libraries.

   > [!NOTE]
   > ZRS accounts cannot be converted LRS or GRS. Similarly, an existing LRS or GRS account cannot be converted to a ZRS account.
    
<a id="changedowntime"></a>
#### 2. Does changing the replication type of my storage account result in down time?

   No, changing the replication type of your storage account does not result in down time.

<a id="changecost"></a>
#### 3. Are there additional costs to changing the replication type of my storage account?

   Yes. If you change from LRS to GRS (or RA-GRS) for your storage account, you incur an additional charge for egress involved in copying existing data from primary location to the secondary location. After the initial data is copied, there are no further additional egress charges for geo-replication from the primary to secondary location. For details on bandwidth charges, see [Azure Storage Pricing page](https://www.azure.cn/pricing/details/storage).

   If you change from GRS to LRS, there is no additional cost, but your data is deleted from the secondary location.

<a id="ragrsbenefits"></a>
#### 4. How can RA-GRS help me?

   GRS storage provides replication of your data from a primary to a secondary region that is hundreds of miles away from the primary region. With GRS, your data is durable even in the event of a complete regional outage or a disaster in which the primary region is not recoverable. RA-GRS storage offers GRS replication and adds the ability to read the data from the secondary location. For suggestions on how to design for high availability, see [Designing Highly Available Applications using RA-GRS storage](../storage-designing-ha-apps-with-ragrs.md).

<a id="lastsynctime"></a>
#### 5. Is there a way to figure out how long it takes to replicate my data from the primary to the secondary region?

   If you are using RA-GRS storage, you can check the Last Sync Time of your storage account. Last Sync Time is a GMT date/time value. All primary writes before the Last Sync Time have been successfully written to the secondary location, meaning that they are available to be read from the secondary location. Primary writes after the Last Sync Time may or may not be available for reads yet. You can query this value using the [Azure portal](https://portal.azure.com/), [Azure PowerShell](storage-powershell-guide-full.md), or from one of the Azure Storage client libraries.

<a id="outage"></a>
#### 6. If there is an outage in the primary region, how do I switch to the secondary region?

   For more information, see [What to do if an Azure Storage outage occurs](../storage-disaster-recovery-guidance.md).

<a id="rpo-rto"></a>
#### 7. What is the RPO and RTO with GRS?

   **Recover Point Objective (RPO):** In GRS and RA-GRS, the storage service asynchronously geo-replicates the data from the primary to the secondary location. In the event of a major regional disaster in the primary region, Microsoft performs a failover to the secondary region. If a failover happens, recent changes that have not yet been geo-replicated may be lost. The number of minutes of potential data lost is referred to as the RPO, and it indicates the point in time to which data can be recovered. Azure Storage typically has an RPO of less than 15 minutes, although there is currently no SLA on how long geo-replication takes.

   **Recovery Time Objective (RTO):** The RTO is a measure of how long it takes to perform the failover and get the storage account back online. The time to perform the failover includes the following actions:

   * The time Azure requires to determine whether the data can be recovered at the primary location, or if a failover is necessary.
   * The time to perform the failover of the storage account by changing the primary DNS entries to point to the secondary location.

   Azure takes the responsibility of preserving your data seriously. If there is any chance of recovering the data in the primary region, Microsoft will delay the failover and focus on recovering your data. A future version of the service will allow you to trigger a failover at an account level so that you can control the RTO yourself.

## Next steps
* [Designing highly available applications using RA-GRS Storage](../storage-designing-ha-apps-with-ragrs.md)
* [Azure Storage pricing](https://www.azure.cn/pricing/details/storage/)
* [About Azure storage accounts](../storage-create-storage-account.md)
* [Azure Storage scalability and performance targets](storage-scalability-targets.md)
* [Azure Storage redundancy options and read access geo redundant storage ](http://blogs.msdn.com/b/windowsazurestorage/archive/2013/12/11/introducing-read-access-geo-replicated-storage-ra-grs-for-windows-azure-storage.aspx)
* [SOSP Paper - Azure Storage: A highly available cloud storage service with strong consistency](http://blogs.msdn.com/b/windowsazurestorage/archive/2011/11/20/windows-azure-storage-a-highly-available-cloud-storage-service-with-strong-consistency.aspx)

<!--Update_Description:wording update-->