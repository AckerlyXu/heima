---
title: Windows HPC Pack cluster options in Azure | Azure
description: Learn about options with Microsoft HPC Pack to create and manage a Windows high performance computing (HPC) cluster in the Azure cloud
services: virtual-machines-windows,cloud-services,batch
documentationcenter: ''
author: rockboyfor
manager: digimobile
editor: ''
tags: azure-resource-manager,azure-service-management,hpc-pack

ms.assetid: 02c5566d-2129-483c-9ecf-0d61030442d7
ms.service: virtual-machines-windows
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: vm-windows
ms.workload: big-compute
origin.date: 10/26/2017
ms.date: 12/18/2017
ms.author: v-yeche

---
# Options with HPC Pack to create and manage a cluster for Windows HPC workloads in Azure
[!INCLUDE [virtual-machines-common-hpcpack-cluster-options](../../../includes/virtual-machines-common-hpcpack-cluster-options.md)]

This article focuses on options to create HPC Pack clusters to run Windows workloads. 
<!-- Not Available on [Linux HPC workloads](../linux/hpcpack-cluster-options.md)-->

## HPC Pack cluster in Azure VMs and VM scale sets
### Azure templates

>[!NOTE]
> Templates you downloaded from the GitHub Repo "azure-quickstart-templates" must be modified in order to fit in the Azure China Cloud Environment. For example, replace some endpoints -- "blob.core.windows.net" by "blob.core.chinacloudapi.cn", "cloudapp.net" by "chinacloudapp.cn"; change some unsupported VM images; and changes some unsupported VM sizes.

* (Quickstart) [Create an HPC cluster](https://github.com/Azure/azure-quickstart-templates/tree/master/create-hpc-cluster)
* (Quickstart) [Create an HPC cluster with custom compute node image](https://github.com/Azure/azure-quickstart-templates/tree/master/create-hpc-cluster-custom-image)

<!-- Not Available on ### Azure VM images -->
### PowerShell deployment script for HPC Pack 2012 R2
* [Create an HPC cluster with the HPC Pack IaaS deployment script](classic/hpcpack-cluster-powershell-script.md?toc=%2fvirtual-machines%2fwindows%2fclassic%2ftoc.json)

### Manual deployment with the Azure portal
* [Set up the head node of an HPC Pack cluster in an Azure VM](hpcpack-cluster-headnode.md?toc=%2fvirtual-machines%2fwindows%2ftoc.json)

### Cluster management
* [Manage compute nodes in an HPC Pack cluster in Azure](classic/hpcpack-cluster-node-manage.md?toc=%2fvirtual-machines%2fwindows%2fclassic%2ftoc.json)
* [Grow and shrink Azure compute resources in an HPC Pack cluster](classic/hpcpack-cluster-node-autogrowshrink.md?toc=%2fvirtual-machines%2fwindows%2fclassic%2ftoc.json)
* [Submit jobs to an HPC Pack cluster in Azure](hpcpack-cluster-submit-jobs.md?toc=%2fvirtual-machines%2fwindows%2ftoc.json)
* [Job management in HPC Pack](https://technet.microsoft.com/library/jj899585.aspx)
* [Manage an HPC Pack 2016 cluster in Azure with Azure Active Directory](hpcpack-cluster-active-directory.md?toc=%2fvirtual-machines%2fwindows%2fclassic%2ftoc.json)

## Burst with worker role nodes 
* [Burst to Azure worker instances with HPC Pack](https://technet.microsoft.com/library/gg481749.aspx)
* [Tutorial: Set up a hybrid cluster with HPC Pack in Azure](../../cloud-services/cloud-services-setup-hybrid-hpcpack-cluster.md)
* [Add Azure "burst" nodes to an HPC Pack head node in Azure](classic/hpcpack-cluster-node-burst.md?toc=%2fvirtual-machines%2fwindows%2fclassic%2ftoc.json)

## Burst with Azure Batch
* [Burst to Azure Batch with HPC Pack](https://technet.microsoft.com/library/mt612877.aspx)
<!--Update_Description: update meta properties, wording update-->