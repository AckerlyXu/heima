---
title: Azure PowerShell Script Sample - Add a network security group rule | Azure
description: Azure PowerShell Script Sample - Adds a network security group to allow inbound traffic on a specific port.
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
origin.date: 11/28/2017
ms.date: 01/01/2018
ms.author: v-yeche
ms.custom: mvc
---

# Add an inbound network security group rule

This sample script creates a network security group rule to allow inbound traffic on port 8081.  The script gets the `Microsoft.Network/networkSecurityGroups` resource that the cluster is located in, creates a new network security configuration rule, and updates the network security group. Customize the parameters as needed.

If needed, install the Azure PowerShell using the instructions found in the [Azure PowerShell guide](https://docs.microsoft.com/powershell/azure/overview). 

## Sample script

```powershell
﻿Login-AzureRmAccount -EnvironmentName AzureChinaCloud
Get-AzureRmSubscription
Set-AzureRmContext -SubscriptionId "yourSubscriptionID"

$RGname="sfclustertutorialgroup"
$port=8081
$rulename="allowAppPort$port"
$nsgname="sf-vnet-security"

# Get the NSG resource
$resource = Get-AzureRmResource | Where {$_.ResourceGroupName -eq $RGname -and $_.ResourceType -eq "Microsoft.Network/networkSecurityGroups"} 
$nsg = Get-AzureRmNetworkSecurityGroup -Name $nsgname -ResourceGroupName $RGname

# Add the inbound security rule.
$nsg | Add-AzureRmNetworkSecurityRuleConfig -Name $rulename -Description "Allow app port" -Access Allow `
    -Protocol * -Direction Inbound -Priority 3891 -SourceAddressPrefix "*" -SourcePortRange * `
    -DestinationAddressPrefix * -DestinationPortRange $port

# Update the NSG.
$nsg | Set-AzureRmNetworkSecurityGroup
```

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [Get-AzureRmResource](https://docs.microsoft.com/powershell/module/azurerm.resources/get-azurermresource) | Gets the `Microsoft.Network/networkSecurityGroups` resource. |
|[Get-AzureRmNetworkSecurityGroup](https://docs.microsoft.com/powershell/module/azurerm.network/get-azurermnetworksecuritygroup)| Gets the network security group by name.|
|[Add-AzureRmNetworkSecurityRuleConfig](https://docs.microsoft.com/powershell/module/azurerm.network/add-azurermnetworksecurityruleconfig)| Adds a network security rule configuration to a network security group. |
|[Set-AzureRmNetworkSecurityGroup](https://docs.microsoft.com/powershell/module/azurerm.network/set-azurermnetworksecuritygroup)| Sets the goal state for a network security group.|

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).
<!-- Update_Description: new articles on adding service fabric nsg rule with powershell -->