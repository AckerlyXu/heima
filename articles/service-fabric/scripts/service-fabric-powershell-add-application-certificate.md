---
title: Azure PowerShell Script Sample - Add application cert to a cluster| Azure
description: Azure PowerShell Script Sample - Add an application certificate to a Service Fabric cluster.
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

# Add an application certificate to a Service Fabric cluster

This sample script creates a self-signed certificate in the specified Azure key vault and installs it to all nodes of the Service Fabric cluster. The certificate also downloads to a local folder. The name of the downloaded certificate is the same as the name of the certificate in the key vault. Customize the parameters as needed.

If needed, install the Azure PowerShell using the instruction found in the [Azure PowerShell guide](https://docs.microsoft.com/powershell/azure/overview) and then run `Login-AzureRmAccount -EnvironmentName AzureChinaCloud` to create a connection with Azure. 

## Sample script

```powershell
﻿
# Variables for common values.
$clusterloc="ChinaEast"
$groupname="mysfclustergroup"
$clustername = "mysfcluster"
$vaultname = "mykeyvault"
$subname="$clustername.$clusterloc.cloudapp.chinacloudapi.cn"

# Certificate variables.
$appcertpwd = ConvertTo-SecureString -String 'Password#1234' -AsPlainText -Force
$appcertfolder="c:\myappcertificates\"

# Create a new self-signed certificate and add it to all the VMs in the cluster.
Add-AzureRmServiceFabricApplicationCertificate -ResourceGroupName $groupname -Name $clustername `
    -KeyVaultName $vaultname -KeyVaultResouceGroupName $groupname -CertificateSubjectName $subname `
    -CertificateOutputFolder $appcertfolder -CertificatePassword $appcertpwd
```

## Script explanation

This script uses the following commands: Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [Add-AzureRmServiceFabricApplicationCertificate](https://docs.microsoft.com/powershell/module/azurerm.servicefabric/Add-AzureRmServiceFabricApplicationCertificate) | Add a new application certificate to the virtual machine scale set that make up the cluster.  |

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional Azure Powershell samples for Azure Service Fabric can be found in the [Azure PowerShell samples](../service-fabric-powershell-samples.md).
<!--Update_Description: update meta properties-->