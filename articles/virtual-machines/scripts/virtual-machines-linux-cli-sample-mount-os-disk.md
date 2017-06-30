---
title: Azure CLI Script Sample - Mount operating system disk | Azure
description: Azure CLI Script Sample - Mount operating system disk
services: virtual-machines-linux
documentationcenter: virtual-machines
author: neilpeterson
manager: timlt
editor: tysonn
tags: azure-service-management

ms.assetid:
ms.service: virtual-machines-linux
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: vm-linux
ms.workload: infrastructure
origin.date: 02/27/2017
ms.date: 06/20/2017
ms.author: v-dazen
ms.custom: mvc
---

# Troubleshoot a VMs operating system disk

This script mounts the operating system disk of a failed or problematic virtual machine as a data disk to a second virtual machine. This can be useful when troubleshooting disk issues or recovering data. 

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurecli
#!/bin/bash

# Source virtual machine details.
sourcevm=<Replace with vm name>
resourcegroup=<Replace with resource group name>

# Get the disk id for the source VM operating system disk.
diskid="$(az vm show -g $resourcegroup -n $sourcevm --query [storageProfile.osDisk.managedDisk.id] -o tsv)"

# Delete the source virtual machine, this will not delete the disk.
az vm delete -g $resourcegroup -n $sourcevm --yes

# Create a new virtual machine, this creates SSH keys if not present.
az vm create --resource-group $resourcegroup --name myVM --image UbuntuLTS --generate-ssh-keys

# Attach disk as a data disk to the newly created VM.
az vm disk attach --resource-group $resourcegroup --vm-name myVM --disk $diskid

# Configure disk on new VM.
ip=$(az vm list-ip-addresses --resource-group $resourcegroup --name myVM --query '[].virtualMachine.network.publicIpAddresses[0].ipAddress' -o tsv)
ssh $ip 'sudo mkdir /mnt/remountedOsDisk'
ssh $ip 'sudo mount -t ext4 /dev/sdc1 /mnt/remountedOsDisk'

```

## Script explanation

This script uses the following commands to create a resource group, virtual machine, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az vm show](https://docs.microsoft.com/cli/azure/vm#show) | Return a list of virtual machines. In this case, the query option is used to return the virtual machine operating system disk. This value is then added to a variable name 'uri'. |
| [az vm delete](https://docs.microsoft.com/cli/azure/vm#delete) | Deletes a virtual machine. |
| [az vm create](https://docs.microsoft.com/cli/azure/vm#create) | Creates a virtual machine.  |
| [az vm disk attach](https://docs.microsoft.com/cli/azure/vm/disk#attach) | Attaches a disk to a virtual machine. |
| [az vm list-ip-addresses](https://docs.microsoft.com/cli/azure/vm#list-ip-addresses) | Returns the IP addresses of a virtual machine. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional virtual machine CLI script samples can be found in the [Azure Linux VM documentation](../linux/cli-samples.md?toc=%2fvirtual-machines%2flinux%2ftoc.json).
