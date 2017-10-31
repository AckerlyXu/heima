---
title: Azure CLI Script Sample - Delete containers by prefix | Microsoft Docs
description: Delete Azure Storage blob containers based on a container name prefix.
services: storage
documentationcenter: na
author: forester123
manager: digimobile
editor: tysonn

ms.assetid:
ms.custom: mvc
ms.service: storage
ms.workload: storage
ms.tgt_pltfrm: na
ms.devlang: azurecli
ms.topic: sample
origin.date: 06/22/2017
ms.date: 10/23/2017
ms.author: v-johch
---

# Delete containers based on container name prefix

This script first creates a few sample containers in Azure Blob storage, then deletes some of the containers based on a prefix in the container name.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurecli
#!/bin/bash
export AZURE_STORAGE_ACCOUNT=<storage-account-name>
export AZURE_STORAGE_ACCESS_KEY=<storage-account-key>

# Create a resource group
az group create --name myResourceGroup --location chinaeast

# Create some test containers
az storage container create --name test-container-001
az storage container create --name test-container-002
az storage container create --name production-container-001

# List only the containers with a specific prefix
az storage container list --prefix "test-" --query "[*].[name]" --output tsv

echo "Deleting test- containers..."

# Delete 
for container in `az storage container list --prefix "test-" --query "[*].[name]" --output tsv`; do
    az storage container delete --name $container
done

echo "Remaining containers:"
az storage container list --output table
```

## Clean up deployment 

Run the following command to remove the resource group, remaining containers, and all related resources.

```azurecli
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands to delete containers based on container name prefix. Each item in the table links to command-specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.azure.cn/cli/group#create) | Creates a resource group in which all resources are stored. |
| [az storage account create](https://docs.azure.cn/cli/storage/account#create) | Creates an Azure Storage account in the specified resource group. |
| [az storage container create](https://docs.azure.cn/cli/storage/container#create) | Creates a container in Azure Blob storage. |
| [az storage container list](https://docs.azure.cn/cli/storage/container#list) | Lists the containers in an Azure Storage account. |
| [az storage container delete](https://docs.azure.cn/cli/storage/container#delete) | Deletes containers in an Azure Storage account. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/cli/overview).

Additional storage CLI script samples can be found in the [Azure CLI samples for Azure Storage](../blobs/storage-samples-blobs-cli.md).
