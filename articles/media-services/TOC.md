# [Overview](media-services-overview.md)
## [Concepts ](media-services-concepts.md)

# Get started
## [Create and manage account](media-services-create-account.md)
## [Set up your dev environment](media-services-set-up-computer.md)
###[.NET](media-services-dotnet-how-to-use.md)
###[REST](media-services-rest-how-to-use.md)  
## Connect programmatically with ACS keys
### [.NET](media-services-dotnet-connect-programmatically.md)
### [REST](media-services-rest-connect-programmatically.md)

## Deliver video on demand
### [.NET SDK](media-services-dotnet-get-started.md)
### [Java](media-services-java-how-to-use.md)
### [REST](media-services-rest-get-started.md)
## Perform live streaming
### [.NET](media-services-dotnet-live-encode-with-onpremises-encoders.md)

# How To
## Manage
### Accounts
#### [PowerShell](media-services-manage-with-powershell.md)
#### [REST](https://docs.microsoft.com/rest/api/media/mediaservice)
### Entities
#### [.NET](media-services-dotnet-manage-entities.md)
#### [REST](media-services-rest-manage-entities.md)
### Storage
#### [Update Media Services after rolling storage access keys](media-services-roll-storage-access-keys.md)
#### [Manage assets across multiple storage accounts](meda-services-managing-multiple-storage-accounts.md)
### [Quotas and limitations](media-services-quotas-and-limitations.md)

## Upload content
### Upload files into an account
#### [.NET](media-services-dotnet-upload-files.md)
#### [REST](media-services-rest-upload-files.md)
### [Copy existing blobs](media-services-copying-existing-blob.md)

## [Encode content](media-services-encode-asset.md)
### [Manage speed and concurrency of your encoding](media-services-manage-encoding-speed.md)
### Media Encoder Standard (MES)
#### [Media Encoder Standard Formats and Codecs](media-services-media-encoder-standard-formats.md)
#### [Use MES to auto-generate a bitrate ladder](media-services-autogen-bitrate-ladder-with-mes.md)
#### Encode with Media Encoder Standard
##### [.NET](media-services-dotnet-encode-with-media-encoder-standard.md)
##### [REST](media-services-rest-encode-asset.md)
#### [Advanced encoding with MES](media-services-advanced-encoding-with-mes.md)
##### [Customize Media Encoder Standard presets](media-services-custom-mes-presets-with-dotnet.md)
##### [How to generate thumbnails using Media Encoder Standard with .NET](media-services-dotnet-generate-thumbnail-with-mes.md)
##### [Crop videos with Media Encoder Standard](media-services-crop-video.md)
#### MES Schemas
##### [Media Encoder Standard schema](media-services-mes-schema.md)
##### [Input metadata](media-services-input-metadata-schema.md)
##### [Output metadata](media-services-output-metadata-schema.md)
#### [MES Presets](media-services-mes-presets-overview.md) 
##### [H264 Multiple Bitrate 1080p Audio 5.1](media-services-mes-preset-H264-Multiple-Bitrate-1080p-Audio-5.1.md)
##### [H264 Multiple Bitrate 1080p](media-services-mes-preset-H264-Multiple-Bitrate-1080p.md)
##### [H264 Multiple Bitrate 16x9 SD Audio 5.1](media-services-mes-preset-H264-Multiple-Bitrate-16x9-SD-Audio-5.1.md)
##### [H264 Multiple Bitrate 16x9 SD](media-services-mes-preset-H264-Multiple-Bitrate-16x9-SD.md)
##### [H264 Multiple Bitrate 16x9 for iOS](media-services-mes-preset-H264-Multiple-Bitrate-16x9-for-iOS.md)
##### [H264 Multiple Bitrate 4K Audio 5.1](media-services-mes-preset-H264-Multiple-Bitrate-4K-Audio-5.1.md)
##### [H264 Multiple Bitrate 4K](media-services-mes-preset-H264-Multiple-Bitrate-4K.md)
##### [H264 Multiple Bitrate 4x3 SD Audio 5.1](media-services-mes-preset-H264-Multiple-Bitrate-4x3-SD-Audio-5.1.md)
##### [H264 Multiple Bitrate 4x3 SD](media-services-mes-preset-H264-Multiple-Bitrate-4x3-SD.md)
##### [H264 Multiple Bitrate 4x3 for iOS](media-services-mes-preset-H264-Multiple-Bitrate-4x3-for-iOS.md)
##### [H264 Multiple Bitrate 720p Audio 5.1](media-services-mes-preset-H264-Multiple-Bitrate-720p-Audio-5.1.md)
##### [H264 Multiple Bitrate 720p](media-services-mes-preset-H264-Multiple-Bitrate-720p.md)
##### [H264 Single Bitrate 1080p Audio 5.1](media-services-mes-preset-H264-Single-Bitrate-1080p-Audio-5.1.md)
##### [H264 Single Bitrate 1080p](media-services-mes-preset-H264-Single-Bitrate-1080p.md)
##### [H264 Single Bitrate 16x9 SD Audio 5.1](media-services-mes-preset-H264-Single-Bitrate-16x9-SD-Audio-5.1.md)
##### [H264 Single Bitrate 16x9 SD](media-services-mes-preset-H264-Single-Bitrate-16x9-SD.md)
##### [H264 Single Bitrate 4K Audio 5.1](media-services-mes-preset-H264-Single-Bitrate-4K-Audio-5.1.md)
##### [H264 Single Bitrate 4K](media-services-mes-preset-H264-Single-Bitrate-4K.md)
##### [H264 Single Bitrate 4x3 SD Audio 5.1](media-services-mes-preset-H264-Single-Bitrate-4x3-SD-Audio-5.1.md)
##### [H264 Single Bitrate 4x3 SD](media-services-mes-preset-H264-Single-Bitrate-4x3-SD.md)
##### [H264 Single Bitrate 720p Audio 5.1](media-services-mes-preset-H264-Single-Bitrate-720p-Audio-5.1.md)
##### [H264 Single Bitrate 720p](media-services-mes-preset-H264-Single-Bitrate-720p.md)
##### [H264 Single Bitrate 720p for Android](media-services-mes-preset-H264-Single-Bitrate-720p-for-Android.md)
##### [H264 Single Bitrate High Quality SD for Android](media-services-mes-preset-H264-Single-Bitrate-High-Quality-SD-for-Android.md)
##### [H264 Single Bitrate Low Quality SD for Android](media-services-mes-preset-H264-Single-Bitrate-Low-Quality-SD-for-Android.md)
#### Encode with Media Encoder Premium Workflow
### [Create a task that generates fMP4 chunks](media-services-generate-fmp4-chunks.md)
### Media processors
#### [.NET](media-services-get-media-processor.md)
#### [REST](media-services-rest-get-media-processor.md)
### [Error codes](media-services-encoding-error-codes.md)
### Deprecated
#### [Static packaging and encryption](media-services-static-packaging.md)

## [Stream live](media-services-manage-channels-overview.md)
### [On-premise encoders](media-services-live-streaming-with-onprem-encoders.md)
#### [.NET](media-services-dotnet-live-encode-with-onpremises-encoders.md)
#### [REST](https://docs.microsoft.com/rest/api/media/operations/channel)
### [Live streaming with cloud encoder](media-services-manage-live-encoder-enabled-channels.md)
#### [Portal](media-services-portal-creating-live-encoder-enabled-channel.md)
#### [.NET](media-services-dotnet-creating-live-encoder-enabled-channel.md)
### [Configure on-premises encoders for use with cloud encoder](media-services-live-encoders-overview.md)
#### [Elemental Live encoder](media-services-configure-elemental-live-encoder.md)
#### [FMLE encoder ](media-services-configure-fmle-live-encoder.md)
#### [NewTek TriCaster encoder](media-services-configure-tricaster-live-encoder.md)
#### [Wirecast encoder](media-services-configure-wirecast-live-encoder.md)
### [Handle long-running operations](media-services-dotnet-long-operations.md)
### [Fragmented MP4 live ingest specification](media-services-fmp4-live-ingest-overview.md)

## [Protect](media-services-content-protection-overview.md)
### [Configure AES-128 clear key for your stream](media-services-protect-with-aes128.md)
### [Use REST to encrypt your content with storage encryption](media-services-rest-storage-encryption.md)
### [Media Services PlayReady license template overview](media-services-playready-license-template-overview.md)
### [DRM license delivery](media-services-deliver-keys-and-licenses.md)
### [Using PlayReady and/or Widevine dynamic common encryption](media-services-protect-with-drm.md)
### [Stream your HLS content protected with Apple FairPlay ](media-services-protect-hls-with-fairplay.md)

### Asset delivery
#### Configure asset delivery policies
##### [.NET](media-services-dotnet-configure-asset-delivery-policy.md)
##### [REST](media-services-rest-configure-asset-delivery-policy.md)
### Create ContentKeys
#### [.NET](media-services-dotnet-create-contentkey.md)
#### [REST](media-services-rest-create-contentkey.md)
### Configure content key authorization policy
#### [Portal](media-services-portal-configure-content-key-auth-policy.md)
#### [.NET](media-services-dotnet-configure-content-key-auth-policy.md)
#### [REST](media-services-rest-configure-content-key-auth-policy.md)

## [Analyze](media-services-analytics-overview.md)
### [Process with Indexer](media-services-index-content.md)
### [Process with Hyperlapse](media-services-hyperlapse-content.md)
### [Process with Face Detector](media-services-face-and-emotion-detection.md)
### [Process with Motion Detector](media-services-motion-detection.md)
### [Process with Face Redactor](media-services-face-redaction.md)
#### [Face Redactor walkthrough](media-services-redactor-walkthrough.md)
### [Process with video thumbnails](media-services-video-summarization.md)
### [Process with OCR](media-services-video-optical-character-recognition.md)

## [Configure telemetry](media-services-telemetry-overview.md)
###[.NET](media-services-dotnet-telemetry.md)
###[REST](media-services-rest-telemetry.md)

## Scale
### [Media Processing](media-services-scale-media-processing-overview.md)
#### [.NET](media-services-dotnet-encoding-units.md)
#### [REST](https://docs.microsoft.com/rest/api/media/operations/encodingreservedunittype)


## [Deliver content](media-services-deliver-content-overview.md)
### [Dynamic packaging](media-services-dynamic-packaging-overview.md)
### [Filters and dynamic manifests overview](media-services-dynamic-manifest-overview.md)
#### [Create filters with .NET](media-services-dotnet-dynamic-manifest.md)
#### [Create filters with REST](media-services-rest-dynamic-manifest.md)
### Publish content
#### [.NET](media-services-deliver-streaming-content.md)
#### [REST](media-services-rest-deliver-streaming-content.md)
### [Deliver by Download](media-services-deliver-asset-download.md)
### [Failover streaming scenario](media-services-implement-failover.md)

## Consume
### [Playback media with existing players](media-services-playback-content-with-existing-players.md)
### [Playback media with Media Player](media-services-develop-video-players.md)
### Other playback options
#### [Smooth streaming Windows Store application](media-services-build-smooth-streaming-apps.md)
#### [HTML5 Application with DASH.js](media-services-embed-mpeg-dash-in-html5.md)
#### [Adobe Open Source Media Framework players](media-services-use-osmf-smooth-streaming-client-plugin.md)
### [Insert ads on the client side](media-services-inserting-ads-on-client-side.md)
### [Licensing Microsoft Smooth Streaming Client Porting Kit](media-services-sspk.md)


## Monitor
### Check job progress
#### [REST](media-services-rest-check-job-progress.md)
#### [Portal](media-services-portal-check-job-progress.md)
#### [.NET](media-services-check-job-progress.md)
### [Monitor job notifications with queue storage](media-services-dotnet-check-job-progress-with-queues.md)

## Troubleshoot
### [Frequently asked questions](media-services-frequently-asked-questions.md)
### [Troubleshooting guide for live streaming](media-services-troubleshooting-live-streaming.md)
### [Error codes](media-services-error-codes.md)
### [Retry logic](media-services-retry-logic-in-dotnet-sdk.md)

# Reference
## [PowerShell (Resource Manager)](https://docs.microsoft.com/powershell/module/azurerm.media)
## [PowerShell (Service Management)](https://docs.microsoft.com/powershell/module/azure/?view=azuresmps-3.7.0)
## [.NET](https://docs.microsoft.com/dotnet/api/microsoft.windowsazure.mediaservices.client)
## [REST](https://docs.microsoft.com/rest/api/media/mediaservice)  

# Resources
## [Release notes](media-services-release-notes.md)
## [Pricing](https://www.azure.cn/pricing/details/media-services/)
