---
title: Use CLI 2.0 to create an Azure AD app and configure it to access Azure Media Services API | Azure
description: This topic shows how to use CLI 2.0 to create an Azure AD app and configure it to access Azure Media Services API.
services: media-services
documentationcenter: ''
author: Juliako
manager: erikre
editor: ''

ms.service: media-services
ms.workload: media
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 06/17/2017
ms.date: 08/07/2017
ms.author: v-haiqya

---
# Use CLI 2.0 to create an AAD app and configure it to access Azure Media Services API

This topic shows you how to use CLI 2.0 to create an Azure Active Directory (Azure AD) application and service principal to access Azure Media Services resources.

## Prerequisites

- An Azure account. For details, see [Azure trial](https://www.azure.cn/pricing/1rmb-trial/).
- A Media Services account. For more information, see [Create an Azure Media Services account using the Azure portal](media-services-portal-create-account.md).

## Create an Azure AD app and configure access to the media account with CLI 2.0

```azurecli
az login
az ad sp create-for-rbac --name <appName> --password <strong password>
az role assignment create -- assignee < user/app id> --role Contributor --scope <subscription/subscription id>
```

For example:

```azurecli
az role assignment create --assignee a3e068fa-f739-44e5-ba4d-ad57866e25a1 --role Contributor --scope /subscriptions/0b65e280-7917-4874-9fed-1307f2615ea2/resourceGroups/Default-AzureBatch-SouthCentralUS/providers/microsoft.media/mediaservices/sbbash
```

In this example, the **scope** is the full resource path for the media services account. However, the **scope** can be at any level.

For example, it could be one of the following levels:

- The **subscription** level.
- The **resource group** level.
- The **resource** level (for example, a Media account).

For more information, see [Create an Azure service principal with Azure CLI 2.0](https://docs.microsoft.com/cli/azure/create-an-azure-service-principal-azure-cli)

Also see [Manage Role-Based Access Control with the Azure command-line interface](../active-directory/role-based-access-control-manage-access-azure-cli.md).

## Next steps

Get started with [uploading files to your account](media-services-portal-upload-files.md).