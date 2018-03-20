---
title: Azure CosmosDB Table API .NET SDK & Resources | Azure
description: Learn all about the Azure Cosmos DB Table API including release dates, retirement dates, and changes made between each version.
services: cosmos-db
documentationcenter: .net
author: rockboyfor
manager: digimobile
editor: cgronlun

ms.assetid: 
ms.service: cosmos-db
ms.workload: data-services
ms.tgt_pltfrm: na
ms.devlang: dotnet
ms.topic: article
origin.date: 02/21/2018
ms.date: 03/05/2018
ms.author: v-yeche

---
# Azure Cosmos DB Table .NET API: Download and release notes
> [!div class="op_single_selector"]
> * [.NET](table-sdk-dotnet.md)
> * [Java](table-sdk-java.md)
> * [Node.js](table-sdk-nodejs.md)
> * [Python](table-sdk-python.md)

|   |   |
|---|---|
|**SDK download**|[NuGet](https://aka.ms/acdbtablenuget)|
|**API documentation**|[.NET API reference documentation](https://aka.ms/acdbtableapiref)|
|**Quickstart**|[Azure Cosmos DB: Build an app with .NET and the Table API](create-table-dotnet.md)|
|**Tutorial**|[Azure Cosmos DB: Develop with the Table API in .NET](tutorial-develop-table-dotnet.md)|
|**Current supported framework**|[Microsoft .NET Framework 4.5.1](https://www.microsoft.com/download/details.aspx?id=40779)|

> [!IMPORTANT]
> If you created a Table API account during the preview, please create a [new Table API account](create-table-dotnet.md#create-a-database-account) to work with the generally available Table API SDKs.
>

<!-- Not Avaialble ## Release notes -->
<!-- Not Avaialble ## Release and Retirement dates -->

## <a name="troubleshooting"></a> Troubleshooting
## Troubleshooting

If you get the error 

```
Unable to resolve dependency 'Microsoft.Azure.Storage.Common'. Source(s) used: 'nuget.org', 
'CliFallbackFolder', 'Microsoft Visual Studio Offline Packages', 'Azure Service Fabric SDK'`
```

when attempting to use the Microsoft.Azure.CosmosDB.Table NuGet package, you have two options to fix the issue:

* Use Package Manage Console to install the Microsoft.Azure.CosmosDB.Table package and its dependencies. To do this, type the following in the Package Manager Console for your solution. 
    ```
    Install-Package Microsoft.Azure.CosmosDB.Table -IncludePrerelease
    ```

* Using your preferred Nuget package management tool, install the Microsoft.Azure.Storage.Common Nuget package before installing Microsoft.Azure.CosmosDB.Table.

## FAQ

[!INCLUDE [cosmos-db-sdk-faq](../../includes/cosmos-db-sdk-faq.md)]

## See also
To learn more about the Azure Cosmos DB Table API, see [Introduction to Azure Cosmos DB Table API](table-introduction.md).

<!-- Update_Description: update meta properties, wording update -->