---
title: Introduction to Azure File storage | Azure
description: Introduction to Azure File storage, which provides network file shares in the Microsoft Cloud
services: storage
documentationcenter: ''
author: hayley244
manager: aungoo
editor: tysonn

ms.assetid: 
ms.service: storage
ms.workload: storage
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: get-started-article
origin.date: 05/27/2017
ms.date: 08/28/2017
ms.author: v-haiqya
---

# Introduction to Azure File storage

Azure File storage offers network file shares in the cloud using the industry standard [Server Message Block (SMB) Protocol](https://msdn.microsoft.com/library/windows/desktop/aa365233.aspx) and [Common Internet File System (CIFS)](https://technet.microsoft.com/library/cc939973.aspx). Azure File shares can be mounted concurrently by Azure Virtual Machines and on-premises deployments running Windows, macOS, or Linux. A general-purpose storage account gives you access to Azure File storage, Azure Blob storage, and Azure Queue storage.

## Why Azure File storage is useful

Azure File storage allows you to replace Windows Server, Linux, or NAS-based file servers hosted on-premises or in the cloud with an OS-free cloud file share. Azure File storage has the following benefits:

* **Shared access** Azure File shares support the industry standard SMB protocol, meaning you can seamlessly replace your on-premises file shares with Azure File shares without worrying about application compatibility. Being able to access a file share from multiple machines and applications/instances is a significant advantage with Azure File storage.

* **Fully Managed** Azure File shares can be created without the need to manage hardware or an OS, which means you don't have to deal with patching the server OS with critical security upgrades or replacing faulty hard disks.

* **Scripting and Tooling** PowerShell cmdlets and Azure CLI can be used to create, mount, and manage Azure File shares as part of the administration of Azure applications. You can create and manage Azure File shares using the [Azure portal](https://portal.azure.cn) and the [Azure Storage Explorer](https://storageexplorer.com). 

* **Resiliency** Azure File storage has been built from the ground up to be always available. Replacing on-premises file shares with Azure File storage means you no longer have to wake up to deal with local power outages or network issues. 

* **Familiar Programmability** Applications running in Azure can access data on the share via [file system I/O APIs](https://msdn.microsoft.com/library/system.io.file.aspx). Developers can therefore leverage their existing code and skills to migrate existing applications. In addition to System IO APIs, you can use any of the Azure storage client Libraries, such as the one for [.NET](https://docs.microsoft.com/dotnet/api/overview/azure/storage?view=azure-dotnet), or the [Azure Storage REST API](https://docs.microsoft.com/rest/api/storageservices/file-service-rest-api).

Azure File shares can be used to:

* **Replace on-premises file servers**
    Azure File storage can be used to completely replace file shares on traditional on-premises file servers or NAS devices. Popular operating systems such as Windows, macOS, and Linux can easily mount an Azure File share wherever they are in the world.

* **"Lift and Shift" applications**

    Azure File storage makes it easy to "lift and shift" applications to the cloud that use on-premises file shares to share data between parts of the application. To implement this, each VM connects to the file share and then it can read and write files just like it would against an on-premises file share.

* **Simplify Cloud Development**

    Azure File storage can be used in a number of different ways to simplify new cloud development projects.

    * **Shared Application Settings**

        A common pattern for distributed applications is to have configuration files in a centralized location where they can be accessed from many different VMs. Such configuration files can now be stored in an Azure File share, and read by all application instances. These settings can also be managed via the REST interface, which allows worldwide access to the configuration files.

    * **Diagnostic Share**

        An Azure File share can also be used to save diagnostic files like logs, metrics, and crash dumps. Having file shares available through both the SMB and REST interface allows applications to build or leverage a variety of analysis tools for processing and analyzing the diagnostic data.

    * **Dev/Test/Debug**

        When developers or administrators are working on VMs in the cloud, they often need a set of tools or utilities. Installing and distributing these utilities on each virtual machine where they are needed can be a time consuming exercise. With Azure File storage, a developer or administrator can store their favorite tools on a file share, which can be easily connected to from any virtual machine.

## How does it work?

Managing Azure File shares is much simpler than managing file shares on-premises. The following diagram illustrates the Azure File storage management constructs:

![File Structure](./media/storage-files-introduction/files-concepts.png)

* **Storage Account** All access to Azure Storage is done through a storage account. See [Scalability and Performance Targets](../common/storage-scalability-targets.md?toc=%2fstorage%2ffiles%2ftoc.json) for details about storage account capacity.

* **Share** A File Storage share is an SMB file share in Azure. All directories and files must be created in a parent share. An account can contain an unlimited number of shares, and a share can store an unlimited number of files, up to the 5 TB total capacity of the file share.

* **Directory** An optional hierarchy of directories.

* **File** A file in the share. A file may be up to 1 TB in size.

* **URL format** Files are addressable using the following URL format:  

    ```
    https://<storage account>.file.core.chinacloudapi.cn/<share>/<directory/directories>/<file>
    ```

## Next steps

* [Create Azure File Share](storage-how-to-create-file-share.md)
* [Connect and Mount on Windows](storage-how-to-use-files-windows.md)
* [Connect and Mount on Linux](storage-how-to-use-files-linux.md)
* [Connect and Mount on macOS](storage-how-to-use-files-mac.md)
* [FAQ](../storage-files-faq.md)
* [Troubleshooting on Windows](storage-troubleshoot-windows-file-connection-problems.md)   
* [Troubleshooting on Linux](storage-troubleshoot-linux-file-connection-problems.md)   

### Tooling support for Azure File storage
* [How to use AzCopy with Azure Storage](../common/storage-use-azcopy.md?toc=%2fstorage%2ffiles%2ftoc.json)
* [Using the Azure CLI with Azure Storage](../common/storage-azure-cli.md?toc=%2fstorage%2ffiles%2ftoc.json#create-and-manage-file-shares)

### Reference
* [Storage Client Library for .NET reference](https://msdn.microsoft.com/library/azure/dn261237.aspx)
* [File Service REST API reference](http://msdn.microsoft.com/library/azure/dn167006.aspx)
<!--Update_Description: update link-->