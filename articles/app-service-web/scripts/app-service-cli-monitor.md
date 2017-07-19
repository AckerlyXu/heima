---
title: Azure CLI Script Sample - Monitor a web app with web server logs | Azure
description: Azure CLI Script Sample - Monitor a web app with web server logs
services: appservice
documentationcenter: appservice
author: syntaxc4
manager: erikre
editor: 
tags: azure-service-management

ms.assetid: 0887656f-611c-4627-8247-b5cded7cef60
ms.service: app-service
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: na
ms.workload: web
origin.date: 06/19/2017
ms.date: 07/24/2017
ms.author: v-dazen
ms.custom: mvc
---

# Monitor a web app with web server logs

In this scenario you will create a resource group, app service plan, web app and configure the web app to enable web server logs. You will then download the log files for review.

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

If you choose to install and use the CLI locally, this topic requires that you are running the Azure CLI version 2.0 or later. Run `az --version` to find the version. If you need to install or upgrade, see [Install Azure CLI 2.0](https://docs.microsoft.com/cli/azure/install-azure-cli). 

[!INCLUDE [azure-cli-2-azurechinacloud-environment-parameter](../../../includes/azure-cli-2-azurechinacloud-environment-parameter.md)]

## Sample script

```azurecli
#/bin/bash

# Variables
appName="AppServiceMonitor$random"
location="ChinaNorth"

# Create a Resource Group
az group create --name myResourceGroup --location $location

# Create an App Service Plan
az appservice plan create --name AppServiceMonitorPlan --resource-group myResourceGroup --location $location

# Create a Web App and save the URL
url=$(az webapp create --name $appName --plan AppServiceMonitorPlan --resource-group myResourceGroup --query defaultHostName | sed -e 's/^"//' -e 's/"$//')

# Enable all logging options for the Web App
az webapp log config --name $appName --resource-group myResourceGroup --application-logging true --detailed-error-messages true --failed-request-tracing true --web-server-logging filesystem

# Create a Web Server Log
curl -s -L $url/404

# Download the log files for review
az webapp log download --name $webappname --resource-group myResourceGroup
```

[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation

This script uses the following commands to create a resource group, web app, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.microsoft.com/cli/azure/group#create) | Creates a resource group in which all resources are stored. |
| [az appservice plan create](https://docs.microsoft.com/cli/azure/appservice/plan#create) | Creates an App Service plan. This is like a server farm for your Azure web app. |
| [az webapp create](https://docs.microsoft.com/cli/azure/webapp#create) | Creates an Azure web app. |
| [az webapp log config](https://docs.microsoft.com/cli/azure/webapp/log#config) | Configures which logs an Azure web app will persist. |
| [az webapp log download](https://docs.microsoft.com/cli/azure/webapp/log#download) | Downloads the logs of the an Azure web app to your local machine. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional App Service CLI script samples can be found in the [Azure App Service documentation](../app-service-cli-samples.md).
