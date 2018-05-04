---
title: Azure CLI samples for virtual network | Azure
description: Azure CLI samples for virtual network.
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
origin.date: 03/20/2018
ms.date: 05/07/2018
ms.author: v-yeche

---
# Azure CLI samples for virtual network

The following table includes links to bash scripts with Azure CLI commands:

| | |
|----|----|
| [Create a virtual network for multi-tier applications](./scripts/virtual-network-cli-sample-multi-tier-application.md) | Creates a virtual network with front-end and back-end subnets. Traffic to the front-end subnet is limited to HTTP and SSH, while traffic to the back-end subnet is limited to MySQL, port 3306. |
| [Peer two virtual networks](./scripts/virtual-network-cli-sample-peer-two-virtual-networks.md) | Creates and connects two virtual networks in the same region. |
| [Route traffic through a network virtual appliance](./scripts/virtual-network-cli-sample-route-traffic-through-nva.md) | Creates a virtual network with front-end and back-end subnets and a VM that is able to route traffic between the two subnets. |
| [Filter inbound and outbound VM network traffic](./scripts/virtual-network-cli-sample-filter-network-traffic.md) | Creates a virtual network with front-end and back-end subnets. Inbound network traffic to the front-end subnet is limited to HTTP, HTTPS, and SSH. Outbound traffic to the internet from the back-end subnet is not permitted. |
<!-- Update_Description: new articles on cli samples  -->
<!--ms.date: 05/07/2018-->