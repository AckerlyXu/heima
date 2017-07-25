---
title: Create a Service Bus namespace in the Azure portal | Azure
description: Create a Service Bus namespace using the Azure portal.
services: service-bus
documentationCenter: .net
author: sethmanheim
manager: timlt
editor: ''

ms.assetid: fbb10e62-b133-4851-9d27-40bd844db3ba
ms.service: service-bus
ms.devlang: tbd
ms.topic: get-started-article
ms.tgt_pltfrm: dotnet
ms.workload: na
origin.date: 06/27/2017
ms.author: v-yiso
ms.date: 08/21/2017
---

# Create a Service Bus namespace using the Azure portal

A namespace is a scoping container for all messaging components. Multiple queues and topics can reside within a single namespace, and namespaces often serve as application containers. There are two different ways to create a Service Bus namespace:

1. Azure portal (this article)

2. [Resource Manager templates][create-namespace-using-arm]

## Create a namespace in the Azure portal

[!INCLUDE [service-bus-create-namespace-portal](../../includes/service-bus-create-namespace-portal.md)]

Congratulations! You have now created a Service Bus Messaging namespace.

## Next steps

Check out our [GitHub samples][github-samples], which show some of the more advanced features of Azure Service Bus Messaging.

[create-namespace-using-arm]: ./service-bus-resource-manager-overview.md
[github-samples]: https://github.com/Azure/azure-service-bus/tree/master/samples

<!--Update_Description:update meta properties and link references-->