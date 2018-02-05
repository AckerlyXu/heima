---
title: Build integrated solutions with SQL Data Warehouse | Azure
description: Tools and partners with solutions that integrate with SQL Data Warehouse. 
services: sql-data-warehouse
documentationcenter: NA
author: rockboyfor
manager: digimobile
editor: ''

ms.assetid: e2dc8f3f-10e3-4589-a4e2-50c67dfcf67f
ms.service: sql-data-warehouse
ms.devlang: NA
ms.topic: article
ms.tgt_pltfrm: NA
ms.workload: data-services
ms.custom: integrate
origin.date: 10/31/2016
ms.date: 07/17/2017
ms.author: v-yeche

---

# Leverage other services with SQL Data Warehouse
In addition to its core functionality, SQL Data Warehouse enables users to leverage many of the other services in Azure alongside it.  Specifically, we have currently taken steps to deeply integrate with the following:

* Azure Stream Analytics
<!-- Not Available Power BI, Azure Data Factory, Azure Machine Learning -->

We are working to connect with more services across the Azure ecosystem.

<!-- Not Available ## Power BI -->
<!-- Not Available ## Azure Data Factory -->
<!-- Not Available ## Azure Machine Learning -->
##Azure Stream Analytics
Azure Stream Analytics is a complex, fully managed infrastructure for processing and consuming event data generated from Azure Event Hub.  Integration with SQL Data Warehouse allows for streaming data to be effectively processed and stored alongside relational data enabling deeper, more advanced analysis.  

* **Job Output:** Send output from Stream Analytics jobs directly to SQL Data Warehouse.

See [Integrate with Azure Stream Analytics](sql-data-warehouse-integrate-azure-stream-analytics.md) or the [Azure Stream Analytics documentation](http://docs.azure.cn/zh-cn/stream-analytics/) for more information.

<!--Image references-->

<!--Article references-->
[development overview]: sql-data-warehouse-overview-develop/

<!-- Not Available on [Azure Data Factory]: sql-data-warehouse-integrate-azure-data-factory.md -->
<!-- Not Available on [Azure Machine Learning]: sql-data-warehouse-integrate-azure-machine-learning.md -->
[Azure Stream Analytics]: sql-data-warehouse-integrate-azure-stream-analytics.md
<!-- Not Available on [Power BI]: sql-data-warehouse-integrate-power-bi.md -->
<!-- Not Available on [Partners]: sql-data-warehouse-partner-business-intelligence.md -->

<!--MSDN references-->

<!--Other Web references-->