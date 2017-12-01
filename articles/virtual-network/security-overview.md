---
title: Azure network security overview | Azure
description: Learn about security options for controlling the flow of network traffic between Azure resources.
services: virtual-network
documentationcenter: na
author: rockboyfor
manager: digimobile
editor: ''

ms.assetid: 
ms.service: virtual-network
ms.devlang: NA
ms.topic: get-started-article
ms.tgt_pltfrm: na
ms.workload: infrastructure-services
origin.date: 09/19/2017
ms.date: 11/06/2017
ms.author: v-yeche

---
# Network security

You can limit network traffic to resources in a virtual network using a network security group. A network security group contains a list of security rules that allow or deny inbound or outbound network traffic based on source or destination IP address, port, and protocol. 

## Network security groups

Each network interface has zero, or one, associated network security group. Each network interface exists in a [virtual network](virtual-networks-overview.md) subnet. A subnet can also have zero, or one, associated network security group. 

When applied to a subnet, security rules are applied to all resources in the subnet. In addition to network interfaces, you may have instances of other Azure services such as HDInsight, Virtual Machine Scale Sets, and Application Service Environments deployed in the subnet.

How network security groups are applied when a network security group is associated to both a network interface, and the subnet the network interface is in, is as follows:

- **Inbound traffic**: The network security group associated to the subnet the network interface is in is evaluated first. Any traffic allowed through the network security group associated to the subnet is then evaluated by the network security group associated to the network interface. For example, you might require inbound access to a virtual machine over port 80 from the Internet. If you associate a network security group to both the network interface, and the subnet the network interface is in, the network security group associated to the subnet and the network interface must allow port 80. If you only allowed port 80 through the network security group associated to the subnet or the network interface the subnet is in, communication fails due to default security rules. See [default security rules](#default-security-rules) for details. If you only applied a network security group to either the subnet or the network interface, and the network security group contained a rule that allowed inbound port 80 traffic, for example, the communication succeeds. 
- **Outbound traffic**: The network security group associated to the network interface is evaluated first. Any traffic allowed through the network security group associated to the network interface is then evaluated by the network security group associated to the subnet.

You may not always be aware when network security groups are applied to both a network interface and a subnet. You can easily view the aggregate rules applied to a network interface by viewing the [effective security rules](virtual-network-manage-nsg-arm-portal.md) for a network interface. You can also use the [IP flow verify](../network-watcher/network-watcher-check-ip-flow-verify-portal.md?toc=%2fvirtual-network%2ftoc.json) capability in Azure Network Watcher to determine whether communication is allowed to or from a network interface. The tool tells you whether communication is allowed, and which network security rule allows or denies traffic.

> [!NOTE]
> Network security groups are associated to subnets or to virtual machines and cloud services deployed the classic deployment model, rather than to network interfaces in the Resource Manager deployment model. To learn more about Azure deployment models, see [Understand Azure deployment models](../azure-resource-manager/resource-manager-deployment-model.md?toc=%2fvirtual-network%2ftoc.json).

The same network security group can be applied to as many individual network interfaces and subnets as you choose.

## Security rules

A network security group contains zero, or as many rules as desired, within Azure subscription limits. Each rule specifies the following properties:

|Property  |Explanation  |
|---------|---------|
|Name|A unique name within the network security group.|
|Priority | A number between 100 and 4096. Rules are processed in priority order, with lower numbers processed before higher numbers, because lower numbers have higher priority. Once traffic matches a rule, processing stops. As a result, any rules that exist with lower priorities (higher numbers) that have the same attributes as rules with higher priorities are not processed.|
|Source or destination| Any, or an individual IP address, CIDR block (example 10.0.0.0/24, for example), service tag, or application security group. Learn more about [service tags](#service-tags) and [application security groups](#application-security-groups). Specifying a range, a service tag, or application security group, enables you to create fewer security rules. The ability to specify multiple individual IP addresses and ranges (you cannot specify multiple service tags or application groups) in a rule is in preview release and is referred to as augmented security rules. Augmented security rules can only be created in network security groups created through the Resource Manager deployment model. You cannot specify multiple IP addresses and IP address ranges in network security groups created through the classic deployment model.|
|Protocol     | TCP, UDP, or Any, which includes TCP, UDP, and ICMP. You cannot specify ICMP alone, so if you require ICMP, you must use Any. |
|Direction| Whether the rule applies to inbound, or outbound traffic.|
|Port range     |You can specify an individual or range of ports. For example, you could specify 80 or 10000-10005. Specifying ranges enables you to create fewer security rules. The ability to specify multiple individual ports and port ranges in a rule is in preview release and is referred to as augmented security rules. Before using augmented security rules, read [Preview features](#preview-features) for important information. Augmented security rules can only be created in network security groups created through the Resource Manager deployment model. You cannot specify multiple ports or port ranges in the same security rule in network security groups created through the classic deployment model.   |
|Action     | Allow or deny        |

**Considerations**

- **Virtual IP of the host node**: Basic infrastructure services such as DHCP, DNS, and health monitoring are provided through the virtualized host IP addresses 168.63.129.16 and 169.254.169.254. These public IP addresses belong to Microsoft and are the only virtualized IP addresses used in all regions for this purpose. The addresses map to the physical IP address of the server machine (host node) hosting the virtual machine. The host node acts as the DHCP relay, the DNS recursive resolver, and the probe source for the load balancer health probe and the machine health probe. Communication to these IP addresses is not an attack. If you block traffic to or from these IP addresses, a virtual machine may not function properly.
- **Licensing (Key Management Service)**: Windows images running in virtual machines must be licensed. To ensure licensing, a request is sent to the Key Management Service host servers that handle such queries. The request is made outbound through port 1688.
- **Virtual machines in load-balanced pools**: The source port and address range applied are from the originating computer, not the load balancer. The destination port and address range are for the destination computer, not the load balancer.
- **Azure service instances**: Instances of several Azure services, such as HDInsight, Application Service Environments, and Virtual Machine Scale Sets are deployed in virtual network subnets. Ensure you familiarize yourself with the port requirements for each service before applying a network security group to the subnet the resource is deployed in. If you deny ports required by the service, the service doesn't function properly. 

Security rules are stateful. If you specify an outbound security rule to any address over port 80, for example, it's not necessary to specify an inbound security rule for the response to the outbound traffic. You only need to specify an inbound security rule if communication is initiated externally. The opposite is also true. If inbound traffic is allowed over a port, it's not necessary to specify an outbound security rule to respond to traffic over the port. 

<!-- Not Available ## Augmented security rules-->
## Default security rules

If a network security group is not associated to a subnet or network interface, all traffic is allowed inbound to, or outbound from, the subnet, or network interface. As soon as a network security group is created, Azure creates the following default rules within the network security group:

### Inbound

#### AllowVNetInBound

|Priority|Source|Source ports|Destination|Destination ports|Protocol|Access|
|---|---|---|---|---|---|---|
|65000|VirtualNetwork|0-65535|VirtualNetwork|0-65535|All|Allow|

#### AllowAzureLoadBalancerInBound

|Priority|Source|Source ports|Destination|Destination ports|Protocol|Access|
|---|---|---|---|---|---|---|
|65001|AzureLoadBalancer|0-65535|0.0.0.0/0|0-65535|All|Allow|

#### DenyAllInbound

|Priority|Source|Source ports|Destination|Destination ports|Protocol|Access|
|---|---|---|---|---|---|---|
|65500|0.0.0.0/0|0-65535|0.0.0.0/0|0-65535|All|Deny|

### Outbound

#### AllowVnetOutBound

|Priority|Source|Source ports| Destination | Destination ports | Protocol | Access |
|---|---|---|---|---|---|---|
| 65000 | VirtualNetwork | 0-65535 | VirtualNetwork | 0-65535 | All | Allow |

#### AllowInternetOutBound

|Priority|Source|Source ports| Destination | Destination ports | Protocol | Access |
|---|---|---|---|---|---|---|
| 65001 | 0.0.0.0/0 | 0-65535 | Internet | 0-65535 | All | Allow |

#### DenyAllOutBound

|Priority|Source|Source ports| Destination | Destination ports | Protocol | Access |
|---|---|---|---|---|---|---|
| 65500 | 0.0.0.0/0 | 0-65535 | 0.0.0.0/0 | 0-65535 | All | Deny |

In the **Source** and **Destination** columns, *VirtualNetwork*, *AzureLoadBalancer*, and *Internet* are [service tags](#tags), rather than IP addresses. In the protocol column, **All** encompasses TCP, UDP, and ICMP. When creating a rule, you can specify TCP, UDP, or All, but you cannot specify ICMP alone. Therefore, if your rule requires ICMP, you must select *All* for protocol. *0.0.0.0/0* in the **Source** and **Destination** columns represents all addresses.

You cannot remove the default rules, but you can override them by creating rules with higher priorities.

<!--Not Available ## Service tags-->

<!-- Not Available ## Application security groups-->

## Next steps

* Complete the [Create a network security group](virtual-networks-create-nsg-arm-pportal.md) tutorial
<!-- Not Available * Complete the [Create a network security group with application security groups](create-network-security-group-preview.md) tutorial-->


<!--Update_Description: new articles on security overview -->