---
title: Problems signing in to an custom-developed application | Azure
description: Common rrors that could be causing you to not be able to sign into an application you have developed with Azure AD
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

# Problems signing in to an custom-developed application

There are several errors that could be causing you to not be able to sign into an app. The biggest reason people encounter this problem is misconfigured apps.

## Errors related to  misconfigured apps

* Verify both the configurations in the portal match what you have in your app. Specifically, compare Client/Application ID, Reply URLs, Client Secrets/Keys, and App ID URI.

* Compare the resource you’re requesting access to in code with the configured permissions in the **Required Resources** tab to make sure you only request resources you’ve configured.


## Next steps

[Azure AD Developer Guide](./develop/active-directory-developers-guide.md)<br>

[Consent and Integrating Apps to Azure AD](./develop/active-directory-integrating-applications.md)<br>




