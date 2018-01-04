---
title: Service Fabric CLI Script Sample - Update an application on a cluster
description: Service Fabric CLI Script Sample - Update an application with a new version. This example also upgrades a deployed application with the new bits.
services: service-fabric
documentationcenter: 
author: rockboyfor
manager: digimobile
editor: 
tags: 

ms.assetid: 
ms.service: service-fabric
ms.workload: multiple
ms.devlang: na
ms.topic: article
origin.date: 12/06/2017
ms.date: 01/01/2018
ms.author: v-yeche
ms.custom: 
---

# Add an application certificate to a Service Fabric cluster

This sample script uploads a new version of an existing application, and then upgrades a deployed application with the new bits.

[!INCLUDE [links to azure cli and service fabric cli](../../../includes/service-fabric-sfctl.md)]

## Sample script

```sh
#!/bin/bash

# Select cluster
sfctl cluster select \
    --endpoint http://svcfab1.chinanorth.cloudapp.chinacloudapi.cn:19080

# Upload the latest bits of an application
sfctl application upload --path ~/app_package_dir_2

# Provision the new application
sfctl application provision --application-type-build-path app_package_dir_2

# Upgrade an existing up with the new version
sfctl application upgrade --app-id TestApp --app-version 2.0.0 --parameters "{\"test\":\"value\"}" --mode Monitored
```

## Next steps

For more information, see the [Service Fabric CLI documentation](../service-fabric-cli.md).

Additional Service Fabric CLI samples for Azure Service Fabric can be found in the [Service Fabric CLI samples](../samples-cli.md).
<!--Update_Description: update meta properties, wording update -->