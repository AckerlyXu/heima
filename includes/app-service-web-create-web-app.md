## Create a web app

Create a [web app](../articles/app-service-web/app-service-web-overview.md) in the `myAppServicePlan` App Service plan with the [az appservice web create](https://docs.microsoft.com/cli/azure/webapp#create) command. 

The web app provides a hosting space for your code and provides a URL to view the deployed app.

In the following command, replace *\<app_name>* with a unique name. If `<app_name>` is not unique, you get the error message "Website with given name <app_name> already exists." The default URL of the web app is `https://<app_name>.chinacloudsites.cn`. 

```azurecli-interactive
az webapp create --name <app_name> --resource-group myResourceGroup --plan myAppServicePlan
```

When the web app has been created, the Azure CLI shows information similar to the following example:

```json
{
  "availabilityState": "Normal",
  "clientAffinityEnabled": true,
  "clientCertEnabled": false,
  "cloningInfo": null,
  "containerSize": 0,
  "dailyMemoryTimeQuota": 0,
  "defaultHostName": "<app_name>.chinacloudsites.cn",
  "enabled": true,
  "enabledHostNames": [
    "<app_name>.chinacloudsites.cn",
    "<app_name>.scm.chinacloudsites.cn"
  ],
  "gatewaySiteName": null,
  "hostNameSslStates": [
    {
      "hostType": "Standard",
      "name": "<app_name>.chinacloudsites.cn",
      "sslState": "Disabled",
      "thumbprint": null,
      "toUpdate": null,
      "virtualIp": null
    }
    < JSON data removed for brevity. >
}
```

Browse to the site to see your newly created web app.

```bash
http://<app_name>.chinacloudsites.cn
```