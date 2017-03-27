<properties
    pageTitle="ExpressRoute connectivity models: Connect to Microsoft Azure through network service providers, exchanges, and Ethernet providers | Azure"
    description="This article describes the different modes of connectivity between the customer's network and Microsoft Azure, Office 365 and Dynamics 365 services. Customers can use MPLS providers, cloud exchanges and Ethernet providers."
    documentationcenter="na"
    services="expressroute"
    author="cherylmc"
    manager="timlt"
    editor="" />
<tags
    ms.assetid="ms.service: expressroute"
    ms.devlang="na"
    ms.topic="get-started-article"
    ms.tgt_pltfrm="na"
    ms.workload="infrastructure-services"
    ms.date="02/09/2017"
    wacn.date=""
    ms.author="cherylmc" />

# ExpressRoute connectivity models
You can create a connection between your on-premises network and the Microsoft cloud in three different ways, [CloudExchange Co-location](#CloudExchange), [Point-to-point Ethernet Connection](#Ethernet), and [Any-to-any (IPVPN) Connection](#IPVPN). Connectivity providers can offer one or more connectivity models. You can work with your connectivity provider to pick the model that works best for you.
<br><br>

![ExpressRoute connectivity model diagram](./media/expressroute-connectivity-models/expressroute-connectivity-models-diagram.png)

## <a name="CloudExchange"></a>Co-located at a cloud exchange
If you are co-located in a facility with a cloud exchange, you can order virtual cross-connections to the Microsoft cloud through the co-location provider’s Ethernet exchange. Co-location providers can offer either Layer 2 cross-connections, or managed Layer 3 cross-connections between your infrastructure in the co-location facility and the Microsoft cloud.

## <a name="Ethernet"></a>Point-to-point Ethernet connections
You can connect your on-premises datacenters/offices to the Microsoft cloud through point-to-point Ethernet links. Point-to-point Ethernet providers can offer Layer 2 connections, or managed Layer 3 connections between your site and the Microsoft cloud.

## <a name="IPVPN"></a>Any-to-any (IPVPN) networks
You can integrate your WAN with the Microsoft cloud. IPVPN providers (typically MPLS VPN) offer any-to-any connectivity between your branch offices and datacenters. The Microsoft cloud can be interconnected to your WAN to make it look just like any other branch office. WAN providers typically offer managed Layer 3 connectivity. ExpressRoute capabilities and features are all identical across all of the above connectivity models. 

## Next steps
* Learn about ExpressRoute connections and routing domains. See [ExpressRoute circuits and routing domains](/documentation/articles/expressroute-circuit-peerings/).
* Learn about ExpressRoute features. See the [ExpressRoute Technical Overview](/documentation/articles/expressroute-introduction/)
* Find a service provider. See [ExpressRoute partners and peering locations](/documentation/articles/expressroute-locations/).
* Ensure that all prerequisites are met. See [ExpressRoute prerequisites](/documentation/articles/expressroute-prerequisites/).
* Refer to the requirements for [Routing](/documentation/articles/expressroute-routing/).
* Configure your ExpressRoute connection.
  * [Create an ExpressRoute circuit](/documentation/articles/expressroute-howto-circuit-portal-resource-manager/)
  * [Configure routing](/documentation/articles/expressroute-howto-routing-portal-resource-manager/)
  * [Link a VNet to an ExpressRoute circuit](/documentation/articles/expressroute-howto-linkvnet-portal-resource-manager/)