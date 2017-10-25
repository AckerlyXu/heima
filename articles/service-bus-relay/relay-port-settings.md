---
title: Azure Relay port settings | Microsoft Docs
description: Details about Azure Relay port values.
services: service-bus-relay
documentationcenter: na
author: sethmanheim
manager: timlt
editor: ''

ms.assetid: 
ms.service: service-bus-relay
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: na
origin.date: 10/05/2017
ms.author: v-yiso
ms.date: 11/06/2017
---

# Azure Relay port settings

The following table describes the required configuration for port values for Azure Relay.

## Hybrid Connections
Hybrid Connections uses WebSockets as the underlying transport mechanism, which uses **HTTPS** only. 

## WCF Relays
  
|Binding|Transport Security|Port|  
|-------------|------------------------|----------|  
|[BasicHttpRelayBinding Class](https://docs.microsoft.com/dotnet/api/microsoft.servicebus.basichttprelaybinding) (client)|Yes|HTTPS| 
| |" |No|HTTP|  
|[BasicHttpRelayBinding Class](https://docs.microsoft.com/dotnet/api/microsoft.servicebus.basichttprelaybinding) (service)|Either|9351/HTTP|  
|[NetEventRelayBinding Class](https://docs.microsoft.com/dotnet/api/microsoft.servicebus.neteventrelaybinding) (client)|Yes|9351/HTTPS|  
||" |No|9350/HTTP|  
|[NetEventRelayBinding Class](https://docs.microsoft.com/dotnet/api/microsoft.servicebus.neteventrelaybinding) (service)|Either|9351/HTTP|  
|[NetTcpRelayBinding Class](https://docs.microsoft.com/dotnet/api/microsoft.servicebus.nettcprelaybinding) (client/service)|Either|5671/9352/HTTP (9352/9353 if using hybrid)|  
|[NetOnewayRelayBinding Class](https://docs.microsoft.com/dotnet/api/microsoft.servicebus.netonewayrelaybinding) (client)|Yes|9351/HTTPS|  
||" |No|9350/HTTP|  
|[NetOnewayRelayBinding Class](https://docs.microsoft.com/dotnet/api/microsoft.servicebus.netonewayrelaybinding) (service)|Either|9351/HTTP|  
|[WebHttpRelayBinding Class](https://docs.microsoft.com/dotnet/api/microsoft.servicebus.webhttprelaybinding) (client)|Yes|HTTPS|  
||" |No|HTTP|  
|[WebHttpRelayBinding Class](https://docs.microsoft.com/dotnet/api/microsoft.servicebus.webhttprelaybinding) (service)|Either|9351/HTTP|  
|[WS2007HttpRelayBinding Class](https://docs.microsoft.com/dotnet/api/microsoft.servicebus.ws2007httprelaybinding) (client)|Yes|HTTPS|  
||" |No|HTTP|  
|[WS2007HttpRelayBinding Class](https://docs.microsoft.com/dotnet/api/microsoft.servicebus.ws2007httprelaybinding) (service)|Either|9351/HTTP|

## Next steps
To learn more about Azure Relay, visit these links:
* [What is Azure Relay?](./relay-what-is-it.md)
* [Relay FAQ](./relay-faq.md)


<!--Update_Description:update meta properties only-->