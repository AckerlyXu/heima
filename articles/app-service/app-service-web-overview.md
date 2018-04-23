---
title: Web Apps overview | Azure
description: Learn how Azure App Service helps you develop and host web applications
services: app-service\web
documentationcenter: ''
author: cephalin
manager: erikre
editor: ''

ms.assetid: 94af2caf-a2ec-4415-a097-f60694b860b3
ms.service: app-service-web
ms.workload: web
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: overview
origin.date: 01/04/2017
ms.date: 04/30/2018
ms.author: v-yiso
ms.custom: mvc
---
# Web Apps overview

*Azure App Service Web Apps* (or just Web Apps) is a service for hosting web applications, REST APIs, and mobile back ends. You can develop in your favorite language, be it .NET, .NET Core, Java, Ruby, Node.js, PHP, or Python. 

Web Apps not only adds the power of Microsoft Azure to your application, such as security, load balancing, autoscaling, and automated management. You can also take advantage of its DevOps capabilities, such as continuous deployment from VSTS, GitHub, Docker Hub, and other sources, package management, staging environments, custom domain, and SSL certificates. 

With App Service, you pay for the Azure compute resources you use. The compute resources you use is determined by the _App Service plan_ that you run your Web Apps on. For more information, see [App Service plans in Azure Web Apps](azure-web-sites-web-hosting-plans-in-depth-overview.md).


## Why use Web Apps?
Here are some key features of App Service Web Apps:

* **Multiple languages and frameworks** - Web Apps has first-class support for ASP.NET, ASP.NET Core, Java, Ruby, Node.js, PHP, or Python. You can also run [PowerShell and other scripts or executables](web-sites-create-web-jobs.md) as background services.
* **DevOps optimization** - Set up [continuous integration and deployment](app-service-continuous-deployment.md) with Visual Studio Team Services, GitHub, or BitBucket. Promote updates through [test and staging environments](web-sites-staged-publishing.md). Manage your apps in Web Apps by using [Azure PowerShell](/powershell/azureps-cmdlets-docs) or the [cross-platform command-line interface (CLI)](https://docs.azure.cn/zh-cn/cli/install-azure-cli?view=azure-cli-lastest).
* **Global scale with high availability** - Scale [up](web-sites-scale.md) or [out](../monitoring-and-diagnostics/insights-how-to-scale.md) manually or automatically. Host your apps anywhere in Azure.cn's national datacenter infrastructure, and the App Service [SLA](https://www.azure.cn/support/sla/app-service/) promises high availability.
* **Visual Studio integration** - Dedicated tools in Visual Studio streamline the work of creating, deploying, and debugging.
* **API and mobile features** - Web Apps provides turn-key CORS support for RESTful API scenarios, and simplifies mobile app scenarios by enabling authentication, offline data sync, push notifications, and more.

Besides Web Apps in App Service, Azure offers other services that can be used for hosting websites and web applications. For most scenarios, Web Apps is the best choice.  For microservice architecture, consider [Service Fabric](/service-fabric). If you need more control over the VMs that your code runs on, consider [Azure Virtual Machines](/virtual-machines/). For more information about how to choose between these Azure services, see [Azure App Service, Virtual Machines, Service Fabric, and Cloud Services comparison](choose-web-site-cloud-service-vm.md).

## Next steps

Create your first web app.

> [!div class="nextstepaction"]
> [ASP.NET](app-service-web-get-started-dotnet.md)

> [!div class="nextstepaction"]
> [PHP](app-service-web-get-started-php.md)

> [!div class="nextstepaction"]
> [Node.js](app-service-web-get-started-nodejs.md)

> [!div class="nextstepaction"]
> [Java](app-service-web-get-started-java.md)

> [!div class="nextstepaction"]
> [Python](app-service-web-get-started-python.md)

> [!div class="nextstepaction"]
> [HTML](app-service-web-get-started-html.md)

