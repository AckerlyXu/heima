---
title: Designing Azure Virtual Machine Scale Sets For Scale | Azure
description: Learn about how to design your Azure Virtual Machine Scale Sets for scale
keywords: linux virtual machine,virtual machine scale sets
services: virtual-machine-scale-sets
documentationcenter: ''
author: gatneil
manager: madhana
editor: tysonn
tags: azure-resource-manager

ms.assetid: c27c6a59-a0ab-4117-a01b-42b049464ca1
ms.service: virtual-machine-scale-sets
ms.workload: na
ms.tgt_pltfrm: vm-linux
ms.devlang: na
ms.topic: article
ms.date: 02/13/2017
wacn.date: ''
ms.author: negat

---
# Designing VM Scale Sets For Scale
This topic discusses design considerations for Virtual Machine Scale Sets. For information about what Virtual Machine Scale Sets are, refer to [Virtual Machine Scale Sets Overview](virtual-machine-scale-sets-overview.md).

## Storage

### User-managed Storage
A scale set relies on user-created storage accounts to store the OS disks of the VMs in the set. A ratio of 20 VMs per storage account or less is recommended to achieve maximum IO and also take advantage of _overprovisioning_ (see below). It is also recommended that you spread the beginning characters of the storage account names across the alphabet. Doing so helps spread load across different internal systems. 

## Overprovisioning
Starting with the "2016-03-30" API version, VM Scale Sets default to "overprovisioning" VMs. With overprovisioning turned on, the scale set actually spins up more VMs than you asked for, then deletes the extra VMs once the requested number of VMs are successfully provisioned. Overprovisioning improves provisioning success rates and reduces deployment time. You are not billed for the extra VMs, and they do not count toward your quota limits.

While overprovisioning does improve provisioning success rates, it can cause confusing behavior for an application that is not designed to handle extra VMs appearing and then disappearing. To turn overprovisioning off, ensure you have the following string in your template: "overprovision": "false". More details can be found in the [VM Scale Set REST API documentation](https://msdn.microsoft.com/library/azure/mt589035.aspx).

If your scale set uses user-managed storage, and you turn off overprovisioning, you can have more than 20 VMs per storage account, but it is not recommended to go above 40 for IO performance reasons. 

## Limits

A scale set configured with user-managed storage accounts is currently limited to 100 VMs (and 5 storage accounts are recommended for this scale).

A scale set built on a custom image (one built by you) can have a capacity of up to 100 VMs. If the scale set is configured with user-managed storage accounts, it must create all OS disk VHDs within one storage account. As a result, the maximum recommended number of VMs in a scale set built on a custom image and user-managed storage is 20. If you turn off overprovisioning, you can go up to 40.

For more VMs than these limits allow, you need to deploy multiple scale sets as shown in [this template](https://github.com/Azure/azure-quickstart-templates/tree/master/301-custom-images-at-scale).