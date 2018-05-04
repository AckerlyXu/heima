---
title: Azure CLI script sample - Create a network for multi-tier applications | Azure
description: Azure CLI script sample - Create a virtual network for multi-tier applications.
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

# Create a network for multi-tier applications script sample

This script sample creates a virtual network with front-end and back-end subnets. Traffic to the front-end subnet is limited to HTTP and SSH, while traffic to the back-end subnet is limited to MySQL, port 3306. After running the script, you have two virtual machines, one in each subnet, that you can deploy web server and MySQL software to.

You can execute the script from a local Azure CLI installation. If you use the CLI locally, this script requires that you are running version 2.0.28 or later. To find the installed version, run `az --version`. If you need to install or upgrade, see [Install Azure CLI 2.0](/zh-cn/cli/install-azure-cli?view=azure-cli-latest). If you are running the CLI locally, you also need to run `az login` to create a connection with Azure.
<!-- Not Avaialble on [Cloud Shell](https://shell.azure.com/bash)-->

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

# Create a virtual network with a front-end subnet.
az network vnet create \
  --name MyVnet \
  --resource-group $RgName \
  --location $Location \
  --address-prefix 10.0.0.0/16 \
  --subnet-name MySubnet-FrontEnd \
  --subnet-prefix 10.0.1.0/24

# Create a back-end subnet.
az network vnet subnet create \
  --address-prefix 10.0.2.0/24 \
  --name MySubnet-BackEnd \
  --resource-group $RgName \
  --vnet-name MyVnet

# Create a network security group for the front-end subnet.
az network nsg create \
  --resource-group $RgName \
  --name MyNsg-FrontEnd \
  --location $Location

# Create an NSG rule to allow HTTP traffic in from the Internet to the front-end subnet.
az network nsg rule create \
  --resource-group $RgName \
  --nsg-name MyNsg-FrontEnd \
  --name Allow-HTTP-All \
  --access Allow \
  --protocol Tcp \
  --direction Inbound \
  --priority 100 \
  --source-address-prefix Internet \
  --source-port-range "*" \
  --destination-address-prefix "*" \
  --destination-port-range 80

# Create an NSG rule to allow SSH traffic in from the Internet to the front-end subnet.
az network nsg rule create \
  --resource-group $RgName \
  --nsg-name MyNsg-FrontEnd \
  --name Allow-SSH-All \
  --access Allow \
  --protocol Tcp \
  --direction Inbound \
  --priority 300 \
  --source-address-prefix Internet \
  --source-port-range "*" \
  --destination-address-prefix "*" \
  --destination-port-range 22

# Associate the front-end NSG to the front-end subnet.
az network vnet subnet update \
  --vnet-name MyVnet \
  --name MySubnet-FrontEnd \
  --resource-group $RgName \
  --network-security-group MyNsg-FrontEnd

# Create a network security group for back-end subnet.
az network nsg create \
  --resource-group $RgName \
  --name MyNsg-BackEnd \
  --location $Location

# Create an NSG rule to allow MySQL traffic from the front-end subnet to the back-end subnet.
az network nsg rule create \
  --resource-group $RgName \
  --nsg-name MyNsg-BackEnd \
  --name Allow-MySql-FrontEnd \
  --access Allow --protocol Tcp \
  --direction Inbound \
  --priority 100 \
  --source-address-prefix 10.0.1.0/24 \
  --source-port-range "*" \
  --destination-address-prefix "*" \
  --destination-port-range 3306

# Create an NSG rule to allow SSH traffic from the Internet to the front-end subnet.
az network nsg rule create \
  --resource-group $RgName \
  --nsg-name MyNsg-BackEnd \
  --name Allow-SSH-All \
  --access Allow \
  --protocol Tcp \
  --direction Inbound \
  --priority 200 \
  --source-address-prefix Internet \
  --source-port-range "*" \
  --destination-address-prefix "*" \
  --destination-port-range 22

# Create an NSG rule to block all outbound traffic from the back-end subnet to the Internet (NOTE: If you run the MySQL installation below this rule will be disabled and then re-enabled).
az network nsg rule create \
  --resource-group $RgName \
  --nsg-name MyNsg-BackEnd \
  --name Deny-Internet-All \
  --access Deny --protocol Tcp \
  --direction Outbound --priority 300 \
  --source-address-prefix "*" \
  --source-port-range "*" \
  --destination-address-prefix "*" \
  --destination-port-range "*"

# Associate the back-end NSG to the back-end subnet.
az network vnet subnet update \
  --vnet-name MyVnet \
  --name MySubnet-BackEnd \
  --resource-group $RgName \
  --network-security-group MyNsg-BackEnd

# Create a public IP address for the web server VM.
az network public-ip create \
  --resource-group $RgName \
  --name MyPublicIP-Web

# Create a NIC for the web server VM.
az network nic create \
  --resource-group $RgName \
  --name MyNic-Web \
  --vnet-name MyVnet \
  --subnet MySubnet-FrontEnd \
  --network-security-group MyNsg-FrontEnd \
  --public-ip-address MyPublicIP-Web

# Create a Web Server VM in the front-end subnet.
az vm create \
  --resource-group $RgName \
  --name MyVm-Web \
  --nics MyNic-Web \
  --image UbuntuLTS \
  --admin-username azureadmin \
  --generate-ssh-keys

# Create a public IP address for the MySQL VM.
az network public-ip create \
  --resource-group $RgName \
  --name MyPublicIP-Sql

# Create a NIC for the MySQL VM.
az network nic create \
  --resource-group $RgName \
  --name MyNic-Sql \
  --vnet-name MyVnet \
  --subnet MySubnet-BackEnd \
  --network-security-group MyNsg-BackEnd \
  --public-ip-address MyPublicIP-Sql

# Create a MySQL VM in the back-end subnet.
az vm create \
  --resource-group $RgName \
  --name MyVm-Sql \
  --nics MyNic-Sql \
  --image UbuntuLTS \
  --admin-username azureadmin \
  --generate-ssh-keys

```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources:

```azurecli
az group delete --name MyResourceGroup --yes
```

## Script explanation

This script uses the following commands to create a resource group, virtual network, and network security groups. Each command in the following table links to command-specific documentation:

| Command | Notes |
|---|---|
| [az group create](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az-group-create) | Creates a resource group in which all resources are stored. |
| [az network vnet create](https://docs.azure.cn/zh-cn/cli/network/vnet?view=azure-cli-latest#az-network-vnet-create) | Creates an Azure virtual network and front-end subnet. |
| [az network subnet create](https://docs.azure.cn/zh-cn/cli/network/vnet/subnet?view=azure-cli-latest#az-network-vnet-subnet-create) | Creates a back-end subnet. |
| [az network public-ip create](https://docs.azure.cn/zh-cn/cli/network/public-ip?view=azure-cli-latest#az-network-public-ip-create) | Creates a public IP address to access the VM from the internet. |
| [az network nic create](https://docs.azure.cn/zh-cn/cli/network/nic?view=azure-cli-latest#az-network-nic-create) | Creates virtual network interfaces and attaches them to the virtual network's front-end and back-end subnets. |
| [az network nsg create](https://docs.azure.cn/zh-cn/cli/network/nsg?view=azure-cli-latest#az-network-nsg-create) | Creates network security groups (NSG) that are associated to the front-end and back-end subnets. |
| [az network nsg rule create](https://docs.azure.cn/zh-cn/cli/network/nsg/rule?view=azure-cli-latest#az-network-nsg-rule-create) |Creates NSG rules that allow or block specific ports to specific subnets. |
| [az vm create](https://docs.azure.cn/zh-cn/cli/vm?view=azure-cli-latest#az-vm-create) | Creates virtual machines and attaches a NIC to each VM. This command also specifies the virtual machine image to use and administrative credentials. |
| [az group delete](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az-group-delete) | Deletes a resource group and all resources it contains. |
## Next steps
For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-latest).
Additional virtual network CLI script samples can be found in [Virtual network CLI samples](../cli-samples.md).

<!-- Update_Description: new articles on virtual network cli sample multi tier application script -->
<!--ms.date: 05/07/2018-->