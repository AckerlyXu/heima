<properties
    pageTitle="Azure portal: Create and manage single Azure SQL databases | Azure"
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

# Create and manage single Azure SQL databases with the Azure portal

You can create and manage single Azure SQL databases with the [Azure portal](https://portal.azure.cn/), PowerShell, Transact-SQL, the REST API, or C#. This topic is about using the Azure portal. For PowerShell, see [Create and manage single databases with Powershell](/documentation/articles/sql-database-manage-single-databases-powershell/). For Transact-SQL, see [Create and manage single databases with Transact-SQL](/documentation/articles/sql-database-manage-single-databases-tsql/). 

## Create a single Azure SQL database with the Azure portal

1. Open the **SQL databases** blade in the [Azure portal](https://portal.azure.cn/). 

    ![sql databases](./media/sql-database-get-started/sql-databases.png)
2. On the SQL databases blade, click **Add**.

    ![add sql database](./media/sql-database-get-started/add-sql-database.png)

> [AZURE.TIP]
> For a tutorial creating a database with the Azure portal, see [Create a database - Azure portal](/documentation/articles/sql-database-get-started/).
>    

## View and update SQL database settings using the Azure portal

1. Open the **SQL databases** blade in the [Azure portal](https://portal.azure.cn/). 

    ![sql databases](./media/sql-database-get-started/sql-databases.png)

2. Click the database you want to work with and then click the desired setting on the SQL database blade.

    ![new sample db blade](./media/sql-database-get-started/new-sample-db-blade.png)

## Change the service tier and performance level of a single database
Open the SQL Database blade for the database you want to scale up or down:

1. In the [Azure portal](https://portal.azure.cn), click **More services** > **SQL databases**.
2. Click the database you want to change.
3. On the **SQL database** blade, click **Pricing tier (scale DTUs)**:
   
   ![pricing tier](./media/sql-database-manage-single-database-portal/new-tier.png)

4. Choose a new tier and click **Select**:
   
   Clicking **Select** submits a scale request to change the pricing tier. Depending on the size of your database, the scale operation can take some time to complete (see the info at the top of this article).
   
   > [AZURE.NOTE]
   > Changing your database pricing tier does not change the max database size. To change your database max size, use [Transact-SQL (T-SQL)](https://msdn.microsoft.com/zh-cn/library/mt574871.aspx) or [PowerShell](https://msdn.microsoft.com/zh-cn/library/mt619433.aspx).
   > 
   > 
   
   ![select pricing tier](./media/sql-database-manage-single-database-portal/choose-tier.png)
5. Click the notification icon (bell), in the upper right:
   
   ![notifications](./media/sql-database-manage-single-database-portal/scale-notification.png)
   
6. Click the notification text to open the details pane where you can see the status of the request.

## Next steps
* For an overview of management tools, see [Overview of management tools](/documentation/articles/sql-database-manage-overview/).
* To see how to perform management tasks using the Azure portal, see [Manage Azure SQL Databases using the Azure portal](/documentation/articles/sql-database-manage-portal/).
* To see how to perform management tasks using PowerShell, see [Manage Azure SQL Databases using PowerShell](/documentation/articles/sql-database-manage-powershell/).
* To see how to perform management tasks using SQL Server Management Studio, see [SQL Server Management Studio](/documentation/articles/sql-database-manage-azure-ssms/).
* For information about the SQL Database service, see [What is SQL Database](/documentation/articles/sql-database-technical-overview/). 
* For information about Azure Database servers and database features, see [Features](/documentation/articles/sql-database-features/).
