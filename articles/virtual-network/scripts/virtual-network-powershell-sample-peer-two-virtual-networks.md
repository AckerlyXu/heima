---
title: Azure PowerShell script sample - Peer two virtual networks | Azure
description: Azure PowerShell script sample - Peer two virtual networks
services: virtual-network
documentationcenter: virtual-network
author: rockboyfor
manager: digimobile
editor: ''
tags:

ms.assetid:
ms.service: virtual-network
ms.devlang: powershell
ms.topic: sample
ms.tgt_pltfrm:
ms.workload: infrastructure
origin.date: 03/20/2018
ms.date: 05/07/2018
ms.author: v-yeche
---

# Peer two virtual networks script sample

This script sample creates and connects two virtual networks in the same region through the Azure network. After running the script, you will create a peering between two virtual networks.

You can execute the script from a local PowerShell installation. If you use PowerShell locally, this script requires the AzureRM PowerShell module version 5.4.1 or later. To find the installed version, run `Get-Module -ListAvailable AzureRM`. If you need to upgrade, see [Install Azure PowerShell module](https://docs.microsoft.com/powershell/azure/install-azurerm-ps). If you are running PowerShell locally, you also need to run `Login-AzureRmAccount -EnvironmentName AzureChinaCloud` to create a connection with Azure.
<!-- Not Available on [Cloud Shell](https://shell.azure.com/powershell) -->

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurepowershell-interactive
# Variables for common values
$rgName='MyResourceGroup'
$location='chinaeast'

# Create a resource group.
New-AzureRmResourceGroup -Name $rgName -Location $location

# Create virtual network 1.
$vnet1 = New-AzureRmVirtualNetwork -ResourceGroupName $rgName -Name 'Vnet1' -AddressPrefix '10.0.0.0/16' -Location $location

# Create virtual network 2.
$vnet2 = New-AzureRmVirtualNetwork -ResourceGroupName $rgName -Name 'Vnet2' -AddressPrefix '10.1.0.0/16' -Location $location

# Peer VNet1 to VNet2.
Add-AzureRmVirtualNetworkPeering -Name 'LinkVnet1ToVnet2' -VirtualNetwork $vnet1 -RemoteVirtualNetworkId $vnet2.Id

# Peer VNet2 to VNet1.
Add-AzureRmVirtualNetworkPeering -Name 'LinkVnet2ToVnet1' -VirtualNetwork $vnet2 -RemoteVirtualNetworkId $vnet1.Id

```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources:

```powershell
Remove-AzureRmResourceGroup -Name myResourceGroup -Force
```

## Script explanation

This script uses the following commands to create a resource group, virtual machine, and all related resources. Each command in the following table links to command specific documentation:

| Command | Notes |
|---|---|
| [New-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/new-azurermresourcegroup) | Creates a resource group in which all resources are stored. | 
| [New-AzureRmVirtualNetwork](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermvirtualnetwork)| Creates an Azure virtual network and subnet. |
| [Add-AzureRmVirtualNetworkPeering](https://docs.microsoft.com/powershell/module/azurerm.network/add-azurermvirtualnetworkpeering) | Creates a peering between two virtual networks.  |
| [Remove-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/remove-azurermresourcegroup) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure PowerShell, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional virtual network PowerShell script samples can be found in [Virtual network PowerShell samples](../powershell-samples.md).
<!-- Update_Description: new articles on virtual network powershell sample peer two virtual networks script -->
<!--ms.date: 05/07/2018-->