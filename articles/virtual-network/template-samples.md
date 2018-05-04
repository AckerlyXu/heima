---
title: Azure Resource Manager template samples for virtual network | Azure
description: Learn about different Azure Resource Manager templates available for you to deploy Azure virtual networks with.
services: virtual-network
documentationcenter: virtual-network
author: rockboyfor
manager: digimobile
editor: ''
tags:

ms.assetid:
ms.service: virtual-network
ms.devlang: na
ms.topic: sample
ms.tgt_pltfrm:
ms.workload: infrastructure
origin.date: 04/13/2018
ms.date: 05/07/2018
ms.author: v-yeche

---
# Azure Resource Manager template samples for virtual network

The following table includes links to Azure Resource Manager template samples. You can deploy templates using the Azure [portal](../azure-resource-manager/resource-group-template-deploy-portal.md?toc=%2fvirtual-network%2ftoc.json), Azure [CLI](../azure-resource-manager/resource-group-template-deploy-cli.md?toc=%2fvirtual-network%2ftoc.json), or Azure [PowerShell](../azure-resource-manager/resource-group-template-deploy.md?toc=%2fvirtual-network%2ftoc.json). To learn how to author your own templates, see [Create your first template](../azure-resource-manager/resource-manager-create-first-template.md?toc=%2fvirtual-network%2ftoc.json) and [Understand the structure and syntax of Azure Resource Manager templates](../azure-resource-manager/resource-group-authoring-templates.md?toc=%2fvirtual-network%2ftoc.json)

>[!NOTE]
> Templates you downloaded from the GitHub Repo "azure-quickstart-templates" must be modified in order to fit in the Azure China Cloud Environment. For example, replace some endpoints -- "blob.core.windows.net" by "blob.core.chinacloudapi.cn", "cloudapp.azure.com" by "cloudapp.chinacloudapi.cn"; change some unsupported VM images and sku. 

| | |
|----|----|
|[Create a virtual network with two subnets](https://github.com/Azure/azure-quickstart-templates/tree/master/101-vnet-two-subnets)| Creates a virtual network with two subnets.|
|[Route traffic through a network virtual appliance](https://github.com/Azure/azure-quickstart-templates/tree/master/201-userdefined-routes-appliance)| Creates a virtual network with three subnets. Deploys a virtual machine into each of the subnets. Creates a route table containing routes to direct traffic from one subnet to another through the virtual machine in the third subnet. Associates the route table to one of the subnets.|
|[Create a virtual network service endpoint for Azure Storage](https://github.com/Azure/azure-quickstart-templates/tree/master/201-vnet-2subnets-service-endpoints-storage-integration)|Creates a new virtual network with two subnets, and a network interface in each subnet. Enables a service endpoint to Azure Storage for one of the subnets and secures a new storage account to that subnet.|
|[Connect two virtual networks](https://github.com/Azure/azure-quickstart-templates/tree/master/201-vnet-to-vnet-peering)| Creates two virtual networks and a virtual network peering between them.|
|[Create a virtual machine with multiple IP addresses](https://github.com/Azure/azure-quickstart-templates/tree/master/101-vm-multiple-ipconfig)| Creates a Windows or Linux VM with multiple IP addresses.|

<!-- Update_Description: new articles on template samples -->
<!--ms.date: 05/07/2018-->