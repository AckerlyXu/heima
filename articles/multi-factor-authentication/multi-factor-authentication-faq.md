---
title: Azure Multi-Factor Authentication FAQ | Microsoft Docs
description: Frequently asked questions and answers related to Azure Multi-Factor Authentication. Multi-Factor Authentication is a method of verifying a user's identity that requires more than a user name and password. It provides an additional layer of security to user sign-in and transactions.
services: multi-factor-authentication
documentationcenter: ''
author: alexchen2016
manager: digimobile
editor: yossib

ms.assetid: 50bb8ac3-5559-4d8b-a96a-799a74978b14
ms.service: multi-factor-authentication
ms.workload: identity
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 06/16/2017
ms.date: 01/16/2018
ms.author: v-junlch

ms.custom: H1Hack27Feb2017
---
# Frequently asked questions about Azure Multi-Factor Authentication
This FAQ answers common questions about Azure Multi-Factor Authentication and using the Multi-Factor Authentication service. It's broken down into questions about the service in general, billing models, user experiences, and troubleshooting.

## General

## Billing
Most billing questions can be answered by referring to the [Multi-Factor Authentication Pricing page](https://www.azure.cn/pricing/details/multi-factor-authentication/).

**Q: Is my organization charged for sending the phone calls and text messages that are used for authentication?**

No, you are not charged for individual phone calls placed or text messages sent to users through Azure Multi-Factor Authentication.

Your users might be charged for the phone calls or text messages they receive, according to their personal phone service.


## Manage and support user accounts

**Q: What should I tell my users to do if they don’t receive a response on their phone, or don't have their phone with them?**

Hopefully all your users configured more than one verification method. Tell them to try signing in again, but select a different verification method on the sign-in page.

You can point your users to the [End-user troubleshooting guide](./end-user/multi-factor-authentication-end-user-troubleshoot.md).


**Q: What should I do if one of my users can't get in to their account?**

You can reset the user's account by making them to go through the registration process again. Learn more about [managing user and device settings with Azure Multi-Factor Authentication in the cloud](multi-factor-authentication-manage-users-and-devices.md).

**Q: My users say that sometimes they don't receive the text message, or they reply to two-way text messages but the verification times out.**

Delivery of text messages and receipt of replies in two-way SMS are not guaranteed because there are uncontrollable factors that might affect the reliability of the service. These factors include the destination country, the mobile phone carrier, and the signal strength.

If your users often have problems with reliably receiving text messages, tell them to use the mobile app or phone call method instead. The mobile app can receive notifications both over cellular and Wi-Fi connections. In addition, the mobile app can generate verification codes even when the device has no signal at all. The Microsoft Authenticator app is available for [Android](http://go.microsoft.com/fwlink/?Linkid=825072), [IOS](http://go.microsoft.com/fwlink/?Linkid=825073), and [Windows Phone](http://go.microsoft.com/fwlink/?Linkid=825071).

If you must use text messages, we recommend using one-way SMS rather than two-way SMS when possible. One-way SMS is more reliable and it prevents users from incurring global SMS charges from replying to a text message that was sent from another country.

**Q: Why are my users being prompted to register their security information?**

There are several reasons that users could be prompted to register their security information:

- The user has been enabled for MFA by their administrator in Azure AD, but doesn't have security information registered for their account yet.
- The user has been enabled for self-service password reset in Azure AD. The security information will help them reset their password in the future if they ever forget it.
- The user accessed an application that has a Conditional Access policy to require MFA and hasn’t previously registered for MFA.
- The user is registering a device with Azure AD (including Azure AD Join), and your organization requires MFA for device registration, but the user has not previously registered for MFA.
- The user is generating Windows Hello for Business in Windows 10 (which requires MFA) and hasn’t previously registered for MFA.
- The organization has created and enabled an MFA Registration policy that has been applied to the user.
- The user previously registered for MFA, but chose a verification method that an administrator has since disabled. The user must therefore go through MFA registration again to select a new default verification method.


## Errors
**Q: What should users do if they see an “Authentication request is not for an activated account” error message when using mobile app notifications?**

Tell them to follow this procedure to remove their account from the mobile app, then add it again:

1. Go to your Azure portal profile and sign in with your organizational account.
2. Select **Additional Security Verification**.
3. Remove the existing account from the mobile app.
4. Click **Configure**, and then follow the instructions to reconfigure the mobile app.

**Q: What should users do if they see a 0x800434D4L error message when signing in to a non-browser application?**

The 0x800434D4L error occurs when you try to sign in to a non-broswer application, installed on a local computer, that doesn't work with account that require two-step verification.

A workaround for this is to have separate user accounts for admin-related and non-admin operations. Later, you can link mailboxes between your admin account and non-admin account so that you can sign in to Outlook by using your non-admin account. For more details about this, learn how to [give an administrator the ability to open and view the contents of a user's mailbox](http://help.outlook.com/141/gg709759.aspx?sl=1).

## Next steps
If your question isn't answered here, please leave it in the comments at the bottom of the page. Or, here are some additional options for getting help:

- Search the [Microsoft Support Knowledge Base](https://www.microsoft.com/en-us/Search/result.aspx?form=mssupport&q=phonefactor&form=mssupport) for solutions to common technical issues.
- Search for and browse technical questions and answers from the community, or ask your own question in the [Azure Active Directory forums](https://social.msdn.microsoft.com/Forums/azure/newthread?category=windowsazureplatform&forum=WindowsAzureAD&prof=required).
- If you're a legacy PhoneFactor customer and you have questions or need help resetting a password, use the [password reset](mailto:phonefactorsupport@microsoft.com) link to open a support case.
- Contact a support professional through [Azure Multi-Factor Authentication Server (PhoneFactor) support](https://support.microsoft.com/oas/default.aspx?prid=14947). When contacting us, it's helpful if you can include as much information about your issue as possible. Information you can supply includes the page where you saw the error, the specific error code, the specific session ID, and the ID of the user who saw the error.

