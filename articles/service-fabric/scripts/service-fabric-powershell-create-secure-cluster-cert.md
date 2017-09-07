---
title: Azure PowerShell Script Sample - Create a Service Fabric cluster| Azure
description: Azure PowerShell Script Sample - Create a Service Fabric cluster.
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
ms.topic: article
origin.date: 06/20/2017
ms.date: 09/11/2017
ms.author: v-yeche
ms.custom: mvc
---

# Create a Service Fabric cluster

This sample script creates a Service Fabric cluster a five-node cluster secured with an X.509 certificate.  The command creates a self-signed certificate and uploads it to a new key vault. The certificate is also copied to a local directory.  Set the *-OS* parameter to choose the version of Windows or Linux that runs on the cluster nodes.  Customize the parameters as needed.

If needed, install the Azure PowerShell using the instruction found in the [Azure PowerShell guide](https://docs.microsoft.com/powershell/azure/overview) and then run `Login-AzureRmAccount -EnvironmentName AzureChinaCloud` to create a connection with Azure. 

## Sample script

```powershell
#Provide the subscription Id
$subscriptionId = 'yourSubscriptionId'

# Certificate variables.
$certpwd="Password#1234" | ConvertTo-SecureString -AsPlainText -Force
$certfolder="c:\mycertificates\"

# Variables for VM admin.
$adminuser="vmadmin"
$adminpwd="Password#1234" | ConvertTo-SecureString -AsPlainText -Force 

# Variables for common values
$clusterloc="SouthCentralUS"
$clustername = "mysfcluster"
$groupname="mysfclustergroup"       
$vmsku = "Standard_D2_v2"
$vaultname = "mykeyvault"
$subname="$clustername.$clusterloc.cloudapp.chinacloudapi.cn"

# Set the number of cluster nodes. Possible values: 1, 3-99
$clustersize=5 

# Set the context to the subscription Id where the cluster will be created
Select-AzureRmSubscription -SubscriptionId $subscriptionId

# Create the Service Fabric cluster.
New-AzureRmServiceFabricCluster -Name $clustername -ResourceGroupName $groupname -Location $clusterloc `
-ClusterSize $clustersize -VmUserName $adminuser -VmPassword $adminpwd -CertificateSubjectName $subname `
-CertificatePassword $certpwd -CertificateOutputFolder $certfolder `
-OS WindowsServer2016DatacenterwithContainers -VmSku $vmsku -KeyVaultName $vaultname
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

<!--Update_Description: new articles of create secure cluster with ps in service fabric -->