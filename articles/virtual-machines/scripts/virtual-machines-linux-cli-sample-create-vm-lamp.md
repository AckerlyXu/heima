---
title: Azure CLI Script Sample - Deploy the LAMP Stack in a Load-Balanced Virutal Machin Scale Set | Azure
description: Use a custom script extension to deploy the LAMP Stack in a load=balanced virtual machine scale set on Azure.
services: virtual-machines-linux
documentationcenter: virtual-machines
author: allclark
manager: douge
editor: tysonn
tags: azure-service-management

ms.assetid:
ms.service: virtual-machines-linux
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: vm-linux
ms.workload: infrastructure
origin.date: 04/05/2017
ms.date: 07/03/2017
ms.author: v-dazen
ms.custom: mvc
---

# Deploy the LAMP stack in a load-balanced virtual machine scale set

This example creates a virtual machine scale set
and applies an extension that runs a custom script to deploy the LAMP stack
on each virtual machine in the scale set.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

## Sample script

```azurecli-interactive
#!/bin/bash

# Create the resource group if it doesn't exist
az group create -n myResourceGroup -l chinanorth

# Build the Scale Set
az vmss create -n myScaleSet -g myResourceGroup --public-ip-address-dns-name my-lamp-sample \
    --image CentOS --storage-sku Premium_LRS --admin-username deploy --vm-sku Standard_DS3_v2

# Add a load balanced endpoint on port 80 routed to the backend servers on port 80
az network lb rule create -g myResourceGroup -n http-rule --backend-pool-name myScaleSetLBBEPool \
    --backend-port 80 --frontend-ip-name LoadBalancerFrontEnd --frontend-port 80 --lb-name myScaleSetLB \
    --protocol Tcp

# Create a virtual machine scale set custom script extension. This extension will provide configuration
# to each of the virtual machines within the scale set on how to provision their software stack.
# The configuration (./projected_config.json) contains commands to be executed upon provisioning
# of instances. This is helpful for hooking into configuration management software or simply
# provisioning your software stack directly.
az vmss extension set -n CustomScript --publisher Microsoft.Azure.Extensions --version 2.0 \
   -g myResourceGroup --vmss-name myScaleSet --protected-settings ./protected_config.json --no-auto-upgrade

# The instances that we have were created before the extension was added.
# Update these instances to run the new configuration on each of them.
az vmss update-instances --instance-ids "*" -n myScaleSet -g myResourceGroup

# Scaling adds new instances. These instances will run the configuration when they're provisioned.
az vmss scale --new-capacity 2 -n myScaleSet -g myResourceGroup

```

## Connect

Use this code to see how to connect to your VMs and your scale set.

```azurecli
#!/bin/bash

FQDN=$(az network public-ip list -g myResourceGroup --query \
                "[?starts_with(dnsSettings.fqdn, 'my-lamp-')].dnsSettings.fqdn | [0]" -o tsv)

PORTS=$(az network lb show -g myResourceGroup -n myScaleSetLB \
    --query "inboundNatRules[].{backend: backendPort, frontendPort: frontendPort}" -o tsv)
while read CMD; do
    read _ frontend <<< "${CMD}"
    echo "'ssh deploy@${FQDN} -p ${frontend}'"
done <<< "${PORTS}"

echo ""
echo "You can now reach the scale set by opening your browser to: 'http://${FQDN}'."
```

## Clean up deployment 

Run the following command to remove the resource group, the scale set and VMs, and all related resources.

```azurecli-interactive 
az group delete -n myResourceGroup
```

## Script explanation

This script uses the following commands to create a resource group, virtual machine, availability set, load balancer, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.microsoft.com/cli/azure/group#create) | Creates a resource group in which all resources are stored. |
| [az vmss create](https://docs.microsoft.com/cli/azure/vmss#create) | Creates a virtual machine scale set |
| [az network lb rule create](https://docs.microsoft.com/cli/azure/network/lb/rule#create) | Add a load-balanced endpoint |
| [az vmss extension set](https://docs.microsoft.com/cli/azure/vmss/extension#set) | Create the extension that runs the custom script on deployment of a VM |
| [az vmss update-instances](https://docs.microsoft.com/cli/azure/vmss#update-instances) | Run the custom script on the VM instances that were deployed before the extension was applied to the scale set. |
| [az vmss scale](https://docs.microsoft.com/cli/azure/vmss#scale) | Scale up the scale set by adding more VM instances. The custom script is run on these when they are deployed. |
| [az network public-ip list](https://docs.microsoft.com/cli/azure/network/public-ip#list) | Get the IP addresses of the VMs created by the sample. |
| [az network lb show](https://docs.microsoft.com/cli/azure/network/lb#show) | Get the frontend and backend ports used by the load balancer. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional virtual machine CLI script samples can be found in the [Azure Linux VM documentation](../linux/cli-samples.md?toc=%2fvirtual-machines%2flinux%2ftoc.json).
