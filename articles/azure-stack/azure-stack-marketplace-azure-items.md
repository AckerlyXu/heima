---
title: Azure Marketplace items available for Azure Stack | Microsoft Docs
description: These Azure Marketplace items can be used in Azure Stack.
services: azure-stack
documentationcenter: ''
author: brenduns
manager: femila
editor: ''

ms.assetid:
ms.service: azure-stack
ms.workload: na
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 04/11/2018
ms.date: 04/23/2018
ms.author: v-junlch
ms.reviewer: jeffgo

---
# Azure Marketplace items available for Azure Stack

*Applies to: Azure Stack integrated systems and Azure Stack Development Kit*


## Virtual Machine Extensions
Whenever there are updates to virtual machine (VM) extensions you use, you should download them. Extensions shipped in the product do not update in the normal patch and update process; so check for updates frequently. Other extensions are only available through Marketplace Management.

|  | Item name | Description | Publisher | OS Type |
| --- | --- | --- | --- | --- |
|![SQL IaaS Extension](./media/azure-stack-marketplace-azure-items/cse.png) | [ SQL IaaS Extension ](/virtual-machines/windows/sql/virtual-machines-windows-sql-server-agent-extension)| <b>Download this extension to deploy any SQL Server on Windows Marketplace item - this extension is required.</b> | Microsoft | Windows |
|![Custom Script Extension](./media/azure-stack-marketplace-azure-items/cse.png) | [ Custom Script Extension ](/virtual-machines/windows/extensions-customscript)| <b>Download this update to the in-box version of the Custom Script Extension for Windows.</b> | Microsoft | Windows |
|![PowerShell DSC Extension](./media/azure-stack-marketplace-azure-items/dsc.png) | [ PowerShell DSC Extension ](/virtual-machines/windows/extensions-dsc-overview)| <b>Download this update to the in-box version of the PowerShell DSC Extension. Updated to support TLS v1.2.</b> | Microsoft | Windows |
| ![Microsoft Antimalware Extension](./media/azure-stack-marketplace-azure-items/cse.png) | [ Microsoft Antimalware Extension ](/security/azure-security-antimalware)| Microsoft Antimalware for Azure is a single-agent solution for applications and tenant environments, designed to run in the background without human intervention. | Microsoft | Windows |
|![Custom Script Extension](./media/azure-stack-marketplace-azure-items/cse.png) | [ Custom Script Extension ](/virtual-machines/windows/extensions-customscript)| <b>Download this update to the in-box version of the Custom Script Extension for Linux. There are multiple versions of this extension and you should download both 1.5.2.1 and 2.0.x. </b> | Microsoft | Linux |
| ![Docker Extension](./media/azure-stack-marketplace-azure-items/dockerextension.png) | [Docker](https://azuremarketplace.microsoft.com/marketplace/apps/microsoft.docker-arm) | Docker Extension for Linux Virtual Machines. | Microsoft | Linux |
| ![VM Access for Linux](./media/azure-stack-marketplace-azure-items/cse.png) | [ VM Access for Linux ](https://azure.microsoft.com/blog/using-vmaccess-extension-to-reset-login-credentials-for-linux-vm/)| <b>Download this update to the in-box version of the VMAccess for Linux Extension. This update is important if you plan to use Debian Linux VMs.</b> | Microsoft | Linux |
| ![CloudLink SecureVM Extension for Linux](./media/azure-stack-marketplace-azure-items/cloudlink.png) | [ CloudLink SecureVM Extension for Linux ](https://azuremarketplace.microsoft.com/en-us/marketplace/apps/cloudlink.cloudlink-securevm)  | Control, monitor, and encrypt VMs with ease and confidence. | Dell EMC | Linux |
| ![CloudLink SecureVM Extension for Windows](./media/azure-stack-marketplace-azure-items/cloudlink.png) | [ CloudLink SecureVM Extension for Windows ](https://azuremarketplace.microsoft.com/en-us/marketplace/apps/cloudlink.cloudlink-securevm)  | Control, monitor, and encrypt VMs with ease and confidence. | Dell EMC | Windows |

## Microsoft Virtual Machine Images and Solution Templates

Azure Stack supports the following Azure Marketplace virtual machines and solution templates. Download any dependencies separately, as noted. Applications such as SQL Server and Machine Learning Server require proper licensing, except where marked as Free or Trial.

|  | Item name | Description | Publisher |
| --- | --- | --- | --- |
| ![Windows Server](./media/azure-stack-marketplace-azure-items/windowsserver.png) | [Windows Server](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.WindowsServer) | Enterprise-class solutions that are simple to deploy, cost-effective, application-focused, and user-centric. These images are updated regularly with the latest patches. <b>Important information: Images downloaded before January 18, 2018 must be deleted and replaced with the latest versions.</b> | Microsoft |
| ![Remote Desktop Services](./media/azure-stack-marketplace-azure-items/remotedesktopservicesdeployment.png) | [Remote Desktop Services (RDS) Deployment](https://azuremarketplace.microsoft.com/marketplace/apps/rds.remote-desktop-services-basic-deployment) | Create a basic Remote Desktop Services (RDS) deployment. <b>Download the latest Windows Server 2016 Datacenter image.</b> | Microsoft |
| ![SharePoint Server 2013 Trial](./media/azure-stack-marketplace-azure-items/sharepoint.png) | [SharePoint Server 2013 Trial](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.SharePointServer2013Trial) | Microsoft SharePoint Server 2013 Trial on Windows Server 2012 Datacenter and Visual Studio 2017 community edition. | Microsoft |
| ![SharePoint Server 2016 Trial](./media/azure-stack-marketplace-azure-items/sharepoint.png) | [SharePoint Server 2016 Trial](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.SharePointServer2016Trial) | Microsoft SharePoint Server 2016 Trial on Windows Server 2016 Datacenter. | Microsoft |
| ![SQL Server 2014 SP2 on Windows Server 2012 R2](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2014 SP2 on Windows Server 2012 R2](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.SQL2014SP2-WS2012R2) | SQL Server 2014 Service Pack 2. **Required download:** SQL IaaS Extension. | Microsoft |
| ![SQL Server 2016 SP1 Standard on Windows Server 2016](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2016 SP1 Standard on Windows Server 2016](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.SQL2016SP1-WS2016) | Database platform for intelligent, mission-critical applications. **Required download:** SQL IaaS Extension. | Microsoft |
| ![SQL Server 2016 SP1 Developer on Windows Server 2016](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2016 SP1 Developer on Windows Server 2016](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.FreeLicenseSQLServer2016SP1DeveloperWindowsServer2016) | Free developer version of SQL Server 2016 SP1 for transactional, data warehousing, business intelligence, and analytics workloads. **Required download:** SQL IaaS Extension. | Microsoft |
| ![SQL Server 2016 SP1 Express on Windows Server 2016](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2016 SP1 Express on Windows Server 2016](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.FreeLicenseSQLServer2016SP1ExpressWindowsServer2016) | Free express version of SQL Server 2016 SP1. **Required download:** SQL IaaS Extension. | Microsoft |
| ![SQL Server 2016 SP1 Enterprise on Windows Server 2016](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2016 SP1 Enterprise on Windows Server 2016](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.SQL2016SP1-WS2016) | Database platform for intelligent, mission-critical applications. **Required download:** SQL IaaS Extension. | Microsoft |
| ![SQL Server 2016 SP1 Web on Windows Server 2016](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2016 SP1 Web on Windows Server 2016](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.SQL2016SP1-WS2016) | Database platform for intelligent, mission-critical applications. **Required download:** SQL IaaS Extension. | Microsoft |
| ![SQL Server 2017 Standard on Windows Server 2016](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2017 Standard on Windows Server 2016](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.SQLServer2017StandardonWindowsServer2016) | Database platform for intelligent, mission-critical applications. **Required download:** SQL IaaS Extension. | Microsoft |
| ![SQL Server 2017 Developer on Windows Server 2016](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2017 Developer on Windows Server 2016](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.FreeSQLServerLicenseSQLServer2017DeveloperonWindowsServer2016) | Free developer version of SQL Server 2016 SP1 for transactional, data warehousing, business intelligence, and analytics workloads. **Required download:** SQL IaaS Extension. | Microsoft |
| ![SQL Server 2017 Express on Windows Server 2016](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2017 Express on Windows Server 2016](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.FreeSQLServerLicenseSQLServer2017ExpressonWindowsServer2016) | Free express version of SQL Server 2016 SP1. **Required download:** SQL IaaS Extension. | Microsoft |
| ![SQL Server 2017 Enterprise on Windows Server 2016](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2017 Enterprise on Windows Server 2016](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.SQLServer2017EnterpriseWindowsServer2016) | Database platform for intelligent, mission-critical applications. **Required download:** SQL IaaS Extension. | Microsoft |
| ![](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2017 Web on Windows Server 2016](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.SQLServer2017WebonWindowsServer2016) | Database platform for intelligent, mission-critical applications. **Required download:** SQL IaaS Extension. | Microsoft |
| ![SQL Server 2017 Standard on Ubuntu Server 16.04 LTS](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2017 Standard on Ubuntu Server 16.04 LTS](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.SQLServer2017StandardonUbuntuServer1604LTS) | Database platform for intelligent, mission-critical applications. | Microsoft + Canonical |
| ![SQL Server 2017 Developer on Ubuntu Server 16.04 LTS](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2017 Developer on Ubuntu Server 16.04 LTS](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.FreeSQLServerLicenseSQLServer2017DeveloperonUbuntuServer1604LTS) | Free developer version of SQL Server 2016 SP1 for transactional, data warehousing, business intelligence, and analytics workloads. | Microsoft + Canonical |
| ![SQL Server 2017 Express on Ubuntu Server 16.04 LTS](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2017 Express on Ubuntu Server 16.04 LTS](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.FreeSQLServerLicenseSQLServer2017ExpressonUbuntuServer1604LTS) | Free express version of SQL Server 2016 SP1. | Microsoft + Canonical |
| ![SQL Server 2017 Enterprise on Ubuntu Server 16.04 LTS](./media/azure-stack-marketplace-azure-items/sql.png) | SQL Server 2017 Enterprise on Ubuntu Server 16.04 LTS | Database platform for intelligent, mission-critical applications. | Microsoft + Canonical |
| ![SQL Server 2017 Web on Ubuntu Server 16.04 LTS](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2017 Web on Ubuntu Server 16.04 LTS](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.SQLServer2017WebonUbuntuServer1604LTS) | Database platform for intelligent, mission-critical applications. | Microsoft + Canonical |
| ![QL Server 2017 Standard on SUSE Linux Enterprise Server (SLES) 12 SP2](./media/azure-stack-marketplace-azure-items/sql.png) | SQL Server 2017 Standard on SUSE Linux Enterprise Server (SLES) 12 SP2 | Database platform for intelligent, mission-critical applications. | Microsoft + SUSE |
| ![SQL Server 2017 Developer on SUSE Linux Enterprise Server (SLES) 12 SP2](./media/azure-stack-marketplace-azure-items/sql.png) | SQL Server 2017 Developer on SUSE Linux Enterprise Server (SLES) 12 SP2 | Free developer version of SQL Server 2016 SP1 for transactional, data warehousing, business intelligence, and analytics workloads. | Microsoft + SUSE |
| ![SQL Server 2017 Express on SUSE Linux Enterprise Server (SLES) 12 SP2](./media/azure-stack-marketplace-azure-items/sql.png) | [SQL Server 2017 Express on SUSE Linux Enterprise Server (SLES) 12 SP2](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.FreeSQLServerLicenseSQLServer2017ExpressonSLES12SP2) | Free express version of SQL Server 2016 SP1. | Microsoft + SUSE |
| ![SQL Server 2017 Enterprise on SUSE Linux Enterprise Server (SLES) 12 SP2](./media/azure-stack-marketplace-azure-items/sql.png) | SQL Server 2017 Enterprise on SUSE Linux Enterprise Server (SLES) 12 SP2 | Database platform for intelligent, mission-critical applications. | Microsoft + SUSE |
| ![SQL Server 2017 Web on SUSE Linux Enterprise Server (SLES) 12 SP2](./media/azure-stack-marketplace-azure-items/sql.png) | SQL Server 2017 Web on SUSE Linux Enterprise Server (SLES) 12 SP2| Database platform for intelligent, mission-critical applications. | Microsoft + SUSE |
| ![Microsoft Machine Learning Server 9.3.0 on Windows Server 2016](./media/azure-stack-marketplace-azure-items/microsoft.png) | [Microsoft Machine Learning Server 9.3.0 on Windows Server 2016 ](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.MicrosoftMachineLearningServer930onWindowsServer2016) | Microsoft Machine Learning Server 9.3.0 on Windows Server 2016. | Microsoft |
| ![Microsoft Machine Learning Server 9.3.0 on Ubuntu 16.04](./media/azure-stack-marketplace-azure-items/microsoft.png) | [Microsoft Machine Learning Server 9.3.0 on Ubuntu 16.04 ](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.MicrosoftMachineLearningServer930onUbuntu1604) | Microsoft Machine Learning Server 9.3.0 on Ubuntu 16.04. | Microsoft + Canonical |
| ![Microsoft Machine Learning Server 9.3.0 on CentOS Linux 7.2](./media/azure-stack-marketplace-azure-items/microsoft.png) | [Microsoft Machine Learning Server 9.3.0 on CentOS Linux 7.2 ](https://azuremarketplace.microsoft.com/marketplace/apps/Microsoft.MicrosoftMachineLearningServer930onCentOSLinux72) | Microsoft Machine Learning Server 9.3.0 on CentOS Linux 7.2. | Microsoft + Rogue Wave |


## Linux Distributions
|  | Item name | Description | Publisher |
| --- | --- | --- | --- |
| ![Ubuntu Server](./media/azure-stack-marketplace-azure-items/ubuntu.png) | [Ubuntu Server](https://azuremarketplace.microsoft.com/marketplace/apps/Canonical.UbuntuServer) | Ubuntu Server is the world's most popular Linux for cloud environments. | Canonical |
| ![SLES 12 SP3 (BYOS)](./media/azure-stack-marketplace-azure-items/suse.png) | SLES 12 SP3 (BYOS) | SUSE Linux Enterprise Server 12 SP3. | SUSE |

## Third-Party BYOL, Free, and Trial images and Solution Templates

|  | Item name | Description | Publisher |
| --- | --- | --- | --- |
| ![SUSE Manager 3.0 Proxy (BYOS)](./media/azure-stack-marketplace-azure-items/suse.png) | SUSE Manager 3.0 Proxy (BYOS) | Best-in-class open-source infrastructure management. | SUSE |


<!-- Update_Description: wording update -->