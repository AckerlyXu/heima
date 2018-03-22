---
title: Article Index for Application Management in Azure Active Directory | Azure
description: Learn how to customize the expiration date for your federation certificates, and how to renew certificates that will soon expire.
services: active-directory
documentationcenter: ''
author: alexchen2016
manager: digimobile

ms.assetid: 5321b8e4-2afa-4dfe-8d53-4add7abb5ec8
ms.service: active-directory
ms.workload: identity
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 01/26/2018
ms.date: 03/05/2018
ms.author: v-junlch
ms.reviewer: asteen

---
# Article Index for Application Management in Azure Active Directory
This page provides a comprehensive list of every document written about the various application-related features in Azure Active Directory (Azure AD).

There is a brief introduction to each major feature area, as well as guidance on which articles to read depending on what information you're looking for.

## Overview Articles
The articles below are good starting points for those who simply want a brief explanation of Azure AD application management features.

| Article Guide |  |
|:---:| --- |
| An introduction to the application management problems that Azure AD solves |[Managing Applications with Azure Active Directory (AD)](active-directory-enable-sso-scenario.md) |
| An overview of the various features in Azure AD related to enabling single sign-on, defining who has access to apps, and how users launch apps |[Application Access and Single Sign-on in Azure Active Directory](active-directory-appssoaccess-whatis.md) |
| A look at the different steps involved when integrating apps into your Azure AD |[Integrating Azure Active Directory with Applications](./active-directory-integrating-applications-getting-started.md)<br /><br />Enabling Single Sign-On to SaaS Apps<br /><br />[Managing Access to Apps](./active-directory-managing-access-to-apps.md) |
| A technical explanation of how apps are represented in Azure AD |[How and Why Applications are Added to Azure AD](./develop/active-directory-how-applications-are-added.md) |

## Troubleshooting Articles
This section provides quick access to relevant troubleshooting guides. More information about each feature area can be found on the rest of this page.

| Feature Area |  |
|:---:| --- |
| Federated Single Sign-On |[Troubleshooting SAML-Based Single Sign-On](./develop/active-directory-saml-debugging.md) |
| Password-Based Single Sign-On | Troubleshooting the Access Panel Extension for Internet Explorer |
| Single sign-on between on-prem AD and Azure AD |[Troubleshooting Password Synchronization](connect/active-directory-aadconnectsync-implement-password-synchronization.md#troubleshoot-password-synchronization)|

## Single Sign-On (SSO)
### Federated Single Sign-On: Sign into many apps using one identity
Single sign-on allows users to access a variety of apps and services using only one set of credentials. Federation is one method through which you can enable single sign-on. When users attempt to sign into federated apps, they will get redirected to their organization's official sign-in page rendered by Azure Active Directory, and are then redirected back to the app upon successful authentication.

| Article Guide |  |
|:---:| --- |
| An introduction to federation and other types of sign-on |[Single Sign-On with Azure AD](active-directory-appssoaccess-whatis.md) |
| More than 150 app tutorials on how to configure single sign-on for apps |
| How to manually set up and customize your single sign-on configuration |How to Configure Federated Single Sign-On to Apps that are not in the Azure Active Directory Application Gallery |
| Troubleshooting guide for federated apps that use the SAML protocol |[Troubleshooting SAML-Based Single Sign-On](./develop/active-directory-saml-debugging.md) |
| How to configure your app's certificate's expiration date, and how to renew your certificates | Managing Certificates for Federated Single Sign-On in Azure Active Directory |

Federated single sign-on is available for all editions of Azure AD for up to ten apps per user. [Azure AD Premium](https://www.azure.cn/pricing/details/identity/) supports unlimited applications. If your organization has [Azure AD Basic](https://www.azure.cn/pricing/details/identity/) or [Azure AD Premium](https://www.azure.cn/pricing/details/identity/), then you can [use groups to assign access to federated applications](#managing-access-to-applications).

### Password-Based Single Sign-On: Account sharing and SSO for non-federated apps
To enable single sign-on to applications that don't support federation, Azure AD offers password management features that can securely store passwords to SaaS apps and automatically sign users into those apps. You can easily distribute credentials for newly created accounts and share team accounts with multiple people. Users don't necessarily need to know the credentials to the accounts that they're given access to.

| Article Guide |  |
|:---:| --- |
| An introduction to how password-based SSO works and a brief technical overview |[Password-Based Single Sign-On with Azure AD](active-directory-appssoaccess-whatis.md#password-based-single-sign-on) |
| A summary of the scenarios related to account sharing and how these problems are solved by Azure AD |[Sharing accounts with Azure AD](active-directory-sharing-accounts.md) |
| Automatically change the password for certain apps at a regular interval |[Automated Password Rollover (preview)](https://blogs.technet.microsoft.com/enterprisemobility/2015/02/20/azure-ad-automated-password-roll-over-for-facebook-twitter-and-linkedin-now-in-preview/) |
| Deployment and troubleshooting guides for the Internet Explorer version of the Azure AD password management extension |How to Deploy the Access Panel Extension for Internet Explorer using Group Policy <br /><br /> Troubleshooting the Access Panel Extension for Internet Explorer  |

Password-based single sign-on is available for all editions of Azure AD for up to ten apps per user. [Azure AD Premium](https://www.azure.cn/pricing/details/identity/) supports unlimited applications. If your organization has [Azure AD Basic](https://www.azure.cn/pricing/details/identity/) or [Azure AD Premium](https://www.azure.cn/pricing/details/identity/), then you can [use groups to assign access to applications](#managing-access-to-applications). Automated password rollover is an [Azure AD Premium](https://www.azure.cn/pricing/details/identity/) feature.

### Enabling single sign-on between Azure AD and on-premises AD
If your organization maintains a Windows Server Active Directory on premises along with your Azure Active Directory in the cloud, then you will likely want to enable single sign-on between these two systems. Azure AD Connect (the tool that integrates these two systems together) provides multiple options for setting up single sign-on: establish federation with ADFS or another federation provider, or enable password synchronization.

| Article Guide |  |
|:---:| --- |
| An overview on the single sign-on options offered in Azure AD Connect, as well as information on managing hybrid environments |[User Sign On Options in Azure AD Connect](./connect/active-directory-aadconnect-user-signin.md) |
| General guidance for managing environments with both on-premises Active Directory and Azure Active Directory | [Integrating your On-Premises Identities with Azure Active Directory](./connect/active-directory-aadconnect.md) |
| Guidance on using Password Sync to enable SSO |[Implement Password Synchronization with Azure AD Connect](./connect/active-directory-aadconnectsync-implement-password-synchronization.md)<br /><br />[Troubleshoot Password Synchronization](https://support.microsoft.com/zh-cn/kb/2855271) |
| Guidance on using third party identity providers to enable SSO |[List of Compatible Third-Party Identity Providers That Can Be Used to Enable Single Sign-On](https://aka.ms/ssoproviders) |

Azure AD Connect is available for [all editions of Azure Active Directory](https://www.azure.cn/pricing/details/identity/). Azure AD Self-Service Password Reset is available for [Azure AD Basic](https://www.azure.cn/pricing/details/identity/) and [Azure AD Premium](https://www.azure.cn/pricing/details/identity/). Password Writeback to on-prem AD is an [Azure AD Premium](https://www.azure.cn/pricing/details/identity/) feature.

## Apps & Azure AD

### Automatically provision and deprovision user accounts in SaaS apps
Automate the creation, maintenance, and removal of user identities in SaaS applications such as Dropbox, Salesforce, ServiceNow, and more. Match and sync existing identities between Azure AD and your SaaS apps, and control access by automatically disabling accounts when users leave the organization.

| Article Guide |  |
|:---:| --- |
| Configure how information is mapped between Azure AD and your SaaS app | Customizing Attribute Mappings <br><br> Writing Expressions for Attribute Mappings |
| How to enable automated provisioning to any app that supports the SCIM protocol | Set up Automated User Provisioning to any SCIM-Enabled App |
| Limit who gets provisioned to an application based on their attribute values | |

Automated user provisioning is available for all editions of Azure AD for up to ten apps per user. [Azure AD Premium](https://www.azure.cn/pricing/details/identity/) supports unlimited applications. If your organization has [Azure AD Basic](https://www.azure.cn/pricing/details/identity/) or [Azure AD Premium](https://www.azure.cn/pricing/details/identity/), then you can [use groups to manage which users get provisioned](#managing-access-to-applications).

### Building applications that integrate with Azure AD
If your organization is developing or maintaining line-of-business (LoB) applications, or if you're an app developer with customers who use Azure Active Directory, the following tutorials will help you integrate your applications with Azure AD.

| Article Guide |  |
|:---:| --- |
| Guidance for both IT professionals and application developers on integrating apps with Azure AD |[The IT Pro's Guide for Developing Applications for Azure AD](./active-directory-applications-guiding-developers-for-lob-applications.md)<br /><br />[The Developer's Guide for Azure Active Directory](./develop/active-directory-developers-guide.md) |
| How to manage access to developed applications using Azure Active Directory |[How to Enable User Assignment for Developed Applications](./active-directory-applications-guiding-developers-requiring-user-assignment.md)<br /><br />[Assigning Users to your App](./active-directory-applications-guiding-developers-assigning-users.md)<br /> |

## Managing Access to Applications


## See also
[What is Azure Active Directory?](active-directory-whatis.md)

[Azure Multi-Factor Authentication](/multi-factor-authentication/)

<!--Update_Description: wording update -->  
