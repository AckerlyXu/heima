---
title: Azure CLI Samples for Azure Cosmos DB | Azure
description: Azure CLI Samples - Create and manage Azure Cosmos DB accounts, databases, containers, regions, and firewalls. 
services: cosmos-db
author: rockboyfor
manager: digimobile
editor: 
tags: azure-service-management

ms.assetid:
ms.service: cosmos-db
ms.custom: mvc
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: na
ms.workload: database
origin.date: 11/29/2017
ms.date: 03/26/2018
ms.author: v-yeche
---

# Azure CLI samples for Azure Cosmos DB

[!INCLUDE [cosmos-db-sql-api](../../includes/cosmos-db-sql-api.md)] 

The following table includes links to sample Azure CLI scripts for Azure Cosmos DB. Reference pages for all Azure Cosmos DB CLI commands are available in the [Azure CLI 2.0 Reference](https://docs.azure.cn/zh-cn/cli/cosmosdb?view=azure-cli-latest).

| |  |
|---|---|
|**Create Azure Cosmos DB account, database, and containers**||
|[Create a SQL API account](scripts/create-database-account-collections-cli.md)| Creates a single Azure Cosmos DB API account, database, and container for use with the SQL API. |
| [Create a MongoDB API account](scripts/create-mongodb-database-account-cli.md) | Creates a single Azure Cosmos DB MongoDB API account, database, and collection. |
|**Scale Azure Cosmos DB**||
| [Scale container throughput](scripts/scale-collection-throughput-cli.md) | Changes the provisioned throughput on a container.|
|[Replicate Azure Cosmos DB database account in multiple regions and configure failover priorities](scripts/scale-multiregion-cli.md)|Multiple data-center replicates account data into multiple regions with a specified failover priority.|
|**Secure Azure Cosmos DB**||
| [Get account keys](scripts/secure-get-account-key-cli.md) | Gets the primary and secondary master write keys and primary and secondary read-only keys for the account.|
| [Get MongoDB connection string](scripts/secure-mongo-connection-string-cli.md) | Gets the connection string to connect your MongoDB app to your Azure Cosmos DB account.|
|[Regenerate account keys](scripts/secure-regenerate-key-cli.md)|Regenerates the master or read-only key for the account.|
|[Create a firewall](scripts/create-firewall-cli.md)| Creates an inbound IP access control policy to limit access to the account from an approved set of machines and/or cloud services.|
|**High availability, disaster recovery, backup and restore**||
|[Configure failover policy](scripts/ha-failover-policy-cli.md)|Sets the failover priority of each region in which the account is replicated.|
|**Connect Azure Cosmos DB to resources**||
|[Connect a web app to Azure Cosmos DB](../app-service/scripts/app-service-cli-app-service-documentdb.md)|Create and connect an Azure Cosmos DB database and an Azure web app.|
|||
<!--NOTICES: Line 35 全球范围 to 多个数据中心范围  -->
<!--NOTICE: Line 35 Globally TO Multiple data-center-->


<!--Update_Description: update meta properties, wording update, update link -->