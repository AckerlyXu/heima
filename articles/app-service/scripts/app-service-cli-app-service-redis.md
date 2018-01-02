---
title: Azure CLI Script Sample - Connect a web app to a redis cache | Azure
description: Azure CLI Script Sample - Connect a web app to a redis cache
services: appservice
documentationcenter: appservice
author: syntaxc4
manager: erikre
editor: 
tags: azure-service-management

ms.assetid: bc8345b2-8487-40c6-a91f-77414e8688e6
ms.service: app-service
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: na
ms.workload: web
origin.date: 12/11/2017
ms.date: 01/02/2018/2017
ms.author: v-yiso
ms.custom: mvc
---

# Connect a web app to a redis cache

This sample script creates an Azure redis cache and an Azure web app. It then links the redis cache to the web app using app settings.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurecli
#/bin/bash

# Variables
resourceGroupName="myResourceGroup$RANDOM"
appName="webappwithredis$RANDOM"
storageName="webappredis$RANDOM"
location="chinanorth"

# Create a Resource Group 
az group create --name $resourceGroupName --location $location

# Create an App Service Plan
az appservice plan create --name WebAppWithRedisPlan --resource-group $resourceGroupName --location $location

# Create a Web App
az webapp create --name $appName --plan WebAppWithRedisPlan --resource-group $resourceGroupName 

# Create a Redis Cache
redis=($(az redis create --name $appName --resource-group $resourceGroupName --location $location --sku-capacity 0 --sku-family C --sku-name Basic --query [hostName,sslPort,accessKeys.primaryKey] --output tsv))

# Assign the connection string to an App Setting in the Web App
az webapp config appsettings set --settings "REDIS_URL=${redis[0]}" "REDIS_PORT=${redis[1]}" "REDIS_KEY=${redis[2]}" --name $appName --resource-group $resourceGroupName
```

[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation

This script uses the following commands to create a resource group, web app, redis cache, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.azure.cn/zh-cn/cli/group#az_group_create) | Creates a resource group in which all resources are stored. |
| [az appservice plan create](https://docs.azure.cn/zh-cn/cli/appservice/plan#az_appservice_plan_create) | Creates an App Service plan. This is like a server farm for your Azure web app. |
| [az webapp create](https://docs.azure.cn/zh-cn/cli/webapp#az_webapp_create) | Creates an Azure web app. |
| [az redis create](https://docs.microsoft.com/en-us/cli/azure/redis#az_redis_create) | Create new Redis Cache instance. This is where the data will be stored. |
| [az redis list-keys](https://docs.microsoft.com/en-us/cli/azure/redis#az_redis_list_keys) | Lists the access keys for the redis cache instance. |
| [az webapp config appsettings set](https://docs.azure.cn/zh-cn/cli/webapp/config/appsettings#az_webapp_config_appsettings_set) | Creates or updates an app setting for an Azure web app. App settings are exposed as environment variables for your app. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-lastest).

Additional App Service CLI script samples can be found in the [Azure App Service documentation](../app-service-cli-samples.md).

<!--Update_Description: replace "az appservice web" with "az webapp"-->