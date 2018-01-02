---
title: Azure Service Fabric CLI Script Deploy Sample
description: Deploy an application to an Azure Service Fabric cluster using the Azure Service Fabric CLI
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

# Deploy an application to a Service Fabric cluster

This sample script copies an application package to a cluster image store, registers the application type in the cluster, and creates an application instance from the application type. Any default services are also created at this time.

If needed, install the [Service Fabric CLI](../service-fabric-cli.md).

## Sample script

```sh
﻿#!/bin/bash

# Select cluster
sfctl cluster select \
    --endpoint http://svcfab1.chinanorth.cloudapp.chinacloudapi.cn:19080

# Upload the application files to the image store
# (note the last folder name, Debug in this example)
sfctl application upload \
    --path  C:\Code\svcfab-vs\svcfab-vs\pkg\Debug \
    --show-progress

# Register the application (manifest files) from the image store
# (Note the last folder from the previous command is used: Debug)
sfctl application provision \
    --application-type-build-path Debug \
    --timeout 500

# Create an instance of the registered application and 
# auto deploy any defined services
sfctl application create \
    --app-name fabric:/MyApp \
    --app-type MyAppType \
    --app-version 1.0.0

```

## Clean up deployment

When done, the [remove](cli-remove-application.md) script can be used to remove the application. The remove script
deletes the application instance, unregisters the application type, and deletes the application package from the
image store.

## Next steps

For more information, see the [Service Fabric CLI documentation](../service-fabric-cli.md).

Additional Service Fabric CLI samples for Azure Service Fabric can be found in the [Service Fabric CLI samples](../samples-cli.md).

<!--Update_Description: update meta properties, update link -->