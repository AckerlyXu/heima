---
title: Azure CLI Script-Create a firewall for Azure Cosmos DB | Azure
description: Azure CLI Script Sample - Create a firewall for Azure Cosmos DB
services: cosmosdb
documentationcenter: cosmosdb
author: mimig1
manager: jhubbard
editor: ''
tags: azure-service-management

ms.assetid:
ms.service: cosmosdb
ms.custom: sample
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: cosmosdb
ms.workload: database
ms.date: 05/10/2017
wacn.date: ''
ms.author: mimig
---

# Azure Cosmos DB: Create a firewall using the Azure CLI

This sample CLI script creates a firewall policy for any kind of Azure Cosmos DB account. 

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

## Sample script

```azurecli-interactive
#!/bin/bash

# Set variables for the new account, database, and collection
resourceGroupName='myResourceGroup'
location='southcentralus'
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
    --locations "South Central US"=0 "North Central US"=1 \
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
| [az group create](https://docs.microsoft.com/cli/azure/group#create) | Creates a resource group in which all resources are stored. |
| [az cosmosdb create](https://docs.microsoft.com/cli/azure/cosmosdb/name#create) | Creates an Azure CosmosDB account. |
| [az cosmosdb update](https://docs.microsoft.com/cli/azure/sql/server#create) | Updates an Azure CosmosDB account to include firewall settings. |
| [az group delete](https://docs.microsoft.com/cli/azure/resource#delete) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional Azure Cosmos DB CLI script samples can be found in the [Azure Cosmos DB CLI documentation](../cli-samples.md).