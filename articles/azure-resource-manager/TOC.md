# Overview
## [What is Resource Manager?](resource-group-overview.md)
## [Resource providers and types](resource-manager-supported-services.md)
## [Resource Manager and Classic deployment](resource-manager-deployment-model.md)
## [Subscription governance](resource-manager-subscription-governance.md)
<!-- Not Available ## [Managed Applications](managed-application-overview.md)-->

# Get started
## [Export template](resource-manager-export-template.md)
## [Create and deploy template](resource-manager-create-first-template.md)
## [Visual Studio with Resource Manager](vs-azure-tools-resource-groups-deployment-projects-create-deploy.md)

# Samples
## [Code samples](https://azure.microsoft.com/resources/samples/?service=azure-resource-manager)
## PowerShell
### [Deploy template](resource-manager-samples-powershell-deploy.md)

## Azure CLI
### [Deploy template](resource-manager-samples-cli-deploy.md)

# How to
## Create templates
### [Best practices for templates](resource-manager-template-best-practices.md)
### [Template sections](resource-group-authoring-templates.md)
### [Link to other templates](resource-group-linked-templates.md)
### [Define dependency between resources](resource-group-define-dependencies.md)
### [Create multiple instances](resource-group-create-multiple.md)
### [Set location](resource-manager-template-location.md)
### [Assign tags](resource-manager-template-tags.md)
### [Set child resource name and type](resource-manager-template-child-resource.md)
### [Update resource](resource-manager-update.md)
<!-- Not Availble ### [Use objects for parameters](resource-manager-objects-as-parameters.md) -->
### [Share state between linked templates](best-practices-resource-manager-state.md)
### [Patterns for designing templates](best-practices-resource-manager-design-templates.md)

## Deploy
### PowerShell
#### [Deploy template](resource-group-template-deploy.md)
#### [Deploy private template with SAS token](resource-manager-powershell-sas-token.md)
#### [Export template and redeploy](resource-manager-export-template-powershell.md)
### Azure CLI
#### [Deploy template](resource-group-template-deploy-cli.md)
#### [Deploy private template with SAS token](resource-manager-cli-sas-token.md)
#### [Export template and redeploy](resource-manager-export-template-cli.md)
### [Portal](resource-group-template-deploy-portal.md)
### [REST API](resource-group-template-deploy-rest.md)
### [Cross resource group deployment](resource-manager-cross-resource-group-deployment.md)
### [Continuous integration with Visual Studio Team Services](../vs-azure-tools-resource-groups-ci-in-vsts.md?toc=%2fazure-resource-manager%2ftoc.json)
### [Pass secure values during deployment](resource-manager-keyvault-parameter.md)

## Manage
### [PowerShell](powershell-azure-resource-manager.md)
### [Azure CLI](xplat-cli-azure-resource-manager.md)
### [Portal](resource-group-portal.md)
### [REST API](resource-manager-rest-api.md)
### [Use tags to organize resources](resource-group-using-tags.md)
### [Move resources to new group or subscription](resource-group-move-resources.md)
### [Governance examples](resource-manager-subscription-examples.md)

## Control Access
### Create service principal
#### [PowerShell](resource-group-authenticate-service-principal.md)
#### [Azure CLI 2.0](https://docs.microsoft.com/cli/azure/create-an-azure-service-principal-azure-cli?toc=%2fazure%2fazure-resource-manager%2ftoc.json)
#### [Azure CLI 1.0](resource-group-authenticate-service-principal-cli.md)
#### [Portal](resource-group-create-service-principal-portal.md)
### [Authentication API to access subscriptions](resource-manager-api-authentication.md)
### [Lock resources](resource-group-lock-resources.md)

## Set resource policies
### [What are resource policies?](resource-manager-policy.md)
<!-- Not Available ### [Use portal to assign policy](resource-manager-policy-portal.md) -->
<!-- Not Available ### [Use scripts to assign policy](resource-manager-policy-create-assign.md) -->
### Examples
<!-- Not Available #### [Resource tags](resource-manager-policy-tags.md) -->
<!-- Not Available #### [Naming conventions](resource-manager-policy-naming-convention.md) -->
<!-- Not Available #### [Network](resource-manager-policy-network.md) -->
<!-- Not Available #### [Storage](resource-manager-policy-storage.md) -->
#### [Linux VM](../virtual-machines/linux/policy.md?toc=%2fazure-resource-manager%2ftoc.json)
#### [Windows VM](../virtual-machines/windows/policy.md?toc=%2fazure-resource-manager%2ftoc.json)

<!-- Not Available ## Use managed applications -->
<!-- Not Available ### [Publish service catalog application](managed-application-publishing.md) -->
<!-- Not Available ### [Consume service catalog application](managed-application-consumption.md) -->
<!-- Not Available ### [Create UI definitions](managed-application-createuidefinition-overview.md) -->

## Audit
### [View activity logs](resource-group-audit.md)
### [View deployment operations](resource-manager-deployment-operations.md)

## Troubleshoot
### [Common deployment errors](resource-manager-common-deployment-errors.md)
### [Understand deployment errors](resource-manager-troubleshoot-tips.md)
### [RequestDisallowedByPolicy error](resource-manager-policy-requestdisallowedbypolicy-error.md)
### Virtual Machine deployment errors
#### [Linux](../virtual-machines/linux/troubleshoot-deploy-vm.md)
#### [Windows](../virtual-machines/windows/troubleshoot-deploy-vm.md)

# Reference
<!-- Not Available ## [Template format](/templates/) -->
## [Template functions](resource-group-template-functions.md)
### [Array and object functions](resource-group-template-functions-array.md)
### [Comparison functions](resource-group-template-functions-comparison.md)
### [Deployment functions](resource-group-template-functions-deployment.md)
### [Logical functions](resource-group-template-functions-logical.md)
### [Numeric functions](resource-group-template-functions-numeric.md)
### [Resource functions](resource-group-template-functions-resource.md)
### [String functions](resource-group-template-functions-string.md)
<!-- Not Available ## [UI definition functions](managed-application-createuidefinition-functions.md) -->
<!-- Not Available ## [UI definition elements](managed-application-createuidefinition-elements.md) -->
<!-- Not Available ### [Microsoft.Common.DropDown](managed-application-microsoft-common-dropdown.md) -->
<!-- Not Available ### [Microsoft.Common.FileUpload](managed-application-microsoft-common-fileupload.md) -->
<!-- Not Available ### [Microsoft.Common.OptionsGroup](managed-application-microsoft-common-optionsgroup.md) -->
<!-- Not Available ### [Microsoft.Common.PasswordBox](managed-application-microsoft-common-passwordbox.md) -->
<!-- Not Available ### [Microsoft.Common.Section](managed-application-microsoft-common-section.md) -->
<!-- Not Available ### [Microsoft.Common.TextBox](managed-application-microsoft-common-textbox.md) -->
<!-- Not Available ### [Microsoft.Compute.CredentialsCombo](managed-application-microsoft-compute-credentialscombo.md) -->
<!-- Not Available ### [Microsoft.Compute.SizeSelector](managed-application-microsoft-compute-sizeselector.md) -->
<!-- Not Available ### [Microsoft.Compute.UserNameTextBox](managed-application-microsoft-compute-usernametextbox.md) -->
<!-- Not Available ### [Microsoft.Network.PublicIpAddressCombo](managed-application-microsoft-network-publicipaddresscombo.md) -->
<!-- Not Available ### [Microsoft.Network.VirtualNetworkCombo](managed-application-microsoft-network-virtualnetworkcombo.md) -->
<!-- Not Available ### [Microsoft.Storage.MultiStorageAccountCombo](managed-application-microsoft-storage-multistorageaccountcombo.md) -->
<!-- Not Available ### [Microsoft.Storage.StorageAccountSelector](managed-application-microsoft-storage-storageaccountselector.md) -->
## [PowerShell](https://docs.microsoft.com/powershell/module/azurerm.resources)
## [Azure CLI](https://docs.microsoft.com/cli/azure/resource)
## [.NET](https://docs.microsoft.com/dotnet/api/microsoft.azure.management.resourcemanager)
## [Java](https://docs.azure.cn/java/api/com.microsoft.azure.management.resources)
## [Python](http://azure-sdk-for-python.readthedocs.io/en/latest/resourcemanagement.html)
## [REST](https://docs.microsoft.com/rest/api/resources/)

# Resources
<!-- Not Available ## [Service updates](https://azure.microsoft.com/updates/?product=azure-resource-manager) -->
## [Pricing calculator](https://www.azure.cn/pricing/calculator/)
## [Service updates](https://www.azure.cn/what-is-new/)
## [Stack Overflow](http://stackoverflow.com/questions/tagged/azure-resource-manager)
## [Throttling requests](resource-manager-request-limits.md)
## [Track asynchronous operations](resource-manager-async-operations.md)
<!-- Not Available ## [Videos](https://azure.microsoft.com/documentation/videos/index/?services=azure-resource-manager) -->
