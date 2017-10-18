---
title: Azure CLI Script Sample - Calculate blob container size | Microsoft Docs
description: Calculate the size of a container in Azure Blob storage by totaling the size of the blobs in the container.
services: storage
documentationcenter: na
author: forester123
manager: digimobile
editor: tysonn

ms.assetid:
ms.custom: mvc
ms.service: storage
ms.workload: storage
ms.tgt_pltfrm: na
ms.devlang: azurecli
ms.topic: sample
origin.date: 06/28/2017
ms.date: 10/23/2017
ms.author: v-johch
---

# Calculate the size of a Blob storage container

This script calculates the size of a container in Azure Blob storage by totaling the size of the blobs in the container.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurecli
#!/bin/bash
export AZURE_STORAGE_ACCOUNT=<storage-account-name>
export AZURE_STORAGE_ACCESS_KEY=<storage-account-key>

# Create a resource group
az group create --name myResourceGroup --location chinaeast

# Create a container
az storage container create --name mycontainer

# Create sample files to upload as blobs
for i in `seq 1 3`; do
    echo $RANDOM > container_size_sample_file_$i.txt
done

# Upload sample files to container
az storage blob upload-batch \
    --pattern "container_size_sample_file_*.txt" \
    --source . \
    --destination mycontainer

# Calculate total size of container. Use the --query parameter to display only
# blob contentLength and output it in TSV format so only the values are
# returned. Then pipe the results to the paste and bc utilities to total the
# size of the blobs in the container.
bytes=`az storage blob list \
    --container-name mycontainer \
    --query "[*].[properties.contentLength]" \
    --output tsv |
    paste --serial --delimiters=+ | bc`

# Display total bytes
echo "Total bytes in container: $bytes"

# Delete the sample files created by this script
rm container_size_sample_file_*.txt
```

## Clean up deployment 

Run the following command to remove the resource group, container, and all related resources.

```azurecli
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands to calculate the size of the Blob storage container. Each item in the table links to command-specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.microsoft.com/cli/azure/group#create) | Creates a resource group in which all resources are stored. |
| [az storage blob upload](https://docs.microsoft.com/cli/azure/storage/account#create) | Uploads local files to an Azure Blob storage container. |
| [az storage blob list](https://docs.microsoft.com/cli/azure/storage/account/keys#list) | Lists the blobs in an Azure Blob storage container. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional storage CLI script samples can be found in the [Azure CLI samples for Azure Blob storage](../blobs/storage-samples-blobs-cli.md).
