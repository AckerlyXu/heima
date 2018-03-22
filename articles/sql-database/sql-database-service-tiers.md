---
title: 'Azure SQL Database service | Microsoft Docs'
description: Learn about service tiers for single and pool databases to provide performance levels and storage sizes.  
keywords: 
services: sql-database
documentationcenter: ''
author: forester123
manager: digimobile
editor: ''

ms.assetid: f5c5c596-cd1e-451f-92a7-b70d4916e974
ms.service: sql-database
ms.custom: DBs & servers
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: data-management
origin.date: 02/26/2018
ms.date: 02/28/2018
ms.author: v-johch

---
# What are Azure SQL Database service tiers?

[Azure SQL Database](sql-database-technical-overview.md) offers **Basic**, **Standard**, and **Premium** service tiers for both [single databases](sql-database-single-database-resources.md) and [elastic pools](sql-database-elastic-pool.md). Service tiers are primarily differentiated by a range of performance level and storage size choices, and price.  All service tiers provide flexibility in changing performance level and storage size.  Single databases and elastic pools are billed hourly based on service tier, performance level, and storage size.   

## Choosing a service tier

Choosing a service tier depends primarily on business continuity, storage, and performance requirements.
| | **Basic** | **Standard** |**Premium**  |
| :-- | --: |--:| --:| --:| 
|Target workload|Development and production|Development and production|Development and production||
|Uptime SLA|99.99%|99.99%|99.99%|N/A while in preview|
|Backup retention|7 days|35 days|35 days|
|CPU|Low|Low, Medium, High|Medium, High|
|IO throughput (approximate) |2.5 IOPS per DTU	| 2.5 IOPS per DTU | 48 IOPS per DTU|
|IO latency (approximate)|5 ms (read), 10 ms (write)|5 ms (read), 10 ms (write)|2 ms (read/write)|
|Columnstore indexing and in-memory OLTP|N/A|N/A|Supported|
|||||

## Performance level and storage size limits

Performance levels are expressed in terms of Database Transaction Units (DTUs) for single databases and elastic Database Transaction Units (eDTUs) for elastic pools. For more on DTUs and eDTUs, see [What are DTUs and eDTUs?](sql-database-what-is-a-dtu.md)

### Single databases

|  | **Basic** | **Standard** | **Premium** | 
| :-- | --: | --: | --: | --: |
| Maximum storage size* | 2 GB | 1 TB | 4 TB  | 
| Maximum DTUs | 5 | 3000 | 4000 | |
||||||

### Elastic pools

| | **Basic** | **Standard** | **Premium** | 
| :-- | --: | --: | --: | --: |
| Maximum storage size per database*  | 2 GB | 1 TB | 1 TB | 
| Maximum storage size per pool* | 156 GB | 4 TB | 4 TB | 
| Maximum eDTUs per database | 5 | 3000 | 4000 | 
| Maximum eDTUs per pool | 1600 | 3000 | 4000 | 
| Maximum number of databases per pool | 500  | 500 | 100 | 
||||||


For details on specific performance levels and storage size choices available, see [SQL Database resource limits](sql-database-resource-limits.md).


## Next steps

- Learn about [Single database resources](sql-database-single-database-resources.md).
- Learn about elastic pools, see [Elastic pools](sql-database-elastic-pool.md).
* Learn more about [DTUs and eDTUs](sql-database-what-is-a-dtu.md).
* Learn about monitoring DTU usage, see [Monitoring and performance tuning](sql-database-troubleshoot-performance.md).

