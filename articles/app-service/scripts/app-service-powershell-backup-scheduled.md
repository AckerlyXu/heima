---
title: Azure PowerShell Script Sample - Create a scheduled backup for a web app | Microsoft Docs
description: Azure PowerShell Script Sample - Create a scheduled backup for a web app
services: app-service\web
documentationcenter: 
author: cephalin
manager: cfowler
editor: 
tags: azure-service-management

ms.assetid: a2a27d94-d378-4c17-a6a9-ae1e69dc4a72
ms.service: app-service-web
ms.workload: web
ms.devlang: na
ms.topic: sample
origin.date: 10/30/2017
ms.author: v-yiso
ms.custom: mvc
ms.date: 01/02/2018
---

# Create a scheduled backup for a web app

This sample script creates a web app in App Service with its related resources, and then creates a scheduled backup for it. 

If needed, install the Azure PowerShell using the instruction found in the [Azure PowerShell guide](https://docs.microsoft.com/en-us/powershell/azure/overview), and then run `Login-AzureRmAccount` to create a connection with Azure. 

## Sample script

```powershell
$webappname="mywebapp$(Get-Random -Minimum 100000 -Maximum 999999)"
$storagename="$($webappname)storage"
$container="appbackup"
$location="China East"

# Create a resource group.
New-AzureRmResourceGroup -Name myResourceGroup -Location $location

# Create a storage account.
$storage = New-AzureRmStorageAccount -ResourceGroupName myResourceGroup `
-Name $storagename -SkuName Standard_LRS -Location $location

# Create a storage container.
New-AzureStorageContainer -Name $container -Context $storage.Context

# Generates an SAS token for the storage container, valid for 1 year.
# NOTE: You can use the same SAS token to make backups in Web Apps until -ExpiryTime
$sasUrl = New-AzureStorageContainerSASToken -Name $container -Permission rwdl `
-Context $storage.Context -ExpiryTime (Get-Date).AddYears(1) -FullUri

# Create an App Service plan in Standard tier. Standard tier allows one backup per day.
New-AzureRmAppServicePlan -ResourceGroupName myResourceGroup -Name $webappname `
-Location $location -Tier Standard

# Create a web app.
New-AzureRmWebApp -ResourceGroupName myResourceGroup -Name $webappname `
-Location $location -AppServicePlan $webappname

# Schedule a backup every day, beginning in one hour, and retain for 10 days
Edit-AzureRmWebAppBackupConfiguration -ResourceGroupName myResourceGroup -Name $webappname `
-StorageAccountUrl $sasUrl -FrequencyInterval 1 -FrequencyUnit Day -KeepAtLeastOneBackup `
-StartTime (Get-Date).AddHours(1) -RetentionPeriodInDays 10

# List statuses of all backups that are complete or currently executing.
Get-AzureRmWebAppBackupList -ResourceGroupName myResourceGroup -Name $webappname

# (OPTIONAL) Change the backup schedule to every 2 days
$configuration = Get-AzureRmWebAppBackupConfiguration -ResourceGroupName myResourceGroup `
-Name $webappname
$configuration.FrequencyInterval = 2
$configuration | Edit-AzureRmWebAppBackupConfiguration
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
| [New-AzureRmResourceGroup](https://docs.microsoft.com/en-us/powershell/module/azurerm.resources/new-azurermresourcegroup) | Creates a resource group in which all resources are stored. |
| [New-AzureRmStorageAccount](https://docs.microsoft.com/en-us/powershell/module/azurerm.storage/new-azurermstorageaccount) | Creates a Storage account. |
| [New-AzureStorageContainer](https://docs.microsoft.com/en-us/powershell/module/azure.storage/new-azurestoragecontainer) | Creates an Azure storage container. |
| [New-AzureStorageContainerSASToken](https://docs.microsoft.com/en-us/powershell/module/azure.storage/new-azurestoragecontainersastoken) | Generates an SAS token for an Azure storage container. |
| [New-AzureRmAppServicePlan](https://docs.microsoft.com/en-us/powershell/module/azurerm.websites/new-azurermappserviceplan) | Creates an App Service plan. |
| [New-AzureRmWebApp](https://docs.microsoft.com/en-us/powershell/module/azurerm.websites/new-azurermwebapp) | Creates a web app. |
| [Edit-AzureRmWebAppBackupConfiguration](https://docs.microsoft.com/en-us/powershell/module/azurerm.websites/edit-azurermwebappbackupconfiguration) | Edits the backup configuration for web app. |
| [Get-AzureRmWebAppBackupList](https://docs.microsoft.com/en-us/powershell/module/azurerm.websites/get-azurermwebappbackuplist) | Gets a list of backups for a web app. |
| [Get-AzureRmWebAppBackupConfiguration](https://docs.microsoft.com/en-us/powershell/module/azurerm.websites/get-azurermwebappbackupconfiguration) | Gets the backup configuration for web app. |

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/en-us/powershell/azure/overview).

Additional Azure Powershell samples for Azure App Service Web Apps can be found in the [Azure PowerShell samples](../app-service-powershell-samples.md).
