---
title: Azure PowerShell Script Sample - Change the RDP port range | Azure
description: Azure PowerShell Script Sample - Changes the RDP port range of a deployed cluster.
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

# Update the RDP port range values

This sample script changes the RDP port range values on the cluster node VMs after the cluster has been deployed.  Azure PowerShell is used so that the underlying VMs do not cycle.  The script gets the `Microsoft.Network/loadBalancers` resource in cluster's resource group and updates the `inboundNatPools.frontendPortRangeStart` and `inboundNatPools.frontendPortRangeEnd` values. Customize the parameters as needed.

If needed, install the Azure PowerShell using the instruction found in the [Azure PowerShell guide](https://docs.microsoft.com/powershell/azure/overview). 

## Sample script

```powershell
﻿Login-AzureRmAccount -EnvironmentName AzureChinaCloud
Get-AzureRmSubscription
Set-AzureRmContext -SubscriptionId 'yourSubscriptionId'

$groupname = "mysfclustergroup"
$start=3400
$end=4400

# Get the load balancer resource
$resource = Get-AzureRmResource | Where {$_.ResourceGroupName -eq $groupname -and $_.ResourceType -eq "Microsoft.Network/loadBalancers"} 
$lb = Get-AzureRmResource -ResourceGroupName $groupname -ResourceType Microsoft.Network/loadBalancers -ResourceName $resource.Name

# Update the front end port range
$lb.Properties.inboundNatPools.properties.frontendPortRangeStart = $start
$lb.Properties.inboundNatPools.properties.frontendPortRangeEnd = $end

# Write the inbound NAT pools properties
Write-Host ($lb.Properties.inboundNatPools | Format-List | Out-String)

# Update the load balancer
Set-AzureRmResource -PropertyObject $lb.Properties -ResourceGroupName $groupname -ResourceType Microsoft.Network/loadBalancers -ResourceName $lbname  -Force

```

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [Get-AzureRmResource](https://docs.microsoft.com/powershell/module/azurerm.resources/get-azurermresource) | Gets the `Microsoft.Network/loadBalancers` resource. |
|[Set-AzureRmResource](https://docs.microsoft.com/powershell/module/azurerm.resources/set-azurermresource)|Updates the `Microsoft.Network/loadBalancers` resource.|

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional Azure Powershell samples for Azure Service Fabric can be found in the [Azure PowerShell samples](../service-fabric-powershell-samples.md).

<!-- Update_Description: new articles on changing service fabric rdp port range with powershell -->