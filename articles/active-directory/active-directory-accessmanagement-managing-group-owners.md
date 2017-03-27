
<properties
	pageTitle="Next steps for access management using groups | Azure"
	description="Advanced How-to's for managing security groups and how to use these groups to manage access to a resource."
	services="active-directory"
	documentationCenter=""
	authors="curtand"
	manager="femila"
	editor=""/>

<tags
	ms.service="active-directory" 
	ms.date="08/10/2016"
	wacn.date=""/>

# Managing owners for a group
Once a resource owner has assigned access to a resource to an Azure AD group, the membership of the group is managed by the group owner. The resource owner effectively delegates the permission to assign users to the resource to the owner of the group.

## Assigning group ownership

**To add an owner to a group**

1. In the [Azure classic portal](https://manage.windowsazure.cn), select **Active Directory**, and then open your organization’s directory.

2. Select the **Groups** tab, and then open the group that you want to add owners to.

3. Select **Add Owners**.

4. On the **Add owners** page, select the user that you want to add as the owner of this group, and make sure this name is added to the **Selected** pane.


**To remove an owner from a group**

1. In the [Azure classic portal](https://manage.windowsazure.cn), select **Active Directory**, and then open your organization’s directory.

2. Select the **Groups** tab, and then open the group that you want to remove an owner from.

4. Select the **Owners** tab.

5. Select the owner that you want to remove from this group, and then select **Remove**.

## Additional information

These articles provide additional information on Azure Active Directory.

* [Managing access to resources with Azure Active Directory groups](/documentation/articles/active-directory-manage-groups/)
* [Article Index for Application Management in Azure Active Directory](/documentation/articles/active-directory-apps-index/)
* [What is Azure Active Directory?](/documentation/articles/active-directory-whatis/)

* [Integrating your on-premises identities with Azure Active Directory](/documentation/articles/active-directory-aadconnect/)