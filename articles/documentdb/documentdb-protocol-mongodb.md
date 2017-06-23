---
title: 'Introduction to DocumentDB: API for MongoDB | Microsoft Docs'
description: Learn how you can use DocumentDB to store and query massive volumes of JSON documents with low latency using the popular OSS MongoDB APIs.
keywords: what is MongoDB
services: documentdb
author: AndrewHoh
manager: jhubbard
editor: ''
documentationcenter: ''

ms.assetid: 4afaf40d-c560-42e0-83b4-a64d94671f0a
ms.service: documentdb
ms.workload: data-services
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 05/05/2017
ms.date: 05/31/2017
ms.author: v-junlch

---
# Introduction to DocumentDB: API for MongoDB

[DocumentDB](./documentdb-resources.md) is Microsoft's globally distributed, multi-model database service for mission-critical applications. DocumentDB provides [turn-key global distribution](../documentdb/documentdb-distribute-data-globally.md), [elastic scaling of throughput and storage](../documentdb/documentdb-partition-data.md) worldwide, single-digit millisecond latencies at the 99th percentile, [five well-defined consistency levels](../documentdb/documentdb-consistency-levels.md), and guaranteed high availability, all backed by industry-leading SLAs. DocumentDB [automatically indexes data](http://www.vldb.org/pvldb/vol8/p1668-shukla.pdf) without requiring you to deal with schema and index management. It is multi-model and supports document, key-value, graph, and columnar data models. 

![Azure API for MongoDB](./media/documentdb-protocol-mongodb/documentdb-mongodb.png) 

DocumentDB databases can be used as the data store for apps written for [MongoDB](https://docs.mongodb.com/manual/introduction/). This means that by using existing [drivers](https://docs.mongodb.org/ecosystem/drivers/), your application written for MongoDB can now communicate with DocumentDB and use DocumentDB databases instead of MongoDB databases. In many cases, you can switch from using MongoDB to DocumenetDB by simply changing a connection string. Using this functionality, you can easily build and run MongoDB database applications in the Azure cloud with DocumentDB's global distribution and comprehensive industry leading SLAs, while continuing to use familiar skills and tools for MongoDB.


## What is the benefit of using DocumentDB for MongoDB applications?

- **Elastically scalable throughput and storage:** Easily scale up or scale down your MongoDB database to meet your application needs. Your data is stored on solid state disks (SSD) for low predictable latencies. DocumentDB supports MongoDB collections that can scale to virtually unlimited storage sizes and provisioned throughput. You can elastically scale DocumentDB with predictable performance seamlessly as your application grows. 

- **Multi-region replication:** DocumentDB transparently replicates your data to all regions you've associated with your MongoDB account, enabling you to develop applications that require global access to data while providing tradeoffs between consistency, availability and performance, all with corresponding guarantees. DocumentDB provides transparent regional failover with multi-homing APIs, and the ability to elastically scale throughput and storage across the globe. Learn more in [Distribute data globally](documentdb-distribute-data-globally.md).

**MongoDB compatibility**: You can use your existing MongoDB expertise, application code, and tooling. You can develop applications using MongoDB and deploy them to production using the fully managed globally distributed DocumentDB service.

**No server management**: You don't have to manage and scale your MongoDB databases. DocumentDB is a fully managed service, which means you do not have to manage any infrastructure or Virtual Machines yourself. DocumentDB is available in 30+ [Azure Regions](https://azure.microsoft.com/regions/services/).

- **Tunable consistency levels:** Select from five well defined consistency levels to achieve optimal trade-off between consistency and performance. For queries and read operations, DocumentDB offers five distinct consistency levels: strong, bounded-staleness, session, consistent prefix, and eventual. These granular, well-defined consistency levels allow you to make sound trade-offs between consistency, availability, and latency. Learn more in [Using consistency levels to maximize availability and performance](documentdb-consistency-levels.md).

- **Automatic indexing**: By default, DocumentDB automatically indexes all the properties within documents in your MongoDB database and does not expect or require any schema or creation of secondary indices.

**Enterprise grade** - DocumentDB supports multiple local replicas to deliver 99.99% availability and data protection in the face of local and regional failures. DocumentDB has enterprise grade [compliance certifications](https://www.microsoft.com/trustcenter) and security features. 

## How to get started

Create a DocumentDB account in the [Azure Portal](https://portal.azure.cn) and swap the MongoDB connection string to your new account. 

*And, that's it!*

For more detailed instructions, follow [create account](documentdb-create-account.md) and [connect to your account](documentdb-connect-mongodb-account.md).

## Next steps

Information about DocumentDB's MongoDB API is integrated into the overall DocumentDB documentation, but here are a few pointers to get you started:

- Follow the [Connect to a MongoDB account](documentdb-connect-mongodb-account.md) tutorial to learn how to get your account connection string information.
- Follow the [Use MongoChef with DocumentDB](documentdb-mongodb-mongochef.md) tutorial to learn how to create a connection between your DocumentDB database and MongoDB app in MongoChef.
- Follow the [Migrate data to DocumentDB with protocol support for MongoDB](documentdb-mongodb-migrate.md) tutorial to import your data to an API for MongoDB database.
- Build your first API for MongoDB app using [Node.js](documentdb-mongodb-samples.md).
- Build your first API for MongoDB web app using .[NET](documentdb-mongodb-application.md).
- Connect to an API for MongoDB account using [Robomongo](documentdb-mongodb-robomongo.md).
- Learn how many RUs your operations are using with the [GetLastRequestStatistics command and the Azure portal metrics](documentdb-request-units.md#GetLastRequestStatistics).


