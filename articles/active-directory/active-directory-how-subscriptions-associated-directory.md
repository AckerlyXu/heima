---
title: How Azure subscriptions are associated with Azure Active Directory | Microsoft Docs
description: How Azure subscriptions are associated with Azure Active Directory
services: active-directory
documentationcenter: ''
author: alexchen2016
manager: digimobile
editor: ''

ms.assetid: bc4773c2-bc4a-4d21-9264-2267065f0aea
ms.service: active-directory
ms.workload: identity
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: get-started-article
origin.date: 10/17/2017
ms.date: 11/22/2017
ms.author: v-junlch

ms.reviewer: jeffsta
ms.custom: oldportal;it-pro;

---
# How to add an Azure subscription to Azure Active Directory
This article covers information about the relationship between an Azure subscription and Azure Active Directory (Azure AD), and how to add an existing subscription to your Azure AD directory. Your Azure subscription has a trust relationship with Azure AD, which means that it trusts the directory to authenticate users, services, and devices. Multiple subscriptions can trust the same directory, but each subscription trusts only one directory. 

The trust relationship that a subscription has with a directory is unlike the relationship that it has with other resources in Azure (websites, databases, and so on). If a subscription expires, access to the other resources associated with the subscription also stops. But an Azure AD directory remains in Azure, and you can associate a different subscription with that directory and manage the directory using the new subscription.

All users have a single home directory that authenticates them, but they can also be guests in other directories. In Azure AD, you can see the directories of which your user account is a member or guest.

## Next steps
- To learn more about how resource access is controlled in Azure, see [Understanding resource access in Azure](active-directory-understanding-resource-access.md)
- For more information on how to assign roles in Azure AD, see [Assigning administrator roles in Azure Active Directory](active-directory-assign-admin-roles.md)

<!--Image references-->
[1]: ./media/active-directory-how-subscriptions-associated-directory/WAAD_PassThruAuth.png
[2]: ./media/active-directory-how-subscriptions-associated-directory/WAAD_OrgAccountSubscription.png
[3]: ./media/active-directory-how-subscriptions-associated-directory/WAAD_SignInDisambiguation.PNG

<!--Update_Description: wording update -->
