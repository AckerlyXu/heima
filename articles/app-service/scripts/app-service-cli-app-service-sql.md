---
title: Azure CLI Script Sample - Connect a web app to a SQL database | Azure
description: Azure CLI Script Sample - Connect a web app to a SQL database
services: appservice
documentationcenter: appservice
author: syntaxc4
manager: erikre
editor: 
tags: azure-service-management

ms.assetid: 7c2efdd0-f553-4038-a77a-e953021b3f77
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

# Connect a web app to a SQL database

This sample script creates an Azure SQL database and an Azure web app. It then links the SQL database to the web app using app settings.

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

If you choose to install and use the CLI locally, you need Azure CLI version 2.0 or later. To find the version, run `az --version`. If you need to install or upgrade, see [Install Azure CLI 2.0](https://docs.azure.cn/zh-cn/cli/install-azure-cli?view=azure-cli-lastest).

[!INCLUDE [azure-cli-2-azurechinacloud-environment-parameter](../../../includes/azure-cli-2-azurechinacloud-environment-parameter.md)]

## Sample script

```azurecli
#/bin/bash

# Variables
appName="webappwithSQL$RANDOM"
serverName="webappwithsql$RANDOM"
location="ChinaNorth"
startip="0.0.0.0"
endip="0.0.0.0"
username="<replace-with-username>"
sqlServerPassword="<replace-with-password>"

# Create a resource group 
az group create --name myResourceGroup --location $location

# Create an App Service Plan
az appservice plan create --name myAppServicePlan --resource-group myResourceGroup --location $location

# Create a Web App
az webapp create --name $appName --plan myAppServicePlan --resource-group myResourceGroup

# Create a SQL Database server
az sql server create --name $serverName --resource-group myResourceGroup --location $location --admin-user $username --admin-password $sqlServerPassword

# Configure firewall for Azure access
az sql server firewall-rule create --server $serverName --resource-group myResourceGroup \
--name AllowYourIp --start-ip-address $startip --end-ip-address $endip

# Create a database called 'MySampleDatabase' on server
az sql db create --server $serverName --resource-group myResourceGroup --name MySampleDatabase \
--service-objective S0

# Get connection string for the database
connstring=$(az sql db show-connection-string --name MySampleDatabase --server $serverName \
--client ado.net --output tsv)

# Add credentials to connection string
connstring=${connstring//<username>/$username}
connstring=${connstring//<password>/$sqlServerPassword}

# Assign the connection string to an app setting in the web app
az webapp config appsettings set --name $appName --resource-group myResourceGroup \
--settings "SQLSRV_CONNSTR=$connstring" 
```

[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation

This script uses the following commands to create a resource group, web app, SQL Database, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [`az group create`](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az_group_create) | Creates a resource group in which all resources are stored. |
| [`az appservice plan create`](https://docs.azure.cn/zh-cn/cli/appservice/plan?view=azure-cli-latest#az_appservice_plan_create) | Creates an App Service plan. |
| [`az webapp create`](https://docs.azure.cn/zh-cn/cli/webapp?view=azure-cli-latest#az_webapp_create) | Creates an Azure web app. |
| [`az sql server create`](https://docs.azure.cn/zh-cn/cli/sql/server?view=azure-cli-latest#az_sql_server_create) | Creates a SQL Database Server.  |
| [`az sql db create`](https://docs.azure.cn/zh-cn/cli/sql/db?view=azure-cli-latest#az_sql_db_create) | Creates a new database with the SQL Database Server. |
| [`az sql db show-connection-string`](https://docs.azure.cn/zh-cn/cli/sql/db?view=azure-cli-latest#az_sql_db_show_connection_string) | Generates a connection string to a database. |
| [`az webapp config appsettings set`](https://docs.azure.cn/zh-cn/cli/webapp/config/appsettings?view=azure-cli-latest#az_webapp_config_appsettings_set) | Creates or updates an app setting for an Azure web app. App settings are exposed as environment variables for your app. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-lastest).

Additional App Service CLI script samples can be found in the [Azure App Service documentation](../app-service-cli-samples.md).

<!--Update_Description: add a note about Azure CLI 2.0 version-->