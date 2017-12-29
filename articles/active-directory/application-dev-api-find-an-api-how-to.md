---
title: How to find a specific API needed for a custom-developed application | Azure
description: How to configure the permissions you need to access a particular API in your custom developed Azure AD application
services: active-directory
documentationcenter: ''
author: yunan2016
manager: digimobile

ms.assetid: 
ms.service: active-directory
ms.workload: identity
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 07/11/2017
ms.date: 1/1/2018
ms.author: v-nany


---

# How to find a specific API needed for a custom-developed application

Access to APIs require configuration of access scopes and roles. If you want to expose your resource application web APIs to client applications, you need to configure access scopes and roles for the API. If you want a client application to access a web API, you need to configure permissions to access the API in the app registration.

## Configuring a resource application to expose web APIs

When you expose your web API, the API be displayed in the **Select an API** list when adding permissions to an app registration. To add access scopes, follow the steps outlined in [adding access scopes to your resource application](./develop/active-directory-integrating-applications.md#adding-access-scopes-to-your-resource-application).

## Configuring a client application to access web APIs

When you add permissions to your app registration, you can **add API access** to exposed web APIs. To access web APIs, follow the steps outlined in [add credentials or permissions to access web APIs](./develop/active-directory-integrating-applications.md#to-add-credentials-or-permissions-to-access-web-apis).

## Next steps

-   [Integrating applications with Azure Active Directory](./develop/active-directory-integrating-applications.md)

-   [Understanding the Azure Active Directory application manifest](./develop/active-directory-application-manifest.md)


