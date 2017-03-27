<properties
	pageTitle="Add new users to Azure Active Directory preview| Azure"
	description="Explains how to add new users or change user information in Azure Active Directory."
	services="active-directory"
	documentationCenter=""
	authors="curtand"
	manager="femila"
	editor=""/>

<tags
	ms.service="active-directory"
	ms.workload="identity"
	ms.tgt_pltfrm="na"
	ms.devlang="na"
	ms.topic="article"
	ms.date="09/12/2016"
	ms.author="curtand"
   	wacn.date=""/>


# Add new users to Azure Active Directory preview

> [AZURE.SELECTOR]
- [Azure portal](/documentation/articles/active-directory-users-create-azure-portal/)
- [Azure Classic Management Portal](/documentation/articles/active-directory-create-users/)

This article explains how to add new users in your organization in teh Azure Active Direstory (Azure AD) preview. [What's in the preview?](/documentation/articles/active-directory-preview-explainer/)

1.  Sign in to the [Azure portal](https://portal.azure.cn) with an account that's a global admin for the directory.

2.  Select **More services**, enter **Users and groups** in the text box, and then select **Enter**.

    ![Opening user management](./media/active-directory-users-create-azure-portal/create-users-user-management.png)

3.  On the **Users and groups** blade, select **All users**, and then select **Add**.

    ![Selecting the Add command](./media/active-directory-users-create-azure-portal/create-users-add-command.png)

4.  Enter details for the user, such as **Name** and **User name**. The domain name portion of the user name must either be the initial default domain name "foo.partner.onmschina.cn" domain name, or a verified, non-federated domain name such as "contoso.com."

5. Copy or otherwise note the generated user password so that you can provide it to the user after this process is complete.

6. Optionally, you can open and fill out the information in the **Profile** blade, the **Groups** blade, or the **Directory role** blade for the user. For more information about user and administrator roles, see [Assigning administrator roles in Azure AD](/documentation/articles/active-directory-assign-admin-roles/).

7.  On the **User** blade, select **Create**.

8. Securely distribute the generated password to the new user so that the user can sign in.

## What's next

- [Add an external user](/documentation/articles/active-directory-users-create-external-azure-portal/)
- [Reset a user's password in the new Azure portal](/documentation/articles/active-directory-users-reset-password-azure-portal/)
- [Change a user's work information](/documentation/articles/active-directory-users-work-info-azure-portal/)
- [Manage user profiles](/documentation/articles/active-directory-users-profile-azure-portal/)
- [Delete a user in your Azure AD](/documentation/articles/active-directory-users-delete-user-azure-portal/)
- [Assign a user to a role in your Azure AD](/documentation/articles/active-directory-users-assign-role-azure-portal/)
