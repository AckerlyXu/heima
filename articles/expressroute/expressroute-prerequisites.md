---
title: Prerequisites for ExpressRoute adoption | Azure
description: This page provides a list of requirements to be met before you can order an Azure ExpressRoute circuit.
documentationCenter: na
services: expressroute
authors: cherylmc
manager: carmonm
editor: ''

ms.service: expressroute
ms.devlang: na
ms.topic: get-started-article
ms.tgt_pltfrm: na
ms.workload: infrastructure-services
ms.date: 01/06/2017
ms.author: cherylmc
---

# ExpressRoute prerequisites & checklist  

To connect to Microsoft cloud services using ExpressRoute, you need to verify that the following requirements listed in the following sections have been met.

[!INCLUDE [expressroute-office365-include](../../includes/expressroute-office365-include.md)]

## Azure account
* A valid and active Microsoft Azure account. This account is required to set up the ExpressRoute circuit. ExpressRoute circuits are resources within Azure subscriptions. An Azure subscription is a requirement even if connectivity is limited to non-Azure Microsoft cloud services, such as Office 365 services and CRM online.
* An active Office 365 subscription (if using Office 365 services). For more information, see the [Office 365 specific requirements](#office-365-specific-requirements) section of this article.

## Connectivity provider
- You can work with an [ExpressRoute connectivity partner](./expressroute-locations.md#partners) to connect to the Microsoft cloud. You can set up a connection between your on-premises network and Microsoft in [three ways](./expressroute-introduction.md). 
- If your provider is not an ExpressRoute connectivity partner, you can still connect to the Microsoft cloud through a [cloud exchange provider](./expressroute-locations.md#nonpartners).

## Network requirements
- **Redundant connectivity**: there is no redundancy requirement on physical connectivity between you and your provider. Microsoft does require redundant BGP sessions to be set up between Microsoft’s routers and the peering routers, even when you have just [one physical connection to a cloud exchange](./expressroute-faqs.md#onep2plink). 
- **Routing**: depending on how you connect to the Microsoft Cloud, you or your provider need to set up and manage the BGP sessions for [routing domains](./expressroute-circuit-peerings.md). Some Ethernet connectivity provider or cloud exchange provider may offer BGP management as a value-add service.



## Next steps

- For more information about ExpressRoute, see the [ExpressRoute FAQ](./expressroute-faqs.md).
- Find an ExpressRoute connectivity provider. See [ExpressRoute partners and peering locations](./expressroute-locations.md).
- Refer to requirements for [Routing](./expressroute-routing.md).
- Configure your ExpressRoute connection.
    - [Create an ExpressRoute circuit](./expressroute-howto-circuit-classic.md)
    - [Configure routing](./expressroute-howto-routing-classic.md)
    - [Link a VNet to an ExpressRoute circuit](./expressroute-howto-linkvnet-classic.md)