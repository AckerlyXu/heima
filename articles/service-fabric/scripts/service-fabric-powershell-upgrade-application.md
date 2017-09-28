---
title: Azure PowerShell Script Sample - Upgrade a Service Fabric application | Azure
description: Azure PowerShell Script Sample - Upgrade a Service Fabric application.
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
origin.date: 08/23/2017
ms.date: 10/02/2017
ms.author: v-yeche
ms.custom: mvc
---

# Upgrade a Service Fabric application

This sample script upgrades a running Service Fabric application instance to version 1.3.0. The script copies the new application package to the cluster image store, registers the application type, starts a monitored upgrade, and continuously checks the upgrade status until the upgrade completes or rolls back. Customize the parameters as needed. 

If needed, install the Service Fabric PowerShell module with the [Service Fabric SDK](../service-fabric-get-started.md). 

## Sample script

```powershell
﻿## Variables
$ApplicationPackagePath = "C:\Users\sfuser\documents\visual studio 2017\Projects\Voting\Voting\pkg\Debug"
$ApplicationName = "fabric:/Voting"
$ApplicationTypeName = "VotingType"
$ApplicationTypeVersion = "1.3.0"
$imageStoreConnectionString = "fabric:ImageStore"
$CopyPackageTimeoutSec = 600
$CompressPackage = $false

## Check existence of the application
$oldApplication = Get-ServiceFabricApplication -ApplicationName $ApplicationName

if (!$oldApplication)
{
    $errMsg = "Application '$ApplicationName' doesn't exist in cluster."
    throw $errMsg
}
else
{
    ## Check upgrade status
    $upgradeStatus = Get-ServiceFabricApplicationUpgrade -ApplicationName $ApplicationName
    if ($upgradeStatus.UpgradeState -ne "RollingBackCompleted" -and $upgradeStatus.UpgradeState -ne "RollingForwardCompleted" -and $upgradeStatus.UpgradeState -ne "Failed")
    {
        $errMsg = "An upgrade for the application '$ApplicationTypeName' is already in progress."
        throw $errMsg
    }

    $reg = Get-ServiceFabricApplicationType -ApplicationTypeName $ApplicationTypeName | Where-Object  { $_.ApplicationTypeVersion -eq $ApplicationTypeVersion }
    if ($reg)
    {
        Write-Host 'Application Type '$ApplicationTypeName' and Version '$ApplicationTypeVersion' was already registered with Cluster, unregistering it...'
        $reg | Unregister-ServiceFabricApplicationType -Force
    }

    ## Copy application package to image store
    $applicationPackagePathInImageStore = $ApplicationTypeName
    Write-Host "Copying application package to image store..."
    Copy-ServiceFabricApplicationPackage -ApplicationPackagePath $ApplicationPackagePath -ImageStoreConnectionString $imageStoreConnectionString -ApplicationPackagePathInImageStore $applicationPackagePathInImageStore -TimeOutSec $CopyPackageTimeoutSec -CompressPackage:$CompressPackage 
    if(!$?)
    {
        throw "Copying of application package to image store failed. Cannot continue with registering the application."
    }

    ## Register application type
    Write-Host "Registering application type..."
    Register-ServiceFabricApplicationType -ApplicationPathInImageStore $applicationPackagePathInImageStore
    if(!$?)
    {
        throw "Registration of application type failed."
    }

    ## Start monitored application upgrade
    try
    {
        Write-Host "Start upgrading application..." 
        Start-ServiceFabricApplicationUpgrade -ApplicationName $ApplicationName -ApplicationTypeVersion $ApplicationTypeVersion -HealthCheckStableDurationSec 60 -UpgradeDomainTimeoutSec 1200 -UpgradeTimeout 3000 -FailureAction Rollback -Monitored
    }
    catch
    {
        Write-Host ("Error starting upgrade. " + $_)

        Write-Host "Unregister application type '$ApplicationTypeName' and version '$ApplicationTypeVersion' ..."
        Unregister-ServiceFabricApplicationType -ApplicationTypeName $ApplicationTypeName -ApplicationTypeVersion $ApplicationTypeVersion -Force
        throw
    }

    do
    {
        Write-Host "Waiting for upgrade..."
        Start-Sleep -Seconds 3
        $upgradeStatus = Get-ServiceFabricApplicationUpgrade -ApplicationName $ApplicationName
    } while ($upgradeStatus.UpgradeState -ne "RollingBackCompleted" -and $upgradeStatus.UpgradeState -ne "RollingForwardCompleted" -and $upgradeStatus.UpgradeState -ne "Failed")

    if($upgradeStatus.UpgradeState -eq "RollingForwardCompleted")
    {
        Write-Host "Upgrade completed successfully."
    }
    elseif($upgradeStatus.UpgradeState -eq "RollingBackCompleted")
    {
        Write-Error "Upgrade was Rolled back."
    }
    elseif($upgradeStatus.UpgradeState -eq "Failed")
    {
        Write-Error "Upgrade Failed."
    }
}
```

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [Get-ServiceFabricApplication](https://docs.microsoft.com/powershell/module/servicefabric/get-servicefabricapplication?view=azureservicefabricps) | Gets all the applications in the Service Fabric cluster or a specific application.  |
| [Get-ServiceFabricApplicationUpgrade](https://docs.microsoft.com/powershell/module/servicefabric/get-servicefabricapplicationupgrade?view=azureservicefabricps) | Gets the status of a Service Fabric application upgrade. |
| [Get-ServiceFabricApplicationType](https://docs.microsoft.com/powershell/module/servicefabric/get-servicefabricapplicationtype?view=azureservicefabricps) | Gets the Service Fabric application types registered on the Service Fabric cluster. |
| [Unregister-ServiceFabricApplicationType](https://docs.microsoft.com/powershell/module/servicefabric/unregister-servicefabricapplicationtype?view=azureservicefabricps) | Unregisters a Service Fabric application type.  |
| [Copy-ServiceFabricApplicationPackage](https://docs.microsoft.com/powershell/module/servicefabric/copy-servicefabricapplicationpackage?view=azureservicefabricps) | Copies a Service Fabric application package to the image store.  |
| [Register-ServiceFabricApplicationType](https://docs.microsoft.com/powershell/module/servicefabric/register-servicefabricapplicationtype?view=azureservicefabricps) | Registers a Service Fabric application type. |
| [Start-ServiceFabricApplicationUpgrade](https://docs.microsoft.com/powershell/module/servicefabric/start-servicefabricapplicationupgrade?view=azureservicefabricps) | Upgrades a Service Fabric application to the specified application type version. |

## Next steps

For more information on the Service Fabric PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/service-fabric/?view=azureservicefabricps).

Additional Powershell samples for Azure Service Fabric can be found in the [Azure PowerShell samples](../service-fabric-powershell-samples.md).

<!--Update_Description: new articles on upgrading application with powershell  -->