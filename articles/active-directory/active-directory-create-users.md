---
title: Add new users to Azure Active Directory | Microsoft Docs
description: Explains how to add new users or change user information in Azure Active Directory.
services: active-directory
documentationcenter: ''
author: alexchen2016
manager: digimobile
editor: ''

ms.assetid: e3673727-6bec-4fdc-87a4-d65b213c4c3c
ms.service: active-directory
ms.workload: identity
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 07/26/2017
ms.date: 08/22/2017
ms.author: v-junlch

ms.reviewer: jeffsta
ms.custom: oldportal;it-pro;
robots: NOINDEX
---
# Add new users or users with Microsoft accounts to Azure Active Directory
Add users to populate your directory. This article explains how to add new users in your organization, and how to add users who have Microsoft accounts. For more information about adding users from other directories in Azure Active Directory or adding users from partner companies, see [Add users from other directories or partner companies in Azure Active Directory](active-directory-create-users-external.md). Added users don't have administrator permissions by default, but you can assign roles to them at any time.

## Add a user
1. Sign in to the [Azure Classic Management Portal](https://manage.windowsazure.cn) with an account that's a global admin for the directory.
2. Select **Active Directory**, and then select the name of your organization directory.
3. Select the **Users** tab, and then, in the command bar, select **Add User**.
4. On the **Tell us about this user** page, under **Type of user**, select either:

   - **New user in your organization** - adds a new user account in your directory.
   - **User with an existing Microsoft account** - adds an existing Microsoft consumer account to your directory (for example, an Outlook account)
5. Depending on **Type of user**, enter a user name (for new user) or an email address (for a user with a Microsoft account).
6. On the user **Profile** page, provide a first and last name, a user-friendly name, and a user role from the **Roles** list. For more information about user and administrator roles, see [Assigning administrator roles in Azure AD](active-directory-assign-admin-roles.md). Specify whether to **Enable Multi-Factor Authentication** for the user.
7. On the **Get temporary password** page, select **Create**.

> [!IMPORTANT]
> If your organization uses more than one domain, you should know about the following issues when you add a user account:
>
> * TO add user accounts with the same user principal name (UPN) across domains, **first** add, for example, geoffgrisso@contoso.partner.onmschina.cn, **followed by** geoffgrisso@contoso.com.
> * **Don't** add geoffgrisso@contoso.com before you add geoffgrisso@contoso.partner.onmschina.cn. This order is important, and can be cumbersome to undo.
>
>

## Change user information
You can change any user attribute except for the object ID.

1. Open your directory.
2. Select the **Users** tab, and then select the display name of the user you want to change.
3. Complete your changes, and then click **Save**.

If the user that you're changing is synchronized with your on-premises Active Directory service, you can't change the user information using this procedure. To change the user, use your on-premises Active Directory management tools.

## What's next
- [Add users from other directories or partner companies in Azure Active Directory](active-directory-create-users-external.md)
- [Administering Azure AD](active-directory-administer.md)
- [Manage passwords in Azure AD](active-directory-manage-passwords.md)

<!--Image references-->
[1]: ./media/active-directory-create-users/RBACDirConfigTab.png
[2]: ./media/active-directory-create-users/RBACGuestAccessControls.png

<!--Update_Description: update metadata properties -->
