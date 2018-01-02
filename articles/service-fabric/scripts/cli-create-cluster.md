---
title: Azure Service Fabric CLI Script Deploy Sample
description: Create a secure Service Fabric Linux cluster in Azure using the Azure Service Fabric CLI.
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
origin.date: 09/18/2017
ms.date: 01/01/2018
ms.author: v-yeche
ms.custom: mvc
---

# Create a secure Service Fabric Linux cluster in Azure

This command creates a self-signed certificate, adds it to a key vault and downloads the certificate locally.  The new certificate is used to secure the cluster when it deploys.  You can also use an existing certificate instead of creating a new one.  Either way, the certificate's subject name must match the domain that you use to access the Service Fabric cluster. This match is required to provide an SSL for the cluster's HTTPS management endpoints and Service Fabric Explorer. You cannot obtain an SSL certificate from a CA for the `.cloudapp.chinacloudapi.cn` domain. You must obtain a custom domain name for your cluster. When you request a certificate from a CA, the certificate's subject name must match the custom domain name that you use for your cluster.

If needed, install the [Azure CLI 2.0](https://docs.azure.cn/zh-cn/cli/install-azure-cli?view=azure-cli-latest).

## Sample script

```sh
﻿#!/bin/bash

# Variables
ResourceGroupName="aztestclustergroup" 
ClusterName="aztestcluster" 
Location="chinaeast" 
Password="q6D7nN%6ck@6" 
Subject="aztestcluster.chinaeast.cloudapp.chinacloudapi.cn" 
VaultName="aztestkeyvault" 
VmPassword="Mypa$$word!321"
VmUserName="sfadminuser"

# Create resource group
az group create --name $ResourceGroupName --location $Location 

# Create secure five node Linux cluster. Creates a key vault in a resource group
# and creates a certficate in the key vault. The certificate's subject name must match 
# the domain that you use to access the Service Fabric cluster.  The certificate is downloaded locally.
az sf cluster create --resource-group $ResourceGroupName --location $Location \ 
  --certificate-output-folder . --certificate-password $Password --certificate-subject-name $Subject \
  --cluster-name $ClusterName --cluster-size 5 --os UbuntuServer1604 --vault-name $VaultName \ 
  --vault-resource-group $ResourceGroupName --vm-password $VmPassword --vm-user-name $VmUserName

```

## Clean up deployment

After the script sample has been run, the following command can be used to remove the resource group, cluster, and all related resources.

```azurecli
ResourceGroupName = "aztestclustergroup"
az group delete --name $ResourceGroupName
```

## Script explanation

This script uses the following commands. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az sf cluster create](https://docs.azure.cn/zh-cn/cli/sf/cluster?view=azure-cli-latest#az_sf_cluster_create) | Creates a new Service Fabric cluster.  |

## Next steps

Additional Service Fabric CLI samples for Azure Service Fabric can be found in the [Service Fabric CLI samples](../samples-cli.md).
<!--Update_Description: update meta properties, update wording -->