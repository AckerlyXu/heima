---
title: Azure PowerShell Script Sample - Set up custom domain
description: Azure PowerShell Script Sample - Set up custom domain
services: api-management
documentationcenter: ''
author: juliako
manager: cfowler
editor: ''

ms.service: api-management
ms.workload: mobile
ms.devlang: na
ms.topic: sample
origin.date: 12/14/2017
ms.date: 02/26/2018
ms.author: v-yiso
ms.custom: mvc
---

# Set up custom domain

This sample script sets up custom domain on proxy and portal endpoint of the API Management service.


If you choose to install and use the PowerShell locally, this tutorial requires the Azure PowerShell module version 3.6 or later. Run ` Get-Module -ListAvailable AzureRM` to find the version. If you need to upgrade, see [Install Azure PowerShell module](https://docs.microsoft.com/en-us/powershell/azure/install-azurerm-ps). If you are running PowerShell locally, you also need to run `Login-AzureRmAccount -Environment AzureChinaCloud` to create a connection with Azure.

## Sample script

```powershell
##########################################################
#  Script to setup custom domain on proxy and portal endpoint
#  of api management service.
###########################################################

$random = (New-Guid).ToString().Substring(0,8)

#Azure specific details
$subscriptionId = "my-azure-subscription-id"

# Api Management service specific details
$apimServiceName = "apim-$random"
$resourceGroupName = "apim-rg-$random"
$location = "China East"
$organisation = "Contoso"
$adminEmail = "admin@contoso.com"

# Set the context to the subscription Id where the cluster will be created
Select-AzureRmSubscription -SubscriptionId $subscriptionId

# Create a resource group.
New-AzureRmResourceGroup -Name $resourceGroupName -Location $location

# Create the Api Management service. Since the SKU is not specified, it creates a service with Developer SKU. 
New-AzureRmApiManagement -ResourceGroupName $resourceGroupName -Name $apimServiceName -Location $location -Organization $organisation -AdminEmail $adminEmail

# Certificate related details
$proxyHostname = "proxy.contoso.net"
# Certificate containing Common Name CN="proxy.contoso.net" or CN=*.contoso.net
$proxyCertificatePath = "C:\proxycert.pfx"
$proxyCertificatePassword = "certPassword"

$portalHostname = "portal.contoso.net"
# Certificate containing Common Name CN="portal.contoso.net" or CN=*.contoso.net
$portalCertificatePath = "C:\portalcert.pfx"
$portalCertificatePassword = "certPassword"

# Upload the custom ssl certificate to be applied to Proxy endpoint / Api Gateway endpoint
$proxyCertUploadResult = Import-AzureRmApiManagementHostnameCertificate -Name $apimServiceName -ResourceGroupName $resourceGroupName `
                        -HostnameType "Proxy" -PfxPath $proxyCertificatePath -PfxPassword $proxyCertificatePassword

# Upload the custom ssl certificate to be applied to Portal endpoint
$portalCertUploadResult = Import-AzureRmApiManagementHostnameCertificate -Name $apimServiceName -ResourceGroupName $resourceGroupName `
                        -HostnameType "Portal" -PfxPath $portalCertificatePath -PfxPassword $portalCertificatePassword

# Create the HostnameConfiguration object for Portal endpoint
$PortalHostnameConf = New-AzureRmApiManagementHostnameConfiguration -Hostname $proxyHostname -CertificateThumbprint $proxyCertUploadResult.Thumbprint

# Create the HostnameConfiguration object for Proxy endpoint
$ProxyHostnameConf = New-AzureRmApiManagementHostnameConfiguration -Hostname $portalHostname -CertificateThumbprint $portalCertUploadResult.Thumbprint

# Apply the configuration to API Management
Set-AzureRmApiManagementHostnames -Name $apimServiceName -ResourceGroupName $resourceGroupName `
        -PortalHostnameConfiguration $PortalHostnameConf -ProxyHostnameConfiguration $ProxyHostnameConf
```

## Clean up resources

When no longer needed, you can use the [Remove-AzureRmResourceGroup](https://docs.microsoft.com/en-us/powershell/module/azurerm.resources/remove-azurermresourcegroup) command to remove the resource group and all related resources.

```azurepowershell
Remove-AzureRmResourceGroup -Name myResourceGroup
```

[!INCLUDE [api-management-custom-domain](../../../includes/api-management-custom-domain.md)]

## Next steps

For more information on the Azure PowerShell module, see [Azure PowerShell documentation](https://docs.microsoft.com/powershell/azure/overview).

Additional Azure Powershell samples for Azure API Management can be found in the [PowerShell samples](../powershell-samples.md).
