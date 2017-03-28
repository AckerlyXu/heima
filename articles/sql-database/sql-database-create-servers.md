<properties
    pageTitle="Create Azure SQL Database servers | Azure"
    description="Quick reference on how to create Azure SQL Database servers using the Azure portal and PowerShell."
    services="sql-database"
    documentationcenter=""
    author="CarlRabeler"
    manager="jhubbard"
    editor="" />
<tags
    ms.service="sql-database"
    ms.custom="servers"
    ms.devlang="NA"
    ms.workload="data-management"
    ms.topic="article"
    ms.tgt_pltfrm="NA"
    ms.date="11/23/2016"
    wacn.date=""
    ms.author="carlrab" />

# Create Azure SQL Database servers

You can create an Azure SQL Database server using the [Azure portal](https://portal.azure.cn/), PowerShell, the REST API, or C#. 

## Create an Azure SQL Database server using the Azure portal

1. Open the **SQL servers** blade in the [Azure portal](https://portal.azure.cn/). 

    ![sql servers](./media/sql-database-get-started/new-sql-server.png)

2. Click **Add** to create a SQL server

    ![add new sql server](./media/sql-database-get-started/new-sql-server-add.png)

> [AZURE.TIP]
> For a getting started tutorial using the Azure portal and SQL Server Management Studio, see [Get started with Azure SQL Database servers, databases and firewall rules by using the Azure portal and SQL Server Management Studio](/documentation/articles/sql-database-get-started/).
>

## Create an Azure SQL Database server using PowerShell

To create a SQL database server, use the [New-AzureRmSqlServer](https://docs.microsoft.com/powershell/resourcemanager/azurerm.sql/v2.3.0/new-azurermsqlserver) cmdlet. Replace *server1* with the name for your server. Server names must be unique across all Azure SQL database servers. If the server name is already taken, you get an error. This command may take several minutes to complete. The resource group must already exist in your subscription.


	$resourceGroupName = "resourcegroup1"

	$sqlServerName = "server1"
	$sqlServerVersion = "12.0"
	$sqlServerLocation = "China North"
	$serverAdmin = "loginname"
	$serverPassword = "password" 
	$securePassword = ConvertTo-SecureString –String $serverPassword –AsPlainText -Force
	$creds = New-Object –TypeName System.Management.Automation.PSCredential –ArgumentList $serverAdmin, $securePassword


	$sqlServer = New-AzureRmSqlServer -ServerName $sqlServerName `
	 -SqlAdministratorCredentials $creds -Location $sqlServerLocation `
	 -ResourceGroupName $resourceGroupName -ServerVersion $sqlServerVersion


> [AZURE.TIP]
> For a sample script, see [Create a SQL database PowerShell script](/documentation/articles/sql-database-get-started-powershell/).
>

## Additional resources
* For an overview of management tools, see [Overview of management tools](/documentation/articles/sql-database-manage-overview/)
* To see how to perform management tasks using the Azure portal, see [Manage Azure SQL Databases using the Azure portal](/documentation/articles/sql-database-manage-portal/)
* To see how to perform management tasks using PowerShell, see [Manage Azure SQL Databases using PowerShell](/documentation/articles/sql-database-manage-powershell/)
* To see how to perform additional tasks using SQL Server Management Studio, see [SQL Server Management Studio](/documentation/articles/sql-database-manage-azure-ssms/).
* For information about the SQL Database service, see [What is SQL Database](/documentation/articles/sql-database-technical-overview/). 
* For information about Azure Database servers and database features, see [Features](/documentation/articles/sql-database-features/).
