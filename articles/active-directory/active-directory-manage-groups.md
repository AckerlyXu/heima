---

title: Use groups to manage access to resources in Azure Active Directory | Microsoft Docs
description: How to use groups in Azure Active Directory to manage user access to on-premises and cloud applications and resources.
services: active-directory
documentationcenter: ''
author: yunan2016
manager: digimobile
editor: ''

ms.assetid: 714120d0-cdf9-465d-afee-39bef591c6b3
ms.service: active-directory
ms.workload: identity
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 08/28/2017
ms.date: 03/05/2018
ms.author: v-nany

ms.custom: H1Hack27Feb2017;it-pro
ms.reviewer: piotrci

---
# Manage access to resources with Azure Active Directory groups
Azure Active Directory (Azure AD) is a comprehensive identity and access management solution that provides a robust set of capabilities to manage access to on-premises and cloud applications and resources including Microsoft online services like Office 365 and a world of non-Microsoft SaaS applications. This article provides an overview, but if you want to start using Azure AD groups right now, follow the instructions in [Managing security groups in Azure AD](active-directory-groups-create-azure-portal.md). If you want to see how you can use PowerShell to manage groups in Azure Active directory you can read more in [Azure Active Directory cmdlets for group management](active-directory-accessmanagement-groups-settings-v2-cmdlets.md).

> [!NOTE]
> To use Azure Active Directory, you need an Azure account. If you don't have an account, you can [sign up for a Azure account](https://www.azure.cn/pricing/1rmb-trial/).
>
>

Within Azure AD, one of the major features is the ability to manage access to resources. These resources can be part of the directory, as in the case of permissions to manage objects through roles in the directory, or resources that are external to the directory, such as SaaS applications, Azure services, and SharePoint sites or on-premises resources. There are four ways a user can be assigned access rights to a resource:

1. Direct assignment

    Users can be assigned directly to a resource by the owner of that resource.


## How does access management in Azure Active Directory work?
At the center of the Azure AD access management solution is the security group. Using a security group to manage access to resources is a well-known paradigm, which allows for a flexible and easily understood way to provide access to a resource for the intended group of users. The resource owner (or the administrator of the directory) can assign a group to provide a certain access right to the resources they own. The members of the group will be provided the access, and the resource owner can delegate the right to manage the members list of a group to someone else, such as a department manager or a helpdesk administrator.


The owner of a group can also make that group available for self-service requests. In doing so, an end user can search for and find the group and make a request to join, effectively seeking permission to access the resources that are managed through the group. The owner of the group can set up the group so that join requests are approved automatically or require approval by the owner of the group. When a user makes a request to join a group, the join request is forwarded to the owners of the group. If one of the owners approves the request, the requesting user is notified and the user is joined to the group. If one of the owners denies the request, the requesting user is notified but not joined to the group.

## Getting started with access management
Ready to get started? You should try out some of the basic tasks you can do with Azure AD groups. Use these capabilities to provide specialized access to different groups of people for different resources in your organization. A list of basic first steps are listed below.

* [Creating a simple rule to configure dynamic memberships for a group](active-directory-groups-create-azure-portal.md)

## Next steps
Now that you have understood the basics of access management, here are some additional advanced capabilities available in Azure Active Directory for managing access to your applications and resources.

* [Managing security groups in Azure AD](active-directory-groups-create-azure-portal.md)
* [Graph API reference for groups](https://msdn.microsoft.com/Library/Azure/Ad/Graph/api/groups-operations#GroupFunctions)
