---
title: Azure CLI Script-Regenerate Azure Cosmos DB account key | Azure
description: Azure CLI Script Sample - Regenerate an Azure Cosmos DB account key
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

# Regenerate an Azure Cosmos DB account key using the Azure CLI

This sample regenerates any kind of Azure Cosmos DB account key using the Azure CLI. 

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

## Sample script

```azurecli-interactive
#!/bin/bash

# Set variables for the new account, database, and collection
resourceGroupName='myResourceGroup'
location='southcentralus'
name='docdb-test'

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

# List account keys
az cosmosdb list-keys \
    --name $name \
    --resource-group $resourceGroupName 

# Regenerate an account key
az documentdb regenerate-key \
    --name $name \
    --resource-group $resourceGroupName \
    --key-kind secondary

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
| [az cosmosdb create](https://docs.microsoft.com/cli/azure/cosmosdb/name#create) | Updates an Azure Cosmos DB account. |
| [az cosmosdb regenerate-key](https://docs.microsoft.com/cli/azure/cosmosdb/regenerate-key) | Regeneratates Azure Cosmos DB account keys. |
| [az group delete](https://docs.microsoft.com/cli/azure/resource#delete) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional Azure Cosmos DB CLI script samples can be found in the [Azure Cosmos DB CLI documentation](../cli-samples.md).