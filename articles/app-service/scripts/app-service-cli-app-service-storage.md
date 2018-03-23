---
title: Azure CLI Script Sample - Connect a web app to a storage account | Azure
description: Azure CLI Script Sample - Connect a web app to a storage account
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
ms.date: 04/02/2018
ms.author: v-yiso
ms.custom: mvc
---

# Connect a web app to a storage account

This sample script creates an Azure storage account and an Azure web app. It then links the storage account to the web app using app settings.

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

If you choose to install and use the CLI locally, you need Azure CLI version 2.0 or later. To find the version, run `az --version`. If you need to install or upgrade, see [Install Azure CLI 2.0](https://docs.azure.cn/zh-cn/cli/install-azure-cli?view=azure-cli-lastest).

[!INCLUDE [azure-cli-2-azurechinacloud-environment-parameter](../../../includes/azure-cli-2-azurechinacloud-environment-parameter.md)]

## Sample script

```azurecli
#/bin/bash

# Variables
appName="webappwithstorage$random"
storageName="webappstorage$random"
location="ChinaNorth"

# Create a Resource Group 
az group create --name myResourceGroup --location $location

# Create an App Service Plan
az appservice plan create --name myAppServicePlan --resource-group myResourceGroup --location $location

# Create a Web App
az webapp create --name $appName --plan myAppServicePlan --resource-group myResourceGroup 

# Create a Storage Account
az storage account create --name $storageName --resource-group myResourceGroup --location $location --sku Standard_LRS

# Retreive the Storage Account connection string 
connstr=$(az storage account show-connection-string --name $storageName --resource-group myResourceGroup --query connectionString --output tsv)

# Assign the connection string to an App Setting in the Web App
az webapp config appsettings set --name $appName --resource-group myResourceGroup \
--settings "STORAGE_CONNSTR=$connstr"
```

[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation

This script uses the following commands to create a resource group, web app, storage account, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [`az group create`](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az_group_create) | Creates a resource group in which all resources are stored. |
| [`az appservice plan create`](https://docs.azure.cn/zh-cn/cli/appservice/plan?view=azure-cli-latest#az_appservice_plan_create) | Creates an App Service plan. |
| [`az webapp create`](https://docs.azure.cn/zh-cn/cli/webapp?view=azure-cli-latest#az_webapp_create) | Creates an Azure web app. |
| [`az storage account create`](https://docs.azure.cn/zh-cn/cli/storage/account?view=azure-cli-latest#az_storage_account_create) | Creates a storage account. |
| [`az storage account show-connection-string`](https://docs.azure.cn/zh-cn/cli/storage/account?view=azure-cli-latest#az_storage_account_show_connection_string) | Get the connection string for a storage account. |
| [`az webapp config appsettings set`](https://docs.azure.cn/zh-cn/cli/webapp/config/appsettings?view=azure-cli-latest#az_webapp_config_appsettings_set) | Creates or updates an app setting for an Azure web app. App settings are exposed as environment variables for your app. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-lastest).

Additional App Service CLI script samples can be found in the [Azure App Service documentation](../app-service-cli-samples.md).

<!--Update_Description: add a note about Azure CLI 2.0 version-->