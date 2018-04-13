---
title: Create VMs running an SQL&#92;IIS&#92;.NET stack in Azure| Azure
description: Tutorial - install a Azure SQL, IIS, .NET stack on a Windows virtual machines. 
services: virtual-machines-windows
documentationcenter: virtual-machines
author: rockboyfor
manager: digimobile
editor: tysonn
tags: azure-resource-manager

ms.service: virtual-machines-windows
ms.devlang: na
ms.topic: tutorial
ms.tgt_pltfrm: vm-windows
ms.workload: infrastructure
origin.date: 02/27/2018
ms.date: 04/16/2018
ms.author: v-yeche
ms.custom: mvc
---

# Install a SQL&#92;IIS&#92;.NET stack in Azure

In this tutorial, we install a SQL&#92;IIS&#92;.NET stack using Azure PowerShell. This stack consists of two VMs running Windows Server 2016, one with IIS and .NET and the other with SQL Server.

> [!div class="checklist"]
> * Create a VM 
> * Install IIS and the .NET Core SDK on the VM
> * Create a VM running SQL Server
> * Install the SQL Server extension


If you choose to install and use the PowerShell locally, this tutorial requires the AzureRM.Compute module version 4.3.1 or later. Run `Get-Module -ListAvailable AzureRM.Compute` to find the version. If you need to upgrade, see [Install Azure PowerShell module](https://docs.microsoft.com/powershell/azure/install-azurerm-ps).

## Create a IIS VM 

In this example, we use [New-AzureRMVM](https://docs.microsoft.com/powershell/module/azurerm.compute/new-azurermvm) cmdlet in the PowerShell Cloud Shell to quickly create a Windows Server 2016 VM and then install IIS and the .NET Framework. The IIS and SQL VMs share a resource group and virtual network, so we create variables for those names.

```azurepowershell-interactive
$vmName = "IISVM"
$vNetName = "myIISSQLvNet"
$resourceGroup = "myIISSQLGroup"
New-AzureRmVm `
    -ResourceGroupName $resourceGroup `
    -Name $vmName `
    -Location "chinaeast" `
    -VirtualNetworkName $vNetName `
    -SubnetName "myIISSubnet" `
    -SecurityGroupName "myNetworkSecurityGroup" `
	-AddressPrefix 192.168.0.0/16 `
    -PublicIpAddressName "myIISPublicIpAddress" `
    -OpenPorts 80,3389 
```

Install IIS and the .NET framework using the custom script extension.

```azurepowershell-interactive
Set-AzureRmVMExtension `
    -ResourceGroupName $resourceGroup `
    -ExtensionName IIS `
    -VMName $vmName `
    -Publisher Microsoft.Compute `
    -ExtensionType CustomScriptExtension `
    -TypeHandlerVersion 1.4 `
    -SettingString '{"commandToExecute":"powershell Add-WindowsFeature Web-Server,Web-Asp-Net45,NET-Framework-Features"}' `
    -Location chinaeast
```

## Create another subnet

Create a second subnet for the SQL VM. Get the vNet using [Get-AzureRmVirtualNetwork](https://docs.microsoft.com/powershell/module/azurerm.network/get-azurermvirtualnetwork).

```azurepowershell-interactive
$vNet = Get-AzureRmVirtualNetwork `
   -Name $vNetName `
   -ResourceGroupName $resourceGroup
```

Create a configuration for the subNet using [Add-AzureRmVirtualNetworkSubnetConfig](https://docs.microsoft.com/powershell/module/azurerm.network/add-azurermvirtualnetworksubnetconfig).

```azurepowershell-interactive
Add-AzureRmVirtualNetworkSubnetConfig `
   -AddressPrefix 192.168.0.0/24 `
   -Name mySQLSubnet `
   -VirtualNetwork $vNet `
   -ServiceEndpoint Microsoft.Sql
```

Update the vNet with the new subnet information using [Set-AzureRmVirtualNetwork](https://docs.microsoft.com/powershell/module/azurerm.network/set-azurermvirtualnetwork)

```azurepowershell-interactive   
$vNet | Set-AzureRmVirtualNetwork
```

## Azure SQL VM

Use a pre-configured Azure marketplace image of a SQL server to create the SQL VM. We first create the VM, then we install the SQL Server Extension on the VM. 

```azurepowershell-interactive
New-AzureRmVm `
    -ResourceGroupName $resourceGroup `
    -Name "mySQLVM" `
	-ImageName "MicrosoftSQLServer:SQL2016SP1-WS2016:Enterprise:latest" `
    -Location chinaeast `
    -VirtualNetworkName $vNetName `
    -SubnetName "mySQLSubnet" `
    -SecurityGroupName "myNetworkSecurityGroup" `
    -PublicIpAddressName "mySQLPublicIpAddress" `
    -OpenPorts 3389,1401 
```

Use [Set-AzureRmVMSqlServerExtension](https://docs.microsoft.com/powershell/module/azurerm.compute/set-azurermvmsqlserverextension) to add the [SQL Server extension](https://docs.microsoft.com/sql/virtual-machines-windows-sql-server-agent-extension) to the SQL VM.

```azurepowershell-interactive
Set-AzureRmVMSqlServerExtension `
   -ResourceGroupName $resourceGroup  `
   -VMName mySQLVM `
   -Name "SQLExtension" `
   -Location "chinaeast"
```

## Next steps

In this tutorial, you installed a SQL&#92;IIS&#92;.NET stack using Azure PowerShell. You learned how to:

> [!div class="checklist"]
> * Create a VM 
> * Install IIS and the .NET Core SDK on the VM
> * Create a VM running SQL Server
> * Install the SQL Server extension

Advance to the next tutorial to learn how to secure IIS web server with SSL certificates.

> [!div class="nextstepaction"]
> [Secure IIS web server with SSL certificates](tutorial-secure-web-server.md)
<!-- Update_Description: update meta properties, wording update -->