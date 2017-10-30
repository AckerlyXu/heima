---
title: Use New-AzVM to create an IIS VM in Azure | Azure
description: Azure PowerShell Script Sample - create a VM running IIS using New-AzVM.
services: virtual-machines-windows
documentationcenter: virtual-machines
author: rockboyfor
manager: digimobile
editor: tysonn
tags: azure-resource-management

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

# Create an IIS VM using the New-AzVM PowerShell cmdlet (preview)

This script creates an Azure Virtual Machine running Windows Server 2016, and then uses the Azure Virtual Machine Custom Script Extension to install IIS. After running the script, you can access the default IIS website on the public IP address of the virtual machine. 

This sample uses the New-AzVM cmdlet, which is in preview. 

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

<!-- Not Available [!INCLUDE [cloud-shell-powershell.md](../../../includes/cloud-shell-powershell.md)]-->

## Sample script

```powershell

New-AzVM -Name myVM `
	-VirtualNetworkName myVNet `
	-Location chinanorth `
	-SecurityGroupName myNSG `
	-PublicIpAddressName myPIP

# Create an inbound network security group rule for port 80

$nsgRuleHTTP = New-AzureRmNetworkSecurityRuleConfig -Name myNetworkSecurityGroupRuleHTTP  -Protocol Tcp `
  -Direction Inbound -Priority 1000 -SourceAddressPrefix * -SourcePortRange * -DestinationAddressPrefix * `
  -DestinationPortRange 80 -Access Allow

$nsg = Get-AzureRmNetworkSecurityGroup -Name myNSG -ResourceGroupName myVMResourceGroup
$nsg | Add-AzureRmNetworkSecurityRuleConfig -Name $nsgRuleHTTP -NetworkSecurityGroup myNSG 
$nsg | Set-AzureRmNetworkSecurityGroup

# Install IIS

Set-AzureRmVMExtension -ExtensionName "IIS" -ResourceGroupName myVMResourceGroup -VMName myVM `
  -Publisher "Microsoft.Compute" -ExtensionType "CustomScriptExtension" -TypeHandlerVersion 1.4 `
  -SettingString '{"commandToExecute":"powershell Add-WindowsFeature Web-Server"}' -Location chinanorth

```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources.

```powershell
Remove-AzureRmResourceGroup -Name myVMResourceGroup
```

## Script explanation

This script uses the following commands to create the deployment. Each item in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [New-AzureRmNetworkSecurityRuleConfig](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermnetworksecurityruleconfig) | Creates a network security group rule configuration. This configuration is used to create an NSG rule when the NSG is created. |
| [Get-AzureRmNetworkSecurityGroup](https://docs.microsoft.com/powershell/module/azurerm.network/get-azurermnetworksecuritygroup) | Gets NSG information. |
| [Add-AzureRmNetworkSecurityRuleConfig](https://docs.microsoft.com/powershell/module/azurerm.network/add-azurermnetworksecurityruleconfig) | Adds the new rule to the configuration. |
| [Set-AzureRmNetworkSecurityGroup](https://docs.microsoft.com/powershell/module/azurerm.network/Set-AzureRmNetworkSecurityGroup) | Updates the NSG with the new rule. |
| [Set-AzureRmVMExtension](https://docs.microsoft.com/powershell/module/azurerm.compute/set-azurermvmextension) | Add a VM extension to the virtual machine. In this sample, the custom script extension is used to install IIS. |
|[Remove-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/remove-azurermresourcegroup) | Removes a resource group and all resources contained within. |

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional virtual machine PowerShell script samples can be found in the [Azure Windows VM documentation](../windows/powershell-samples.md?toc=%2fvirtual-machines%2fwindows%2ftoc.json).
<!--Update_Description: new articles on create IIS auto-->
