---
title: Deployment FAQs for Azure web apps | Azure
description: Get answers to frequently asked questions about deployment for the Web Apps feature of Azure App Service.
services: app-service\web
documentationcenter: ''
author: genlin
manager: cshepard
editor: ''
tags: top-support-issue

ms.assetid: 2fa5ee6b-51a6-4237-805f-518e6c57d11b
ms.service: app-service-web
ms.workload: web
ms.tgt_pltfrm: ibiza
ms.devlang: na
ms.topic: article
origin.date: 07/10/2017
ms.date: 10/09/2017
ms.author: v-yiso

---
# Deployment FAQs for Web Apps in Azure

This article has answers to frequently asked questions (FAQs) about deployment issues for the [Web Apps feature of Azure App Service](https://www.azure.cn/home/features/app-service/web-apps/).

[!INCLUDE [support-disclaimer](../../includes/support-disclaimer.md)]

## I am just getting started with App Service web apps. How do I publish my code?

Here are some options for publishing your web app code:

*   Deploy by using Visual Studio. If you have the Visual Studio solution, right-click the web application project, and then select **Publish**.
*   Deploy by using an FTP client. In the Azure portal, download the publish profile for the web app that you want to deploy your code to. Then, upload the files to \site\wwwroot by using the same publish profile FTP credentials.

For more information, see [Deploy your app to App Service](web-sites-deploy.md).

## I see an error message when I try to deploy from Visual Studio. How do I resolve this?

If you see the following message, you might be using an older version of the SDK: "Error during deployment for resource 'YourResourceName' in resource group 'YourResourceGroup': MissingRegistrationForLocation: The subscription is not registered for the resource type 'components' in the location 'China North'. Please re-register for this provider in order to have access to this location." 

To resolve this error, upgrade to the [latest SDK](/downloads/). If you see this message and you have the latest SDK, submit a support request.

## How do I deploy an ASP.NET application from Visual Studio to App Service?
<a id="deployasp"></a>

The tutorial [Create your first ASP.NET web app in Azure in five minutes](/app-service-web/web-sites-dotnet-get-started/) shows you how to deploy an ASP.NET web application to a web app in App Service by using Visual Studio 2015.

## What are the different types of deployment credentials?

App Service supports two types of credentials for local Git deployment and FTP/S deployment. For more information about how to configure deployment credentials, see [Configure deployment credentials for App Service](app-service-deployment-credentials.md).

## What is the file or directory structure of my App Service web app?

For information about the file structure of your App Service app, see [File structure in Azure](https://github.com/projectkudu/kudu/wiki/File-structure-on-azure).

## How do I resolve "FTP Error 550 - There is not enough space on the disk" when I try to FTP my files?

If you see this message, it's likely that you are running into a disk quota in the service plan for your web app. You might need to scale up to a higher service tier based on your disk space needs. For more information about pricing plans and resource limits, see [App Service pricing](https://www.azure.cn/pricing/details/app-service/).

## How do I set up continuous deployment for my App Service web app?

You can set up continuous deployment from GitHub. [Continuous deployment to App Service](app-service-continuous-deployment.md) is a helpful tutorial that explains how to set up continuous deployment.

## How do I troubleshoot issues with continuous deployment from GitHub?

For help investigating issues with continuous deployment from GitHub, see [Investigating continuous deployment](https://github.com/projectkudu/kudu/wiki/Investigating-continuous-deployment).

## I can't FTP to my site and publish my code. How do I resolve this?

To resolve FTP issues:

1. Verify that you are entering the correct host name and credentials. For detailed information about different types of credentials and how to use them, see [Deployment credentials](https://github.com/projectkudu/kudu/wiki/Deployment-credentials).
2. Verify that the FTP ports are not blocked by a firewall. The ports should have these settings:
    * FTP control connection port: 21
    * FTP data connection port: 989, 10001-10300

## How do I publish my code to App Service?

The Azure Quickstart is designed to help you deploy your app by using the deployment stack and method of your choice. To use the Quickstart, in the Azure portal, go to **Settings** > **App Deployment**.

## Why does my app sometimes restart after deployment to App Service?

To learn about the circumstances under which an application deployment might result in a restart, see [Deployment vs. runtime issues](https://github.com/projectkudu/kudu/wiki/Deployment-vs-runtime-issues#deployments-and-web-app-restarts"). As the article describes, App Service deploys files to the wwwroot folder. It never directly restarts your app.

## How do I use FTP or FTPS to deploy my app to App Service?

For information about using FTP or FTPS to deploy your web app to App Service, see [Deploy your app to App Service by using FTP/S](app-service-deploy-ftp.md).

<!--Update_Description: update meta data-->