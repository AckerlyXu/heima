---
title: Azure CLI Script Sample - Create a web app and deploy files with FTP | Microsoft Docs
description: Azure CLI Script Sample - Create a web app and deploy files with FTP
services: app-service\web
documentationcenter: 
author: cephalin
manager: cfowler
editor: 
tags: azure-service-management

ms.service: app-service-web
ms.workload: web
ms.devlang: azurecli
ms.tgt_pltfrm: sample
ms.topic: sample
origin.date: 12/12/2017
ms.date: 01/02/2018
ms.author: v-yiso
ms.custom: mvc
---
# Create a web app and deploy files with FTP

This sample script creates a web app in App Service with its related resources, and then deploys a static HTML page using FTP. For FTP upload, the script uses [cURL](https://en.wikipedia.org/wiki/CURL) as an example. You can use whatever FTP tool to upload your files.

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]


If you choose to install and use the CLI locally, you need Azure CLI version 2.0 or later. To find the version, run `az --version`. If you need to install or upgrade, see [Install Azure CLI 2.0](https://docs.azure.cn/zh-cn/cli/install-azure-cli?view=azure-cli-lastest).

## Sample script

```azurecli
#!/bin/bash

# Replace the following URL with a public GitHub repo URL
warurl=https://raw.githubusercontent.com/Azure-Samples/html-docs-hello-world/master/index.html
webappname=mywebapp$RANDOM

# Download sample static HTML page
curl $warurl --output index.html

# Create a resource group.
az group create --location chinanorth --name myResourceGroup

# Create an App Service plan in `FREE` tier.
az appservice plan create --name myAppServicePlan --resource-group myResourceGroup --sku FREE

# Create a web app.
az webapp create --name $webappname --resource-group myResourceGroup --plan myAppServicePlan

# Get FTP publishing profile and query for publish URL and credentials
creds=($(az webapp deployment list-publishing-profiles --name $webappname --resource-group myResourceGroup \
--query "[?contains(publishMethod, 'FTP')].[publishUrl,userName,userPWD]" --output tsv))

# Use cURL to perform FTP upload. You can use any FTP tool to do this instead. 
curl -T index.html -u ${creds[1]}:${creds[2]} ${creds[0]}/

# Copy the result of the following command into a browser to see the static HTML site.
echo http://$webappname.chinacloudsites.cn
```

[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation 

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [`az group create`](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az_group_create) | Creates a resource group in which all resources are stored. |
| [`az appservice plan create`](https://docs.azure.cn/zh-cn/cli/appservice/plan?view=azure-cli-latest#az_appservice_plan_create) | Creates an App Service plan. |
| [`az webapp create`](https://docs.azure.cn/zh-cn/cli/webapp?view=azure-cli-latest#az_webapp_create) | Creates an Azure web app. |
| [`az webapp deployment list-publishing-profiles`](https://docs.azure.cn/zh-cn/cli/webapp/deployment?view=azure-cli-latest#az_webapp_deployment_list_publishing_profiles) | Get the details for available web app deployment profiles. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-lastest).

Additional App Service CLI script samples can be found in the [Azure App Service documentation](../app-service-cli-samples.md).
