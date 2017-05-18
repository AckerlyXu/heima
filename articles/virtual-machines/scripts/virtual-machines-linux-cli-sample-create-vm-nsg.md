---
title: Azure CLI Script Sample - Create two VMs with an internal and external NSG | Azure
description: Azure CLI Script Sample - Create two VMs with internal and external NSG
services: virtual-machines-linux
documentationcenter: virtual-machines
author: neilpeterson
manager: timlt
editor: tysonn
tags: azure-service-management

ms.assetid:
ms.service: virtual-machines-linux
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: vm-linux
ms.workload: infrastructure
ms.date: 02/27/2017
wacn.date: ''
ms.author: nepeters
---

# Secure network traffic between virtual machines

This script creates two virtual machines and secures incoming traffic to both. One virtual machine is accessible on the internet and has a network security group (NSG) configured to allow traffic on port 22 and port 80. The second virtual machine is not accessible on the internet, and has an NSG configured to only allow traffic from the first virtual machine. 

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

[!INCLUDE [azure-cli-2-azurechinacloud-environment-parameter](../../../includes/azure-cli-2-azurechinacloud-environment-parameter.md)]

## Sample script

```azurecli-interactive
#!/bin/bash

# Create a resource group.
az group create --name myResourceGroup --location chinanorth

# Create a virtual network and front-end subnet.
az network vnet create --resource-group myResourceGroup --name myVnet --address-prefix 10.0.0.0/16 \
--subnet-name mySubnetFrontEnd --subnet-prefix 10.0.1.0/24

# Create a back-end subnet and associate with virtual network. 
az network vnet subnet create --resource-group myResourceGroup --vnet-name myVnet \
  --name mySubnetBackEnd --address-prefix 10.0.2.0/24

# Create a front-end virtual machine.
az vm create --resource-group myResourceGroup --name myVMFrontEnd --image UbuntuLTS \
  --vnet-name myVnet --subnet mySubnetFrontEnd --nsg myNetworkSecurityGroupFrontEnd \
  --generate-ssh-keys --no-wait

# Create a back-end virtual machine without a public IP address.
az vm create --resource-group myResourceGroup --name myVMBackEnd --image UbuntuLTS \
  --vnet-name myVnet --subnet mySubnetBackEnd --nsg myNetworkSecurityGroupBackEnd \
  --public-ip-address "" --generate-ssh-keys

# Create front-end NSG rule to allow traffic on port 80.
az network nsg rule create --resource-group myResourceGroup --nsg-name myNetworkSecurityGroupFrontEnd \
  --name http --access allow --protocol Tcp --direction Inbound --priority 200 \
  --source-address-prefix "*" --source-port-range "*" --destination-address-prefix "*" --destination-port-range 80

# Get default back-end SSH rule.
nsgrule=$(az network nsg rule list --resource-group myResourceGroup --nsg-name myNetworkSecurityGroupBackEnd --query [0].name -o tsv)

# Update back-end network security group rule to limit SSH to source prefix (priority 100).
az network nsg rule update --resource-group myResourceGroup --nsg-name myNetworkSecurityGroupBackEnd \
  --name $nsgrule --protocol tcp --direction inbound --priority 100 \
  --source-address-prefix 10.0.2.0/24 --source-port-range '*' --destination-address-prefix '*' \
  --destination-port-range 22 --access allow

# Create backend NSG rule to block all incoming traffic (priority 200).
az network nsg rule create --resource-group myResourceGroup --nsg-name myNetworkSecurityGroupBackEnd \
  --name denyAll --access Deny --protocol Tcp --direction Inbound --priority 200 \
  --source-address-prefix "*" --source-port-range "*" --destination-address-prefix "*" --destination-port-range "*"
```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources.

```azurecli
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands to create a resource group, virtual machine, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.microsoft.com/cli/azure/group#create) | Creates a resource group in which all resources are stored. |
| [az network vnet create](https://docs.microsoft.com/cli/azure/network/vnet#create) | Creates an Azure virtual network and subnet. |
| [az network vnet subnet create](https://docs.microsoft.com/cli/azure/network/vnet/subnet#create) | Creates a subnet. |
| [az vm create](https://docs.microsoft.com/cli/azure/vm#create) | Creates the virtual machine and connects it to the network card, virtual network, subnet, and NSG. This command also specifies the virtual machine image to be used, and administrative credentials.  |
| [az network nsg rule list](https://docs.microsoft.com/cli/azure/network/nsg/rule#list) | Returns information about a network security group rule. In this sample, the rule name is stored in a variable for use later in the script. |
| [az network nsg rule update](https://docs.microsoft.com/cli/azure/network/nsg/rule#update) | Updates an NSG rule. In this sample, the back-end rule is updated to pass through traffic only from the front-end subnet. |
| [az group delete](https://docs.microsoft.com/cli/azure/vm/extension#set) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional virtual machine CLI script samples can be found in the [Azure Linux VM documentation](../linux/cli-samples.md?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
