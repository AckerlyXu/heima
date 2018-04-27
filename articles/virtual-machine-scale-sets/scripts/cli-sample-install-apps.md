---
title: Azure CLI 2.0 Samples - Install apps | Microsoft Docs
description: Azure CLI 2.0 Samples
services: virtual-machine-scale-sets
documentationcenter: ''
author: iainfoulds
manager: jeconnoc
editor: ''
tags: azure-resource-manager

ms.assetid:
ms.service: virtual-machine-scale-sets
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: na
ms.workload: na
origin.date: 03/27/2018
ms.date: 04/25/2018
ms.author: v-junlch
ms.custom: mvc

---

# Install applications into a virtual machine scale set with the Azure CLI 2.0
This script creates a virtual machine scale set running Ubuntu and uses the Custom Script Extension to install a basic web application. After running the script, you can access the web app through a web browser.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

If you don't have an Azure subscription, create a [trial account](https://www.azure.cn/pricing/1rmb-trial) before you begin.

## Sample script
```azurecli
#!/bin/bash

# Create a resource group
az group create --name myResourceGroup --location chinanorth

# Create a scale set
# Network resources such as an Azure load balancer are automatically created
az vmss create `
  --resource-group myResourceGroup `
  --name myScaleSet `
  --image UbuntuLTS `
  --upgrade-policy-mode automatic `
  --admin-username azureuser `
  --generate-ssh-keys `
  --vm-sku Standard_DS1

# Install the Azure Custom Script Extension to run an install script
az vmss extension set `
  --publisher Microsoft.Azure.Extensions `
  --version 2.0 `
  --name CustomScript `
  --resource-group myResourceGroup `
  --vmss-name myScaleSet `
  --settings '{"fileUris":["https://raw.githubusercontent.com/Azure-Samples/compute-automation-configurations/master/automate_nginx.sh"],"commandToExecute":"./automate_nginx.sh"}'

# Create a load balancer rule to allow web traffic to reach VM instances
az network lb rule create `
  --resource-group myResourceGroup `
  --name myLoadBalancerRuleWeb `
  --lb-name myScaleSetLB `
  --backend-pool-name myScaleSetLBBEPool `
  --backend-port 80 `
  --frontend-ip-name loadBalancerFrontEnd `
  --frontend-port 80 `
  --protocol tcp

# Show the public IP address of the load balancer and view your web servers
az network public-ip show `
  --resource-group myResourceGroup `
  --name myScaleSetLBPublicIP `
  --query [ipAddress] `
  --output tsv
```
## Clean up deployment
Run the following command to remove the resource group, scale set, and all related resources.

```azurecli
az group delete --name myResourceGroup
```

## Script explanation
This script uses the following commands to create a resource group, virtual machine scale set, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](/cli/ad/group#az_ad_group_create) | Creates a resource group in which all resources are stored. |
| [az vmss create](/cli/vmss#az_vmss_create) | Creates the virtual machine scale set and connects it to the virtual network, subnet, and network security group. A load balancer is also created to distribute traffic to multiple VM instances. This command also specifies the VM image to be used and administrative credentials.  |
| [az vmss extension set](/cli/vmss/extension#az_vmss_extension_set) | Installs the Azure Custom Script Extension to run a script that prepares the data disks on each VM instance. |
| [az network lb rule create](/cli/network/lb/rule#az_network_lb_rule_create) | Creates a load balancer rule to distribute traffic on TCP port 80 to the VM instances in the scale set. |
| [az network public-ip show](/cli/network/public-ip#az_network_public_ip_show) | Gets information on the public IP address assigned used by the load balancer. |
| [az group delete](/cli/ad/group#delete) | Deletes a resource group including all nested resources. |

## Next steps
For more information on the Azure CLI 2.0, see [Azure CLI 2.0 documentation](/cli/).

Additional virtual machine scale set Azure CLI 2.0 script samples can be found in the [Azure virtual machine scale set documentation](../cli-samples.md).

