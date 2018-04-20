---
title: Azure Cosmos DB as a key value store - Cost overview | Azure
description: Learn about the low cost of using Azure Cosmos DB as a key value store.
keywords: key value store
services: cosmos-db
author: rockboyfor
manager: digimobile
tags: ''
documentationcenter: ''

ms.assetid: 7f765c17-8549-4509-9475-46394fc3a218
ms.service: cosmos-db
ms.workload: data-services
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 11/15/2017
ms.date: 04/23/2018
ms.author: v-yeche
---

# Azure Cosmos DB as a key value store - Cost overview

Azure Cosmos DB is a multiple-region distributed, multi-model database service for building highly available, large-scale applications easily. By default, Azure Cosmos DB automatically indexes all the data it ingests, efficiently. This enables fast and consistent [SQL](sql-api-sql-query.md) (and [JavaScript](programming.md)) queries on any kind of data. 
<!-- Notice: 全球 to 多个区域 -->

This article describes the cost of Azure Cosmos DB for simple write and read operations when it's used as a key/value store. Write operations include inserts, replaces, deletes, and upserts of documents. Besides guaranteeing a 99.99% availability SLA for all single region accounts and all multi-region accounts with relaxed consistency, and 99.999% read availability on all multi-region database accounts, Azure Cosmos DB offers guaranteed <10-ms latency for reads and <15-ms latency for the (indexed) writes respectively, at the 99th percentile. 

## Why we use Request Units (RUs)

Azure Cosmos DB performance is based on the amount of provisioned [Request Units](request-units.md) (RU) for the partition. The provisioning is at a second granularity and is purchased in RUs/sec ([not to be confused with the hourly billing](https://www.azure.cn/pricing/details/cosmos-db/)). RUs should be considered as a currency that simplifies the provisioning of required throughput for the application. Our customers do not have to think of differentiating between read and write capacity units. The single currency model of RUs creates efficiencies to share the provisioned capacity between reads and writes. This provisioned capacity model enables the service to provide a predictable and consistent throughput, guaranteed low latency, and high availability. Finally, we use RU to model throughput, but each provisioned RU also has a defined amount of resources (Memory, Core). RU/sec is not only IOPS.

As a multiple-region distributed database system, Cosmos DB is the only Azure service that provides an SLA on latency, throughput, and consistency in addition to high availability. The throughput you provision is applied to each of the regions associated with your Cosmos DB database account. For reads, Cosmos DB offers multiple, well-defined [consistency levels](consistency-levels.md) for you to choose from. 
<!-- Notice: 全球 to 多个区域 -->

The following table shows the number of RUs required to perform read and write transactions based on document size of 1 KB and 100 KBs.

|Item Size|1 Read|1 Write|
|-------------|------|-------|
|1 KB|1 RU|5 RUs|
|100 KB|10 RUs|50 RUs|

<!-- Not Available ## Cost of reads and writes -->

## Next steps

Stay tuned for new articles on optimizing Azure Cosmos DB resource provisioning. In the meantime, feel free to use our [RU calculator](https://www.documentdb.com/capacityplanner).

<!--Update_Description: update meta properties, wording update-->