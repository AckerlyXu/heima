---
title: Azure PowerShell Script Sample - Deploy application to a cluster| Azure
description: Azure PowerShell Script Sample - Deploy an application to a Service Fabric cluster.
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

# Deploy an application to a Service Fabric cluster

This sample script copies an application package to a cluster image store, registers the application type in the cluster, removes the unnecessary application package, and creates an application instance from the application type.  If any default services were defined in the application manifest of the target application type, then those services are created at this time. Customize the parameters as needed. 

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

# Copy the application package to the cluster image store.
Copy-ServiceFabricApplicationPackage $packagepath -ImageStoreConnectionString fabric:ImageStore -ApplicationPackagePathInImageStore MyApplication

# Register the application type.
Register-ServiceFabricApplicationType -ApplicationPathInImageStore MyApplication

# Remove the application package to free system resources.
Remove-ServiceFabricApplicationPackage -ImageStoreConnectionString fabric:ImageStore -ApplicationPackagePathInImageStore MyApplication

# Create the application instance.
New-ServiceFabricApplication -ApplicationName fabric:/MyApplication -ApplicationTypeName MyApplicationType -ApplicationTypeVersion 1.0.0
```

## Clean up deployment 

After the script sample has been run, the script in [Remove an application](service-fabric-powershell-remove-application.md) can be used to remove the application instance, unregister the application type, and delete the application package from the image store.

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
|[Connect-ServiceFabricCluster](https://docs.microsoft.com/powershell/module/servicefabric/connect-servicefabriccluster?view=azureservicefabricps)| Creates a connection to a Service Fabric cluster. |
|[Copy-ServiceFabricApplicationPackage](https://docs.microsoft.com/powershell/module/servicefabric/copy-servicefabricapplicationpackage?view=azureservicefabricps) | Copies an application package to the cluster image store.  |
|[Register-ServiceFabricApplicationType](https://docs.microsoft.com/powershell/module/servicefabric/register-servicefabricapplicationtype?view=azureservicefabricps)| Registers an application type and version on the cluster. |
|[New-ServiceFabricApplication](https://docs.microsoft.com/powershell/module/servicefabric/new-servicefabricapplication?view=azureservicefabricps)| Creates an application from a registered application type. |
| [Remove-ServiceFabricApplicationPackage](https://docs.microsoft.com/powershell/module/servicefabric/remove-servicefabricapplicationpackage?view=azureservicefabricps) | Removes a Service Fabric application package from the image store.|

## Next steps

For more information on the Service Fabric PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/service-fabric/?view=azureservicefabricps).

Additional Powershell samples for Azure Service Fabric can be found in the [Azure PowerShell samples](../service-fabric-powershell-samples.md).
<!--Update_Description: update meta properties -->