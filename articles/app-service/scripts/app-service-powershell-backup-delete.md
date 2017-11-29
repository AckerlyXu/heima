---
title: Azure PowerShell Script Sample - Delete a backup for a web app | Microsoft Docs
description: Azure PowerShell Script Sample - Delete a backup for a web app
services: app-service\web
documentationcenter: 
author: cephalin
manager: cfowler
editor: 
tags: azure-service-management

ms.assetid: ebcadb49-755d-4202-a5eb-f211827a9168
ms.service: app-service-web
ms.workload: web
ms.devlang: na
ms.topic: sample
origin.date: 10/30/2017
ms.author: v-yiso
ms.date: 12/04/2017
ms.custom: mvc
---

# Delete a backup for a web app

This sample script creates a web app in App Service with its related resources, and then creates a one-time backup for it. 

To run this script, you need an existing backup for a web app. To create one, see [Backup up a web app](app-service-powershell-backup-onetime.md) or [Create a scheduled backup for a web app](app-service-powershell-backup-scheduled.md).

## Sample script

```powershell
$resourceGroupName = "myResourceGroup"
$webappname = "<replace-with-your-app-name>"

# List statuses of all backups that are complete or currently executing.
Get-AzureRmWebAppBackupList -ResourceGroupName $resourceGroupName -Name $webappname

# Note the BackupID property of the backup you want to delete

# Delete the backup by specifying the BackupID
Remove-AzureRmWebAppBackup -ResourceGroupName $resourceGroupName -Name $webappname `
-BackupId <replace-with-BackupID>
```

## Clean up deployment 

After the script sample has been run, the following command can be used to remove the resource group, web app, and all related resources.

```powershell
Remove-AzureRmResourceGroup -Name myResourceGroup -Force
```

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [Get-AzureRmWebAppBackupList](https://docs.microsoft.com/en-us/powershell/module/azurerm.websites/get-azurermwebappbackuplist) | Gets a list of backups for a web app. |
| [Remove-AzureRmWebAppBackup](https://docs.microsoft.com/en-us/powershell/module/azurerm.websites/remove-azurermwebappbackup) | Removes the specified backup of a web app. |

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/en-us/powershell/azure/overview).

Additional Azure Powershell samples for Azure App Service Web Apps can be found in the [Azure PowerShell samples](../app-service-powershell-samples.md).
