---
title: Azure Cosmos DB frequently asked questions | Azure
description: Get answers to frequently asked questions about Azure Cosmos DB, a multiple-region distributed, multi-model database service. Learn about capacity, performance levels, and scaling.
keywords: Database questions, frequently asked questions, documentdb, azure, 21Vianet Azure
services: cosmos-db
author: rockboyfor
manager: digimobile
documentationcenter: ''

ms.assetid: b68d1831-35f9-443d-a0ac-dad0c89f245b
ms.service: cosmos-db
ms.workload: data-services
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 03/14/2018
ms.date: 04/23/2018
ms.author: v-yeche

---
<!-- meta.description: GLOBALLY to multiple-region -->
# Azure Cosmos DB FAQ
## Azure Cosmos DB fundamentals
### What is Azure Cosmos DB?

Azure Cosmos DB is a multiple-region replicated, multi-model database service that offers rich querying over schema-free data, helps deliver configurable and reliable performance, and enables rapid development. It's all achieved through a managed platform that's backed by the power and reach of Azure. 
<!-- Notice: GLOBALLY to multiple-region -->

Azure Cosmos DB is the right solution for web, mobile, gaming, and IoT applications when predictable throughput, high availability, low latency, and a schema-free data model are key requirements. It delivers schema flexibility and rich indexing, and it includes multi-document transactional support with integrated JavaScript. 

For more database questions, answers, and instructions for deploying and using this service, see the [Azure Cosmos DB documentation page](/cosmos-db/).

### What happened to the DocumentDB API?

The Azure Cosmos DB DocumentDB API or SQL (DocumentDB) API is now known as Azure Cosmos DB SQL API. You don't need to change anything to continue running your apps built with DocumentDB API. The functionality remains the same.

If you had a DocumentDB API account before, you now have a SQL API account, with no change to your billing. 

### What happened to Azure DocumentDB as a service?

The Azure DocumentDB service is now a part of the Azure Cosmos DB service and manifests itself in the form of the SQL API. Applications built against Azure DocumentDB will run without any changes against Azure Cosmos DB SQL API. In addition, Azure Cosmos DB supports MongoDB API.
<!--Not Available on the Table API,  Graph API (Preview), and Cassandra API (Preview) -->

### What are the typical use cases for Azure Cosmos DB?
Azure Cosmos DB is a good choice for new web, mobile, gaming, and IoT applications where automatic scale, predictable performance, fast order of millisecond response times, and the ability to query over schema-free data is important. Azure Cosmos DB lends itself to rapid development and supporting the continuous iteration of application data models. Applications that manage user-generated content and data are [common use cases for Azure Cosmos DB](use-cases.md). 

### How does Azure Cosmos DB offer predictable performance?
A [request unit](request-units.md) (RU) is the measure of throughput in Azure Cosmos DB. A 1-RU throughput corresponds to the throughput of the GET of a 1-KB document. Every operation in Azure Cosmos DB, including reads, writes, SQL queries, and stored procedure executions, has a deterministic RU value that's based on the throughput required to complete the operation. Instead of thinking about CPU, IO, and memory and how they each affect your application throughput, you can think in terms of a single RU measure.

You can reserve each Azure Cosmos DB container with provisioned throughput in terms of RUs of throughput per second. For applications of any scale, you can benchmark individual requests to measure their RU values, and provision a container to handle the total of request units across all requests. You can also scale up or scale down your container's throughput as the needs of your application evolve. For more information about request units and for help determining your container needs, see [Estimating throughput needs](request-units.md#estimating-throughput-needs) and try the [throughput calculator](https://www.documentdb.com/capacityplanner). The term *container* here refers to refers to a SQL API collection, MongoDB API collection. 
<!-- Not Available on Table API table, Graph -->

### How does Azure Cosmos DB support various data models such as columnar, and document?
Columnar and document data models are all natively supported because of the ARS (atoms, records and sequences) design that Azure Cosmos DB is built on. Atoms, records, and sequences can be easily mapped and projected to various data models. The APIs for a subset of models are available right now (SQL and MongoDB APIs) and others specific to additional data models will be available in the future.
<!-- Not Available on Table and Graph -->

Azure Cosmos DB has a schema agnostic indexing engine capable of automatically indexing all the data it ingests without requiring any schema or secondary indexes from the developer. The engine relies on a set of logical index layouts (inverted, columnar, tree) which decouple the storage layout from the index and query processing subsystems. Cosmos DB also has the ability to support a set of wire protocols and APIs in an extensible manner and translate them efficiently to the core data model (1) and the logical index layouts (2) making it uniquely capable of supporting multiple data models natively.

### Is Azure Cosmos DB HIPAA compliant?
Yes, Azure Cosmos DB is HIPAA-compliant. HIPAA establishes requirements for the use, disclosure, and safeguarding of individually identifiable health information. For more information, see the [Microsoft Trust Center](https://www.microsoft.com/en-us/TrustCenter/Compliance/HIPAA).

### What are the storage limits of Azure Cosmos DB?
There is no limit to the total amount of data that a container can store in Azure Cosmos DB.

### What are the throughput limits of Azure Cosmos DB?
There is no limit to the total amount of throughput that a container can support in Azure Cosmos DB. The key idea is to distribute your workload roughly evenly among a sufficiently large number of partition keys.

### How much does Azure Cosmos DB cost?
For details, refer to the [Azure Cosmos DB pricing details](https://www.azure.cn/pricing/details/cosmos-db/) page. Azure Cosmos DB usage charges are determined by the number of provisioned containers, the number of hours the containers were online, and the provisioned throughput for each container. The term *containers* here refers to the SQL API collection and MongoDB API collection. 
<!-- Not Avaialbe  Table API tables and Graph API graph -->

### Is a trial account available?
<!-- Not Available [Try Azure Cosmos DB for free](https://www.azure.cn/try/cosmosdb/) -->
If you are new to Azure, you can sign up for an [Azure trial account](https://www.azure.cn/pricing/1rmb-trial/), which gives you 30 days and and a credit to try all the Azure services. If you have a Visual Studio subscription, you are also eligible for [free Azure credits](https://www.azure.cn/support/legal/offer-rate-plans/) to use on any Azure service. 

You can also use the [Azure Cosmos DB Emulator](local-emulator.md) to develop and test your application locally for free, without creating an Azure subscription. When you're satisfied with how your application is working in the Azure Cosmos DB Emulator, you can switch to using an Azure Cosmos DB account in the cloud.

### How can I get additional help with Azure Cosmos DB?

To ask a technical question, you can post to one of these two question and answer forums:
* [MSDN forum](https://www.azure.cn/support/contact/)
* [Stack Overflow](http://stackoverflow.com/questions/tagged/azure-cosmosdb). Stack Overflow is best for programming questions. Make sure your question is [on-topic](https://stackoverflow.com/help/on-topic) and [provide as many details as possible, making the question clear and answerable](https://stackoverflow.com/help/how-to-ask). 

To request new features, create a new request on [Uservoice](https://www.azure.cn/support/support-azure/).
To fix an issue with your account, file a [support request](https://www.azure.cn/support/support-azure/) in the Azure portal.
<!-- Not Avaiable on newsupportrequest in (https://www.azure.cn/support/support-azure/newsupportrequest) -->

Other questions can be submitted to the team at [Azure Support](https://www.azure.cn/support/contact/); however this is not a technical support alias. 
<!-- Not Avaialble ## Try Azure Cosmos DB subscriptions-->
## Set up Azure Cosmos DB
### How do I sign up for Azure Cosmos DB?
Azure Cosmos DB is available in the Azure portal. First, sign up for an Azure subscription. After you've signed up, you can add a SQL API and MongoDB API account to your Azure subscription.
<!-- Not Available Table API , Graph API (Preview) and Cassandra API -->

### What is a master key?
A master key is a security token to access all resources for an account. Individuals with the key have read and write access to all resources in the database account. Use caution when you distribute master keys. The primary master key and secondary master key are available on the **Keys** blade of the [Azure portal][azure-portal]. For more information about keys, see [View, copy, and regenerate access keys](manage-account.md#keys).

### What are the regions that PreferredLocations can be set to? 
The PreferredLocations value can be set to any of the Azure regions in which Cosmos DB is available. For a list of available regions, see [Azure regions](https://www.azure.cn/support/service-dashboard/).

### Is there anything I should be aware of when distributing data across the multiple-region via the Azure datacenters? 
Azure Cosmos DB is present across all Azure regions, as specified on the [Azure regions](https://www.azure.cn/support/service-dashboard/) page. Because it is the core service, every new datacenter has an Azure Cosmos DB presence. 
<!-- Notice: WORLD to multiple-region(多个区域分配) -->

When you set a region, remember that Azure Cosmos DB respects sovereign and government clouds. That is, if you create an account in a sovereign region, you cannot replicate out of that sovereign region. Similarly, you cannot enable replication into other sovereign locations from an outside account. 

## Develop against the SQL API

### How do I start developing against the SQL API?
First you must sign up for an Azure subscription. Once you sign up for an Azure subscription, you can add a SQL API container to your Azure subscription. For instructions on adding an Azure Cosmos DB account, see [Create an Azure Cosmos DB database account](create-sql-api-dotnet.md#create-account). 

[SDKs](sql-api-sdk-dotnet.md) are available for .NET, Python, Node.js, JavaScript, and Java. Developers can also use the [RESTful HTTP APIs](https://docs.microsoft.com/rest/api/cosmos-db/) to interact with Azure Cosmos DB resources from various platforms and languages.

### Can I access some ready-made samples to get a head start?
Samples for the SQL API [.NET](sql-api-dotnet-samples.md), [Java](https://github.com/Azure/azure-documentdb-java), [Node.js](sql-api-nodejs-samples.md), and [Python](sql-api-python-samples.md) SDKs are available on GitHub.

### Does the SQL API database support schema-free data?
Yes, the SQL API allows applications to store arbitrary JSON documents without schema definitions or hints. Data is immediately available for query through the Azure Cosmos DB SQL query interface.  

### Does the SQL API support ACID transactions?
Yes, the SQL API supports cross-document transactions expressed as JavaScript-stored procedures and triggers. Transactions are scoped to a single partition within each collection and executed with ACID semantics as "all or nothing," isolated from other concurrently executing code and user requests. If exceptions are thrown through the server-side execution of JavaScript application code, the entire transaction is rolled back. For more information about transactions, see [Database program transactions](programming.md#database-program-transactions).

### What is a collection?
A collection is a group of documents and their associated JavaScript application logic. A collection is a billable entity, where the [cost](performance-levels.md) is determined by the throughput and used storage. Collections can span one or more partitions or servers and can scale to handle practically unlimited volumes of storage or throughput.

Collections are also the billing entities for Azure Cosmos DB. Each collection is billed hourly, based on the provisioned throughput and used storage space. For more information, see [Azure Cosmos DB Pricing](https://www.azure.cn/pricing/details/cosmos-db/). 

### How do I create a database?
You can create databases by using the [Azure portal](https://portal.azure.cn), as described in [Add a collection](create-sql-api-dotnet.md#create-collection), one of the [Azure Cosmos DB SDKs](sql-api-sdk-dotnet.md), or the [REST APIs](https://docs.microsoft.com/rest/api/cosmos-db/). 

### How do I set up users and permissions?
You can create users and permissions by using one of the [Cosmos DB API SDKs](sql-api-sdk-dotnet.md) or the [REST APIs](https://docs.microsoft.com/rest/api/cosmos-db/).  

### Does the SQL API support SQL?
The SQL query language supported by SQL API accounts is an enhanced subset of the query functionality that's supported by SQL Server. The Azure Cosmos DB SQL query language provides rich hierarchical and relational operators and extensibility via JavaScript-based, user-defined functions (UDFs). JSON grammar allows for modeling JSON documents as trees with labeled nodes, which are used by both the Azure Cosmos DB automatic indexing techniques and the SQL query dialect of Azure Cosmos DB. For information about using SQL grammar, see the [SQL Query][query] article.

### Does the SQL API support SQL aggregation functions?
The SQL API supports low-latency aggregation at any scale via aggregate functions `COUNT`, `MIN`, `MAX`, `AVG`, and `SUM` via the SQL grammar. For more information, see [Aggregate functions](sql-api-sql-query.md#Aggregates).

### How does the SQL API provide concurrency?
The SQL API supports optimistic concurrency control (OCC) through HTTP entity tags, or ETags. Every SQL API resource has an ETag, and the ETag is set on the server every time a document is updated. The ETag header and the current value are included in all response messages. ETags can be used with the If-Match header to allow the server to decide whether a resource should be updated. The If-Match value is the ETag value to be checked against. If the ETag value matches the server ETag value, the resource is updated. If the ETag is no longer current, the server rejects the operation with an "HTTP 412 Precondition failure" response code. The client then re-fetches the resource to acquire the current ETag value for the resource. In addition, ETags can be used with the If-None-Match header to determine whether a re-fetch of a resource is needed.

To use optimistic concurrency in .NET, use the [AccessCondition](https://msdn.microsoft.com/library/azure/microsoft.azure.documents.client.accesscondition.aspx) class. For a .NET sample, see [Program.cs](https://github.com/Azure/azure-documentdb-dotnet/blob/master/samples/code-samples/DocumentManagement/Program.cs) in the DocumentManagement sample on GitHub.

### How do I perform transactions in the SQL API?
The SQL API supports language-integrated transactions via JavaScript-stored procedures and triggers. All database operations inside scripts are executed under snapshot isolation. If it is a single-partition collection, the execution is scoped to the collection. If the collection is partitioned, the execution is scoped to documents with the same partition-key value within the collection. A snapshot of the document versions (ETags) is taken at the start of the transaction and committed only if the script succeeds. If the JavaScript throws an error, the transaction is rolled back. For more information, see [Server-side JavaScript programming for Azure Cosmos DB](programming.md).

### How can I bulk-insert documents into Cosmos DB?
You can bulk-insert documents into Azure Cosmos DB in either of two ways:

* The data migration tool, as described in [Database migration tool for Azure Cosmos DB](import-data.md).
* Stored procedures, as described in [Server-side JavaScript programming for Azure Cosmos DB](programming.md).

### Does the SQL API support resource link caching?
Yes, because Azure Cosmos DB is a RESTful service, resource links are immutable and can be cached. SQL API clients can specify an "If-None-Match" header for reads against any resource-like document or collection and then update their local copies after the server version has changed.

### Is a local instance of SQL API available?
Yes. The [Azure Cosmos DB Emulator](local-emulator.md) provides a high-fidelity emulation of the Cosmos DB service. It supports functionality that's identical to Azure Cosmos DB, including support for creating and querying JSON documents, provisioning and scaling collections, and executing stored procedures and triggers. You can develop and test applications by using the Azure Cosmos DB Emulator, and deploy them to Azure at a multiple-region scale by making a single configuration change to the connection endpoint for Azure Cosmos DB.
<!-- Notice: 全球范围 to 多个区域范围 -->

## Develop against the API for MongoDB
### What is the Azure Cosmos DB API for MongoDB?
The Azure Cosmos DB API for MongoDB is a compatibility layer that allows applications to easily and transparently communicate with the native Azure Cosmos DB database engine by using existing, community-supported Apache MongoDB APIs and drivers. Developers can now use existing MongoDB tool chains and skills to build applications that take advantage of Azure Cosmos DB. Developers benefit from the unique capabilities of Azure Cosmos DB, which include auto-indexing, backup maintenance, financially backed service level agreements (SLAs), and so on.

### How do I connect to my API for MongoDB database?
The quickest way to connect to the Azure Cosmos DB API for MongoDB is to head over to the [Azure portal](https://portal.azure.cn). Go to your account and then, on the left navigation menu, click **Quick Start**. Quick Start is the best way to get code snippets to connect to your database. 

Azure Cosmos DB enforces strict security requirements and standards. Azure Cosmos DB accounts require authentication and secure communication via SSL, so be sure to use TLSv1.2.

For more information, see [Connect to your API for MongoDB database](connect-mongodb-account.md).

### Are there additional error codes for an API for MongoDB database?
In addition to the common MongoDB error codes, the MongoDB API has its own specific error codes:

| Error               | Code  | Description  | Solution  |
|---------------------|-------|--------------|-----------|
| TooManyRequests     | 16500 | The total number of request units consumed has exceeded the provisioned request-unit rate for the collection and has been throttled. | Consider scaling the throughput of the collection from the Azure portal or retrying again. |
| ExceededMemoryLimit | 16501 | As a multi-tenant service, the operation has exceeded the client's memory allotment. | Reduce the scope of the operation through more restrictive query criteria or contact support from the [Azure portal](https://www.azure.cn/support/support-azure/). <br><br>Example: *&nbsp;&nbsp;&nbsp;&nbsp;db.getCollection('users').aggregate([<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{$match: {name: "Andy"}}, <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{$sort: {age: -1}}<br>&nbsp;&nbsp;&nbsp;&nbsp;])*) |

<!-- Not Available ## Develop with the Table API -->

<!-- Not Available ## Develop against the Graph API (Preview) -->



<!-- Not Available on ## Develop with the Apache Cassandra API (preview) -->

[azure-portal]: https://portal.azure.cn
[query]: sql-api-sql-query.md

<!--Update_Description: update meta properties, update link, wording update -->