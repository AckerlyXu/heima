---
title: Manage costs effectively for SQL Server on Azure virtual machines | Azure
description: Provides best practices for choosing the right SQL Server virtual machine pricing model.
services: virtual-machines-windows
documentationcenter: na
author: luisherring
manager: jhubbard
editor: ''
tags: azure-service-management

ms.assetid: 
ms.service: virtual-machines-sql
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: vm-windows-sql-server
ms.workload: iaas-sql-server
origin.date: 04/18/2017
ms.date: 07/03/2017
ms.author: v-dazen

---
# Pricing guidance for SQL Server Azure VMs

This topic provides pricing guidance for SQL Server virtual machines in Azure. There are several options that affect cost, and it is important to pick the right image that balances costs with business requirements.

## Free-licensed SQL Server editions

If you want to develop, test, or build a proof of concept, then use the free-licensed **SQL Server Developer edition**. This edition has everything in SQL Server Enterprise edition, thus you can use it to build whatever application you want. It's just not allowed to run in production. A SQL Server Developer VM will only charge for the cost of the VM, not for SQL Server licensing.

If you want to run a lightweight workload in production (<4 cores, <1 GB memory, <10 GB/database), then use the free-licensed **SQL Server Express edition**. A SQL Express VM will only charge for the cost of the VM, not SQL licensing.

For these development/test or lightweight production workloads, you can also save money by choosing a smaller VM size that matches these workloads. The DS1v2 might be a good choice for these workloads.

To create a SQL Server 2016 Azure VM with one of these images, see the following links:

- [SQL Server 2016 Developer Azure VM](https://portal.azure.cn/#create/Microsoft.FreeLicenseSQLServer2016SP1DeveloperWindowsServer2016-ARM)
- [SQL Server 2016 Express Azure VM](https://portal.azure.cn/#create/Microsoft.FreeLicenseSQLServer2016SP1ExpressWindowsServer2016-ARM)

## Paid SQL Server editions

If you have a non-lightweight production workload, use one of the following SQL Server editions:

| SQL Server Edition | Workload |
|-----|-----|
| Web | Small web sites |
| Standard | Small to medium workloads |
| Enterprise | Large or mission-critical workloads|

You have two options to pay for SQL Server licensing for these editions: *pay per usage* or *bring your own license*.

### Pay per usage

**Paying the SQL Server license per usage** means that the per-minute cost of running the Azure VM includes the cost of the SQL Server license. You can see the pricing for the different SQL Server editions (Web, Standard, Enterprise) in the [Azure VM pricing page](https://www.azure.cn/pricing/details/virtual-machines/). The cost is the same for all versions of SQL Server (2008 R2 to 2016). As with SQL Server licensing in general, the per-minute licensing cost depends on the number of VM cores.

Paying the SQL Server licensing per usage is recommended for:

- Temporary or periodic workloads. For example, an app that needs to support an event for a couple of months every year, or business analysis on Mondays.
- Workloads with unknown lifetime or scale. For example, an app that may not be required in a few months, or which may require more, or less compute power, depending on demand.

To create a SQL Server 2016 Azure VM with one of these pay-per-usage images, see the following links:

- [SQL Server 2016 Web Azure VM](https://portal.azure.cn/#create/Microsoft.SQLServer2016SP1WebWindowsServer2016)
- [SQL Server 2016 Standard Azure VM](https://portal.azure.cn/#create/Microsoft.SQLServer2016SP1StandardWindowsServer2016)
- [SQL Server 2016 Enterprise Azure VM](https://portal.azure.cn/#create/Microsoft.SQLServer2016SP1EnterpriseWindowsServer2016)

> [!IMPORTANT]
> When you create a SQL Server virtual machine in the Azure portal, the estimated monthly cost displayed on the **Choose a size** blade does not include SQL Server licensing costs. This is the cost of the VM alone.
>
> ![Choose VM size blade](./media/virtual-machines-windows-sql-server-pricing-guidance/sql-vm-choose-size-pricing-estimate.png)
>
>For the free-licensed Express and Developer editions of SQL Server, this is the total estimated cost. But for Web, Standard, and Enterprise, find the additional SQL licensing costs on the [Windows Virtual Machines pricing page](https://www.azure.cn/pricing/details/virtual-machines/windows/). On the pricing page, select your target edition of SQL Server.

## Avoid unecessary costs

If you are using any workloads that do not run continuously, consider shutting down the virtual machine during the inactive periods. You only pay for what you use.

For example, if you are simply trying out SQL Server on an Azure VM, you would not want to incur charges by accidentally leaving it running for weeks. One solution is to use the [automatic shutdown feature](https://azure.microsoft.com/blog/announcing-auto-shutdown-for-vms-using-azure-resource-manager/).

![SQL VM autoshutdown](./media/virtual-machines-windows-sql-server-pricing-guidance/sql-vm-auto-shutdown.png)

For other workflows, consider automatically shutting down and restarting Azure VMs with a scripting solution,such as [Azure Automation](https://www.azure.cn/home/features/automation/).

> [!IMPORTANT]
> Shutting down and deallocating your VM is the only way to avoid charges. Simply stopping or using power options to shut down the VM still incurs usage charges.

## Next steps

For the latest Virtual Machines pricing, including SQL Server, see the [Azure VM pricing page](https://www.azure.cn/pricing/details/virtual-machines/).

Review other SQL Server Virtual Machine topics at [SQL Server on Azure Virtual Machines Overview](virtual-machines-windows-sql-server-iaas-overview.md).