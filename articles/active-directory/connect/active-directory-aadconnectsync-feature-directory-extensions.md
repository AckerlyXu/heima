---
title: 'Azure AD Connect sync: Directory extensions | Microsoft Docs'
description: This topic describes the directory extensions feature in Azure AD Connect.
services: active-directory
documentationcenter: ''
author: alexchen2016
manager: digimobile
editor: ''

ms.assetid: 995ee876-4415-4bb0-a258-cca3cbb02193
ms.service: active-directory
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: identity
origin.date: 07/12/2017
ms.date: 12/25/2017
ms.author: v-junlch

---
# Azure AD Connect sync: Directory extensions
Directory extensions allows you to extend the schema in Azure AD with your own attributes from on-premises Active Directory. This feature allows you to build LOB apps consuming attributes you continue to manage on-premises. These attributes can be consumed through [Azure AD Graph directory extensions](https://msdn.microsoft.com/Library/Azure/Ad/Graph/howto/azure-ad-graph-api-directory-schema-extensions) or [Microsoft Graph](https://graph.microsoft.io/). You can see the attributes available using Azure AD Graph explorer and [Microsoft Graph explorer](https://developer.microsoft.com/zh-cn/graph/graph-explorer-china) respectively.

At present no Office 365 workload consumes these attributes.

You configure which additional attributes you want to synchronize in the custom settings path in the installation wizard.
![Schema Extension Wizard](./media/active-directory-aadconnectsync-feature-directory-extensions/extension2.png)  
The installation shows the following attributes, which are valid candidates:

- User and Group object types
- Single-valued attributes: String, Boolean, Integer, Binary
- Multi-valued attributes: String, Binary


>[!NOTE]
> Azure AD Connect supports synchronizing multi-valued Active Directory attributes to Azure AD as multi-valued directory extensions. But no features in Azure AD currently support the use of multi-valued directory extensions.

The list of attributes is read from the schema cache that's created during installation of Azure AD Connect. If you have extended the Active Directory schema with additional attributes, you must [refresh the schema](active-directory-aadconnectsync-installation-wizard.md#refresh-directory-schema) before these new attributes are visible.

An object in Azure AD can have up to 100 attributes for directory extensions. The maximum length is 250 characters. If an attribute value is longer, the sync engine truncates it.

During installation of Azure AD Connect, an application is registered where these attributes are available. You can see this application in the Azure portal.

![Schema extension app](./media/active-directory-aadconnectsync-feature-directory-extensions/extension3new.png)

The attributes are prefixed with the extension \_{AppClientId}\_. AppClientId has the same value for all attributes in your Azure AD tenant.
These attributes are now available through Graph:  
![Azure AD Graph Explorer](./media/active-directory-aadconnectsync-feature-directory-extensions/extension4.png)

The attributes are prefixed with extension\_{AppClientId}\_. The AppClientId has the same value for all attributes in your Azure AD tenant.

## Next steps
Learn more about the [Azure AD Connect sync](active-directory-aadconnectsync-whatis.md) configuration.

Learn more about [Integrating your on-premises identities with Azure Active Directory](active-directory-aadconnect.md).

<!-- Update_Description: wording update -->