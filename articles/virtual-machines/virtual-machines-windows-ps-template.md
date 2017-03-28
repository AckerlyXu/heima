<properties
    pageTitle="Create a Windows VM from a template in Azure | Azure"
    description="Use a Resource Manager template and PowerShell to easily create a new Windows VM."
    services="virtual-machines-windows"
    documentationcenter=""
    author="davidmu1"
    manager="timlt"
    editor=""
    tags="azure-resource-manager" />
<tags
    ms.assetid="19129d61-8c04-4aa9-a01f-361a09466805"
    ms.service="virtual-machines-windows"
    ms.workload="na"
    ms.tgt_pltfrm="vm-windows"
    ms.devlang="na"
    ms.topic="article"
    ms.date="03/07/2017"
    wacn.date=""
    ms.author="davidmu"
    ms.custom="H1Hack27Feb2017" />

# Create a Windows virtual machine from a Resource Manager template

This article shows you how to deploy an Azure Resource Manager template using PowerShell. The [template](https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/101-vm-simple-windows/azuredeploy.json) deploys a single virtual machine running Windows Server in a new virtual network with a single subnet.

For a detailed description of the virtual machine resource, see [Virtual machines in an Azure Resource Manager template](/documentation/articles/virtual-machines-windows-template-description/). For more information about all the resources in a template, see [Azure Resource Manager template walkthrough](/documentation/articles/resource-manager-template-walkthrough/).

It should take about five minutes to do the steps in this article.

## Step 1: Install Azure PowerShell

See [How to install and configure Azure PowerShell](/documentation/articles/powershell-install-configure/) for information about installing the latest version of Azure PowerShell, selecting your subscription, and signing in to your account.

## Step 2: Create a resource group

All resources must be deployed in a [resource group](/documentation/articles/resource-group-overview/).

1. Get a list of available locations where resources can be created.

        Get-AzureRmLocation | sort DisplayName | Select DisplayName

2. Create the resource group in the location that you select. This example shows the creation of a resource group named **myResourceGroup** in the **China North** location:

        New-AzureRmResourceGroup -Name "myResourceGroup" -Location "China North"

    You should see something like this example:

        ResourceGroupName : myResourceGroup
        Location          : chinaeast
        ProvisioningState : Succeeded
        Tags              :
        ResourceId        : /subscriptions/{subscription-id}/resourceGroups/myResourceGroup

## Step 3: Create the resources
Deploy the template and provide parameter values when prompted. This example deploys the 101-vm-simple-windows template in the resource group that you created:

    New-AzureRmResourceGroupDeployment -ResourceGroupName "myResourceGroup" -TemplateUri "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/101-vm-simple-windows/azuredeploy.json" 

You're asked to provide the name of the administrator account on the VM, the password of the account, and the DNS prefix.

You should see something like this example:

    DeploymentName    : azuredeploy
    ResourceGroupName : myResourceGroup
    ProvisioningState : Succeeded
    Timestamp         : 12/29/2016 8:11:37 PM
    Mode              : Incremental
    TemplateLink      :
       Uri            : https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/
                        101-vm-simple-windows/azuredeploy.json
       ContentVersion : 1.0.0.0
    Parameters        :
      Name             Type                       Value
      ===============  =========================  ==========
      adminUsername    String                     myAdminUser
      adminPassword    SecureString
      dnsLabelPrefix   String                     myDomain
      windowsOSVersion String                     2016-Datacenter
    Outputs           :
      Name             Type                       Value
      ===============  =========================  ===========
      hostname         String                     myDomain.chinaeast.chinacloudapp.cn
    DeploymentDebugLogLevel :

> [AZURE.NOTE]
> You can also deploy templates and parameters from local files. To learn more, see [Using Azure PowerShell with Azure Storage](/documentation/articles/storage-powershell-guide-full/).

## Next Steps

- If there were issues with the deployment, a next step would be to look at [Troubleshoot common Azure deployment errors with Azure Resource Manager](/documentation/articles/resource-manager-common-deployment-errors/).
- Learn how to use Azure PowerShell to create a virtual machine from [Create a Windows VM using Resource Manager and PowerShell](/documentation/articles/virtual-machines-windows-ps-create/).
- Learn how to manage the virtual machine that you created by reviewing [Manage virtual machines using Azure Resource Manager and PowerShell](/documentation/articles/virtual-machines-windows-ps-manage/).