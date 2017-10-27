---
title: Troubleshoot deploying Linux virtual machine issues in Azure | Azure
description: Troubleshoot deploying Linux virtual machine issues in Azurethe Resource Manager deployment model.
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
ms.topic: troubleshooting
origin.date: 06/22/2017
ms.date: 10/30/2017
ms.author: v-yeche

---
# Troubleshoot deploying Linux virtual machine issues in Azure

To troubleshoot virtual machine (VM) deployment issues in Azure, review the [top issues](#top-issues) for common failures and resolutions.

If you need more help at any point in this article, you can contact the Azure experts on [the MSDN Azure and CSDN Azure](https://www.azure.cn/support/forums/). Alternatively, you can file an Azure support incident. Go to the [Azure support site](https://www.azure.cn/support/contact/) and select **Get Support**.

## Top issues
[!INCLUDE [virtual-machines-linux-troubleshoot-deploy-vm-top](../../../includes/virtual-machines-linux-troubleshoot-deploy-vm-top.md)]

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

<!--Not Available on BizSpart, GPU, N-Series VB -->
## I am not able to see VM Size family that I want when resizing my VM.

When a VM is running, it is deployed to a physical server. The physical servers in Azure regions are grouped in clusters of common physical hardware. Resizing a VM that requires the VM to be moved to different hardware clusters is different depending on which deployment model was used to deploy the VM.

- VMs deployed in Classic deployment model, the cloud service deployment must be removed and redeployed to change the VMs to a size in another size family.

- VMs deployed in Resource Manager deployment model, you must stop all VMs in the availability set before changing the size of any VM in the availability set.

## The listed VM size is not supported while deploying in Availability Set.

Choose a size that is supported on the availability set's cluster. It is recommended when creating an availability set to choose the largest VM size you think you need, and have that be your first deployment to the Availability set.

## What Linux distributions/versions are supported on Azure?

You can find the list at Linux on [Azure-Endorsed Distributions](endorsed-distros.md).

## Can I add an existing Classic VM to an availability set?

Yes. You can add an existing classic VM to a new or existing Availability Set. For more information see [Add an existing virtual machine to an availability set](../windows/classic/configure-availability.md#addmachine).

## Next steps
If you need more help at any point in this article, you can contact the Azure experts on [the MSDN Azure and CSDN Azure](https://www.azure.cn/support/forums/).

Alternatively, you can file an Azure support incident. Go to the [Azure support site](https://www.azure.cn/support/contact/) and select **Get Support**.

<!--Update_Description: update meta properties， wording update->