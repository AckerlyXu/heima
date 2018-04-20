---
title: Azure CLI Script-Create a firewall for Azure Cosmos DB | Azure
description: Azure CLI Script Sample - Create a firewall for Azure Cosmos DB
services: cosmos-db
documentationcenter: cosmosdb
author: rockboyfor
manager: digimobile
tags: azure-service-management

ms.assetid:
ms.service: cosmos-db
ms.custom: sammvcple
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: cosmosdb
ms.workload: database
origin.date: 06/02/2017
ms.date: 04/23/2018
ms.author: v-yeche
---

# Azure Cosmos DB: Create a firewall using the Azure CLI

This sample CLI script creates a firewall policy for any kind of Azure Cosmos DB account. 

[!INCLUDE [azure-cli-2-azurechinacloud-environment-parameter](../../../includes/azure-cli-2-azurechinacloud-environment-parameter.md)]

If you choose to install and use the CLI locally, this topic requires that you are running the Azure CLI version 2.0 or later. Run `az --version` to find the version. If you need to install or upgrade, see [Install Azure CLI 2.0](https://docs.azure.cn/zh-cn/cli/install-azure-cli?view=azure-cli-latest). 

## Sample script

```azurecli
#!/bin/bash

# Set variables for the new account, database, and collection
resourceGroupName='myResourceGroup'
location='chinaeast'
name='docdb-test'
databaseName='docdb-test-database'
collectionName='docdb-test-collection'
ipRangeFilter="13.91.6.132,13.91.6.1/24"

# Create a resource group
az group create \
    --name $resourceGroupName \
    --location $location

# Create a DocumentDB API Cosmos DB account
az cosmosdb create \
    --name $name \
    --kind GlobalDocumentDB \
    --locations "China East"=0 "China North"=1 \
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
    --resource-group $resourceGroupName

# Configure the firewall
az cosmosdb update \
    --name $name \
    --resource-group $resourceGroupName \
    --ip-range-filter $ipRangeFilter

```

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
| [az cosmosdb create](https://docs.azure.cn/zh-cn/cli/cosmosdb?view=azure-cli-latest#az_cosmosdb_create) | Creates an Azure CosmosDB account. |
| [az cosmosdb update](https://docs.azure.cn/zh-cn/cli/cosmosdb?view=azure-cli-latest#az_cosmosdb_update) | Updates an Azure CosmosDB account to include firewall settings. |
| [az group delete](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az_group_delete) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-latest).

Additional Azure Cosmos DB CLI script samples can be found in the [Azure Cosmos DB CLI documentation](../cli-samples.md).

<!--Update_Description: update link, wording update-->