---
title: Azure PowerShell Script Sample - Create a Windows VM NLB | Azure
description: Azure PowerShell Script Sample - Create a Windows VM NLB
services: virtual-machines-windows
documentationcenter: virtual-machines
author: neilpeterson
manager: timlt
editor: tysonn
tags: azure-service-management

ms.assetid:
ms.service: virtual-machines-windows
ms.devlang: na
ms.topic: sample
ms.tgt_pltfrm: vm-windows
ms.workload: infrastructure
origin.date: 06/05/2017
ms.date: ''
ms.author: v-dazen
ms.custom: mvc
---

# Load balance traffic between highly available virtual machines

This script sample creates everything needed to run several Windows Server 2016 virtual machines configured in a highly available and load balanced configuration. After running the script, you will have three virtual machines, joined to an Azure Availability Set, and accessible through an Azure Load Balancer.

[!INCLUDE [sample-powershell-install](../../../includes/sample-powershell-install-no-ssh.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```powershell
# Variables for common values
$rgName='MyResourceGroup'
$location='chinaeast'

# Create user object
$cred = Get-Credential -Message 'Enter a username and password for the virtual machine.'

# Create a resource group.
New-AzureRmResourceGroup -Name $rgName -Location $location

# Create a virtual network.
$subnet = New-AzureRmVirtualNetworkSubnetConfig -Name 'MySubnet' -AddressPrefix 192.168.1.0/24

$vnet = New-AzureRmVirtualNetwork -ResourceGroupName $rgName -Name 'MyVnet' `
  -AddressPrefix 192.168.0.0/16 -Location $location -Subnet $subnet

# Create a public IP address.
$publicIp = New-AzureRmPublicIpAddress -ResourceGroupName $rgName -Name 'myPublicIP' `
  -Location $location -AllocationMethod Dynamic

# Create a front-end IP configuration for the website.
$feip = New-AzureRmLoadBalancerFrontendIpConfig -Name 'myFrontEndPool' -PublicIpAddress $publicIp

# Create the back-end address pool.
$bepool = New-AzureRmLoadBalancerBackendAddressPoolConfig -Name 'myBackEndPool'

# Creates a load balancer probe on port 80.
$probe = New-AzureRmLoadBalancerProbeConfig -Name 'myHealthProbe' -Protocol Http -Port 80 `
  -RequestPath / -IntervalInSeconds 360 -ProbeCount 5

# Creates a load balancer rule for port 80.
$rule = New-AzureRmLoadBalancerRuleConfig -Name 'myLoadBalancerRuleWeb' -Protocol Tcp `
  -Probe $probe -FrontendPort 80 -BackendPort 80 `
  -FrontendIpConfiguration $feip -BackendAddressPool $bePool

# Create three NAT rules for port 3389.
$natrule1 = New-AzureRmLoadBalancerInboundNatRuleConfig -Name 'myLoadBalancerRDP1' -FrontendIpConfiguration $feip `
  -Protocol tcp -FrontendPort 4221 -BackendPort 3389

$natrule2 = New-AzureRmLoadBalancerInboundNatRuleConfig -Name 'myLoadBalancerRDP2' -FrontendIpConfiguration $feip `
  -Protocol tcp -FrontendPort 4222 -BackendPort 3389

$natrule3 = New-AzureRmLoadBalancerInboundNatRuleConfig -Name 'myLoadBalancerRDP3' -FrontendIpConfiguration $feip `
  -Protocol tcp -FrontendPort 4223 -BackendPort 3389

# Create a load balancer.
$lb = New-AzureRmLoadBalancer -ResourceGroupName $rgName -Name 'MyLoadBalancer' -Location $location `
  -FrontendIpConfiguration $feip -BackendAddressPool $bepool `
  -Probe $probe -LoadBalancingRule $rule -InboundNatRule $natrule1,$natrule2,$natrule3

# Create a network security group rule for port 3389.
$rule1 = New-AzureRmNetworkSecurityRuleConfig -Name 'myNetworkSecurityGroupRuleRDP' -Description 'Allow RDP' `
  -Access Allow -Protocol Tcp -Direction Inbound -Priority 1000 `
  -SourceAddressPrefix Internet -SourcePortRange * `
  -DestinationAddressPrefix * -DestinationPortRange 3389

# Create a network security group rule for port 80.
$rule2 = New-AzureRmNetworkSecurityRuleConfig -Name 'myNetworkSecurityGroupRuleHTTP' -Description 'Allow HTTP' `
  -Access Allow -Protocol Tcp -Direction Inbound -Priority 2000 `
  -SourceAddressPrefix Internet -SourcePortRange * `
  -DestinationAddressPrefix * -DestinationPortRange 80

# Create a network security group
$nsg = New-AzureRmNetworkSecurityGroup -ResourceGroupName $RgName -Location $location `
-Name 'myNetworkSecurityGroup' -SecurityRules $rule1,$rule2

# Create three virtual network cards and associate with public IP address and NSG.
$nicVM1 = New-AzureRmNetworkInterface -ResourceGroupName $rgName -Location $location `
  -Name 'MyNic1' -LoadBalancerBackendAddressPool $bepool -NetworkSecurityGroup $nsg `
  -LoadBalancerInboundNatRule $natrule1 -Subnet $vnet.Subnets[0]

$nicVM2 = New-AzureRmNetworkInterface -ResourceGroupName $rgName -Location $location `
  -Name 'MyNic2' -LoadBalancerBackendAddressPool $bepool -NetworkSecurityGroup $nsg `
  -LoadBalancerInboundNatRule $natrule2 -Subnet $vnet.Subnets[0]

$nicVM3 = New-AzureRmNetworkInterface -ResourceGroupName $rgName -Location $location `
  -Name 'MyNic3' -LoadBalancerBackendAddressPool $bepool -NetworkSecurityGroup $nsg `
  -LoadBalancerInboundNatRule $natrule3 -Subnet $vnet.Subnets[0]

# Create an availability set.
$as = New-AzureRmAvailabilitySet -ResourceGroupName $rgName -Location $location `
  -Name 'MyAvailabilitySet' -Sku Aligned -PlatformFaultDomainCount 3 -PlatformUpdateDomainCount 3

# Create three virtual machines.

# ############## VM1 ###############

# Create a virtual machine configuration
$vmConfig = New-AzureRmVMConfig -VMName 'myVM1' -VMSize Standard_DS2 -AvailabilitySetId $as.Id | `
  Set-AzureRmVMOperatingSystem -Windows -ComputerName 'myVM1' -Credential $cred | `
  Set-AzureRmVMSourceImage -PublisherName MicrosoftWindowsServer -Offer WindowsServer `
  -Skus 2016-Datacenter -Version latest | Add-AzureRmVMNetworkInterface -Id $nicVM1.Id

# Create a virtual machine
$vm1 = New-AzureRmVM -ResourceGroupName $rgName -Location $location -VM $vmConfig

# ############## VM2 ###############

# Create a virtual machine configuration
$vmConfig = New-AzureRmVMConfig -VMName 'myVM2' -VMSize Standard_DS2 -AvailabilitySetId $as.Id | `
  Set-AzureRmVMOperatingSystem -Windows -ComputerName 'myVM2' -Credential $cred | `
  Set-AzureRmVMSourceImage -PublisherName MicrosoftWindowsServer -Offer WindowsServer `
  -Skus 2016-Datacenter -Version latest | Add-AzureRmVMNetworkInterface -Id $nicVM2.Id

# Create a virtual machine
$vm2 = New-AzureRmVM -ResourceGroupName $rgName -Location $location -VM $vmConfig

# ############## VM3 ###############

# Create a virtual machine configuration
$vmConfig = New-AzureRmVMConfig -VMName 'myVM3' -VMSize Standard_DS2 -AvailabilitySetId $as.Id | `
  Set-AzureRmVMOperatingSystem -Windows -ComputerName 'myVM3' -Credential $cred | `
  Set-AzureRmVMSourceImage -PublisherName MicrosoftWindowsServer -Offer WindowsServer `
  -Skus 2016-Datacenter -Version latest | Add-AzureRmVMNetworkInterface -Id $nicVM3.Id

# Create a virtual machine
$vm3 = New-AzureRmVM -ResourceGroupName $rgName -Location $location -VM $vmConfig

```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources.

```powershell
Remove-AzureRmResourceGroup -Name myResourceGroup
```

## Script explanation

This script uses the following commands to create the deployment. Each item in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [New-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/new-azurermresourcegroup) | Creates a resource group in which all resources are stored. |
| [New-AzureRmVirtualNetworkSubnetConfig](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermvirtualnetworksubnetconfig) | Creates a subnet configuration. This configuration is used with the virtual network creation process. |
| [New-AzureRmVirtualNetwork](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermvirtualnetwork) | Creates a virtual network. |
| [New-AzureRmPublicIpAddress](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermpublicipaddress) | Creates a public IP address. |
| [New-AzureRmLoadBalancerFrontendIpConfig](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermloadbalancerfrontendipconfig) | Creates a front-end IP configuration for a load balancer. |
| [New-AzureRmLoadBalancerBackendAddressPoolConfig](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermloadbalancerbackendaddresspoolconfig) | Creates a backend address pool configuration for a load balancer. |
| [New-AzureRmLoadBalancerProbeConfig](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermloadbalancerprobeconfig) | Creates a probe configuration for a load balancer. |
| [New-AzureRmLoadBalancerRuleConfig](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermloadbalancerruleconfig) | Creates a rule configuration for a load balancer. |
| [New-AzureRmLoadBalancerInboundNatRuleConfig](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermloadbalancerinboundnatruleconfig) | Creates an inbound NAT rule configuration for a load balancer. |
| [New-AzureRmLoadBalancer](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermloadbalancer) | Creates a load balancer. |
| [New-AzureRmNetworkSecurityRuleConfig](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermnetworksecurityruleconfig) | Creates a network security group rule configuration. This configuration is used to create an NSG rule when the NSG is created. |
| [New-AzureRmNetworkSecurityGroup](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermnetworksecuritygroup) | Creates a network security group. |
| [Get-AzureRmVirtualNetworkSubnetConfig](https://docs.microsoft.com/powershell/module/azurerm.network/get-azurermvirtualnetworksubnetconfig) | Gets subnet information. This information is used when creating a network interface. |
| [New-AzureRmNetworkInterface](https://docs.microsoft.com/powershell/module/azurerm.network/new-azurermnetworkinterface) | Creates a network interface. |
| [New-AzureRmVMConfig](https://docs.microsoft.com/powershell/module/azurerm.compute/new-azurermvmconfig) | Creates a VM configuration. This configuration includes information such as VM name, operating system, and administrative credentials. The configuration is used during VM creation. |
| [New-AzureRmVM](https://docs.microsoft.com/powershell/module/azurerm.compute/new-azurermvm) | Create a virtual machine. |
|[Remove-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/remove-azurermresourcegroup) | Removes a resource group and all resources contained within. |

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional virtual machine PowerShell script samples can be found in the [Azure Windows VM documentation](../windows/powershell-samples.md?toc=%2fvirtual-machines%2fwindows%2ftoc.json).