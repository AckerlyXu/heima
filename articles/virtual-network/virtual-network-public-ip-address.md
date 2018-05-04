---
title: Create, change, or delete an Azure public IP address | Azure
description: Learn how to create, change, or delete a public IP address.
services: virtual-network
documentationcenter: na
author: rockboyfor
manager: digimobile
editor: ''
tags: azure-resource-manager

ms.assetid: bb71abaf-b2d9-4147-b607-38067a10caf6 
ms.service: virtual-network
ms.devlang: NA
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: infrastructure-services
origin.date: 09/25/2017
ms.date: 05/07/2018
ms.author: v-yeche

---

# Create, change, or delete a public IP address

Learn about a public IP address and how to create, change, and delete one. A public IP address is a resource with its own configurable settings. Assigning a public IP address to other Azure resources enables:
- Inbound Internet connectivity to resources such as Azure Virtual Machines, Azure Virtual Machine Scale Sets, Azure VPN Gateway, Application gateways, and Internet-facing Azure Load Balancers. Azure resources cannot receive inbound communication from the Internet without an assigned public IP address. While some Azure resources are inherently accessible through public IP addresses, other resources must have public IP addresses assigned to them to be accessible from the Internet.
- Outbound connectivity to the Internet using a predictable IP address. For example, a virtual machine can communicate outbound to the Internet without a public IP address assigned to it, but its address is network address translated by Azure to an unpredictable public address. Assigning a public IP address to a resource enables you to know which IP address is used for the outbound connection. Though predictable, the address can change, depending on the assignment method chosen. For more information, see [Create a public IP address](#create-a-public-ip-address). To learn more about outbound connections from Azure resources, read the [Understand outbound connections](../load-balancer/load-balancer-outbound-connections.md?toc=%2fvirtual-network%2ftoc.json) article.

<a name="before"></a>
## Before you begin

Complete the following tasks before completing steps in any section of this article:

- If you don't already have an Azure account, sign up for a [trial account](https://www.azure.cn/pricing/1rmb-trial).
- If using the portal, open https://portal.azure.cn, and log in with your Azure account.
- If using PowerShell commands to complete tasks in this article,  by running PowerShell from your computer.  This tutorial requires the Azure PowerShell module version 5.2.0 or later. Run `Get-Module -ListAvailable AzureRM` to find the installed version. If you need to upgrade, see [Install Azure PowerShell module](https://docs.microsoft.com/powershell/azure/install-azurerm-ps). If you are running PowerShell locally, you also need to run `Login-AzureRmAccount -EnvironmentName AzureChinaCloud` to create a connection with Azure.
- If using Azure Command-line interface (CLI) commands to complete tasks in this article,  by running the CLI from your computer. This tutorial requires the Azure CLI version 2.0.26 or later. Run `az --version` to find the installed version. If you need to install or upgrade, see [Install Azure CLI 2.0](https://docs.azure.cn/zh-cn/cli/install-azure-cli?view=azure-cli-latest). If you are running the Azure CLI locally, you also need to run `az login` to create a connection with Azure.
<!-- Not Available on Azure Cloud Shell -->

Public IP addresses have a nominal charge. To view the pricing, read the [IP address pricing](https://www.azure.cn/pricing/details/reserved-ip-addresses/) page. 

## <a name="create-a-public-ip-address"></a>Create a public IP address

1. In the box that contains the text *Search resources* at the top of the Azure portal, type *public ip address*. When **Public IP addresses** appears in the search results, click it.
2. Click **+ Add** in the **Public IP address** blade that appears.
3. Enter or select values for the following settings in the **Create public IP address** blade that appears, then click **Create**:

    |Setting|Required?|Details|
    |---|---|---|
    <!-- No Available on SKU for public IP Address |SKU|Yes|All public IP addresses created before the introduction of SKUs are **Basic** SKU public IP addresses.  You cannot change the SKU after the public IP address is created. A standalone virtual machine, virtual machines within an availability set, or virtual machine scale sets can use Basic or Standard SKUs.  Mixing SKUs between virtual machines within availability sets or scale sets is not allowed. **Basic** SKU: If you are creating a public IP address in a region that supports availability zones, the **Availability zone** setting is set to *None* by default. You can choose to select an availability zone to guarantee a specific zone for your public IP address. **Standard** SKU: A Standard SKU public IP can be associated to a virtual machine or a load balancer front end. If you're creating a public IP address in a region that supports availability zones, the **Availability zone** setting is set to *Zone-redundant* by default. For more information about availability zones, see the **Availability zone** setting. The standard SKU is required if you associate the address to a Standard load balancer.  The Standard SKU is in preview release. Before creating a Standard SKU public IP address, you must first complete the steps in register for the standard SKU preview and create the public IP address in a supported location (region). For a list of supported locations, monitor the [Azure Virtual Network updates](https://www.azure.cn/what-is-new/) page for additional region support. When you assign a standard SKU public IP address to a virtual machine's network interface, you must explicitly allow the intended traffic with a [network security group](security-overview.md#network-security-groups). Communication with the resource fails until you create and associate a network security group and explicitly allow the desired traffic.| -->
    <!-- Not Avaialbe on Load Balancer Standard -->
    |Name|Yes|The name must be unique within the resource group you select.|
    |IP Version|Yes| Select IPv4.  While public IPv4 addresses can be assigned to several Azure resources.
    |IP address assignment|Yes|**Dynamic:** Dynamic addresses are assigned only after the public IP address is associated to a network interface attached to a virtual machine and the virtual machine is started for the first time. Dynamic addresses can change if the virtual machine the network interface is attached to is stopped (deallocated). The address remains the same if the virtual machine is rebooted or stopped (but not deallocated). **Static:** Static addresses are assigned when the public IP address is created. Static addresses do not change even if the virtual machine is put in the stopped (deallocated) state. The address is only released when the network interface is deleted. You can change the assignment method after the network interface is created. If you select *Standard* for **SKU**, the assignment method is *Static*.|
    |Idle timeout (minutes)|No|How many minutes to keep a TCP or HTTP connection open without relying on clients to send keep-alive messages.|
    |DNS name label|No|Must be unique within the Azure location you create the name in (across all subscriptions and all customers). Azure automatically registers the name and IP address in its DNS so you can connect to a resource with the name. Azure appends a default subnet such as *location.cloudapp.chinacloudapi.cn* (where location is the location you select) to the name you provide, to create the fully qualified DNS name. Azure's default DNS contains IPv4 A name records and responds with record when the DNS name is looked up. The client chooses (IPv4) address to communicate with. Instead of, or in addition to, using the DNS name label with the default suffix, you can use the Azure DNS service to configure a DNS name with a custom suffix that resolves to the public IP address.|
    |Subscription|Yes|Must exist in the same [subscription](../azure-glossary-cloud-terminology.md?toc=%2fvirtual-network%2ftoc.json#subscription) as the resource you want to associate the public IP address to.|
    |Resource group|Yes|Can exist in the same, or different, [resource group](../azure-glossary-cloud-terminology.md?toc=%2fvirtual-network%2ftoc.json#resource-group) as the resource you want to associate the public IP address to.|
    |Location|Yes|Must exist in the same [location](https://azure.microsoft.com/regions), also referred to as region, as the resource you want to associate the public IP address to.|
    <!-- Line 49 Not Available on [Azure load balancer standard SKU](../load-balancer/load-balancer-standard-overview.md?toc=%2fvirtual-network%2ftoc.json) -->
    <!-- Not Available on Available zone -->

**Commands**

<!-- Not Available on two version for IPv4 and IPv6 -->
|Tool|Command|
|---|---|
|CLI|[az network public-ip create](https://docs.azure.cn/zh-cn/cli/network/public-ip?toc=%2fvirtual-network%2ftoc.json?view=azure-cli-latest#az-network-public-ip-create)|
|PowerShell|[New-AzureRmPublicIpAddress](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermpublicipaddress)|

<a name="change"></a>
## View, change settings for, or delete a public IP address

1. In the box that contains the text *Search resources* at the top of the Azure portal, type *public ip address*. When **Public IP addresses** appears in the search results, click it.
2. In the **Public IP addresses** blade that appears, click the name of the public IP address you want to view, change settings for, or delete.
3. In the blade that appears for the public IP address, complete one of the following options depending on whether you want to view, delete, or change the public IP address.
    - **View**: The **Overview** section of the blade shows key settings for the public IP address, such as the network interface it's associated to (if the address is associated to a network interface). To view the version information, use the PowerShell or CLI command to view the public IP address. 
    <!-- Not Available on IPV6 -->
    - **Delete**: To delete the public IP address, click **Delete** in the **Overview** section of the blade. If the address is currently associated to an IP configuration, it cannot be deleted. If the address is currently associated with a configuration, click **Dissociate** to dissociate the address from the IP configuration.
    - **Change**: Click **Configuration**. Change settings using the information in step 4 of the [Create a public IP address](#create-a-public-ip-address) section of this article. To change the assignment for an IPv4 address from static to dynamic, you must first dissociate the public IPv4 address from the IP configuration it's associated to. You can then change the assignment method to dynamic and click **Associate** to associate the IP address to the same IP configuration, a different configuration, or you can leave it dissociated. To dissociate a public IP address, in the **Overview** section, click **Dissociate**.

>[!WARNING]
>When you change the assignment method from static to dynamic, you lose the IP address that was assigned to the public IP address. While the Azure public DNS servers maintain a mapping between static or dynamic addresses and any DNS name label (if you defined one), a dynamic IP address can change when the virtual machine is started after being in the stopped (deallocated) state. To prevent the address from changing, assign a static IP address.

**Commands**

|Tool|Command|
|---|---|
|CLI|[az network public-ip-list](https://docs.azure.cn/zh-cn/cli/network/public-ip?toc=%2fvirtual-network%2ftoc.json?view=azure-cli-latest#az-network-public-ip-list) to list public IP addresses, [az network public-ip-show](https://docs.azure.cn/zh-cn/cli/network/public-ip?toc=%2fvirtual-network%2ftoc.json?view=azure-cli-latest#az-network-public-ip-show) to show settings; [az network public-ip update](https://docs.azure.cn/zh-cn/cli/network/public-ip?toc=%2fvirtual-network%2ftoc.json?view=azure-cli-latest#az-network-public-ip-update) to update; [az network public-ip delete](https://docs.azure.cn/zh-cn/cli/network/public-ip?toc=%2fvirtual-network%2ftoc.json?view=azure-cli-latest#az-network-public-ip-delete) to delete|
|PowerShell|[Get-AzureRmPublicIpAddress](https://docs.microsoft.com/powershell/module/azurerm.network/get-azurermpublicipaddress?toc=%2fvirtual-network%2ftoc.json) to retrieve a public IP address object and view its settings, [Set-AzureRmPublicIpAddress](https://docs.microsoft.com/powershell/resourcemanager/azurerm.network/set-azurermpublicipaddress?toc=%2fvirtual-network%2ftoc.json) to update settings; [Remove-AzureRmPublicIpAddress](https://docs.microsoft.com/powershell/module/azurerm.network/remove-azurermpublicipaddress) to delete|

## <a name="next-steps"></a>Next steps
Assign public IP addresses when creating the following Azure resources:

- [Windows](../virtual-machines/virtual-machines-windows-hero-tutorial.md?toc=%2fvirtual-network%2ftoc.json) or [Linux](../virtual-machines/linux/quick-create-portal.md?toc=%2fvirtual-network%2ftoc.json) virtual machines
- [Internet-facing Azure Load Balancer](../load-balancer/load-balancer-get-started-internet-portal.md?toc=%2fvirtual-network%2ftoc.json)
- [Azure Application Gateway](../application-gateway/application-gateway-create-gateway-portal.md?toc=%2fvirtual-network%2ftoc.json)
- [Site-to-site connection using an Azure VPN Gateway](../vpn-gateway/vpn-gateway-howto-site-to-site-resource-manager-portal.md?toc=%2fvirtual-network%2ftoc.json)
- [Azure Virtual Machine Scale Set](../virtual-machine-scale-sets/virtual-machine-scale-sets-portal-create.md?toc=%2fvirtual-network%2ftoc.json)

<!--Update_Description: wording update, update link -->