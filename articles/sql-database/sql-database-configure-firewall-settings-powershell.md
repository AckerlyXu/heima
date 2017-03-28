<properties
	pageTitle="Configure Azure SQL Database server-level firewall rules by using PowerShell | Azure"
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


# Configure Azure SQL Database server-level firewall rules by using PowerShell


> [AZURE.SELECTOR]
- [Overview](/documentation/articles/sql-database-firewall-configure/)
- [Azure Portal](/documentation/articles/sql-database-configure-firewall-settings/)
- [TSQL](/documentation/articles/sql-database-configure-firewall-settings-tsql/)
- [PowerShell](/documentation/articles/sql-database-configure-firewall-settings-powershell/)
- [REST API](/documentation/articles/sql-database-configure-firewall-settings-rest/)


Azure SQL Database uses firewall rules to allow connections to your servers and databases. You can define server-level and database-level firewall settings for the master database or a user database in your SQL Database server to selectively allow access to the database.

> [AZURE.IMPORTANT] To allow applications from Azure to connect to your database server, Azure connections must be enabled. For more information about firewall rules and enabling connections from Azure, see [Azure SQL Database Firewall](/documentation/articles/sql-database-firewall-configure/). If you are making connections inside the Azure cloud boundary, you may have to open some additional TCP ports. For more information, see the "V12 of SQL Database: Outside vs inside" section of [Ports beyond 1433 for ADO.NET 4.5 and SQL Database V12](/documentation/articles/sql-database-develop-direct-route-ports-adonet-v12/)


[AZURE.INCLUDE [Start your PowerShell session](../../includes/sql-database-powershell.md)]

## Create server firewall rules

Server-level firewall rules can be created, updated, and deleted by using Azure PowerShell.

To create a new server-level firewall rule, execute the New-AzureRmSqlServerFirewallRule cmdlet. The following example enables a range of IP addresses on the server Contoso.

    New-AzureRmSqlServerFirewallRule -ResourceGroupName 'resourcegroup1' -ServerName 'Contoso' -FirewallRuleName "ContosoFirewallRule" -StartIpAddress '192.168.1.1' -EndIpAddress '192.168.1.10'		

To modify an existing server-level firewall rule, execute the Set-AzureSqlDatabaseServerFirewallRule cmdlet. The following example changes the range of acceptable IP addresses for the rule named ContosoFirewallRule.

    Set-AzureRmSqlServerFirewallRule -ResourceGroupName 'resourcegroup1' –StartIPAddress 192.168.1.4 –EndIPAddress 192.168.1.10 –RuleName 'ContosoFirewallRule' –ServerName 'Contoso'

To delete an existing server-level firewall rule, execute the Remove-AzureSqlDatabaseServerFirewallRule cmdlet. The following example deletes the rule named ContosoFirewallRule.

    Remove-AzureRmSqlServerFirewallRule –RuleName 'ContosoFirewallRule' –ServerName 'Contoso'


## Manage firewall rules by using PowerShell

You can also use PowerShell to manage firewall rules. For more information, see the following topics:

* [New-AzureRmSqlServerFirewallRule](https://msdn.microsoft.com/zh-cn/library/mt603860.aspx)
* [Remove-AzureRmSqlServerFirewallRule](https://msdn.microsoft.com/zh-cn/library/mt603588.aspx)
* [Set-AzureRmSqlServerFirewallRule](https://msdn.microsoft.com/zh-cn/library/mt603789.aspx)
* [Get-AzureRmSqlServerFirewallRule](https://msdn.microsoft.com/zh-cn/library/mt603586.aspx)


## Next steps

For information about how to use Transact-SQL to create server-level and database-level firewall rules, see [Configure Azure SQL Database server-level and database-level firewall rules using T-SQL](/documentation/articles/sql-database-configure-firewall-settings-tsql/).

For information about how to create server-level firewall rules using other methods, see:

- [Configure Azure SQL Database server-level firewall rules using the Azure portal](/documentation/articles/sql-database-configure-firewall-settings/)
- [Configure Azure SQL Database server-level firewall rules using the REST API](/documentation/articles/sql-database-configure-firewall-settings-rest/)

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
