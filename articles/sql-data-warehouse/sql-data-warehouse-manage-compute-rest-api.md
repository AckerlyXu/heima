---
title: Pause, resume, scale with REST in Azure SQL Data Warehouse | Azure
description: Manage compute power in SQL Data Warehouse through REST APIs.
services: sql-data-warehouse
documentationcenter: NA
author: rockboyfor
manager: digimobile
editor: ''

ms.service: sql-data-warehouse
ms.devlang: NA
ms.topic: article
ms.tgt_pltfrm: NA
ms.workload: data-services
ms.custom: manage
origin.date: 02/13/2018
ms.date: 03/12/2018
ms.author: v-yeche

---
# REST APIs for Azure SQL Data Warehouse
REST APIs for managing compute in Azure SQL Data Warehouse.


<a name="scale-performance-bk"></a>
<a name="scale-compute-bk"></a>
## Scale compute
To change the data warehouse units, use the [Create or Update Database](https://docs.microsoft.com/rest/api/sql/databases/createorupdate) REST API. The following example sets the data warehouse units to DW1000 for the database MySQLDW, which is hosted on server MyServer. The server is in an Azure resource group named ResourceGroup1.

```
PATCH https://management.chinacloudapi.cn/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.Sql/servers/{server-name}/databases/{database-name}?api-version=2014-04-01-preview HTTP/1.1
Content-Type: application/json; charset=UTF-8

{
    "properties": {
        "requestedServiceObjectiveName": DW1000
    }
}
```

<a name="pause-compute-bk"></a>

## Pause compute

To pause a database, use the [Pause Database](https://docs.microsoft.com/rest/api/sql/databases/pause) REST API. The following example pauses a database named Database02 hosted on a server named Server01. The server is in an Azure resource group named ResourceGroup1.

```
POST https://management.chinacloudapi.cn/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.Sql/servers/{server-name}/databases/{database-name}/pause?api-version=2014-04-01-preview HTTP/1.1
```

<a name="resume-compute-bk"></a>

## Resume compute

To start a database, use the [Resume Database](https://docs.microsoft.com/rest/api/sql/databases/resume) REST API. The following example starts a database named Database02 hosted on a server named Server01. The server is in an Azure resource group named ResourceGroup1. 

```
POST https://management.chinacloudapi.cn/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.Sql/servers/{server-name}/databases/{database-name}/resume?api-version=2014-04-01-preview HTTP/1.1
```

## Check database state

```
GET https://management.chinacloudapi.cn/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.Sql/servers/{server-name}/databases/{database-name}?api-version=2014-04-01 HTTP/1.1
```

<a name="next-steps-bk"></a>
## Next steps
For other management tasks, see [Management overview](./sql-data-warehouse-overview-manage.md).
<!--Update_Description: update meta properties, wording update-->