<properties
    pageTitle="Azure SQL database overview | Azure"
    description="This page provides an overview of Azure SQL databases."
    services="sql-database"
    documentationcenter="na"
    author="CarlRabeler"
    manager="jhubbard"
    editor="" />
<tags
    ms.service="sql-database"
    ms.custom="single databases"
    ms.devlang="na"
    ms.topic="get-started-article"
    ms.tgt_pltfrm="na"
    ms.workload="data-management"
    ms.date="11/28/2016"
    wacn.date=""
    ms.author="carlrab" />

# Azure SQL database overview
This topic provides an overview of Azure SQL databases. For information about Azure SQL logical servers, see [Logical servers](/documentation/articles/sql-database-server-overview/).

## What is Azure SQL database?
Each database in Azure SQL Database is associated with a logical server. The database can be:

- A single database with its [own set of resources](/documentation/articles/sql-database-what-is-a-dtu/#what-are-database-transaction-units-dtus) (DTUs)
- Part of an [elastic pool](/documentation/articles/sql-database-elastic-pool/) that [shares a set of resources](/documentation/articles/sql-database-what-is-a-dtu/#what-are-elastic-database-transaction-units-edtus) (eDTUs)
- Part of a [scaled-out set of sharded databases](/documentation/articles/sql-database-elastic-scale-introduction/#horizontal-and-vertical-scaling), which can be either single or pooled databases
- Part of a set of databases participating in a [multitenant SaaS design pattern](/documentation/articles/sql-database-design-patterns-multi-tenancy-saas-applications/), and whose databases can either be single or pooled databases (or both) 

## How do I connect and authenticate to an Azure SQL database?

- **Authentication and authorization**: Azure SQL Database supports SQL authentication and Azure Active Directory Authentication (with certain limitations - see [Connect to SQL Database with Azure Active Directory Authentication](/documentation/articles/sql-database-aad-authentication/) for authentication. You can connect and authenticate to Azure SQL databases through the server's master database or directly to a user database. 
For more information, see [Managing Databases and Logins in Azure SQL Database](/documentation/articles/sql-database-manage-logins/). Windows Authentication is not supported. 
- **TDS**: Azure SQL Database supports tabular data stream (TDS) protocol client version 7.3 or later.
- **TCP/IP**: Only TCP/IP connections are allowed.
- **SQL Database firewall**: To help protect your data, a SQL Database firewall prevents all access to your database server or its databases until you specify which computers have permission. See [Firewalls](/documentation/articles/sql-database-firewall-configure/)

## What collations are supported?
The default database collation used by Azure SQL Database is **SQL_LATIN1_GENERAL_CP1_CI_AS**, where **LATIN1_GENERAL** is English (United States), **CP1** is code page 1252, **CI** is case-insensitive, and **AS** is accent-sensitive. It is not possible to alter the collation for V12 databases. For more information about how to set the collation, see [COLLATE (Transact-SQL)](https://msdn.microsoft.com/zh-cn/library/ms184391.aspx).

## What are the naming requirements for database objects?

Names for all new objects must comply with the SQL Server rules for identifiers. For more information, see [Identifiers](https://msdn.microsoft.com/zh-cn/library/ms175874.aspx).

## What features are supported by Azure SQL databases?

For information about supported features, see [Features](/documentation/articles/sql-database-features/). See also [Azure SQL Database Transact-SQL differences](/documentation/articles/sql-database-transact-sql-information/) for more background on the reasons for lack of support for certain types of features.

## How do I manage an Azure SQL database?

You can manage Azure SQL Database logical servers using several methods:
- [Azure portal](/documentation/articles/sql-database-manage-portal/)
- [PowerShell](/documentation/articles/sql-database-manage-powershell/)
- [Transact-SQL](/documentation/articles/sql-database-manage-azure-ssms/)
- [REST](https://docs.microsoft.com/rest/api/sql/)

## Next steps

- For information about the Azure SQL Database service, see [What is SQL Database?](/documentation/articles/sql-database-technical-overview/)
- For information about supported features, see [Features](/documentation/articles/sql-database-features/)
- For an overview of Azure SQL logical servers, see [SQL Database logical server overview](/documentation/articles/sql-database-server-overview/)
- For information about Transact-SQL support and differences, see [Azure SQL Database Transact-SQL differences](/documentation/articles/sql-database-transact-sql-information/).
- For information about specific resource quotas and limitations based on your **service tier**. For an overview of service tiers, see [SQL Database service tiers](/documentation/articles/sql-database-service-tiers/).
- For security-related guidelines, see [Azure SQL Database Security Guidelines and Limitations](/documentation/articles/sql-database-security-guidelines/).
- For information on driver availability and support for SQL Database, see [Connection Libraries for SQL Database and SQL Server](/documentation/articles/sql-database-libraries/).

