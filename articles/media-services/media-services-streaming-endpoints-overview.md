---

title: Azure Media Services Streaming Endpoint overview | Azure 
description: This topic gives an overview of Azure Media Services streaming endpoints.
services: media-services
documentationcenter: ''
author: Juliako
writer: juliako
manager: erikre
editor: ''

ms.assetid: 097ab5e5-24e1-4e8e-b112-be74172c2701
ms.service: media-services
ms.workload: media
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 06/29/2017
ms.date: 08/07/2017
ms.author: v-haiqya

---
# Streaming endpoints overview

## Overview

In Azure Media Services (AMS), a **Streaming Endpoint** represents a streaming service that can deliver content directly to a client player application, or to a Content Delivery Network (CDN) for further distribution. Media Services also provides seamless Azure CDN integration. The outbound stream from a StreamingEndpoint service can be a live stream, a video on demand, or progressive download of your asset in your Media Services account. Each Azure Media Services account includes a default StreamingEndpoint. Additional StreamingEndpoints can be created under the account. There are two versions of StreamingEndpoints, 1.0 and 2.0. Starting with January 10th 2017, any newly created AMS accounts will include version 2.0 **default** StreamingEndpoint. Additional streaming endpoints that you add to this account will also be version 2.0. This change will not impact the existing accounts; existing StreamingEndpoints will be version 1.0 and can be upgraded to version 2.0. With this change there will be behavior, billing and feature changes (for more information, see the **Streaming types and versions** section documented below).

In addition, starting with the 2.15 version (released in January 2017), Azure Media Services added the following properties to the Streaming Endpoint entity: **CdnProvider**, **CdnProfile**, **FreeTrialEndTime**, **StreamingEndpointVersion**. For detailed overview of these properties, see [this](https://docs.microsoft.com/rest/api/media/operations/streamingendpoint).

When you create an Azure Media Services account a default Classic streaming endpoint is created for you in the **Stopped** state. You cannot delete the default streaming endpoint.

>[!NOTE]
>Azure CDN integration can be disabled before starting the streaming endpoint.

This topic gives an overview of the main functionalities that are provided by streaming endpoints.

## Streaming types and versions

### Premium types (version 2.0)

Starting with the January 2017 release of Media Services, you have a new streaming types: **Premium**. This type is the Streaming endpoint version "2.0".

Type|Description
---|---
**Premium**|This option is suitable for professional scenarios that require higher scale or control.<br/>Variable SLA that is based on premium streaming unit (SU) capacity purchased, dedicated streaming endpoints live in isolated environment and do not compete for resources.

For more detailed information, see the **Compare Streaming types** following section.

### Classic type (version 1.0)

For users who created AMS accounts prior to the January 10 2017 release, you have a **Classic** type of a streaming endpoint. This type is part of the streaming endpoint version "1.0".

If your **version "1.0"** streaming endpoint has >=1 premium streaming units (SU), it will be premium streaming endpoint and will provide all AMS features (just like the **Premium** type) without any additional configuration steps.

>[!NOTE]
>**Classic** streaming endpoints (version "1.0" and 0 SU), provides limited features and doesn't include a SLA. It is recommended to migrate to **Premium** type to get a better experience and to use features like dynamic packaging or encryption and other features that come with the **Premium** type. To migrate to the **Premium** type, go to the [Azure portal](https://portal.azure.cn/) and select **Opt-in to Premium**. For more information about migration, see the [migration](#migration-between-types) section.
>
>Beware that this operation cannot be rolled back and has a pricing impact.
>

## Comparing streaming types

### Versions

|Type|StreamingEndpointVersion|ScaleUnits|CDN|Billing|SLA| 
|--------------|----------|-----------------|-----------------|-----------------|-----------------|
|Classic|1.0|0|NA|Free|NA|
|Premium Streaming Units|1.0|>0|Yes|Paid|Yes|
|Premium Streaming Units|2.0|>0|Yes|Paid|Yes|

### Features

Feature|Premium
---|---
Free first 15 days|No
Throughput |200 Mbps per streaming unit (SU). Scales with CDN.
SLA |99.9(200 Mbps per SU).
CDN|Azure CDN, third party CDN, or no CDN.
Billing is prorated|Daily
Dynamic encryption|Yes
Dynamic packaging|Yes
Scale|Additional streaming units
IP filtering/G20/Custom host|Yes
Progressive download|Yes
Recommended usage |Professional usage.<br/>If you think you may have needs beyond Classic. Contact us (amsstreaming at microsoft.com) if you expect a concurrent audience size larger than 50,000 viewers.

## Migration between types

From | To | Action
---|---|---
Classic|Premium| Scale(additional streaming units)
Premium|Classic|Not available(If streaming endpoint version is 1.0. It is allowed to change to classic with setting scaleunits to "0")
Version 1.0 with SU >= 1 with CDN|Premium with no CDN|Allowed in the **stopped** state. Not allowed in the **started** state.
Version 1.0 with SU >= 1 with CDN|Premium with/without CDN|Allowed in the **stopped** state. Not allowed in the **started** state. Classic CDN will be deleted and new one created and started.

<!--Update_Description:new file stander type is not use in ACN-->