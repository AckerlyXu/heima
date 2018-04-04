---
title: Govern Azure virtual machines with Azure CLI | Azure
description: Tutorial - Manage Azure virtual machines by applying RBAC, polices, locks and tags with Azure CLI
services: virtual-machines-linux
documentationcenter: virtual-machines
author: rockboyfor
manager: digimobile
editor: tysonn

ms.service: virtual-machines-linux
ms.workload: infrastructure
ms.tgt_pltfrm: vm-linux
ms.devlang: na
ms.topic: article
origin.date: 02/21/2018
ms.date: 03/19/2018
ms.author: v-yeche

---
# Virtual machine governance with Azure CLI

[!include[Resource Manager governance introduction](../../../includes/resource-manager-governance-intro.md)]

[!INCLUDE [azure-cli-2-azurechinacloud-environment-parameter](../../../includes/azure-cli-2-azurechinacloud-environment-parameter.md)]

To install and use the CLI locally, see [Install Azure CLI 2.0](https://docs.azure.cn/zh-cn/cli/install-azure-cli?view=azure-cli-latest).

## Understand scope

[!include[Resource Manager governance scope](../../../includes/resource-manager-governance-scope.md)]

In this tutorial, you apply all management settings to a resource group so you can easily remove those settings when done.

Let's create that resource group.

```azurecli
az group create --name myResourceGroup --location "China East"
```

Currently, the resource group is empty.

## Role-based access control

You want to make sure users in your organization have the right level of access to these resources. You don't want to grant unlimited access to users, but you also need to make sure they can do their work. [Role-based access control](../../active-directory/role-based-access-control-what-is.md) enables you to manage which users have permission to complete specific actions at a scope.

To create and remove role assignments, users must have `Microsoft.Authorization/roleAssignments/*` access. This access is granted through the Owner or User Access Administrator roles.

For managing virtual machine solutions, there are three resource-specific roles that provide commonly needed access:

* [Virtual Machine Contributor](../../active-directory/role-based-access-built-in-roles.md#virtual-machine-contributor)
* [Network Contributor](../../active-directory/role-based-access-built-in-roles.md#network-contributor)
* [Storage Account Contributor](../../active-directory/role-based-access-built-in-roles.md#storage-account-contributor)

Instead of assigning roles to individual users, it's often easier to [create an Azure Active Directory group](../../active-directory/active-directory-groups-create-azure-portal.md) for users who need to take similar actions. Then, assign that group to the appropriate role. To simplify this article, you create an Azure Active Directory group without members. You can still assign this group to a role for a scope. 

The following example creates an Azure Active Directory group named *VMDemoContributors* with a mail nickname of *vmDemoGroup*. The mail nickname serves as an alias for the group.

```azurecli
adgroupId=$(az ad group create --display-name VMDemoContributors --mail-nickname vmDemoGroup --query objectId --output tsv)
```

It takes a moment after the command prompt returns for the group to propagate throughout Azure Active Directory. After waiting for 20 or 30 seconds, use the [az role assignment create](https://docs.azure.cn/zh-cn/cli/role/assignment?view=azure-cli-latest#az_role_assignment_create) command to assign the new Azure Active Directory group to the Virtual Machine Contributor role for the resource group.  If you run the following command before it has propagated, you receive an error stating **Principal <guid> does not exist in the directory**. Try running the command again.

```azurecli
az role assignment create --assignee-object-id $adgroupId --role "Virtual Machine Contributor" --resource-group myResourceGroup
```

Typically, you repeat the process for *Network Contributor* and *Storage Account Contributor* to make sure users are assigned to manage the deployed resources. In this article, you can skip those steps.

<!-- Not Avaiable on ## Azure policies -->
<!-- Not Avaiable on ### Apply policies -->

## Deploy the virtual machine

You have assigned roles and policies, so you're ready to deploy your solution. The default size is Standard_DS1_v2, which is one of your allowed SKUs. The command creates SSH keys if they do not exist in a default location.

```azurecli
az vm create --resource-group myResourceGroup --name myVM --image UbuntuLTS --generate-ssh-keys
```

After your deployment finishes, you can apply more management settings to the solution.

## Lock resources

[Resource locks](../../azure-resource-manager/resource-group-lock-resources.md) prevent users in your organization from accidentally deleting or modifying critical resources. Unlike role-based access control, resource locks apply a restriction across all users and roles. You can set the lock level to *CanNotDelete* or *ReadOnly*.

To create or delete management locks, you must have access to `Microsoft.Authorization/locks/*` actions. Of the built-in roles, only **Owner** and **User Access Administrator** are granted those actions.

To lock the virtual machine and network security group, use the [az lock create](https://docs.azure.cn/zh-cn/cli/lock?view=azure-cli-latest#az_lock_create) command:

```azurecli
# Add CanNotDelete lock to the VM
az lock create --name LockVM \
  --lock-type CanNotDelete \
  --resource-group myResourceGroup \
  --resource-name myVM \
  --resource-type Microsoft.Compute/virtualMachines

# Add CanNotDelete lock to the network security group
az lock create --name LockNSG \
  --lock-type CanNotDelete \
  --resource-group myResourceGroup \
  --resource-name myVMNSG \
  --resource-type Microsoft.Network/networkSecurityGroups
```

To test the locks, try running the following command:

```azurecli 
az group delete --name myResourceGroup
```

You see an error stating that the delete operation cannot be performed because of a lock. The resource group can only be deleted if you specifically remove the locks. That step is shown in [Clean up resources](#clean-up-resources).

## Tag resources

You apply [tags](../../azure-resource-manager/resource-group-using-tags.md) to your Azure resources to logically organize them by categories. Each tag consists of a name and a value. For example, you can apply the name "Environment" and the value "Production" to all the resources in production.

[!include[Resource Manager governance tags CLI](../../../includes/resource-manager-governance-tags-cli.md)]

To apply tags to a virtual machine, use the [az resource tag](https://docs.azure.cn/zh-cn/cli/resource?view=azure-cli-latest#az_resource_tag) command. Any existing tags on the resource are not retained.

```azurecli
az resource tag -n myVM \
  -g myResourceGroup \
  --tags Dept=IT Environment=Test Project=Documentation \
  --resource-type "Microsoft.Compute/virtualMachines"
```

### Find resources by tag

To find resources with a tag name and value, use the [az resource list](https://docs.azure.cn/zh-cn/cli/resource?view=azure-cli-latest#az_resource_list) command:

```azurecli
az resource list --tag Environment=Test --query [].name
```

You can use the returned values for management tasks like stopping all virtual machines with a tag value.

```azurecli
az vm stop --ids $(az resource list --tag Environment=Test --query "[?type=='Microsoft.Compute/virtualMachines'].id" --output tsv)
```

<!-- Not Available on ### View costs by tag values -->

<!-- [!include[Resource Manager governance tags billing](../../../includes/resource-manager-governance-tags-billing.md)] -->

## Clean up resources

The locked network security group can't be deleted until the lock is removed. To remove the lock, retrieve the IDs of the locks and provide them to the [az lock delete](https://docs.azure.cn/zh-cn/cli/lock?view=azure-cli-latest#az_lock_delete) command:

```azurecli
vmlock=$(az lock show --name LockVM \
  --resource-group myResourceGroup \
  --resource-type Microsoft.Compute/virtualMachines \
  --resource-name myVM --output tsv --query id)
nsglock=$(az lock show --name LockNSG \
  --resource-group myResourceGroup \
  --resource-type Microsoft.Network/networkSecurityGroups \
  --resource-name myVMNSG --output tsv --query id)
az lock delete --ids $vmlock $nsglock
```

When no longer needed, you can use the [az group delete](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az_group_delete) command to remove the resource group, VM, and all related resources. Exit the SSH session to your VM, then delete the resources as follows:

```azurecli 
az group delete --name myResourceGroup
```

## Next steps

In this tutorial, you created a custom VM image. You learned how to:

> [!div class="checklist"]
> * Assign users to a role
> * Apply policies that enforce standards
> * Protect critical resources with locks
> * Tag resources for billing and management

Advance to the next tutorial to learn about how highly available virtual machines.

> [!div class="nextstepaction"]
> [Monitor virtual machines](tutorial-monitoring.md)

<!--The parent file of includes file of resource-manager-governance-tags-cli.md-->
<!--ms.date:03/05/2018-->
