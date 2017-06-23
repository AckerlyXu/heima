---
title: Understanding your bill for Azure | Microsoft Docs
description: Learn how to read and understand the usage and bill for your Azure subscription
services: ''
documentationcenter: ''
author: genlin
manager: ruchic
editor: ''
tags: billing

ms.assetid: 32eea268-161c-4b93-8774-bc435d78a8c9
ms.service: billing
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: na
ms.date: 04/07/2017
ms.author: v-junlch

---
# Understand your bill for Microsoft Azure
To understand your Azure bill, review the invoice with the summary of charges and the separate detailed daily usage file. This article describes most of the terms shown in the invoice and the daily usage file. If you're using a free trial subscription, you can get your daily usage information but you don't have an invoice.

The charges for Microsoft Azure subscriptions vary by rate plan. Some rate plans, like the Visual Studio Enterprise (MPN) subscribers, include monthly credits that you can use on any Azure service based on your needs.

Up to 24 hours of usage at the end of the previous billing period may show up in your current bill. Also charges listed on billing statements for international customers are for estimation purposes only. Banks have different costs for the conversion rates.

## <a name="pdf"></a> Understand your invoice (.pdf)
The invoice provides a summary of your charges. It’s available for download in the Portable Document Format (.pdf) from the [Azure portal](https://portal.azure.cn). 

The following sections list most of the terms that you see on your invoice and descriptions for each term.

### Understand the invoice summary
The **Invoice Summary** section of the bill summarizes transactions since your last bill, and your current usage charges.

![invoice summary](./media/billing-understand-your-bill/InvoiceSummary.png)

The previous balance, payments, and outstanding balance section of the bill summarizes transactions since your last bill.

| Term | Description |
| --- | --- |
| Previous balance |The total amount due from your last bill |
| Payments |Total payments applied to your last bill |
| Outstanding balance (from previous billing cycle) |Any bill adjustments (credits or balances) applied to your account since your last bill |

### Understand the current charges
The Current Charges section of the bill shows details about your monthly charges. 

| Term | Description |
| --- | --- |
| Usage charges |Usage charges are total monthly charges on a subscription. You are billed for your past month’s usage. |
| Discounts |Service discounts applied to your current bill. |
| Adjustments |Miscellaneous credits or outstanding charges applied to your current bill. For example, if you have the Visual Studio Enterprise with MSDN offer, you see a monthly credit. If you cancel your subscription, you see any monthly usage charges that exceed the monthly credit that you get with your subscription offer. The charges are from the start of your current billing period up to the subscription cancellation date. |

## <a name="csv"></a> Understand detailed usage charges (.csv)
The usage file shows how much of each resource was used within the current billing period. It’s available in a comma-separated values (.csv) file format that you can open in a spreadsheet application. If you see two versions available, download version 2. That's the most current file format.

Usage charges are the total **monthly** charges on a subscription minus any credit or discount. You are billed for your past month’s usage.  

The following sections describe most of the terms shown in version 2 of the detailed usage file.

### Statement 
The top section of the file shows the services that you used during the previous month's billing cycle. The following table lists the terms and descriptions shown in this section.

| Term | Description |
| --- | --- |
|Billing Period |The billing period when the resource or service was used. |
|Meter Category |Identifies the top-level service for which this usage belongs. |
|Meter Sub-Category |Defines the type of Azure service and can affect the rate. |
|Meter Name |Identifies the unit of measure for the resource being consumed. |
|Meter Region |Identifies the location of the datacenter for certain services that are priced based on datacenter location. |
|SKU |Identifies the unique system identifier for each Azure resource. |
|Unit |Identifies the Unit that the service is charged in. For example, GB, hours, 10,000 s. |
|Consumed Quantity |The amount of the resource used during the billing period. |
|Included Quantity |The amount of the resource that is included at no charge in your current billing period. |
|Overage Quantity |Shows the difference between the Consumed Quantity and the Included Quantity. You're billed for this amount. For Pay-As-You-Go offers with no amount included with the offer, this total is the same as the Consumed Quantity. |
|Within Commitment |Shows the resource charges that are subtracted from your commitment amount associated with your 6 or 12-month offer. Resource charges are subtracted in chronological order. |
|Currency |The currency used in your current billing period. |
|Overage |Shows the resource charges that exceed your commitment amount associated with your 6 or 12-month offer. |
|Commitment Rate |Shows the commitment rate based on the total commitment amount associated with your 6 or 12-month offer. |
|Rate |The rate you're charged per billable unit. |
|Value |Shows the result of multiplying the Overage Quantity column by the Rate column. If the Consumed Quantity doesn't exceed the Included Quantity, there is no charge in this column. |

### Daily usage 

The Daily usage section of the file shows usage details that affect the billing rates. The following table lists the terms and descriptions shown in this section. 

| Term| Description |
| --- | --- |
|Usage Date |The date when the resource was used. |
|Meter Category |Identifies the top-level service for which this usage belongs. |
|Meter ID |The billed meter identifier that's used to price billing usage. |
|Meter Sub-Category |Defines the Azure service type that can affect the rate. |
|Meter Name |Identifies the unit of measure for the resource being consumed. |
|Meter Region|Identifies the location of the datacenter for certain services that are priced based on datacenter location. |
|Unit |Identifies the unit that the service is charged in. For example, GB, hours, 10,000 s. |
|Consumed Quantity |The amount of the resource that has been consumed for that day. |
|Resource Location |Identifies the datacenter where the resource is running. |
|Consumed Service |The Azure platform service that you used. |
|Resource Group |The resource group in which the deployed resource is running in. For more information, see [Azure Resource Manager overview](azure-resource-manager/resource-group-overview.md). |
|Instance ID |The identifier for the resource. The identifier contains the name you specify for the resource when it was created. It's either the name of the resource or the fully qualified Resource ID. For more information, see [Azure Resource Manager API](https://docs.microsoft.com/rest/api/resources/resources). |
|Tags |Tag you assign to the resource. Use tags to group billing records. For example, you can use tags to distribute costs by the department that uses the resource. Services that support emitting tags are virtual machines, storage, and networking services provisioned by using the [Azure Resource Manager API](https://docs.microsoft.com/rest/api/resources/resources). For more information, see [Organize your Azure resources with tags](http://azure.microsoft.com/updates/organize-your-azure-resources-with-tags/). |
|Additional Info |Service-specific metadata. For example, an image type for a virtual machine. |
|Service Info 1 |The project name that the service belongs to on your subscription. |
|Service Info 2 |Legacy field that captures optional service-specific metadata. |

## How do I make a payment?
If you set up a credit card or a debit card as your payment method, the payment is made automatically. On your credit card statement, the line item would say **MSFT Azure**.

## What about Marketplace orders or external service charges?
External services used to be called Marketplace orders. External Services are provided by independent service vendors, but are integrated within Azure. 

## Need help? Contact support. 
If you still need help, [contact support](https://portal.azure.com/?#blade/Microsoft_Azure_Support/HelpAndSupportBlade) to get your issue resolved quickly.
 



