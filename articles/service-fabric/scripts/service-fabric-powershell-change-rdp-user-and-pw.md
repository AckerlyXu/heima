---
title: Azure PowerShell Script Sample - Update the RDP username and password | Azure
description: Azure PowerShell Script Sample - Update the RDP username and password for all Service Fabric cluster nodes of a specific node type.
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
origin.date: 11/17/2017
ms.date: 01/01/2018
ms.author: v-yeche
ms.custom: mvc
---

# Update the admin username and password of the VMs in a cluster

Each node type in a Service Fabric cluster is a virtual machine scale set. This sample script updates the admin username and password for the cluster virtual machines in a specific node type.  Add the VMAccessAgent extension to the scale set, because the admin password is not a modifiable scale set property.  The username and password changes apply to all nodes in the scale set. Customize the parameters as needed.

If needed, install the Azure PowerShell using the instruction found in the [Azure PowerShell guide](https://docs.microsoft.com/powershell/azure/overview). 

## Sample script

```powershell
﻿Login-AzureRmAccount -EnvironmentName AzureChinaCloud
Get-AzureRmSubscription
Set-AzureRmContext -SubscriptionId 'yourSubscriptionID'

$nodeTypeName = 'nt1vm'
$resourceGroup = 'sfclustertutorialgroup'
$publicConfig = @{'UserName' = 'newuser'}
$privateConfig = @{'Password' = 'PasSwo0rd$#!'}
$extName = 'VMAccessAgent'
$publisher = 'Microsoft.Compute'
$node = Get-AzureRmVmss -ResourceGroupName $resourceGroup -VMScaleSetName $nodeTypeName
$node = Add-AzureRmVmssExtension -VirtualMachineScaleSet $node -Name $extName -Publisher $publisher -Setting $publicConfig -ProtectedSetting $privateConfig -Type $extName -TypeHandlerVersion '2.0' -AutoUpgradeMinorVersion $true

Update-AzureRmVmss -ResourceGroupName $resourceGroup -Name $nodeTypeName -VirtualMachineScaleSet $node
```

## Script explanation

This script uses the following commands: Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [Get-AzureRmVmss](https://docs.microsoft.com/powershell/module/azurerm.compute/get-azurermvmss) | Gets the properties of a cluster node type (a virtual machine scale set).   |
| [Add-AzureRmVmssExtension](https://docs.microsoft.com/powershell/module/azurerm.compute/add-azurermvmssextension)| Adds an extension to the virtual machine scale set.|
| [Update-AzureRmVmss](https://docs.microsoft.com/powershell/module/azurerm.compute/update-azurermvmss)|Updates the state of a virtual machine scale set to the state of a local VMSS object.|

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional Azure Powershell samples for Azure Service Fabric can be found in the [Azure PowerShell samples](../service-fabric-powershell-samples.md).
<!-- Update_Description: new articles on changing rdp service fabric user and password with powershell-->