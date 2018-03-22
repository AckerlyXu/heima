---
title: PowerShell example-restore-backup-Azure SQL database | Azure
description: Azure PowerShell example script to restore an Azure SQL database from geo-redundant backups
services: sql-database
documentationcenter: sql-database
author: forester123
manager: digimobile
editor: carlrab
tags: azure-service-management

ms.assetid:
ms.service: sql-database
ms.custom: business continuity
ms.devlang: PowerShell
ms.topic: sample
ms.tgt_pltfrm: sql-database
ms.workload: database
origin.date: 06/23/2017
ms.date: 2/28/2018
ms.author: v-johch
---

# Use PowerShell to restore an Azure SQL database from backups

This PowerShell script example restores an Azure SQL database from a geo-redundant backup, restores a deleted Azure SQL database to its latest backup, and restores an Azure SQL database to a specific point in time.  

[!INCLUDE [sample-powershell-install](../../../includes/sample-powershell-install-no-ssh.md)]

## Sample script

```powershell
# Login-AzureRmAccount -EnvironmentName AzureChinaCloud
# Set the resource group name and location for your server
$resourcegroupname = "myResourceGroup-$(Get-Random)"
$location = "China North"
# Set an admin login and password for your server
$adminlogin = "ServerAdmin"
$password = "ChangeYourAdminPassword1"
# Set server name - the logical server name has to be unique in the system
$servername = "server-$(Get-Random)"
# The sample database name
$databasename = "mySampleDatabase"
# The restored database names
$georestoredatabasename = "MySampleDatabase_GeoRestore"
$pointintimerestoredatabasename = "MySampleDatabase_10MinutesAgo"
$deleteddatabaserestorename = "MySampleDatabase_DeletedRestore"
# The ip address range that you want to allow to access your server
$startip = "0.0.0.0"
$endip = "0.0.0.0"

# Create a resource group
$resourcegroup = New-AzureRmResourceGroup -Name $resourcegroupname -Location $location

# Create a server with a system wide unique server name
$server = New-AzureRmSqlServer -ResourceGroupName $resourcegroupname `
    -ServerName $servername `
    -Location $location `
    -SqlAdministratorCredentials $(New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $adminlogin, $(ConvertTo-SecureString -String $password -AsPlainText -Force))

# Create a server firewall rule that allows access from the specified IP range
$firewallrule = New-AzureRmSqlServerFirewallRule -ResourceGroupName $resourcegroupname `
    -ServerName $servername `
    -FirewallRuleName "AllowedIPs" -StartIpAddress $startip -EndIpAddress $endip

# Create a blank database with an S0 performance level
$database = New-AzureRmSqlDatabase  -ResourceGroupName $resourcegroupname `
    -ServerName $servername `
    -DatabaseName $databasename `
    -RequestedServiceObjectiveName "S0" 

# Restore database from latest geo-redundant backup into existing server 
# Note: Check to see that backups are created and ready to restore from geo-redundant backup
# Important: If no backup exists, you will get an error indicating that no backups exist for the server specified
Get-AzureRmSqlDatabaseGeoBackup -ResourceGroupName $resourcegroupname -ServerName $servername 
Get-AzureRmSqlDatabaseGeoBackup -ResourceGroupName $resourcegroupname -ServerName $servername -DatabaseName $databasename
# Do not continue until a backup exists
Restore-AzureRmSqlDatabase `
    -FromGeoBackup `
    -ResourceGroupName $resourcegroupname `
    -ServerName $servername `
    -TargetDatabaseName $georestoredatabasename `
    -ResourceId $database.ResourceID `
    -Edition "Standard" `
    -ServiceObjectiveName "S0"

# Restore database to its state 10 minutes ago
# Note: Point-in-time restore requires database to be at least 5 minutes old
Restore-AzureRmSqlDatabase `
      -FromPointInTimeBackup `
      -PointInTime (Get-Date).AddMinutes(-10) `
      -ResourceGroupName $resourcegroupname `
      -ServerName $servername `
      -TargetDatabaseName $pointintimerestoredatabasename `
      -ResourceId $database.ResourceID `
      -Edition "Standard" `
      -ServiceObjectiveName "S0"

# Delete original database
Remove-AzureRmSqlDatabase -ResourceGroupName $resourcegroupname -ServerName $servername -DatabaseName $databasename

# Restore deleted database 
# Note: Check to see that the Get-AzureRmSqlDeletedDatabaseBackup cmdlet returns a deletion date (may take a few minutes). 
# Important: If no backup exists, no value will be returned.
$deleteddatabase = Get-AzureRmSqlDeletedDatabaseBackup -ResourceGroupName $resourcegroupname -ServerName $servername -DatabaseName $databasename
$deleteddatabase
# Do not continue until the cmdlet returns information about the deleted database.
Restore-AzureRmSqlDatabase -FromDeletedDatabaseBackup `
    -ResourceGroupName $resourcegroupname `
    -ServerName $servername `
    -TargetDatabaseName $deleteddatabaserestorename `
    -ResourceId $deleteddatabase.ResourceID `
    -DeletionDate $deleteddatabase.DeletionDate `
    -Edition "Standard" `
    -ServiceObjectiveName "S0"

# Clean up deployment 
# Remove-AzureRmResourceGroup -ResourceGroupName $resourcegroupname
```

## Clean up deployment

After the script sample has been run, the following command can be used to remove the resource group and all resources associated with it.

```powershell
Remove-AzureRmResourceGroup -ResourceGroupName $resourcegroupname
```

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [New-AzureRmResourceGroup](https://docs.microsoft.com/powershell/resourcemanager/azurerm.resources/v3.5.0/new-azurermresourcegroup) | Creates a resource group in which all resources are stored. | [New-AzureRmSqlServer](https://docs.microsoft.com/powershell/module/azurerm.sql/new-azurermsqlserver) | Creates a logical server that hosts a database or elastic pool. | 
| [New-AzureRmSqlDatabase](https://docs.microsoft.com/powershell/module/azurerm.sql/new-azurermsqldatabase) | Creates a database in a logical server as a single or a pooled database. |
[Get-AzureRmSqlDatabaseGeoBackup](https://docs.microsoft.com/powershell/module/azurerm.sql/get-azurermsqldatabasegeobackup) | Gets a geo-redundant backup of a database. |
| [Restore-AzureRmSqlDatabase](https://docs.microsoft.com/powershell/module/azurerm.sql/restore-azurermsqldatabase) | Restores a SQL database. |
|[Remove-AzureRmSqlDatabase](https://docs.microsoft.com/powershell/module/azurerm.sql/remove-azurermsqldatabase) | Removes an Azure SQL database. |
| [Get-AzureRmSqlDeletedDatabaseBackup](https://docs.microsoft.com/powershell/module/azurerm.sql/get-azurermsqldeleteddatabasebackup) | Gets a deleted database that you can restore. |
| [Remove-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/remove-azurermresourcegroup) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure PowerShell, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional SQL Database PowerShell script samples can be found in the [Azure SQL Database PowerShell scripts](../sql-database-powershell-samples.md).

<!--Update_Description: update "Clean up deployment" script-->