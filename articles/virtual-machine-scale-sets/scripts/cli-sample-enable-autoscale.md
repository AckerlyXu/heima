---
title: Azure CLI 2.0 Samples - Enable host-based autoscale | Microsoft Docs
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

# Automatically scale a virtual machine scale set with the Azure CLI 2.0
This script creates a virtual machine scale set running Ubuntu and uses host-based metrics to automatically scale as CPU load changes.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

If you don't have an Azure subscription, create a [trial account](https://www.azure.cn/pricing/1rmb-trial) before you begin.

## Sample script
```azurecli
#!/bin/bash

$sub=az account show --query id -o tsv
$resourcegroup_name="myResourceGroup"
$scaleset_name="myScaleSet"
$location_name="chinanorth"

# Create a resource group
az group create --name $resourcegroup_name --location $location_name

# Create a scale set
# Network resources such as an Azure load balancer are automatically created
az vmss create `
  --resource-group $resourcegroup_name `
  --name $scaleset_name `
  --image UbuntuLTS `
  --upgrade-policy-mode automatic `
  --instance-count 2 `
  --admin-username azureuser `
  --generate-ssh-keys `
  --vm-sku Standard_DS1

# Define auto scale rules
# These rules automatically scale up the number of VM instances by 3 instances when the average CPU load over a 5-minute
# window exceeds 70%
# The scale set then automatically scales in by 1 instance when the average CPU load over a 5-minute window drops below 30%
az monitor autoscale-settings create `
    --resource-group $resourcegroup_name `
    --name autoscale `
    --parameters '{"autoscale_setting_resource_name": "autoscale",
      "enabled": true,
      "location": "'$location_name'",
      "notifications": [],
      "profiles": [
        {
          "name": "autoscale by percentage based on CPU usage",
          "capacity": {
            "minimum": "2",
            "maximum": "10",
            "default": "2"
          },
          "rules": [
            {
              "metricTrigger": {
                "metricName": "Percentage CPU",
                "metricNamespace": "",
                "metricResourceUri": "/subscriptions/'$sub'/resourceGroups/'$resourcegroup_name'/providers/Microsoft.Compute/virtualMachineScaleSets/'$scaleset_name'",
                "metricResourceLocation": "'$location_name'",
                "timeGrain": "PT1M",
                "statistic": "Average",
                "timeWindow": "PT5M",
                "timeAggregation": "Average",
                "operator": "GreaterThan",
                "threshold": 70
              },
              "scaleAction": {
                "direction": "Increase",
                "type": "ChangeCount",
                "value": "3",
                "cooldown": "PT5M"
              }
            },
            {
              "metricTrigger": {
                "metricName": "Percentage CPU",
                "metricNamespace": "",
                "metricResourceUri": "/subscriptions/'$sub'/resourceGroups/'$resourcegroup_name'/providers/Microsoft.Compute/virtualMachineScaleSets/'$scaleset_name'",
                "metricResourceLocation": "'$location_name'",
                "timeGrain": "PT1M",
                "statistic": "Average",
                "timeWindow": "PT5M",
                "timeAggregation": "Average",
                "operator": "LessThan",
                "threshold": 30
              },
              "scaleAction": {
                "direction": "Decrease",
                "type": "ChangeCount",
                "value": "1",
                "cooldown": "PT5M"
              }
            }
          ]
        }
      ],
      "tags": {},
      "target_resource_uri": "/subscriptions/'$sub'/resourceGroups/'$resourcegroup_name'/providers/Microsoft.Compute/virtualMachineScaleSets/'$scaleset_name'"
    }'
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
| [az monitor autoscale-settings create](/cli/monitor/autoscale-settings#az_monitor_autoscale_settings_create) | Creates and applies autoscale rules to a virtual machine scale set. |
| [az group delete](/cli/ad/group#delete) | Deletes a resource group including all nested resources. |

## Next steps
For more information on the Azure CLI 2.0, see [Azure CLI 2.0 documentation](/cli/).

Additional virtual machine scale set Azure CLI 2.0 script samples can be found in the [Azure virtual machine scale set documentation](../cli-samples.md).

