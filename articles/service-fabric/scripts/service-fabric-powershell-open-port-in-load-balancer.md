---
title: Azure PowerShell Script Sample - Open application port in load balancer| Azure
description: Azure PowerShell Script Sample - Open a port in the Azure load balancer for a Service Fabric application.
services: service-fabric
documentationcenter: 
author: rockboyfor
manager: digimobile
editor: 
tags: azure-service-management

ms.assetid: 
ms.service: service-fabric
ms.workload: multiple
ms.devlang: na
ms.topic: sample
origin.date: 12/08/2017
ms.date: 01/01/2018
ms.author: v-yeche
ms.custom: mvc
---

# Open an application port in the Azure load balancer

A Service Fabric application running in Azure sits behind the Azure load balancer. This sample script opens a port in an Azure load balancer so that a Service Fabric application can communicate with external clients. Customize the parameters as needed. If your cluster is in a network security group, also [add an inbound network security group rule](service-fabric-powershell-add-nsg-rule.md) to allow inbound traffic.

If needed, install the Service Fabric PowerShell module with the [Service Fabric SDK](../service-fabric-get-started.md). 

## Sample script

```powershell
﻿# Variables
$probename = "AppPortProbe6"
$rulename="AppPortLBRule6"
$RGname="mysftestclustergroup"
$port=8303

# Get the load balancer resource
$resource = Get-AzureRmResource | Where {$_.ResourceGroupName -eq $RGname -and $_.ResourceType -eq "Microsoft.Network/loadBalancers"} 
$slb = Get-AzureRmLoadBalancer -Name $resource.Name -ResourceGroupName $RGname

# Add a new probe configuration to the load balancer
$slb | Add-AzureRmLoadBalancerProbeConfig -Name $probename -Protocol Tcp -Port $port -IntervalInSeconds 15 -ProbeCount 2

# Add rule configuration to the load balancer
$probe = Get-AzureRmLoadBalancerProbeConfig -Name $probename -LoadBalancer $slb
$slb | Add-AzureRmLoadBalancerRuleConfig -Name $rulename -BackendAddressPool $slb.BackendAddressPools[0] -FrontendIpConfiguration $slb.FrontendIpConfigurations[0] -Probe $probe -Protocol Tcp -FrontendPort $port -BackendPort $port

# Set the goal state for the load balancer
$slb | Set-AzureRmLoadBalancer

```

## Script explanation

This script uses the following commands. Each command in the table links to command-specific documentation.

| Command | Notes |
|---|---|
| [Get-AzureRmResource](https://docs.microsoft.com/powershell/module/azurerm.resources/get-azurermresource) | Gets an Azure resource.  |
| [Get-AzureRmLoadBalancer](https://docs.microsoft.com/powershell/module/azurerm.network/get-azurermloadbalancer) | Gets the Azure load balancer. |
| [Add-AzureRmLoadBalancerProbeConfig](https://docs.microsoft.com/powershell/module/azurerm.network/add-azurermloadbalancerprobeconfig) | Adds a probe configuration to a load balancer.|
| [Get-AzureRmLoadBalancerProbeConfig](https://docs.microsoft.com/powershell/module/azurerm.network/get-azurermloadbalancerprobeconfig) | Gets a probe configuration for a load balancer. |
| [Add-AzureRmLoadBalancerRuleConfig](https://docs.microsoft.com/powershell/module/azurerm.network/add-azurermloadbalancerruleconfig) | Adds a rule configuration to a load balancer. |
| [Set-AzureRmLoadBalancer](https://docs.microsoft.com/powershell/module/azurerm.network/set-azurermloadbalancer) | Sets the goal state for a load balancer. |

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional Powershell samples for Azure Service Fabric can be found in the [Azure PowerShell samples](../service-fabric-powershell-samples.md).

<!--Update_Description: update meta properties, update link -->