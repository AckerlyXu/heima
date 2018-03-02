Create a resource group with the [az group create](https://docs.azure.cn/zh-cn/cli/webapp?view=azure-cli-latest#az_webapp_create) command.

[!INCLUDE [resource group intro text](resource-group.md)]

The following example creates a resource group named *myResourceGroup* in the *chinanorth* location. To see all supported locations for App Service, run the `az appservice list-locations` command.

```azurecli
az group create --name myResourceGroup --location chinanorth
```

You generally create your resource group and the resources in a region near you. 

When the command finishes, a JSON output shows you the resource group properties.