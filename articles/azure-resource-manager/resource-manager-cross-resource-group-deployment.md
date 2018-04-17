---
title: Deploy Azure resources to multiple subscription and resource groups | Azure
description: Shows how to target more than one Azure subscription and resource group during deployment.
services: azure-resource-manager
documentationcenter: na
author: rockboyfor
manager: digimobile
editor: ''

ms.service: azure-resource-manager
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: na
origin.date: 03/13/2018
ms.date: 03/26/2018
ms.author: v-yeche

---

# Deploy Azure resources to more than one subscription or resource group

Typically, you deploy all the resources in your template to a single [resource group](resource-group-overview.md). However, there are scenarios where you want to deploy a set of resources together but place them in different resource groups or subscriptions. For example, you may want to deploy the backup virtual machine for Azure Site Recovery to a separate resource group and location. Resource Manager enables you to use nested templates to target different subscriptions and resource groups than the subscription and resource group used for the parent template.

> [!NOTE]
> You can deploy to only five resource groups in a single deployment. Typically, this limitation means you can deploy to one resource group specified for the parent template, and up to four resource groups in nested or linked deployments. However, if your parent template contains only nested or linked templates and does not itself deploy any resources, then you can include up to five resource groups in nested or linked deployments.

## Specify a subscription and resource group

To target a different resource, use a nested or linked template. The `Microsoft.Resources/deployments` resource type provides parameters for `subscriptionId` and `resourceGroup`. These properties enable you to specify a different subscription and resource group for the nested deployment. All the resource groups must exist before running the deployment. If you do not specify either the subscription ID or resource group, the subscription and resource group from the parent template is used.

The account you use to deploy the template must have permissions to deploy to the specified subscription ID. 
<!-- Not Available on [add guest users from another directory](../active-directory/active-directory-b2b-what-is-azure-ad-b2b.md) -->

To specify a different resource group and subscription, use:

```json
"resources": [
    {
        "apiVersion": "2017-05-10",
        "name": "nestedTemplate",
        "type": "Microsoft.Resources/deployments",
        "resourceGroup": "[parameters('secondResourceGroup')]",
        "subscriptionId": "[parameters('secondSubscriptionID')]",
        ...
    }
]
```

If your resource groups are in the same subscription, you can remove the **subscriptionId** value.

The following example deploys two storage accounts - one in the resource group specified during deployment, and one in a resource group specified in the `secondResourceGroup` parameter:

```json
{
    "$schema": "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {
        "storagePrefix": {
            "type": "string",
            "maxLength": 11
        },
        "secondResourceGroup": {
            "type": "string"
        },
        "secondSubscriptionID": {
            "type": "string",
            "defaultValue": ""
        },
        "secondStorageLocation": {
            "type": "string",
            "defaultValue": "[resourceGroup().location]"
        }
    },
    "variables": {
        "firstStorageName": "[concat(parameters('storagePrefix'), uniqueString(resourceGroup().id))]",
        "secondStorageName": "[concat(parameters('storagePrefix'), uniqueString(parameters('secondSubscriptionID'), parameters('secondResourceGroup')))]"
    },
    "resources": [
        {
            "apiVersion": "2017-05-10",
            "name": "nestedTemplate",
            "type": "Microsoft.Resources/deployments",
            "resourceGroup": "[parameters('secondResourceGroup')]",
            "subscriptionId": "[parameters('secondSubscriptionID')]",
            "properties": {
                "mode": "Incremental",
                "template": {
                    "$schema": "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
                    "contentVersion": "1.0.0.0",
                    "parameters": {},
                    "variables": {},
                    "resources": [
                        {
                            "type": "Microsoft.Storage/storageAccounts",
                            "name": "[variables('secondStorageName')]",
                            "apiVersion": "2017-06-01",
                            "location": "[parameters('secondStorageLocation')]",
                            "sku":{
                                "name": "Standard_LRS"
                            },
                            "kind": "Storage",
                            "properties": {
                            }
                        }
                    ]
                },
                "parameters": {}
            }
        },
        {
            "type": "Microsoft.Storage/storageAccounts",
            "name": "[variables('firstStorageName')]",
            "apiVersion": "2017-06-01",
            "location": "[resourceGroup().location]",
            "sku":{
                "name": "Standard_LRS"
            },
            "kind": "Storage",
            "properties": {
            }
        }
    ]
}
```

If you set `resourceGroup` to the name of a resource group that does not exist, the deployment fails.

To deploy the example template, use Azure PowerShell 4.0.0 or later, or Azure CLI 2.0.0 or later.

## Use the resourceGroup() function

For cross resource group deployments, the [resourceGroup() function](resource-group-template-functions-resource.md#resourcegroup) resolves differently based on how you specify the nested template. 

If you embed one template within another template, resourceGroup() in the nested template resolves to the parent resource group. An embedded template uses the following format:

```json
"apiVersion": "2017-05-10",
"name": "embeddedTemplate",
"type": "Microsoft.Resources/deployments",
"resourceGroup": "crossResourceGroupDeployment",
"properties": {
    "mode": "Incremental",
    "template": {
        ...
        resourceGroup() refers to parent resource group
    }
}
```

If you link to a separate template, resourceGroup() in the linked template resolves to the nested resource group. A linked template uses the following format:

```json
"apiVersion": "2017-05-10",
"name": "linkedTemplate",
"type": "Microsoft.Resources/deployments",
"resourceGroup": "crossResourceGroupDeployment",
"properties": {
    "mode": "Incremental",
    "templateLink": {
        ...
        resourceGroup() in linked template refers to linked resource group
    }
}
```

## Example templates

The following templates demonstrate multiple resource group deployments. Scripts to deploy the templates are shown after the table.

|Template  |Description  |
|---------|---------|
|[Cross subscription template](https://github.com/Azure/azure-docs-json-samples/blob/master/azure-resource-manager/crosssubscription.json) |Deploys one storage account to one resource group and one storage account to a second resource group. Include a value for the subscription ID when the second resource group is in a different subscription. |
|[Cross resource group properties template](https://github.com/Azure/azure-docs-json-samples/blob/master/azure-resource-manager/crossresourcegroupproperties.json) |Demonstrates how the `resourceGroup()` function resolves. It does not deploy any resources. |

### PowerShell

For PowerShell, to deploy two storage accounts to two resource groups in the **same subscription**, use:

```powershell
$firstRG = "primarygroup"
$secondRG = "secondarygroup"

New-AzureRmResourceGroup -Name $firstRG -Location chinaeast
New-AzureRmResourceGroup -Name $secondRG -Location chinaeast

New-AzureRmResourceGroupDeployment `
  -ResourceGroupName $firstRG `
  -TemplateUri https://raw.githubusercontent.com/Azure/azure-docs-json-samples/master/azure-resource-manager/crosssubscription.json `
  -storagePrefix storage `
  -secondResourceGroup $secondRG `
  -secondStorageLocation chinaeast
```

For PowerShell, to deploy two storage accounts to **two subscriptions**, use:

```powershell
$firstRG = "primarygroup"
$secondRG = "secondarygroup"

$firstSub = "<first-subscription-id>"
$secondSub = "<second-subscription-id>"

Select-AzureRmSubscription -Subscription $secondSub
New-AzureRmResourceGroup -Name $secondRG -Location chinaeast

Select-AzureRmSubscription -Subscription $firstSub
New-AzureRmResourceGroup -Name $firstRG -Location chinaeast

New-AzureRmResourceGroupDeployment `
  -ResourceGroupName $firstRG `
  -TemplateUri https://raw.githubusercontent.com/Azure/azure-docs-json-samples/master/azure-resource-manager/crosssubscription.json `
  -storagePrefix storage `
  -secondResourceGroup $secondRG `
  -secondStorageLocation chinaeast `
  -secondSubscriptionID $secondSub
```

For PowerShell, to test how the **resource group object** resolves for the parent template, inline template, and linked template, use:

```powershell
New-AzureRmResourceGroup -Name parentGroup -Location chinaeast
New-AzureRmResourceGroup -Name inlineGroup -Location chinaeast
New-AzureRmResourceGroup -Name linkedGroup -Location chinaeast

New-AzureRmResourceGroupDeployment `
  -ResourceGroupName parentGroup `
  -TemplateUri https://raw.githubusercontent.com/Azure/azure-docs-json-samples/master/azure-resource-manager/crossresourcegroupproperties.json
```

In the preceding example, both **parentRG** and **inlineRG** resolve to **parentGroup**. **linkedRG** resolves to **linkedGroup**. The output from the preceding example is:

```powershell
 Name             Type                       Value
 ===============  =========================  ==========
 parentRG         Object                     {
                                               "id": "/subscriptions/<subscription-id>/resourceGroups/parentGroup",
                                               "name": "parentGroup",
                                               "location": "chinaeast",
                                               "properties": {
                                                 "provisioningState": "Succeeded"
                                               }
                                             }
 inlineRG         Object                     {
                                               "id": "/subscriptions/<subscription-id>/resourceGroups/parentGroup",
                                               "name": "parentGroup",
                                               "location": "chinaeast",
                                               "properties": {
                                                 "provisioningState": "Succeeded"
                                               }
                                             }
 linkedRG         Object                     {
                                               "id": "/subscriptions/<subscription-id>/resourceGroups/linkedGroup",
                                               "name": "linkedGroup",
                                               "location": "chinaeast",
                                               "properties": {
                                                 "provisioningState": "Succeeded"
                                               }
                                             }
```

### Azure CLI

For Azure CLI, to deploy two storage accounts to two resource groups in the **same subscription**, use:

```azurecli
firstRG="primarygroup"
secondRG="secondarygroup"

az group create --name $firstRG --location chinaeast
az group create --name $secondRG --location chinaeast
az group deployment create \
  --name ExampleDeployment \
  --resource-group $firstRG \
  --template-uri https://raw.githubusercontent.com/Azure/azure-docs-json-samples/master/azure-resource-manager/crosssubscription.json \
  --parameters storagePrefix=tfstorage secondResourceGroup=$secondRG secondStorageLocation=chinaeast
```

For Azure CLI, to deploy two storage accounts to **two subscriptions**, use:

```azurecli
firstRG="primarygroup"
secondRG="secondarygroup"

firstSub="<first-subscription-id>"
secondSub="<second-subscription-id>"

az account set --subscription $secondSub
az group create --name $secondRG --location chinaeast

az account set --subscription $firstSub
az group create --name $firstRG --location chinaeast

az group deployment create \
  --name ExampleDeployment \
  --resource-group $firstRG \
  --template-uri https://raw.githubusercontent.com/Azure/azure-docs-json-samples/master/azure-resource-manager/crosssubscription.json \
  --parameters storagePrefix=storage secondResourceGroup=$secondRG secondStorageLocation=chinaeast secondSubscriptionID=$secondSub
```

For Azure CLI, to test how the **resource group object** resolves for the parent template, inline template, and linked template, use:

```azurecli
az group create --name parentGroup --location chinaeast
az group create --name inlineGroup --location chinaeast
az group create --name linkedGroup --location chinaeast

az group deployment create \
  --name ExampleDeployment \
  --resource-group parentGroup \
  --template-uri https://raw.githubusercontent.com/Azure/azure-docs-json-samples/master/azure-resource-manager/crossresourcegroupproperties.json 
```

In the preceding example, both **parentRG** and **inlineRG** resolve to **parentGroup**. **linkedRG** resolves to **linkedGroup**. The output from the preceding example is:

```azurecli
...
"outputs": {
  "inlineRG": {
    "type": "Object",
    "value": {
      "id": "/subscriptions/<subscription-id>/resourceGroups/parentGroup",
      "location": "chinaeast",
      "name": "parentGroup",
      "properties": {
        "provisioningState": "Succeeded"
      }
    }
  },
  "linkedRG": {
    "type": "Object",
    "value": {
      "id": "/subscriptions/<subscription-id>/resourceGroups/linkedGroup",
      "location": "chinaeast",
      "name": "linkedGroup",
      "properties": {
        "provisioningState": "Succeeded"
      }
    }
  },
  "parentRG": {
    "type": "Object",
    "value": {
      "id": "/subscriptions/<subscription-id>/resourceGroups/parentGroup",
      "location": "chinaeast",
      "name": "parentGroup",
      "properties": {
        "provisioningState": "Succeeded"
      }
    }
  }
},
...
```

## Next steps

* To understand how to define parameters in your template, see [Understand the structure and syntax of Azure Resource Manager templates](resource-group-authoring-templates.md).
* For tips on resolving common deployment errors, see [Troubleshoot common Azure deployment errors with Azure Resource Manager](resource-manager-common-deployment-errors.md).
* For information about deploying a template that requires a SAS token, see [Deploy private template with SAS token](resource-manager-powershell-sas-token.md).

<!-- Update_Description: wording update, update meta properties, update link -->