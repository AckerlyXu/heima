---
title: Azure PowerShell script sample - Calculate the total billing size of a blob container | Microsoft Docs
description: Calculate the total size of a container in Azure Blob storage for billing purposes.
services: storage
documentationcenter: na
author: yunan2016
manager: digimobile

editor: tysonn

ms.assetid:
ms.custom: mvc
ms.service: storage
ms.workload: storage
ms.tgt_pltfrm: na
ms.devlang: powershell
ms.topic: sample
origin.date: 11/07/2017
ms.date: 12/04/2017
ms.author: v-nany

---

# Calculate the total billing size of a blob container

This script calculates the size of a container in Azure Blob storage for the purpose of estimating billing costs. The script totals the size of the blobs in the container.

[!INCLUDE [sample-powershell-install](../../../includes/sample-powershell-install-no-ssh.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

> [!NOTE]
> This PowerShell script calculates the size of a container for billing purposes. If you are calculating container size for other purposes, see [Calculate the total size of a Blob storage container](../scripts/storage-blobs-container-calculate-size-powershell.md) for a simpler script that provides an estimate.

## Determine the size of the blob container

The total size of the blob container includes the size of the container itself and the size of all blobs under the container.

The following sections describes how the storage capacity is calculated for blob containers and blobs. In the following section, Len(X) means the number of characters in the string.

### Blob containers

The following calculation describes how to estimate the amount of storage that's consumed per blob container:

`
48 bytes + Len(ContainerName) * 2 bytes +
For-Each Metadata[3 bytes + Len(MetadataName) + Len(Value)] +
For-Each Signed Identifier[512 bytes]
`

Following is the breakdown:
* 48 bytes of overhead for each container includes the Last Modified Time, Permissions, Public Settings, and some system metadata.

* The container name is stored as Unicode, so take the number of characters and multiply by two.

* For each block of blob container metadata that's stored, we store the length of the name (ASCII), plus the length of the string value.

* The 512 bytes per Signed Identifier includes signed identifier name, start time, expiry time, and permissions.

### Blobs

The following calculations show how to estimate the amount of storage consumed per blob.

* Block blob (base blob or snapshot):

   `
   124 bytes + Len(BlobName) * 2 bytes +
   For-Each Metadata[3 bytes + Len(MetadataName) + Len(Value)] +
   8 bytes + number of committed and uncommitted blocks * Block ID Size in bytes +
   SizeInBytes(data in unique committed data blocks stored) +
   SizeInBytes(data in uncommitted data blocks)
   `

* Page blob (base blob or snapshot):

   `
   124 bytes + Len(BlobName) * 2 bytes +
   For-Each Metadata[3 bytes + Len(MetadataName) + Len(Value)] +
   number of nonconsecutive page ranges with data * 12 bytes +
   SizeInBytes(data in unique pages stored)
   `

Following is the breakdown:

* 124 bytes of overhead for blob, which includes:
    - Last Modified Time
    - Size
    - Cache-Control
    - Content-Type
    - Content-Language
    - Content-Encoding
    - Content-MD5
    - Permissions
    - Snapshot information
    - Lease
    - Some system metadata

* The blob name is stored as Unicode, so take the number of characters and multiply by two.

* For each block of metadata that's stored, add the length of the name (stored as ASCII), plus the length of the string value.

* For the block blobs:
    * 8 bytes for the block list.
    * Number of blocks times the block ID size in bytes.
    * The size of the data in all of the committed and uncommitted blocks. 
    
    >[!NOTE]
    >When snapshots are used, this size  includes only the unique data for this base or snapshot blob. If the uncommitted blocks are not used after a week, they are garbage-collected. After that, they don't count toward billing.

* For page blobs:
    * The number of nonconsecutive page ranges with data times 12 bytes. This is the number of unique page ranges you see when calling the **GetPageRanges** API.

    * The size of the data in bytes of all of the stored pages. 
    
    >[!NOTE]
    >When snapshots are used, this size includes only the unique pages for the base blob or the snapshot blob that's being counted.

## Sample script

```powershell

# this script will show how to get the total size of the blobs in a container
# before running this, you need to create a storage account, create a container,
#    and upload some blobs into the container
# note: this retrieves all of the blobs in the container in one command.
#       connect Azure with Login-AzureRmAccount before you run the script.
# command line usage: script.ps1 -ResourceGroup {YourResourceGroupName} -StorageAccountName {YourAccountName} -ContainerName {YourContainerName}
#

param(
    [Parameter(Mandatory=$true)]
    [string]$ResourceGroup,

    [Parameter(Mandatory=$true)]
    [string]$StorageAccountName,

    [Parameter(Mandatory=$true)]
    [string]$ContainerName
)

#Set-StrictMode will cause Get-AzureStorageBlob returns result in different data types when there is only one blob
#Set-StrictMode -Version 2

$VerbosePreference = "Continue"

if((Get-Module -ListAvailable Azure) -eq $null)
{
    throw "Azure Powershell not found! Please install from http://www.windowsazure.com/en-us/downloads/#cmd-line-tools"
}

# function Get-BlobBytes

function Get-BlobBytes
{
    param(
        [Parameter(Mandatory=$true)]
        $Blob)

    # Base + blobname
    $blobSizeInBytes = 124 + $Blob.Name.Length * 2

    # Get size of metadata
    $metadataEnumerator=$Blob.ICloudBlob.Metadata.GetEnumerator()
    while($metadataEnumerator.MoveNext())
    {
        $blobSizeInBytes += 3 + $metadataEnumerator.Current.Key.Length + $metadataEnumerator.Current.Value.Length
    }

    if($Blob.BlobType -eq [Microsoft.WindowsAzure.Storage.Blob.BlobType]::BlockBlob)
    {
        $blobSizeInBytes += 8
        # Default is Microsoft.WindowsAzure.Storage.Blob.BlockListingFilter.Committed. Need All
        $Blob.ICloudBlob.DownloadBlockList([Microsoft.WindowsAzure.Storage.Blob.BlockListingFilter]::All) |
            ForEach-Object { $blobSizeInBytes += $_.Length + $_.Name.Length }
    }
    else
    {
        $Blob.ICloudBlob.GetPageRanges() |
            ForEach-Object { $blobSizeInBytes += 12 + $_.EndOffset - $_.StartOffset }
    }

    return $blobSizeInBytes
}

# function Get-ContainerBytes

function Get-ContainerBytes
{
    param(
        [Parameter(Mandatory=$true)]
        [Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer]$Container)

    # Base + name of container
    $containerSizeInBytes = 48 + $Container.Name.Length*2

    # Get size of metadata
    $metadataEnumerator = $Container.Metadata.GetEnumerator()
    while($metadataEnumerator.MoveNext())
    {
        $containerSizeInBytes += 3 + $metadataEnumerator.Current.Key.Length + $metadataEnumerator.Current.Value.Length
    }

    # Get size for SharedAccessPolicies
    $containerSizeInBytes += $Container.GetPermissions().SharedAccessPolicies.Count * 512

    # Calculate size of all blobs.
    $blobCount = 0
    $Token = $Null
    $MaxReturn = 5000

    do {
        $Blobs = Get-AzureStorageBlob -Context $storageContext -Container $Container.Name -MaxCount $MaxReturn -ContinuationToken $Token
        if($Blobs -eq $Null) { break }

        #Set-StrictMode will cause Get-AzureStorageBlob returns result in different data types when there is only one blob
        if($Blobs.GetType().Name -eq "AzureStorageBlob")
        {
            $Token = $Null
        }
        else
        {
            $Token = $Blobs[$Blobs.Count - 1].ContinuationToken;
        }

        $Blobs | ForEach-Object {
                $blobSize = Get-BlobBytes $_
                $containerSizeInBytes += $blobSize
                $blobCount++

                if(($blobCount % 1000) -eq 0)
                {
                    Write-Verbose("Counting {0} Sizing {1} " -f $blobCount, $containerSizeInBytes)
                }
            }
    }
    While ($Token -ne $Null)

    return @{ "containerSize" = $containerSizeInBytes; "blobCount" = $blobCount }
}

#Login-AzureRmAccount

$storageAccount = Get-AzureRmStorageAccount -ResourceGroupName $ResourceGroup -Name $StorageAccountName -ErrorAction SilentlyContinue
if($storageAccount -eq $null)
{
    throw "The storage account specified does not exist in this subscription."
}

$storageContext = $storageAccount.Context

$containers = New-Object System.Collections.ArrayList
if($ContainerName.Length -ne 0)
{
    $container = Get-AzureStorageContainer -Context $storageContext -Name $ContainerName -ErrorAction SilentlyContinue |
        ForEach-Object { $containers.Add($_) } | Out-Null
}
else
{
    Get-AzureStorageContainer -Context $storageContext | ForEach-Object { $containers.Add($_) } | Out-Null
}

$sizeInBytes = 0

if($containers.Count -gt 0)
{
    $containers | ForEach-Object {
        Write-Output("Calculating container {0} ..." -f $_.CloudBlobContainer.Name)
        $result = Get-ContainerBytes $_.CloudBlobContainer
        $sizeInBytes += $result.containerSize

        Write-Output("Container '{0}' with {1} blobs has a sizeof {2:F2} MB." -f $_.CloudBlobContainer.Name,$result.blobCount,($result.containerSize/1MB))
    }
}
else
{
    Write-Warning "No containers found to process in storage account '$StorageAccountName'."
}

```

## Next steps

- See [Calculate the total size of a Blob storage container](../scripts/storage-blobs-container-calculate-size-powershell.md) for a simple script that provides an estimate of container size.

- For more information about Azure Storage billing, see [Understanding Windows Azure Storage Billing](https://blogs.msdn.microsoft.com/windowsazurestorage/2010/07/08/understanding-windows-azure-storage-billing-bandwidth-transactions-and-capacity/).

- For more information about the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/en-us/powershell/azure/overview?view=azurermps-4.4.1).

- You can find additional Storage PowerShell script samples in [PowerShell samples for Azure Storage](../blobs/storage-samples-blobs-powershell.md).
