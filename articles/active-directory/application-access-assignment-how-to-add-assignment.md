---
title: How to assign users and groups to an application | Microsoft Docs
description: Assign users to the application to grant access
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

# How to assign users and groups to an application

Before your users can do any of the below for a specific application, you need to first **assign them to the application** to grant them access:

-   Access an application by **navigating to the application’s URL directly** (also known as SP-initiated sign-on).

-   Access an application by using the **User Access URL** on an application’s **Properties** page (also known as IDP-initiated sign on).


-   See an application appear on their [Office 365 Application Launcher](https://support.office.com/article/Meet-the-Office-365-app-launcher-79f12104-6fed-442f-96a0-eb089a3f476a).

## Methods to assign applications with Azure Active Directory 

You can assign applications with Azure Active Directory in Azure China:

-   [Assign a user directly to an application as an administrator](#assign-a-user-directly-as-an-administrator)



## Assign a user directly as an administrator

To assign one or more users to an application directly, follow the steps below:

1.  Open the [**Azure Portal**](https://portal.azure.cn/) and sign in as a **Global Administrator.**

2.  Open the **Azure Active Directory Extension** by clicking **More services** at the bottom of the main left hand navigation menu.

3.  Type in **“Azure Active Directory**” in the filter search box and select the **Azure Active Directory** item.

4.  click **Enterprise Applications** from the Azure Active Directory left hand navigation menu.

5.  click **All Applications** to view a list of all your applications.

  * If you do not see the application you want show up here, use the **Filter** control at the top of the **All Applications List** and set the **Show** option to **All Applications.**

6.  Select the application you want to assign a user to from the list.

7.  Once the application loads, click **Users and Groups** from the application’s left hand navigation menu.

8.  Click the **Add** button on top of the **Users and Groups** list to open the **Add Assignment** blade.

9.  click the **Users and groups** selector from the **Add Assignment** blade.

10. Type in the **full name** or **email address** of the user you are interested in assigning into the **Search by name or email address** search box.

11. Hover over the **user** in the list to reveal a **checkbox**. Click the checkbox next to the user’s profile photo or logo to add your user to the **Selected** list.

12. **Optional:** If you would like to **add more than one user**, type in another **full name** or **email address** into the **Search by name or email address** search box, and click the checkbox to add this user to the **Selected** list.

13. When you are finished selecting users, click the **Select** button to add them to the list of users and groups to be assigned to the application.

14. **Optional:** click the **Select Role** selector in the **Add Assignment** blade to select a role to assign to the users you have selected.

15. Click the **Assign** button to assign the application to the selected users.

After a short period of time, the users you have selected be able to launch these applications using the methods described in the solution description section.



