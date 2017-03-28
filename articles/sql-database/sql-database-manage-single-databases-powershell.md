<properties
    pageTitle="PowerShell: Create and manage single Azure SQL databases | Azure"
    description="Quick reference on how to create and manage single Azure SQL database using the Azure portal"
    services="sql-database"
    documentationcenter=""
    author="CarlRabeler"
    manager="jhubbard"
    editor="" />
<tags
    ms.service="sql-database"
    ms.custom="single databases"
    ms.devlang="NA"
    ms.workload="data-management"
    ms.topic="article"
    ms.tgt_pltfrm="NA"
    ms.date="02/06/2017"
    wacn.date=""
    ms.author="carlrab" />

# Create and manage single Azure SQL databases with PowerShell

You can create and manage single Azure SQL databases using the [Azure portal](https://portal.azure.cn/), PowerShell, Transact-SQL, the REST API, or C#. This topic is about using PowerShell. For the Azure portal, see [Create and manage single databases with the Azure portal](/documentation/articles/sql-database-manage-single-databases-powershell/). For Transact-SQL, see [Create and manage single databases with Transact-SQL](/documentation/articles/sql-database-manage-single-databases-tsql/). 

[AZURE.INCLUDE [Start your PowerShell session](../../includes/sql-database-powershell.md)]

## Create an Azure SQL database using PowerShell

To create a SQL database, use the [New-AzureRmSqlDatabase](https://docs.microsoft.com/powershell/resourcemanager/azurerm.sql/v2.3.0/new-azurermsqldatabase) cmdlet. The resource group, and server must already exist in your subscription. 


	$resourceGroupName = "resourcegroup1"
	$sqlServerName = "server1"

	$databaseName = "database1"
	$databaseEdition = "Standard"
	$databaseServiceLevel = "S0"

	$currentDatabase = New-AzureRmSqlDatabase -ResourceGroupName $resourceGroupName `
	 -ServerName $sqlServerName -DatabaseName $databaseName `
	 -Edition $databaseEdition -RequestedServiceObjectiveName $databaseServiceLevel


> [AZURE.TIP]
> For a sample script, see [Create a SQL database PowerShell script](/documentation/articles/sql-database-get-started-powershell/).
>

## Change the service tier and performance level of a single database

Run the [Set-AzureRmSqlDatabase](https://msdn.microsoft.com/zh-cn/library/azure/mt619433\(v=azure.300\).aspx) cmdlet and set the **-RequestedServiceObjectiveName** to the performance level of the desired pricing tier; for example, *S0*, *S1*, *S2*, *S3*, *P1*, *P2*, ...

Replace ```{variables}``` with your values (do not include the curly braces).


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
* For an overview of management tools, see [Overview of management tools](/documentation/articles/sql-database-manage-overview/).
* To see how to perform management tasks using the Azure portal, see [Manage Azure SQL Databases using the Azure portal](/documentation/articles/sql-database-manage-portal/).
* To see how to perform management tasks using PowerShell, see [Manage Azure SQL Databases using PowerShell](/documentation/articles/sql-database-manage-powershell/).
* To see how to perform management tasks using SQL Server Management Studio, see [SQL Server Management Studio](/documentation/articles/sql-database-manage-azure-ssms/).
* For information about the SQL Database service, see [What is SQL Database](/documentation/articles/sql-database-technical-overview/). 
* For information about Azure Database servers and database features, see [Features](/documentation/articles/sql-database-features/).
