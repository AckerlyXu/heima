---
title: vCPU quotas for Azure | Azure
description: Learn about vCPU quotas for Azure.
keywords: ''
services: virtual-machines-linux
documentationcenter: ''
author: rockboyfor
manager: digimobile
editor: ''
tags: azure-resource-manager

ms.service: virtual-machines-linux
ms.workload: infrastructure-services
ms.tgt_pltfrm: vm-linux
ms.devlang: na
ms.topic: article
origin.date: 12/05/2016
ms.date: 4/10/2018
ms.author: v-yeche

---

# Virtual machine vCPU quotas

The vCPU quotas for virtual machines and virtual machine scale sets are arranged in two tiers for each subscription, in each region. The first tier is the Total Regional vCPUs, and the second tier is the various VM size family cores such as Standard D Family vCPUs. Any time a new VM is deployed the vCPUs for the newly deployed VM must not exceed the vCPU quota for the specific VM size family or the total regional vCPU quota. If either of those quotas are exceeded, then the VM deployment will not be allowed. There is also a quota for the overall number of virtual machines in the region. The details on each of these quotas can be seen in the **Usage + quotas** section of the **Subscription** page in the [Azure portal](https://portal.azure.cn), or you can query for the values using Azure CLI.

## Check usage

You can check your quota usage using [az vm list-usage](https://docs.azure.cn/zh-cn/cli/vm?view=azure-cli-latest#az_vm_list_usage).

```azurecli
az vm list-usage --location "China East"
[
  …
  {
    "currentValue": 4,
    "limit": 260,
    "name": {
      "localizedValue": "Total Regional vCPUs",
      "value": "cores"
    }
  },
  {
    "currentValue": 4,
    "limit": 10000,
    "name": {
      "localizedValue": "Virtual Machines",
      "value": "virtualMachines"
    }
  },
  {
    "currentValue": 1,
    "limit": 2000,
    "name": {
      "localizedValue": "Virtual Machine Scale Sets",
      "value": "virtualMachineScaleSets"
    }
  },
  {
    "currentValue": 1,
    "limit": 10,
    "name": {
      "localizedValue": "Standard B Family vCPUs",
      "value": "standardBFamily"
    }
  },
```
## Reserved VM Instances
Reserved VM Instances, which are scoped to a single subscription, will add a new aspect to the vCPU quotas. These values describe the number of instances of the stated size that must be deployable in the subscription. They work as a placeholder in the quota system to ensure that quota is reserved to ensure reserved instances are deployable in the subscription. For example, if a specific subscription has 10 Standard_D1 reserved instances the usages limit for Standard_D1 Reserved Instances will be 10. This will cause Azure to ensure that there are always at least 10 vCPUs available in the Total Regional vCPUs quota to be used for Standard_D1 instances and there are at least 10 vCPUs available in the Standard D Family vCPU quota to be used for Standard_D1 instances.

If a quota increase is required to either purchase a Single Subscription RI, you can [request a quota increase](https://support.windowsazure.cn/support/support-azure) on your subscription.
<!-- URL /azure-supportability/resource-manager-core-quotas-request SHOULD BE https://support.windowsazure.cn/support/support-azure -->

## Next steps

For more information about billing and quotas, see [Azure subscription and service limits, quotas, and constraints](/azure-subscription-service-limits?toc=/azure/billing/TOC.json).
<!-- Update_Description: update meta propertiessss -->
<!-- ms.date: 04/10/2018 -->