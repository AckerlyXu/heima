Log in to your Azure subscription with the [az login](https://docs.microsoft.com/cli/azure/#login) command and follow the on-screen directions. For more information about logging in, see [Get Started with Azure CLI 2.0](https://docs.microsoft.com/cli/azure/get-started-with-azure-cli).

```azurecli
az login
```

> [!NOTE]
> Before you can use Azure CLI 2.0 in Azure China, please run `az cloud set -n AzureChinaCloud` first to change the cloud environment. If you want to switch back to Global Azure, run `az cloud set -n AzureCloud` again.

If you have more than one Azure subscription, list the subscriptions for the account.

```azurecli
az account list --all
```

Specify the subscription that you want to use.

```azurecli
az account set --subscription <replace_with_your_subscription_id>
```