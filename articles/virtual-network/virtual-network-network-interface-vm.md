---
title: Add network interfaces to or remove from Azure virtual machines | Azure
description: Learn how to add network interfaces to or remove network interfaces from virtual machines.
services: virtual-network
documentationcenter: na
author: rockboyfor
manager: digimobile
editor: ''
tags: azure-resource-manager

ms.assetid:
ms.service: virtual-network
ms.devlang: NA
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: infrastructure-services
origin.date: 12/15/2017
ms.date: 01/22/2018
ms.author: v-yeche

---

# Add network interfaces to or remove network interfaces from virtual machines

Learn how to add an existing network interface when creating a VM or add or remove network interfaces from an existing VM in the stopped (deallocated) state. A network interface enables an Azure Virtual Machine (VM) to communicate with Internet, Azure, and on-premises resources. A VM can have one or more network interfaces. 

If you need to add, change, or remove IP addresses for a network interface, read the [Manage network interface IP addresses](virtual-network-network-interface-addresses.md) article. If you need to create, change, or delete network interfaces, read the [Manage network interfaces](virtual-network-network-interface.md) article.

## <a name="before"></a>Before you begin

Complete the following tasks before completing any steps in any section of this article:

- Log in to the Azure [portal](https://portal.azure.cn), Azure command-line interface (CLI), or Azure PowerShell with an Azure account. If you don't already have an Azure account, sign up for a [trial account](https://www.azure.cn/pricing/1rmb-trial).
- If using PowerShell commands to complete tasks in this article, [install and configure Azure PowerShell](https://docs.microsoft.com/powershell/azureps-cmdlets-docs?toc=%2fvirtual-network%2ftoc.json). Ensure you have the most recent version of the Azure PowerShell commandlets installed. To get help for PowerShell commands, with examples, type `get-help <command> -full`.
- If using Azure command-line interface (CLI) commands to complete tasks in this article, [install and configure the Azure CLI](https://docs.azure.cn/zh-cn/cli/install-azure-cli?toc=%2fvirtual-network%2ftoc.json?view=azure-cli-latest). Ensure you have the most recent version of the Azure CLI installed. To get help for CLI commands, type `az <command> --help`.
<!--Not Available on Cloud Shell Introduction -->

## <a name="vm-create"></a>Add existing network interfaces to a new VM

When you create a VM through the portal, the portal creates a network interface with default settings and attaches it to the VM for you. You cannot add existing network interfaces to a new VM, or create a VM with multiple network interfaces, using the Azure portal. You can do both using the CLI or PowerShell. Before using PowerShell or the CLI to create a VM with an existing network interface however, familiarize yourself with the [constraints](#constraints). If you create a virtual machine with multiple network interfaces, you must also configure the operating system to properly use them once the VM is created. For details, see Configure [Linux](../virtual-machines/linux/multiple-nics.md?toc=%2fvirtual-network%2ftoc.json#configure-guest-os-for-multiple-nics) or [Windows](../virtual-machines/windows/multiple-nics.md?toc=%2fvirtual-network%2ftoc.json#configure-guest-os-for-multiple-nics) for multiple network interfaces.

**Commands**
Before creating the VM, create a network interface using the steps in [Create a network interface](virtual-network-network-interface.md#create-a-network-interface).

|Tool|Command|
|---|---|
|CLI|[az vm create](https://docs.azure.cn/zh-cn/cli/vm?toc=%2fvirtual-network%2ftoc.json?view=azure-cli-latest#create)|
|PowerShell|[New-AzureRmVM](https://docs.microsoft.com/powershell/module/azurerm.compute/new-azurermvm?toc=%2fvirtual-network%2ftoc.json)|

## <a name="vm-add-nic"></a>Add a network interface to an existing VM

1. Log in to the Azure portal.
2. In the search box at the top of the portal, search for the name of the VM you want to add the network interface to, or browse for the VM by clicking **All services**, then **Virtual machines**. Once you've found the VM, click it. The VM you want to add a network interface to must support the number of network interfaces you want to add. To learn how many network interfaces each VM size supports, read the [Linux](../virtual-machines/linux/sizes.md?toc=%2fvirtual-network%2ftoc.json) or [Windows](../virtual-machines/virtual-machines-windows-sizes.md?toc=%2fvirtual-network%2ftoc.json) VM sizes articles.  
3. Click **Overview**, under **SETTINGS**. Click **Stop**, and wait until the **Status** of the VM changes to *Stopped (deallocated)*. 
4. Click **Networking**, under **SETTINGS**.
5. Click **Attach network interface**. From the list of existing network interfaces that aren't currently attached to another VM, click the network interface you'd like to attach. The network interface must exist in the same virtual network as the virtual network the network interface currently attached to the VM is in. If you don't have an existing network interface, you must first create one. To create a network interface, click **Create network interface**. To learn more about creating a network interface, see [Create a network interface](virtual-network-network-interface.md#create-a-network-interface). To learn more about additional constraints when adding network interfaces to virtual machines, see [Constraints](#constraints).
<!--Not Available on accelerated networking and IPv6 address -->
6. Click **OK**.
7. Click **Overview**, under **SETTINGS**. Click **Start** to start the virtual machine.
8. Configure the VM operating system to properly use multiple network interfaces. For details, see Configure [Linux](../virtual-machines/linux/multiple-nics.md?toc=%2fvirtual-network%2ftoc.json#configure-guest-os-for-multiple-nics) or [Windows](../virtual-machines/windows/multiple-nics.md?toc=%2fvirtual-network%2ftoc.json#configure-guest-os-for-multiple-nics) for multiple network interfaces.

|Tool|Command|
|---|---|
|CLI|[az vm nic add](https://docs.azure.cn/zh-cn/cli/vm/nic?toc=%2fvirtual-network%2ftoc.json?view=azure-cli-latest#add) (reference) or [detailed steps](../virtual-machines/linux/multiple-nics.md?toc=%2fvirtual-network%2ftoc.json#add-a-nic-to-a-vm)|
|PowerShell|[Add-AzureRmVMNetworkInterface](https://docs.microsoft.com/powershell/module/azurerm.compute/add-azurermvmnetworkinterface?toc=%2fvirtual-network%2ftoc.json) (reference) or [detailed steps](../virtual-machines/windows/multiple-nics.md?toc=%2fvirtual-network%2ftoc.json#add-a-nic-to-an-existing-vm)|

## <a name="vm-view-nic"></a> View network interfaces for a VM

You can view the network interfaces currently attached to a VM to learn about each network interface's configuration, and the IP addresses assigned to each network interface. 

1. Log in to the [Azure portal](https://portal.azure.cn) with an account that is assigned the Owner, Contributor, or Network Contributor role for your subscription. To learn more about assigning roles to accounts, see [Built-in roles for Azure role-based access control](../active-directory/role-based-access-built-in-roles.md?toc=%2fvirtual-network%2ftoc.json#network-contributor).
2. In the box that contains the text *Search resources* at the top of the Azure portal, type *virtual machines*. When **virtual machines** appears in the search results, click it.
3. Click the name of the VM you want to view network interfaces for.
4. In the **SETTINGS** section for the VM you selected, click **Networking**. To learn about network interface settings and how to change them, see [Manage network interfaces](virtual-network-network-interface.md). To learn about adding, changing, or removing IP addresses assigned to a network interface, see [Manage IP addresses](virtual-network-network-interface-addresses.md).

**Commands**

|Tool|Command|
|---|---|
|CLI|[az vm show](https://docs.azure.cn/zh-cn/cli/vm?toc=%2fvirtual-network%2ftoc.json?view=azure-cli-latest#show)|
|PowerShell|[Get-AzureRmVM](https://docs.microsoft.com/powershell/module/azurerm.compute/get-azurermvm?toc=%2fvirtual-network%2ftoc.json)|

## <a name="vm-remove-nic"></a> Remove a network interface from a VM

1. Log in to the Azure portal.
2. In the search box at the top of the portal, search for the name of the VM you want to remove (detach) the network interface from, or browse for the VM by clicking **All services**, then **Virtual machines**. Once you've found the VM, click it.
3. Click **Overview**, under **SETTINGS**. Click **Stop**, and wait until the **Status** of the VM changes to *Stopped (deallocated)*. 
4. Click **Networking**, under **SETTINGS**.
5. Click **Detach network interface**. From the list of network interfaces currently attached to the virtual machine, click the network interface you'd like to detach. If only one network interface is listed, you cannot detach it, because a virtual machine must always have at least one network interface attached to it.
6. Click **OK**.

**Commands**

|Tool|Command|
|---|---|
|CLI|[az vm nic remove](https://docs.azure.cn/zh-cn/cli/vm/nic?toc=%2fvirtual-network%2ftoc.json?view=azure-cli-latest#remove) (reference) or [detailed steps](../virtual-machines/linux/multiple-nics.md?toc=%2fvirtual-network%2ftoc.json#remove-a-nic-from-a-vm)|
|PowerShell|[Remove-AzureRMVMNetworkInterface](https://docs.microsoft.com/powershell/module/azurerm.compute/remove-azurermvmnetworkinterface?toc=%2fvirtual-network%2ftoc.json) (reference) or [detailed steps](../virtual-machines/windows/multiple-nics.md?toc=%2fvirtual-network%2ftoc.json#remove-a-nic-from-an-existing-vm)|

## <a name="next-steps"></a>Next steps
To create a VM with multiple network interfaces or IP addresses, read the following articles:

**Commands**

|Task|Tool|
|---|---|
|Create a VM with multiple NICs|[CLI](../virtual-machines/linux/multiple-nics.md?toc=%2fvirtual-network%2ftoc.json), [PowerShell](../virtual-machines/windows/multiple-nics.md?toc=%2fvirtual-network%2ftoc.json)|
|Create a single NIC VM with multiple IPv4 addresses|[CLI](virtual-network-multiple-ip-addresses-cli.md), [PowerShell](virtual-network-multiple-ip-addresses-powershell.md)|
<!-- Not Available on IPv6 -->
## Constraints

- A VM must have at least one network interface attached to it.
- A VM can only have as many network interfaces attached to it as the VM size supports. To learn more about how many network interfaces each VM size supports, see [Linux](../virtual-machines/linux/sizes.md?toc=%2fvirtual-network%2ftoc.json) and [Windows](../virtual-machines/virtual-machines-windows-sizes.md?toc=%2fvirtual-network%2ftoc.json) VM sizes. All sizes support at least two network interfaces.
- The network interfaces you add to a VM cannot currently be attached to another VM. To learn more about creating network interfaces, see [Create a network interface](virtual-network-network-interface.md#create-a-network-interface).
- In the past, network interfaces could only be added to VMs that supported multiple network interfaces and were created with at least two network interfaces. You could not add a network interface to a VM that was created with one network interface, even if the VM size supported multiple network interfaces. Conversely, you could only remove network interfaces from a VM with at least three network interfaces, because VMs created with at least two network interfaces always had to have at least two network interfaces. Neither of these constraints apply anymore. You can now create a VM with any number of network interfaces (up to the number supported by the VM size).
- By default, the first network interface attached to a VM is defined as the *primary* network interface. All other network interfaces in the VM are *secondary* network interfaces.
- Though you can control which network interface you sent outbound traffic to, by default, all outbound traffic from the VM is sent out the IP address assigned to the primary IP configuration of the primary network interface.
- In the past, all VMs within the same availability set were required to have a single, or multiple, network interfaces. VMs with any number of network interfaces can now exist in the same availability set, up to the number supported by the VM size. You can only add a VM to an availability set when it's created though. To learn more about availability sets, read the [Manage the availability of VMs in Azure](../virtual-machines/windows/manage-availability.md?toc=%2fvirtual-network%2ftoc.json#configure-multiple-virtual-machines-in-an-availability-set-for-redundancy) article.
- While network interfaces in the same VM can be connected to different subnets within a VNet, the network interfaces must all be connected to the same VNet.
- You can add any IP address for any IP configuration of any primary or secondary network interface to an Azure Load Balancer back-end pool. In the past, only the primary IP address for the primary network interface could be added to a back-end pool. To learn more about IP addresses and configurations, read the [Add, change, or remove IP addresses](virtual-network-network-interface-addresses.md) article.
- Deleting a VM does not delete the network interfaces that are attached to it. When a VM is deleted, the network interfaces are detached from the VM. You can add the network interfaces to different VMs, or delete them.
<!--Not Availble on IPv6 -->
<!--Update_Description: update meta properties, wording udpate, add constraints content  -->