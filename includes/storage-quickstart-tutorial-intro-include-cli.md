## Create a resource group

Create an Azure resource group with the [az group create](https://docs.azure.cn/cli/group#az_group_create) command. A resource group is a logical container into which Azure resources are deployed and managed.

```cli
az group create \
    --name myResourceGroup \
    --location "China East"
```

## Create a storage account

Create a general-purpose storage account with the [az storage account create](https://docs.azure.cn/cli/storage/account#create) command. The general-purpose storage account can be used for all four services: blobs, files, tables, and queues. 

```cli
az storage account create \
    --name mystorageaccount \
    --resource-group myResourceGroup \
    --location "China East" \
    --sku Standard_LRS \
    --encryption blob
```

## Specify storage account credentials

The Azure CLI needs your storage account credentials for most of the commands in this tutorial. While there are several options for doing so, one of the easiest ways to provide them is to set `AZURE_STORAGE_ACCOUNT` and `AZURE_STORAGE_ACCESS_KEY` environment variables.

First, display your storage account keys by using the [az storage account keys list](https://docs.azure.cn/cli/storage/account/keys#list) command:

```
az storage account keys list \
    --account-name mystorageaccount \
    --resource-group myResourceGroup \
    --output table
```

Now, set the `AZURE_STORAGE_ACCOUNT` and `AZURE_STORAGE_ACCESS_KEY` environment variables. You can do this in the Bash shell by using the `export` command:

```bash
export AZURE_STORAGE_ACCOUNT="mystorageaccountname"
export AZURE_STORAGE_ACCESS_KEY="myStorageAccountKey"
```