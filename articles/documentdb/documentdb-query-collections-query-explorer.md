<properties
    pageTitle="Azure DocumentDB portal tool: Query Explorer | Azure"
    description="Learn about the DocumentDB Query Explorer, a SQL query editor in the Azure portal for writing SQL queries and running them against a NoSQL DocumentDB collection."
    keywords="writing sql queries, sql query editor"
    services="documentdb"
    author="kirillg"
    manager="jhubbard"
    editor="monicar"
    documentationcenter="" />
<tags
    ms.assetid="ac378240-b11f-4522-ae9f-09da3a6f9c16"
    ms.service="documentdb"
    ms.workload="data-services"
    ms.tgt_pltfrm="na"
    ms.devlang="na"
    ms.topic="article"
    ms.date="02/10/2017"
    wacn.date=""
    ms.author="kirillg" />

# Write, edit, and run SQL queries for DocumentDB using Query Explorer in the Azure portal
This article provides an overview of the [Azure DocumentDB](/home/features/documentdb/) Query Explorer, an Azure portal tool that enables you to write, edit, and run SQL queries against a [DocumentDB collection](/documentation/articles/documentdb-create-collection/).

1. In the [Azure portal](https://portal.azure.cn), on the left navigation, click ![Azure DocumentDB icon](./media/documentdb-query-collections-query-explorer/nosql-documentdb-portal-icon.png) **NoSQL (DocumentDB)**. 

    If **NoSQL (DocumentDB)** is not visible, click **More Services** at the bottom, and then click ![Azure DocumentDB icon](./media/documentdb-query-collections-query-explorer/nosql-documentdb-portal-icon.png) **NoSQL (DocumentDB)**.
2. In the resource menu, click **Query Explorer**. 
   
    ![Screenshot of the Azure portal with Query Explorer highlighted](./media/documentdb-query-collections-query-explorer/queryexplorercommand.png)
3. In the **Query Explorer** blade, select the **Databases** and **Collections** to query from the drop down lists, and type the query to run. 
   
    The **Databases** and **Collections** drop-down lists are pre-populated depending on the context in which you launch Query Explorer. 
   
    A default query of `SELECT TOP 100 * FROM c` is provided.  You can accept the default query or construct your own query using the SQL query language described in the [SQL query cheat sheet](/documentation/articles/documentdb-sql-query-cheat-sheet/) or the [SQL query and SQL syntax](/documentation/articles/documentdb-sql-query/) article.
   
    Click **Run query** to view the results.
   
    ![Screenshot of writing SQL queries in Query Explorer, a SQL query editor](./media/documentdb-query-collections-query-explorer/queryexplorerinitial.png)
4. The **Results** blade displays the output of the query. 
   
    ![Screenshot of results of writing SQL queries in Query Explorer](./media/documentdb-query-collections-query-explorer/queryresults1.png)

## Work with results
By default, Query Explorer returns results in sets of 100.  If your query produces more than 100 results, simply use the **Next page** and **Previous page** commands to navigate through the result set.

![Screenshot of Query Explorer pagination support](./media/documentdb-query-collections-query-explorer/queryresultspagination.png)

For successful queries, the **Information** pane contains metrics such as the request charge,  the number of round trips the query made, the set of results currently being shown, and whether there are more results, which can then be accessed via the **Next page** command, as mentioned previously.

![Screenshot of Query Explorer query information](./media/documentdb-query-collections-query-explorer/queryinformation.png)

## Use multiple queries
If you're using multiple queries and want to quickly switch between them, you can enter all the queries in the query text box of the **Query Explorer** blade, then highlight the one you want to run, and then click **Run query** to view the results.

![Screenshot of writing multiple SQL queries in Query Explorer (a SQL query editor) and highlighting and running individual queries](./media/documentdb-query-collections-query-explorer/queryexplorerhighlightandrun.png)

## Add queries from a file into the SQL query editor
You can load the contents of an existing file using the **Load File** command.

![Screenshot showing how to load SQL queries from a file into Query Explorer using Load File](./media/documentdb-query-collections-query-explorer/loadqueryfile.png)

## Troubleshoot
If a query completes with errors, Query Explorer displays a list of errors that can help with troubleshooting efforts.

![Screenshot of Query Explorer query errors](./media/documentdb-query-collections-query-explorer/queryerror.png)

## Run DocumentDB SQL queries outside the portal
The Query Explorer in the Azure portal is just one way to run SQL queries against DocumentDB. You can also run SQL queries using the [REST API](https://msdn.microsoft.com/zh-cn/library/azure/dn781481.aspx) or the [client SDKs](/documentation/articles/documentdb-sdk-dotnet/). For more information about using these other methods, see [Executing SQL queries](/documentation/articles/documentdb-sql-query/#executing-sql-queries/)

## Next steps
To learn more about the DocumentDB SQL grammar supported in Query Explorer, see the [SQL query and SQL syntax](/documentation/articles/documentdb-sql-query/) article or print out the [SQL query cheat sheet](/documentation/articles/documentdb-sql-query-cheat-sheet/).
You may also enjoy experimenting with the [Query Playground](https://www.documentdb.com/sql/demo) where you can test out queries online using a sample dataset.

