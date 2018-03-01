---
title: Azure CLI Script Sample - Create an Azure Redis Cache | Microsoft Docs
description: Azure CLI Script Sample - Create an Azure Redis Cache
services: redis-cache
documentationcenter: ''
author: wesmc7777
manager: cfowler
editor: 
tags: azure-service-management

ms.assetid: afd7f6e0-9297-4c98-a95e-597be939cef7
ms.service: cache-redis
ms.devlang: azurecli
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: tbd
origin.date: 08/30/2017
ms.date: 03/01/2018
ms.author: v-junlch
---

# Create an Azure Redis Cache

In this scenario, you learn how to create an Azure Redis Cache.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

## Sample script

```azurecli
#/bin/bash

# Creates a Resource Group named contosoGroup, and creates a Redis Cache in that group named contosoCache

# Create a Resource Group 
az group create --name contosoGroup --location chinanorth

# Create a Basic C0 (256 MB) Redis Cache
az redis create --name contosoCache --resource-group contosoGroup --location chinanorth --sku Basic --vm-size C0
```

[!INCLUDE [cli-script-clean-up](../../../includes/redis-cli-script-clean-up.md)]

## Script explanation

This script uses the following commands to create a resource group and a redis cache. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](/cli/group#az_group_create) | Creates a resource group in which all resources are stored. |
| [az redis create](/cli/redis#az_redis_create) | Create Redis Cache instance. |


## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](/cli/overview).

Additional Azure Redis Cache CLI script samples can be found in the [Azure Redis Cache documentation](../cli-samples.md).

<!--Update_Description: code update-->
