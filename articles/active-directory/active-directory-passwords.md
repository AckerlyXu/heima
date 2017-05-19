---
title: Azure Active Directory password reset | Azure
description: Description of password management capabilities in Azure AD, including password reset, change, password management reporting, and writeback to your local on-premises Active Directory.
services: active-directory
documentationcenter: ''
author: MicrosoftGuyJFlo
manager: femila
editor: curtand

ms.assetid: be6164fc-bae1-49df-af76-761329ba70a1
ms.service: active-directory
ms.workload: identity
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
ms.date: 02/28/2017
wacn.date: ''
ms.author: joflore
---

# Azure Active Directory password reset for IT administrators
> [!IMPORTANT]
> **Are you here because you're having problems signing in?** If so, [here's how you can change and reset your own password](./active-directory-passwords-update-your-own-password.md#how-to-reset-your-password).
>
>

Self-service has long been a key goal for IT departments across the world as a cost-reduction and labor-saving measure.  Indeed, the market is flooded with products that let you manage your on-premises groups, passwords, or user profiles from the cloud or on-premises. Azure Active Directory (Azure AD) sets itself apart from other offerings by providing some of the easiest to use and most powerful self-service capabilities available today.

**Azure AD Password Management** is a set of capabilities that allow your users to manage any password from any device, at any time, from any location, while remaining in compliance with the security policies you define.

## ADMINS: Learn about how to get started with Azure AD password reset
If you're an admin who wants to enable Azure AD password reset, or just learn more about it, start with the links below to get to what you're interested in.

| Topic |  |
| --- | --- |
| Supported scenarios |[What is possible with Azure AD password reset?](#what-is-possible-with-azure-ad-password-reset) |
| Why use it? |[Why use Azure AD password reset?](#why-use-azure-ad-password-reset) |
| Pricing and availability |[Pricing and availability](#pricing-and-availability) |
| Reset a user's password |[Manage your users' passwords](#manage-your-users-passwords) |
| Set my organization's password policies |[Set password policies](#set-password-policies) |
| Newly released features |[Recent service updates](#recent-service-updates) |

### What is possible with Azure AD password reset? <a name="what-is-possible-with-azure-ad-password-reset"></a>
Here are some of the things you can do with Azure AD's password management capabilities.

- **Self-service password change** allows end users or administrators to change their expired or non-expired passwords without calling an administrator or helpdesk for support.
- **Self-service password reset** allows end users or administrators to reset their passwords automatically without calling an administrator or helpdesk for support. Self-service password reset requires Azure AD Premium or Basic. For more information, see Azure Active Directory Editions.
- **Administrator-initiated password reset** allows an administrator to reset an end user’s or another administrator’s password from within the [Azure Management Portal](https://manage.windowsazure.cn).
- **Password Writeback** allows management of on-premises passwords from the cloud so all of the above scenarios can be performed by, or on the behalf of, federated or password synchronized users. Password Writeback requires Azure AD Premium. For more information, see Getting started with Azure AD Premium.

### Why use Azure AD password reset? <a name="why-use-azure-ad-password-reset"></a>
Here are some of the reasons you should use Azure AD's password management capabilities

- **Reduce costs** - support-assisted password reset is typically 20% of organization's IT spend
- **Improve user experiences** - users don't want to call helpdesk and spend an hour on the phone every time they forget their passwords
- **Lower helpdesk volumes** - password management is the single largest helpdesk driver for most organizations
- **Enable mobility** - users can reset their passwords from wherever they are

### Pricing and availability <a name="pricing-and-availability"></a>
Azure AD password reset is available in 3 tiers, depending on which subscription you have:

- **Azure AD Free** - cloud-only administrators can reset their own passwords
- **Azure AD Basic or any Paid O365 Subscription** - cloud-only users and cloud-only administrators can reset their own passwords
- **Azure AD Premium** - any user or administrator, including cloud-only, federated, or password synced users, can reset their own passwords (requires password writeback to be enabled)

For more information on Azure AD Premium or Basic pricing, visit the [Active Directory Pricing Details](https://www.azure.cn/pricing/details/identity/) page.

## Manage your users' passwords <a name="manage-your-users-passwords"></a>
| Topic |  |
| --- | --- |
| How do I reset a user's password from the O365 management portal? |[Reset a user's password in Office 365](https://support.office.com/article/Reset-a-user-s-password-7A5D073B-7FAE-4AA5-8F96-9ECD041ABA9C) |
| How do I reset a user's password using PowerShell? |[Reset a user's password with Set-MsolUserPassword](https://msdn.microsoft.com/zh-cn/library/azure/dn194140.aspx) |

## Set password policies <a name="set-password-policies"></a>
| Topic |  |
| --- | --- |
| How do I set organization password expiration policy from Office 365? |[Set password expiration policy](https://support.office.com/article/Set-a-user-s-password-expiration-policy-0f54736f-eb22-414c-8273-498a0918678f) |
| How do I set a specific user's passwords to never expire with PowerShell? |[Set individual user's password to never expire using PowerShell](https://support.office.com/article/Set-an-individual-user-s-password-to-never-expire-f493e3af-e1d8-4668-9211-230c245a0466) |
| How do I find out whether a user's password is set to never expire using PowerShell |[Check individual user's password expiration status using PowerShell](https://support.office.com/article/Set-an-individual-user-s-password-to-never-expire-f493e3af-e1d8-4668-9211-230c245a0466#__toc378845827) |

## Recent service updates <a name="recent-service-updates"></a>
#### Usability updates to registration page - October 2015
- Now, when a user has data already registered, he or she can just click "looks good" to update the data without needing to re-send the email or phone call.

#### Improved reliability of password writeback - September 2015
- As of the September release of Azure AD Connect, the password writeback agent will now more aggressively retry connections and additional, more robust, failover capabilities.

#### API for retrieving password reset reporting data - August 2015
- Now, the data behind the password reset reports can be retrieved directly from the [Azure AD Reports and Events API](https://msdn.microsoft.com/zh-cn/library/azure/ad/graph/howto/azure-ad-reports-and-events-preview).

#### Support for Azure AD password reset during cloud domain join - August 2015
- Now, any cloud user can reset his or her password right from the Windows 10 sign in screen during the cloud domain join onboarding experience.  Note, this is not yet exposed on the Windows 10 sign in screen.

#### Enforce password reset registration at sign-in to Azure and federated apps - July 2015
- In addition to enforcing registration when signing into myapps.microsoft.com, we now support enforcing registration during sign ins to the Azure Management Portal and any of your federated single-sign on applications

#### Security question localization support - May 2015
- Now, you have the option to select pre-defined security questions which are localized in the full O365 language set when configuring Security Questions for password reset.

#### Account unlock support during password reset - June 2015
- If you're using password writeback and you reset your password when your account is locked, we'll automatically unlock your Active Directory account!

#### Branded self-service password reset (SSPR) registration - April 2015
- The password reset registration page is now branded with your company logo!

#### Security questions - March 2015
- We released security questions to GA!

#### Account unlock - March 2015
- Now users can unlock their accounts when password reset occurs

## Coming soon
Below are some of the cool features we're working on right now!

**Support for Reminding Users to Update their Registered Data During Sign-in** - Work in progress

- Today, we support reminding users to update their registered data when accessing myapps.microsoft.com, but we're working on the ability to do so for all sign ins.

## Next steps
Below are links to all of the Azure AD password reset documentation pages:

- **Are you here because you're having problems signing in?** If so, [here's how you can change and reset your own password](./active-directory-passwords-update-your-own-password.md#how-to-reset-your-password).
