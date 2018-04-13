## Create a resource group

Create a resource group with the [az group create](/cli/group#az_group_create). An Azure resource group is a logical container into which Azure resources like function apps, databases, and storage accounts are deployed and managed.

The following example creates a resource group named `myResourceGroup`.  

```azurecli
az cloud set -n AzureChinaCloud
az login
az group create --name myResourceGroup --location chinanorth
```
You generally create your resource group and the resources in a region near you. To see all supported locations for App Service plans, run the [az appservice list-locations](/cli/appservice#az_appservice_list_locations) command.

