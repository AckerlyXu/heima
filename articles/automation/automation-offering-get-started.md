--- 
title:  Get Started with Azure Automation | Azure
description: This article provides an overview of Azure Automation service by reviewing the design and implementation details in preparation to onboard the offering from Azure Marketplace. 
services: automation
documentationcenter: ''
author: yunan2016
manager: digimobile
editor: ''

ms.assetid: 
ms.service: automation
ms.workload: tbd
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: get-started-article
origin.date: 08/31/2017
ms.date: 01/15/2018
ms.author: v-nany

---

# Getting Started with Azure Automation

This getting started guide introduces core concepts related to the deployment of Azure Automation. If you are new to Automation in Azure or have experience with automation workflow software like System Center Orchestrator, this guide helps you understand how to prepare and onboard Automation.  Afterwards, you will be prepared to begin developing runbooks in support of your process automation needs. 


## Automation architecture overview

![Azure Automation overview](media/automation-offering-get-started/automation-infradiagram-networkcomms.png)

Azure Automation is a software as a service (SaaS) application that provides a scalable and reliable, multi-tenant environment to automate processes with runbooks and manage configuration changes to Windows and Linux systems using Desired State Configuration (DSC) in Azure, other cloud services, or on-premises. Entities contained within your Automation account, such as runbooks, assets, Run As accounts are isolated from other Automation accounts within your subscription and other subscriptions.  

Runbooks that you run in Azure are executed on Automation sandboxes, which are hosted in Azure platform as a service (PaaS) virtual machines.  Automation sandboxes provide tenant isolation for all aspects of runbook execution – modules, storage, memory, network communication, job streams, etc. This role is managed by the service and is not accessible from your Azure or Azure Automation account for you to control.         

To automate the deployment and management of resources in your local datacenter or other cloud services, after creating an Automation account, you can designate one or more machines to run the [Hybrid Runbook Worker (HRW)](automation-hybrid-runbook-worker.md)  role.  Each HRW requires the Microsoft Management Agent with a connection to a Log Analytics workspace and an Automation account.  Log Analytics is used to bootstrap the installation, maintain the Microsoft Management Agent, and monitor the functionality of the HRW.  The delivery of runbooks and the instruction to run them are performed by Azure Automation.

You can deploy multiple HRW to provide high availability for your runbooks, load balance runbook jobs, and in some cases dedicate them for particular workloads or environments.  The Microsoft Monitoring Agent on the HRW initiates communication with the Automation service over TCP port 443 and there are no inbound firewall requirements.  Once you have runbook running on an HRW within the environment, and you want the runbook to perform management tasks against other machines or services within that environment, there may be other ports that the runbook needs access to.  

Runbooks running on an HRW run in the context of the local System account on the computer, which is the recommended security context when performing administrative actions on the local Windows machine. If you want the runbook to run tasks against resources outside of the local machine, you may need to define secure credential assets in the Automation account that you can access from the runbook and use to authenticate with the external resource. You can use [Credential](automation-credentials.md), [Certificate](automation-certificates.md), and [Connection](automation-connections.md) assets in your runbook with cmdlets that allow you to specify credentials so you can authenticate them.

DSC configurations stored in Azure Automation can be directly applied to Azure virtual machines. Other physical and virtual machines can request configurations from the Azure Automation DSC pull server.  For managing configurations of your on-premise physical or virtual Windows and Linux systems, you don't need to deploy any infrastructure to support the Automation DSC pull server, only outbound Internet access from each system to be managed by Automation DSC, communicating over TCP port 443 to the OMS service.   

## Prerequisites

### Automation DSC
Azure Automation DSC can be used to manage various machines:

* Azure virtual machines (classic) running Windows or Linux
* Azure virtual machines running Windows or Linux
* Amazon Web Services (AWS) virtual machines running Windows or Linux
* Physical/virtual Windows computers on-premises, or in a cloud other than Azure or AWS
* Physical/virtual Linux computers on-premises, or in a cloud other than Azure or AWS

The latest version of WMF 5 must be installed for the PowerShell DSC agent for Windows to be able to communicate with Azure Automation. The latest version of the [PowerShell DSC agent for Linux](https://www.microsoft.com/en-us/download/details.aspx?id=49150) must be installed for Linux to be able to communicate with Azure Automation.

### Hybrid Runbook Worker  
When designating a computer to run hybrid runbook jobs, this computer must have the following:

* Windows Server 2012 or later
* Windows PowerShell 4.0 or later.  We recommend installing Windows PowerShell 5.0 on the computer for increased reliability. You can download the new version from the [Microsoft Download Center](https://www.microsoft.com/download/details.aspx?id=50395)
* .NET Framework 4.6.2 or later
* Minimum of two cores
* Minimum of 4 GB of RAM

### Permissions required to create Automation account
To create or update an Automation account, you must have the following specific privileges and permissions required to complete this topic.   
 
* In order to create an Automation account, your AD user account needs to be added to a role with permissions equivalent to the Owner role for Microsoft.Automation resources as outlined in article [Role-based access control in Azure Automation](automation-role-based-access-control.md).  
* If the App registrations setting is set to **Yes**, non-admin users in your Azure AD tenant can [register AD applications](../azure-resource-manager/resource-group-create-service-principal-portal.md#check-azure-subscription-permissions).  If the app registrations setting is set to **No**, the user performing this action must be a global administrator in Azure AD. 

If you are not a member of the subscription’s Active Directory instance before you are added to the global administrator/co-administrator role of the subscription, you are added to Active Directory as a guest. In this situation, you receive a “You do not have permissions to create…” warning on the **Add Automation Account** blade. Users who were added to the global administrator/co-administrator role first can be removed from the subscription's Active Directory instance and re-added to make them a full User in Active Directory. To verify this situation, from the **Azure Active Directory** pane in the Azure portal, select **Users and groups**, select **All users** and, after you select the specific user, select **Profile**. The value of the **User type** attribute under the users profile should not equal **Guest**.

## Authentication planning
Azure Automation allows you to automate tasks against resources in Azure, on-premises, and with other cloud providers.  In order for a runbook to perform its required actions, it must have permissions to securely access the resources with the minimal rights required within the subscription.  

### What is an Automation Account 
All the automation tasks you perform against resources using the Azure cmdlets in Azure Automation authenticate to Azure using Azure Active Directory organizational identity credential-based authentication.  An Automation account is separate from the account you use to sign in to the portal to configure and use Azure resources.  Automation resources included with an account are the following:

* **Certificates** - contains a certificate used for authentication from a runbook or DSC configuration or add them.
* **Connections** - contains authentication and configuration information required to connect to an external service or application from a runbook or DSC configuration.
* **Credentials** - is a PSCredential object which contains security credentials such as a username and password required to authenticate from a runbook or DSC configuration.
* **Integration modules** - are PowerShell modules included with an Azure Automation account to make use of cmdlets within runbooks and DSC configurations.
* **Schedules** - contains schedules that starts or stops a runbook at a specified time, including recurring frequencies.
* **Variables** - contain values that are available from a runbook or DSC configuration.
* **DSC Configurations** - are PowerShell scripts that describes how to configure an operating system feature or setting or install an application on a Windows or Linux computer.  
* **Runbooks** - are a set of tasks that perform some automated process in Azure Automation based on Windows PowerShell.    

The Automation resources for each Automation account are associated with a single Azure region, but Automation accounts can manage all the resources in your subscription. Create Automation accounts in different regions if you have policies that require data and resources to be isolated to a specific region.

> [!NOTE]
> Automation accounts, and the resources they contain that are created in the Azure portal, cannot be accessed in the Azure classic portal. If you want to manage these accounts or their resources with Windows PowerShell, you must use the Azure Resource Manager modules.
> 

When you create an Automation account in the Azure portal, you automatically create two authentication entities:

* A Run As account. This account creates a service principal in Azure Active Directory (Azure AD) and a certificate. It also assigns the Contributor role-based access control (RBAC), which manages Resource Manager resources by using runbooks.
* A Classic Run As account. This account uploads a management certificate, which is used to manage classic resources by using runbooks.

Role-based access control is available with Azure Resource Manager to grant permitted actions to an Azure AD user account and Run As account, and authenticate that service principal.  Read [Role-based access control in Azure Automation article](automation-role-based-access-control.md) for further information to help develop your model for managing Automation permissions.  

#### Authentication methods
The following table summarizes the different authentication methods for each environment supported by Azure Automation.

| Method | Environment 
| --- | --- | 
| Azure Run As and Classic Run As account |Azure Resource Manager and Azure classic deployment |  
| Azure AD User account |Azure Resource Manager and Azure classic deployment |  
| Windows authentication |Local data center or other cloud provider using the Hybrid Runbook Worker |  
| AWS credentials |Amazon Web Services |  

Under the **How to\Authentication and security** section, are supporting articles providing overview and implementation steps to configure authentication for those environments, either with an existing or new account you dedicate for that environment.  For the Azure Run As and Classic Run As account, the topic [Update Automation Run As account](automation-create-runas-account.md) describes how to update your existing Automation account with the Run As accounts from the portal or using PowerShell if it was not originally configured with a Run As or Classic Run As account. If you want to create a Run As and a Classic Run As account with a certificate issued by your enterprise certification authority (CA), review this article to learn how to create the accounts using this configuration.     
 

## Creating an Automation account

There are different ways you can create an Automation account in the Azure portal.  The following table introduces each type of deployment experience and differences between them.  

|Method | Description |
|-------|-------------|
| Select Automation from the Marketplace | Creates an Automation account in a new or existing resource group that is not linked to an OMS workspace and does not include any available solutions from the Automation & Control offering. This is a basic configuration that introduces you to Automation and can help you learn how to write runbooks, DSC configurations, and use the capabilities of the service. |



## Next steps
* You can confirm your new Automation account can authenticate against Azure resources by reviewing [test Azure Automation Run As account authentication](automation-verify-runas-authentication.md).
* To get started with creating runbooks, first review the [Automation runbook types](automation-runbook-types.md) supported and related considerations before you begin authoring.


