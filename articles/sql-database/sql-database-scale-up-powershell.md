<properties 
    pageTitle="Change the service tier and performance level of an Azure SQL database using PowerShell" 
    description="Change the service tier and performance level of an Azure SQL database shows how to scale your SQL database up or down with PowerShell. Changing the pricing tier of an Azure SQL database with PowerShell." 
	services="sql-database"
	documentationCenter=""
	authors="stevestein"
	manager="jhubbard"
	editor=""/>

<tags
	ms.service="sql-database"
	ms.devlang="NA"
	ms.date="10/12/2016"
	ms.author="sstein"
	ms.workload="data-management"
	ms.topic="article"
	ms.tgt_pltfrm="NA"/>


# Change the service tier and performance level (pricing tier) of a SQL database with PowerShell


> [AZURE.SELECTOR]
- [Azure portal](/documentation/articles/sql-database-scale-up/)
- [**PowerShell**](/documentation/articles/sql-database-scale-up-powershell/)


Service tiers and performance levels describe the features and resources available for your SQL database and can be updated as the needs of your application change. For details, see [Service Tiers](/documentation/articles/sql-database-service-tiers/).

Note that changing the service tier and/or performance level of a database creates a replica of the original database at the new performance level, and then switches connections over to the replica. No data is lost during this process but during the brief moment when we switch over to the replica, connections to the database are disabled, so some transactions in flight may be rolled back. This window varies, but is on average under 4 seconds, and in more than 99% of cases is less than 30 seconds. Very infrequently, especially if there are large numbers of transactions in flight at the moment connections are disabled, this window may be longer.  

The duration of the entire scale-up process depends on both the size and service tier of the database before and after the change. For example, a 250 GB database that is changing to, from, or within a Standard service tier, should complete within 6 hours. For a database of the same size that is changing performance levels within the Premium service tier, it should complete within 3 hours.


- To downgrade a database, the database should be smaller than the maximum allowed size of the target service tier. 
- When upgrading a database with [Geo-Replication](/documentation/articles/sql-database-geo-replication-portal/) enabled, you must first upgrade its secondary databases to the desired performance tier before upgrading the primary database.
- When downgrading from a Premium service tier, you must first terminate all Geo-Replication relationships. You can follow the steps described in the [Recover from an outage](/documentation/articles/sql-database-disaster-recovery/) topic to stop the replication process between the primary and the active secondary databases.
- The restore service offerings are different for the various service tiers. If you are downgrading you may lose the ability to restore to a point in time, or have a lower backup retention period. For more information, see [Azure SQL Database Backup and Restore](/documentation/articles/sql-database-business-continuity/).
- The new properties for the database are not applied until the changes are complete.



**To complete this article you need the following:**

- An Azure subscription. If you need an Azure subscription simply click **Trial** at the top of this page, and then come back to finish this article.
- An Azure SQL database. If you do not have a SQL database, create one following the steps in this article: [Create your first Azure SQL Database](/documentation/articles/sql-database-get-started/).
- Azure PowerShell.


[AZURE.INCLUDE [Start your PowerShell session](../../includes/sql-database-powershell.md)]



## Change the service tier and performance level of your SQL database

Run the **Set-AzureRmSqlDatabase** cmdlet and set the **-RequestedServiceObjectiveName** to the performance level of the desired pricing tier; for example *S0*, *S1*, *S2*, *S3*, *P1*, *P2*, ...

    $ResourceGroupName = "resourceGroupName"
    
    $ServerName = "serverName"
    $DatabaseName = "databaseName"

    $NewEdition = "Standard"
    $NewPricingTier = "S2"

    Set-AzureRmSqlDatabase -DatabaseName $DatabaseName -ServerName $ServerName -ResourceGroupName $ResourceGroupName -Edition $NewEdition -RequestedServiceObjectiveName $NewPricingTier


  

   


## Sample PowerShell script to change the service tier and performance level of your SQL database

Replace `{variables}` with your values (do not include the curly braces).
    

    
    $SubscriptionId = "{4cac86b0-1e56-bbbb-aaaa-000000000000}"
    
    $ResourceGroupName = "{resourceGroup}"
    $Location = "{AzureRegion}"
    
    $ServerName = "{server}"
    $DatabaseName = "{database}"
    
    $NewEdition = "{Standard}"
    $NewPricingTier = "{S2}"
    
    Add-AzureRmAccount -EnvironmentName AzureChinaCloud
    Set-AzureRmContext -SubscriptionId $SubscriptionId
    
    Set-AzureRmSqlDatabase -DatabaseName $DatabaseName -ServerName $ServerName -ResourceGroupName $ResourceGroupName -Edition $NewEdition -RequestedServiceObjectiveName $NewPricingTier

    
        


## Next steps

- [Scale out and in](/documentation/articles/sql-database-elastic-scale-get-started/)
- [Connect and query a SQL database with SSMS](/documentation/articles/sql-database-connect-query-ssms/)
- [Export an Azure SQL database](/documentation/articles/sql-database-export-powershell/)

## Additional resources

- [Business Continuity Overview](/documentation/articles/sql-database-business-continuity/)
- [SQL Database documentation](/documentation/services/sql-databases)
- [Azure SQL Database Cmdlets](http://msdn.microsoft.com/zh-cn/library/mt574084.aspx)
