---
title: PowerShell example-copy-Azure SQL database-new server | Azure
description: Azure PowerShell example script to copy a SQL database to a new server
services: sql-database
documentationcenter: sql-database
author: forester123
manager: digimobile
editor: carlrab
tags: azure-service-management

ms.assetid:
ms.service: sql-database
ms.custom: load & move data
ms.devlang: PowerShell
ms.topic: sample
ms.tgt_pltfrm: sql-database
ms.workload: database
origin.date: 04/01/2018
ms.date: 04/17/2018
ms.author: v-johch
---

# Use PowerShell to copy a SQL database to a new server

This PowerShell script example creates a copy of an existing database in a new server. 

[!INCLUDE [sample-powershell-install](../../../includes/sample-powershell-install-no-ssh.md)]

## Copy a database to a new server

```powershell
# Login-AzureRmAccount -EnvironmentName AzureChinaCloud
# Set the resource group name and location for your source server
$sourceresourcegroupname = "mySourceResourceGroup-$(Get-Random)"
$sourcelocation = "China East"
# Set the resource group name and location for your target server
$targetresourcegroupname = "myTargetResourceGroup-$(Get-Random)"
$targetlocation = "China East"
# Set an admin login and password for your server
$adminlogin = "ServerAdmin"
$password = "ChangeYourAdminPassword1"
# The logical server names have to be unique in the system
$sourceservername = "source-server-$(Get-Random)"
$targetservername = "target-server-$(Get-Random)"
# The sample database name
$sourcedatabasename = "mySampleDatabase"
$targetdatabasename = "CopyOfMySampleDatabase"
# The ip address range that you want to allow to access your servers
$sourcestartip = "0.0.0.0"
$sourceendip = "0.0.0.0"
$targetstartip = "0.0.0.0"
$targetendip = "0.0.0.0"

# Create two new resource groups
$sourceresourcegroup = New-AzureRmResourceGroup -Name $sourceresourcegroupname -Location $sourcelocation
$targetresourcegroup = New-AzureRmResourceGroup -Name $targetresourcegroupname -Location $targetlocation

# Create a server with a system wide unique server name
$sourceresourcegroup = New-AzureRmSqlServer -ResourceGroupName $sourceresourcegroupname `
    -ServerName $sourceservername `
    -Location $sourcelocation `
    -SqlAdministratorCredentials $(New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $adminlogin, $(ConvertTo-SecureString -String $password -AsPlainText -Force))
$targetresourcegroup = New-AzureRmSqlServer -ResourceGroupName $targetresourcegroupname `
    -ServerName $targetservername `
    -Location $targetlocation `
    -SqlAdministratorCredentials $(New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $adminlogin, $(ConvertTo-SecureString -String $password -AsPlainText -Force))

# Create a server firewall rule that allows access from the specified IP range
$sourceserverfirewallrule = New-AzureRmSqlServerFirewallRule -ResourceGroupName $sourceresourcegroupname `
    -ServerName $sourceservername `
    -FirewallRuleName "AllowedIPs" -StartIpAddress $sourcestartip -EndIpAddress $sourceendip
$targetserverfirewallrule = New-AzureRmSqlServerFirewallRule -ResourceGroupName $targetresourcegroupname `
    -ServerName $targetservername `
    -FirewallRuleName "AllowedIPs" -StartIpAddress $targetstartip -EndIpAddress $targetendip

# Create a blank database in the source-server with an S0 performance level
$sourcedatabase = New-AzureRmSqlDatabase  -ResourceGroupName $sourceresourcegroupname `
    -ServerName $sourceservername `
    -DatabaseName $sourcedatabasename -RequestedServiceObjectiveName "S0"

# Copy source database to the target server 
$databasecopy = New-AzureRmSqlDatabaseCopy -ResourceGroupName $sourceresourcegroupname `
    -ServerName $sourceservername `
    -DatabaseName $sourcedatabasename `
    -CopyResourceGroupName $targetresourcegroupname `
    -CopyServerName $targetservername `
    -CopyDatabaseName $targetdatabasename 

# Clean up deployment 
# Remove-AzureRmResourceGroup -ResourceGroupName $sourceresourcegroupname
# Remove-AzureRmResourceGroup -ResourceGroupName $targetresourcegroupname
```

## Clean up deployment

After the script sample has been run, the following command can be used to remove the resource group and all resources associated with it.

```powershell
Remove-AzureRmResourceGroup -ResourceGroupName $sourceresourcegroupname
Remove-AzureRmResourceGroup -ResourceGroupName $targetresourcegroupname
```

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [New-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/new-azurermresourcegroup) | Creates a resource group in which all resources are stored. |
| [New-AzureRmSqlServer](https://docs.microsoft.com/powershell/module/azurerm.sql/new-azurermsqlserver) | Creates a logical server that hosts a database or elastic pool. |
| [New-AzureRmSqlDatabase](https://docs.microsoft.com/powershell/module/azurerm.sql/new-azurermsqldatabase) | Creates a database in a logical server as a single or a pooled database. |
| [New-AzureRmSqlDatabaseCopy](https://docs.microsoft.com/powershell/module/azurerm.sql/new-azurermsqldatabasecopy) | Creates a copy of a database that uses the snapshot at the current time. |
| [Remove-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/remove-azurermresourcegroup) | Deletes a resource group including all nested resources. |
|||

## Next steps

For more information on the Azure PowerShell, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional SQL Database PowerShell script samples can be found in the [Azure SQL Database PowerShell scripts](../sql-database-powershell-samples.md).

<!--Update_Description: update "Clean up deployment" script-->