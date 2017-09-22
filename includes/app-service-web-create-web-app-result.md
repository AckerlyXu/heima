When the web app has been created, the Azure CLI shows output similar to the following example:

```json
Local git is configured with url of 'https://<username>@<app name>.scm.chinacloudsites.cn/<app name>.git'
{
  "availabilityState": "Normal",
  "clientAffinityEnabled": true,
  "clientCertEnabled": false,
  "cloningInfo": null,
  "containerSize": 0,
  "dailyMemoryTimeQuota": 0,
  "defaultHostName": "<app name>.chinacloudsites.cn",
  "deploymentLocalGitUrl": "https://<username>@<app name>.scm.chinacloudsites.cn/<app name>.git",
  "enabled": true,
  < JSON data removed for brevity. >
}
```

Browse to the site to see your newly created web app. Replace _&lt;app name>_ with a unique app name.

```bash
http://<app name>.chinacloudsites.cn
```
