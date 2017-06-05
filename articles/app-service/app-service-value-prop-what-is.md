<properties
    pageTitle="Azure App Service for web, mobile, and API apps | Azure"
    description="Learn how Azure App Service helps you develop, deploy, and manage web and mobile apps."
    keywords="app service, azure app service, app service cost, scale, scalable, app deployment, azure app deployment, paas, platform-as-a-service, website, web site, web, azure mobile"
    services="app-service"
    documentationcenter=""
    author="omarkmsft"
    manager="erikre"
    editor="cephalin" />
<tags
    ms.assetid="979cafa8-eeb6-4d3b-87cf-764a821c3e4f"
    ms.service="app-service"
    ms.workload="na"
    ms.tgt_pltfrm="na"
    ms.devlang="na"
    ms.topic="get-started-article"
    ms.date="12/02/2016"
    wacn.date=""
    ms.author="byvinyal" />

# What is Azure App Service?
*App Service* is a [platform-as-a-service](https://zh.wikipedia.org/wiki/平台即服务) (PaaS) offering of Azure. Create web and mobile apps for any platform or device. Integrate your apps with SaaS solutions, connect with on-premises applications, and automate your business processes. Azure runs your apps on fully managed virtual machines (VMs), with your choice of shared VM resources or dedicated VMs.

App Service includes the web and mobile capabilities that we previously delivered separately as Azure Websites and Azure Mobile Services. It also includes new capabilities for automating business processes and hosting cloud APIs. As a single integrated service, App Service lets you compose various components -- websites, mobile app back ends, RESTful APIs, and business processes -- into a single solution.

## Why use App Service?
Here are some key features and capabilities of App Service:

* **Multiple languages and frameworks** - App Service has first-class support for ASP.NET, Node.js, Java, PHP, and Python. You can also run [Windows PowerShell and other scripts or executables](/documentation/articles/web-sites-create-web-jobs/) on App Service VMs.
* **DevOps optimization** - Set up [continuous integration and deployment](/documentation/articles/app-service-continuous-deployment/) with GitHub. Promote updates through [test and staging environments](/documentation/articles/web-sites-staged-publishing/). Perform [A/B testing](/documentation/articles/app-service-web-test-in-production-get-start/). Manage your apps in App Service by using [Azure PowerShell](https://docs.microsoft.com/zh-cn/powershell/azureps-cmdlets-docs) or the [cross-platform command-line interface (CLI)](/documentation/articles/cli-install-nodejs/).
* **Global scale with high availability** - Scale [up](/documentation/articles/web-sites-scale/) or [out](/documentation/articles/insights-how-to-scale/) manually or automatically. Host your apps anywhere in Azure China's datacenter infrastructure, and the App Service [SLA](/support/sla/app-service/) promises high availability.
* **Connections to SaaS platforms and on-premises data** - Choose from more than 50 connectors for enterprise systems (such as SAP, Siebel, and Oracle), SaaS services (such as Salesforce and Office 365), and internet services (such as Facebook and Twitter). Access on-premises data using [Azure Virtual Networks](/documentation/articles/app-service-vnet-integration-powershell/).
* **Security and compliance** - App Service is [ISO, SOC, and PCI compliant](https://www.trustcenter.cn/zh-cn/).
* **Visual Studio integration** - Dedicated tools in Visual Studio streamline the work of creating, deploying, and debugging.

## App types in App Service
App Service offers several *app types*, each of which is intended to host a specific workload:

* [**Web Apps**](/documentation/articles/app-service-web-overview/) - For hosting websites and web applications.
* [**Mobile Apps**](/documentation/articles/app-service-mobile-value-prop/) For hosting mobile app back ends.
* [**API Apps**](/documentation/articles/app-service-api-apps-why-best-platform/) - For hosting RESTful APIs.

The word *app* here refers to the hosting resources dedicated to running a workload. Taking "web app" as an example, you're probably accustomed to thinking of a web app as both the compute resources and application code that together deliver functionality to a browser. But in App Service a *web app* is the compute resources that Azure provides for hosting your application code. 

Your application may be composed of multiple App Service apps of different kinds. For example If your application is composed of a web front end and a RESTful API back end you could:

- Deploy both (front end and api) to a single web app  
- Deploy your front-end code to a web app and your back-end code to an API app. 

## App Service plans
[App Service plans](/documentation/articles/azure-web-sites-web-hosting-plans-in-depth-overview/) represent the collection of physical resources used to host your apps.

App Service plans define:

- **Region** (China North, China East)
- **Scale count** (one, two, three instances, etc.)
- **Instance size** (Small, Medium, Large)
- **SKU** (Free, Shared, Basic, Standard, Premium)

All applications assigned to an **App Service plan** share the resources defined by it allowing you to save cost when hosting multiple apps.

Your **App Service plan** can scale from **Free** and **Shared** SKUs to **Basic**, **Standard**, and **Premium** SKUs giving you access to more resources and features along the way. Once your App Service Plan is set to **Basic** or higher you can also control the **size** and scale count of the VMs.

The **SKU** and **Scale** of the App Service plan determines the cost and not the number of apps hosted in it. 

## Pricing
For information about how much App Service costs, see [App Service Pricing](/pricing/details/app-service/).

## Test-drive App Service

Open a [trial Azure account](/pricing/1rmb-trial/), and try one of our getting-started tutorials:

* [Tutorial: Create a web app](/documentation/articles/app-service-web-get-started/)
* [Tutorial: Create a mobile app](/documentation/articles/app-service-mobile-android-get-started/)
* [Tutorial: Create an API app](/documentation/articles/app-service-api-dotnet-get-started/)