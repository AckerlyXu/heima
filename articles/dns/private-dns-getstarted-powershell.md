---
title: Get started with Azure DNS private zones using PowerShell | Azure
description: Learn how to create a private DNS zone and record in Azure DNS. This is a step-by-step guide to create and manage your first private DNS zone and record using PowerShell.
services: dns
documentationcenter: na
author: yunan2016
manager: digimobile

editor: ''
tags: azure-resource-manager

ms.assetid: ''
ms.service: dns
ms.devlang: na
ms.topic: get-started-article
ms.tgt_pltfrm: na
ms.workload: infrastructure-services
origin.date: 11/20/2017
ms.date: 03/05/2018
ms.author: v-nany

---

# Get started with Azure DNS private zones using PowerShell

This article walks you through the steps to create your first private DNS zone and record using Azure PowerShell.

[!INCLUDE [private-dns-preview-notice](../../includes/private-dns-preview-notice.md)]

## Create the resource group

Before creating the DNS zone, a resource group is created to contain the DNS zone. The following shows the command.

```powershell
New-AzureRMResourceGroup -name MyResourceGroup -location "chinaeast"
```

## Create a DNS zone

A DNS zone is created by using the `New-AzureRmDnsZone` cmdlet. The following example creates a DNS zone called *contoso.local* in the resource group called *MyResourceGroup* and makes the DNS zone available to the virtual network called *MyAzureVnet*. Use the example to create a DNS zone, substituting the values for your own.

```powershell
$vnet = Get-AzureRmVirtualNetwork -Name MyAzureVnet -ResourceGroupName VnetResourceGroup
New-AzureRmDnsZone -Name contoso.local -ResourceGroupName MyResourceGroup -ZoneType Private -ResolutionVirtualNetworkId @($vnet.Id)
```

If you need Azure to automatically create hostname records in the zone, use the *RegistrationVirtualNetworkId* parameter instead of *ResolutionVirtualNetworkId*.  Registration virtual networks are automatically enabled for resolution.

```powershell
$vnet = Get-AzureRmVirtualNetwork -Name MyAzureVnet -ResourceGroupName VnetResourceGroup
New-AzureRmDnsZone -Name contoso.local -ResourceGroupName MyResourceGroup -ZoneType Private -RegistrationVirtualNetworkId @($vnet.Id)
```


## Create a DNS record

You create record sets by using the `New-AzureRmDnsRecordSet` cmdlet. The following example creates a record with the relative name "db" in the DNS Zone "contoso.local", in resource group "MyResourceGroup". The fully-qualified name of the record set is "db.contoso.local". The record type is "A", with IP address "10.0.0.4", and the TTL is 3600 seconds.

```powershell
New-AzureRmDnsRecordSet -Name db -RecordType A -ZoneName contoso.local -ResourceGroupName MyResourceGroup -Ttl 3600 -DnsRecords (New-AzureRmDnsRecordConfig -IPv4Address "10.0.0.4")
```

For other record types, for record sets with more than one record, and to modify existing records, see [Manage DNS records and record sets using Azure PowerShell](dns-operations-recordsets.md). 


## View records

To list the DNS records in your zone, use:

```powershell
Get-AzureRmDnsRecordSet -ZoneName contoso.local -ResourceGroupName MyResourceGroup
```

## Delete all resources

To delete all resources created in this article, take the following step:

```powershell
Remove-AzureRMResourceGroup -Name MyResourceGroup
```

## Next steps

To learn more about private DNS zones, see [Using Azure DNS for private domains](private-dns-overview.md).

To learn more about managing DNS records in Azure DNS, see [Manage DNS records and record sets in Azure DNS using PowerShell](dns-operations-recordsets.md).

