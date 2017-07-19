---
title: Schedules in Azure Automation | Azure
description: Automation schedules are used to schedule runbooks in Azure Automation to start automatically. Describes how to create and manage a schedule in so that you can automatically start a runbook at a particular time or on a recurring schedule.
services: automation
documentationcenter: ''
author: MGoedtel
manager: jwhit
editor: tysonn

ms.assetid: 1c2da639-ad20-4848-920b-88e471b2e1d9
ms.service: automation
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: infrastructure-services
origin.date: 06/13/2017
ms.date: 07/10/2017
ms.author: v-dazen

---
# Scheduling a runbook in Azure Automation
To schedule a runbook in Azure Automation to start at a specified time, you link it to one or more schedules. A schedule can be configured to either run once or on a reoccurring hourly or daily schedule for runbooks in the Azure Classic Management Portal,  you can also schedule them for weekly, monthly, specific days of the week or days of the month, or a particular day of the month.  A runbook can be linked to multiple schedules, and a schedule can have multiple runbooks linked to it.

## Windows PowerShell Cmdlets
The cmdlets in the following table are used to create and manage schedules with Windows PowerShell in Azure Automation. They ship as part of the [Azure PowerShell module](https://docs.microsoft.com/powershell/azureps-cmdlets-docs).

| Cmdlets | Description |
|:--- |:--- |
| **Azure Service Management cmdlets** | |
| [Get-AzureAutomationSchedule](http://msdn.microsoft.com/library/dn690274.aspx) |Retrieves a schedule. |
| [New-AzureAutomationSchedule](http://msdn.microsoft.com/library/dn690271.aspx) |Creates a new schedule. |
| [Remove-AzureAutomationSchedule](http://msdn.microsoft.com/library/dn690279.aspx) |Removes a schedule. |
| [Set-AzureAutomationSchedule](http://msdn.microsoft.com/library/dn690270.aspx) |Sets the properties for an existing schedule. |
| [Get-AzureAutomationScheduledRunbook](http://msdn.microsoft.com/library/dn913778.aspx) |Retrieves scheduled runbooks. |
| [Register-AzureAutomationScheduledRunbook](http://msdn.microsoft.com/library/dn690265.aspx) |Associates a runbook with a schedule. |
| [Unregister-AzureAutomationScheduledRunbook](http://msdn.microsoft.com/library/dn690273.aspx) |Dissociates a runbook from a schedule. |

## Creating a schedule
You can create a new schedule for runbooks in the Classic Management Portal, or with Windows PowerShell. You also have the option of creating a new schedule when you link a runbook to a schedule using the Azure Classic Management Portal.

> [!NOTE]
> Azure Automation will use the latest modules in your Automation account when a new scheduled job is run.  To avoid impacting your runbooks and the processes they automate, you should first test any runbooks that have linked schedules with an Automation account dedicated for testing.  This will validate your scheduled runbooks continue to work correctly and if not, you can further troubleshoot and apply any changes required before migrating the updated runbook version to production.  
> Your Automation account will not automatically get any new versions of modules. 
> 

### To create a new schedule in the Azure Classic Management Portal
1. In the Azure Classic Management Portal, select Automation and then select the name of an automation account.
2. Select the **Assets** tab.
3. At the bottom of the window, click **Add Setting**.
4. Click **Add Schedule**.
5. Type a **Name** and optionally a **Description** for the new schedule.your schedule will run **One Time**, **Hourly**, **Daily**, **Weekly**, or **Monthly**.
6. Specify a **Start Time** and other options depending on the type of schedule that you selected.

### To create a new schedule with Windows PowerShell
You can use the [New-AzureAutomationSchedule](http://msdn.microsoft.com/library/azure/dn690271.aspx) cmdlet to create a new schedule in Azure Automation for classic runbooks. You must specify the start time for the schedule and the frequency it should run.

The following sample commands show how to create a new schedule that runs each day at 3:30 PM starting on January 20, 2015 with an Azure Service Management cmdlet.

    $automationAccountName = "MyAutomationAccount"
    $scheduleName = "Sample-DailySchedule"
    New-AzureAutomationSchedule -AutomationAccountName $automationAccountName -Name `
    $scheduleName -StartTime "1/20/2016 15:30:00" -DayInterval 1

## Linking a schedule to a runbook
A runbook can be linked to multiple schedules, and a schedule can have multiple runbooks linked to it. If a runbook has parameters, then you can provide values for them. You must provide values for any mandatory parameters and may provide values for any optional parameters.  These values will be used each time the runbook is started by this schedule.  You can attach the same runbook to another schedule and specify different parameter values.

### To link a schedule to a runbook with the Azure Classic Management Portal
1. In the Azure Classic Management Portal, select **Automation** and then click the name of an automation account.
2. Select the **Runbooks** tab.
3. Click on the name of the runbook to schedule.
4. Click the **Schedule** tab.
5. If the runbook is not currently linked to a schedule, then you will be given the option to **Link to a New Schedule** or **Link to an Existing Schedule**.  If the runbook is currently linked to a schedule, click **Link** at the bottom of the window to access these options.
6. If the runbook has parameters, you will be prompted for their values.  

### To link a schedule to a runbook with Windows PowerShell
You can use the [Register-AzureAutomationScheduledRunbook](http://msdn.microsoft.com/library/azure/dn690265.aspx) to link a schedule to a classic runbook.  You can specify values for the runbook's parameters with the Parameters parameter. See [Starting a Runbook in Azure Automation](automation-starting-a-runbook.md) for more information on specifying parameter values.

The following sample commands show how to link a schedule using an Azure Service Management cmdlet with parameters.

    $automationAccountName = "MyAutomationAccount"
    $runbookName = "Test-Runbook"
    $scheduleName = "Sample-DailySchedule"
    $params = @{"FirstName"="Joe";"LastName"="Smith";"RepeatCount"=2;"Show"=$true}
    Register-AzureAutomationScheduledRunbook -AutomationAccountName $automationAccountName `
    -Name $runbookName -ScheduleName $scheduleName -Parameters $params

## Disabling a schedule
When you disable a schedule, any runbooks linked to it will no longer run on that schedule. You can manually disable a schedule or set an expiration time for schedules with a frequency when you create them. When the expiration time is reached, the schedule will be disabled.

### To disable a schedule from the Azure Classic Management Portal
You can disable a schedule in the Azure Classic Management Portal from the Schedule Details page for the schedule.

1. In the Azure Classic Management Portal, select Automation and then click the name of an automation account.
2. Select the Assets tab.
3. Click the name of a schedule to open its detail page.
4. Change **Enabled** to **No**.

### To disable a schedule with Windows PowerShell

You can use the [Set-AzureAutomationSchedule](http://msdn.microsoft.com/library/azure/dn690270.aspx) cmdlet to change the properties of an existing schedule for a classic runbook. To disable the schedule, specify **false** for the **IsEnabled** parameter.

The following sample commands show how to disable a schedule using the Azure Service Management cmdlet.

    $automationAccountName = "MyAutomationAccount"
    $scheduleName = "Sample-DailySchedule"
    Set-AzureAutomationSchedule -AutomationAccountName $automationAccountName `
    -Name $scheduleName -IsEnabled $false

## Next steps
* To get started with runbooks in Azure Automation, see [Starting a Runbook in Azure Automation](automation-starting-a-runbook.md)