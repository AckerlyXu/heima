---
title: Azure CLI Script Sample - Remove application from a cluster
description: Azure CLI Script Sample - Remove an application from a Service Fabric cluster.
services: service-fabric
documentationcenter: 
author: rockboyfor
manager: digimobile
editor: 
tags: azure-service-management

ms.assetid: 
ms.service: service-fabric
ms.workload: multiple
ms.devlang: na
ms.topic: article
origin.date: 07/21/2017
ms.date: 09/11/2017
ms.author: v-yeche
ms.custom: mvc
---

# Remove an application from a Service Fabric cluster

This sample script deletes a running Service Fabric application instance, unregisters an application type and version from the cluster.  Deleting the application instance also deletes all the running service instances associated with that application. Next, the application files are deleted from the image store. 

If needed, install the [Azure CLI](../service-fabric-azure-cli-2-0.md).

## Sample script

```sh
﻿#!/bin/bash

# Select cluster
sfctl cluster select \
    --endpoint http://svcfab1.chinanorth2.cloudapp.chinacloudapi.cn:19080

# Delete the application
sfctl application delete \
    --application-id svcfab_app \
    --timeout 500

# Unprovision the application type
sfctl application unprovision \
    --application-type-name svcfab_appType \
    --application-type-version 1.0.0 \
    --timeout 500

# Delete the application files from the image store
sfctl store delete \
    --content-path myappfolder
```

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [sf cluster select](https://docs.microsoft.com/cli/azure/sf/cluster#select) | Selects the cluster to work with. |
| [sf application delete](https://docs.microsoft.com/cli/azure/sf/application#delete) | Deletes the application instance from the cluster. |
| [sf application unprovision](https://docs.microsoft.com/cli/azure/sf/application#unprovision) | Unregisters a Service Fabric application type and version from the cluster.|
| [sf application package-delete](https://docs.microsoft.com/cli/azure/sf/application#package-delete) | Removes a Service Fabric application package from the image store. |

## Next steps

For more information, see the [Azure CLI documentation](../service-fabric-azure-cli-2-0.md).

Additional Azure CLI samples for Azure Service Fabric can be found in the [Azure CLI samples](../samples-cli.md).

<!--Update_Description: new articles of remove application with CLI in service fabric -->