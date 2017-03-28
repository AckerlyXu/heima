<properties
    pageTitle="T-SQL: Create and manage single Azure SQL databases | Azure"
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

# Create and manage single Azure SQL databases with Transact-SQL

You can create and manage single Azure SQL databases with the [Azure portal](https://portal.azure.cn/), PowerShell, Transact-SQL, the REST API, or C#. This topic is about using the Azure portal. For PowerShell, see [Create and manage single databases with Powershell](/documentation/articles/sql-database-manage-single-databases-powershell/). For Transact-SQL, see [Create and manage single databases with Transact-SQL](/documentation/articles/sql-database-manage-single-databases-tsql/). 

## Create an Azure SQL database using Transact-SQL in SQL Server Management Studio

To create a SQL Database using Transact-SQL in SQL Server Management Studio:

1. Using SQL Server Management Studio, connect to the Azure Database server using the server-level principal login or a login that is a member of the **dbmanager** role. For more information on logins, see [Manage logins](/documentation/articles/sql-database-manage-logins/).
2. In Object Explorer, open the Databases node, expand the **System Databases** folder, right-click on **master**, and then click **New Query**.
3. Use the **CREATE DATABASE** statement to create a database. For
  more information, see [CREATE DATABASE (SQL Database)](https://msdn.microsoft.com/zh-cn/library/dn268335.aspx). The following statement creates a database named **myTestDB** and specifies that it is a Standard S0 Edition database with a default maximum size of 250 GB.
  
      CREATE DATABASE myTestDB
      (EDITION='Standard',
       SERVICE_OBJECTIVE='S0');

4. Click **Execute** to run the query.
5. In Object Explorer, right-click the Databases node and click **Refresh** to view the new database in Object Explorer. 


## Change the service tier and performance level of a single database
Change your database max size using [Transact-SQL (T-SQL)](https://msdn.microsoft.com/zh-cn/library/mt574871.aspx)

> [AZURE.TIP]
> For a tutorial creating a database using Transact-SQL, see [Create a database - Azure portal](/documentation/articles/sql-database-get-started/).
>

## Next steps
* For an overview of management tools, see [Overview of management tools](/documentation/articles/sql-database-manage-overview/).
* To see how to perform management tasks using the Azure portal, see [Manage Azure SQL Databases using the Azure portal](/documentation/articles/sql-database-manage-portal/).
* To see how to perform management tasks using PowerShell, see [Manage Azure SQL Databases using PowerShell](/documentation/articles/sql-database-manage-powershell/).
* To see how to perform management tasks using SQL Server Management Studio, see [SQL Server Management Studio](/documentation/articles/sql-database-manage-azure-ssms/).
* For information about the SQL Database service, see [What is SQL Database](/documentation/articles/sql-database-technical-overview/). 
* For information about Azure Database servers and database features, see [Features](/documentation/articles/sql-database-features/).
