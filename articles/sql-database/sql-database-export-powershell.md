<properties
    pageTitle="PowerShell: Export an Azure SQL database to a BACPAC file | Azure"
    description="Export an Azure SQL database to a BACPAC file by using PowerShell"
    services="sql-database"
    documentationcenter=""
    author="stevestein"
    manager="jhubbard"
    editor="" />
<tags
    ms.assetid="9439dd83-812f-4688-97ea-2a89a864d1f3"
    ms.service="sql-database"
    ms.custom="migrate and move"
    ms.devlang="NA"
    ms.date="02/07/2017"
    wacn.date=""
    ms.author="sstein"
    ms.workload="data-management"
    ms.topic="article"
    ms.tgt_pltfrm="NA" />


# Export an Azure SQL database or a SQL Server to a BACPAC file by using PowerShell

This article provides directions for exporting your Azure SQL database or a SQL Server database to a BACPAC file (stored in Azure Blob storage) using PowerShell. For an overview of exporting to a BACPAC file, see [Export to a BACPAC](/documentation/articles/sql-database-export/).

> [AZURE.NOTE]
> You can also export your Azure SQL database file to a BACPAC file using the [Azure portal](/documentation/articles/sql-database-export-portal/), [SQL Server Management Studio](/documentation/articles/sql-database-export-ssms/), or [SQLPackage](/documentation/articles/sql-database-export-sqlpackage/).
>

## Prerequisites

To complete this article, you need the following:

- An Azure subscription. 
- An Azure SQL database. 
- An [Azure Standard Storage account](/documentation/articles/storage-create-storage-account/) with a blob container to store the BACPAC in standard storage.


[AZURE.INCLUDE [Start your PowerShell session](../../includes/sql-database-powershell.md)]

## Export your database
The [New-AzureRmSqlDatabaseExport](https://msdn.microsoft.com/zh-cn/library/azure/mt707796\(v=azure.300\).aspx) cmdlet submits an export database request to the service. Depending on the size of your database, the export operation may take some time to complete.

> [AZURE.IMPORTANT] To guarantee a transactionally consistent BACPAC file you should first [create a copy of your database](/documentation/articles/sql-database-copy-powershell/) and then export the database copy. 


     $exportRequest = New-AzureRmSqlDatabaseExport –ResourceGroupName $ResourceGroupName –ServerName $ServerName `
       –DatabaseName $DatabaseName –StorageKeytype $StorageKeytype –StorageKey $StorageKey -StorageUri $BacpacUri `
       –AdministratorLogin $creds.UserName –AdministratorLoginPassword $creds.Password


## Monitor the progress of the export operation
After running [New-AzureRmSqlDatabaseExport](https://msdn.microsoft.com/zh-cn/library/azure/mt603644\(v=azure.300\).aspx), you can check the status of the request by running [Get-AzureRmSqlDatabaseImportExportStatus](https://msdn.microsoft.com/zh-cn/library/azure/mt707794\(v=azure.300\).aspx). Running this immediately after the request usually returns **Status : InProgress**. When you see **Status: Succeeded** the export is complete.

    Get-AzureRmSqlDatabaseImportExportStatus -OperationStatusLink $exportRequest.OperationStatusLink



## Export SQL database example
The following example exports an existing SQL database to a BACPAC and then shows how to check the status of the export operation.

To run the example, there are a few variables you need to replace with the specific values for your database and storage account. In the [Azure portal](https://portal.azure.cn), browse to your storage account to get the storage account name, blob container name, and key value. You can find the key by clicking **Access keys** on your storage account blade.

Replace the following `VARIABLE-VALUES` with values for your specific Azure resources. The database name is the existing database you want to export.

    $subscriptionId = "YOUR AZURE SUBSCRIPTION ID"

    Login-AzureRmAccount -EnvironmentName AzureChinaCloud
    Set-AzureRmContext -SubscriptionId $subscriptionId

    # Database to export
    $DatabaseName = "DATABASE-NAME"
    $ResourceGroupName = "RESOURCE-GROUP-NAME"
    $ServerName = "SERVER-NAME"
    $serverAdmin = "ADMIN-NAME"
    $serverPassword = "ADMIN-PASSWORD" 
    $securePassword = ConvertTo-SecureString –String $serverPassword –AsPlainText -Force
    $creds = New-Object –TypeName System.Management.Automation.PSCredential –ArgumentList $serverAdmin, $securePassword

    # Generate a unique filename for the BACPAC
    $bacpacFilename = $DatabaseName + (Get-Date).ToString("yyyyMMddHHmm") + ".bacpac"

    # Storage account info for the BACPAC
    $BaseStorageUri = "https://STORAGE-NAME.blob.core.chinacloudapi.cn/BLOB-CONTAINER-NAME/"
    $BacpacUri = $BaseStorageUri + $bacpacFilename
    $StorageKeytype = "StorageAccessKey"
    $StorageKey = "YOUR STORAGE KEY"

    $exportRequest = New-AzureRmSqlDatabaseExport –ResourceGroupName $ResourceGroupName –ServerName $ServerName `
       –DatabaseName $DatabaseName –StorageKeytype $StorageKeytype –StorageKey $StorageKey -StorageUri $BacpacUri `
       –AdministratorLogin $creds.UserName –AdministratorLoginPassword $creds.Password
    $exportRequest

    # Check status of the export
    Get-AzureRmSqlDatabaseImportExportStatus -OperationStatusLink $exportRequest.OperationStatusLink

## Automate export using Azure Automation

Azure SQL Database Automated Export is now in preview and will be retired on March 1, 2017. Starting December 1, 2016, you will no longer be able to configure automated export on any SQL database. All your existing automated export jobs will continue to work until March 1, 2017. After December 1, 2016, you can use [long-term backup retention](/documentation/articles/sql-database-long-term-retention/) or [Azure Automation](/documentation/articles/automation-intro/) to archive SQL databases periodically using PowerShell periodically according to a schedule of your choice. For a sample script, you can download the [sample script from Github](https://github.com/Microsoft/sql-server-samples/tree/master/samples/manage/azure-automation-automated-export). 


## Next steps
* To learn how to import an Azure SQL database by using Powershell, see [Import a BACPAC using PowerShell](/documentation/articles/sql-database-import-powershell/).
* To learn about importing a BACPAC using SQLPackage, see [Import a BACPAC to Azure SQL Database using SqlPackage](/documentation/articles/sql-database-import-sqlpackage/)
* To learn about importing a BACPAC using the Azure portal, see [Import a BACPAC to Azure SQL Database using the Azure portal](/documentation/articles/sql-database-import-portal/)
* For a discussion of the entire SQL Server database migration process, including performance recommendations, see [Migrate a SQL Server database to Azure SQL Database](/documentation/articles/sql-database-cloud-migrate/).
* To learn about long-term backup retention of an Azure SQL database backup as an alternative to exported a database for archive purposes, see [Long term backup retention](/documentation/articles/sql-database-long-term-retention/)
* To learn about importing a BACPAC to a SQL Server database, see [Import a BACPCAC to a SQL Server database](https://msdn.microsoft.com/zh-cn/library/hh710052.aspx)



## Additional resources
* [New-AzureRmSqlDatabaseExport](https://msdn.microsoft.com/zh-cn/library/azure/mt707796\(v=azure.300\).aspx)
* [Get-AzureRmSqlDatabaseImportExportStatus](https://msdn.microsoft.com/zh-cn/library/azure/mt707794\(v=azure.300\).aspx)

