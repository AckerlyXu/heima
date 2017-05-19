---
title: Azure PowerShell Script-Create a firewall for Azure Cosmos DB | Azure
description: Azure PowerShell Script Sample - Create a firewall for Azure Cosmos DB
services: cosmosdb
documentationcenter: cosmosdb
author: mimig1
manager: jhubbard
editor: ''
tags: azure-service-management

ms.assetid:
ms.service: cosmosdb
ms.custom: sample
ms.devlang: PowerShell
ms.topic: article
ms.tgt_pltfrm: cosmosdb
ms.workload: database
ms.date: 05/10/2017
wacn.date: ''
ms.author: mimig
---

# Azure Cosmos DB: Create a firewall using PowerShell

This sample PowerShell script creates a firewall for any kind of Azure Cosmos DB API account. 

[!INCLUDE [sample-powershell-install](../../../includes/sample-powershell-install-no-ssh.md)]

## Sample script

```powershell
# Set the Azure resource group name and location
$resourceGroupName = "myResourceGroup"
$resourceGroupLocation = "South Central US"

# Database name
$DBName = "testdb"
# Distribution locations
$locations = @(@{"locationName"="East US"; 
                 "failoverPriority"=0},
               @{"locationName"="West US"; 
                 "failoverPriority"=1})

# Create the resource group
New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation

# Consistency policy
$consistencyPolicy = @{"maxIntervalInSeconds"="10"; 
                       "maxStalenessPrefix"="200"}

# DB properties without firewall configuration
$DBProperties = @{"databaseAccountOfferType"="Standard";
                  "Kind"="GlobalDocumentDB"; 
                  "locations"=$locations; 
                  "consistencyPolicy"=$consistencyPolicy;}

# Create the database
New-AzureRmResource -ResourceType "Microsoft.DocumentDb/databaseAccounts" `
                    -ApiVersion "2015-04-08" `
                    -ResourceGroupName $resourceGroupName `
                    -Location $resourceGroupLocation `
                    -Name $DBName `
                    -PropertyObject $DBProperties

# Add an IP range filter to the properties
$updateDBProperties = @{"databaseAccountOfferType"="Standard";
                        "ipRangeFilter"="10.0.0.1";}

# Update the database with the properties
Set-AzureRmResource -ResourceType "Microsoft.DocumentDb/databaseAccounts" `
    -ApiVersion "2015-04-08" `
    -ResourceGroupName $resourceGroupName `
    -Name $DBName `
    -PropertyObject $DBProperties

```

## Clean up deployment

After the script sample has been run, the following command can be used to remove the resource group and all resources associated with it.

```powershell
Remove-AzureRmResourceGroup -ResourceGroupName "myResourceGroup"
```

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [New-AzureRmResourceGroup](https://docs.microsoft.com/powershell/resourcemanager/azurerm.resources/v3.5.0/new-azurermresourcegroup) | Creates a resource group in which all resources are stored. |
| [New-AzureRmResource](https://docs.microsoft.com/powershell/module/azurerm.resources/new-azurermresource?view=azurermps-3.8.0) | Creates a logical server that hosts a database or elastic pool. |
| [Set-AzureRMResource](https://docs.microsoft.com/powershell/module/azurerm.resources/set-azurermresource?view=azurermps-3.8.0) | Modifies the database account. |
| [Remove-AzureRmResourceGroup](https://docs.microsoft.com/powershell/resourcemanager/azurerm.resources/v3.5.0/remove-azurermresourcegroup) | Deletes a resource group including all nested resources. |
|||

## Next steps

For more information on the Azure PowerShell, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/).

Additional Azure Cosmos DB PowerShell script samples can be found in the [Azure Cosmos DB PowerShell scripts](../powershell-samples.md).