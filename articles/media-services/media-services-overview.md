---
title: Azure Media Services overview | Azure
description: This topic gives an overview of Azure Media Services
services: media-services
documentationcenter: ''
author: yunan2016
manager: digimobile
editor: ''

ms.assetid: 7a5e9723-c379-446b-b4d6-d0e41bd7d31f
ms.service: media-services
ms.workload: media
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: hero-article
origin.date: 10/24/2017
ms.date: 12/11/2017
ms.author: v-nany

---
# Azure Media Services overview

Microsoft Azure Media Services is an extensible cloud-based platform that enables developers to build scalable media management and delivery applications. Media Services is based on REST APIs that enable you to securely upload, store, encode, and package video or audio content for both on-demand and live streaming delivery to various clients (for example, TV, PC, and mobile devices).

You can build end-to-end workflows using entirely Media Services. You can also choose to use third-party components for some parts of your workflow. For example, encode using a third-party encoder. Then, upload, protect, package, deliver using Media Services.

You can choose to stream your content live or deliver content on-demand. The topic also links to other relevant topics.

## Prerequisites

To start using Azure Media Services, you should have the following:

* An Azure account. If you don't have an account, you can create a trial account in just a couple of minutes. For details, see [Azure 1rmb Trial](https://www.azure.cn/pricing/1rmb-trial/).
* An Azure Media Services account. For more information, see [Create Account](media-services-portal-create-account.md).
* (Optional) Set up development environment. Choose .NET or REST API for your development environment. For more information, see [Set up environment](media-services-dotnet-how-to-use.md).

    Also, learn how to [connect  programmatically to AMS API](media-services-use-aad-auth-to-access-ams-api.md).
* A standard or premium streaming endpoint in started state.  For more information, see [Managing streaming endpoints](media-services-portal-manage-streaming-endpoints.md)

## SDKs and tools

To build Media Services solutions, you can use:

* [Media Services REST API](https://docs.microsoft.com/rest/api/media/operations/azure-media-services-rest-api-reference)
* One of the available client SDKs:
  * [Azure Media Services SDK for .NET](https://github.com/Azure/azure-sdk-for-media-services),
  * [Azure SDK for Java](https://github.com/Azure/azure-sdk-for-java),
  * [Azure PHP SDK](https://github.com/Azure/azure-sdk-for-php),
  * [Azure Media Services for Node.js](https://github.com/michelle-becker/node-ams-sdk/blob/master/lib/request.js) (This is a non-Microsoft version of a Node.js SDK. It is maintained by a community and currently does not have a 100% coverage of the AMS APIs).
* Existing tools:
  * [Azure portal](https://portal.azure.cn/)
  * [Azure-Media-Services-Explorer](https://github.com/Azure/Azure-Media-Services-Explorer) (Azure Media Services Explorer (AMSE) is a Winforms/C# application for Windows)

## Code samples

Find multiple code samples in the **Azure Code Samples** gallery: [Azure Media Services code samples](https://azure.microsoft.com/resources/samples/?service=media-services&sort=0).

## Concepts and overview

For Azure Media Services concepts, see [Concepts](media-services-concepts.md).

For a how-to series that introduces you to all the main components of Azure Media Services, see [Azure Media Services Step-by-Step tutorials](https://docs.com/shigeyf/1220/azure-media-services-step-by-step-tutorial-series). This series has a great overview of concepts and it uses the AMSE tool to demonstrate AMS tasks. AMSE tool is a Windows tool. This tool supports most of the tasks you can achieve programmatically with [AMS SDK for .NET](https://github.com/Azure/azure-sdk-for-media-services), [Azure SDK for Java](https://github.com/Azure/azure-sdk-for-java), or  [Azure PHP SDK](https://github.com/Azure/azure-sdk-for-php).

## Supported scenarios and availability of Media Services across data centers

For detailed information, see [AMS scenarios and availability of features and services across data centers](scenarios-and-availability.md).

## Service Level Agreement (SLA)

* For Media Services Encoding, we guarantee 99.9% availability of REST API transactions.
* For Streaming, we will successfully service requests with a 99.9% availability guarantee for existing media content when a standard or premium streaming endpoint is purchased.
* For Live Channels, we guarantee that running Channels will have external connectivity at least 99.9% of the time.
* For Content Protection, we guarantee that we will successfully fulfill key requests at least 99.9% of the time.
* For Indexer, we will successfully service Indexer Task requests processed with an Encoding Reserved Unit 99.9% of the time.

For more information, see [Azure SLA](https://www.azure.cn/support/legal/sla/).

For information about availability in datacenters, see the [Availability](scenarios-and-availability.md#availability) section.

## Support
[Azure Support](https://www.azure.cn/support/contact/) provides support options for Azure, including Media Services.
<!--Update_Description: wording update-->