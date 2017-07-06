---
title: Configuration FAQs for Azure web apps | Azure
description: Get answers to frequently asked questions about configuration and management issues for the Web Apps feature of Azure App Service.
services: app-service\web
documentationcenter: ''
author: simonxjx
manager: cshepard
editor: ''
tags: top-support-issue

ms.assetid: 2fa5ee6b-51a6-4237-805f-518e6c57d11b
ms.service: app-service-webf
ms.workload: web
ms.tgt_pltfrm: ibiza
ms.devlang: na
ms.topic: article
origin.date: 05/16/2017
ms.date: 07/10/2017
ms.author: v-dazen

---
# Configuration and management FAQs for Web Apps in Azure

This article has answers to frequently asked questions (FAQs) about configuration and management issues for the [Web Apps feature of Azure App Service](https://www.azure.cn/home/features/app-service/web-apps/).

[!INCLUDE [support-disclaimer](../../includes/support-disclaimer.md)]

## Are there limitations I should be aware of if I want to move App Service resources?

If you plan to move App Service resources to a new resource group or subscription, there are a few limitations to be aware of. For more information, see [App Service limitations](../azure-resource-manager/resource-group-move-resources.md#app-service-limitations).

## How do I use a custom domain name for my web app?

For answers to common questions about using a custom domain name with your Azure web app, see our seven-minute video [Add a custom domain name](https://channel9.msdn.com/blogs/Azure-App-Service-Self-Help/Add-a-Custom-Domain-Name). The video offers a walkthrough of how to add a custom domain name. It describes how to use your own URL instead of the *.chinacloudsites.cn URL with your App Service web app. You also can see a detailed walkthrough of [how to map a custom domain name](web-sites-custom-domain-name.md).

## How do I upload and configure an existing SSL certificate for my web app?

To learn how to upload and set up an existing custom SSL certificate, see [Bind an existing custom SSL certificate to an Azure web app](app-service-web-tutorial-custom-ssl.md#upload).

## Where can I find a guidance checklist and learn more about resource move operations?

[App Service limitations](../azure-resource-manager/resource-group-move-resources.md#app-service-limitations) shows you how to move resources to either a new subscription or to a new resource group in the same subscription. You can get information about the resource move checklist, learn which services support the move operation, and learn more about App Service limitations and other topics.

## How do I set the server time zone for my web app?

To set the server time zone for your web app:

1. In the Azure portal, in your App Service subscription, go to the **Application settings** menu.
2. Under **App settings**, add this setting:
    * Key = WEBSITE_TIME_ZONE
    * Value = *The time zone you want*
3. Select **Save**.

## Why do my continuous WebJobs sometimes fail?

By default, web apps are unloaded if they are idle for a set period of time. This lets the system conserve resources. In Basic and Standard plans, you can turn on the **Always On** setting to keep the web app loaded all the time. If your web app runs continuous WebJobs, you should turn on **Always On**, or the WebJobs might not run reliably. For more information, see [Create a continuously running WebJob](web-sites-create-web-jobs.md#CreateContinuous).

## How do I get the outbound IP address for my web app?

To get the list of outbound IP addresses for your web app:

1. In the Azure portal, on your web app blade, go to the **Properties** menu.
2. Search for **outbound ip addresses**.

The list of outbound IP addresses appears.

## How do I get a reserved or dedicated inbound IP address for my web app?

To set up a dedicated or reserved IP address for inbound calls made to your Azure app website, install and configure an IP-based SSL certificate.

Note that to use a dedicated or reserved IP address for inbound calls, your App Service plan must be in a Basic or higher service plan.

## Why do I see the message "Partially Succeeded" when I try to back up my web app?

A common cause of backup failure is that some files are in use by the application. Files that are in use are locked while you perform the backup. This prevents these files from being backed up and might result in a "Partially Succeeded" status. You can potentially prevent this from occurring by excluding files from the backup process. You can choose to back up only what is needed. For more information, see [Backup just the important parts of your site with Azure web apps](http://www.zainrizvi.io/2015/06/05/creating-partial-backups-of-your-site-with-azure-web-apps/).

## How do I remove a header from the HTTP response?

To remove the headers from the HTTP response, update your site's web.config file. For more information, see [Remove standard server headers on your Azure websites](https://azure.microsoft.com/blog/removing-standard-server-headers-on-windows-azure-web-sites/).

## Is App Service compliant with PCI Standard 3.0 and 3.1?

Currently, the Web Apps feature of Azure App Service is in compliance with PCI Data Security Standard (DSS) version 3.0 Level 1. PCI DSS version 3.1 is on our roadmap. Planning is already underway for how adoption of the latest standard will proceed.

PCI DSS version 3.1 certification requires disabling Transport Layer Security (TLS) 1.0. Currently, disabling TLS 1.0 is not an option for most App Service plans.

For more information, see [Azure App Service web app compliance with PCI Standard 3.0 and 3.1](https://support.microsoft.com/help/3124528).

## How do I use the staging environment and deployment slots?

In Standard and Premium App Service plans, when you deploy your web app to App Service, you can deploy to a separate deployment slot instead of to the default production slot. Deployment slots are live web apps that have their own host names. Web app content and configuration elements can be swapped between two deployment slots, including the production slot.

For more information about using deployment slots, see [Set up a staging environment in App Service](web-sites-staged-publishing.md).

## How do I add or edit a URL rewrite rule?

To add or edit a URL rewrite rule:

1. Set up Internet Information Services (IIS) Manager so that it connects to your App Service web app. To learn how to connect IIS Manager to App Service, see [Remote administration of Azure websites by using IIS Manager](https://azure.microsoft.com/blog/remote-administration-of-windows-azure-websites-using-iis-manager/).
2. In IIS Manager, add or edit a URL rewrite rule. To learn how to add or edit a URL rewrite rule, see [Create rewrite rules for the URL rewrite module](https://www.iis.net/learn/extensions/url-rewrite-module/creating-rewrite-rules-for-the-url-rewrite-module).

## How do I control inbound traffic to App Service?

At the site level, you have two options for controlling inbound traffic to App Service:

* Turn on dynamic IP restrictions. To learn how to turn on dynamic IP restrictions, see [IP and domain restrictions for Azure websites](https://azure.microsoft.com/blog/ip-and-domain-restrictions-for-windows-azure-web-sites/).
* Turn on Module Security. To learn how to turn on Module Security, see [ModSecurity web application firewall on Azure websites](https://azure.microsoft.com/blog/modsecurity-for-azure-websites/).

## How do I block ports in an App Service web app?

In the App Service shared tenant environment, it is not possible to block specific ports because of the nature of the infrastructure. TCP ports 4016, 4018, and 4020 also might be open for Visual Studio remote debugging.

## How do I capture an F12 trace?

You have two options for capturing an F12 trace:

* F12 HTTP trace
* F12 console output

### F12 HTTP trace

1. In Internet Explorer, go to your website. It's important to sign in before you do the next steps. Otherwise, the F12 trace captures sensitive sign-in data.
2. Press F12.
3. Verify that the **Network** tab is selected, and then select the green **Play** button.
4. Do the steps that reproduce the issue.
5. Select the red **Stop** button.
6. Select the **Save** button (disk icon), and save the HAR file (in Internet Explorer and Edge) *or* right-click the HAR file, and then select **Save as HAR with content** (in Chrome).

### F12 console output

1. Select the **Console** tab.
2. For each tab that contains more than zero items, select the tab (**Error**, **Warning**, or **Information**). If the tab isn't selected, the tab icon is gray or black when you move the cursor away from it.
3. Right-click in the message area of the pane, and then select **Copy all**.
4. Paste the copied text in a file, and then save the file.

To view an HAR file, you can use the [HAR viewer](http://www.softwareishard.com/har/viewer/).

## Why can't I delete my App Service plan?

You can't delete an App Service plan if any App Service apps are associated with the App Service plan. Before you delete an App Service plan, remove all associated App Service apps from the App Service plan.

## How do I schedule a WebJob?

You can create a scheduled WebJob by using Cron expressions:

1. Create a settings.job file.
2. In this JSON file, include a schedule property by using a Cron expression: 
    ```
    { "schedule": "{second}
    {minute} {hour} {day}
    {month} {day of the week}" }
    ```

For more information about scheduled WebJobs, see [Create a scheduled WebJob by using a Cron expression](web-sites-create-web-jobs.md#CreateScheduledCRON).

## How do I configure a custom domain name for an App Service web app that uses Traffic Manager?

To learn how to use a custom domain name with an App Service app that uses Azure Traffic Manager for load balancing, see [Configure a custom domain name for an Azure web app with Traffic Manager](web-sites-traffic-manager-custom-domain-name.md).

## How do authentication and authorization work in App Service?

For detailed documentation for authentication and authorization in App Service, see [App Service security](../app-service/app-service-security-readme.md). The documentation also has information about setting up App Service to use various identify provider sign-ins:
* [Azure Active Directory](../app-service-mobile/app-service-mobile-how-to-configure-active-directory-authentication.md)
* [Microsoft Account](../app-service-mobile/app-service-mobile-how-to-configure-microsoft-authentication.md)

## How do I redirect the default *.chinacloudsites.cn domain to my Azure web app's custom domain?

When you create a new website by using Web Apps in Azure, a default *sitename*.chinacloudsites.cn domain is assigned to your site. If you add a custom host name to your site and don't want users to be able to access your default *.chinacloudsites.cn domain, you can redirect the default URL. To learn how to redirect all traffic from your website's default domain to your custom domain, see [Redirect the default domain to your custom domain in Azure web apps](http://www.zainrizvi.io/2016/04/07/block-default-azure-websites-domain/).

## How do I determine which version of .NET version is installed in App Service?

The quickest way to find the version of Microsoft .NET that's installed in App Service is by using the Kudu console. You can access the Kudu console from the portal or by using the URL of your App Service app. For detailed instructions, see [Determine the installed .NET version in App Service](https://blogs.msdn.microsoft.com/waws/2016/11/02/how-to-determine-the-installed-net-version-in-azure-app-services/).

## Why isn't Autoscale working as expected?

If Azure Autoscale hasn't scaled in or scaled out the web app instance as you expected, you might be running into a scenario in which we intentionally choose not to scale to avoid an infinite loop due to "flapping." This usually happens when there isn't an adequate margin between the scale-out and scale-in thresholds.

## Why does Autoscale sometimes scale only partially?

Autoscale is triggered when metrics exceed preconfigured boundaries. Sometimes, you might notice that the capacity is only partially filled compared to what you expected. This might occur when the number of instances you want are not available. In that scenario, Autoscale partially fills in with the available number of instances. Autoscale then runs the rebalance logic to get more capacity. It allocates the remaining instances. Note that this might take a few minutes.

If you don't see the expected number of instances after a few minutes, it might be because the partial refill was enough to bring the metrics within the boundaries. Or, Autoscale might have scaled down because it reached the lower metrics boundary.

If none of these conditions apply and the problem persists, submit a support request.

## How do I turn on HTTP compression for my content?

To turn on compression both for static and dynamic content types, add the following code to the application-level web.config file:

```
<system.webServer>
<urlCompression doStaticCompression="true" doDynamicCompression="true" />
< /system.webServer>
```

You also can specify the specific dynamic and static MIME types that you want to compress. For more information, see our response to a forum question in [httpCompression settings on a simple Azure website](https://social.msdn.microsoft.com/Forums/azure/890b6d25-f7dd-4272-8970-da7798bcf25d/httpcompression-settings-on-a-simple-azure-website?forum=windowsazurewebsitespreview).
