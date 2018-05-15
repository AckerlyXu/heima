---
title: Overview of SQL Server on Azure Linux Virtual Machines | Azure
description: Learn about how to run full SQL Server editions on Azure Linux Virtual machines. Get direct links to all Linux SQL Server VM images and related content.
services: virtual-machines-linux
documentationcenter: ''
author: rockboyfor
manager: digimobile
tags: azure-service-management
ms.service: virtual-machines-sql
ms.devlang: na
ms.topic: get-started-article
ms.workload: iaas-sql-server
origin.date: 04/10/2018
ms.date: 05/21/2018
ms.author: v-yeche
---
# Overview of SQL Server on Azure Virtual Machines (Linux)

> [!div class="op_single_selector"]
> * [Windows](../../windows/sql/virtual-machines-windows-sql-server-iaas-overview.md)
> * [Linux](sql-server-linux-virtual-machines-overview.md)

SQL Server on Azure virtual machines enables you to use full versions of SQL Server in the Cloud without having to manage any on-premises hardware. SQL Server VMs also simplify licensing costs when you pay as you go.

Azure virtual machines run in many different [geographic regions](https://www.azure.cn/support/service-dashboard/) around China. They also offer a variety of [machine sizes](../sizes.md). The virtual machine image gallery allows you to create a SQL Server VM with the right version, edition, and operating system. This makes virtual machines a good option for a many different SQL Server workloads.
<!--Notice: Change around the world to China -->

<a name="create"></a>
##  Get started with SQL VMs

To get started, choose a SQL Server virtual machine image with your required version, edition, and operating system. The following sections provide direct links to the Azure portal for the SQL Server virtual machine gallery images.

> [!TIP]
> For more information about how to understand pricing for SQL images, see [the pricing page for Linux SQL Server VMs](https://www.azure.cn/pricing/details/virtual-machines/).

| Version | Operating System | Edition |
| --- | --- | --- |
| **SQL Server 2017** | Ubuntu 16.04 LTS |[Enterprise](https://portal.azure.cn/#create/Microsoft.SQLServer2017EnterpriseonUbuntuServer1604LTS), [Standard](https://portal.azure.cn/#create/Microsoft.SQLServer2017StandardonUbuntuServer1604LTS), [Web](https://portal.azure.cn/#create/Microsoft.SQLServer2017WebonUbuntuServer1604LTS), [Express](https://portal.azure.cn/#create/Microsoft.FreeSQLServerLicenseSQLServer2017ExpressonUbuntuServer1604LTS), [Developer](https://portal.azure.cn/#create/Microsoft.FreeSQLServerLicenseSQLServer2017DeveloperonUbuntuServer1604LTS) |
<!-- Not Avaiable on RHEL (Red Har Enterprise License) -->
<!-- Not Avaiable on SLES (SUSE Linux Enterprise Server) -->

> [!NOTE]
> To see the available Windows SQL Server virtual machine images, see [Overview of SQL Server on Azure Virtual Machines (Windows)](../../windows/sql/virtual-machines-windows-sql-server-iaas-overview.md).

<a name="packages"></a>
##  Installed packages

When you configure SQL Server on Linux, you install the database engine package and then several optional packages depending on your requirements. The Linux virtual machine images for SQL Server automatically install most packages for you. The following table shows which packages are installed for each distribution.

| Distribution | [Database Engine](https://docs.microsoft.com/sql/linux/sql-server-linux-setup) | [Tools](https://docs.microsoft.com/sql/linux/sql-server-linux-setup-tools) | [SQL Server Agent](https://docs.microsoft.com/sql/linux/sql-server-linux-setup-sql-agent) | [Full-Text Search](https://docs.microsoft.com/sql/linux/sql-server-linux-setup-full-text-search) | [SSIS](https://docs.microsoft.com/sql/linux/sql-server-linux-setup-ssis) | [HA add-on](https://docs.microsoft.com/sql/linux/sql-server-linux-business-continuity-dr) |
|---|---|---|---|---|---|---|
| Ubuntu | ![yes](./media/sql-server-linux-virtual-machines-overview/yes.png) | ![yes](./media/sql-server-linux-virtual-machines-overview/yes.png) | ![yes](./media/sql-server-linux-virtual-machines-overview/yes.png) | ![yes](./media/sql-server-linux-virtual-machines-overview/yes.png) | ![yes](./media/sql-server-linux-virtual-machines-overview/yes.png) | ![yes](./media/sql-server-linux-virtual-machines-overview/yes.png) |
<!-- Not Avaiable on RHEL (Red Har Enterprise License) -->
<!-- Not Avaiable on SLES (SUSE Linux Enterprise Server) -->

## Related products and services

### Linux Virtual Machines

* [Virtual Machines overview](../overview.md)

### Storage

* [Introduction to Azure Storage](../../../storage/common/storage-introduction.md)

### Networking

* [Virtual Network overview](../../../virtual-network/virtual-networks-overview.md)
* [IP addresses in Azure](../../../virtual-network/virtual-network-ip-addresses-overview-arm.md)
* [Create a Fully Qualified Domain Name in the Azure portal](../portal-create-fqdn.md)

### SQL

* [SQL Server on Linux documentation](https://docs.microsoft.com/sql/linux)
* [Azure SQL Database comparison](../../../sql-database/sql-database-paas-vs-sql-server-iaas.md)

## Next steps

Get started with SQL Server on Azure Linux virtual machines:

* [Create a SQL Server VM in the Azure portal](provision-sql-server-linux-virtual-machine.md)

Get answers to commonly asked questions about SQL VMs on Linux:

* [SQL Server on Azure Linux Virtual Machines FAQ](sql-server-linux-faq.md)
<!-- Update_Description: update meta properties, wording update, update link -->