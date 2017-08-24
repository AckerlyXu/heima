---
title: Azure Monitor CLI 1.0 quick start samples. | Microsoft Docs
description: Sample CLI 1.0 commands for Azure Monitor features. Azure Monitor is a Microsoft Azure service which allows you to send alert notifications, call web URLs based on values of configured telemetry data, and autoScale Cloud Services, Virtual Machines, and Web Apps.
author: kamathashwin
manager: orenr
editor: ''
services: monitoring-and-diagnostics
documentationcenter: monitoring-and-diagnostics

ms.assetid: 1653aa81-0ee6-4622-9c65-d4801ed9006f
ms.service: monitoring-and-diagnostics
ms.workload: na
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 08/09/2017
ms.author: v-yiso
ms.date: 09/04/2017
---
# Azure Monitor  Cross-platform CLI 1.0 quick start samples
This article shows you sample command-line interface (CLI) commands to help you access Azure Monitor features. Azure Monitor allows you to AutoScale Cloud Services, Virtual Machines, and Web Apps and to send alert notifications or call web URLs based on values of configured telemetry data.

> [!NOTE]
> Azure Monitor is the new name for what was called "Azure Insights" until Sept 25th, 2016. However, the namespaces and thus the commands below still contain the "insights".
> 
> 

## Prerequisites

If you haven't already installed the Azure CLI, see [Install the Azure CLI](../cli-install-nodejs.md). If you're unfamiliar with Azure CLI, you can read more about it at [Use the Azure CLI for Mac, Linux, and Windows with Azure Resource Manager](../azure-resource-manager/xplat-cli-azure-resource-manager.md).

In Windows, install npm from the [Node.js website](https://nodejs.org/). After you complete the installation, using CMD.exe with Run As Administrator privileges, execute the following from the folder where npm is installed:

```console
npm install azure-cli --global
```

Next, navigate to any folder/location you want and type at the command-line:

```console
azure help
```

## Log in to Azure
The first step is to login to your Azure account.

```console
azure login
```

After running this command, you have to sign in via the instructions on the screen. Afterward, you see your Account, TenantId, and default Subscription Id. All commands work in the context of your default subscription.

To list the details of your current subscription, use the following command.

```console
azure account show
```

To change working context to a different subscription, use the following command.

```console
azure account set "subscription ID or subscription name"
```

To use Azure Resource Manager and Azure Monitor commands, you need to be in Azure Resource Manager mode.

```console
azure config mode arm
```

To view a list of all supported Azure Monitor commands, perform the following.

```console
azure insights
```

## View activity log for a subscription
To view a list of activity log events, perform the following.

```console
azure insights logs list [options]
```

Try the following to view all available options.

```console
azure insights logs list -help
```

Here is an example to list logs by a resourceGroup

```console
azure insights logs list --resourceGroup "myrg1"
```

Example to list logs by caller

```console
azure insights logs list --caller "myname@company.com"
```

Example to list logs by caller on a resource type, within a start and end date

```console
azure insights logs list --resourceProvider "Microsoft.Web" --caller "myname@company.com" --startTime 2016-03-08T00:00:00Z --endTime 2016-03-16T00:00:00Z
```


## Log profiles
Use the information in this section to work with log profiles.

### Get a log profile
```console
azure insights logprofile list
azure insights logprofile get -n default
```


### Add a log profile without retention
```console
azure insights logprofile add --name default --storageId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/insights-integration/providers/Microsoft.Storage/storageAccounts/insightsintegration7777 --locations global,westus,eastus,northeurope,westeurope,eastasia,southeastasia,japaneast,japanwest,northcentralus,southcentralus,eastus2,centralus,australiaeast,australiasoutheast,brazilsouth,centralindia,southindia,westindia
```

### Remove a log profile
```console
azure insights logprofile delete --name default
```

### Add a log profile with retention
```console
azure insights logprofile add --name default --storageId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/insights-integration/providers/Microsoft.Storage/storageAccounts/insightsintegration7777 --locations global,westus,eastus,northeurope,westeurope,eastasia,southeastasia,japaneast,japanwest,northcentralus,southcentralus,eastus2,centralus,australiaeast,australiasoutheast,brazilsouth,centralindia,southindia,westindia --retentionInDays 90
```

### Add a log profile with retention and EventHub
```console
azure insights logprofile add --name default --storageId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/insights-integration/providers/Microsoft.Storage/storageAccounts/insightsintegration7777 --serviceBusRuleId /subscriptions/1a66ce04-b633-4a0b-b2bc-a912ec8986a6/resourceGroups/Default-ServiceBus-EastUS/providers/Microsoft.ServiceBus/namespaces/testshoeboxeastus/authorizationrules/RootManageSharedAccessKey --locations global,westus,eastus,northeurope,westeurope,eastasia,southeastasia,japaneast,japanwest,northcentralus,southcentralus,eastus2,centralus,australiaeast,australiasoutheast,brazilsouth,centralindia,southindia,westindia --retentionInDays 90
```


