<properties
    pageTitle="Overview and comparison of Azure on demand media encoders | Azure"
    description="This topic gives an overview and comparison of Azure on demand media encoders."
    services="media-services"
    documentationcenter=""
    author="juliako"
    manager="erikre"
    editor="" />
<tags
    ms.assetid="e6bfc068-fa46-4d68-b1ce-9092c8f3a3c9"
    ms.service="media-services"
    ms.workload="media"
    ms.tgt_pltfrm="na"
    ms.devlang="na"
    ms.topic="article"
    ms.date="01/05/2017"
    wacn.date=""
    ms.author="juliako" />

#Overview and comparison of Azure on demand media encoders

##Encoding overview

Azure Media Services provides multiple options for the encoding of media in the cloud.

When starting out with Media Services, it is important to understand the difference between codecs and file formats.
Codecs are the software that implements the compression/decompression algorithms whereas file formats are containers that hold the compressed video.

Media Services provides dynamic packaging which allows you to deliver your adaptive bitrate MP4 or Smooth Streaming encoded content in streaming formats supported by Media Services (MPEG DASH, HLS, Smooth Streaming) without you having to re-package into these streaming formats.

>[AZURE.NOTE]
>When your AMS account is created a **default** streaming endpoint is added to your account in the **Stopped** state. To start streaming your content and take advantage of dynamic packaging and dynamic encryption, the streaming endpoint from which you want to stream content has to be in the **Running** state. 
To take advantage of [dynamic packaging](/documentation/articles/media-services-dynamic-packaging-overview/), you need to do the following:
>
>Also, encode your source file into a set of adaptive bitrate MP4 files or adaptive bitrate Smooth Streaming files (the encoding steps are demonstrated later in this tutorial).

Media Services supports the following on demand encoders that are described in this article:

- [Media Encoder Standard](/documentation/articles/media-services-encode-asset.md/#media-encoder-standard)
- [Media Encoder Premium Workflow](/documentation/articles/media-services-encode-asset/#media-encoder-premium-workflow)

This article gives a brief overview of on demand media encoders and provides links to articles that give more detailed information. The topic also provides comparison of the encoders.

Note that by default each Media Services account can have one active encoding task at a time. You can reserve encoding units that allow you to have multiple encoding tasks running concurrently, one for each encoding reserved unit you purchase. For information, see [Scaling encoding units](/documentation/articles/media-services-scale-media-processing-overview/).

##Media Encoder Standard

###How to use

[How to encode with Media Encoder Standard](/documentation/articles/media-services-dotnet-encode-with-media-encoder-standard/)

###Formats

[Formats and codecs](/documentation/articles/media-services-media-encoder-standard-formats/)

###Presets

Media Encoder Standard is configured using one of the encoder presets described [here](https://docs.microsoft.com/azure/media-services/media-services-mes-presets-overview).

### Input and output metadata
The encoders input metadata is described [here](/documentation/articles/media-services-input-metadata-schema/).

The encoders output metadata is described [here](/documentation/articles/media-services-output-metadata-schema/).

###Generate thumbnails

For information, see [How to generate thumbnails using Media Encoder Standard](/documentation/articles/media-services-advanced-encoding-with-mes/#thumbnails).

###Trim videos (clipping)

For information, see [How to trim videos using Media Encoder Standard](/documentation/articles/media-services-advanced-encoding-with-mes/#trim_video).

###Create overlays

For information, see [How to create overlays using Media Encoder Standard](/documentation/articles/media-services-advanced-encoding-with-mes/#overlay).

###See also

[The Media Services blog](https://azure.microsoft.com/blog/2015/07/16/announcing-the-general-availability-of-media-encoder-standard/)
 
##Media Encoder Premium Workflow

###Overview

[Introducing Premium Encoding in Azure Media Services](https://azure.microsoft.com/blog/2015/03/05/introducing-premium-encoding-in-azure-media-services/)

###How to use

Media Encoder Premium Workflow is configured using complex workflows. Workflow files could be created and updated using the [Workflow Designer](/documentation/articles/media-services-workflow-designer/) tool.

[How to Use Premium Encoding in Azure Media Services](https://azure.microsoft.com/blog/2015/03/06/how-to-use-premium-encoding-in-azure-media-services/)

### Known issues
If your input video does not contain closed captioning, the output Asset will still contain an empty TTML file.


## Related articles
* [Perform advanced encoding tasks by customizing Media Encoder Standard presets](/documentation/articles/media-services-custom-mes-presets-with-dotnet/)
* [Quotas and Limitations](/documentation/articles/media-services-quotas-and-limitations/)

<!--Reference links in article-->
[1]: /pricing/details/media-services/
