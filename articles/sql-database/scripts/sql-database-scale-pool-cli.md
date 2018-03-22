---
title: CLI example scales a SQL elastic pool-Azure SQL Database | Azure
description: Azure CLI example script to scale a SQL elastic pool in Azure SQL Database
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

# Use CLI to scale a SQL elastic pool in Azure SQL Database

This Azure CLI script example creates SQL elastic pools, moves pooled databases, and changes elastic pool performance levels. 

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

If you choose to install and use the CLI locally, this topic requires that you are running the Azure CLI version 2.0 or later. Run `az --version` to find the version. If you need to install or upgrade, see [Install Azure CLI 2.0]( https://docs.azure.cn/cli/install-azure-cli). 

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
	--location "China East" 

# Create a server
az sql server create \
	--name $servername \
	--resource-group myResourceGroup \
	--location "China East" \
	--admin-user $adminlogin \
	--admin-password $password

# Create a pool
az sql elastic-pools create \
	--resource-group myResourceGroup \
	--location "China East"  \
	--server $servername \
	--name samplepool \
	--dtu 50 \
	--database-dtu-max 20

# Create two database in the pool
az sql db create \
	--resource-group myResourceGroup \
	--server $servername \
	--name myFirstSampleDatabase \
	--elastic-pool-name samplepool
az sql db create \
	--resource-group myResourceGroup \
	--server $servername \
	--name mySecondSampleDatabase \
	--elastic-pool-name samplepool

# Scale up to the pool to 100 eDTU
az sql elastic-pools update \
	--resource-group myResourceGroup \
	--server $servername \
	--name samplepool \
	--set dtu=100
```

## Clean up deployment

After the script sample has been run, the following command can be used to remove the resource group and all resources associated with it.

```azurecli
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands to create a resource group, logical server, SQL Database, and firewall rules. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.azure.cn/cli/group#az_group_create) | Creates a resource group in which all resources are stored. |
| [az sql server create](https://docs.azure.cn/cli/sql/server#az_sql_server_create) | Creates a logical server that hosts the SQL Database. |
| [az sql elastic-pools create](https://docs.azure.cn/cli/sql/elastic-pool#az_sql_elastic_pool_create) | Creates an elastic database pool within the logical server. |
| [az sql db create](https://docs.azure.cn/cli/sql/db#az_sql_db_create) | Creates the SQL Database in the logical server. |
| [az sql elastic-pools update](https://docs.azure.cn/cli/sql/elastic-pool#az_sql_elastic_pool_update) | Updates an elastic database pool, in this example changes the assigned eDTU. |
| [az group delete](https://docs.azure.cn/cli/vm/extension#az_vm_extension_set) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/cli/overview).

Additional SQL Database CLI script samples can be found in the [Azure SQL Database documentation](../sql-database-cli-samples.md).

<!--Update_Description: update Global CLI 2.O links to Mooncake CLI 2.O links-->