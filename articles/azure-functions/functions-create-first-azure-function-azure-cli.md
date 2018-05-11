---
title: Create your first function from the Azure CLI | Microsoft Docs 
description: Learn how to create your first Azure Function for serverless execution using the Azure CLI.
services: functions 
keywords: 
author: ggailey777
ms.author: v-junlch
ms.assetid: 674a01a7-fd34-4775-8b69-893182742ae0
origin.date: 01/24/2018
ms.date: 04/10/2018
ms.topic: quickstart
ms.service: functions
ms.custom: mvc
ms.devlang: azure-cli
manager: cfowler
---

# Create your first function using the Azure CLI

This quickstart topic walks you through how to use Azure Functions to create your first function. You use the Azure CLI to create a function app, which is the [serverless](https://azure.microsoft.com/overview/serverless-computing/) infrastructure that hosts your function. The function code itself is deployed from a GitHub sample repository.    

You can follow the steps below using a Mac, Windows, or Linux computer. 

## Prerequisites 

Before running this sample, you must have the following:

+ An active [GitHub](https://github.com) account. 
+ An active Azure subscription.

If you don't have an Azure subscription, create a [trial account](https://www.azure.cn/pricing/1rmb-trial) before you begin.

If you choose to install and use the CLI locally, this topic requires the Azure CLI version 2.0 or later. Run `az --version` to find the version you have. If you need to install or upgrade, see [Install Azure CLI 2.0](/cli/install-azure-cli). 


[!INCLUDE [functions-create-resource-group](../../includes/functions-create-resource-group.md)]

[!INCLUDE [functions-create-storage-account](../../includes/functions-create-storage-account.md)]

## Create a function app

You must have a function app to host the execution of your functions. The function app provides an environment for serverless execution of your function code. It lets you group functions as a logic unit for easier management, deployment, and sharing of resources. Create a function app by using the [az functionapp create](https://docs.microsoft.com/en-us/cli/azure/functionapp?view=azure-cli-latest#az_functionapp_create) command. 

In the following command, substitute a unique function app name where you see the `<app_name>` placeholder and the storage account name for  `<storage_name>`. The `<app_name>` is used as the default DNS domain for the function app, and so the name needs to be unique across all apps in Azure. The _deployment-source-url_ parameter is a sample repository in GitHub that contains a "Hello World" HTTP triggered function.

```azurecli
az functionapp create --deployment-source-url https://github.com/Azure-Samples/functions-quickstart  `
--resource-group myResourceGroup --plan <App Service plan> chinanorth `
--name <app_name> --storage-account  <storage_name>  
```
In this plan, resources are added dynamically as required by your functions and you only pay when functions are running. For more information, see [Choose the correct hosting plan](functions-scale.md). 

After the function app has been created, the Azure CLI shows information similar to the following example:

```json
{
  "availabilityState": "Normal",
  "clientAffinityEnabled": true,
  "clientCertEnabled": false,
  "containerSize": 1536,
  "dailyMemoryTimeQuota": 0,
  "defaultHostName": "quickstart.chinacloudsites.cn",
  "enabled": true,
  "enabledHostNames": [
    "quickstart.chinacloudsites.cn",
    "quickstart.scm.chinacloudsites.cn"
  ],
   ....
    // Remaining output has been truncated for readability.
}
```

[!INCLUDE [functions-test-function-code](../../includes/functions-test-function-code.md)]

[!INCLUDE [functions-cleanup-resources](../../includes/functions-cleanup-resources.md)]

[!INCLUDE [functions-quickstart-next-steps-cli](../../includes/functions-quickstart-next-steps-cli.md)]

