---
title: Govern Azure virtual machines with Azure PowerShell | Azure
description: Tutorial - Manage Azure virtual machines by applying RBAC, polices, locks and tags with Azure PowerShell
services: virtual-machines-windows
documentationcenter: virtual-machines
author: rockboyfor
manager: digimobile
editor: tysonn

ms.service: virtual-machines-windows
ms.workload: infrastructure
ms.tgt_pltfrm: vm-windows
ms.devlang: na
ms.topic: article
origin.date: 02/21/2018
ms.date: 05/21/2018
ms.author: v-yeche

---
# Virtual machine governance with Azure PowerShell

[!INCLUDE [Resource Manager governance introduction](../../../includes/resource-manager-governance-intro.md)]



If you choose to install and use the PowerShell locally, see [Install Azure PowerShell module](https://docs.microsoft.com/powershell/azure/install-azurerm-ps). If you are running PowerShell locally, you also need to run `Login-AzureRmAccount -EnvironmentName AzureChinaCloud` to create a connection with Azure. For local installations, you must also [download the Azure AD PowerShell module](https://www.powershellgallery.com/packages/AzureAD/) to create a new Azure Active Directory group.

## Understand scope

[!INCLUDE [Resource Manager governance scope](../../../includes/resource-manager-governance-scope.md)]

In this tutorial, you apply all management settings to a resource group so you can easily remove those settings when done.

Let's create that resource group.

```azurepowershell-interactive
New-AzureRmResourceGroup -Name myResourceGroup -Location ChinaEast
```

Currently, the resource group is empty.

## Role-based access control

You want to make sure users in your organization have the right level of access to these resources. You don't want to grant unlimited access to users, but you also need to make sure they can do their work. [Role-based access control](../../role-based-access-control/overview.md) enables you to manage which users have permission to complete specific actions at a scope.

To create and remove role assignments, users must have `Microsoft.Authorization/roleAssignments/*` access. This access is granted through the Owner or User Access Administrator roles.

For managing virtual machine solutions, there are three resource-specific roles that provide commonly needed access:

* [Virtual Machine Contributor](../../role-based-access-control/built-in-roles.md#virtual-machine-contributor)
* [Network Contributor](../../role-based-access-control/built-in-roles.md#network-contributor)
* [Storage Account Contributor](../../role-based-access-control/built-in-roles.md#storage-account-contributor)

Instead of assigning roles to individual users, it's often easier to [create an Azure Active Directory group](../../active-directory/active-directory-groups-create-azure-portal.md) for users who need to take similar actions. Then, assign that group to the appropriate role. To simplify this article, you create an Azure Active Directory group without members. You can still assign this group to a role for a scope. 

The following example creates an Azure Active Directory group named *VMDemoContributors* with a mail nickname of *vmDemoGroup*. The mail nickname serves as an alias for the group.

```azurepowershell-interactive
$adgroup = New-AzureADGroup -DisplayName VMDemoContributors `
  -MailNickName vmDemoGroup `
  -MailEnabled $false `
  -SecurityEnabled $true
```

It takes a moment after the command prompt returns for the group to propagate throughout Azure Active Directory. After waiting for 20 or 30 seconds, use the [New-AzureRmRoleAssignment](https://docs.microsoft.com/powershell/module/azurerm.resources/new-azurermroleassignment) command to assign the new Azure Active Directory group to the Virtual Machine Contributor role for the resource group.  If you run the following command before it has propagated, you receive an error stating **Principal <guid> does not exist in the directory**. Try running the command again.

```azurepowershell-interactive
New-AzureRmRoleAssignment -ObjectId $adgroup.ObjectId `
  -ResourceGroupName myResourceGroup `
  -RoleDefinitionName "Virtual Machine Contributor"
```

Typically, you repeat the process for *Network Contributor* and *Storage Account Contributor* to make sure users are assigned to manage the deployed resources. In this article, you can skip those steps.

<!-- Not Avaiable on ## Azure policies -->
<!-- Not Avaiable on ### Apply policies -->

## Deploy the virtual machine

You have assigned roles and policies, so you're ready to deploy your solution. The default size is Standard_DS1_v2, which is one of your allowed SKUs. When running this step, you are prompted for credentials. The values that you enter are configured as the user name and password for the virtual machine.

```azurepowershell-interactive
New-AzureRmVm -ResourceGroupName "myResourceGroup" `
     -Name "myVM" `
     -Location "China East" `
     -VirtualNetworkName "myVnet" `
     -SubnetName "mySubnet" `
     -SecurityGroupName "myNetworkSecurityGroup" `
     -PublicIpAddressName "myPublicIpAddress" `
     -OpenPorts 80,3389
```

After your deployment finishes, you can apply more management settings to the solution.

## Lock resources

[Resource locks](../../azure-resource-manager/resource-group-lock-resources.md) prevent users in your organization from accidentally deleting or modifying critical resources. Unlike role-based access control, resource locks apply a restriction across all users and roles. You can set the lock level to *CanNotDelete* or *ReadOnly*.

To lock the virtual machine and network security group, use the [New-AzureRmResourceLock](https://docs.microsoft.com/powershell/module/azurerm.resources/new-azurermresourcelock) command:

```azurepowershell-interactive
# Add CanNotDelete lock to the VM
New-AzureRmResourceLock -LockLevel CanNotDelete `
  -LockName LockVM `
  -ResourceName myVM `
  -ResourceType Microsoft.Compute/virtualMachines `
  -ResourceGroupName myResourceGroup

# Add CanNotDelete lock to the network security group
New-AzureRmResourceLock -LockLevel CanNotDelete `
  -LockName LockNSG `
  -ResourceName myNetworkSecurityGroup `
  -ResourceType Microsoft.Network/networkSecurityGroups `
  -ResourceGroupName myResourceGroup
```

To test the locks, try running the following command:

```azurepowershell-interactive 
Remove-AzureRmResourceGroup -Name myResourceGroup
```

You see an error stating that the delete operation cannot be performed because of a lock. The resource group can only be deleted if you specifically remove the locks. That step is shown in [Clean up resources](#clean-up-resources).

## Tag resources

You apply [tags](../../azure-resource-manager/resource-group-using-tags.md) to your Azure resources to logically organize them by categories. Each tag consists of a name and a value. For example, you can apply the name "Environment" and the value "Production" to all the resources in production.

[!INCLUDE [Resource Manager governance tags Powershell](../../../includes/resource-manager-governance-tags-powershell.md)]

To apply tags to a virtual machine, use the [Set-AzureRmResource](https://docs.microsoft.com/powershell/module/azurerm.resources/set-azurermresource) command:

```azurepowershell-interactive
# Get the virtual machine
$r = Get-AzureRmResource -ResourceName myVM `
  -ResourceGroupName myResourceGroup `
  -ResourceType Microsoft.Compute/virtualMachines

# Apply tags to the virtual machine
Set-AzureRmResource -Tag @{ Dept="IT"; Environment="Test"; Project="Documentation" } -ResourceId $r.ResourceId -Force
```

### Find resources by tag

To find resources with a tag name and value, use the [Find-AzureRmResource](https://docs.microsoft.com/powershell/module/azurerm.resources/find-azurermresource) command:

```azurepowershell-interactive
(Find-AzureRmResource -TagName Environment -TagValue Test).Name
```

You can use the returned values for management tasks like stopping all virtual machines with a tag value.

```azurepowershell-interactive
Find-AzureRmResource -TagName Environment -TagValue Test | Where-Object {$_.ResourceType -eq "Microsoft.Compute/virtualMachines"} | Stop-AzureRmVM
```

### View costs by tag values

[!INCLUDE [Resource Manager governance tags billing](../../../includes/resource-manager-governance-tags-billing.md)]

## Clean up resources

The locked network security group can't be deleted until the lock is removed. To remove the lock, use the [Remove-AzureRmResourceLock](https://docs.microsoft.com/powershell/module/azurerm.resources/remove-azurermresourcelock) command:

```azurepowershell-interactive
Remove-AzureRmResourceLock -LockName LockVM `
  -ResourceName myVM `
  -ResourceType Microsoft.Compute/virtualMachines `
  -ResourceGroupName myResourceGroup
Remove-AzureRmResourceLock -LockName LockNSG `
  -ResourceName myNetworkSecurityGroup `
  -ResourceType Microsoft.Network/networkSecurityGroups `
  -ResourceGroupName myResourceGroup
```

When no longer needed, you can use the [Remove-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/remove-azurermresourcegroup) command to remove the resource group, VM, and all related resources.

```azurepowershell-interactive
Remove-AzureRmResourceGroup -Name myResourceGroup
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
<!-- Update_Description: update meta properties, update link -->