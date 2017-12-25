---
title: Azure CLI Script Sample - Back up a web app | Microsoft Docs
description: Azure CLI Script Sample - Back up a web app
services: app-service\web
documentationcenter: 
author: cephalin
manager: cfowler
editor: 
tags: azure-service-management

ms.service: app-service-web
ms.workload: web
ms.devlang: na
ms.topic: sample
origin.date: 12/07/2017
ms.date: 01/02/2018
ms.author: v-yiso
ms.custom: mvc
---

# Back up a web app

This sample script creates a web app in App Service with its related resources, and then creates a one-time backup for it. 

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]



If you choose to install and use the CLI locally, you need Azure CLI version 2.0 or later. To find the version, run `az --version`. If you need to install or upgrade, see [Install Azure CLI 2.0](https://docs.azure.cn/zh-cn/cli/install-azure-cli?view=azure-cli-lastest).

## Sample script

```azurecli
#!/bin/bash

groupname="myResourceGroup"
planname="myAppServicePlan"
webappname=mywebapp$RANDOM
storagename=mywebappstorage$RANDOM
location="ChinaEast"
container="appbackup"
backupname="backup1"
expirydate=$(date -I -d "$(date) + 1 month")

# Create a Resource Group 
az group create --name $groupname --location $location

# Create a Storage Account
az storage account create --name $storagename --resource-group $groupname --location $location \
--sku Standard_LRS

# Create a storage container
az storage container create --account-name $storagename --name $container

# Generates an SAS token for the storage container, valid for one month.
# NOTE: You can use the same SAS token to make backups in App Service until --expiry
sastoken=$(az storage container generate-sas --account-name $storagename --name $container \
--expiry $expirydate --permissions rwdl --output tsv)

# Construct the SAS URL for the container
sasurl=https://$storagename.blob.core.chinacloudapi.cn/$container?$sastoken

# Create an App Service plan in Standard tier. Standard tier allows one backup per day.
az appservice plan create --name $planname --resource-group $groupname --location $location \
--sku S1

# Create a web app
az webapp create --name $webappname --plan $planname --resource-group $groupname

# Create a one-time backup
az webapp config backup create --resource-group $groupname --webapp-name $webappname \
--backup-name $backupname --container-url $sasurl

# List statuses of all backups that are complete or currently executing.
az webapp config backup list --resource-group $groupname --webapp-name $webappname
```

[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [`az group create`](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az_group_create) | Creates a resource group in which all resources are stored. |
| [`az storage account create`](https://docs.azure.cn/zh-cn/cli/storage/account?view=azure-cli-latest#az_storage_account_create) | Creates a storage account. |
| [`az storage container create`](https://docs.azure.cn/zh-cn/cli/storage/container?view=azure-cli-latest#az_storage_container_create) | Creates an Azure storage container. |
| [`az storage container generate-sas`](https://docs.azure.cn/zh-cn/cli/storage/container?view=azure-cli-latest#az_storage_container_generate_sas) | Generates an SAS token for an Azure storage container.  |
| [`az appservice plan create`](https://docs.azure.cn/zh-cn/cli/appservice/plan?view=azure-cli-latest#az_appservice_plan_create) | Creates an App Service plan. |
| [`az webapp create`](https://docs.azure.cn/zh-cn/cli/webapp?view=azure-cli-latest#az_webapp_create) | Creates an Azure web app. |
| [`az webapp config backup create`](https://docs.azure.cn/zh-cn/cli/webapp/config/backup?view=azure-cli-latest#az_webapp_config_backup_create) | Creates a backup for a web app. |
| [`az webapp config backup list`](https://docs.azure.cn/zh-cn/cli/webapp/config/backup?view=azure-cli-latest#az_webapp_config_backup_list) | Gets a list of backups for a web app. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-lastest).

Additional App Service CLI script samples can be found in the [Azure App Service documentation](../app-service-cli-samples.md).
