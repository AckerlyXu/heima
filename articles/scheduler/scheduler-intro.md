<properties
 pageTitle="What is Azure Scheduler? | Microsoft Azure"
 description="Azure Scheduler allows you to declaratively describe actions to run in the cloud. It then schedules and runs those actions automatically."
 services="scheduler"
 documentationCenter=".NET"
 authors="krisragh"
 manager="dwrede"
 editor=""/>
<tags
 ms.service="scheduler"
 ms.workload="infrastructure-services"
 ms.tgt_pltfrm="na"
 ms.devlang="dotnet"
 ms.topic="hero-article"
 ms.date="08/18/2016"
 wacn.date=""
 ms.author="krisragh"/>

# What is Azure Scheduler?

Azure Scheduler allows you to declaratively describe actions to run in the cloud. It then schedules and runs those actions automatically.  Scheduler does this by using [the Azure portal](/documentation/articles/scheduler-get-started-portal/), code, [REST API](https://msdn.microsoft.com/zh-cn/library/mt629143.aspx), or Azure PowerShell.

Scheduler creates, maintains, and invokes scheduled work.  Scheduler does not host any workloads or run any code. It only _invokes_ code hosted elsewhere—in Azure, on-premises, or with another provider. It invokes via HTTP, HTTPS, a storage queue, a service bus queue, or a service bus topic.

Scheduler schedules [jobs](/documentation/articles/scheduler-concepts-terms/), keeps a history of job execution results that one can review, and deterministically and reliably schedules workloads to be run. Azure WebJobs (part of the Web Apps feature in Azure App Service) and other Azure scheduling capabilities use Scheduler in the background. The [Scheduler REST API](https://msdn.microsoft.com/zh-cn/library/mt629143.aspx) helps manage the communication for these actions. As such, Scheduler supports [complex schedules and advanced recurrence](/documentation/articles/scheduler-advanced-complexity/) easily.

There are several scenarios that lend themselves to the usage of Scheduler. For example:

+ _Recurring application actions:_ Periodically gathering data from Twitter into a feed.
+ _Daily maintenance:_ Daily pruning of logs, performing backups, and other maintenance tasks. For example, an administrator may choose to back up the database at 1:00 A.M. every day for the next nine months.

Scheduler allows you to create, update, delete, view, and manage jobs and [job collections ](/documentation/articles/scheduler-concepts-terms/) programmatically, by using scripts, and in the portal. 

## See also

 [Scheduler Concepts, Terminology, and Entity Hierarchy](/documentation/articles/scheduler-concepts-terms/)

 [Get Started Using Scheduler in the Management Portal](/documentation/articles/scheduler-get-started-portal/)

 [Plans and Billing in Azure Scheduler](/documentation/articles/scheduler-plans-billing/)

 [How to Build Complex Schedules and Advanced Recurrence with Azure Scheduler](/documentation/articles/scheduler-advanced-complexity/)

 [Azure Scheduler REST API reference](https://msdn.microsoft.com/zh-cn/library/mt629143)

 [Scheduler PowerShell Cmdlets Reference](/documentation/articles/scheduler-powershell-reference/)

 [Scheduler High-Availability and Reliability](/documentation/articles/scheduler-high-availability-reliability/)

 [Scheduler Limits, Defaults, and Error Codes](/documentation/articles/scheduler-limits-defaults-errors/)

 [Scheduler Outbound Authentication](/documentation/articles/scheduler-outbound-authentication/)
 
 