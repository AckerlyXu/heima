---
title: Azure Service Fabric CLI Script Remove Sample
description: Remove an application from an Azure Service Fabric cluster using the Azure Service Fabric CLI
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
ms.topic: sample
origin.date: 12/06/2017
ms.date: 01/01/2018
ms.author: v-yeche
ms.custom: mvc
---

# Remove an application from a Service Fabric cluster

This sample script deletes a running Service Fabric application instance, unregisters an application type and version from the cluster.  Deleting the application instance also deletes all the running service instances associated with that application. Next, the application files are deleted from the image store. 

If needed, install the [Service Fabric CLI](../service-fabric-cli.md).

## Sample script

```sh
﻿#!/bin/bash

# Select cluster
sfctl cluster select \
    --endpoint http://svcfab1.chinanorth.cloudapp.chinacloudapi.cn:19080

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

## Next steps

For more information, see the [Service Fabric CLI documentation](../service-fabric-cli.md).

Additional Service Fabric CLI samples for Azure Service Fabric can be found in the [Service Fabric CLI samples](../samples-cli.md).

<!--Update_Description: update meta properties, update link -->