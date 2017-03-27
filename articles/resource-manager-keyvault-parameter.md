<properties
   pageTitle="Use Key Vault secret with Resource Manager template | Windows Azure"
   description="Shows how to pass a secret from a key vault as a parameter during deployment."
   services="azure-resource-manager,key-vault"
   documentationCenter="na"
   authors="tfitzmac"
   manager="timlt"
   editor="tysonn"/>

<tags
   ms.service="azure-resource-manager"
   ms.date="06/23/2016"
   wacn.date=""/>

# Pass secure values during deployment

When you need to pass a secure value (like a password) as a parameter during deployment, you can store that value as a secret in an [Azure Key Vault](/documentation/articles/key-vault-whatis/) and reference the value in other Resource Manager templates. You include only a reference to the secret 

## Deploy a key vault and secret

To create key vault that can be referenced from other Resource Manager templates, you must set the **enabledForTemplateDeployment** property to **true**, and you must grant access to the user or 
service principal that will execute the deployment which references the secret.

To learn about deploying a key vault and secret, see 
[Key vault schema](/documentation/articles/resource-manager-template-keyvault/) and [Key vault secret schema](/documentation/articles/resource-manager-template-keyvault-secret/).

## Reference a secret with static id

You reference the secret from within a parameters file which passes values to your template. You reference the secret by passing the resource identifier of the key vault and the name of the secret. In this example, the key vault secret must already exist, and you are using a static value for it resource id.

    "parameters": {
      "adminPassword": {
        "reference": {
          "keyVault": {
            "id": "/subscriptions/{guid}/resourceGroups/{group-name}/providers/Microsoft.KeyVault/vaults/{vault-name}"
          }, 
          "secretName": "sqlAdminPassword" 
        } 
      }
    }

An entire parameter file might look like:

    {
      "$schema": "http://schema.management.azure.com/schemas/2015-01-01/deploymentParameters.json#",
      "contentVersion": "1.0.0.0",
      "parameters": {
        "sqlsvrAdminLogin": {
          "value": ""
        },
        "sqlsvrAdminLoginPassword": {
          "reference": {
            "keyVault": {
              "id": "/subscriptions/{guid}/resourceGroups/{group-name}/providers/Microsoft.KeyVault/vaults/{vault-name}"
            },
            "secretName": "adminPassword"
          }
        }
      }
    }

The parameter that accepts the secret should be a **securestring**. The following example shows the relevant sections of a template that deploys a SQL server that requires an administrator password.

    {
        "$schema": "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
        "contentVersion": "1.0.0.0",
        "parameters": {
            "sqlsvrAdminLogin": {
                "type": "string",
                "minLength": 4
            },
            "sqlsvrAdminLoginPassword": {
                "type": "securestring"
            },
            ...
        },
        "resources": [
        {
            "name": "[variables('sqlsvrName')]",
            "type": "Microsoft.Sql/servers",
            "location": "[resourceGroup().location]",
            "apiVersion": "2014-04-01-preview",
            "properties": {
                "administratorLogin": "[parameters('sqlsvrAdminLogin')]",
                "administratorLoginPassword": "[parameters('sqlsvrAdminLoginPassword')]"
            },
            ...
        }],
        "variables": {
            "sqlsvrName": "[concat('sqlsvr', uniqueString(resourceGroup().id))]"
        },
        "outputs": { }
    }

## Reference a secret with dynamic id

The previous section showed how to pass a static resource id for the key vault secret. However, in some scenarios, you need to reference a key vault secret that varies based on the current deployment. In that case, you cannot hard-code the resource id in the parameters file. Unfortunately, you cannot dynamically generate the resource id in the parameters file because template expressions are not permitted in the parameters file.

To dynamically generate the resource id for a key vault secret, you must move the resource that needs the secret into a nested template. In your master template, you add the nested template and pass in a parameter that contains the dynamically generated resource id.

    {
      "$schema": "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
      "contentVersion": "1.0.0.0",
      "parameters": {
        "vaultName": {
          "type": "string"
        },
        "secretName": {
          "type": "string"
        }
      },
      "resources": [
        {
          "apiVersion": "2015-01-01",
          "name": "nestedTemplate",
          "type": "Microsoft.Resources/deployments",
          "properties": {
            "mode": "incremental",
            "templateLink": {
              "uri": "https://www.contoso.com/AzureTemplates/newVM.json",
              "contentVersion": "1.0.0.0"
            },
            "parameters": {
              "adminPassword": {
                "reference": {
                  "keyVault": {
                    "id": "[concat(resourceGroup().id, '/providers/Microsoft.KeyVault/vaults/', parameters('vaultName'))]"
                  },
                  "secretName": "[parameters('secretName')]"
                }
              }
            }
          }
        }
      ],
      "outputs": {}
    }


## Next steps

- For general information about key vaults, see [Get started with Azure Key Vault](/documentation/articles/key-vault-get-started/).
- For information about using a key vault with a Virtual Machine, see [Security considerations for Azure Resource Manager](/documentation/articles/best-practices-resource-manager-security/).
- For complete examples of referencing key secrets, see [Key Vault examples](https://github.com/rjmax/ArmExamples/tree/master/keyvaultexamples).

