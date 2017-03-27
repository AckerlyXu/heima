<properties
    pageTitle="Connect Active Directory with Azure Active Directory. | Azure"
    description="Azure AD Connect will integrate your on-premises directories with Azure Active Directory. This allows you to provide a common identity for Office 365, Azure, and SaaS applications integrated with Azure AD."
    keywords="introduction to Azure AD Connect, Azure AD Connect overview, what is Azure AD Connect, install active directory"
    services="active-directory"
    documentationcenter=""
    author="billmath"
    manager="femila"
    editor="" />
    
<tags
    ms.assetid="59bd209e-30d7-4a89-ae7a-e415969825ea"
    ms.service="active-directory"
    ms.workload="identity"
    ms.tgt_pltfrm="na"
    ms.devlang="na"
    ms.topic="get-started-article"
    ms.date="02/07/2017"
    wacn.date=""
    ms.author="billmath" />

# Connect Active Directory with Azure Active Directory.
Azure AD Connect will integrate your on-premises directories with Azure Active Directory. This allows you to provide a common identity for your users for Office 365, Azure, and SaaS applications integrated with Azure AD. This topic will guide you through the planning, deployment, and operation steps. It is a collection of links to the topics related to this area.

> [AZURE.IMPORTANT]
> [Azure AD Connect is the best way to connect your on-premises directory with Azure AD and Office 365. This is a great time to upgrade to Azure AD Connect from Azure Active Directory Sync (DirSync) or Azure AD Sync as these tools are now deprecated and will reach end of support on April 13, 2017.](/documentation/articles/active-directory-aadconnect-dirsync-deprecated/)
> 
> 

![What is Azure AD Connect](./media/active-directory-aadconnect/arch.png)

## Why use Azure AD Connect
Integrating your on-premises directories with Azure AD makes your users more productive by providing a common identity for accessing both cloud and on-premises resources. Users and organizations can take advantage of the following:

- Users can use a single identity to access on-premises applications and cloud services such as Office 365.
- Single tool to provide an easy deployment experience for synchronization and sign-in.


### How Azure AD Connect works
Azure Active Directory Connect is made up of three primary components: the synchronization services, the optional Active Directory Federation Services component.

<center>![Azure AD Connect Stack](./media/active-directory-aadconnect-how-it-works/AADConnectStack2.png)
</center>

- Synchronization - This component is responsible for creating users, groups, and other objects. It is also responsible for making sure identity information for your on-premises users and groups is matching the cloud.
- AD FS - Federation is an optional part of Azure AD Connect and can be used to configure a hybrid environment using an on-premises AD FS infrastructure. This can be used by organizations to address complex deployments, such as domain join SSO, enforcement of AD sign-in policy, and smart card or 3rd party MFA.


## Install Azure AD Connect
You can find the download for Azure AD Connect on [Microsoft Download Center](http://go.microsoft.com/fwlink/?LinkId=615771).

| Solution | Scenario |
| --- | --- |
| Before you start - [Hardware and prerequisites](/documentation/articles/active-directory-aadconnect-prerequisites/) |<li>Steps to complete before you start to install Azure AD Connect.</li> |
| [Express settings](/documentation/articles/active-directory-aadconnect-get-started-express/) |<li>If you have a single forest AD then this is the recommended option to use.</li> <li>User sign in with the same password using password synchronization.</li> |
| [Customized settings](/documentation/articles/active-directory-aadconnect-get-started-custom/) |<li>Used when you have multiple forests. Supports many on-premises [topologies](/documentation/articles/active-directory-aadconnect-topologies/).</li> <li>Customize your sign-in option, such as ADFS for federation or use a 3rd party identity provider.</li> <li>Customize synchronization features, such as filtering and writeback.</li> |
| [Upgrade from DirSync](/documentation/articles/active-directory-aadconnect-dirsync-upgrade-get-started/) |<li>Used when you have an existing DirSync server already running.</li> |
| [Upgrade from Azure AD Sync or Azure AD Connect](/documentation/articles/active-directory-aadconnect-upgrade-previous-version/) |<li>There are several different methods depending on your preference.</li> |

[After installation](/documentation/articles/active-directory-aadconnect-whats-next/) you should verify it is working as expected and assign licenses to the users.

### Next steps to Install Azure AD Connect
|Topic |Link|  
| --- | --- |
|Download Azure AD Connect | [Download Azure AD Connect](http://go.microsoft.com/fwlink/?LinkId=615771)|
|Install using Express settings | [Express installation of Azure AD Connect](/documentation/articles/active-directory-aadconnect-get-started-express/)|
|Install using Customized settings | [Custom installation of Azure AD Connect](/documentation/articles/active-directory-aadconnect-get-started-custom/)|
|Upgrade from DirSync | [Upgrade from Azure AD sync tool (DirSync)](/documentation/articles/active-directory-aadconnect-dirsync-upgrade-get-started/)|
|After installation | [Verify the installation and assign licenses ](/documentation/articles/active-directory-aadconnect-whats-next/)|

### Learn more about Install Azure AD Connect
You also want to prepare for [operational](/documentation/articles/active-directory-aadconnectsync-operations/) concerns. You might want to have a stand-by server so you easily can fall over if there is a [disaster](/documentation/articles/active-directory-aadconnectsync-operations/#disaster-recovery/). If you plan to make frequent configuration changes, you should plan for a [staging mode](/documentation/articles/active-directory-aadconnectsync-operations/#staging-mode/) server.

|Topic |Link|  
| --- | --- |
|Supported topologies | [Topologies for Azure AD Connect](/documentation/articles/active-directory-aadconnect-topologies/)|
|Design concepts | [Azure AD Connect design concepts](/documentation/articles/active-directory-aadconnect-design-concepts/)|
|Accounts used for installation | [More about Azure AD Connect credentials and permissions](/documentation/articles/active-directory-aadconnect-accounts-permissions/)|
|Operational planning | [Azure AD Connect sync: Operational tasks and considerations](/documentation/articles/active-directory-aadconnectsync-operations/)|
|User sign-in options | [Azure AD Connect User sign-in options](/documentation/articles/active-directory-aadconnect-user-signin/)|

## Configure sync features
Azure AD Connect comes with several features you can optionally turn on or are enabled by default. Some features might sometimes require more configuration in certain scenarios and topologies.

[Filtering](/documentation/articles/active-directory-aadconnectsync-configure-filtering/) is used when you want to limit which objects are synchronized to Azure AD. By default all users, contacts, groups, and Windows 10 computers are synchronized. You can change the filtering based on domains, OUs, or attributes.

[Password synchronization](/documentation/articles/active-directory-aadconnectsync-implement-password-synchronization/) synchronizes the password hash in Active Directory to Azure AD. The  end-user can use the same password on-premises and in the cloud but only manage it in one location. Since it uses your on-premises Active Directory as the authority, you can also use your own password policy.

[Password writeback](/documentation/articles/active-directory-passwords-getting-started/) will allow your users to change and reset their passwords in the cloud and have your on-premises password policy applied.

The [prevent accidental deletes](/documentation/articles/active-directory-aadconnectsync-feature-prevent-accidental-deletes/) feature is turned on by default and protects your cloud directory from numerous deletes at the same time. By default it allows 500 deletes per run. You can change this setting depending on your organization size.

[Automatic upgrade](/documentation/articles/active-directory-aadconnect-feature-automatic-upgrade/) is enabled by default for express settings installations and ensures your Azure AD Connect is always up to date with the latest release.

### Next steps to configure sync features
|Topic |Link|  
| --- | --- |
|Configure filtering | [Azure AD Connect sync: Configure filtering](/documentation/articles/active-directory-aadconnectsync-configure-filtering/)|
|Password synchronization | [Azure AD Connect sync: Implement password synchronization](/documentation/articles/active-directory-aadconnectsync-implement-password-synchronization/)|
|Password writeback | [Getting started with password management](/documentation/articles/active-directory-passwords-getting-started/)|
|Prevent accidental deletes | [Azure AD Connect sync: Prevent accidental deletes](/documentation/articles/active-directory-aadconnectsync-feature-prevent-accidental-deletes/)|
|Automatic upgrade | [Azure AD Connect: Automatic upgrade](/documentation/articles/active-directory-aadconnect-feature-automatic-upgrade/)|

## Customize Azure AD Connect sync
Azure AD Connect sync comes with a default configuration that is intended to work for most customers and topologies. But there are always situations where the default configuration does not work and must be adjusted. It is supported to make changes as documented in this section and linked topics.

If you have not worked with a synchronization topology before you want to start to understand the basics and the terms used as described in the [technical concepts](/documentation/articles/active-directory-aadconnectsync-technical-concepts/). Azure AD Connect is the evolution of MIIS2003, ILM2007, and FIM2010. Even if some things are identical, a lot has changed as well.

The [default configuration](/documentation/articles/active-directory-aadconnectsync-understanding-default-configuration/) assumes there might be more than one forest in the configuration. In those topologies a user object might be represented as a contact in another forest. The user might also have a linked mailbox in another resource forest. The behavior of the default configuration is described in [users and contacts](/documentation/articles/active-directory-aadconnectsync-understanding-users-and-contacts/).

The configuration model in sync is called [declarative provisioning](/documentation/articles/active-directory-aadconnectsync-understanding-declarative-provisioning-expressions/). The advanced attribute flows are using [functions](/documentation/articles/active-directory-aadconnectsync-functions-reference/) to express attribute transformations. You can see and examine the entire configuration using tools which comes with Azure AD Connect. If you need to make configuration changes, make sure you follow the [best practices](/documentation/articles/active-directory-aadconnectsync-best-practices-changing-default-configuration/) so it is easier to adopt new releases.

### Next steps to customize Azure AD Connect sync
|Topic |Link|  
| --- | --- |
|All Azure AD Connect sync articles | [Azure AD Connect sync](/documentation/articles/active-directory-aadconnectsync-whatis/)|
|Technical concepts | [Azure AD Connect sync: Technical Concepts](/documentation/articles/active-directory-aadconnectsync-technical-concepts/)|
|Understanding the default configuration | [Azure AD Connect sync: Understanding the default configuration](/documentation/articles/active-directory-aadconnectsync-understanding-default-configuration/)|
|Understanding users and contacts | [Azure AD Connect sync: Understanding Users and Contacts](/documentation/articles/active-directory-aadconnectsync-understanding-users-and-contacts/)|
|Declarative provisioning | [Azure AD Connect Sync: Understanding Declarative Provisioning Expressions](/documentation/articles/active-directory-aadconnectsync-understanding-declarative-provisioning-expressions/)|
|Change the default configuration | [Best practices for changing the default configuration](/documentation/articles/active-directory-aadconnectsync-best-practices-changing-default-configuration/)|

## Configure federation features
if your ADFS server has not been configured to automatically update certificates from Azure AD or if you use a non-ADFS solution, then you will be notified when you have to [update certificates](/documentation/articles/active-directory-aadconnect-o365-certs/).

### Next steps to configure federation features
|Topic |Link|  
| --- | --- |
|All AD FS articles | [Azure AD Connect and federation](/documentation/articles/active-directory-aadconnectfed-whatis/)|
|Configure ADFS with subdomains | Multiple Domain Support for Federating with Azure AD |
|Manage AD FS farm | [AD FS management and customizaton with Azure AD Connect](/documentation/articles/active-directory-aadconnect-federation-management/)|
|Manually updating federation certificates | [Renewing Federation Certificates for Office 365 and Azure AD](/documentation/articles/active-directory-aadconnect-o365-certs/)|

## More information and references
|Topic |Link|  
| --- | --- |
|Version history | [Version history](/documentation/articles/active-directory-aadconnect-version-history/)|
|Non-ADFS compatibility list for Azure AD | [Azure AD federation compatibility list](/documentation/articles/active-directory-aadconnect-federation-compatibility/)|
|Attributes synchronized | [Attributes synchronized](/documentation/articles/active-directory-aadconnectsync-attributes-synchronized/)|
|Frequently Asked Questions | [Azure AD Connect FAQ](/documentation/articles/active-directory-aadconnect-faq/)|

**Additional Resources**

Ignite 2015 presentation on extending your on-premises directories to the cloud.

