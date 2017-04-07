<properties
    pageTitle="Create an Internet-facing load balancer - Azure template | Azure"
    description="Learn how to create an Internet facing load balancer in Resource Manager using a template"
    services="load-balancer"
    documentationcenter="na"
    author="kumudd"
    manager="timlt"
    tags="azure-resource-manager" />
<tags
    ms.assetid="b24f4729-4559-4458-8527-71009d242647"
    ms.service="load-balancer"
    ms.devlang="na"
    ms.topic="get-started-article"
    ms.tgt_pltfrm="na"
    ms.workload="infrastructure-services"
    ms.date="01/23/2017"
    wacn.date=""
    ms.author="kumud" />

# Creating an Internet facing load balancer using a template
> [AZURE.SELECTOR]
- [Portal](/documentation/articles/load-balancer-get-started-internet-portal/)
- [PowerShell](/documentation/articles/load-balancer-get-started-internet-arm-ps/)
- [Azure CLI](/documentation/articles/load-balancer-get-started-internet-arm-cli/)
- [Template](/documentation/articles/load-balancer-get-started-internet-arm-template/)

[AZURE.INCLUDE [load-balancer-get-started-internet-intro-include.md](../../includes/load-balancer-get-started-internet-intro-include.md)]

[AZURE.INCLUDE [azure-arm-classic-important-include](../../includes/azure-arm-classic-important-include.md)]

This article covers the Resource Manager deployment model. You can also [Learn how to create an Internet facing load balancer using classic deployment model](/documentation/articles/load-balancer-get-started-internet-classic-portal/)

[AZURE.INCLUDE [load-balancer-get-started-internet-scenario-include.md](../../includes/load-balancer-get-started-internet-scenario-include.md)]

## Deploy the template by using click to deploy

The sample template available in the public repository uses a parameter file containing the default values used to generate the scenario described above. To deploy this template using click to deploy, follow [this link](https://github.com/Azure/azure-quickstart-templates/tree/master/201-2-vms-loadbalancer-natrules), click **Deploy to Azure**, replace the default parameter values if necessary, and follow the instructions in the portal.

## Deploy the template by using PowerShell

To deploy the template you downloaded by using PowerShell, follow the steps below.

1. If you have never used Azure PowerShell, see [How to Install and Configure Azure PowerShell](https://docs.microsoft.com/powershell/azureps-cmdlets-docs) and follow the instructions all the way to the end to sign into Azure and select your subscription.
2. Run the **New-AzureRmResourceGroupDeployment** cmdlet to create a resource group using the template.

        New-AzureRmResourceGroupDeployment -Name TestRG -Location chinanorth `
            -TemplateFile 'https://raw.githubusercontent.com/azure/azure-quickstart-templates/master/201-2-vms-loadbalancer-lbrules/azuredeploy.json' `
            -TemplateParameterFile 'https://raw.githubusercontent.com/azure/azure-quickstart-templates/master/201-2-vms-loadbalancer-lbrules/azuredeploy.parameters.json'

## Deploy the template by using the Azure CLI

To deploy the template by using the Azure CLI, follow the steps below.

1. If you have never used Azure CLI, see [Install and Configure the Azure CLI](/documentation/articles/cli-install-nodejs/) and follow the instructions up to the point where you select your Azure account and subscription.
2. Run the **azure config mode** command to switch to Resource Manager mode, as shown below.

        azure config mode arm

Here is the expected output for the command above:

        info:    New mode is arm

3. From your browser, navigate to [the Quickstart Template](https://github.com/Azure/azure-quickstart-templates/tree/master/201-2-vms-loadbalancer-lbrules), copy the contents of the json file and paste into a new file in your computer. For this scenario, you would be copying the values below to a file named **c:\lb\azuredeploy.parameters.json**.
4. Run the **azure group deployment create** cmdlet to deploy the new load balancer by using the template and parameter files you downloaded and modified above. The list shown after the output explains the parameters used.

        azure group create --name TestRG --location chinanorth --template-file 'https://raw.githubusercontent.com/azure/azure-quickstart-templates/master/201-2-vms-loadbalancer-lbrules/azuredeploy.json' --parameters-file 'c:\lb\azuredeploy.parameters.json'

## Next steps

[Get started configuring an internal load balancer](/documentation/articles/load-balancer-get-started-ilb-arm-ps/)

[Configure a load balancer distribution mode](/documentation/articles/load-balancer-distribution-mode/)

[Configure idle TCP timeout settings for your load balancer](/documentation/articles/load-balancer-tcp-idle-timeout/)