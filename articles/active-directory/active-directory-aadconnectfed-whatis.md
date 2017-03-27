<properties
    pageTitle="Azure AD Connect and Federation | Azure"
    description="This page is the central location for all documentation regarding AD FS operations using Azure AD Connect"
    services="active-directory"
    documentationcenter=""
    author="anandyadavmsft"
    manager="femila"
    editor="" />
<tags
    ms.assetid="f9107cf5-0131-499a-9edf-616bf3afef4d"
    ms.service="active-directory"
    ms.workload="identity"
    ms.tgt_pltfrm="na"
    ms.devlang="na"
    ms.topic="article"
    ms.date="10/31/2016"
    ms.author="anandy" 
    wacn.date=""/>

# Azure AD Connect and federation
Azure AD Connect lets you configure federation with the on-premises AD FS and Azure AD. With federation sign on, you can enable users to sign on to Azure AD based services with their on-premises passwords and, while on the corporate network, without having to enter their passwords again. The federation option with AD FS allows you to deploy a new or specify an existing AD FS in Windows Server 2012 R2 farm.

This topic is the home for information on Federation related functionalities for Azure AD Connect and lists links to all other topics related to it. For links to Azure AD Connect, see Integrating your on-premises identities with Azure Active Directory.

## Azure AD Connect - federation topics
| Topic | What it covers and when to read |
|:--- |:--- |
| **Azure AD Connect user sign-in options** | |
| [Understanding User sign-in options](/documentation/articles/active-directory-aadconnect-user-signin/) |Description of various user sign-in options and how they affect Azure sign-in user experience |
| **AD FS installation using Azure AD Connect** | |
| [Pre-requisites](/documentation/articles/active-directory-aadconnect-get-started-custom/#ad-fs-configuration-pre-requisites/) |Pre-requisites for a successful AD FS installation via Azure AD Connect |
| [Configure AD FS farm](/documentation/articles/active-directory-aadconnect-get-started-custom/#configuring-federation-with-ad-fs/) |How to install a new AD FS farm using Azure AD Connect |
| **Modifying the AD FS configuration** | |
| [Repairing the trust](/documentation/articles/active-directory-aadconnect-federation-management/#repairthetrust/) |How to repair current trust between on-premises AD FS and Office 365 / Azure |
| [Adding a new AD FS server](/documentation/articles/active-directory-aadconnect-federation-management/#addadfsserver/) |Expanding AD FS farm with additional AD FS server post initial installation |
| [Adding a new AD FS WAP server](/documentation/articles/active-directory-aadconnect-federation-management/#addwapserver/) |Expanding AD FS farm with additional WAP server post initial installation |
| [Add a new federated domain](/documentation/articles/active-directory-aadconnect-federation-management/#addfeddomain/) |Add another domain to be federated with Azure AD |
| **Post installation tasks** | |
| [Add custom company logo / illustration](/documentation/articles/active-directory-aadconnect-federation-management/#customlogo/) |Modify the sign-in experience by specifying the custom logo that will be shown on the AD FS sign-in page |
| [Add sign-in description](/documentation/articles/active-directory-aadconnect-federation-management/#addsignindescription/) |Changing sign-in description on the AD FS sign-in page |
| [Modifying AD FS claim rules](/documentation/articles/active-directory-aadconnect-federation-management/#modclaims/) |Modify / add claim rules in AD FS corresponding to Azure AD Connect sync configuration |

## Additional resources
- [Integrating your on-premises identities with Azure Active Directory](/documentation/articles/active-directory-aadconnect/)
- [AD FS deployment in Azure](/documentation/articles/active-directory-aadconnect-azure-adfs/)
- [High availability cross-geographic AD FS deployment in Azure with Azure Traffic Manager](/documentation/articles/active-directory-adfs-in-azure-with-azure-traffic-manager/)

