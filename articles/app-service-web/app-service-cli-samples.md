<properties
    pageTitle="Azure CLI Samples - App Service | Azure"
    description="Azure CLI Samples - App Service"
    services="app-service"
    documentationcenter="app-service"
    author="syntaxc4"
    manager="erikre"
    editor="ggailey777"
    tags="azure-service-management" />
<tags
    ms.assetid="53e6a15a-370a-48df-8618-c6737e26acec"
    ms.service="app-service"
    ms.devlang="na"
    ms.topic="article"
    ms.tgt_pltfrm="na"
    ms.workload="app-service"
    ms.date="03/08/2017"
    wacn.date=""
    ms.author="cfowler" />

# Azure CLI Samples

The following table includes links to bash scripts built using the Azure CLI.

| | |
|-|-|
|**Create app**||
| [Create a web app and deploy code from GitHub](/documentation/articles/app-service-cli-deploy-github/)| Creates an Azure web app and deploys code from a public GitHub repository. |
| [Create a web app with continuous deployment from GitHub](/documentation/articles/app-service-cli-continuous-deployment-github/)| Creates an Azure web app with continuous publishing from a GitHub repository you own. |
| [Create a web app and deploy code from a local Git repository](/documentation/articles/app-service-cli-deploy-local-git/) | Creates an Azure web app and configures code push from a local Git repository. |
| [Create a web app and deploy code to a staging environment](/documentation/articles/app-service-cli-deploy-staging-environment/) | Creates an Azure web app with a deployment slot for staging code changes. |
| [Create an ASP.NET Core web app in a Docker container](/documentation/articles/app-service-cli-linux-docker-aspnetcore/)| Creates an Azure web app on Linux and loads a Docker image from Docker Hub. |
|**Configure app**||
| [Map a custom domain to a web app](/documentation/articles/app-service-cli-configure-custom-domain/)| Creates an Azure web app and maps a custom domain name to it. |
| [Bind a custom SSL certificate to a web app](/documentation/articles/app-service-cli-configure-ssl-certificate/)| Creates an Azure web app and binds the SSL certificate of a custom domain name to it. |
|**Scale app**||
| [Scale a web app manually](/documentation/articles/app-service-cli-scale-manual/) | Creates an Azure web app and scales it across 2 instances. |
| [Scale a web app nationwide with a high-availability architecture](/documentation/articles/app-service-cli-scale-high-availability/) | Creates two Azure web apps in two different geographical regions and makes them available through a single endpoint using Azure Traffic Manager. |
|**Connect app to resources**||
| [Connect a web app to a SQL Database](/documentation/articles/app-service-cli-app-service-sql/)| Creates an Azure web app and a SQL database, then adds the database connection string to the app settings. |
| [Connect a web app to a storage account](/documentation/articles/app-service-cli-app-service-storage/)| Creates an Azure web app and a storage account, then adds the storage connection string to the app settings. |
| [Connect a web app to a redis cache](/documentation/articles/app-service-cli-app-service-redis/) | Creates an Azure web app and a redis cache, then adds the redis connection details to the app settings.) |
| [Connect a web app to a documentdb](/documentation/articles/app-service-cli-app-service-documentdb/) | Creates an Azure web app and a documentdb, then adds the documentdb connection details to the app settings. |
|**Monitor app**||
| [Monitor a web app with web server logs](/documentation/articles/app-service-cli-monitor/) | Creates an Azure web app, enables logging for it, and downloads the logs to your local machine. |
| | |