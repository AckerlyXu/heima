<properties
    pageTitle="Overview: management tools for SQL Database | Azure"
    description="Compares tools and options for managing Azure SQL Database"
    services="sql-database"
    documentationcenter=""
    author="CarlRabeler"
    manager="jhubbard"
    editor="" />
<tags
    ms.assetid="37767380-975f-4dee-a28d-80bc2036dda3"
    ms.service="sql-database"
    ms.custom="overview"
    ms.workload="data-management"
    ms.tgt_pltfrm="na"
    ms.devlang="na"
    ms.topic="article"
    ms.date="02/01/2017"
    wacn.date=""
    ms.author="carlrab" />

# Overview: management tools for SQL Database
This topic explores and compares tools and options for managing Azure SQL databases so you can pick the right tool for the job, your business, and you. Choosing the right tool depends on how many databases you manage, the task, and how often a task is performed.

## Azure portal
The [Azure portal](https://portal.azure.cn) is a web-based application where you can create, update, and delete databases and logical servers and monitor database activity. This tool is great if you're just getting started with Azure, managing a few databases, or need to do something quickly.

For more information about using the portal, see [Manage SQL Databases using the Azure portal](/documentation/articles/sql-database-manage-portal/).

## SQL Server Management Studio and SQL Server Data Tools in Visual Studio
SQL Server Management Studio (SSMS) and SQL Server Data Tools (SSDT) are client tools that run on your computer for managing, and developing your database in the cloud. If you're an application developer familiar with Visual Studio or other integrated development environments (IDEs), [try using SSDT in Visual Studio](https://msdn.microsoft.com/zh-cn/library/mt204009.aspx). Many database administrators are familiar with SSMS, which can be used with Azure SQL databases. [Download the latest version of SSMS](https://msdn.microsoft.com/zh-cn/library/mt238290) and always use the latest release when working with Azure SQL Database. For more information on managing your Azure SQL Databases with SSMS, see [Manage SQL Databases using SSMS](/documentation/articles/sql-database-manage-azure-ssms/).

> [AZURE.IMPORTANT] Always use the latest version of [SQL Server Management Studio](https://msdn.microsoft.com/zh-cn/library/mt238290) and [SQL Server Data Tools](https://msdn.microsoft.com/zh-cn/library/mt204009.aspx) to remain synchronized with updates to Azure and SQL Database.


## PowerShell
You can use PowerShell to manage databases and elastic pools, and to automate Azure resource deployments. Azure recommends this tool for managing a large number of databases and automating deployment and resource changes in a production environment.

For more information, see [Manage SQL Database with PowerShell](/documentation/articles/sql-database-manage-powershell/)

## Elastic Database tools
Use the elastic database tools to perform actions such as 

* Executing a T-SQL script against a set of databases using an [elastic job](/documentation/articles/sql-database-elastic-jobs-overview/)
* Moving multi-tenant model databases to a single-tenant model with the [split-merge tool](/documentation/articles/sql-database-elastic-scale-overview-split-and-merge/)
* Managing databases in a single-tenant model or a multi-tenant model using the [elastic scale client library](/documentation/articles/sql-database-elastic-database-client-library/).
 
## Additional resources
* [Azure Automation](/documentation/services/automation/)
* [Azure Scheduler](/documentation/services/scheduler/)
