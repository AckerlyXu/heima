<properties 
	pageTitle="How to create a database in DocumentDB | Azure" 
	description="Learn how to create a database using the online service portal for Azure DocumentDB, your blazing fast, global-scale NoSQL database." 
	keywords="how to create a database" 
	services="documentdb" 
	authors="mimig1" 
	manager="jhubbard" 
	editor="monicar" 
	documentationCenter=""/>

<tags 
	ms.service="documentdb" 
	ms.workload="data-services" 
	ms.tgt_pltfrm="na" 
	ms.devlang="na" 
	ms.topic="article" 
	ms.date="10/17/2016" 
	ms.author="mimig"
	wacn.date=""/>

# How to create a database for DocumentDB using the Azure portal

To use Azure DocumentDB, you must have a [DocumentDB account](/documentation/articles/documentdb-create-account/), a database, a collection, and documents. In the Azure portal, DocumentDB databases are now created at the same time as a collection is created. 

To create a DocumentDB database and collection in the portal, see [How to create a DocumentDB collection using the Azure portal](/documentation/articles/documentdb-create-collection/).

## Other ways to create a DocumentDB database

Databases do not have to be created using the portal, you can also create them using the [DocumentDB SDKs](/documentation/articles/documentdb-sdk-dotnet/) or the [REST API](https://msdn.microsoft.com/zh-cn/library/mt489072.aspx). For information on working with databases by using the .NET SDK, see [.NET database examples](/documentation/articles/documentdb-dotnet-samples/#database-examples/). For information on working with databases by using the Node.js SDK, see [Node.js database examples](/documentation/articles/documentdb-nodejs-samples/#database-examples/). 

## Next steps

Once your database and collection are created, you can [add JSON documents](/documentation/articles/documentdb-view-json-document-explorer/) by using the Document Explorer in the portal, [import documents](/documentation/articles/documentdb-import-data/) into the collection by using the DocumentDB Data Migration Tool, or use one of the [DocumentDB SDKs](/documentation/articles/documentdb-sdk-dotnet/) to perform CRUD operations. DocumentDB has .NET, Java, Python, Node.js, and JavaScript API SDKs. For .NET code samples showing how to create, remove, update and delete documents, see [.NET document examples](/documentation/articles/documentdb-dotnet-samples/#document-examples/). For information on working with documents by using the Node.js SDK, see [Node.js document examples](/documentation/articles/documentdb-nodejs-samples/#document-examples/). 

After you have documents in a collection, you can use [DocumentDB SQL](/documentation/articles/documentdb-sql-query/) to [execute queries](/documentation/articles/documentdb-sql-query/#executing-sql-queries/) against your documents by using the [Query Explorer](/documentation/articles/documentdb-query-collections-query-explorer/) in the Portal, the [REST API](https://msdn.microsoft.com/zh-cn/library/azure/dn781481.aspx), or one of the [SDKs](/documentation/articles/documentdb-sdk-dotnet/). 
