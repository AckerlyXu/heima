---
title: Frequently asked questions for Azure Files | Microsoft Docs
description: Find answers to frequently asked questions about Azure Files.
services: storage
documentationcenter: ''
author: yunan2016
manager: digimobile
editor: tysonn

ms.assetid: 
ms.service: storage
ms.workload: storage
ms.tgt_pltfrm: na
ms.devlang: na
origin.date: 12/04/2017
ms.date: 01/22/2018
ms.author: v-nany
---

# Frequently asked questions about Azure Files
[Azure Files](storage-files-introduction.md) offers fully managed file shares in the cloud that are accessible via the industry-standard [Server Message Block (SMB) protocol](https://msdn.microsoft.com/library/windows/desktop/aa365233.aspx) (also known as Common Internet File System, or CIFS). You can mount Azure file shares concurrently on cloud or on-premises deployments of Windows, Linux, and macOS. You also can cache Azure file shares on Windows Server machines by using Azure File Sync (preview) for fast access close to where the data is used.


## General
* <a id="why-files-useful"></a>
**How is Azure Files useful?**  
   You can use Azure Files to create file shares in the cloud, without being responsible for managing the overhead of a physical server, device, or appliance. We do the monotonous work for you, including applying OS updates and replacing bad disks. To learn more about the scenarios that Azure Files can help you with, see [Why Azure Files is useful](storage-files-introduction.md#why-azure-files-is-useful).

* <a id="file-access-options"></a>
**What are different ways to access files in Azure Files?**  
    You can mount the file share on your local machine by using the SMB 3.0 protocol, or you can use tools like [Storage Explorer](http://storageexplorer.com/) to access files in your file share. From your application, you can use storage client libraries, REST APIs, PowerShell, or Azure CLI to access your files in the Azure file share.


* <a id="files-versus-blobs"></a>
**Why would I use an Azure file share versus Azure Blob storage for my data?**  
    Azure Files and Azure Blob storage both offer ways to store large amounts of data in the cloud, but they are useful for slightly different purposes. 
    
    Azure Blob storage is useful for massive-scale, cloud-native applications that need to store unstructured data. To maximize performance and scale, Azure Blob storage is a simpler storage abstraction than a true file system. You can access Azure Blob storage only through REST-based client libraries (or directly through the REST-based protocol).

    Azure Files is specifically a file system. Azure Files has all the file abstracts that you know and love from years of working with on-premises operating systems. Like Azure Blob storage, Azure Files offers a REST interface and REST-based client libraries. Unlike Azure Blob storage, Azure Files offers SMB access to Azure file shares. By using SMB, you can mount an Azure file share directly on Windows, Linux, or macOS, either on-premises or in cloud VMs, without writing any code or attaching any special drivers to the file system. You also can cache Azure file shares on on-premises file servers by using Azure File Sync for quick access, close to where the data is used. 
   
    For a more in-depth description on the differences between Azure Files and Azure Blob storage, see [Deciding when to use Azure Blob storage, Azure Files, or Azure Disks](../common/storage-decide-blobs-files-disks.md?toc=%2fstorage%2ffiles%2ftoc.json). To learn more about Azure Blob storage, see [Introduction to Blob storage](../blobs/storage-blobs-introduction.md).

* <a id="files-versus-disks"></a>**Why would I use an Azure file share instead of Azure Disks?**  
    A disk in Azure Disks is simply a disk. A standalone disk by itself is not too useful. To get value from Azure Disks, you must attach a disk to a virtual machine that's running in Azure. Azure Disks can be used for everything that you would use a disk for on an on-premises server. You can use it as an OS system disk, as swap space for an OS, or as dedicated storage for an application. An interesting use for Azure Disks is to create a file server in the cloud to use in the same places where you might use an Azure file share. Deploying a file server in Azure Virtual Machines is a high-performance way to get file storage in Azure when you require deployment options that currently are not supported by Azure Files (such as NFS protocol support or premium storage). 

    However, running a file server with Azure Disks as back-end storage typically is much more expensive than using an Azure file share, for a few reasons. First, in addition to paying for disk storage, you also must pay for the expense of running one or more Azure VMs. Second, you also must manage the VMs that are used to run the file server. For example, you are responsible for OS upgrades. Finally, if you ultimately require data to be cached on-premises, it's up to you to set up and manage replication technologies, such as Distributed File System Replication (DFSR), to make that happen.


    For information about an option for setting up a high-performance and highly available file server in Azure, see [Deploying IaaS VM guest clusters in Azure](https://blogs.msdn.microsoft.com/clustering/2017/02/14/deploying-an-iaas-vm-guest-clusters-in-microsoft-azure/). For a more in-depth description of the differences between Azure Files and Azure Disks, see [Deciding when to use Azure Blob storage, Azure Files, or Azure Disks](../common/storage-decide-blobs-files-disks.md?toc=%2fstorage%2ffiles%2ftoc.json). To learn more about Azure Disks, see [Azure Managed Disks overview](../../virtual-machines/windows/managed-disks-overview.md).

* <a id="get-started"></a>
**How do I get started using Azure Files?**  
   Getting started with Azure Files is easy. First, [create a file share](storage-how-to-create-file-share.md), and then mount it in your preferred operating system: 

    * [Mount in Windows](storage-how-to-use-files-windows.md)
    * [Mount in Linux](storage-how-to-use-files-linux.md)
    * [Mount in macOS](storage-how-to-use-files-mac.md)

   For a more in-depth guide about deploying an Azure file share to replace production file shares in your organization, see [Planning for an Azure Files deployment](storage-files-planning.md).

* <a id="redundancy-options"></a>
**What storage redundancy options are supported by Azure Files?**  
    Currently, Azure Files supports only locally redundant storage (LRS) and geo-redundant storage (GRS). We plan to support zone-redundant storage (ZRS) and read-access geo-redundant (RA-GRS) storage in the future, but we don't have timelines to share at this time.

- <a id="tier-options"></a>
**What storage tiers are supported in Azure Files?**  
    Currently, Azure Files supports only the standard storage tier. We don't have timelines to share for premium storage and cool storage support at this time. 
    
    > [!NOTE]
    > You cannot create Azure file shares from blob-only storage accounts or from premium storage accounts.



## Security, authentication, and access control
* <a id="ad-support"></a>
**Is Active Directory-based authentication and access control supported by Azure Files?**  
    Azure Files offers two ways to manage access control:

    - You can use shared access signatures (SAS) to generate tokens that have specific permissions, and which are valid for a specified time interval. For example, you can generate a token with read-only access to a specific file that has a 10-minute expiry. Anyone who possesses the token while the token is valid has read-only access to that file for those 10 minutes. Currently, shared access signature keys are supported only via the REST API or in client libraries. You must mount the Azure file share over SMB by using the storage account keys.


    Currently, Azure Files does not support Active Directory directly.

* <a id="encryption-at-rest"></a>
**How can I ensure that my Azure file share is encrypted at rest?**  
    Azure Storage Service Encryption is in the process of being enabled by default in all regions. For these regions, you don't need to take any actions to enable encryption. For other regions, see [Server-side encryption](../common/storage-service-encryption.md?toc=%2fazure%2fstorage%2ffiles%2ftoc.json).

* <a id="access-via-browser"></a>
**How can I provide access to a specific file by using a web browser?**  
    You can use shared access signatures to generate tokens that have specific permissions, and which are valid for a specified time interval. For example, you can generate a token that gives read-only access to a specific file, for a set period of time. Anyone who possesses the URL can access the file directly from any web browser while the token is valid. You can easily generate a shared access signature key from a UI like Storage Explorer.

* <a id="file-level-permissions"></a>
**Is it possible to specify read-only or write-only permissions on folders within the share?**  
    If you mount the file share by using SMB, you don't have folder-level control over permissions. However, if you create a shared access signature by using the REST API or client libraries, you can specify read-only or write-only permissions on folders within the share.


* <a id="data-compliance-policies"></a>
**What data compliance policies does Azure Files support?**  
   Azure Files runs on top of the same storage architecture that's used in other storage services in Azure Storage. Azure Files applies the same data compliance policies that are used in other Azure storage services. For more information about Azure Storage data compliance, you can download and refer to the [ Azure Data Protection document](http://go.microsoft.com/fwlink/?LinkID=398382&clcid=0x409), and go to the [Azure Trust Center](https://www.azure.cn/support/trust-center/).

## On-premises access
* <a id="expressroute-not-required"></a>
**Do I have to use Azure ExpressRoute to connect to Azure Files ?**  
    No. ExpressRoute is not required to access an Azure file share. If you are mounting an Azure file share directly on-premises, all that's required is to have port 445 (TCP outbound) open for internet access (this is the port that SMB uses to communicate). If you're using Azure File Sync, all that's required is port 443 (TCP outbound) for HTTPS access (no SMB required). However, you *can* use ExpressRoute with either of these access options.

* <a id="mount-locally"></a>
**How can I mount an Azure file share on my local machine?**  
    You can mount the file share by using the SMB protocol if port 445 (TCP outbound) is open and your client supports the SMB 3.0 protocol (for example, if you're using Windows 10 or Windows Server 2016). If port 445 is blocked by your organization's policy or by your ISP, you can use Azure File Sync to access your Azure file share.



## Billing and pricing
* <a id="vm-file-share-network-traffic"></a>
**Does the network traffic between an Azure VM and an Azure file share count as external bandwidth that is charged to the subscription?**  
    If the file share and VM are in the same Azure region, there is no additional charge for the traffic between the file share and the VM. If the file share and the VM are in different regions, the traffic between them are charged as external bandwidth.


## Scale and performance
* <a id="files-scale-limits"></a>
**What are the scale limits of Azure Files?**  
    For information about scalability and performance targets for Azure Files, see [Azure Files scalability and performance targets](storage-files-scale-targets.md).

* <a id="need-larger-share"></a>
**I need a larger file share than Azure Files currently offers. Can I increase the size of my Azure file share?**  
    No. The maximum size of an Azure file share is 5 TiB. Currently, this is a hard limit that we cannot adjust. We are working on a solution to increase the share size to 100 TiB, but we don't have timelines to share at this time.

* <a id="open-handles-quota"></a>
**How many clients can access the same file simultaneously?**   
    There is a quota of 2,000 open handles on a single file. When you have 2,000 open handles, an error message is displayed that says the quota is reached.

* <a id="zip-slow-performance"></a>
**My performance is slow when I unzip files in Azure Files. What should I do?**  
    To transfer large numbers of files to Azure Files, we recommend that you use AzCopy (for Windows; in preview for Linux and UNIX) or Azure PowerShell. These tools have been optimized for network transfer.

* <a id="slow-perf-windows-81-2012r2"></a>
**Why is my performance slow after I mount my Azure file share on Windows Server 2012 R2 or Windows 8.1?**  
    There is a known issue when mounting an Azure file share on Windows Server 2012 R2 and Windows 8.1. The issue was patched in the April 2014 cumulative update for Windows 8.1 and Windows Server 2012 R2. For optimum performance, ensure that all instances of Windows Server 2012 R2 and Windows 8.1 have this patch applied. (You should always receive  Windows patches through Windows Update.) For more information, see the associated Azure Knowledge Base article [Slow performance when you access Azure Files from Windows 8.1 or Server 2012 R2](https://support.microsoft.com/kb/3114025).

## Features and interoperability with other services
* <a id="cluster-witness"></a>
**Can I use my Azure file share as a *File Share Witness* for my Windows Server Failover Cluster?**  
    Currently, this configuration is not supported for an Azure file share. For more information about how to set this up for Azure Blob storage, see [Deploy a Cloud Witness for a Failover Cluster](https://docs.microsoft.com/windows-server/failover-clustering/deploy-cloud-witness).


* <a id="rest-rename"></a>
**Is there a rename operation in the REST API?**  
    Not at this time.

* <a id="nested-shares"></a>
**Can I set up nested shares? In other words, a share under a share?**  
    No. The file share *is* the virtual driver that you can mount, so nested shares are not supported.

* <a id="ibm-mq"></a>
**How do I use Azure Files with IBM MQ?**  
    IBM has released a document that helps IBM MQ customers configure Azure Files with the IBM service. For more information, see [How to set up an IBM MQ multi-instance queue manager with  Azure Files service](https://github.com/ibm-messaging/mq-azure/wiki/How-to-setup-IBM-MQ-Multi-instance-queue-manager-with-Microsoft-Azure-File-Service).

## See also
* [Troubleshoot Azure Files in Windows](storage-troubleshoot-windows-file-connection-problems.md)
* [Troubleshoot Azure Files in Linux](storage-troubleshoot-linux-file-connection-problems.md)
