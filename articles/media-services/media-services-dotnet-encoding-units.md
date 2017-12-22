---
title: Scale media processing by adding encoding units - Azure |  Microsoft Docs
description: Learn how to how to add encoding units with .NET
services: media-services
documentationcenter: ''
author: yunan2016
manager: digimobile

editor: ''

ms.assetid: 33f7625a-966a-4f06-bc09-bccd6e2a42b5
ms.service: media-services
ms.workload: media
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 12/16/2017
ms.date: 12/25/2017
ms.author: v-nany


---
# How to scale encoding with .NET SDK
> [!div class="op_single_selector"]
> * [Portal](media-services-portal-scale-media-processing.md)
> * [.NET](media-services-dotnet-encoding-units.md)
> * [REST](https://docs.microsoft.com/rest/api/media/operations/encodingreservedunittype)
> * [Java](https://github.com/southworkscom/azure-sdk-for-media-services-java-samples)
> * [PHP](https://github.com/Azure/azure-sdk-for-php/tree/master/examples/MediaServices)
> 
> 

> [!NOTE]
> To get the latest version of Java SDK and get started developing with Java, see [Get started with the Java client SDK for Media Services](media-services-java-how-to-use.md). <br/>
> To download the latest PHP SDK for Media Services, look for version 0.5.7 of the Microsoft/WindowAzure package in the [Packagist repository](https://packagist.org/packages/microsoft/windowsazure#v0.5.7).  

## Overview
> [!IMPORTANT]
> Make sure to review the [overview](media-services-scale-media-processing-overview.md) topic to get more information about scaling media processing topic.
> 
> 

To change the reserved unit type and the number of encoding reserved units using .NET SDK, do the following:

    IEncodingReservedUnit encodingS1ReservedUnit = _context.EncodingReservedUnits.FirstOrDefault();
    encodingS1ReservedUnit.ReservedUnitType = ReservedUnitType.Basic; // Corresponds to S1
    encodingS1ReservedUnit.Update();
    Console.WriteLine("Reserved Unit Type: {0}", encodingS1ReservedUnit.ReservedUnitType);

    encodingS1ReservedUnit.CurrentReservedUnits = 2;
    encodingS1ReservedUnit.Update();

    Console.WriteLine("Number of reserved units: {0}", encodingS1ReservedUnit.CurrentReservedUnits);

<!--Update_Description: remove support ticket related content-->