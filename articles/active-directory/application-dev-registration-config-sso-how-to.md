---
title: How to configure a new multi-tenant application | Microsoft Docs
description: How to configure single sign-on for a custom application you are developing and registering with Azure AD.
services: active-directory
documentationcenter: ''
author: alexchen2016
manager: digimobile

ms.assetid: 
ms.service: active-directory
ms.workload: identity
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 07/11/2017
ms.date: 07/28/2017
ms.author: v-junlch

---

# How to configure a new multi-tenant application

Enabling federated single sign-on (SSO) in your app is automatically enabled when federating through Azure AD for OpenID Connect, SAML 2.0, or WS-Fed. If your end users are having to sign in despite already having an existing session with Azure AD, it’s likely your app may be misconfigured.

- If you’re using ADAL/MSAL, make sure you have **PromptBehavior** set to **Auto** rather than **Always**.

- If you’re building a mobile app, you may need additional configurations to enable brokered or non-brokered SSO.

For Android, see [Enabling Cross App SSO in Android](/active-directory/develop/active-directory-sso-android).<br>

For iOS, see [Enabling Cross App SSO in iOS](/active-directory/develop/active-directory-sso-ios).

## Next steps

[Azure AD SSO](/active-directory/active-directory-appssoaccess-whatis)<br>

[Enabling Cross App SSO in Android](/active-directory/develop/active-directory-sso-android)<br>

[Enabling Cross App SSO in iOS](/active-directory/develop/active-directory-sso-ios)<br>

[Consent and Permissioning for AzureAD v2.0 converged Apps](develop/active-directory-v2-scopes.md)<br>

[AzureAD StackOverflow](http://stackoverflow.com/questions/tagged/azure-active-directory)

<!-- Update_Description: link update -->