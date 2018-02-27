---
title: Troubleshoot deploying Windows virtual machine issues in Azure | Azure
description: Troubleshoot deploying Windows virtual machine issues in Azurethe Resource Manager deployment model.
services: virtual-machines-windows
documentationcenter: ''
author: rockboyfor
manager: digimobile
editor: ''
tags: azure-resource-manager

ms.assetid: 4e383427-4aff-4bf3-a0f4-dbff5c6f0c81
ms.service: virtual-machines-windows
ms.workload: infrastructure-services
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 11/03/2017
ms.date: 02/05/2018
ms.author: v-yeche

---
# Troubleshoot deploying Windows virtual machine issues in Azure

To troubleshoot virtual machine (VM) deployment issues in Azure, review the [top issues](#top-issues) for common failures and resolutions.

If you need more help at any point in this article, you can contact the Azure experts on [the MSDN Azure and CSDN Azure](https://www.azure.cn/support/forums/). Alternatively, you can file an Azure support incident. Go to the [Azure support site](https://www.azure.cn/support/contact/) and select **Get Support**.

## Top issues
[!INCLUDE [virtual-machines-windows-troubleshoot-deploy-vm-top](../../../includes/virtual-machines-windows-troubleshoot-deploy-vm-top.md)]

## The cluster cannot support the requested VM size
<properties
supportTopicIds="123456789"
resourceTags="windows"
productPesIds="1234, 5678"
/>
- Retry the request using a smaller VM size.
- If the size of the requested VM cannot be changed:
    - Stop all the VMs in the availability set. Click **Resource groups** > your resource group > **Resources** > your availability set > **Virtual Machines** > your virtual machine > **Stop**.
    - After all the VMs stop, create the VM in the desired size.
    - Start the new VM first, and then select each of the stopped VMs and click Start.

## The cluster does not have free resources
<properties
supportTopicIds="123456789"
resourceTags="windows"
productPesIds="1234, 5678"
/>
- Retry the request later.
- If the new VM can be part of a different availability set
    - Create a VM in a different availability set (in the same region).
    - Add the new VM to the same virtual network.

<!--Not Available ## How can I use and deploy a windows client image into Azure?-->
## How can I deploy a virtual machine using the Hybrid Use Benefit (HUB)?

There are a couple of different ways to deploy Windows virtual machines with the Azure Hybrid Use Benefit.

For an Enterprise Agreement subscription:

•	Deploy VMs from specific Marketplace images that are pre-configured with Azure Hybrid Use Benefit.

For Enterprise agreement:

•	Upload a custom VM and deploy using a Resource Manager template or Azure PowerShell.

For more information, see the following resources:

 - [Azure Hybrid Use Benefit overview ](https://www.azure.cn/pricing/hybrid-use-benefit/)

 - [Downloadable FAQ](http://download.microsoft.com/download/4/2/1/4211AC94-D607-4A45-B472-4B30EDF437DE/Windows_Server_Azure_Hybrid_Use_FAQ_EN_US.pdf)

 - [Azure Hybrid Use Benefit for Windows Server and Windows Client](hybrid-use-benefit-licensing.md).

 - [How can I use the Hybrid Use Benefit in Azure](https://blogs.msdn.microsoft.com/azureedu/2016/04/13/how-can-i-use-the-hybrid-use-benefit-in-azure)
<!--Not Available ## How do I activate my monthly credit for Visual studio Enterprise (BizSpark)-->
<!--Not Available ## How to add Enterprise Dev/Test to my Enterprise Agreement (EA) to get access to Window client images?-->
<!--Not Available ## My drivers are missing for my Windows N-Series VM-->
<!--Not Available ## I can't find a GPU instance within my N-Series VM-->
<!--Not Available ## Are client images supported for N-Series?-->
<!--Not Available ## Is N-Series VMs available in my region?-->
<!--Not Available ## What client images can I use and deploy in Azure, and how to I get them?-->
## I am not able to see VM Size family that I want when resizing my VM.

When a VM is running, it is deployed to a physical server. The physical servers in Azure regions are grouped in clusters of common physical hardware. Resizing a VM that requires the VM to be moved to different hardware clusters is different depending on which deployment model was used to deploy the VM.

- VMs deployed in Classic deployment model, the cloud service deployment must be removed and redeployed to change the VMs to a size in another size family.

- VMs deployed in Resource Manager deployment model, you must stop all VMs in the availability set before changing the size of any VM in the availability set.

## The listed VM size is not supported while deploying in Availability Set.

Choose a size that is supported on the availability set's cluster. It is recommended when creating an availability set to choose the largest VM size you think you need, and have that be your first deployment to the Availability set.

## Can I add an existing Classic VM to an availability set?

Yes. You can add an existing classic VM to a new or existing Availability Set. For more information see [Add an existing virtual machine to an availability set](classic/configure-availability.md#addmachine).

## Next steps
If you need more help at any point in this article, you can contact the Azure experts on [the MSDN Azure and CSDN Azure](https://www.azure.cn/support/forums/).

Alternatively, you can file an Azure support incident. Go to the [Azure support site](https://www.azure.cn/support/contact/) and select **Get Support**.
<!--Update_Description: add HUB question and answer -->