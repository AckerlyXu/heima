---
title: Azure CLI Script-Get account keys for Azure Cosmos DB | Azure
description: Azure CLI Script Sample - Get account keys for Azure Cosmos DB
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
ms.date: 08/07/2017
ms.author: v-yeche
---

# Get account keys for Azure Cosmos DB using the Azure CLI

This sample gets account keys for any kind of Azure Cosmos DB account.  

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]
<!-- Not Available [!INCLUDE [cloud-shell-try-it.md](../../../includes/cloud-shell-try-it.md)] -->

This topic requires that you are running the Azure CLI version 2.0 or later. Run `az --version` to find the version. If you need to install or upgrade, see [Install Azure CLI 2.0]( /cli/azure/install-azure-cli). 

## Sample script

```azurecli-interactive
#!/bin/bash

# Set variables for the new account, database, and collection
resourceGroupName='myResourceGroup'
location='chinaeast'
name='docdb-test'

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

# List account keys
az cosmosdb list-keys \
    --name $name \
    --resource-group $resourceGroupName 
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
| [az group create](https://docs.microsoft.com/cli/azure/group#create) | Creates a resource group in which all resources are stored. |
| [az cosmosdb update](https://docs.microsoft.com/cli/azure/cosmosdb#update) | Updates an Azure Cosmos DB account. |
| [az cosmosdb list-keys](https://docs.microsoft.com/cli/azure/sql/server#create) | Creates a logical server that hosts the SQL Database. |
| [az group delete](https://docs.microsoft.com/cli/azure/resource#delete) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional Azure Cosmos DB CLI script samples can be found in the [Azure Cosmos DB CLI documentation](../cli-samples.md).

<!--Update_Description: update link, wording update-->