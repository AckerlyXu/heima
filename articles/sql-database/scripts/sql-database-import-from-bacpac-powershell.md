---
title: PowerShell example import BACPAC file Azure SQL database | Microsoft Docs
description: Azure PowerShell example script to import a BACPAC file into a SQL database
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
origin.date: 06/23/2017
ms.date: 10/02/2017
ms.author: v-johch
---

# Use PowerShell to import a BACPAC file into an Azure SQL database

This PowerShell script example imports a database from a BACPAC file into an Azure SQL database.  

[!INCLUDE [sample-powershell-install](../../../includes/sample-powershell-install-no-ssh.md)]

## Sample script

```powershell
# Login-AzureRmAccount -EnvironmentName AzureChinaCloud
# Set the resource group name and location for your server
$resourcegroupname = "myResourceGroup-$(Get-Random)"
$location = "China East"
# Set an admin login and password for your server
$adminlogin = "ServerAdmin"
$password = "ChangeYourAdminPassword1"
# Set server name - the logical server name has to be unique in the system
$servername = "server-$(Get-Random)"
# The sample database name
$databasename = "myImportedDatabase"
# The storage account name and storage container name
$storageaccountname = "sqlimport$(Get-Random)"
$storagecontainername = "importcontainer$(Get-Random)"
# BACPAC file name
$bacpacfilename = "sample.bacpac"
# The ip address range that you want to allow to access your server
$startip = "0.0.0.0"
$endip = "0.0.0.0"

# Create a resource group
$resourcegroup = New-AzureRmResourceGroup -Name $resourcegroupname -Location $location

# Create a storage account 
$storageaccount = New-AzureRmStorageAccount -ResourceGroupName $resourcegroupname `
    -AccountName $storageaccountname `
    -Location $location `
    -Type "Standard_LRS"

# Create a storage container 
$storagecontainer = New-AzureStorageContainer -Name $storagecontainername `
    -Context $(New-AzureStorageContext -StorageAccountName $storageaccountname `
        -StorageAccountKey $(Get-AzureRmStorageAccountKey -ResourceGroupName $resourcegroupname -StorageAccountName $storageaccountname).Value[0])

# Download sample database from Github
Invoke-WebRequest -Uri "https://github.com/Microsoft/sql-server-samples/releases/download/wide-world-importers-v1.0/WideWorldImporters-Standard.bacpac" -OutFile $bacpacfilename

# Upload sample database into storage container
Set-AzureStorageBlobContent -Container $storagecontainername `
    -File $bacpacfilename `
    -Context $(New-AzureStorageContext -StorageAccountName $storageaccountname `
        -StorageAccountKey $(Get-AzureRmStorageAccountKey -ResourceGroupName $resourcegroupname -StorageAccountName $storageaccountname).Value[0])

# Create a new server with a system wide unique server name
$server = New-AzureRmSqlServer -ResourceGroupName $resourcegroupname `
    -ServerName $servername `
    -Location $location `
    -SqlAdministratorCredentials $(New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $adminlogin, $(ConvertTo-SecureString -String $password -AsPlainText -Force))

# Create a server firewall rule that allows access from the specified IP range
$serverfirewallrule = New-AzureRmSqlServerFirewallRule -ResourceGroupName $resourcegroupname `
    -ServerName $servername `
    -FirewallRuleName "AllowedIPs" -StartIpAddress $startip -EndIpAddress $endip

# Import bacpac to database with an S3 performance level
$importRequest = New-AzureRmSqlDatabaseImport -ResourceGroupName $resourcegroupname `
    -ServerName $servername `
    -DatabaseName $databasename `
    -DatabaseMaxSizeBytes "262144000" `
    -StorageKeyType "StorageAccessKey" `
    -StorageKey $(Get-AzureRmStorageAccountKey -ResourceGroupName $resourcegroupname -StorageAccountName $storageaccountname).Value[0] `
    -StorageUri "http://$storageaccountname.blob.core.chinacloudapi.cn/$storagecontainername/$bacpacfilename" `
    -Edition "Standard" `
    -ServiceObjectiveName "S3" `
    -AdministratorLogin "$adminlogin" `
    -AdministratorLoginPassword $(ConvertTo-SecureString -String $password -AsPlainText -Force)

# Check import status and wait for the import to complete
$importStatus = Get-AzureRmSqlDatabaseImportExportStatus -OperationStatusLink $importRequest.OperationStatusLink
[Console]::Write("Importing")
while ($importStatus.Status -eq "InProgress")
{
    $importStatus = Get-AzureRmSqlDatabaseImportExportStatus -OperationStatusLink $importRequest.OperationStatusLink
    [Console]::Write(".")
    Start-Sleep -s 10
}
[Console]::WriteLine("")
$importStatus

# Scale down to S0 after import is complete
Set-AzureRmSqlDatabase -ResourceGroupName $resourcegroupname `
    -ServerName $servername `
    -DatabaseName $databasename  `
    -Edition "Standard" `
    -RequestedServiceObjectiveName "S0"

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
| [New-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/new-azurermresourcegroup) | Creates a resource group in which all resources are stored. |
| [New-AzureRmSqlServer](https://docs.microsoft.com/powershell/module/azurerm.sql/new-azurermsqlserver) | Creates a logical server that hosts the SQL Database. |
| [New-AzureRmSqlServerFirewallRule](https://docs.microsoft.com/powershell/module/azurerm.sql/new-azurermsqlserverfirewallrule) | Creates a firewall rule to allow access to all SQL Databases on the server from the entered IP address range. |
| [New-AzureRmSqlDatabaseImport](https://docs.microsoft.com/powershell/module/azurerm.sql/new-azurermsqldatabaseimport) | Imports a BACPAC file and create a new database on the server. |
| [Remove-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/remove-azurermresourcegroup) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure PowerShell, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional SQL Database PowerShell script samples can be found in the [Azure SQL Database PowerShell scripts](../sql-database-powershell-samples.md).

<!--Update_Description: wording update-->