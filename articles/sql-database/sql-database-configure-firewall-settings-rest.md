<properties
	pageTitle="Azure SQL Database server-level firewall rules using the REST API | Azure"
	description="Learn how to configure the firewall for IP addresses that access Azure SQL databases."
	services="sql-database"
	documentationCenter=""
	authors="stevestein"
	manager="jhubbard"
	editor=""/>


<tags
	ms.service="sql-database"
	ms.date="08/09/2016"
	wacn.date="05/23/2016"/>


#  Configure Azure SQL Database server-level firewall rules using the REST API


> [AZURE.SELECTOR]
- [Overview](/documentation/articles/sql-database-firewall-configure/)
- [Azure Portal](/documentation/articles/sql-database-configure-firewall-settings/)
- [TSQL](/documentation/articles/sql-database-configure-firewall-settings-tsql/)
- [PowerShell](/documentation/articles/sql-database-configure-firewall-settings-powershell/)
- [REST API](/documentation/articles/sql-database-configure-firewall-settings-rest/)


Azure SQL Database uses firewall rules to allow connections to your servers and databases. You can define server-level and database-level firewall settings for the master or a user database in your Azure SQL Database server to selectively allow access to the database.

> [AZURE.IMPORTANT] To allow applications from Azure to connect to your database server, Azure connections must be enabled. For more information about firewall rules and enabling connections from Azure, see [Azure SQL Database Firewall](/documentation/articles/sql-database-firewall-configure/). If you are making connections inside the Azure cloud boundary, you may have to open some additional TCP ports. For more information, see the **V12 of SQL Database: Outside vs inside** section of [Ports beyond 1433 for ADO.NET 4.5 and SQL Database V12](/documentation/articles/sql-database-develop-direct-route-ports-adonet-v12/)


## Manage server-level firewall rules through REST API
1. Managing firewall rules through REST API must be authenticated. For information, see [Developer's guide to authorization with the Azure Resource Manager API](/documentation/articles/resource-manager-api-authentication/).
2. Server-level rules can be created, updated, or deleted using REST API

	To create or update a server-level firewall rule, execute the PUT method using the following:
 
		https://management.chinacloudapi.cn/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.Sql/servers/{server-name}/firewallRules/{rule-name}?api-version={api-version}
	
	Request Body

		{
         "properties": { 
            "startIpAddress": "{start-ip-address}", 
            "endIpAddress": "{end-ip-address}
            }
        } 
 

	To remove an existing server-level firewall rule, execute the DELETE method using the following:
	 
		https://management.chinacloudapi.cn/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.Sql/servers/{server-name}/firewallRules/{rule-name}?api-version={api-version}


## Manage firewall rules using the REST API

* [Create or Update Firewall Rule](https://msdn.microsoft.com/zh-cn/library/azure/mt445501.aspx)
* [Delete Firewall Rule](https://msdn.microsoft.com/zh-cn/library/azure/mt445502.aspx)
* [Get Firewall Rule](https://msdn.microsoft.com/zh-cn/library/azure/mt445503.aspx)
* [List All Firewall Rules](https://msdn.microsoft.com/zh-cn/library/azure/mt604478.aspx)
 
## Next steps

For a how to article on how to use Transact-SQL to create server-level and database-level firewall rules, see [Configure Azure SQL Database server-level and database-level firewall rules using T-SQL](/documentation/articles/sql-database-configure-firewall-settings-tsql/). 

For how to articles on creating server-level firewall rules using other methods, see: 

- [Configure Azure SQL Database server-level firewall rules using the Azure Portal](/documentation/articles/sql-database-configure-firewall-settings/)
- [Configure Azure SQL Database server-level firewall rules using PowerShell](/documentation/articles/sql-database-configure-firewall-settings-powershell/)

For a tutorial on creating a database, see [Create a SQL database in minutes using the Azure portal](/documentation/articles/sql-database-get-started/).
For help in connecting to an Azure SQL database from open source or third-party applications, see [Client quick-start code samples to SQL Database](https://msdn.microsoft.com/zh-cn/library/azure/ee336282.aspx).
To understand how to navigate to databases see [Manage database access and login security](/documentation/articles/sql-database-manage-logins/).


## Additional resources

- [Securing your database](/documentation/articles/sql-database-security/)
- [Security Center for SQL Server Database Engine and Azure SQL Database](https://msdn.microsoft.com/zh-cn/library/bb510589)

<!--Image references-->
[1]: ./media/sql-database-configure-firewall-settings/AzurePortalBrowseForFirewall.png
[2]: ./media/sql-database-configure-firewall-settings/AzurePortalFirewallSettings.png
<!--anchors-->

 
