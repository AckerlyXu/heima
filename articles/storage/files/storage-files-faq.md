---
title: Frequently asked questions about Azure Files | Microsoft Docs
description: Find answers to frequently asked questions about Azure Files.
services: storage
documentationcenter: ''
author: forester123
manager: digimobile
editor: tysonn

ms.assetid: 
ms.service: storage
ms.workload: storage
ms.tgt_pltfrm: na
ms.devlang: na
origin.date: 10/13/2017
ms.date: 10/30/2017
ms.author: v-johch
---
# Frequently Asked Questions about Azure Files

## General
* **What is Azure Files?**  

    Azure Files offers fully managed file shares in the cloud that are accessible via the industry standard [Server Message Block (SMB) protocol](https://msdn.microsoft.com/library/windows/desktop/aa365233.aspx) (also known as Common Internet File System or CIFS). Azure File shares can be mounted concurrently by cloud or on-premises deployments of Windows, Linux, and macOS.

* **Why is Azure Files useful?**  

   Azure Files allows you to create file shares in the cloud without having to manage the overhead of a physical server or device/appliance. This means you can spend less time applying OS updates and replacing bad disks - we do all of that monotonous work for you. To learn more about the scenarios Azure Files can help with, see [Why Azure Files is useful](storage-files-introduction.md#why-azure-files-is-useful).

* **What are different ways to access files in Azure Files?**  

    You can mount the file share on your local machine using SMB 3.0 protocol or use tools like [Storage Explorer](http://storageexplorer.com/) to access files in your file share. From your application, you can use storage client libraries, REST APIs or Powershell to access your files in Azure File share.


* **Why would I use an Azure File share versus Azure Blob storage for my data?**  

    Azure Files and Azure Blob storage both provide a way to store large amounts of data in the cloud, but are useful for slightly different purposes. Azure Blob storage is useful for massive-scale, cloud-native applications that need to store unstructured data. To maximize performance and scale, Azure Blob storage is a simpler storage abstraction than a true file system. Additionally, Azure Blob storage may only be accessed through REST-based client libraries (or directly through the REST-based protocol).

    Azure Files on the other hand specifically seeks to be a file system, with all of the file abstracts you know and love from years of on-premises operating systems. Like Azure Blob storage, Azure Files offers a REST interface and REST-based client libraries, but unlike Azure Blob storage, Azure Files also offers SMB access to Azure File shares. This means you can directly mount an Azure File share on Windows, Linux, or macOS, on-premises or in cloud VMs, without having to write any code or attach any special drivers to the file system.  
   
    For a more in-depth discussion on the differences between Azure Files and Azure Blob storage, see [Deciding when to use Azure Blob storage, Azure Files, or Azure Disks](../common/storage-decide-blobs-files-disks.md?toc=%2fstorage%2ffiles%2ftoc.json). To learn more about Azure Blob storage, see [Introduction to Blob storage](../blobs/storage-blobs-introduction.md).

* **Why would I use an Azure File share versus Azure Disks?**  

    An Azure Disk is just that, a disk. A standalone disk by itself, is not very useful - to get value out of an Azure Disk, you have to attach to virtual machine running in Azure. Azure Disks can be used for anything and everything you would use a disk for on an on-premises server: as an OS system disk, swap space for an OS, or as dedicated storage for an application. One interesting use for Azure Disks is to create a file server in the cloud for use in exactly the same places you might use an Azure File share. Deploying a file server in Azure VMs is a fantastic, high-performance way to get file storage in Azure when you require deployment options not currently supported by Azure Files (such as NFS protocol support or premium storage). 

    On the other hand, running a file server with Azure Disks as backend storage will typically be much more expensive than using an Azure File share for several reasons. First, in addition to paying for disk storage, you must also pay for the expense of running one or more Azure VMs. Second, you must also manage the VMs used to run the file server, such as being responsible for OS upgrades, etc. Finally, if you ultimately require data cached on-premises, it's up to you to set up and manage replication technologies (such as Distributed File System Replication) to make that happen.

    If the Azure File share is in the same region as your file server, you can enable cloud tiering and set volume free space percentage to maximum (99%). This ensures minimal duplication of data while allowing you to use whatever applications you want against your file servers, such anything requiring NFS protocol support.

    For information on one way to set up a high performance and highly available in Azure, see [Deploying IaaS VM Guest Clusters in Azure](https://blogs.msdn.microsoft.com/clustering/2017/02/14/deploying-an-iaas-vm-guest-clusters-in-microsoft-azure/). For a more in-depth discussion on the differences between Azure Files and Azure Disks, see [Deciding when to use Azure Blob storage, Azure Files, or Azure Disks](../common/storage-decide-blobs-files-disks.md?toc=%2fstorage%2ffiles%2ftoc.json). To learn more about Azure Disks, see [Azure Managed Disks Overview](../../virtual-machines/windows/managed-disks-overview.md).

* **How do I get started using Azure Files?**  

    Getting started with Azure Files is easy: simply [create a file share](storage-how-to-create-file-share.md) and mount in your preferred operating system: 

    - [Mount on Windows](storage-how-to-use-files-windows.md)
    - [Mount on Linux](storage-how-to-use-files-linux.md)
    - [Mount on macOS](storage-how-to-use-files-mac.md)

    For a more in-depth guide on how to deploy an Azure File share to replace production file shares in your organization, see [Planning for an Azure Files deployment](storage-files-planning.md).

* **What storage redundancy options are supported by Azure Files?**  

    Azure Files currently only supports locally redundant storage (LRS) and geo-redundant storage (GRS) right now. We plan to support zone-redundant storage (ZRS) and read-access geo-redundant storage (RA-GRS) in the future, but don't have timelines to share at this time.


* **Can I create File Share in cool storage?**   

    Cool storage account only supports blob at this time. It does not support File shares. You need to create standard storage account. Standard storage is very competitively priced and also, recently slashed price for Standard Azure Files ever further. For more information, see [Azure Files Pricing](https://www.azure.cn/pricing/details/storage/).

* **I cannot access file share from on-premises?**  

    If you are trying to access the file share from your local network, the following prerequisite must be meet:

    - The port 445 must be enabled by your ISP (get in touch with your ISP to enable it).

    - on-premises client machine must have SMB 3.0 enabled.

    - When a client accesses File storage, the SMB version used depends on the SMB version supported by the operating system. 
    
    The following list provides a summary of support for Windows clients.

    - Windows Client SMB Version Supported
    - Windows 7 SMB 2.1
    - Windows Server 2008 R2 SMB 2.1
    - Windows 8 SMB 3.0
    - Windows Server 2012 SMB 3.0
    - Windows Server 2012 R2 SMB 3.0
    - Windows 10 SMB 3.0

    For more information, see [Troubleshooter for Azure Files storage problems](https://support.microsoft.com/help/4022301/azure-file-storage-connection-creation--performance-problems).

* **I cannot mount Azure File Share from On-Premises client**

    To resolve this problem, use [Troubleshooter for Azure Files storage](problemshttps://support.microsoft.com/help/4022301/azure-file-storage-connection-creation--performance-problems).

* **How to Map container folder on VM**? 

   see [Mounting an Azure file share with Azure Container Instances](https://docs.microsoft.com/en-us/azure/container-instances/container-instances-mounting-azure-files-volume).

* **Can I increase the maximum size of File Share?**

    No. The maximum size of a File share is 5 TB.

* **Can I to convert to premium storage account for File share?**

    No. Premium storage is not available on Azure file share today.


## Security, Authentication and Access Control
* **Is Active Directory-based authentication and access control supported by Azure Files?**  

    Azure Files does not currently support AD-based authentication or ACLs, but this is something we're actively working on. 

    - Using SAS, you can generate tokens with specific permissions that are valid for a specified time interval. For example, you can generate a token with read-only access to a given file with 10 minutes expiry. Anyone who possesses this token while it is valid has read-only access to that file for those 10 minutes. SAS keys are only supported via the REST API or client libraries today, you must mount the Azure File share over SMB with the storage account keys.


* **How can I ensure my Azure File share is encrypted at-rest?**  

    You don't have to do anything to enable encryption, [Server Side Encryption](../common/storage-service-encryption.md?toc=%2fstorage%2ffiles%2ftoc.json) is now enabled by default for Azure Files in all public regions and national clouds. 

* **How can I provide access to a specific file using a web browser?** 

    Using SAS, you can generate tokens with specific permissions that are valid for a specified time interval. For example, you can generate a token with read-only access to a particular file for a specific period of time. Anyone who possesses this url can access the file directly from any web browser while it is valid. SAS keys can be easily generated from UI like Storage Explorer.

* **Is it possible to specify read-only or write-only permissions on folders within the share?**  

    You don't have this level of control over permissions if you mount the file share via SMB. However, you can achieve this by creating a shared access signature (SAS) via the REST API or client libraries.

* **How to map Azure Files storage for all users as a network share without prompting them for credential?** 

    Azure Files does not support either AD or Azure AD. That means you typically need to map the drive for the users. A scenario where a login script maps the drive could give someone access to the storage key without prompting them for credential. 
   
   For more information, see the following documents:    
   
   - [Get started with Azure File storage on Windows (General Information)](storage-dotnet-how-to-use-files.md )
   - [Persisting connections to Azure Files (Using CMDKey to persist the connections, mapping to other users)](https://blogs.msdn.microsoft.com/windowsazurestorage/2014/05/26/persisting-connections-to-microsoft-azure-files/ )
   - [How can I Persist connections to Azure Files for all the users? (Discussion about the limitation of the storage key)](https://serverfault.com/questions/772168/how-can-i-persist-connections-to-microsoft-azure-files-for-all-the-users)
 
* **Can I set different permissions of different folders in a file share?** 

    All the folders in one file share would have the same one permission. To achieve this goal, you could try to create different file shares as a workaround, and set different permissions to these file shares. Then you can achieve the similar function.

* **Can I apply domain or NTFS permissions to an Azure file share? if not, what would be the best solution for this type of scenario?**

    There is no way to apply domain or NTFS permissions to an Azure File Share. Alternatively, A shared access signature (SAS) provides you with a way to grant limited access to objects in your storage account to other clients, without exposing your account key.

* **Can I access File share using Domain account credentials?**

    No. Currently the Azure File Share only support Storage keys authentication. So we cannot use domain account credentials to access them.

## On-Premises Access
* **Do I have to use Azure ExpressRoute to connect to Azure Files?**  

    No, ExpressRoute is not required to access an Azure File share. If you're mounting an Azure File share directly on-premises, all that is required is that you have port 445 (TCP Outbound) open for Internet access (this is the port SMB communicates on). 

* **How can I mount an Azure File share on my local machine?** 

    You can mount the file share via the SMB protocol as long as port 445 (TCP Outbound) is open and your client supports the SMB 3.0 protocol (for example, you're using Windows 10 or Windows Server 2016). 

* **How to mount the Files share in on-premises macOS?**  

    See the following articles to mount Azure file share on local macOS:
    - [Mount Azure File share over SMB with macOS](storage-how-to-use-files-mac.md)
    - [How to connect with File Sharing on your Mac](https://support.apple.com/en-us/HT204445)

## Backup
* **How do I back up my Azure File share?**  

    You can use periodic share snapshots (preview) for protection against accidental deletes. You can use AzCopy, RoboCopy, or a 3rd party backup tool that can backup a mounted file share.


## Billing and Pricing
* **Does the network traffic between an Azure VM and a file share count as external bandwidth that is charged to the subscription?**  

    If the file share and VM are in the same Azure region, the traffic between them is free. If they are in different regions, the traffic between them will be charged as external bandwidth.

## Scale and Performance
* **What are the scale limits of Azure Files?** 

    For information on scalability and performance targets of Azure Files, see [Azure Storage Scalability and Performance Targets](../common/storage-scalability-targets.md?toc=%2fstorage%2ffiles%2ftoc.json#scalability-targets-for-blobs-queues-tables-and-files).

* **How many clients can access the same file simultaneously?** 

    There is a 2000 open handles quota on a single file. Once you have 2000 open handles, you will get an error that quota is reached.

* **My performance was slow when trying to unzip files into Azure Files. What should I do?**  

    To transfer large numbers of files into Azure Files, we recommend that you use AzCopy(Windows, Preview for Linux/Unix) or Azure Powershell as these tools have been optimized for network transfer.

* **I've mounted my Azure File share on Windows Server 2012 R2 or Windows 8.1, and my performance is slow - why?**  

    There is a known issue when mounting an Azure File share on Windows Server 2012 R2 and Windows 8.1 that was patched in the April 2014 cumulative update for Windows 8.1 and Windows Server 2012 R2. Please ensure that all instances of Windows Server 2012 R2 and Windows 8.1 have this patch applied for optimum performance (of course, we always recommend taking all Windows patches through Windows Update). For more information, please check out the associated KB article, [Slow performance when you access Azure Files from Windows 8.1 or Server 2012 R2](https://support.microsoft.com/kb/3114025).

## Features and Interoperability with other services
* **Is a "File Share Witness" for a Failover Cluster one of the use cases for Azure Files?**  

    This is not currently supported for an Azure File share. For more information on how to set this up for Azure Blob storage, see [Deploy a Cloud Witness for a Failover Cluster](https://docs.microsoft.com/windows-server/failover-clustering/deploy-cloud-witness).

* **Is there a rename operation in the REST API?**  

    Not at this time.

* **Can you have nested shares, in other words, a share under a share?**  

    No. The file share is the virtual driver that you can mount, so nested shares are not supported.

* **Using Azure Files with IBM MQ**  

    IBM has released a document to guide IBM MQ customers when configuring Azure Files with their service. For more information, please check out [How to setup IBM MQ Multi instance queue manager with Azure File Service](https://github.com/ibm-messaging/mq-azure/wiki/How-to-setup-IBM-MQ-Multi-instance-queue-manager-with-Microsoft-Azure-File-Service).

## See also
* [Troubleshoot Azure Files problems in Windows](storage-troubleshoot-windows-file-connection-problems.md)
* [Troubleshoot Azure Files problems in Linux](storage-troubleshoot-linux-file-connection-problems.md)
<!--Update_Description:whole content update-->