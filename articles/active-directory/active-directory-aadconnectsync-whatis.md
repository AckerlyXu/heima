<properties
    pageTitle="Azure AD Connect sync: Understand and customize synchronization | Azure"
    description="Explains how Azure AD Connect sync works and how to customize."
    services="active-directory"
    documentationcenter=""
    author="andkjell"
    manager="femila"
    editor="" />
<tags
    ms.assetid="ee4bf802-045b-4da0-986e-90aba2de58d6"
    ms.service="active-directory"
    ms.workload="identity"
    ms.tgt_pltfrm="na"
    ms.devlang="na"
    ms.topic="article"
    ms.date="11/01/2016"
    ms.author="markusvi" 
    wacn.date=""/>

# Azure AD Connect sync: Understand and customize synchronization
The Azure Active Directory Connect synchronization services (Azure AD Connect sync) is a main component of Azure AD Connect. It takes care of all the operations that are related to synchronize identity data between your on-premises environment and Azure AD. Azure AD Connect sync is the successor of DirSync, Azure AD Sync, and Forefront Identity Manager with the Azure Active Directory Connector configured.

This topic is the home for **Azure AD Connect sync** (also called **sync engine**) and lists links to all other topics related to it. For links to Azure AD Connect, see [Integrating your on-premises identities with Azure Active Directory](/documentation/articles/active-directory-aadconnect/).

The sync service consists of two components, the on-premises **Azure AD Connect sync** component and the service side in Azure AD called **Azure AD Connect sync service**. The service is common for DirSync, Azure AD Sync, and Azure AD Connect.

## Azure AD Connect sync topics
| Topic | What it covers and when to read |
| --- | --- |
| **Azure AD Connect sync fundamentals** | |
| [Understanding the architecture](/documentation/articles/active-directory-aadconnectsync-understanding-architecture/) |For those of you who are new to the sync engine and want to learn about the architecture and the terms used. |
| [Technical concepts](/documentation/articles/active-directory-aadconnectsync-technical-concepts/) |A short version of the architecture topic and briefly explains the terms used. |
| [Topologies for Azure AD Connect](/documentation/articles/active-directory-aadconnect-topologies/) |Describes the different topologies and scenarios the sync engine supports. |
| **Custom configuration** | |
| [Running the installation wizard again](/documentation/articles/active-directory-aadconnectsync-installation-wizard/) |Explains what options you have available when you run the Azure AD Connect installation wizard again. |
| [Understanding Declarative Provisioning](/documentation/articles/active-directory-aadconnectsync-understanding-declarative-provisioning/) |Describes the configuration model called declarative provisioning. |
| [Understanding Declarative Provisioning Expressions](/documentation/articles/active-directory-aadconnectsync-understanding-declarative-provisioning-expressions/) |Describes the syntax for the expression language used in declarative provisioning. |
| [Understanding the default configuration](/documentation/articles/active-directory-aadconnectsync-understanding-default-configuration/) |Describes the out-of-box rules and the default configuration. Also describes how the rules work together for the out-of-box scenarios to work. |
| [Understanding Users and Contacts](/documentation/articles/active-directory-aadconnectsync-understanding-users-and-contacts/) |Continues on the previous topic and describes how the configuration for users and contacts works together, in particular in a multi-forest environment. |
| [How to make a change to the default configuration](/documentation/articles/active-directory-aadconnectsync-change-the-configuration/) |Walks you through how to make a common configuration change to attribute flows. |
| [Best practices for changing the default configuration](/documentation/articles/active-directory-aadconnectsync-best-practices-changing-default-configuration/) |Support limitations and for making changes to the out-of-box configuration. |
| [Configure Filtering](/documentation/articles/active-directory-aadconnectsync-configure-filtering/) |Describes the different options for how to limit which objects are being synchronized to Azure AD and step-by-step how to configure these options. |
| **Features and scenarios** | |
| [Prevent accidental deletes](/documentation/articles/active-directory-aadconnectsync-feature-prevent-accidental-deletes/) |Describes the *prevent accidental deletes* feature and how to configure it. |
| [Scheduler](/documentation/articles/active-directory-aadconnectsync-feature-scheduler/) |Describes the built-in scheduler, which is importing, synchronizing, and exporting data. |
| [Implement password synchronization](/documentation/articles/active-directory-aadconnectsync-implement-password-synchronization/) |Describes how password synchronization works, how to implement, and how to operate and troubleshoot. |
| [Directory extensions](/documentation/articles/active-directory-aadconnectsync-feature-directory-extensions/) |Describes how to extend the Azure AD schema with your own custom attributes. |
| **Sync Service** | |
| [Azure AD Connect sync service features](/documentation/articles/active-directory-aadconnectsyncservice-features/) |Describes the sync service side and how to change sync settings in Azure AD. |
| [Duplicate attribute resiliency](/documentation/articles/active-directory-aadconnectsyncservice-duplicate-attribute-resiliency/) |Describes how to enable and use **userPrincipalName** and **proxyAddresses** duplicate attribute values resiliency. |
| **Operations and UI** | |
| [Synchronization Service Manager](/documentation/articles/active-directory-aadconnectsync-service-manager-ui/) |Describes the Synchronization Service Manager UI, including [Operations](/documentation/articles/active-directory-aadconnectsync-service-manager-ui-operations/), [Connectors](/documentation/articles/active-directory-aadconnectsync-service-manager-ui-connectors/), [Metaverse Designer](/documentation/articles/active-directory-aadconnectsync-service-manager-ui-mvdesigner/), and [Metaverse Search](/documentation/articles/active-directory-aadconnectsync-service-manager-ui-mvsearch/) tabs. |
| [Operational tasks and considerations](/documentation/articles/active-directory-aadconnectsync-operations/) |Describes operational concerns, such as disaster recovery. |
| **How To...** | |
| [Reset the Azure AD account](/documentation/articles/active-directory-aadconnectsync-howto-azureadaccount/) |How to reset the credentials of the service account used to connect from Azure AD Connect sync to Azure AD. |
| **More information and references** | |
| [Ports](/documentation/articles/active-directory-aadconnect-ports/) |Lists which ports you need to open between the sync engine and your on-premises directories and Azure AD. |
| [Attributes synchronized to Azure Active Directory](/documentation/articles/active-directory-aadconnectsync-attributes-synchronized/) |Lists all attributes being synchronized between on-premises AD and Azure AD. |
| [Functions Reference](/documentation/articles/active-directory-aadconnectsync-functions-reference/) |Lists all functions available in declarative provisioning. |

## Additional Resources
- [Integrating your on-premises identities with Azure Active Directory](/documentation/articles/active-directory-aadconnect/)

