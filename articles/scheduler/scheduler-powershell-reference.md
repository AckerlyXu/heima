<properties
 pageTitle="Scheduler PowerShell Cmdlets Reference"
 description="Scheduler PowerShell Cmdlets Reference"
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
 ms.topic="article"
 ms.date="08/18/2016"
 wacn.date=""
 ms.author="krisragh"/>

# Scheduler PowerShell Cmdlets Reference

The following table describes and links to the reference page of each of the major cmdlets in Azure Scheduler.

To install Azure PowerShell and associate it with your Azure subscription, see [How to install and configure Azure PowerShell](/documentation/articles/powershell-install-configure/). 

For more information about [Azure Resource Manager cmdlets](https://msdn.microsoft.com/zh-cn/library/mt125356\(v=azure.200\).aspx), see [Using Azure PowerShell with Azure Resource Manager](/documentation/articles/powershell-azure-resource-manager/).

|Cmdlet|Cmdlet Description|
|---|---|
[Disable-AzureRmSchedulerJobCollection](https://msdn.microsoft.com/zh-cn/library/mt490133\(v=azure.200\).aspx) |Disables a job collection. 
[Enable-AzureRmSchedulerJobCollection](https://msdn.microsoft.com/zh-cn/library/mt490135\(v=azure.200\).aspx) |Enables a job collection.
[Get-AzureRmSchedulerJob](https://msdn.microsoft.com/zh-cn/library/mt490125\(v=azure.200\).aspx) |Gets Scheduler jobs.
[Get-AzureRmSchedulerJobCollection](https://msdn.microsoft.com/zh-cn/library/mt490132\(v=azure.200\).aspx) |Gets job collections.
[Get-AzureRmSchedulerJobHistory](https://msdn.microsoft.com/zh-cn/library/mt490126\(v=azure.200\).aspx) |Gets job history.
[New-AzureRmSchedulerHttpJob](https://msdn.microsoft.com/zh-cn/library/mt490136\(v=azure.200\).aspx) |Creates an HTTP job.
[New-AzureRmSchedulerJobCollection](https://msdn.microsoft.com/zh-cn/library/mt490141\(v=azure.200\).aspx) |Creates a job collection.
[New-AzureRmSchedulerServiceBusQueueJob](https://msdn.microsoft.com/zh-cn/library/mt490134\(v=azure.200\).aspx) |Creates a service bus queue job.
[New-AzureRmSchedulerServiceBusTopicJob](https://msdn.microsoft.com/zh-cn/library/mt490142\(v=azure.200\).aspx) |Creates a service bus topic job.
[New-AzureRmSchedulerStorageQueueJob](https://msdn.microsoft.com/zh-cn/library/mt490127\(v=azure.200\).aspx) |Creates a storage queue job. 
[Remove-AzureRmSchedulerJob](https://msdn.microsoft.com/zh-cn/library/mt490140\(v=azure.200\).aspx) |Removes a Scheduler job.  
[Remove-AzureRmSchedulerJobCollection](https://msdn.microsoft.com/zh-cn/library/mt490131\(v=azure.200\).aspx) |Removes a job collection. 
[Set-AzureRmSchedulerHttpJob](https://msdn.microsoft.com/zh-cn/library/mt490130\(v=azure.200\).aspx) |Modifies a Scheduler HTTP job.
[Set-AzureRmSchedulerJobCollection](https://msdn.microsoft.com/zh-cn/library/mt490129\(v=azure.200\).aspx) |Modifies a job collection. 
[Set-AzureRmSchedulerServiceBusQueueJob](https://msdn.microsoft.com/zh-cn/library/mt490143\(v=azure.200\).aspx) |Modifies a service bus queue job.  
[Set-AzureRmSchedulerServiceBusTopicJob](https://msdn.microsoft.com/zh-cn/library/mt490137\(v=azure.200\).aspx) |Modifies a service bus topic job. 
[Set-AzureRmSchedulerStorageQueueJob](https://msdn.microsoft.com/zh-cn/library/mt490128\(v=azure.200\).aspx) |Modifies a storage queue job.   

For more detailed information, you can run any of the following cmdlets: 


	Get-Help <cmdlet name> -Detailed


	Get-Help <cmdlet name> -Examples


	Get-Help <cmdlet name> -Full


## See Also


 [What is Scheduler?](/documentation/articles/scheduler-intro/)
 
 [Azure Scheduler Concepts, Terminology, and Entity Hierarchy](/documentation/articles/scheduler-concepts-terms/)
 
 [Get Started Using Scheduler in the Management Portal](/documentation/articles/scheduler-get-started-portal/)
 
 [Plans and Billing in Azure Scheduler](/documentation/articles/scheduler-plans-billing/)
 
 [Azure Scheduler REST API reference](https://msdn.microsoft.com/zh-cn/library/mt629143)
 
 [Azure Scheduler High-Availability and Reliability](/documentation/articles/scheduler-high-availability-reliability/)
 [Azure Scheduler limits, defaults, and error codes](/documentation/articles/scheduler-limits-defaults-errors/)

 [Azure Scheduler outbound authentication](/documentation/articles/scheduler-outbound-authentication/)
  
