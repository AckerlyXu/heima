<properties 
	pageTitle="How to Create a Media Processor | Azure" 
	description="Learn how to create a media processor component to encode, convert format, encrypt, or decrypt media content for Azure Media Services. Code samples are written in C# and use the Media Services SDK for .NET." 
	services="media-services" 
	documentationCenter="" 
	authors="juliako" 
	manager="erikre" 
	editor=""/>

<tags 
	ms.service="media-services" 
	ms.workload="media" 
	ms.tgt_pltfrm="na" 
	ms.devlang="na" 
	ms.topic="article" 
	ms.date="09/26/2016" 
	ms.author="juliako"/>


#How to: Get a Media Processor Instance

> [AZURE.SELECTOR]
- [.NET](/documentation/articles/media-services-get-media-processor/)
- [REST](/documentation/articles/media-services-rest-get-media-processor/)


##Overview

In Media Services a media processor is a component that handles a specific processing task, such as encoding, format conversion, encrypting, or decrypting media content. You typically create a media processor when you are creating a task to encode, encrypt, or convert the format of media content.

The following table provides the name and description of each available media processor.

Media Processor Name|Description|More Information
---|---|---
Media Encoder Standard|Provides standard capabilities for on-demand encoding. |[Overview and Comparison of Azure On Demand Media Encoders](/documentation/articles/media-services-encode-asset/)
Media Encoder Premium Workflow|Lets you run encoding tasks using Media Encoder Premium Workflow.|[Overview and Comparison of Azure On Demand Media Encoders](/documentation/articles/media-services-encode-asset/)
Azure Media Indexer| Enables you to make media files and content searchable, as well as generate closed captioning tracks and keywords.|[Azure Media Indexer](/documentation/articles/media-services-index-content/).
Azure Media Hyperlapse (preview)|Enables you to smooth out the "bumps" in your video with video stabilization. Also allows you to speed up your content into a consumable clip.|[Azure Media Hyperlapse](/documentation/articles/media-services-hyperlapse-content/)
Azure Media Encoder|Depreciated
Storage Decryption| Depreciated|
Azure Media Packager|Depreciated|
Azure Media Encryptor|Depreciated|

##Get Media Processor

The following method shows how to get a media processor instance. The code example assumes the use of a module-level variable named **_context** to reference the server context as described in the section [How to: Connect to Media Services Programmatically](/documentation/articles/media-services-dotnet-connect-programmatically/).

	private static IMediaProcessor GetLatestMediaProcessorByName(string mediaProcessorName)
	{
		var processor = _context.MediaProcessors.Where(p => p.Name == mediaProcessorName).
		ToList().OrderBy(p => new Version(p.Version)).LastOrDefault();
		
		if (processor == null)
		throw new ArgumentException(string.Format("Unknown media processor", mediaProcessorName));
		
		return processor;
	}



##Next Steps

Now that you know how to get a media processor instance, go to the [How to Encode an Asset](/documentation/articles/media-services-dotnet-encode-with-media-encoder-standard/) topic which will show you how to use the Media Encoder Standard to encode an asset.


