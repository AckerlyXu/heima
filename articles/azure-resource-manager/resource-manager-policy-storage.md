<properties
    pageTitle="Azure resource policies for storage accounts | Azure"
    description="Describes Azure Resource Manager policies for managing the deployment of storage accounts."
    services="azure-resource-manager"
    documentationcenter="na"
    author="tfitzmac"
    manager="timlt"
    editor="tysonn" />
<tags
    ms.assetid=""
    ms.service="azure-resource-manager"
    ms.devlang="na"
    ms.topic="article"
    ms.tgt_pltfrm="na"
    ms.workload="na"
    ms.date="02/09/2017"
    wacn.date=""
    ms.author="tomfitz" />

# Apply resource policies to storage accounts
This topic shows several [resource policies](/documentation/articles/resource-manager-policy/) you can apply to Azure storage accounts. These policies ensure consistency for the storage accounts deployed in your organization. 

## Define permitted storage account types

The following policy restricts which [storage account types](/documentation/articles/storage-redundancy/) can be deployed:

    {
      "if": {
        "allOf": [
          {
            "field": "type",
            "equals": "Microsoft.Storage/storageAccounts"
          },
          {
            "not": {
              "field": "Microsoft.Storage/storageAccounts/sku.name",
              "in": [
                "Standard_LRS",
                "Standard_GRS"
              ]
            }
          }
        ]
      },
      "then": {
        "effect": "deny"
      }
    }

A similar policy rule with a parameter for accepting the allowed SKUs is available as a built-in policy definition. The built-in policy has the resource ID of `/providers/Microsoft.Authorization/policyDefinitions/7433c107-6db4-4ad1-b57a-a76dce0154a1`. 

## Define permitted access tier

The following policy specifies the type of [access tier](/documentation/articles/storage-blob-storage-tiers/) that can be specified for storage accounts:

    {
      "if": {
        "allOf": [
          {
            "field": "type",
            "equals": "Microsoft.Storage/storageAccounts"
          },
          {
            "field": "kind",
            "equals": "BlobStorage"
          },
          {
            "not": {
              "field": "Microsoft.Storage/storageAccounts/accessTier",
              "equals": "cool"
            }
          }
        ]
      },
      "then": {
        "effect": "deny"
      }
    }

## Ensure encryption is enabled

The following policy requires all storage accounts to enable [Storage service encryption](/documentation/articles/storage-service-encryption/):

    {
      "if": {
        "allOf": [
          {
            "field": "type",
            "equals": "Microsoft.Storage/storageAccounts"
          },
          {
            "not": {
              "field": "Microsoft.Storage/storageAccounts/enableBlobEncryption",
              "equals": "true"
            }
          }
        ]
      },
      "then": {
        "effect": "deny"
      }
    }

This policy rule is also available as a built-in policy definition with the resource ID of `/providers/Microsoft.Authorization/policyDefinitions/7c5a74bf-ae94-4a74-8fcf-644d1e0e6e6f`.

## Next steps
* After defining a policy rule (as shown in the preceding examples), you need to create the policy definition and assign it to a scope. The scope can be a subscription, resource group, or resource. For examples on creating and assigning policies, see [Assign and manage policies](/documentation/articles/resource-manager-policy-create-assign/). 
* For guidance on how enterprises can use Resource Manager to effectively manage subscriptions, see [Azure enterprise scaffold - prescriptive subscription governance](/documentation/articles/resource-manager-subscription-governance/).