---
title: Azure Event Hubs Capture enable through portal | Azure
description: Enable the Event Hubs Capture feature using the Azure portal.
services: event-hubs
documentationcenter: ''
author: rockboyfor
manager: digimobile
editor: ''

ms.assetid: 
ms.service: event-hubs
ms.workload: na
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: get-started-article
origin.date: 08/28/2017
ms.date: 09/25/2017
ms.author: v-yeche

---

# Enable Event Hubs Capture using the Azure portal

Azure [Event Hubs Capture][capture-overview] enables you to automatically deliver the streaming data in Event Hubs to an [Azure Blob storage](https://www.azure.cn/home/features/storage/) account of your choice.
<!-- Not Available [Azure Data Lake Store](https://www.azure.cn/home/features/data-lake-store/) -->

You can configure Capture at the event hub creation time using the [Azure portal](https://portal.azure.cn). You can either capture the data to an Azure [Blob storage](https://www.azure.cn/home/features/storage/) container.
<!-- Not Available [Azure Data Lake Store](https://www.azure.cn/home/features/data-lake-store/) account.-->

For more information, see the [Event Hubs Capture overview][capture-overview].

## Capture data to an Azure Storage account  

When you create an event hub, you can enable Capture by clicking the **On** button in the **Create Event Hub** portal screen. You then specify a Storage Account and container by clicking **Azure Storage** in the **Capture Provider** box. Because Event Hubs Capture uses service-to-service authentication with storage, you do not need to specify a storage connection string. The resource picker selects the resource URI for your storage account automatically. If you use Azure Resource Manager, you must supply this URI explicitly as a string.

The default time window is 5 minutes. The minimum value is 1, the maximum 15. The **Size** window has a range of 10-500 MB.

![][1]

<!-- Not Available ## Capture data to an Azure Data Lake Store account-->
## Add or configure Capture on an existing event hub

You can configure Capture on existing event hubs that are in Event Hubs namespaces. To enable Capture on an existing event hub, or to change your Capture settings, click the namespace to load the **Essentials** screen, then click the event hub for which you want to enable or change the Capture setting. Finally, click the **Properties** section of the open page and then edit the Capture settings, as shown in the following figures:

### Azure Blob Storage

![][2]

<!-- Not Available ### Azure Data Lake Store-->
[1]: ./media/event-hubs-capture-enable-through-portal/event-hubs-capture1.png
[2]: ./media/event-hubs-capture-enable-through-portal/event-hubs-capture2.png
[3]: ./media/event-hubs-capture-enable-through-portal/event-hubs-capture3.png
[4]: ./media/event-hubs-capture-enable-through-portal/event-hubs-capture4.png

## Next steps

- Learn more about Event Hubs capture by reading the [Event Hubs Capture overview][capture-overview].
- You can also configure Event Hubs Capture using Azure Resource Manager templates. For more information, see [Enable Capture using an Azure Resource Manager template](event-hubs-resource-manager-namespace-event-hub-enable-capture.md).
<!--Not available - [Get started with Azure Data Lake Store using the Azure portal](../data-lake-store/data-lake-store-get-started-portal.md)-->
[capture-overview]: event-hubs-capture-overview.md

<!--Update_Description: update meta properties, wording update-->