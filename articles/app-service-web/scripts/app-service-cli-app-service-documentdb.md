---
title: Azure CLI Script Sample - Connect a web app to documentdb | Azure
description: Azure CLI Script Sample - Connect a web app to documentdb
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
origin.date: 03/20/2017
ms.date: 04/24/2017
ms.author: v-dazen
ms.custom: mvc
---

# Connect a web app to documentdb

In this scenario you will learn how to create an Azure documentdb account and an Azure web app. Then you will link the documentdb to the web app using app settings.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurecli-interactive
#/bin/bash

# Variables
appName="webappwithcosmosdb$random"
storageName="webappwithcosmosdb$random"
location="ChinaNorth"

# Create a Resource Group 
az group create --name myResourceGroup --location $location

# Create an App Service Plan
az appservice plan create --name WebAppWithCosmosDBPlan --resource-group myResourceGroup --location $location

# Create a Web App
az webapp create --name $appName --plan WebAppWithCosmosDBPlan --resource-group myResourceGroup 

# Create a documentdb
cosmosdb=$(az cosmosdb create --name $appName --resource-group myResourceGroup --query documentEndpoint --output tsv)
cosmosCreds=$(az cosmosdb list-keys --name $appName --resource-group myResourceGroup --query primaryMasterKey --output tsv)

# Assign the connection string to an App Setting in the Web App
az webapp config appsettings set --settings "COSMOSDB_URL=$cosmosdb" "COSMOSDB_KEY=$cosmosCreds" --name $appName --resource-group myResourceGroup
```

[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation

This script uses the following commands to create a resource group, web app, documentdb and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.microsoft.com/cli/azure/group#create) | Creates a resource group in which all resources are stored. |
| [az appservice plan create](https://docs.microsoft.com/cli/azure/appservice/plan#create) | Creates an App Service plan. This is like a server farm for your Azure web app. |
| [az appservice web create](https://docs.microsoft.com/cli/azure/webapp#create) | Creates an Azure web app within the App Service plan. |
| [az cosmosdb create](https://docs.microsoft.com/cli/azure/cosmosdb#create) | Creates a documentdb account. This is where the data will be stored. |
| [az cosmosdb list-keys](https://docs.microsoft.com/cli/azure/cosmosdb#list-keys) | Lists the access keys for the specified documentdb account. |
| [az appservice web config appsettings update](https://docs.microsoft.com/cli/azure/webapp/config/appsettings#update) | Creates or updates an app setting for an Azure web app. App settings are exposed as environment variables for your app. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional App Service CLI script samples can be found in the [Azure App Service documentation](../app-service-cli-samples.md).
