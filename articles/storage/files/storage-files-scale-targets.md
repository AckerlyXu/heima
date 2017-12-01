---
title: Azure Files scalability and performance targets | Microsoft Docs
description: Learn about the scalability and performance targets for Azure Files, including the capacity, request rate, and inbound and outbound bandwidth limits.
services: storage
documentationcenter: na
author: yunan2016
manager: digimobile
editor: tysonn
ms.service: storage
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: storage
origin.date: 10/17/2017
ms.date: 12/04/2017
ms.author: v-nany

---

# Azure Files scalability and performance targets
[Azure Files](storage-files-introduction.md) offers fully managed file shares in the cloud that are accessible via the industry standard SMB protocol. This article discusses the scalability and performance targets for Azure Files.

The scalability and performance targets listed here are high-end targets, but may be affected by other variables in your deployment. For example, the throughput for a file may also be limited by your available network bandwidth, not just the servers hosting the Azure Files service. We strongly recommend testing your usage pattern to determine whether the scalability and performance of Azure Files meet your requirements. We are also committed to increasing these limits over time. 

## Azure storage account scale targets
The parent resource for an Azure File share is an Azure storage account. A storage account represents a pool of storage in Azure that can be used by multiple storage services, including Azure Files, to store data. Other services that store data in storage accounts are Azure Blob storage, Azure Queue storage, and Azure Table storage. The following targets apply all storage services storing data in a storage account:

[!INCLUDE [azure-storage-limits](../../../includes/azure-storage-limits.md)]

[!INCLUDE [azure-storage-limits-azure-resource-manager](../../../includes/azure-storage-limits-azure-resource-manager.md)]

> [!Important]  
> Storage account utilization from other storage services affects your Azure File shares in your storage account. For example, if you reach the maximum storage account capacity with Azure Blob storage, you will not be able to create new files on your Azure File share, even if your Azure File share is below the maximum share size.

## Azure Files scale targets
[!INCLUDE [storage-files-scale-targets](../../../includes/storage-files-scale-targets.md)]


## See also
- [Planning for an Azure Files deployment](storage-files-planning.md)
- [Scalability and performance targets for other storage services](../common/storage-scalability-targets.md)