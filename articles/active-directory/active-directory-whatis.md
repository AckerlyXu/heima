---
title: What is Azure Active Directory?
description: Use Azure Active Directory to extend your existing on-premises identities into the cloud or develop Azure AD integrated applications.
services: active-directory
documentationcenter: ''
author: alexchen2016
manager: digimobile
ms.reviewer: jsnow
ms.author: v-junlch
ms.assetid: 498820c4-9ebe-42be-bda2-ecf38cc514ca
ms.service: active-directory
ms.workload: identity
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 07/17/2017
ms.date: 03/05/2018
ms.custom: it-pro

---
# What is Azure Active Directory?
Azure Active Directory (Azure AD) is Microsoft’s multi-tenant, cloud based directory and identity management service. Azure AD combines core directory services, advanced identity governance, and application access management. Azure AD also offers a rich, standards-based platform that enables developers to deliver access control to their applications, based on centralized policy and rules. 

For IT Admins, Azure AD provides an affordable, easy to use solution to give employees and business partners single sign-on (SSO) access to thousands of cloud SaaS Applications like Office365, Salesforce.com, DropBox, and Concur.

For application developers, Azure AD lets you focus on building your application by making it fast and simple to integrate with a world class identity management solution used by millions of organizations around the world.

Azure AD also includes a full suite of identity management capabilities including multi-factor authentication, device registration, self-service password management, self-service group management, privileged account management, role based access control, application usage monitoring, rich auditing and security monitoring and alerting. These capabilities can help secure cloud based applications, streamline IT processes, cut costs and help ensure that corporate compliance goals are met.

Additionally, with just [four clicks](./connect/active-directory-aadconnect-get-started-express.md), Azure AD can be integrated with an existing Windows Server Active Directory, giving organizations the ability to leverage their existing on-premises identity investments to manage access to cloud based SaaS applications.

If you are an Office 365, Azure or Dynamics CRM Online customer, you might not realize that you are already using Azure AD. Every Office 365, Azure and Dynamics CRM tenant is actually already an Azure AD tenant. Whenever you want you can start using that tenant to manage access to thousands of other cloud applications Azure AD integrates with!

![Azure AD Connect Stack](./media/active-directory-whatis/Azure_Active_Directory.png)

## How reliable is Azure AD?
The multi-tenant, geo-distributed, high availability design of Azure AD means that you can rely on it for your most critical business needs. Running out of 28 data centers around the world with automated failover, you’ll have the comfort of knowing that Azure AD is highly reliable and that even if a data center goes down, copies of your directory data are live in at least two more regionally dispersed data centers and available for instant access.

For more details, see [Service Level Agreements](https://www.azure.cn/support/legal/sla/).

## Choose an edition
To enhance your Azure Active Directory, you can add paid capabilities using the Azure Active Directory Basic, Premium P1, and Premium P2 editions. Azure Active Directory paid editions are built on top of your existing free directory, providing enterprise class capabilities spanning self-service, enhanced monitoring, security reporting, Multi-Factor Authentication (MFA), and secure access for your mobile workforce.

> [!NOTE]
> For the pricing options of these editions, see [Azure Active Directory Pricing](https://www.azure.cn/pricing/details/identity/). Azure Active Directory Premium P1, Premium P2, and Azure Active Directory Basic are not currently supported in China. Please contact us at the Azure Active Directory Forum for more information.
>

## How can I get started?

**If you are an IT admin:**

- [Try it out!](./index.md) - you can sign up for a trial today and deploy your first cloud solution using this link


**If you are a developer:**

- Check out our [Developers Guide](./develop/active-directory-developers-guide.md) to Azure Active Directory

- [Start a trial](https://www.azure.cn/pricing/1rmb-trial/) - sign up for a trial today and  start integrating your apps with Azure AD


<!-- Update_Description: wording update -->

