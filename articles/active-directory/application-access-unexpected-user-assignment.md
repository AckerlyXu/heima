---
title: How to Assign users to applications | Azure
description: Understand how users get assigned to an application in your tenant
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

# How to assign users to applications

This article help you to understand how users get assigned to an application in your tenant.

## How do users get assigned to an application in Azure AD?

For a user to access an application, they must first be assigned to it in some way. Assignment can be performed by an administrator, a business delegate, or sometimes, the user themselves. Below describes the ways users can get assigned to applications:

1.  An administrator [assigns a user](active-directory-coreapps-assign-user-azure-portal.md) to the application directly


2.  An administrator assigns a license to a user directly for a first party application, like [Microsoft Office 365](http://products.office.com/)

3.  An administrator assigns a license to a group that the user is a member of to a first party application, like [Microsoft Office 365](http://products.office.com/)

4.  An [administrator consents to an application](./develop/active-directory-devhowto-multi-tenant-overview.md#understanding-user-and-admin-consent) to be used by all users and then a user signs in to the application

5.  A user [consents to an application](./develop/active-directory-devhowto-multi-tenant-overview.md#understanding-user-and-admin-consent) themselves by signing in to the application

## Next steps
[Managing Applications with Azure Active Directory](active-directory-enable-sso-scenario.md)
