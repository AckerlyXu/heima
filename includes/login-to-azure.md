## Log in to Azure

You'll use the Azure CLI 2.0 to create the resources needed to host your app in Azure. Log in to your Azure subscription with the [az login](https://docs.microsoft.com/cli/azure/#login) command and follow the on-screen directions.

```azurecli-interactive
az login
```

> [!NOTE]
> Before you can use Azure CLI 2.0 in Azure China, you need to modify the Azure config file. Run `az configure` to check the path of the config file which usually looks like `C:\Users\<user name>\.azure\config` in Windows and `/var/users/<username>/.azure/config` in Linux. Open the file, and replace `AzureCloud` with `AzureChinaCloud`.