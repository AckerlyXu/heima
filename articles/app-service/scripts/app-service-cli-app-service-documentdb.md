---
title: Azure CLI Script Sample - Connect a web app to MongoDB (Cosmos DB) | Microsoft Docs
description: Azure CLI Script Sample - Connect a web app to MongoDB (Cosmos DB)
services: appservice
documentationcenter: appservice
author: syntaxc4
manager: erikre
editor: 
tags: azure-service-management

ms.assetid: bbbdbc42-efb5-4b4f-8ba6-c03c9d16a7ea
ms.service: app-service
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: na
ms.workload: web
origin.date: 12/11/2017
ms.date: 04/02/2018
ms.author: v-yiso
ms.custom: mvc
---

# Connect a web app to Cosmos DB

This sample script creates an Azure Cosmos DB account with the MongoDB API and an Azure web app. It then links the MongoDB connection string to the web app using app settings.

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]



If you choose to install and use the CLI locally, you need Azure CLI version 2.0 or later. To find the version, run `az --version`. If you need to install or upgrade, see [Install Azure CLI 2.0](https://docs.azure.cn/zh-cn/cli/install-azure-cli?view=azure-cli-lastest).

[!INCLUDE [azure-cli-2-azurechinacloud-environment-parameter](../../../includes/azure-cli-2-azurechinacloud-environment-parameter.md)]


## Sample script

```azurecli
#/bin/bash

# Variables
appName="webappwithcosmosdb$RANDOM"
location="ChinaNorth"

# Create a Resource Group 
az group create --name myResourceGroup --location $location

# Create an App Service Plan
az appservice plan create --name myAppServicePlan --resource-group myResourceGroup --location $location
# Create a Web App
az webapp create --name $appName --plan myAppServicePlan --resource-group myResourceGroup 

# Create a Cosmos DB with MongoDB API
az cosmosdb create --name $appName --resource-group myResourceGroup --kind MongoDB

# Get the MongoDB URL
connectionString=$(az cosmosdb list-connection-strings --name $appName --resource-group myResourceGroup \
--query connectionStrings[0].connectionString --output tsv)

# Assign the connection string to an App Setting in the Web App
az webapp config appsettings set --name $appName --resource-group myResourceGroup \
--settings "MONGODB_URL=$connectionString" 
```

[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation

This script uses the following commands to create a resource group, web app, Cosmos DB, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [`az group create`](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az_group_create) | Creates a resource group in which all resources are stored. |
| [`az appservice plan create`](https://docs.azure.cn/zh-cn/cli/appservice/plan?view=azure-cli-latest#az_appservice_plan_create) | Creates an App Service plan. |
| [`az webapp create`](https://docs.azure.cn/zh-cn/cli/webapp?view=azure-cli-latest#az_webapp_create) | Creates an Azure web app. |
| [`az cosmosdb create`](https://docs.azure.cn/zh-cn/cli/cosmosdb?view=azure-cli-latest#az_cosmosdb_create) | Creates a Cosmos DB account. |
| [`az cosmosdb list-connection-strings`](https://docs.azure.cn/zh-cn/cli/cosmosdb?view=azure-cli-latest#az_cosmosdb_list_connection_strings) | Lists connection strings for the specified Cosmos DB account. |
| [`az webapp config appsettings set`](https://docs.azure.cn/zh-cn/cli/webapp/config/appsettings?view=azure-cli-latest#az_webapp_config_appsettings_set) | Creates or updates an app setting for an Azure web app. App settings are exposed as environment variables for your app. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-lastest).

Additional App Service CLI script samples can be found in the [Azure App Service documentation](../app-service-cli-samples.md).

<!--Update_Description: add a note about Azure CLI 2.0 version-->