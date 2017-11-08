---
title: Service Fabric CLI Script Sample - List applications on a cluster
description: Service Fabric CLI Script Sample - List the applications provisioned on a Service Fabric cluster.
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
origin.date: 09/19/2017
ms.date: 11/13/2017
ms.author: v-yeche
ms.custom: 
---

# Add an application certificate to a Service Fabric cluster

This sample script connects to a Service Fabric cluster and lists all of the provisioned applications.

[!INCLUDE [links to azure cli and service fabric cli](../../../includes/service-fabric-sfctl.md)]

## Sample script

```sh
#!/bin/bash

# Select cluster
sfctl cluster select \
    --endpoint http://svcfab1.chinanorth2.cloudapp.chinacloudapi.cn:19080

# Retrieve all applications from the cluster
sfctl application list
```

## Next steps

For more information, see the [Service Fabric CLI documentation](../service-fabric-cli.md).

Additional Service Fabric CLI samples for Azure Service Fabric can be found in the [Service Fabric CLI samples](../samples-cli.md).
<!--Update_Description: new articles on list application with sfctl-->