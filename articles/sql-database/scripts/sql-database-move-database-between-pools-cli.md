---
title: CLI example-move Azure SQL database-SQL elastic pool | Azure
description: Azure CLI example script to move a SQL database in a SQL elastic pool 
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
origin.date: 07/05/2017
ms.date: 2/28/2018
ms.author: v-johch
---

# Use CLI to move an Azure SQL database in a SQL elastic pool

This Azure CLI script example creates two elastic pools and moves an Azure SQL database from one SQL elastic pool into another SQL elastic pool, and then moves the database out of elastic pool to a single Azure database performance level. 

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

If you choose to install and use the CLI locally, this topic requires that you are running the Azure CLI version 2.0 or later. Run `az --version` to find the version. If you need to install or upgrade, see [Install Azure CLI 2.0]( https://docs.azure.cn/cli/install-azure-cli). 

## Sample script

```azurecli
#!/bin/bash

# Set an admin login and password for your database
adminlogin=ServerAdmin
password=ChangeYourAdminPassword1
# The logical server name has to be unique in the system
export servername=server-$RANDOM

# Create a resource group
az group create \
	--name myResourceGroup \
	--location "China East" 

# Create a logical server in the resource group
az sql server create \
	--name $servername \
	--resource-group myResourceGroup \
	--location "China East" \
	--admin-user $adminlogin \
	--admin-password $password

# Create two pools in the logical server
az sql elastic-pools create \
	--resource-group myResourceGroup \
	--location "China East"  \
	--server $servername \
	--name myFirstPool \
	--dtu 50 \
	--database-dtu-max 20
az sql elastic-pools create \
	--resource-group myResourceGroup \
	--location "China East"  \
	--server $servername \
	--name MySecondPool \
	--dtu 50 \
	--database-dtu-max 50

# Create a database in the first pool
az sql db create \
	--resource-group myResourceGroup \
	--server $servername \
	--name mySampleDatabase \
	--elastic-pool-name myFirstPool

# Move the database to the second pool - create command updates the db if it exists
az sql db create \
	--resource-group myResourceGroup \
	--server-name $servername \
	--name mySampleDatabase \
	--elastic-pool-name mySecondPool

# Move the database to standalone S1 performance level
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
| [az sql server create](https://docs.azure.cn/cli/sql/server#az_sql_server_create) | Creates a logical server that hosts a database or elastic pool. |
| [az sql elastic-pools create](https://docs.azure.cn/cli/sql/elastic-pool#az_sql_elastic_pool_create) | Creates an elastic pool within the logical server. |
| [az sql db create](https://docs.azure.cn/cli/sql/db#az_sql_db_create) | Creates a database in a logical server as a single or a pooled database. |
| [az sql db update](https://docs.azure.cn/cli/sql/db#az_sql_db_update) | Updates database properties or moves a database into, out of, or between elastic pools. |
| [az group delete](https://docs.azure.cn/cli/vm/extension#az_vm_extension_set) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/cli/overview).

Additional SQL Database CLI script samples can be found in the [Azure SQL Database documentation](../sql-database-cli-samples.md).

<!--Update_Description: update Global CLI 2.O links to Mooncake CLI 2.O links-->