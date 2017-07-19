---
title: Azure CLI Script-Create a failover policy for high availability | Azure
description: Azure CLI Script Sample - Create a failover policy for high availability 
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
ms.date: 07/17/2017
ms.author: v-yeche
---

# Create a failover policy for high availability using the Azure CLI

This sample CLI script creates an Azure Cosmos DB account, and then configures it for high availability.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]
<!-- Not Available [!INCLUDE [cloud-shell-try-it.md](../../../includes/cloud-shell-try-it.md)] -->

## Sample script

```azurecli-interactive
#!/bin/bash

# Set variables for the new account, database, and collection
resourceGroupName='myResourceGroup'
location='southcentralus'
name='docdb-test'
databaseName='docdb-test-database'
collectionName='docdb-test-collection'

# Create a resource group
az group create \
    --name $resourceGroupName \
    --location $location

# Create a DocumentDB API Cosmos DB account
az cosmosdb create \
    --name $name \
    --kind GlobalDocumentDB \
    --resource-group $resourceGroupName \
    --max-interval 10 \
    --max-staleness-prefix 200 

# Update failover configuration
az cosmosdb update \
    --name $name \
    --resource-group $resourceGroupName \
    --locations "South Central US"=0 "North Central US"=1 "East US"=2 "West US"=3
```

## Clean up deployment

After the script sample has been run, the following command can be used to remove the resource group and all resources associated with it.

```azurecli-interactive
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.microsoft.com/zh-cn/cli/azure/group#create) | Creates a resource group in which all resources are stored. |
| [az cosmosdb create](https://docs.microsoft.com/zh-cn/cli/azure/sql/server#create) | Creates an Azure Cosmos DB account. |
| [az cosmosdb update](https://docs.microsoft.com/zh-cn/cli/azure/cosmosdb#update) | Updates Azure Cosmos DB account. |
| [az group delete](https://docs.microsoft.com/zh-cn/cli/azure/resource#delete) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/zh-cn/cli/azure/overview).

Additional Azure Cosmos DB CLI script samples can be found in the [Azure Cosmos DB CLI documentation](../cli-samples.md).