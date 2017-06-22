---
title: Azure CLI Script Sample - Create a web app with deployment from GitHub | Azure
description: Azure CLI Script Sample - Create a web app with deployment from GitHub
services: app-service\web
documentationcenter: 
author: cephalin
manager: erikre
editor: 
tags: azure-service-management

ms.assetid: 0205c991-0989-4ca3-bb41-237dcc964460
ms.service: app-service-web
ms.workload: web
ms.devlang: azurecli
ms.tgt_pltfrm: sample
ms.topic: article
origin.date: 03/20/2017
ms.date: 04/24/2017
ms.author: v-dazen
ms.custom: mvc
---
# Create a web app with deployment from GitHub

This sample script creates a web app in App Service with its related resources, and then deploys your web app code from a public GitHub repository (without continuous deployment). For GitHub deployment with continuous deployment, see [Create a web app with continuous deployment from GitHub](../app-service-continuous-deployment.md).

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## sample script

```azurecli-interactive
#!/bin/bash

# Replace the following URL with a public GitHub repo URL
gitrepo=https://github.com/Azure-Samples/php-docs-hello-world
webappname=mywebapp$RANDOM

# Create a resource group.
az group create --location chinanorth --name myResourceGroup

# Create an App Service plan in `FREE` tier.
az appservice plan create --name $webappname --resource-group myResourceGroup --sku FREE

# Create a web app.
az webapp create --name $webappname --resource-group myResourceGroup --plan $webappname

# Deploy code from a public GitHub repository. 
az webapp deployment source config --name $webappname --resource-group myResourceGroup \
--repo-url $gitrepo --branch master --manual-integration

# Browse to the web app.
az webapp browse --name $webappname --resource-group myResourceGroup

```

[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.microsoft.com/cli/azure/group#create) | Creates a resource group in which all resources are stored. |
| [az appservice plan create](https://docs.microsoft.com/cli/azure/appservice/plan#create) | Creates an App Service plan. |
| [az appservice web create](https://docs.microsoft.com/cli/azure/webapp#delete) | Creates an Azure web app. |
| [az appservice web source-control config](https://docs.microsoft.com/cli/azure/webapp/source-control#config) | Associates an Azure web app with a Git or Mercurial repository. |
| [az appservice web browse](https://docs.microsoft.com/cli/azure/webapp#browse) | Open an Azure web app in a browser. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional App Service CLI script samples can be found in the [Azure App Service documentation](../app-service-cli-samples.md).
