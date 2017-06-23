## Log in to Azure

You'll use the Azure CLI 2.0 to create the resources needed to host your app in Azure. Log in to your Azure subscription with the [az login](https://docs.microsoft.com/cli/azure/#login) command and follow the on-screen directions.

```azurecli-interactive
az login
```

> [!NOTE]
> Before you can use Azure CLI 2.0 in Azure China, please run `az cloud set -n AzureChinaCloud` first to change the cloud environment. If you want to switch back to Global Azure, run `az cloud set -n AzureCloud` again.