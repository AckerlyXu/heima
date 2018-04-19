---
title: Create an Azure Function that connects to an Azure Storage | Microsoft Docs
description: Azure CLI Script Sample - Create an Azure Function that connects to an Azure Storage
services: functions
documentationcenter: functions
author: ggailey777
manager: cfowler
editor: 
tags: functions
ms.assetid: 
ms.service: functions
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: na
ms.workload: 
origin.date: 04/20/2017
ms.date: 04/19/2018
ms.author: v-junlch
ms.custom: mvc
---
# Create a function app that connects to an Azure Storage account

This Azure Functions sample script creates a function app and connects the function to an Azure Storage account. The created app setting that contains the connection can be used with a [[storage trigger or binding](..\functions-bindings-storage-blob.md). 

[!INCLUDE [upgrade runtime](../../../includes/functions-cli-version-note.md)]

If you don't have an Azure subscription, create a [trial account](https://www.azure.cn/pricing/1rmb-trial) before you begin.

If you use the CLI locally, make sure that you are running the Azure CLI version 2.0 or later. To find the version, run `az --version`. If you need to install or upgrade, see [Install Azure CLI 2.0](/cli/install-azure-cli). 

## Sample script

This sample creates an Azure Function app and adds the storage connection string to an app setting.

```azurecli
#!/bin/bash

# create a resource group with location
az group create `
  --name myResourceGroup `
  --location chinanorth

# create a storage account 
az storage account create `
  --name myfuncstore `
  --location chinanorth `
  --resource-group myResourceGroup `
  --sku Standard_LRS

# Create an App Service plan
az appservice plan create `
  --name myappserviceplan `
  --resource-group myResourceGroup `
  --location chinanorth

# create a new function app, assign it to the resource group you have just created
az functionapp create `
  --name myfuncstorage  `
  --resource-group myResourceGroup `
  --storage-account myfuncstore `
  --plan myappserviceplan

# Retreive the Storage Account connection string 
$connstr=az storage account show-connection-string --name myfuncstore --resource-group myResourceGroup --query connectionString --output tsv

# update function app settings to connect to storage account
az functionapp config appsettings set `
  --name myfuncstorage `
  --resource-group myResourceGroup `
  --settings StorageConStr=$connstr
```


## Clean up deployment

After the script sample has been run, run the following command to remove the resource group and all related resources:

[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az login](/cli/reference-index#az_login) | Log in to Azure. |
| [az group create](/cli/group#az_group_create) | Create a resource group with location |
| [az storage account create](/cli/storage/account) | Create a storage account |
| [az functionapp create](https://docs.microsoft.com/cli/azure/functionapp#az_functionapp_create) | Create a new function app |
| [az group delete](/cli/group#az_group_delete) | Clean up |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](/cli/overview?view=azure-cli-latest).

Additional Azure Functions CLI script samples can be found in the [Azure Functions documentation](../functions-cli-samples.md).

