---
title: Azure MFA versions and consumption plans | Microsoft Docs
description: Information about the Multi-factor Authentication client and the different methods and versions available. Details about each consumption plan
keywords: 
services: multi-factor-authentication
documentationcenter: ''
author: MicrosoftGuyJFlo
manager: mtillman
ms.reviewer: richagi

ms.assetid: 
ms.service: multi-factor-authentication
ms.workload: identity
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 08/25/2017
ms.date: 01/16/2018
ms.author: v-junlch
---
# How to get Azure Multi-Factor Authentication

When it comes to protecting your accounts, two-step verification should be standard across your organization. This feature is especially important for administrative accounts that have privileged access to resources. For this reason, Microsoft offers basic two-step verification features to Office 365 and Azure administrators for no extra cost. If you want to upgrade the features for your admins or extend two-step verification to the rest of your users, you can purchase Azure Multi-Factor Authentication. 

This article explains the difference between the versions offered to administrators and the full Azure MFA version. If you're ready to deploy the complete Azure MFA offering, the later section covers implementation options and how Microsoft calculates consumption.

>[!IMPORTANT]
>This article is meant to be a guide to help you understand the different ways to buy Azure Multi-Factor Authentication. For specific details about pricing and billing, you should always refer to the [Multi-Factor Authentication pricing page](https://www.azure.cn/pricing/details/multi-factor-authentication/).

## Available versions of Azure Multi-Factor Authentication

The following table describes the differences between three versions of multi-factor authentication:

| Version | Description |
| --- | --- |
| Multi-Factor Authentication for Office 365 |This version works exclusively with Office 365 applications and is managed from the Office 365 portal. Administrators can [secure Office 365 resources with two-step verification](https://support.office.com/article/Set-up-multi-factor-authentication-for-Office-365-users-8f0454b2-f51a-4d9c-bcde-2c48e41621c6). This version is part of an Office 365 subscription. |
| Multi-Factor Authentication for Azure AD Administrators | Users assigned the Global administrator role in Azure AD tenants can enable two-step verification for their Azure AD global admin accounts at no additional cost.|
| Azure Multi-Factor Authentication | Often referred to as the "full" version, Azure Multi-Factor Authentication offers the richest set of capabilities. It provides additional configuration options for a range of cloud applications.|

## Feature comparison of versions
The following table provides a list of the features that are available in the various versions of Azure Multi-Factor Authentication.

> [!NOTE]
> This comparison table discusses the features that are part of each version of Multi-Factor Authentication. If you have the full Azure Multi-Factor Authentication service, some features may not be available depending on whether you use [MFA in the cloud](multi-factor-authentication-get-started-cloud.md).


| Feature | Multi-Factor Authentication for Office 365 | Multi-Factor Authentication for Azure AD Administrators | Azure Multi-Factor Authentication |
| --- |:---:|:---:|:---:|
| Protect Azure AD admin accounts with MFA |● |● (Azure AD Global Administrator accounts only) |● |
| Mobile app as a second factor |● |● |● |
| Phone call as a second factor |● |● |● |
| SMS as a second factor |● |● |● |
| Admin control over verification methods |● |● |● |
| PIN mode | | |● |
| Custom greetings for phone calls | | |● |
| Custom caller ID for phone calls | | |● |

## Next steps

- For more pricing details, see [Azure MFA Pricing](https://www.azure.cn/pricing/details/multi-factor-authentication/).

- Choose whether to deploy Azure MFA [in the cloud or on-premises](./multi-factor-authentication-get-started-cloud.md)

<!--Update_Description: wording update-->