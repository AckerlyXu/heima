---
title: Table Auditing, TDS redirection, and IP endpoints for Azure SQL Database | Azure
description: Learn about auditing, TDS redirection and IP endpoint changes when implementing table auditing in Azure SQL Database.
services: sql-database
author: Hayley244
manager: digimobile

ms.service: sql-database
ms.custom: security
ms.topic: article
origin.date: 05/31/2017
ms.date: 07/10/2017
ms.author: v-johch

---

# SQL Database -  Downlevel clients support and IP endpoint changes for Table Auditing

> [!IMPORTANT]
> This document applies only to Table Auditing, which is **now deprecated**.<br>
> Please use the new [Blob Auditing](sql-database-auditing.md) method, which **does not** require downlevel client connection string modifications. Additional info on Blob Auditing can be found in [Get started with SQL database auditing](sql-database-auditing.md).

[Database Auditing](sql-database-auditing.md) works automatically with SQL clients that support TDS redirection. Note that redirection does not apply when using the Blob Auditing method.

## <a id="subheading-1"></a>Downlevel clients support
Any client which implements TDS 7.4 should also support redirection. Exceptions to this include JDBC 4.0 in which the redirection feature is not fully supported and Tedious for Node.JS in which redirection was not implemented.

For "Downlevel clients", i.e. which support TDS version 7.3 and below - the server FQDN in the connection string should be modified:

Original server FQDN in the connection string: <*server name*>.database.chinacloudapi.cn

Modified server FQDN in the connection string: <*server name*>.database.**secure**.chinacloudapi.cn

A partial list of "Downlevel clients" includes:

* .NET 4.0 and below,
* ODBC 10.0 and below.
* JDBC (while JDBC does support TDS 7.4, the TDS redirection feature is not fully supported)
* Tedious (for Node.JS)

**Remark:** The above server FDQN modification may be useful also for applying a SQL Server Level Auditing policy without a need for a configuration step in each database (Temporary mitigation).

## <a id="subheading-2"></a>IP endpoint changes when enabling Auditing
Please note that when you enable Table Auditing, the IP endpoint of your database will change. If you have strict firewall settings, please update those firewall settings accordingly.

The new database IP endpoint will depend on the database region:

| Database Region | Possible IP endpoints |
| --- | --- |
| China North  | 139.217.29.176, 139.217.28.254 |
| China East  | 42.159.245.65, 42.159.246.245 |