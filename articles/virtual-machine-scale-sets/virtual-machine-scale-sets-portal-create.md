---
title: Create a Virtual Machine Scale Set using the Azure Portal | Azure
description: Deploy scale sets using Azure Portal.
keywords: virtual machine scale sets
services: virtual-machine-scale-sets
documentationcenter: ''
author: gatneil
manager: madhana
editor: tysonn
tags: azure-resource-manager

ms.assetid: 9c1583f0-bcc7-4b51-9d64-84da76de1fda
ms.service: virtual-machine-scale-sets
ms.workload: infrastructure-services
ms.tgt_pltfrm: vm
ms.devlang: na
ms.topic: article
origin.date: 05/01/2017
ms.date: 04/17/2017
ms.author: v-dazen
ms.custom: H1Hack27Feb2017

---
# How to create a Virtual Machine Scale Set with the Azure Portal
This tutorial shows you how easy it is to create a Virtual Machine Scale Set in just a few minutes, by using the Azure Portal. If you don't have an Azure subscription, create a [trial account](https://www.azure.cn/pricing/1rmb-trial/) before you begin.

## Choose the VM image from the marketplace
From the portal, you can easily deploy a scale set with CentOS, CoreOS, Debian, Open Suse, Red Hat Enterprise Linux, SUSE Linux Enterprise Server, Ubuntu Server, or Windows Server images.

First, navigate to the [Azure Portal](https://portal.azure.cn) in a web browser. Click `New`, search for `scale set`, and then select the `Virtual machine scale set` entry:

![ScaleSetPortalOverview](./media/virtual-machine-scale-sets-portal-create/ScaleSetPortalOverview.PNG)

## Create the scale set
Now you can use the default settings and quickly create the scale set.

* On the `Basics` blade, enter a name for the scale set. This name becomes the base of the FQDN of the load balancer in front of the scale set, so make sure the name is unique across all Azure.
* Select your desired OS type, enter your desired username, and select which authentication type you prefer. If you choose a password, it must be at least 12 characters long and meet three out of the four following complexity requirements: one lower case character, one upper case character, one number, and one special character. See more about [username and password requirements](../virtual-machines/windows/faq.md#what-are-the-username-requirements-when-creating-a-vm). If you choose `SSH public key`, be sure to only paste in your public key, NOT your private key:

![ScaleSetPortalBasics](./media/virtual-machine-scale-sets-portal-create/ScaleSetPortalBasics.PNG)

* Enter your desired resource group name and location, and then click `OK`.
* On the `Virtual machine scale set service settings` blade: enter your desired domain name label (the base of the FQDN for the load balancer in front of the scale set). This label must be unique across all Azure.
* Choose your desired operating system disk image, instance count, and machine size.

![ScaleSetPortalService](./media/virtual-machine-scale-sets-portal-create/ScaleSetPortalService.PNG)

* On the `Summary` blade, when validation is done, click `OK` to start the scale set deployment.

## Connect to a VM in the scale set
If you chose to limit your scale set to a single placement group, then the scale set is deployed with NAT rules configured to let you connect to the scale set easily (if not, to connect to the virtual machines in the scale set, you likely need to create a jumpbox in the same virtual network as the scale set). To see them, navigate to the `Inbound NAT Rules` tab of the load balancer for the scale set:

![ScaleSetPortalNatRules](./media/virtual-machine-scale-sets-portal-create/ScaleSetPortalNatRules.PNG)

You can connect to each VM in the scale set using these NAT rules. For instance, for a Windows scale set, if there is a NAT rule on incoming port 50000, you could connect to that machine via RDP on `<load-balancer-ip-address>:50000`. For a Linux scale set, you would connect using the command `ssh -p 50000 <username>@<load-balancer-ip-address>`.

## Next steps
For documentation on how to deploy scale sets from the CLI, see [this documentation](virtual-machine-scale-sets-cli-quick-create.md).

For documentation on how to deploy scale sets from PowerShell, see [this documentation](virtual-machine-scale-sets-windows-create.md).

For documentation on how to deploy scale sets from Visual Studio, see [this documentation](virtual-machine-scale-sets-vs-create.md).

For general documentation, check out the [documentation overview page for scale sets](virtual-machine-scale-sets-overview.md).

For general information, check out the [main landing page for scale sets](https://www.azure.cn/home/features/virtual-machine-scale-sets/).
