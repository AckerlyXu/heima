---
title: Unexpected consent prompt when signing in to an application | Azure
description: How to troubleshoot when a user sees a consent prompt for an application you have integrated with Azure AD that you did not expect
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

# Unexpected consent prompt when signing in to an application

Many applications that integrate with Azure Active Directory require permissions to various resources in order to run. When these resources are also integrated with Azure Active Directory, permissions to access them is requested using the Azure AD consent framework. 

This results in a consent prompt being shown the first time an application is used, which is often a one-time operation. 

## Scenarios in which users see consent prompts

Additional prompts can be expected in various scenarios:

* The set of permissions required by the application have changed.

* The user who originally consented to the application was not an administrator, and now a different (non-admin) User is using the application for the first time.

* The user who originally consented to the application was an administrator, but they did not consent on-behalf of the entire organization.


* Consent was revoked after being granted initially.

* The developer has configured the application to require a consent prompt every time it is used (note: this is not best practice).


