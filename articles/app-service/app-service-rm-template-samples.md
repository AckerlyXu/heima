---
title: Azure Resource Manager template samples - App Service 
description: Azure Resource Manager template samples for the Web Apps feature of App Service
services: app-service
documentationcenter: app-service
author: tfitzmac
manager: timlt
editor: ggailey777
tags: azure-service-management

ms.service: app-service
ms.devlang: na
ms.topic: sample
ms.tgt_pltfrm: na
ms.workload: app-service
origin.date: 02/26/2018
ms.date: 04/02/2018
ms.author: v-yiso
ms.custom: mvc
---
# Azure Resource Manager templates for Web Apps

The following table includes links to Azure Resource Manager templates for the Web Apps feature of Azure App Service. For recommendations about avoiding common errors when you're creating web app templates, see [Guidance on deploying web apps with Azure Resource Manager templates](web-sites-rm-template-guidance.md).

| | |
|-|-|
|**Deploying a web app**||
| [Web app linked to a GitHub repository](https://github.com/Azure/azure-quickstart-templates/tree/master/201-web-app-github-deploy)| Deploys an Azure web app that pulls code from GitHub. |
| [Web app with custom deployment slots](https://github.com/Azure/azure-quickstart-templates/tree/master/101-webapp-custom-deployment-slots)| Deploys an Azure web app with custom deployment slots/environments. |
|**Configuring a web app**||
| [Web app certificate from Key Vault](https://github.com/Azure/azure-quickstart-templates/tree/master/201-web-app-certificate-from-key-vault)| Deploys an Azure web app certificate from an Azure Key Vault secret and uses it for SSL binding. |
| [Web app with a custom domain](https://github.com/Azure/azure-quickstart-templates/tree/master/201-web-app-custom-domain)| Deploys an Azure web app with a custom host name. |
| [Web app with a custom domain and SSL](https://github.com/Azure/azure-quickstart-templates/tree/master/201-web-app-custom-domain-and-ssl)| Deploys an Azure web app with a custom host name, and gets a web app certificate from Key Vault for SSL binding. |
| [Web app with a GoLang extension](https://github.com/Azure/azure-quickstart-templates/tree/master/101-webapp-with-golang)| Deploys an Azure web app with the GoLang site extension. You can then run web applications developed on GoLang on Azure. |
| [Web app with Java 8 and Tomcat 8](https://github.com/Azure/azure-quickstart-templates/tree/master/201-web-app-java-tomcat)| Deploys an Azure web app with Java 8 and Tomcat 8 enabled. You can then run Java applications in Azure. |
|**Web App with connected resources**||
| [Web App with MySQL](https://github.com/Azure/azure-quickstart-templates/tree/master/101-webapp-managed-mysql)| Deploys an Azure web app on Windows with Azure database for MySQL. |
| [Web App with PostgreSQL](https://github.com/Azure/azure-quickstart-templates/tree/master/101-webapp-managed-postgresql)| Deploys an Azure web app on Windows with Azure database for PostgreSQL. |
| [Web App with a SQL Database](https://github.com/Azure/azure-quickstart-templates/tree/master/201-web-app-sql-database)| Deploys an Azure web app and SQL Database at the "Basic" service level. |
| [Web App with Blob Storage connection](https://github.com/Azure/azure-quickstart-templates/tree/master/201-web-app-blob-connection)| Deploys an Azure web app with a blob storage connection string, which enables you to use Azure Blob Storage from the web app. |
| [Web App with Redis Cache](https://github.com/Azure/azure-quickstart-templates/tree/master/201-web-app-with-redis-cache)| Deploys an Azure web app with Redis cache. |
| | |
