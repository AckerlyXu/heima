---
title: Azure Functions scale and hosting | Microsoft Docs
description: choose Azure Functions App Service plan.
services: functions
documentationcenter: na
author: ggailey777
manager: cfowler
editor: ''
tags: ''
keywords: azure functions, functions,  app service plan, event processing, webhooks, dynamic compute, serverless architecture

ms.assetid: 5b63649c-ec7f-4564-b168-e0a74cb7e0f3
ms.service: functions
ms.devlang: multiple
ms.topic: reference
ms.tgt_pltfrm: multiple
ms.workload: na
origin.date: 12/12/2017
ms.date: 04/18/2018
ms.author: v-junlch

ms.custom: H1Hack27Feb2017

---
# Azure Functions scale and hosting

You can run Azure Functions in Azure App Service plan. For details about how the App Service plan works, see the [Azure App Service plans in-depth overview](../app-service/azure-web-sites-web-hosting-plans-in-depth-overview.md). 


If you aren't familiar with Azure Functions, see the [Azure Functions overview](functions-overview.md).

When you create a function app, you must configure a hosting plan for functions that the app contains. In either mode, an instance of the *Azure Functions host* executes the functions. The type of plan controls:

- How host instances are scaled out.
- The resources that are available to each host.

Currently, you must choose the type of hosting plan during the creation of the function app. You can't change it afterward. 

On an App Service plan you can scale between tiers to allocate different amount of resources. 

## App Service plan

In the App Service plan, your function apps run on dedicated VMs on Basic, Standard, Premium, and Isolated SKUs, similar to Web Apps, API Apps, and Mobile Apps. Dedicated VMs are allocated to your App Service apps, which means the functions host is always running. App Service plans support Linux.

Consider an App Service plan in the following cases:
- You have existing, underutilized VMs that are already running other App Service instances.
- You expect your function apps to run continuously, or nearly continuously. In this case, an App Service Plan can be more cost-effective.
- You require features that are only available on an App Service plan, such as support for App Service Environment, VNET/VPN connectivity, and larger VM sizes. 
- You want to run your function app on Linux, or you want to provide a custom image on which to run your functions.

A VM decouples cost from number of executions, execution time, and memory used. As a result, you won't pay more than the cost of the VM instance that you allocate. For details about how the App Service plan works, see the [Azure App Service plans in-depth overview](../app-service/azure-web-sites-web-hosting-plans-in-depth-overview.md). 

With an App Service plan, you can manually scale out by adding more VM instances, or you can enable autoscale. For more information, see [Scale instance count manually or automatically](../monitoring-and-diagnostics/insights-how-to-scale.md?toc=%2fazure%2fapp-service-web%2ftoc.json). You can also scale up by choosing a different App Service plan. For more information, see [Scale up an app in Azure](../app-service/web-sites-scale.md). 

If you are planning to run JavaScript functions on an App Service plan, you should choose a plan that has fewer vCPUs. For more information, see the [Choose single-core App Service plans](functions-reference-node.md#considerations-for-javascript-functions).  

<!-- Note: the portal links to this section via fwlink https://go.microsoft.com/fwlink/?linkid=830855 --> 
<a name="always-on"></a>
### Always On

If you run on an App Service plan, you should enable the **Always On** setting so that your function app runs correctly. On an App Service plan, the functions runtime will go idle after a few minutes of inactivity, so only HTTP triggers will "wake up" your functions. This is similar to how WebJobs must have Always On enabled. 

## Storage account requirements

On an App Service plan, a function app requires a general Azure Storage account that supports Azure Blob, Queue, Files, and Table storage. Internally, Azure Functions uses Azure Storage for operations such as managing triggers and logging function executions. Some storage accounts do not support queues and tables, such as blob-only storage accounts (including premium storage) and general-purpose storage accounts with zone-redundant storage replication. These accounts are filtered from the **Storage Account** blade when you're creating a function app.

<!-- JH: Does using a PRemium Storage account improve perf? -->

To learn more about storage account types, see [Introducing the Azure Storage services](../storage/common/storage-introduction.md#azure-storage-services).

