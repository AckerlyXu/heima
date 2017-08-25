---
title: Azure Monitor PowerShell quick start samples. | Microsoft Docs
description: Use PowerShell to access Azure Monitor features such as autoscale, alerts, webhooks and searching Activity logs.
author: kamathashwin
manager: orenr
editor: ''
services: monitoring-and-diagnostics
documentationcenter: monitoring-and-diagnostics

ms.assetid: c0761814-7148-4ab5-8c27-a2c9fa4cfef5
ms.service: monitoring-and-diagnostics
ms.workload: na
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 08/09/2017
ms.author: v-yiso
ms.date: 09/04/2017
---

# Azure Monitor PowerShell quick start samples
This article shows you sample PowerShell commands to help you access Azure Monitor features. Azure Monitor allows you to AutoScale Cloud Services, Virtual Machines, and Web Apps and to send alert notifications or call web URLs based on values of configured telemetry data.

> [!NOTE]
> Azure Monitor is the new name for what was called "Azure Insights" until Sept 25th, 2016. However, the namespaces and thus the following commands still contain the "insights".
> 
> 

## Set up PowerShell
If you haven't already, set up PowerShell to run on your computer. For more information, see [How to Install and Configure PowerShell](../powershell-install-configure.md) .

## Examples in this article
The examples in the article illustrate how you can use Azure Monitor cmdlets. You can also review the entire list of Azure Monitor PowerShell cmdlets at [Azure Monitor (Insights) Cmdlets](https://msdn.microsoft.com/library/azure/mt282452#40v=azure.200#41.aspx).

## Sign in and use subscriptions
First, log into your Azure subscription.

```PowerShell
Login-AzureRmAccount
```

This requires you to sign in. Once you do, your Account, TenantId and default Subscription Id are displayed. All the Azure cmdlets work in the context of your default subscription. To view the list of subscriptions you have access to, use the following command.

```PowerShell
Get-AzureRmSubscription
```

To change your working context to a different subscription, use the following command.

```PowerShell
Set-AzureRmContext -SubscriptionId <subscriptionid>
```


## Retrieve Activity log for a subscription
Use the `Get-AzureRmLog` cmdlet.  The following are some common examples.

Get log entries from this time/date to present:

```PowerShell
Get-AzureRmLog -StartTime 2016-03-01T10:30
```

Get log entries between a time/date range:

```PowerShell
Get-AzureRmLog -StartTime 2015-01-01T10:30 -EndTime 2015-01-01T11:30
```

Get log entries from a specific resource group:

```PowerShell
Get-AzureRmLog -ResourceGroup 'myrg1'
```

Get log entries from a specific resource provider between a time/date range:

```PowerShell
Get-AzureRmLog -ResourceProvider 'Microsoft.Web' -StartTime 2015-01-01T10:30 -EndTime 2015-01-01T11:30
```

Get all log entries with a specific caller:

```PowerShell
Get-AzureRmLog -Caller 'myname@company.com'
```

The following command retrieves the last 1000 events from the activity log:

```PowerShell
Get-AzureRmLog -MaxEvents 1000
```

`Get-AzureRmLog` supports many other parameters. See the `Get-AzureRmLog` reference for more information.

> [!NOTE]
> `Get-AzureRmLog` only provides 15 days of history. Using the **-MaxEvents** parameter allows you to query the last N events, beyond 15 days. To access events older than 15 days, use the REST API or SDK (C# sample using the SDK). If you do not include **StartTime**, then the default value is **EndTime** minus one hour. If you do not include **EndTime**, then the default value is current time. All times are in UTC.
> 
> 

