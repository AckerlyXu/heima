---
title: Azure Quickstart - Create a storage account using the Azure CLI | Microsoft Docs
description: Quickly learn to create a new storage account using the Azure CLI.
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
ms.devlang: na
ms.topic: quickstart
origin.date: 06/28/2017
ms.date: 10/23/2017
ms.author: v-johch
---

# Create a storage account using the Azure CLI

The Azure CLI is used to create and manage Azure resources from the command line or in scripts. This Quickstart details using the Azure CLI to create an Azure Storage account.

If you don't have an Azure subscription, create a [1rmb account](https://www.azure.cn/pricing/1rmb-trial/?WT.mc_id=A261C142F) before you begin.

This quickstart requires that you are running the Azure CLI version 2.0.4 or later. Run `az --version` to find the version. If you need to install or upgrade, see [Install Azure CLI 2.0](https://docs.azure.cn/cli/install-azure-cli). 

## Create resource group

Create an Azure resource group with the [az group create](https://docs.azure.cn/cli/group#create) command. A resource group is a logical container into which Azure resources are deployed and managed. This example creates a resource group named *myResourceGroup* in the *chinaeast* region.

```azurecli
az group create \
    --name myResourceGroup \
    --location chinaeast
```

If you're unsure which region to specify for the `--location` parameter, you can retrieve a list of supported regions for your subscription with the [az account list-locations](https://docs.azure.cn/cli/account#list) command.

```azurecli
az account list-locations \
    --query "[].{Region:name}" \
    --out table
```

## Create a general-purpose standard storage account

There are several types of storage accounts appropriate for different usage scenarios, each of which supports one or more of the storage services (blobs, files, tables, or queues). The following table details the available storage account types.

|**Type of storage account**|**General-purpose Standard**|**General-purpose Premium**|**Blob storage, hot and cool access tiers**|
|-----|-----|-----|-----|
|**Services supported**| Blob, File, Table, Queue services | Blob service | Blob service|
|**Types of blobs supported**|Block blobs, page blobs, append blobs | Page blobs | Block blobs and append blobs|

Create a general-purpose standard storage account with the [az storage account create](https://docs.azure.cn/cli/storage/account#create) command.

```azurecli
az storage account create \
    --name mystorageaccount \
    --resource-group myResourceGroup \
    --location chinaeast \
    --sku Standard_LRS \
    --encryption blob
```

## Clean up resources

If you no longer need any of the resources in your resource group, including the storage account you created in this Quickstart, delete the resource group with the [az group delete](https://docs.azure.cn/cli/group#delete) command.

```azurecli
az group delete --name myResourceGroup
```

## Next steps

In this Quickstart, you created a resource group and a general-purpose standard storage account. To learn how to transfer data to and from your storage account, continue to the Blob storage Quickstart.

> [!div class="nextstepaction"]
> [Transfer objects to and from Azure Blob storage using the Azure CLI](../blobs/storage-quickstart-blobs-cli.md)