Create an App Service plan in the resource group with the [az appservice plan create](https://docs.azure.cn/zh-cn/cli/webapp?view=azure-cli-latest#az_webapp_create) command.

<!-- [!INCLUDE [app-service-plan](app-service-plan-linux.md)] -->

The following example creates an App Service plan named `myAppServicePlan` in the **Standard** pricing tier and in a Linux container:

```azurecli
az appservice plan create --name myAppServicePlan --resource-group myResourceGroup --sku S1 --is-linux
```

When the App Service plan has been created, the Azure CLI shows information similar to the following example:

```json
{ 
  "adminSiteName": null,
  "appServicePlanName": "myAppServicePlan",
  "geoRegion": "China East",
  "hostingEnvironmentProfile": null,
  "id": "/subscriptions/0000-0000/resourceGroups/myResourceGroup/providers/Microsoft.Web/serverfarms/myAppServicePlan",
  "kind": "linux",
  "location": "China East",
  "maximumNumberOfWorkers": 1,
  "name": "myAppServicePlan",
  < JSON data removed for brevity. >
  "targetWorkerSizeId": 0,
  "type": "Microsoft.Web/serverfarms",
  "workerTierName": null
} 
```