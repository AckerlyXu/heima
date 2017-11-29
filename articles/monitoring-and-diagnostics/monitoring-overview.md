---
title: Monitoring in Microsoft Azure | Azure
description:  Choices when you want to monitor anything in Microsoft Azure.
author: rboucher
manager: carmonm
editor: ''
services: monitoring-and-diagnostics
documentationcenter: monitoring-and-diagnostics

ms.assetid: 1b962c74-8d36-4778-b816-a893f738f92d
ms.service: monitoring-and-diagnostics
ms.workload: na
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 10/04/2017
ms.author: v-yiso
ms.date: 12/11/2017
---

# Overview of Monitoring in Microsoft Azure
This article provides an overview of the tools and services involved in holistically monitoring Microsoft Azure. It applies to:
- Using Azure services to monitor Azure infrastructure and applications
- Using Azure services to monitor hybrid and non-Azure infrastructure and applications
- Using non-Azure services to monitor Azure infrastructure and applications

It discusses the various products and services available and how they work together. It can assist you to determine which tools are most appropriate for you in what cases.  

## Why use Azure's monitoring services?

Performance issues in your cloud app can impact your business. With multiple interconnected components and frequent releases, degradations can happen at any time. And if you’re developing an app, your users usually discover issues that you didn’t find in testing. You should know about these issues immediately, and have tools for diagnosing and fixing the problems. Furthermore, problems in your application often result from the underlying infrastructure on which those applications run, so having a holistic view of your application and infrastructure is key to monitoring your Azure environment. Microsoft Azure has a range of tools for identifying and resolving such problems.

## How do I monitor my Azure environment?

You can use the following tool for monitoring your Azure environment:

-	**Azure Monitor** - the Azure service that operates as a consolidated pipeline for all monitoring data from Azure services. It gives you access to performance metrics and events that describe the operation of the Azure infrastructure and any Azure services you are using. Azure Monitor is a monitoring data pipeline for your Azure environment, and offers that data directly into Log Analytics as well as 3rd party tools where you can gain insight into that data and combine it with data from on premises or other cloud resources.

## Accessing monitoring in the Azure portal
All Azure monitoring services are now available in a single UI pane. For more information on how to access this area, see [Get started with Azure Monitor](monitoring-get-started.md). 

You can also access monitoring functions for specific resources by highlighting those resources and drilling down into their monitoring options. 


## Next steps
Learn more about

* [Getting Started with Azure Monitor](monitoring-get-started.md)
* [Azure Diagnostics](../azure-diagnostics.md) if you are attempting to diagnose problems in your Cloud Service, Virtual Machine, Virtual machine scale set, or Service Fabric application.
