---
title: Azure CLI Script Sample - Encrypt a Windows VM | Azure
description: Azure CLI Script Sample - Encrypt a Windows VM 
services: virtual-machines-windows
documentationcenter: virtual-machines
author: rockboyfor
manager: digimobile
editor: tysonn
tags: azure-resource-manager

ms.assetid:
ms.service: virtual-machines-windows
ms.devlang: azurecli
ms.topic: sample
ms.tgt_pltfrm: vm-windows
ms.workload: infrastructure
origin.date: 12/15/2017
ms.date: 04/16/2018
ms.author: v-yeche
---

# Encrypt a Windows virtual machine in Azure

This script creates a secure Azure Key Vault, encryption keys, Azure Active Directory service principal, and a Windows virtual machine (VM). The VM is then encrypted using the encryption key from Key Vault and service principal credentials.

[!INCLUDE [sample-cli-install](../../../includes/sample-cli-install.md)]

[!INCLUDE [quickstarts-free-trial-note](../../../includes/quickstarts-free-trial-note.md)]

## Sample script

```azurecli
#!/bin/bash

# Provide your own unique Key Vault name
keyvault_name=<your_unique_keyvault_name>

# Register the Key Vault provider and create a resource group.
az provider register -n Microsoft.KeyVault
az group create --name myResourceGroup --location chinaeast

# Create a Key Vault for storing keys and enabled for disk encryption.
az keyvault create --name $keyvault_name --resource-group myResourceGroup --location chinaeast \
    --enabled-for-disk-encryption True

# Create a key within the Key Vault.
az keyvault key create --vault-name $keyvault_name --name myKey --protection software

# Create an Azure Active Directory service principal for authenticating requests to Key Vault.
# Read in the service principal ID and password for use in later commands.
read sp_id sp_password <<< $(az ad sp create-for-rbac --query [appId,password] -o tsv)

# Grant permissions on the Key Vault to the AAD service principal.
az keyvault set-policy --name $keyvault_name --spn $sp_id \
    --key-permissions all \
    --secret-permissions all

# Create a virtual machine.
az vm create \
    --resource-group myResourceGroup \
    --name myVM \
    --name myVM --image win2016datacenter \
    --admin-username azureuser \
    --admin-password myPassword12

# Encrypt the VM disks.
az vm encryption enable --resource-group myResourceGroup --name myVM \
  --aad-client-id $sp_id \
  --aad-client-secret $sp_password \
  --disk-encryption-keyvault $keyvault_name \
  --key-encryption-key myKey \
  --volume-type all

# Output how to monitor the encryption status and next steps.
echo "The encryption process can take some time. View status with:

    az vm encryption show --resource-group myResourceGroup --name myVM --query [osDisk] -o tsv

When encryption status shows \`Encrypted\`, restart the VM with:

    az vm restart --resource-group myResourceGroup --name myVM"
```

## Clean up deployment 

Run the following command to remove the resource group, VM, and all related resources.

```azurecli
az group delete --name myResourceGroup
```

## Script explanation

This script uses the following commands to create a resource group, Azure Key Vault, service principal, virtual machine, and all related resources. Each command in the table links to command specific documentation.

| Command | Notes |
|---|---|
| [az group create](https://docs.azure.cn/zh-cn/cli/group?view=azure-cli-latest#az_group_create) | Creates a resource group in which all resources are stored. |
| [az keyvault create](https://docs.azure.cn/zh-cn/cli/keyvault?view=azure-cli-latest#az_keyvault_create) | Creates an Azure Key Vault to store secure data such as encryption keys. |
| [az keyvault key create](https://docs.azure.cn/zh-cn/cli/keyvault/key?view=azure-cli-latest#az_keyvault_key_create) | Creates an encryption key in Key Vault. |
| [az ad sp create-for-rbac](https://docs.azure.cn/zh-cn/cli/ad/sp?view=azure-cli-latest#az_ad_sp_create_for_rbac) | Creates an Azure Active Directory service principal to securely authenticate and control access to encryption keys. |
| [az keyvault set-policy](https://docs.azure.cn/zh-cn/cli/keyvault?view=azure-cli-latest#az_keyvault_set_policy) | Sets permissions on the Key Vault to grant the service principal access to encryption keys. |
| [az vm create](https://docs.azure.cn/zh-cn/cli/vm?view=azure-cli-latest#az_vm_create) | Creates the virtual machine and connects it to the network card, virtual network, subnet, and NSG. This command also specifies the virtual machine image to be used, and administrative credentials.  |
| [az vm encryption enable](https://docs.azure.cn/zh-cn/cli/vm/encryption?view=azure-cli-latest#az_vm_encryption_enable) | Enables encryption on a VM using the service principal credentials and encryption key. |
| [az vm encryption show](https://docs.azure.cn/zh-cn/cli/vm/encryption?view=azure-cli-latest#az_vm_encryption_show) | Shows the status of the VM encryption process. |
| [az group delete](https://docs.azure.cn/zh-cn/cli/vm/extension?view=azure-cli-latest#az_vm_extension_set) | Deletes a resource group including all nested resources. |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.azure.cn/zh-cn/cli/overview?view=azure-cli-latest).

Additional virtual machine CLI script samples can be found in the [Azure Windows VM documentation](../windows/cli-samples.md?toc=%2fvirtual-machines%windows%2ftoc.json).

<!--Update_Description: update meta propreties, wording update -->