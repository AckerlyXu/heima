---
title: Azure hot, cool storage for blobs | Microsoft Docs
description: Hot, cool storage for Azure storage accounts.
services: storage
documentationcenter: ''
author: forester123
manager: josefree
editor:

ms.assetid: eb33ed4f-1b17-4fd6-82e2-8d5372800eef
ms.service: storage
ms.workload: storage
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: get-started-article
origin.date: 12/11/2017
ms.date: 05/07/2018
ms.author: v-johch

---
# Azure Blob storage: Hot, cool storage tiers

## Overview

Azure storage offers two storage tiers for Blob object storage so that you can store your data most cost-effectively depending on how you use it. The Azure **hot storage tier** is optimized for storing data that is accessed frequently. The Azure **cool storage tier** is optimized for storing data that is infrequently accessed and stored for at least 30 days. Data in the cool storage tier can tolerate slightly lower availability, but still requires high durability and similar time-to-access and throughput characteristics as hot data. For cool data, a slightly lower availability SLA and higher access costs compared to hot data are acceptable trade-offs for lower storage costs. The hot and cool storage tiers can be set at the account level and object level.

Today, data stored in the cloud is growing at an exponential pace. To manage costs for your expanding storage needs, it's helpful to organize your data based on attributes like frequency-of-access and planned retention period to optimize costs. Data stored in the cloud can be different in terms of how it is generated, processed, and accessed over its lifetime. Some data is actively accessed and modified throughout its lifetime. Some data is accessed frequently early in its lifetime, with access dropping drastically as the data ages. Some data remains idle in the cloud and is rarely, if ever, accessed once stored.

Each of these data access scenarios benefits from a different storage tier that is optimized for a particular access pattern. With hot, cool storage tiers, Azure Blob storage addresses this need for differentiated storage tiers with separate pricing models.

## Storage accounts that support tiering

You may only tier your object storage data to hot, cool in Blob Storage. General Purpose v1 (GPv1) accounts do not support tiering. 

Blob Storage exposes the **Access Tier** attribute at the account level, which allows you to specify the default storage tier as hot or cool for any blob in the storage account that does not have the tier set at the object level. For objects with the tier set at the object level, the account tier will not apply. You can switch between these storage tiers at any time.

## Hot access tier

Hot storage has higher storage costs than cool storage, but the lowest access costs. Example usage scenarios for the hot storage tier include:

* Data that is in active use or expected to be accessed (read from and written to) frequently.
* Data that is staged for processing and eventual migration to the cool storage tier.

## Cool access tier

Cool storage tier has lower storage costs and higher access costs compared to hot storage. This tier is intended for data that will remain in the cool tier for at least 30 days. Example usage scenarios for the cool storage tier include:

* Short-term backup and disaster recovery datasets.
* Older media content not viewed frequently anymore but is expected to be available immediately when accessed.
* Large data sets that need to be stored cost effectively while more data is being gathered for future processing. (*For example*, long-term storage of scientific data, raw telemetry data from a manufacturing facility)

## Blob-level tiering

Blob-level tiering allows you to change the tier of your data at the object level using a single operation called [Set Blob Tier](https://docs.microsoft.com/rest/api/storageservices/set-blob-tier). You can easily change the access tier of a blob among the hot, cool tiers as usage patterns change, without having to move data between accounts. All tier changes happen immediately . The time of the last blob tier change is exposed via the **Access Tier Change Time** blob property. You may overwrite a blob in hot and cool, and in this case, the new blob inherits the tier of the old blob that was overwritten.

Blobs in both storage tiers can co-exist within the same account. Any blob that does not have an explicitly assigned tier infers the tier from the account access tier setting. If the access tier is inferred from the account, you see the **Access Tier Inferred** blob property set to “true”, and the blob **Access Tier** blob property matches the account tier. In the Azure portal, the access tier inferred property is displayed with the blob access tier (for example, Hot (inferred) or Cool (inferred)).


### Blob-level tiering billing

When a blob is moved to a cooler tier (hot->cool), the operation is billed as a write of the destination tier, where the write operation (per 10,000) and data write (per GB) charges of the destination tier apply. If a blob is moved to a warmer tier (cool->hot), the operation is billed as a read from the source tier, where the read operation (per 10,000) and data retrieval (per GB) charges of the source tier apply.

If you toggle the account tier from hot to cool, there is no charge for this in Blob storage accounts. You will be charged for both read operations (per 10,000) and data retrieval (per GB) if you toggle your Blob storage from cool to hot. Early deletion charges for any blob moved out of the cool tier may apply as well.

## Comparison of the storage tiers

The following table shows a comparison of the hot, cool storage tiers.

| | **Hot storage tier** | **Cool storage tier** |
| ---- | ----- | ----- |
| **Availability** | 99.9% | 99% |
| **Availability** <br> **(RA-GRS reads)**| 99.99% | 99.9% |
| **Usage charges** | Higher storage costs, lower access and transaction costs | Lower storage costs, higher access and transaction costs |
| **Minimum object size** | N/A | N/A |
| **Minimum storage duration** | N/A | 30 days (GPv2 only) |
| **Latency** <br> **(Time to first byte)** | milliseconds | milliseconds |
| **Scalability and performance targets** | Same as general-purpose storage accounts | Same as general-purpose storage accounts |

> [!NOTE]
> Blob Storage accounts support the same performance and scalability targets as general-purpose storage accounts. See [Azure Storage Scalability and Performance Targets](../common/storage-scalability-targets.md?toc=%2fstorage%2fblobs%2ftoc.json) for more information.

## Quickstart scenarios

In this section, the following scenarios are demonstrated using the Azure portal:

* How to change the default account access tier of a Blob storage account.
* How to change the tier of a blob in a Blob storage account.

### Change the default account access tier of a Blob storage account

1. Sign in to the [Azure portal](https://portal.azure.cn).

2. To navigate to your storage account, select All Resources, then select your storage account.

3. In the Settings blade, click **Configuration** to view and/or change the account configuration.

4. Select the right storage tier for your needs: Set the **Access tier** to either **Cool** or **Hot**.

5. Click Save at the top of the blade.

### Change the tier of a blob in a Blob Storage account.

1. Sign in to the [Azure portal](https://portal.azure.cn).

2. To navigate to your blob in your storage account, select All Resources, select your storage account, select your container, and then select your blob.

3. In the Blob properties blade, click the **Access tier** dropdown menu to select the **Hot**, **Cool** storage tier.

5. Click Save at the top of the blade.

## FAQ


**Can I store objects in all two (hot, cool) storage tiers in the same account?**

Yes. The **Access Tier** attribute set at the account level is the default tier that applies to all objects in that account without an explicit set tier. However, blob-level tiering allows you to set the access tier on at the object level regardless of what the access tier setting on the account is. Blobs in any of the two storage tiers (hot, cool) may exist within the same account.

**Can I change the default storage tier of my Blob storage account?**

Yes, you can change the default storage tier by setting the **Access tier** attribute on the storage account. Changing the storage tier applies to all objects stored in the account that do not have an explicit tier set. Toggling from cool to hot incurs both read operations (per 10,000) and data retrieval (per GB) charges for all blobs in Blob storage accounts.


**In which regions are the hot, cool storage tiers available in?**

The hot and cool storage tiers along with blob-level tiering are available in all regions. 

**Do the blobs in the cool storage tier behave differently than the ones in the hot storage tier?**

Blobs in the hot storage tier have the same latency as blobs in GPv1 and Blob storage accounts. Blobs in the cool storage tier have a similar latency (in milliseconds) as blobs in GPv1 and Blob storage accounts. 

Blobs in the cool storage tier have a slightly lower availability service level (SLA) than the blobs stored in the hot storage tier. For more details, see [SLA for storage](https://www.azure.cn/zh-cn/support/sla/storage/).

**Are the operations among the hot, cool tiers the same?**

Yes. All operations between hot and cool are 100% consistent. 

**After setting the tier of a blob, when will I start getting billed at the appropriate rate?**

Each blob is always billed according to the tier indicated by **Access Tier** blob property. When setting a new tier on a blob, the **Access Tier** property will immediately reflect the new tier for all transitions. 

**Which Azure tools and SDKs support blob-level tiering?**

Azure portal, PowerShell, and CLI tools and .NET, Java, Python, and Node.js client libraries all support blob-level tiering.  

**How much data can I store in the hot, cool tiers?**

Data storage along with other limits are set at the account level and not per storage tier. Therefore, you can chose to use all of your limit in one tier or across both two tiers. See [Azure Storage Scalability and Performance Targets](../common/storage-scalability-targets.md?toc=%2fstorage%2fblobs%2ftoc.json) for more information.

## Next steps

### Evaluate hot, cool in Blob Storage accounts

[Check availability of hot, cool by region](https://www.azure.cn/zh-cn/support/service-dashboard/)

[Evaluate usage of your current storage accounts by enabling Azure Storage metrics](../common/storage-enable-and-view-metrics.md?toc=%2fstorage%2fblobs%2ftoc.json)

[Check hot, cool pricing in Blob Storage accounts by region](https://www.azure.cn/pricing/details/storage/)

[Check data transfers pricing](https://www.azure.cn/pricing/details/data-transfer/)

