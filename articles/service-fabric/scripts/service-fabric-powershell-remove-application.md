---
title: Azure PowerShell Script Sample - Remove application from a cluster| Azure
description: Azure PowerShell Script Sample - Remove an application from a Service Fabric cluster.
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
origin.date: 01/18/2018
ms.date: 03/12/2018
ms.author: v-yeche
ms.custom: mvc
---

# Remove an application from a Service Fabric cluster

This sample script deletes a running Service Fabric application instance and unregisters an application type and version from the cluster.  Deleting the application instance also deletes all the running service instances associated with that application. Customize the parameters as needed. 

If needed, install the Service Fabric PowerShell module with the [Service Fabric SDK](../service-fabric-get-started.md). 

## Sample script

```powershell
﻿# Variables
$endpoint = 'mysftestcluster.chinaeast.cloudapp.chinacloudapi.cn:19000'
$thumbprint = '2779F0BB9A969FB88E04915FFE7955D0389DA7AF'
$packagepath="C:\Users\sfuser\Documents\Visual Studio 2017\Projects\MyApplication\MyApplication\pkg\Release"

# Connect to the cluster using a client certificate.
Connect-ServiceFabricCluster -ConnectionEndpoint $endpoint `
          -KeepAliveIntervalInSec 10 `
          -X509Credential -ServerCertThumbprint $thumbprint `
          -FindType FindByThumbprint -FindValue $thumbprint `
          -StoreLocation CurrentUser -StoreName My

# Remove an application instance
Remove-ServiceFabricApplication -ApplicationName fabric:/MyApplication

# Unregister the application type
Unregister-ServiceFabricApplicationType -ApplicationTypeName MyApplicationType -ApplicationTypeVersion 1.0.0

```

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [Remove-ServiceFabricApplication](https://docs.microsoft.com/powershell/module/servicefabric/remove-servicefabricapplication?view=azureservicefabricps) | Removes a running Service Fabric application instance from the cluster.  |
| [Unregister-ServiceFabricApplicationType](https://docs.microsoft.com/powershell/module/servicefabric/unregister-servicefabricapplicationtype?view=azureservicefabricps) | Unregisters a Service Fabric application type and version from the cluster. |

## Next steps

For more information on the Service Fabric PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/service-fabric/?view=azureservicefabricps).

Additional Powershell samples for Azure Service Fabric can be found in the [Azure PowerShell samples](../service-fabric-powershell-samples.md).
<!--Update_Description: update meta properties -->