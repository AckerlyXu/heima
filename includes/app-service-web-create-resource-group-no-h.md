
[!INCLUDE [resource group intro text](resource-group.md)]

Create a resource group with the [`az group create`](/cli/group?view=azure-cli-latest#az_group_create) command. The following example creates a resource group named *myResourceGroup* in the *China North* location. To see all supported locations for App Service in **Free** tier, run the [`az appservice list-locations --sku F1`](/cli/appservice?view=azure-cli-latest#az_appservice_list_locations) command.

```azurecli
az group create --name myResourceGroup --location "China North"
```

You generally create your resource group and the resources in a region near you. 

When the command finishes, a JSON output shows you the resource group properties.