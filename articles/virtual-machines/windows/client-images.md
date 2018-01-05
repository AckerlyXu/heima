---
title: Use Windows client images in Azure | Azure
description: How to use Visual Studio subscription benefits to deploy Windows 7, Windows 8, or Windows 10 in Azure for dev/test scenarios
services: virtual-machines-windows
documentationcenter: ''
author: rockboyfor
manager: digimobile
editor: ''

ms.assetid: 91c3880a-cede-44f1-ae25-f8f9f5b6eaa4
ms.service: virtual-machines-windows
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: vm-windows
ms.workload: infrastructure-services
origin.date: 12/15/2017
ms.date: 01/08/2018
ms.author: v-yeche

---
# Use Windows client in Azure for dev/test scenarios
You can use Windows 7, Windows 8, or Windows 10 in Azure for dev/test scenarios provided you have an appropriate Visual Studio (formerly MSDN) subscription. This article outlines the eligibility requirements for running Windows client in Azure and use of the Azure Gallery images.

## Subscription eligibility
Active Visual Studio subscribers (people who have acquired a Visual Studio subscription license) can use Windows client for development and testing purposes. Windows client can be used on your own hardware and Azure virtual machines running in any type of Azure subscription. Windows client may not be deployed to or used on Azure for normal production use, or used by people who are not active Visual Studio subscribers.

For your convenience, certain Windows 10 images are available from the Azure Gallery within [eligible dev/test offers](#eligible-offers). Visual Studio subscribers within any type of offer can also [adequately prepare and create](prepare-for-upload-vhd-image.md) a 64-bit Windows 7, Windows 8, or Windows 10 image and then [upload to Azure](upload-generalized-managed.md). The use remains limited to dev/test by active Visual Studio subscribers.

## Eligible offers
The following table details the offer IDs that are eligible to deploy Windows 10 through the Azure Gallery. The Windows 10 images are only visible to the following offers. Visual Studio subscribers who need to run Windows client in a different offer type require you to [adequately prepare and create](prepare-for-upload-vhd-image.md) a 64-bit Windows 7, Windows 8, or Windows 10 image and [then upload to Azure](upload-generalized-managed.md).

| Offer Name | Offer Number | Available client images |
|:--- |:---:|:---:|
| [Visual Studio Professional subscribers](https://www.azure.cn/offers/ms-mc-arz-msdn/) | MS-MC-AZR-59P | Windows 10 |
| [Visual Studio Test Professional subscribers](https://www.azure.cn/offers/ms-mc-arz-msdn/) | MS-MC-AZR-60P | Windows 10 |
| [Visual Studio Enterprise subscribers](https://www.azure.cn/offers/ms-mc-arz-msdn/) |MS-MC-AZR-63P | Windows 10 |

## Check your Azure subscription
If you do not know your offer ID, you can obtain it through the Azure portal in one of these two ways:  

- On the *Subscriptions* window:

  ![Offer ID details from the Azure portal](./media/client-images/offer-id-azure-portal.png) 

- Or, click **Billing** and then click your subscription ID. The offer ID appears in the *Billing* window.

You can also view the offer ID from the ['Subscriptions' tab](http://account.windowsazure.cn/Subscriptions) of the Azure Account portal:

![Offer ID details from the Azure Account portal](./media/client-images/offer-id-azure-account-portal.png) 

## Next steps
You can now deploy your VMs using [PowerShell](quick-create-powershell.md), [Resource Manager templates](ps-template.md), or [Visual Studio](../../vs-azure-tools-resource-groups-deployment-projects-create-deploy.md).
<!--Update_Description: new articles on vm client images -->
<!--ms.date: 01/08/2018-->