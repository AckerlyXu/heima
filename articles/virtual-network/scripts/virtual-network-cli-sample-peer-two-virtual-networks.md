---
title: Azure CLI script sample - Peer two virtual networks | Azure
description: Azure CLI script sample - Peer two virtual networks.
services: virtual-network
documentationcenter: virtual-network
author: rockboyfor
manager: digimobile
editor: ''
tags:
ms.assetid:
ms.service: virtual-network
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm:
ms.workload: infrastructure
origin.date: 03/20/2018
origin.date: 05/07/2018
ms.date: 05/07/2018
ms.author: v-yeche
---

# Peer two virtual networks script sample

This script sample creates and connects two virtual networks in the same region through the Azure network. After running the script, you have a peering between two virtual networks.

You can execute the script from a local Azure CLI installation. If you use the CLI locally, this script requires that you are running version 2.0.28 or later. To find the installed version, run `az --version`. If you need to install or upgrade, see [Install Azure CLI 2.0](/zh-cn/cli/install-azure-cli?view=azure-cli-latest). If you are running the CLI locally, you also need to run `az login` to create a connection with Azure.
<!-- Not Available on [Cloud Shell](https://shell.azure.com/bash) -->

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurecli
#!/bin/bash

RgName="MyResourceGroup"
Location="chinaeast"

# Create a resource group.
az group create \
  --name $RgName \
  --location $Location

# Create virtual network 1.
az network vnet create \
  --name Vnet1 \
  --resource-group $RgName \
  --location $Location \
  --address-prefix 10.0.0.0/16

# Create virtual network 2.
az network vnet create \
  --name Vnet2 \
  --resource-group $RgName \
  --location $Location \
  --address-prefix 10.1.0.0/16

# Get the id for VNet1.
VNet1Id=$(az network vnet show \
  --resource-group $RgName \
  --name Vnet1 \
  --query id --out tsv)

# Get the id for VNet2.
VNet2Id=$(az network vnet show \
  --resource-group $RgName \
  --name Vnet2 \
  --query id \
  --out tsv)

# Peer VNet1 to VNet2.
az network vnet peering create \
  --name LinkVnet1ToVnet2 \
  --resource-group $RgName \
  --vnet-name VNet1 \
  --remote-vnet-id $VNet2Id \
  --allow-vnet-access

# Peer VNet2 to VNet1.
az network vnet peering create \
  --name LinkVnet2ToVnet1 \
  --resource-group $RgName \
  --vnet-name VNet2 \
  --remote-vnet-id $VNet1Id \
  --allow-vnet-access

```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources:

```azurecli
az group delete --name myResourceGroup --yes
```

## Script explanation

This script uses the following commands to create a resource group, virtual machine, and all related resources. Each command in the following table links to command-specific documentation:

| Command | Notes |
|---|---|
| [az group create](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az-group-create) | Creates a resource group in which all resources are stored. |
| [az network vnet create](https://docs.azure.cn/zh-cn/cli/network/vnet?view=azure-cli-latest#az-network-vnet-create) | Creates an Azure virtual network and subnet. |
| [az network vnet peering create](https://docs.azure.cn/zh-cn/cli/network/vnet/peering?view=azure-cli-latest#az-network-vnet-peering-create) | Creates a peering between two virtual networks.  |
| [az group delete](https://docs.azure.cn/zh-cn/cli/vm/extension?view=azure-cli-latest#az-vm-extension-set) | Deletes a resource group including all nested resources. |

## Next steps
For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-latest).
Additional virtual network CLI script samples can be found in [Virtual network CLI samples](../cli-samples.md).

<!-- Update_Description: new articles on virtual network cli sample peer two virtual networks script -->
<!--ms.date: 05/07/2018-->