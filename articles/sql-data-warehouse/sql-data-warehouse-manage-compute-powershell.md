<properties
    pageTitle="Manage compute power in Azure SQL Data Warehouse (PowerShell) | Azure"
    description="PowerShell tasks to manage compute power. Scale compute resources by adjusting DWUs. Or, pause and resume compute resources to save costs."
    services="sql-data-warehouse"
    documentationcenter="NA"
    author="barbkess"
    manager="jhubbard"
    editor="" />
<tags
    ms.assetid="8354a3c1-4e04-4809-933f-db414a8c74dc"
    ms.service="sql-data-warehouse"
    ms.devlang="NA"
    ms.topic="article"
    ms.tgt_pltfrm="NA"
    ms.workload="data-services"
    ms.date="10/31/2016"
    wacn.date=""
    ms.author="barbkess" />

# Manage compute power in Azure SQL Data Warehouse (PowerShell)

> [AZURE.SELECTOR]
- [Overview](/documentation/articles/sql-data-warehouse-manage-compute-overview/)
- [Portal](/documentation/articles/sql-data-warehouse-manage-compute-portal/)
- [PowerShell](/documentation/articles/sql-data-warehouse-manage-compute-powershell/)
- [REST](/documentation/articles/sql-data-warehouse-manage-compute-rest-api/)
- [TSQL](/documentation/articles/sql-data-warehouse-manage-compute-tsql/)

## Before you begin

### Install the latest version of Azure PowerShell
> [AZURE.NOTE]
> To use Azure PowerShell with SQL Data Warehouse, you need Azure PowerShell version 1.0.3 or greater.  To verify your current version run the command **Get-Module -ListAvailable -Name Azure**. You can install the latest version from [Microsoft Web Platform Installer][Microsoft Web Platform Installer].  For more information, see [How to install and configure Azure PowerShell][How to install and configure Azure PowerShell].
> 
> 

### Get started with Azure PowerShell cmdlets

To get started:

1. Open Azure PowerShell. 
2. At the PowerShell prompt, run these commands to sign in to the Azure Resource Manager and select your subscription.

        Login-AzureRmAccount -EnvironmentName AzureChinaCloud
        Get-AzureRmSubscription
        Select-AzureRmSubscription -SubscriptionName "MySubscription"

<a name="scale-performance-bk"></a>
## <a name="scale-compute-bk"></a> Scale compute power

[AZURE.INCLUDE [SQL Data Warehouse scale DWUs description](../../includes/sql-data-warehouse-scale-dwus-description.md)]

To change the DWUs, use the [Set-AzureRmSqlDatabase][Set-AzureRmSqlDatabase] PowerShell cmdlet. The following example sets the service level objective to DW1000 for the database MySQLDW which is hosted on server MyServer.

    Set-AzureRmSqlDatabase -DatabaseName "MySQLDW" -ServerName "MyServer" -RequestedServiceObjectiveName "DW1000"

## <a name="pause-compute-bk"></a> Pause compute

[AZURE.INCLUDE [SQL Data Warehouse pause description](../../includes/sql-data-warehouse-pause-description.md)]

To pause a database, use the [Suspend-AzureRmSqlDatabase][Suspend-AzureRmSqlDatabase] cmdlet. The following example pauses a database named Database02 hosted on a server named Server01. The server is in an Azure resource group named ResourceGroup1.

> [AZURE.NOTE]
> Note that if your server is foo.database.chinacloudapi.cn, use "foo" as the -ServerName in the PowerShell cmdlets.
> 
> 

    Suspend-AzureRmSqlDatabase -ResourceGroupName "ResourceGroup1" `
    -ServerName "Server01" -DatabaseName "Database02"

A variation, this next example retrieves the database into the $database object. It then pipes the object to [Suspend-AzureRmSqlDatabase][Suspend-AzureRmSqlDatabase]. The results are stored in the object resultDatabase. The final command shows the results.

    $database = Get-AzureRmSqlDatabase -ResourceGroupName "ResourceGroup1" `
    -ServerName "Server01" -DatabaseName "Database02"
    $resultDatabase = $database | Suspend-AzureRmSqlDatabase
    $resultDatabase

## <a name="resume-compute-bk"></a> Resume compute

[AZURE.INCLUDE [SQL Data Warehouse resume description](../../includes/sql-data-warehouse-resume-description.md)]

To start a database, use the [Resume-AzureRmSqlDatabase][Resume-AzureRmSqlDatabase] cmdlet. The following example starts a database named Database02 hosted on a server named Server01. The server is in an Azure resource group named ResourceGroup1.

    Resume-AzureRmSqlDatabase -ResourceGroupName "ResourceGroup1" `
    -ServerName "Server01" -DatabaseName "Database02"

A variation, this next example retrieves the database into the $database object. It then pipes the object to [Resume-AzureRmSqlDatabase][Resume-AzureRmSqlDatabase] and stores the results in $resultDatabase. The final command shows the results.

    $database = Get-AzureRmSqlDatabase -ResourceGroupName "ResourceGroup1" `
    -ServerName "Server01" -DatabaseName "Database02"
    $resultDatabase = $database | Resume-AzureRmSqlDatabase
    $resultDatabase

## <a name="next-steps-bk"></a> Next steps

For other management tasks, see [Management overview][].

<!--Image references-->

<!--Article references-->
[Service capacity limits]: /documentation/articles/sql-data-warehouse-service-capacity-limits/
[Management overview]: /documentation/articles/sql-data-warehouse-overview-manage/
[How to install and configure Azure PowerShell]: https://docs.microsoft.com/powershell/azureps-cmdlets-docs/
[Manage compute overview]: /documentation/articles/sql-data-warehouse-manage-compute-overview/

<!--MSDN references-->
[Resume-AzureRmSqlDatabase]: https://msdn.microsoft.com/zh-cn/library/mt619347.aspx
[Suspend-AzureRmSqlDatabase]: https://msdn.microsoft.com/zh-cn/library/mt619337.aspx
[Set-AzureRmSqlDatabase]: https://msdn.microsoft.com/zh-cn/library/mt619433.aspx

<!--Other Web references-->
[Microsoft Web Platform Installer]: https://www.microsoft.com/web/downloads/platform.aspx
[Azure portal]: http://portal.azure.cn/
