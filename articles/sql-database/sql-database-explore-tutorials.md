<properties
    pageTitle="Explore Azure SQL Database Tutorials | Azure"
    description="Learn about SQL Database features and capabilities"
    keywords=""
    services="sql-database"
    documentationcenter=""
    author="CarlRabeler"
    manager="jhubbard"
    editor="" />
<tags
    ms.assetid="04c0fd7f-d260-4e43-a4f0-41cdcd5e3786"
    ms.service="sql-database"
    ms.custom="overview"
    ms.devlang="NA"
    ms.topic="article"
    ms.tgt_pltfrm="NA"
    ms.workload="data-management"
    ms.date="02/08/2017"
    wacn.date=""
    ms.author="carlrab" />

# Explore Azure SQL Database tutorials
The links in the following tables take you to an overview of each listed feature area and a simple step-by-start tutorial for each area. 

## Create servers, databases and server-level firewall rules
In the following tutorials, you create servers, databases, and server-level firewall rules - and learn to connect and query servers and databases.

| Tutorial | Description |
| --- | --- | 
| [Your first Azure SQL database](/documentation/articles/sql-database-get-started/) | When you finish this quick start tutorial, you have a sample database and a blank database running in an Azure resource group and attached to a logical server. You also have two server-level firewall rules configured to enable the server-level principal to log in to the server from two specified IP addresses. Finally, you learn know how to query a database in the Azure portal and to connect and query using SQL Server Management Studio. |
| [Provision and access an Azure SQL database using PowerShell](/documentation/articles/sql-database-get-started-powershell/) | When you finish this tutorial, you have a sample database and a blank database running in an Azure resource group and attached to a logical server. You also have a server-level firewall rule configured to enable the server-level principal to log in to the server from a specified IP address (or IP address range). |
| [Use C# to create a SQL database with the SQL Database Library for .NET](/documentation/articles/sql-database-get-started-csharp/)| In this tutorial, you use the C# to create a SQL Database server, firewall rule, and SQL database. You also create an Active Directory (AD) application and the service principal needed to authenticate the C# app. |
|  | |

## Backups, long-term retention, and database recovery
In the following tutorials, you learn about using [database backups](/documentation/articles/sql-database-automated-backups/), [long-term backup retention](/documentation/articles/sql-database-long-term-retention/), and [database recovery using backups](/documentation/articles/sql-database-recovery-using-backups/).

| Tutorial | Description |
| --- | --- | 
| [Back up and restore using the Azure portal](/documentation/articles/sql-database-get-started-backup-recovery-portal/) | In this tutorial, you learn how to use the Azure portal to view backups, recover to a point in time, configure long-term backup retention, and recover from a backup in the Azure Recovery Services vault
| [Back up and restore using PowerShell](/documentation/articles/sql-database-get-started-backup-recovery-powershell/) | In this tutorial, you learn how to use PowerShell to view backups, recover to a point in time, configure long-term backup retention, and recover from a backup in the Azure Recovery Services vault
|  | |

## Sharded databases
In the following tutorials, you learn how to [Scale out databases with the shard map manager](/documentation/articles/sql-database-elastic-scale-shard-map-management/).

| Tutorial | Description |
| --- | --- | 
| [Create a sharded application](/documentation/articles/sql-database-elastic-scale-get-started/) |In this tutorial, you learn how to use the capabilities of elastic database tools using a simple sharded application. |
| [Deploy a split-merge service](/documentation/articles/sql-database-elastic-scale-configure-deploy-split-and-merge/) |In this tutorial, you learn how to move data between sharded databases. |
|  | |

## Elastic database jobs

In the following tutorials, you learn about using [elastic database jobs](/documentation/articles/sql-database-elastic-jobs-overview/).

| Tutorial | Description |
| --- | --- | 
| [Get started with Azure SQL Database elastic jobs](/documentation/articles/sql-database-elastic-jobs-getting-started/) |In this tutorial, you learn how to create and manage jobs that manage a group of related databases. |
|  | |

## Elastic queries

In the following tutorials, you learn about running [elastic queries](/documentation/articles/sql-database-elastic-query-overview/). 

| Tutorial | Description |
| --- | --- | 
| [Create elastic queries)](/documentation/articles/sql-database-elastic-query-getting-started-vertical/) | In this tutorial, you learn how to run T-SQL queries that span multiple databases using a single connection point |
| [Report across scaled-out cloud databases](/documentation/articles/sql-database-elastic-query-getting-started/) |In this tutorial, you learn how to create reports from all databases in a horizontally partitioned (sharded) database |
| [Query across cloud databases with different schemas](/documentation/articles/sql-database-elastic-query-vertical-partitioning/) | In this tutorial, you learn how to run T-SQL queries that span multiple databases with different schemas |
| [Reporting across scaled-out cloud databases](/documentation/articles/sql-database-elastic-query-horizontal-partitioning/) |In this tutorial, you learn to create reports that span all databases in a sharded database. |
|  | |

## Database authentication and authorization
In the following tutorials, you learn about [creating and managing logins and users](/documentation/articles/sql-database-manage-logins/).

| Tutorial | Description |
| --- | --- | --- |
| [SQL authentication and authorization](/documentation/articles/sql-database-control-access-sql-authentication-get-started/) | In this tutorial, you learn about creating logins and users using SQL Server authentication, and adding them to roles as well as granting them permissions |
| [Azure AD authentication and authorization](/documentation/articles/sql-database-control-access-aad-authentication-get-started/) | In this tutorial, you learn about creating logins and users using Azure Active Directory authentication |
|  | |

## Secure and protect data
In the following tutorials, you learn about [securing Azure SQL Database data](/documentation/articles/sql-database-security-overview/).

| Tutorial | Description |
| --- | --- | 
| [Secure sensitive data using Always Encrypted ](/documentation/articles/sql-database-always-encrypted-azure-key-vault/) |In this tutorial, you use the Always Encrypted wizard to secure sensitive data in an Azure SQL database. |
|  | |

## Develop
In the following tutorials, you learn about application and database development.

| Tutorial | Description |
| --- | --- | 
| [Create a report using Excel](/documentation/articles/sql-database-connect-excel/) |In this tutorial, you learn how to connect Excel to a SQL database in the cloud so you can import data and create tables and charts based on values in the database. |
| [Build an app using SQL Server](https://www.microsoft.com/sql-server/developer-get-started/) |In this tutorial, you learn how to build an application using SQL Server |
| [Temporal tables](/documentation/articles/sql-database-temporal-tables/) | In this tutorial, you learn about temporal tables.
| [Use entity framework with elastic tools](/documentation/articles/sql-database-elastic-scale-use-entity-framework-applications-visual-studio/) |In this tutorial, you learn the changes in an Entity Framework application that are needed to integrate with the Elastic Database tools. |
| [Adopt in-memory OLTP](/documentation/articles/sql-database-in-memory-oltp-migration/) | In this tutorial, you learn how to use [in-memory OLTP](/documentation/articles/sql-database-in-memory/) to improve the performance of transaction processing. |
| [Code First to a New Database](https://msdn.microsoft.com/zh-cn/data/jj193542.aspx) | In this tutorial, you learn about code first development.
| [Tailspin Surveys sample application](https://github.com/Azure-Samples/guidance-identity-management-for-multitenant-apps/blob/master/docs/running-the-app.md) | IN this tutorial, you work with the Tailspon Surveys sample application. |
| [Contoso Clinic demo application](https://github.com/Microsoft/azure-sql-security-sample) | In this tutorial, you work with the Contoso Clinic demo application. |
|  | |

## Data sync
In this tutorial, you learn about [Data Sync](http://download.microsoft.com/download/4/E/3/4E394315-A4CB-4C59-9696-B25215A19CEF/SQL_Data_Sync_Preview.pdf).

| Tutorial  | Description  |
| --- | --- | 
| [Getting Started with Azure SQL Data Sync (Preview)](/documentation/articles/sql-database-get-started-sql-data-sync/)  | In this tutorial, you learn the fundamentals of Azure SQL Data Sync using the Azure Classic Portal. |
|  | |

## Monitor and tune
In the following tutorials, you learn about monitoring and tuning.
| Tutorial | Description |
| --- | --- | 
| [Elastic Pool telemetry using PowerShell](https://github.com/Microsoft/sql-server-samples/tree/master/samples/manage/azure-sql-db-elastic-pools)| In this tutorial, you learn about collecting elastic pool telemetry using PowerShell. |
| [Elastic Pool custom dashboard for SaaS](https://github.com/Microsoft/sql-server-samples/tree/master/samples/manage/azure-sql-db-elastic-pools-custom-dashboard) | In this tutorial, you learn about creating a custom dashboard for monitoring elastic pools. |
| [Capture extended event to event file target](/documentation/articles/sql-database-xevent-code-event-file/)| In this tutorial, you learn to capture extended events to an event target file.|
| [Capture extended event to ring buffer target](/documentation/articles/sql-database-xevent-code-ring-buffer/)| In this tutorial, you learn to capture extended events to an code ring buffer.|
|  | |


