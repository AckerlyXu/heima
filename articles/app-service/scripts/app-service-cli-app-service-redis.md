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
ms.date: 04/02/2018/
ms.author: v-yiso
ms.custom: mvc
---

# Connect a web app to a redis cache

This sample script creates an Azure redis cache and an Azure web app. It then links the redis cache to the web app using app settings.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

If you choose to install and use the CLI locally, you need Azure CLI version 2.0 or later. To find the version, run `az --version`. If you need to install or upgrade, see [Install Azure CLI 2.0]( /cli/install-azure-cli).
## Sample script

```azurecli
#/bin/bash

# Variables
appName="webappwithredis$RANDOM"
location="chinanorth"

# Create a Resource Group 
az group create --name myResourceGroup --location $location

# Create an App Service Plan
az appservice plan create --name myAppServicePlan --resource-group myResourceGroup --location $location

# Create a Web App
az webapp create --name $appName --plan myAppServicePlan --resource-group myResourceGroup 

# Create a Redis Cache
redis=($(az redis create --name $appName --resource-group myResourceGroup \
--location $location --vm-size C0 --sku Basic --query [hostName,sslPort] --output tsv))

# Get access key
key=$(az redis list-keys --name $appName --resource-group myResourceGroup \
--query primaryKey --output tsv)

# Assign the connection string to an App Setting in the Web App
az webapp config appsettings set --name $appName --resource-group myResourceGroup \
 --settings "REDIS_URL=${redis[0]}" "REDIS_PORT=${redis[1]}" "REDIS_KEY=$key"
``` 
 
[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation

This script uses the following commands to create a resource group, web app, redis cache, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.azure.cn/zh-cn/cli/group#az_group_create) | Creates a resource group in which all resources are stored. |
| [`az appservice plan create`](/cli/appservice/plan?view=azure-cli-latest#az_appservice_plan_create) | Creates an App Service plan. |
| [az webapp create](https://docs.azure.cn/zh-cn/cli/webapp#az_webapp_create) | Creates an Azure web app. |
| [`az redis create`](/cli/redis?view=azure-cli-latest#az_redis_create) | Create new Redis Cache instance. |
| [`az redis list-keys`](/cli/redis?view=azure-cli-latest#az_redis_list_keys) | Lists the access keys for the redis cache instance. |
| [az webapp config appsettings set](https://docs.azure.cn/zh-cn/cli/webapp/config/appsettings#az_webapp_config_appsettings_set) | Creates or updates an app setting for an Azure web app. App settings are exposed as environment variables for your app. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-lastest).

Additional App Service CLI script samples can be found in the [Azure App Service documentation](../app-service-cli-samples.md).

<!--Update_Description: replace "az appservice web" with "az webapp"-->