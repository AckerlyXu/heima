<properties
    pageTitle="Create an Internet-facing load balancer - Azure PowerShell classic | Azure"
    description="Learn how to create an Internet facing load balancer in classic mode using PowerShell"
    services="load-balancer"
    documentationcenter="na"
    author="kumudd"
    manager="timlt"
    tags="azure-service-management" />
<tags
    ms.assetid="73e8bfa4-8086-4ef0-9e35-9e00b24be319"
    ms.service="load-balancer"
    ms.devlang="na"
    ms.topic="get-started-article"
    ms.tgt_pltfrm="na"
    ms.workload="infrastructure-services"
    ms.date="01/23/2017"
    wacn.date=""
    ms.author="kumud" />

# Get started creating an Internet facing load balancer (classic) in PowerShell
> [AZURE.SELECTOR]
- [Azure Classic Management Portal](/documentation/articles/load-balancer-get-started-internet-classic-portal/)
- [PowerShell](/documentation/articles/load-balancer-get-started-internet-classic-ps/)
- [Azure CLI](/documentation/articles/load-balancer-get-started-internet-classic-cli/)
- [Azure Cloud Services](/documentation/articles/load-balancer-get-started-internet-classic-cloud/)

[AZURE.INCLUDE [load-balancer-get-started-internet-intro-include.md](../../includes/load-balancer-get-started-internet-intro-include.md)]

> [AZURE.IMPORTANT]
> Before you work with Azure resources, it's important to understand that Azure currently has two deployment models: Azure Resource Manager and classic. Make sure you understand [deployment models and tools](/documentation/articles/azure-classic-rm/) before you work with any Azure resource. You can view the documentation for different tools by clicking the tabs at the top of this article. This article covers the classic deployment model. You can also [Learn how to create an Internet facing load balancer using Azure Resource Manager](/documentation/articles/load-balancer-get-started-internet-arm-ps/).

[AZURE.INCLUDE [load-balancer-get-started-internet-scenario-include.md](../../includes/load-balancer-get-started-internet-scenario-include.md)]

## Set up load balancer using PowerShell

To set up a load balancer using powershell, follow the steps below:

1. If you have never used Azure PowerShell, see [How to Install and Configure Azure PowerShell](https://docs.microsoft.com/powershell/azureps-cmdlets-docs) and follow the instructions all the way to the end to sign into Azure and select your subscription.
2. After creating a virtual machine, you can use PowerShell cmdlets to add a load balancer to a virtual machine within the same cloud service.

In the following example you will add a load balancer set called "webfarm" to cloud service "mytestcloud" (or myctestcloud.chinacloudapp.cn) , adding the endpoints for the load balancer to virtual machines named "web1" and "web2". The load balancer receives network traffic on port 80 and load balances between the virtual machines defined by the local endpoint (in this case port 80) using TCP.

### Step 1

Create a load balanced endpoint for the first VM "web1"

    Get-AzureVM -ServiceName "mytestcloud" -Name "web1" | Add-AzureEndpoint -Name "HttpIn" -Protocol "tcp" -PublicPort 80 -LocalPort 80 -LBSetName "WebFarm" -ProbePort 80 -ProbeProtocol "http" -ProbePath '/' | Update-AzureVM

### Step 2

Create another endpoint for the second VM  "web2" using the same load balancer set name

    Get-AzureVM -ServiceName "mytestcloud" -Name "web2" | Add-AzureEndpoint -Name "HttpIn" -Protocol "tcp" -PublicPort 80 -LocalPort 80 -LBSetName "WebFarm" -ProbePort 80 -ProbeProtocol "http" -ProbePath '/' | Update-AzureVM

## Remove a virtual machine from a load balancer

You can use Remove-AzureEndpoint to remove a virtual machine endpoint from the load balancer

    Get-azureVM -ServiceName mytestcloud  -Name web1 |Remove-AzureEndpoint -Name httpin | Update-AzureVM

## Next steps

You can also [get started creating an internal load balancer](/documentation/articles/load-balancer-get-started-ilb-classic-ps/) and configure what type of [distribution mode](/documentation/articles/load-balancer-distribution-mode/) for a specific load balancer network traffic behavior.

If your application needs to keep connections alive for servers behind a load balancer, you can understand more about [idle TCP timeout settings for a load balancer](/documentation/articles/load-balancer-tcp-idle-timeout/). It will help to learn about idle connection behavior when you are using Azure Load Balancer.