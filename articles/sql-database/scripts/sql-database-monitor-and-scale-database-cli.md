---
title: CLI example-monitor-scale-single Azure SQL database | Azure
description: Azure CLI example script to monitor and scale a single Azure SQL database
services: sql-database
documentationcenter: sql-database
author: forester123
manager: digimobile
editor: carlrab
tags: azure-service-management

ms.assetid:
ms.service: sql-database
ms.custom: monitor & tune
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: sql-database
ms.workload: database
origin.date: 06/23/2017
ms.date: 11/06/2017
ms.author: v-johch
---

# Use CLI to monitor and scale a single SQL database

This Azure CLI script example scales a single Azure SQL database to a different performance level after querying the size information of the database. 

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

If you choose to install and use the CLI locally, this article requires that you are running the Azure CLI version 2.0 or later. Run `az --version` to find the version. If you need to install or upgrade, see [Install Azure CLI 2.0]( https://docs.azure.cn/cli/install-azure-cli). 

## Sample script

```azurecli
#!/bin/bash

# Set an admin login and password for your database
adminlogin=ServerAdmin
password=ChangeYourAdminPassword1
# the logical server name has to be unique in the system
servername=server-$RANDOM

# Create a resource group
az group create \
	--name myResourceGroup \
	-location "China East" 

# Create a server
az sql server create \
	--name $servername \
	--resource-group myResourceGroup \
	--location "China East" \
	--admin-user $adminlogin \
	--admin-password $password

# Create a database
az sql db create \
	--resource-group myResourceGroup \
	--server $servername \
	--name mySampleDatabase \
	--service-objective S0

# Monitor database size
az sql db list-usages \
	--name mySampleDatabase \
	--resource-group myResourceGroup \
	--name $servername

# Scale up database to S1 performance level (create command executes update if DB already exists)
az sql db create \
	--resource-group myResourceGroup \
	--server $servername \
	--name mySampleDatabase \
	--service-objective S1
```

## Clean up deployment

After the script sample has been run, the following command can be used to remove the resource group and all resources associated with it.

```azurecli
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.azure.cn/cli/group#az_group_create) | Creates a resource group in which all resources are stored. |
| [az sql server create](https://docs.azure.cn/cli/sql/server#az_sql_server_create) | Creates a logical server that hosts a database. |
| [az sql db show-usage](https://docs.azure.cn/cli/sql/db#az_sql_db_show_usage) | Shows the size usage information for a database. |
| [az sql db update](https://docs.azure.cn/cli/sql/db#az_sql_db_update) | Updates database properties (such as the service tier or performance level) or moves a database into, out of, or between elastic pools. |
| [az group delete](https://docs.azure.cn/cli/vm/extension#az_vm_extension_set) | Deletes a resource group including all nested resources. |
|||

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/cli/overview).

Additional SQL Database CLI script samples can be found in the [Azure SQL Database documentation](../sql-database-cli-samples.md).

<!--Update_Description: update Global CLI 2.O links to Mooncake CLI 2.O links-->