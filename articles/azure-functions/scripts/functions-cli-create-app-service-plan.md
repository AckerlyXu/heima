---
title: Azure CLI Script Sample - Create a Function App in an App Service plan | Microsoft Docs
description: Azure CLI Script Sample - Create a Function App in an App Service plan
services: functions
documentationcenter: functions
author: syntaxc4
manager: cfowler
editor: 
tags: azure-service-management

ms.assetid: 0e221db6-ee2d-4e16-9bf6-a456cd05b6e7
ms.service: functions
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: na
ms.workload: web
origin.date: 10/22/2018
ms.date: 04/19/2018
ms.author: v-junlch
ms.custom: mvc
---
# Create a Function App in an App Service plan

This Azure Functions sample script creates a function app, which is a container for your functions. The function app that is created uses a dedicated App Service plan, which means your server resources are always on.

If you don't have an Azure subscription, create a [trial account](https://www.azure.cn/pricing/1rmb-trial) before you begin.

If you choose to install and use the CLI locally, this article requires the Azure CLI version 2.0 or later. Run `az --version` to find the version. If you need to install or upgrade, see [Install Azure CLI 2.0](/cli/install-azure-cli). 

## Sample script

This script creates an Azure Function app using a dedicated [App Service plan](../functions-scale.md#app-service-plan).

```azurecli
#!/bin/bash

# Create a resource resourceGroupName
az group create `
  --name myResourceGroup `
  --location chinanorth

# Create an azure storage account
az storage account create `
  --name myappsvcpstore `
  --location chinanorth `
  --resource-group myResourceGroup `
  --sku Standard_LRS

# Create an App Service plan
az appservice plan create `
  --name myappserviceplan `
  --resource-group myResourceGroup `
  --location chinanorth

# Create a Function App
az functionapp create `
  --name myappsvcpfunc `
  --storage-account myappsvcpstore `
  --plan myappserviceplan `
  --resource-group myResourceGroup
```

[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation

Each command in the table links to command specific documentation. This script uses the following commands:

| Command | Notes |
|---|---|
| [az group create](/cli/group#az_group_create) | Creates a resource group in which all resources are stored. |
| [az storage account create](/cli/storage/account#az_storage_account_create) | Creates an Azure Storage account. |
| [az appservice plan create](/cli/appservice/plan?view=azure-cli-latest) | Creates an App Service plan. |
| [az functionapp create](https://docs.microsoft.com/cli/azure/functionapp#az_functionapp_delete) | Creates an Azure Function app. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](/cli/overview?view=azure-cli-latest).

Additional Azure Functions CLI script samples can be found in the [Azure Functions documentation](../functions-cli-samples.md).

