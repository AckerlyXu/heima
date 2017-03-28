<properties
    pageTitle="Pause, resume, scale with T-SQL in Azure SQL Data Warehouse | Azure"
    description="Transact-SQL (T-SQL) tasks to scale-out performance by adjusting DWUs. Save costs by scaling back during non-peak times."
    services="sql-data-warehouse"
    documentationcenter="NA"
    author="barbkess"
    manager="jhubbard"
    editor="" />
<tags
    ms.assetid="a970d939-2adf-4856-8a78-d4fe8ab2cceb"
    ms.service="sql-data-warehouse"
    ms.devlang="NA"
    ms.topic="article"
    ms.tgt_pltfrm="NA"
    ms.workload="data-services"
    ms.date="10/31/2016"
    wacn.date=""
    ms.author="barbkess" />

# Manage compute power in Azure SQL Data Warehouse (T-SQL)

> [AZURE.SELECTOR]
- [Overview](/documentation/articles/sql-data-warehouse-manage-compute-overview/)
- [Portal](/documentation/articles/sql-data-warehouse-manage-compute-portal/)
- [PowerShell](/documentation/articles/sql-data-warehouse-manage-compute-powershell/)
- [REST](/documentation/articles/sql-data-warehouse-manage-compute-rest-api/)
- [TSQL](/documentation/articles/sql-data-warehouse-manage-compute-tsql/)

## <a name="current-dwu-bk"></a> View current DWU settings
To view the current DWU settings for your databases:

1. Open SQL Server Object Explorer in Visual Studio 2015.
2. Connect to the master database associated with the logical SQL Database server.
3. Select from the sys.database_service_objectives dynamic management view. Here is an example: 

        SELECT
	 db.name [Database],
	 ds.edition [Edition],
	 ds.service_objective [Service Objective]
        FROM
	 sys.database_service_objectives ds
	 JOIN sys.databases db ON ds.database_id = db.database_id


<a name="scale-dwu-bk"></a>
## <a name="scale-compute-bk"></a> Scale compute
[AZURE.INCLUDE [SQL Data Warehouse scale DWUs description](../../includes/sql-data-warehouse-scale-dwus-description.md)]

To change the DWUs:

1. Connect to the master database associated with your logical SQL Database server.
2. Use the [ALTER DATABASE][ALTER DATABASE] TSQL statement. The following example sets the service level objective to DW1000 for the database MySQLDW. 

        ALTER DATABASE MySQLDW
        MODIFY (SERVICE_OBJECTIVE = 'DW1000')
        ;

## <a name="next-steps-bk"></a> Next steps
For other management tasks, see [Management overview][Management overview].

<!--Image references-->

<!--Article references-->
[Service capacity limits]: /documentation/articles/sql-data-warehouse-service-capacity-limits/
[Management overview]: /documentation/articles/sql-data-warehouse-overview-manage/
[Manage compute power overview]: /documentation/articles/sql-data-warehouse-manage-compute-overview/

<!--MSDN references-->

[ALTER DATABASE]: https://msdn.microsoft.com/zh-cn/library/mt204042.aspx


<!--Other Web references-->

[Azure portal]: http://portal.azure.cn/
