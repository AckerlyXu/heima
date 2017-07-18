Create a resource group with the [az group create](https://docs.microsoft.com/cli/azure/group#create) command.

[!INCLUDE [resource group intro text](resource-group.md)]

The following example creates a resource group named *myResourceGroup* in the *chinanorth* location.

```azurecli
az group create --name myResourceGroup --location chinanorth
```

To see the available locations, run the `az appservice list-locations` command. You generally create resources in a region near you.