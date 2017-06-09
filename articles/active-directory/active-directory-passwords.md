---

title: Azure AD self-service password reset overview | Microsoft Docs
description: What can self-service password reset in Azure AD do for your organization? 
services: active-directory
documentationcenter: ''
author: MicrosoftGuyJFlo
manager: femila

ms.assetid: 
ms.service: active-directory
ms.workload: identity
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
ms.date: 05/05/2017
wacn.date: ''
ms.author: v-junlch

---
# Azure AD self-service password reset for the IT professional

"Self-service" is a buzzword thrown around inside many IT departments across the world with varying meanings. The market is flooded with products that allow you to manage on-premises groups, passwords, or user profiles from the cloud or on-premises.

Azure Active Directory (Azure AD) self-service password reset (SSPR) sets itself apart with ease of use and deployment. Azure AD self-service password reset combines a set of capabilities that:

- Allow your users to manage their own password
  - From any device
  - In any location
  - At any time
- Maintain compliance with policies you as an administrator define

## What is possible

- **Self-service password change** allows end users or administrators to change their passwords without administrator assistance
- **Self-service account unlock** allows end users to unlock their own account without administrator assistance
- **Self-service password reset** allows end users or administrators to reset their passwords automatically without administrator assistance. Self-service password reset requires Azure AD Premium or Basic - [Azure Active Directory Editions](active-directory-editions.md).
- **Administrator-initiated password reset** allows an administrator to reset an end user’s or another administrator’s password from within the [Azure portal](../azure-portal-overview.md)

## Why choose Azure AD self-service password reset

- **Reduce costs** as helpdesk and support assisted password reset is typically 20% of an IT organization’s spend
- **Improve end-user experiences** and **reduce helpdesk volume** by giving end users the power to resolve their own password issues at once without calling a helpdesk or opening a support request.
- **Drive mobility** as users can reset their passwords from wherever they are.

## Azure AD self-service password reset availability

Azure AD self-service password reset is available in three tiers depending on your subscription.

- **Azure AD Free** - Cloud-only administrators can reset their own passwords
- **Azure AD Basic** or any **Paid Office 365 Subscription** - Cloud-only users and cloud-only administrators can reset their own passwords
- **Azure AD Premium** - Any user or administrator, including cloud-only, federated, or password synchronized users, can reset their own passwords. On-premises passwords require password writeback to be enabled.

## Azure AD self-service password reset, a sum of the parts

Self-service password reset in Azure AD is made up of the following components:

- **Password management configuration portal** where you can control options for how passwords are managed in your tenant via the Azure portal
- **Password reset registration portal** where users can self-register for password reset
- **Password reset portal** where users can reset their password using the challenges defined by the administrator and the answers users have provided
- **User password change portal** where users can change their own passwords by entering their old password and providing a new password
- **Password management reports** where administrators can view and analyze password activity reports for their tenants in the Azure portal
- **Password writeback to on-premises using Azure AD Connect** allows you to enable management of on-premises, federated, or password synchronized users from the cloud

## Azure AD pricing, SLA, updates, and roadmap

More detail about these topics can be found on the following pages

- [**Azure AD Pricing Details**](http://www.azure.cn/pricing/details/identity/)
- [**Office 365 Pricing**](https://products.office.com/compare-all-microsoft-office-products?tab=2)
- [**Azure Service Level Agreements**](https://www.azure.cn/support/legal/sla/)
- [**Service Level Agreement for Microsoft Online Services**](http://go.microsoft.com/fwlink/?LinkID=272026&clcid=0x409)
- [**Azure Updates**](https://azure.microsoft.com/updates/)
- [**Azure Roadmap**](https://www.microsoft.com/cloud-platform/roadmap-recently-available)


