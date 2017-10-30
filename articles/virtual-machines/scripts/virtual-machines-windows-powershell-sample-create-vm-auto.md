---
title: Create a Windows VM using New-AzVM in Azure | Azure
description: Azure PowerShell Script Sample - Create a Windows VM using the New-AzVM cmdlet.
services: virtual-machines-windows
documentationcenter: virtual-machines
author: rockboyfor
manager: digimobile
editor: tysonn
tags: azure-service-management

ms.assetid:
ms.service: virtual-machines-windows
ms.devlang: na
ms.topic: sample
ms.tgt_pltfrm: vm-windows
ms.workload: infrastructure
origin.date: 09/29/2017
ms.date: 10/30/2017
ms.author: v-yeche

---

# Create a fully configured virtual machine with the New-AzVM PowerShell cmdlet (preview)

This script uses the New-AzVM cmdlet in Cloud Shell to create an Azure Virtual Machine running Windows Server 2016. After running the script, you can access the virtual machine over RDP. Cloud Shell has the module that includes New-AzVM installed by default, which makes it easier for you to check out the new functionality.

This sample uses the New-AzVM cmdlet, which is in preview. 

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

<!--Not Available [!INCLUDE [cloud-shell-powershell.md](../../../includes/cloud-shell-powershell.md)]-->

## Sample script

```powershell
New-AzVM -Name myVM `
	-VirtualNetworkName myVNet `
	-Location chinanorth `
	-SecurityGroupName myNSG `
	-PublicIpAddressName myPIP 
```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources.

```powershell
Remove-AzureRmResourceGroup -Name myVMResourceGroup
```

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional virtual machine PowerShell script samples can be found in the [Azure Windows VM documentation](../windows/powershell-samples.md?toc=%2fvirtual-machines%2fwindows%2ftoc.json).
<!--Update_Description: new articles on creat VM auto-->
