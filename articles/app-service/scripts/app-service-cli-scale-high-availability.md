---
title: Azure CLI Script Sample - Scale a web app worldwide with a high-availabilty architecture | Azure
description: Azure CLI Script Sample - Scale a web app worldwide with a high-availabilty architecture
services: appservice
documentationcenter: appservice
author: syntaxc4
manager: erikre
editor: 
tags: azure-service-management

ms.assetid: e4033a50-0e05-4505-8ce8-c876204b2acc
ms.service: app-service
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: na
ms.workload: web
origin.date: 12/11/2017
ms.date: 01/02/2018
ms.author: v-yiso
ms.custom: mvc
---

# Scale a web app worldwide with a high-availability architecture

This sample script creates a resource group, two app service plans, two web apps, a traffic manager profile, and two traffic manager endpoints. Once the exercise is complete, you have a high-available architecture, which provides global availability of your web app based on the lowest network latency.

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

If you choose to install and use the CLI locally, you need Azure CLI version 2.0 or later. To find the version, run `az --version`. If you need to install or upgrade, see [Install Azure CLI 2.0](https://docs.azure.cn/zh-cn/cli/install-azure-cli?view=azure-cli-lastest).

[!INCLUDE [azure-cli-2-azurechinacloud-environment-parameter](../../../includes/azure-cli-2-azurechinacloud-environment-parameter.md)]

## Sample script

```azurecli
#/bin/bash

# Variables
trafficManagerDnsName="myDnsName$random"
app1Name="AppServiceTM1$random"
app2Name="AppServiceTM2$random"
location1="ChinaNorth"
location2="ChinaEast"

# Create a Resource Group
az group create --name myResourceGroup --location $location1

# Create a Traffic Manager Profile
az network traffic-manager profile create --name $trafficManagerDnsName-tmp --resource-group myResourceGroup --routing-method Performance --unique-dns-name $trafficManagerDnsName

# Create App Service Plans in two Regions
az appservice plan create --name $app1Name-Plan --resource-group myResourceGroup --location $location1 --sku S1
az appservice plan create --name $app2Name-Plan --resource-group myResourceGroup --location $location2 --sku S1

# Add a Web App to each App Service Plan
site1=$(az webapp create --name $app1Name --plan $app1Name-Plan --resource-group myResourceGroup --query id --output tsv)
site2=$(az webapp create --name $app2Name --plan $app2Name-Plan --resource-group myResourceGroup --query id --output tsv)

# Assign each Web App as an Endpoint for high-availabilty
az network traffic-manager endpoint create -n $app1Name-$location1 --profile-name $trafficManagerDnsName-tmp -g myResourceGroup --type azureEndpoints --target-resource-id $site1
az network traffic-manager endpoint create -n $app2Name-$location2 --profile-name $trafficManagerDnsName-tmp -g myResourceGroup --type azureEndpoints --target-resource-id $site2
```

[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation

This script uses the following commands to create a resource group, web app, traffic manager profile, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [`az group create`](https://docs.azure.cn/cli/group?view=azure-cli-latest#az_group_create) | Creates a resource group in which all resources are stored. |
| [`az appservice plan create`](https://docs.azure.cn/zh-cn/cli/appservice/plan?view=azure-cli-latest#az_appservice_plan_create) | Creates an App Service plan. |
| [`az webapp create`](https://docs.azure.cn/zh-cn/cli/webapp?view=azure-cli-latest#az_webapp_create) | Creates an Azure web app. |
| [`az network traffic-manager profile create`](https://docs.azure.cn/zh-cn/cli/network/traffic-manager/profile?view=azure-cli-latest#az_network_traffic_manager_profile_create) | Creates an Azure Traffic Manager profile. |
| [`az network traffic-manager endpoint create`](https://docs.azure.cn/zh-cn/cli/network/traffic-manager/endpoint?view=azure-cli-latest#az_network_traffic_manager_endpoint_create) | Adds an endpoint to an Azure Traffic Manager Profile. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-lastest).

Additional App Service CLI script samples can be found in the [Azure App Service documentation](../app-service-cli-samples.md).

<!--Update_Description: add a note about Azure CLI 2.0 version-->