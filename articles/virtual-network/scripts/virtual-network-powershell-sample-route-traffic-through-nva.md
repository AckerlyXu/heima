---
title: Azure PowerShell script sample - Route traffic through a network virtual appliance | Azure
description: Azure PowerShell script sample - Route traffic through a firewall network virtual appliance.
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

# Route traffic through a network virtual appliance script sample

This script sample creates a virtual network with front-end and back-end subnets. It also creates a VM with IP forwarding enabled to route traffic between the two subnets. After running the script you can deploy network software, such as a firewall application, to the VM.

You can execute the script from the Azure [Cloud Shell](https://shell.azure.com/powershell), or from a local PowerShell installation. If you use PowerShell locally, this script requires the AzureRM PowerShell module version 5.4.1 or later. To find the installed version, run `Get-Module -ListAvailable AzureRM`. If you need to upgrade, see [Install Azure PowerShell module](https://docs.microsoft.com/powershell/azure/install-azurerm-ps). If you are running PowerShell locally, you also need to run `Login-AzureRmAccount -EnvironmentName AzureChinaCloud` to create a connection with Azure.

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurepowershell-interactive
# Variables for common values
$rgName='MyResourceGroup'
$location='chinaeast'

# Create user object
$cred = Get-Credential -Message 'Enter a username and password for the virtual machine.'

# Create a resource group.
New-AzureRmResourceGroup -Name $rgName -Location $location

# Create a virtual network, a front-end subnet, a back-end subnet, and a DMZ subnet.
$fesubnet = New-AzureRmVirtualNetworkSubnetConfig -Name 'MySubnet-FrontEnd' -AddressPrefix 10.0.1.0/24
$besubnet = New-AzureRmVirtualNetworkSubnetConfig -Name 'MySubnet-BackEnd' -AddressPrefix 10.0.2.0/24
$dmzsubnet = New-AzureRmVirtualNetworkSubnetConfig -Name 'MySubnet-Dmz' -AddressPrefix 10.0.0.0/24

$vnet = New-AzureRmVirtualNetwork -ResourceGroupName $rgName -Name 'MyVnet' -AddressPrefix 10.0.0.0/16 `
  -Location $location -Subnet $fesubnet, $besubnet, $dmzsubnet

# Create NSG rules to allow HTTP & HTTPS traffic inbound.
$rule1 = New-AzureRmNetworkSecurityRuleConfig -Name 'Allow-HTTP-ALL' -Description 'Allow HTTP' `
  -Access Allow -Protocol Tcp -Direction Inbound -Priority 100 `
  -SourceAddressPrefix Internet -SourcePortRange * `
  -DestinationAddressPrefix * -DestinationPortRange 80

$rule2 = New-AzureRmNetworkSecurityRuleConfig -Name 'Allow-HTTPS-All' -Description 'Allow HTTPS' `
  -Access Allow -Protocol Tcp -Direction Inbound -Priority 200 `
  -SourceAddressPrefix Internet -SourcePortRange * `
  -DestinationAddressPrefix * -DestinationPortRange 443

# Create a network security group (NSG) for the front-end subnet.
$nsg = New-AzureRmNetworkSecurityGroup -ResourceGroupName $RgName -Location $location `
-Name 'MyNsg-FrontEnd' -SecurityRules $rule1,$rule2

# Associate the front-end NSG to the front-end subnet.
Set-AzureRmVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name 'MySubnet-FrontEnd' `
  -AddressPrefix '10.0.1.0/24' -NetworkSecurityGroup $nsg

# Create a public IP address for the firewall VM.
$publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgName -Name 'MyPublicIP-Firewall' `
  -location $location -AllocationMethod Dynamic

# Create a NIC for the firewall VM and enable IP forwarding.
$nicVMFW = New-AzureRmNetworkInterface -ResourceGroupName $rgName -Location $location -Name 'MyNic-Firewall' `
  -PublicIpAddress $publicip -Subnet $vnet.Subnets[2] -EnableIPForwarding

#Create a firewall VM to accept all traffic between the front and back-end subnets.
$vmConfig = New-AzureRmVMConfig -VMName 'MyVm-Firewall' -VMSize Standard_DS2 | `
    Set-AzureRmVMOperatingSystem -Windows -ComputerName 'MyVm-Firewall' -Credential $cred | `
    Set-AzureRmVMSourceImage -PublisherName MicrosoftWindowsServer -Offer WindowsServer `
    -Skus 2016-Datacenter -Version latest | Add-AzureRmVMNetworkInterface -Id $nicVMFW.Id

$vm = New-AzureRmVM -ResourceGroupName $rgName -Location $location -VM $vmConfig

# Create a route for traffic from the front-end to the back-end subnet through the firewall VM.
$route = New-AzureRmRouteConfig -Name 'RouteToBackEnd' -AddressPrefix 10.0.2.0/24 `
  -NextHopType VirtualAppliance -NextHopIpAddress $nicVMFW.IpConfigurations[0].PrivateIpAddress

# Create a route for traffic from the front-end subnet to the Internet through the firewall VM.
$route2 = New-AzureRmRouteConfig -Name 'RouteToInternet' -AddressPrefix 0.0.0.0/0 `
  -NextHopType VirtualAppliance -NextHopIpAddress $nicVMFW.IpConfigurations[0].PrivateIpAddress

# Create route table for the FrontEnd subnet.
$routeTableFEtoBE = New-AzureRmRouteTable -Name 'MyRouteTable-FrontEnd' -ResourceGroupName $rgName `
  -location $location -Route $route, $route2

# Associate the route table to the FrontEnd subnet.
Set-AzureRmVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name 'MySubnet-FrontEnd' -AddressPrefix 10.0.1.0/24 `
  -NetworkSecurityGroup $nsg -RouteTable $routeTableFEtoBE

# Create a route for traffic from the back-end subnet to the front-end subnet through the firewall VM.
$route = New-AzureRmRouteConfig -Name 'RouteToFrontEnd' -AddressPrefix '10.0.1.0/24' -NextHopType VirtualAppliance `
  -NextHopIpAddress $nicVMFW.IpConfigurations[0].PrivateIPAddress

# Create a route for traffic from the back-end subnet to the Internet through the firewall VM.
$route2 = New-AzureRmRouteConfig -Name 'RouteToInternet' -AddressPrefix '0.0.0.0/0' -NextHopType VirtualAppliance `
  -NextHopIpAddress $nicVMFW.IpConfigurations[0].PrivateIPAddress

# Create route table for the BackEnd subnet.
$routeTableBE = New-AzureRmRouteTable -Name 'MyRouteTable-BackEnd' -ResourceGroupName $rgName `
  -location $location -Route $route, $route2

# Associate the route table to the BackEnd subnet.
Set-AzureRmVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name 'MySubnet-BackEnd' `
  -AddressPrefix '10.0.2.0/24' -RouteTable $routeTableBE
```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources:

```powershell
Remove-AzureRmResourceGroup -Name myResourceGroup -Force
```
## Script explanation

This script uses the following commands to create a resource group, virtual network, and network security groups. Each command in the following table links to command-specific documentation:

| Command | Notes |
|---|---|
| [New-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/new-azurermresourcegroup)  | Creates a resource group in which all resources are stored. |
| [New-AzureRmVirtualNetwork](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermvirtualnetwork) | Creates an Azure virtual network and front-end subnet. |
| [New-AzureRmVirtualNetworkSubnetConfig](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermvirtualnetworksubnetconfig) | Creates back-end and DMZ subnets. |
| [New-AzureRmPublicIpAddress](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermpublicipaddress) | Creates a public IP address to access the VM from the internet. |
| [New-AzureRmNetworkInterface](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermnetworkinterface) | Creates a virtual network interface and enable IP forwarding for it. |
| [New-AzureRmNetworkSecurityGroup](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermnetworksecuritygroup) | Creates a network security group (NSG). |
| [New-AzureRmNetworkSecurityRuleConfig](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermnetworksecurityruleconfig) | Creates NSG rules that allow HTTP and HTTPS ports inbound to the VM. |
| [Set-AzureRmVirtualNetworkSubnetConfig](https://docs.microsoft.com/powershell/module/azurerm.network/set-azurermvirtualnetworksubnetconfig)| Associates the NSGs and route tables to subnets. |
| [New-AzureRmRouteTable](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermroutetable)| Creates a route table for all routes. |
| [New-AzureRMRouteConfig](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermrouteconfig)| Creates routes to route traffic between subnets and the internet through the VM. |
| [New-AzureRmVM](https://docs.microsoft.com/powershell/module/azurerm.compute/new-azurermvm) | Creates a virtual machine and attaches the NIC to it. This command also specifies the virtual machine image to use and administrative credentials. |
| [Remove-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/remove-azurermresourcegroup)  | Deletes a resource group and all resources it contains. |

## Next steps

For more information on the Azure PowerShell, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional virtual network PowerShell script samples can be found in [Virtual network PowerShell samples](../powershell-samples.md).
<!-- Update_Description: new articles on virtual network powershell sample route traffic through nva script -->
<!--ms.date: 05/07/2018-->