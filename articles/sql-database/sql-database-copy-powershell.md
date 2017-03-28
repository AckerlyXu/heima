<properties 
    pageTitle="Copy an Azure SQL database using PowerShell | Azure" 
    description="Create copy of an Azure SQL database using PowerShell" 
	services="sql-database"
	documentationCenter=""
	authors="stevestein"
	manager="jhubbard"
	editor=""/>

<tags
	ms.service="sql-database"
	ms.devlang="NA"
	ms.date="09/08/2016"
	ms.author="sstein"
	ms.workload="data-management"
	ms.topic="article"
	ms.tgt_pltfrm="NA"/>


# Copy an Azure SQL database using PowerShell


> [AZURE.SELECTOR]
- [Overview](/documentation/articles/sql-database-copy/)
- [Azure Portal](/documentation/articles/sql-database-copy/)
- [PowerShell](/documentation/articles/sql-database-copy-powershell/)
- [T-SQL](/documentation/articles/sql-database-copy-transact-sql/)

This article shows how to copy a SQL database with PowerShell to the same server, to a different server, or copy a database into an [elastic database pool](/documentation/articles/sql-database-elastic-pool/). The database copy operation uses the [New-AzureRmSqlDatabaseCopy](https://msdn.microsoft.com/zh-cn/library/mt603644.aspx) cmdlet. 


To complete this article, you need the following:

- An Azure SQL database (a database to copy). If you do not have a SQL database, create one following the steps in this article: [Create your first Azure SQL Database](/documentation/articles/sql-database-get-started/).
- The latest version of Azure PowerShell. For detailed information, see [How to install and configure Azure PowerShell](/documentation/articles/powershell-install-configure/).


Many new features of SQL Database are only supported when you are using the [Azure Resource Manager deployment model](/documentation/articles/resource-group-overview/), so examples use the [Azure SQL Database PowerShell cmdlets](https://msdn.microsoft.com/zh-cn/library/azure/mt574084.aspx) for Resource Manager. The existing classic deployment model [Azure SQL Database (classic) cmdlets](https://msdn.microsoft.com/zh-cn/library/azure/dn546723.aspx) are supported for backward compatibility, but we recommend you use the Resource Manager cmdlets.


>[AZURE.NOTE] Depending on the size of your database, the copy operation may take some time to complete.


## Copy a SQL database to the same server

To create the copy on the same server, omit the `-CopyServerName` parameter (or set it to the same server).

    New-AzureRmSqlDatabaseCopy -ResourceGroupName "resourcegroup1" -ServerName "server1" -DatabaseName "database1" -CopyDatabaseName "database1_copy"

## Copy a SQL database to a different server

To create the copy on a different server, include the `-CopyServerName` parameter and set it to a different server. The *copy* server must already exist. If it is in a different resource group, then you must also include the `-CopyResourceGroupName` parameter.

    New-AzureRmSqlDatabaseCopy -ResourceGroupName "resourcegroup1" -ServerName "server1" -DatabaseName "database1" -CopyServerName "server2" -CopyDatabaseName "database1_copy"


## Copy a SQL database into an elastic database pool

To create a copy of a SQL database in a pool, set the `-ElasticPoolName` parameter to an existing pool.

    New-AzureRmSqlDatabaseCopy -ResourceGroupName "resourcegoup1" -ServerName "server1" -DatabaseName "database1" -CopyResourceGroupName "poolResourceGroup" -CopyServerName "poolServer1" -CopyDatabaseName "database1_copy" -ElasticPoolName "poolName"


## Resolve logins

To resolve logins after the copy operation completes, see [Resolve logins](/documentation/articles/sql-database-copy-transact-sql/#resolve-logins-after-the-copy-operation-completes)


## Example PowerShell script

The following script assumes all resource groups, servers, and the pool already exist (replace the variable values with your existing resources). Everything must exist, except for the database copy.

    # Sign in to Azure and set the subscription to work with
    # ------------------------------------------------------
    $SubscriptionId = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
    Add-AzureRmAccount -EnvironmentName AzureChinaCloud
    Set-AzureRmContext -SubscriptionId $SubscriptionId
    
    
    # SQL database source (the existing database to copy)
    # ---------------------------------------------------
    $sourceDbName = "db1"
    $sourceDbServerName = "server1"
    $sourceDbResourceGroupName = "rg1"
    
    # SQL database copy (the new db to be created)
    # --------------------------------------------
    $copyDbName = "db1_copy"
    $copyDbServerName = "server2"
    $copyDbResourceGroupName = "rg2"
    
    # Copy a database to the same server
    # ----------------------------------
    New-AzureRmSqlDatabaseCopy -ResourceGroupName $sourceDbResourceGroupName -ServerName $sourceDbServerName -DatabaseName $sourceDbName -CopyDatabaseName $copyDbName
    
    # Copy a database to a different server
    # -------------------------------------
    New-AzureRmSqlDatabaseCopy -ResourceGroupName $sourceDbResourceGroupName -ServerName $sourceDbServerName -DatabaseName $sourceDbName -CopyResourceGroupName $copyDbResourceGroupName -CopyServerName $copyDbServerName -CopyDatabaseName $copyDbName
    
    # Copy a database into an elastic database pool
    # ---------------------------------------------
    $poolName = "pool1"
    
    New-AzureRmSqlDatabaseCopy -ResourceGroupName $sourceDbResourceGroupName -ServerName $sourceDbServerName -DatabaseName $sourceDbName -CopyResourceGroupName $copyDbResourceGroupName -CopyServerName $copyDbServerName -ElasticPoolName $poolName -CopyDatabaseName $copyDbName



    

## Next steps

- See [Copy an Azure SQL database](/documentation/articles/sql-database-copy/) for an overview of copying an Azure SQL Database.
- See [Copy an Azure SQL database using the Azure Portal](/documentation/articles/sql-database-copy-portal/) to copy a database using the Azure portal.
- See [Copy an Azure SQL database using T-SQL](/documentation/articles/sql-database-copy-transact-sql/) to copy a database using Transact-SQL.
- See [How to manage Azure SQL database security after disaster recovery](/documentation/articles/sql-database-geo-replication-security-config/) to learn about managing users and logins when copying a database to a different logical server.


## Additional resources

- [New-AzureRmSqlDatabase](https://msdn.microsoft.com/zh-cn/library/mt603644.aspx)
- [Get-AzureRmSqlDatabaseActivity](https://msdn.microsoft.com/zh-cn/library/mt603687.aspx)
- [Manage logins](/documentation/articles/sql-database-manage-logins/)
- [Connect to SQL Database with SQL Server Management Studio and perform a sample T-SQL query](/documentation/articles/sql-database-connect-query-ssms/)
- [Export the database to a BACPAC](/documentation/articles/sql-database-export/)
- [Business Continuity Overview](/documentation/articles/sql-database-business-continuity/)
- [SQL Database documentation](/documentation/services/sql-databases)
