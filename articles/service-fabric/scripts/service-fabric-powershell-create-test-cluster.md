---
title: Azure PowerShell Script Sample - Create a Service Fabric cluster | Azure
description: Azure PowerShell Script Sample - Create a three-node test Service Fabric cluster.
services: service-fabric
documentationcenter: 
author: rockboyfor
manager: digimobile
editor: 
tags: azure-service-management

ms.assetid: 0f9c8bc5-3789-4eb3-8deb-ae6e2200795a
ms.service: service-fabric
ms.workload: multiple
ms.devlang: na
ms.topic: sample
origin.date: 03/19/2018
ms.date: 04/30/2018
ms.author: v-yeche
ms.custom: mvc
---

# Create a three-node test Service Fabric cluster

This sample script creates a three-node test Service Fabric cluster secured with an X.509 certificate. The three node cluster configuration is supported for dev/test because you can safely perform upgrades and survive individual node failures (as long as they don't happen simultaneously). Production cluster require five or more nodes in order to be resilient to simultaneous failures.  

The command creates a self-signed certificate and uploads it to a new key vault, which is created in the same resource group as the cluster. The certificate is also copied to a local directory.  Set the *-OS* parameter to choose the version of Windows or Linux that runs on the cluster nodes.  Customize the parameters as needed.

If needed, install the Azure PowerShell using the instruction found in the [Azure PowerShell guide](https://docs.microsoft.com/powershell/azure/overview) and then run `Login-AzureRmAccount -EnvironmentName AzureChinaCloud` to create a connection with Azure. 

## Sample script

```powershell
Login-AzureRmAccount -EnvironmentName AzureChinaCloud
Get-AzureRmSubscription
Set-AzureRmContext -SubscriptionId "<yourSubscriptionID>"

# Certificate variables.
$certpwd="Password#1234" | ConvertTo-SecureString -AsPlainText -Force
$certfolder="c:\mycertificates\"

# Variables for VM admin.
$adminuser="vmadmin"
$adminpwd="Password#1234" | ConvertTo-SecureString -AsPlainText -Force 

# Variables for common values
$clusterloc="chinanorth"
$clustername = "mysftestcluster"
$groupname="mysfclustergroup"       
$vmsku = "Standard_D1_v2"
$subname="$clustername.$clusterloc.cloudapp.chinacloudapi.cn"

# Set the number of cluster nodes. Possible values: 1, 3-99
$clustersize=3 

# Create the Service Fabric cluster.
New-AzureRmServiceFabricCluster -Name $clustername -ResourceGroupName $groupname -Location $clusterloc `
-ClusterSize $clustersize -VmUserName $adminuser -VmPassword $adminpwd -CertificateSubjectName $subname `
-CertificatePassword $certpwd -CertificateOutputFolder $certfolder `
-OS WindowsServer2016DatacenterwithContainers -VmSku $vmsku

```

## Clean up deployment 

After the script sample has been run, the following command can be used to remove the resource group, cluster, and all related resources.

```powershell
$groupname="mysfclustergroup"
Remove-AzureRmResourceGroup -Name $groupname -Force
```

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [New-AzureRmServiceFabricCluster](https://docs.microsoft.com/powershell/module/azurerm.servicefabric/New-AzureRmServiceFabricCluster) | Creates a new Service Fabric cluster. |

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional Azure Powershell samples for Azure Service Fabric can be found in the [Azure PowerShell samples](../service-fabric-powershell-samples.md).
<!-- Update_Description: update meta properties, wording update -->