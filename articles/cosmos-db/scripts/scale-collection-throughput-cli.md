---
title: Azure CLI Script-Scale Azure Cosmos DB container throughput | Azure
description: Azure CLI Script Sample - Scale Azure Cosmos DB contianer throughput
services: cosmos-db
documentationcenter: cosmosdb
author: rockboyfor
manager: digimobile
editor: ''
tags: azure-service-management

ms.assetid:
ms.service: cosmos-db
ms.custom: mvc
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: cosmosdb
ms.workload: database
origin.date: 06/02/2017
ms.date: 03/05/2018
ms.author: v-yeche
---

# Scale Azure Cosmos DB container throughput using the Azure CLI

This sample scales container throughput for any kind of Azure Cosmos DB container.  

[!INCLUDE [azure-cli-2-azurechinacloud-environment-parameter](../../../includes/azure-cli-2-azurechinacloud-environment-parameter.md)]

This topic requires that you are running the Azure CLI version 2.0 or later. Run `az --version` to find the version. If you need to install or upgrade, see [Install Azure CLI 2.0](https://docs.azure.cn/zh-cn/cli/install-azure-cli?view=azure-cli-latest). 

## Sample script

```azurecli
#!/bin/bash

# Set variables for the new account, database, and collection
resourceGroupName='myResourceGroup'
location='chinanorth'
name='docdb-test'
databaseName='docdb-test-database'
collectionName='docdb-test-collection'
originalThroughput=400 
newThroughput=700

# Create a resource group
az group create \
    --name $resourceGroupName \
    --location $location

# Create a DocumentDB API Cosmos DB account
az cosmosdb create \
    --name $name \
    --kind GlobalDocumentDB \
    --locations chinanorth=0 chinaeast=1 \
    --resource-group $resourceGroupName \
    --max-interval 10 \
    --max-staleness-prefix 200 

# Create a database 
az cosmosdb database create \
    --name $name \
    --db-name $databaseName \
    --resource-group $resourceGroupName

# Create a collection
az cosmosdb collection create \
    --collection-name $collectionName \
    --name $name \
    --db-name $databaseName \
    --resource-group $resourceGroupName \
    --throughput $originalThrougput

# Scale throughput
az cosmosdb collection update \
    --collection-name $collectionName \
    --name $name \
    --db-name $databaseName \
    --resource-group $resourceGroupName \
    --throughput $newThroughput

```
<!-- location ADVISE TO chinanorth -->
<!-- location MUST be the style of --locations chinanorth=0 chinaeast=1 -->
<!-- OR it will popup the index out of range error-->

## Clean up deployment

After the script sample has been run, the following command can be used to remove the resource group and all resources associated with it.

```azurecli
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az_group_create) | Creates a resource group in which all resources are stored. |
| [az cosmosdb update](https://docs.azure.cn/zh-cn/cli/cosmosdb?view=azure-cli-latest#az_cosmosdb_update) | Updates an Azure Cosmos DB account. |
| [az group delete](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az_group_delete) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-latest).

Additional Azure Cosmos DB CLI script samples can be found in the [Azure Cosmos DB CLI documentation](../cli-samples.md).

<!--Update_Description: update link, wording update-->