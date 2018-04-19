---
title: Create an Azure Function that connects to an Azure Cosmos DB | Microsoft Docs
description: Azure CLI Script Sample - Create an Azure Function that connects to an Azure Cosmos DB
services: functions
documentationcenter: functions
author: ggailey777
manager: cfowler
editor: 
tags: functions
ms.assetid: 
ms.service: functions
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: na
ms.workload: 
origin.date: 01/22/2018
ms.date: 04/19/2018
ms.author: v-junlch
ms.custom: mvc
---
# Create an Azure Function that connects to an Azure Cosmos DB

This Azure Functions sample script creates a function app and connects the function to an Azure Cosmos DB database. The created app setting that contains the connection can be used with an [Azure Cosmos DB trigger or binding](../functions-bindings-cosmosdb.md).

If you don't have an Azure subscription, create a [trial account](https://www.azure.cn/pricing/1rmb-trial) before you begin.

If you use the CLI locally, make sure that you are running the Azure CLI version 2.0 or later. To find the version, run `az --version`. If you need to install or upgrade, see [Install Azure CLI 2.0](/cli/install-azure-cli). 

## Sample script

This sample creates an Azure Function app and adds a Cosmos DB endpoint and access key to app settings.

```azurecli
#!/bin/bash

# create a resource group with location
az group create `
  --name myResourceGroup `
  --location chinanorth

# create a storage account 
az storage account create `
  --name funccosmosdbstore `
  --location chinanorth `
  --resource-group myResourceGroup `
  --sku Standard_LRS

# create an app service plan
az appservice plan create `
  --name myappserviceplan `
  --resource-group myResourceGroup `
  --location chinanorth

# create a new function app, assign it to the resource group you have just created
az functionapp create `
  --name myfunccosmosdb `
  --resource-group myResourceGroup `
  --storage-account funccosmosdbstore `
  --plan myappserviceplan

# create cosmosdb database, name must be lowercase.
az cosmosdb create `
  --name myfunccosmosdb `
  --resource-group myResourceGroup

# Retrieve cosmosdb connection string
$endpoint=az cosmosdb show --name myfunccosmosdb --resource-group myResourceGroup --query documentEndpoint --output tsv

$key=az cosmosdb list-keys --name myfunccosmosdb --resource-group myResourceGroup --query primaryMasterKey --output tsv

# configure function app settings to use cosmosdb connection string
az functionapp config appsettings set `
  --name myfunccosmosdb `
  --resource-group myResourceGroup `
  --setting CosmosDB_Endpoint=$endpoint CosmosDB_Key=$key
```

[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation

This script uses the following commands: Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az login](/cli/reference-index#az_login) | Log in to Azure. |
| [az group create](/cli/group#az_group_create) | Create a resource group with location |
| [az storage accounts create](/cli/storage/account) | Create a storage account |
| [az functionapp create](https://docs.microsoft.com/cli/azure/functionapp#az_functionapp_create) | Create a new function app |
| [az cosmosdb create](/cli/cosmosdb#az_cosmosdb_create) | Create cosmosdb database |
| [az group delete](/cli/group#az_group_delete) | Clean up |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](/cli/overview?view=azure-cli-latest).

Additional Azure Functions CLI script samples can be found in the [Azure Functions documentation](../functions-cli-samples.md).





