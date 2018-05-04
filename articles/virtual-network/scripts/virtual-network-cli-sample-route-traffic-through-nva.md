---
title: Azure CLI script sample - Route traffic through a network virtual appliance | Azure
description: Azure CLI script sample - Route traffic through a firewall network virtual appliance.
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

# Route traffic through a network virtual appliance script sample

This script sample creates a virtual network with front-end and back-end subnets. It also creates a VM with IP forwarding enabled to route traffic between the two subnets. After running the script you can deploy network software, such as a firewall application, to the VM.

You can execute the script from a local Azure CLI installation. If you use the CLI locally, this script requires that you are running version 2.0.28 or later. To find the installed version, run `az --version`. If you need to install or upgrade, see [Install Azure CLI 2.0](/zh-cn/cli/install-azure-cli?view=azure-cli-latest). If you are running the CLI locally, you also need to run `az login` to create a connection with Azure.
<!-- Not available on [Cloud Shell](https://shell.azure.com/bash) -->

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

# Create a network security group for the front-end subnet allowing HTTP and HTTPS inbound.
az network nsg create \
  --resource-group $RgName \
  --name MyNsg-FrontEnd \
  --location $Location

# Create NSG rules to allow HTTP & HTTPS traffic inbound.
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
az network nsg rule create \
  --resource-group $RgName \
  --nsg-name MyNsg-FrontEnd \
  --name Allow-HTTPS-All \
  --access Allow \
  --protocol Tcp \
  --direction Inbound \
  --priority 200 \
  --source-address-prefix Internet \
  --source-port-range "*" \
  --destination-address-prefix "*" \
  --destination-port-range 443

# Associate the front-end NSG to the front-end subnet.
az network vnet subnet update \
  --vnet-name MyVnet \
  --name MySubnet-FrontEnd \
  --resource-group $RgName \
  --network-security-group MyNsg-FrontEnd

# Create the back-end subnet.
az network vnet subnet create \
  --address-prefix 10.0.2.0/24 \
  --name MySubnet-BackEnd \
  --resource-group $RgName \
  --vnet-name MyVnet

#Create the DMZ subnet.
az network vnet subnet create \
  --address-prefix 10.0.0.0/24 \
  --name MySubnet-Dmz \
  --resource-group $RgName \
  --vnet-name MyVnet

# Create a public IP address for the firewall VM.
az network public-ip create \
  --resource-group $RgName \
  --name MyPublicIP-Firewall

# Create a NIC for the firewall VM and enable IP forwarding.
az network nic create \
  --resource-group $RgName \
  --name MyNic-Firewall \
  --vnet-name MyVnet \
  --subnet MySubnet-Dmz \
  --public-ip-address MyPublicIp-Firewall \
  --ip-forwarding

#Create a firewall VM to accept all traffic between the front and back-end subnets.
az vm create \
  --resource-group $RgName \
  --name MyVm-Firewall \
  --nics MyNic-Firewall \
  --image UbuntuLTS \
  --admin-username azureadmin \
  --generate-ssh-keys

# Get the private IP address from the VM for the user-defined route.
Fw1Ip=$(az vm list-ip-addresses \
  --resource-group $RgName \
  --name MyVm-Firewall \
  --query [].virtualMachine.network.privateIpAddresses[0] --out tsv)

# Create route table for the FrontEnd subnet.
az network route-table create \
  --name MyRouteTable-FrontEnd \
  --resource-group $RgName

# Create a route for traffic from the front-end to the back-end subnet through the firewall VM.
az network route-table route create \
  --name RouteToBackEnd \
  --resource-group $RgName \
  --route-table-name MyRouteTable-FrontEnd \
  --address-prefix 10.0.2.0/24 \
  --next-hop-type VirtualAppliance \
  --next-hop-ip-address $Fw1Ip

# Create a route for traffic from the front-end subnet to the Internet through the firewall VM.
az network route-table route create \
  --name RouteToInternet \
  --resource-group $RgName \
  --route-table-name MyRouteTable-FrontEnd \
  --address-prefix 0.0.0.0/0 \
  --next-hop-type VirtualAppliance \
  --next-hop-ip-address $Fw1Ip

# Associate the route table to the FrontEnd subnet.
az network vnet subnet update \
  --name MySubnet-FrontEnd \
  --vnet-name MyVnet \
  --resource-group $RgName \
  --route-table MyRouteTable-FrontEnd

# Create route table for the BackEnd subnet.
az network route-table create \
  --name MyRouteTable-BackEnd \
  --resource-group $RgName

# Create a route for traffic from the back-end subnet to the front-end subnet through the firewall VM.
az network route-table route create \
  --name RouteToFrontEnd \
  --resource-group $RgName \
  --route-table-name MyRouteTable-BackEnd \
  --address-prefix 10.0.1.0/24 \
  --next-hop-type VirtualAppliance \
  --next-hop-ip-address $Fw1Ip

# Create a route for traffic from the back-end subnet to the Internet through the firewall VM.
az network route-table route create \
  --name RouteToInternet \
  --resource-group $RgName \
  --route-table-name MyRouteTable-BackEnd \
  --address-prefix 0.0.0.0/0 \
  --next-hop-type VirtualAppliance \
  --next-hop-ip-address $Fw1Ip

# Associate the route table to the BackEnd subnet.
az network vnet subnet update \
  --name MySubnet-BackEnd \
  --vnet-name MyVnet \
  --resource-group $RgName \
  --route-table MyRouteTable-BackEnd

```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources:

```azurecli
az group delete --name MyResourceGroup --yes
```

## Script explanation

This script uses the following commands to create a resource group, virtual network,  and network security groups. Each command in the following table links to command-specific documentation:

| Command | Notes |
|---|---|
| [az group create](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az-group-create) | Creates a resource group in which all resources are stored. |
| [az network vnet create](https://docs.azure.cn/zh-cn/cli/network/vnet?view=azure-cli-latest#az-network-vnet-create) | Creates an Azure virtual network and front-end subnet. |
| [az network subnet create](https://docs.azure.cn/zh-cn/cli/network/vnet/subnet?view=azure-cli-latest#az-network-vnet-subnet-create) | Creates back-end and DMZ subnets. |
| [az network public-ip create](https://docs.azure.cn/zh-cn/cli/network/public-ip?view=azure-cli-latest#az-network-public-ip-create) | Creates a public IP address to access the VM from the internet. |
| [az network nic create](https://docs.azure.cn/zh-cn/cli/network/nic?view=azure-cli-latest#az-network-nic-create) | Creates a virtual network interface and enable IP forwarding for it. |
| [az network nsg create](https://docs.azure.cn/zh-cn/cli/network/nsg?view=azure-cli-latest#az-network-nsg-create) | Creates a network security group (NSG). |
| [az network nsg rule create](https://docs.azure.cn/zh-cn/cli/network/nsg/rule?view=azure-cli-latest#az-network-nsg-rule-create) | Creates NSG rules that allow HTTP and HTTPS ports inbound to the VM. |
| [az network vnet subnet update](https://docs.azure.cn/zh-cn/cli/network/vnet/subnet?view=azure-cli-latest#az-network-vnet-subnet-update)| Associates the NSGs and route tables to subnets. |
| [az network route-table create](https://docs.azure.cn/zh-cn/cli/network/route-table?view=azure-cli-latest#az-network-route-table-create)| Creates a route table for all routes. |
| [az network route-table route create](https://docs.azure.cn/zh-cn/cli/network/route-table/route?view=azure-cli-latest#az-network-route-table-route-create)| Creates routes to route traffic between subnets and the internet through the VM. |
| [az vm create](https://docs.azure.cn/zh-cn/cli/vm?view=azure-cli-latest#az-vm-create) | Creates a virtual machine and attaches the NIC to it. This command also specifies the virtual machine image to use and administrative credentials. |
| [az group delete](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az-group-delete) | Deletes a resource group and all resources it contains. |
## Next steps
For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-latest).
Additional virtual network CLI script samples can be found in [Virtual network CLI samples](../cli-samples.md).

<!-- Update_Description: new articles on virtual network cli sample route traffic through nva script -->
<!--ms.date: 05/07/2018-->