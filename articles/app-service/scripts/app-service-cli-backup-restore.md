---
title: Azure CLI Script Sample - Restore a web app from a backup | Microsoft Docs
description: Azure CLI Script Sample - Restore a web app from a backup
services: app-service\web
documentationcenter: 
author: cephalin
manager: cfowler
editor: 
tags: azure-service-management

ms.service: app-service-web
ms.workload: web
ms.devlang: na
ms.topic: sample
origin.date: 12/07/2017
ms.date: 01/02/2017
ms.author: v-yiso
ms.custom: mvc
---

# Restore a web app from a backup

This sample script creates a web app in App Service with its related resources, and then creates a one-time backup for it. 

To run this script, you need an existing backup for a web app. To create one, see [Backup up a web app](app-service-cli-backup-onetime.md) or [Create a scheduled backup for a web app](app-service-cli-backup-scheduled.md).



If you choose to install and use the CLI locally, you need Azure CLI version 2.0 or later. To find the version, run `az --version`. If you need to install or upgrade, see [Install Azure CLI 2.0](https://docs.azure.cn/zh-cn/cli/install-azure-cli?view=azure-cli-lastest). 

## Sample script

```azurecli
#!/bin/bash

groupname="myResourceGroup"
webappname="<replace-with-your-app-name>"

# List statuses of all backups that are complete or currently executing.
az webapp config backup list --resource-group $groupname --webapp-name $webappname

# Note the backupItemName and storageAccountUrl properties of the backup you want to restore

# Restore the app by overwriting it with the backup data
# Be sure to replace <backupItemName> and <storageAccountUrl>
az webapp config backup restore --resource-group $groupname --webapp-name $webappname \
--backup-name <backupItemName> --container-url <storageAccountUrl> --overwrite
```

[!INCLUDE [cli-script-clean-up](../../../includes/cli-script-clean-up.md)]

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [`az webapp config backup list`](https://docs.azure.cn/zh-cn/cli/webapp/config/backup?view=azure-cli-latest#az_webapp_config_backup_list) | Gets a list of backups for a web app. |
| [`az webapp config backup restore`](https://docs.azure.cn/zh-cn/cli/webapp/config/backup?view=azure-cli-latest#az_webapp_config_backup_restore) | Restores a web app from a backup. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-lastest).

Additional App Service CLI script samples can be found in the [Azure App Service documentation](../app-service-cli-samples.md).
