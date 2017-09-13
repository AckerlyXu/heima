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
ms.date: 09/18/2017
ms.author: v-yeche
---

# Scale Azure Cosmos DB container throughput using the Azure CLI

This sample scales container throughput for any kind of Azure Cosmos DB container.  

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]
<!-- Not Available [!INCLUDE [cloud-shell-try-it.md](../../../includes/cloud-shell-try-it.md)] -->

This topic requires that you are running the Azure CLI version 2.0 or later. Run `az --version` to find the version. If you need to install or upgrade, see [Install Azure CLI 2.0](https://docs.microsoft.com/cli/azure/install-azure-cli). 

## Sample script

```azurecli
#!/bin/bash

# Set variables for the new account, database, and collection
resourceGroupName='myResourceGroup'
location='chinaeast'
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
| [az cosmosdb update](https://docs.microsoft.com/cli/azure/cosmosdb#update) | Updates an Azure Cosmos DB account. |
| [az group delete](https://docs.microsoft.com/cli/azure/group#delete) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional Azure Cosmos DB CLI script samples can be found in the [Azure Cosmos DB CLI documentation](../cli-samples.md).

<!--Update_Description: update link, wording update-->