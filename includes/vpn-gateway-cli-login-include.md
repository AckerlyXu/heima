Log in to your Azure subscription with the [az login](https://docs.microsoft.com/cli/azure/#login) command and follow the on-screen directions. For more information about logging in, see [Get Started with Azure CLI 2.0](https://docs.microsoft.com/cli/azure/get-started-with-azure-cli).

```azurecli
az login
```

> [!NOTE]
> Before you can use Azure CLI 2.0 in Azure China, you need to modify the Azure config file. Run `az configure` to check the path of the config file which usually looks like `C:\Users\<user name>\.azure\config` in Windows and `/var/users/<username>/.azure/config` in Linux. Open the file, and replace `AzureCloud` with `AzureChinaCloud`.

If you have more than one Azure subscription, list the subscriptions for the account.

```azurecli
az account list --all
```

Specify the subscription that you want to use.

```azurecli
az account set --subscription <replace_with_your_subscription_id>
```