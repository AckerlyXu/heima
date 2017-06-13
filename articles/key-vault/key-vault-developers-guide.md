---
title: Azure Key Vault Developer's Guide | Microsoft Docs
description: Developers can use Azure Key Vault to manage cryptographic keys within the Azure environment.
services: key-vault
documentationcenter: ''
author: BrucePerlerMS
manager: mbaldwin

ms.service: key-vault
ms.topic: article
ms.workload: identity
ms.date: 05/10/2017
wacn.date: ''
ms.author: v-junlch

---
# Azure Key Vault Developer's Guide

Key Vault allows you to securely access sensitive information from within your applications:

- Keys and secrets are protected without having to write the code yourself and you are easily able to use them from your applications.
- You are able to have your customers own and manage their own keys so you can concentrate on providing the core software features. In this way, your applications will not own the responsibility or potential liability for your customers’ tenant keys and secrets.
- Your application can use keys for signing and encryption yet keeps the key management external from your application, allowing your solution to be suitable as a geographically distributed app.
- As of the September 2016 release of Key Vault, your applications can now use Key Vault [certificates](https://docs.microsoft.com/rest/api/keyvault/certificate-operations). For more information, see [About keys, secrets, and certificates](https://docs.microsoft.com/rest/api/keyvault/about-keys--secrets-and-certificates).

For more general information on Azure Key Vault, see [What is Key Vault](key-vault-whatis.md).

## Public Preview - May 10, 2017

>[!NOTE]
>For this preview version of Azure Key Vault only the **soft-delete** feature is in preview. Azure Key Vault, as a whole, is a full production service.

This preview includes our new soft-delete feature, recoverable deletion of Key Vaults and Key Vault objects,  and updated interfaces for developers; [.NET/C#](https://docs.microsoft.com/dotnet/api/microsoft.azure.keyvault/), [REST](https://docs.microsoft.com/rest/api/keyvault/) and [PowerShell](https://docs.microsoft.com/powershell/module/azurerm.keyvault/). 

For more information on the new soft-delete feature, see [Azure Key Vault soft delete overview](key-vault-ovw-soft-delete.md).

## Creating and Managing Key Vaults

Before working with Azure Key Vault in your code, you can create and manage vaults through REST, Resource Manager Templates, PowerShell or CLI, as described in the following articles:

- [Create and Manage Key Vaults with REST](https://docs.microsoft.com/rest/api/keyvault/)
- [Create and Manage Key Vaults with PowerShell](key-vault-get-started.md)
- [Create and Manage Key Vaults with CLI](key-vault-manage-with-cli2.md)
- [Create a key vault and add a secret via an Azure Resource Manager template](../azure-resource-manager/resource-manager-template-keyvault.md)

> [!NOTE]
> Operations against key vaults are authenticated through AAD and authorized through Key Vault’s own Access Policy, defined per vault.

## Coding with Key Vault

The Key Vault management system for programmers consists of several interfaces, with REST as the foundation. Through the REST interface, all of your key vaults resourcesare are accessible; keys, secrets and certificates. [Key Vault REST API Reference](https://docs.microsoft.com/rest/api/keyvault/). 

### Supported programming languages

#### .NET

- [.NET API refence for Key Vault](https://docs.microsoft.com/dotnet/api/microsoft.azure.keyvault) 

For more information on the 2.x version of the .NET SDK, see the [Release notes](key-vault-dotnet2api-release-notes.md).

#### Java

- [Java SDK for Key Vault](https://docs.microsoft.com/java/api/com.microsoft.azure.keyvault)

#### Node.js

- [Node.js API reference for Key Vault Managment](http://azure.github.io/azure-sdk-for-node/azure-arm-keyvault/latest/)
- [Node.js API reference for Key Vault Operations](http://azure.github.io/azure-sdk-for-node/azure-keyvault/latest/) 

### Quick start

- [Create Key Vault](https://github.com/Azure/azure-quickstart-templates/tree/master/101-key-vault-create)
- [Getting started with Key Vault in Node.js](https://azure.microsoft.com/en-us/resources/samples/key-vault-node-getting-started/)

### Code examples

For complete examples using Key Vault with your applications, see:

- [Azure Key Vault code samples](http://www.microsoft.com/download/details.aspx?id=45343) - .NET sample application *HelloKeyVault* and an Azure web service example. 
- [Use Azure Key Vault from a Web Application](key-vault-use-from-web-application.md) - tutorial to help you learn how to use Azure Key Vault from a web application in Azure. 

## How-tos

The following articles and scenarios provide task-specific guidance for working with Azure Key Vault:

- [Change key vault tenant ID after subscription move](key-vault-subscription-move-fix.md) - When you move your Azure subscription from tenant A to tenant B, your existing key vaults are inaccessible by the principals (users and applications) in tenant B. Fix this using this guide.
- [Accessing Key Vault behind firewall](key-vault-access-behind-firewall.md) - To access a key vault your key vault client application needs to be able to access multiple end-points for various functionalities.
- [How to pass secure values (such as passwords) during deployment](../azure-resource-manager/resource-manager-keyvault-parameter.md) - When you need to pass a secure value (like a password) as a parameter during deployment, you can store that value as a secret in an Azure Key Vault and reference the value in other Resource Manager templates.
- [How to use Key Vault for extensible key management with SQL Server](https://msdn.microsoft.com/library/dn198405.aspx) - The SQL Server Connector for Azure Key Vault enables SQL Server and SQL-in-a-VM to leverage the Azure Key Vault service as an Extensible Key Management (EKM) provider to protect its encryption keys for applications link; Transparent Data Encryption, Backup Encryption, and Column Level Encryption.
- [How to deploy Certificates to VMs from Key Vault](https://blogs.technet.microsoft.com/kv/2015/07/14/deploy-certificates-to-vms-from-customer-managed-key-vault/) - A cloud application running in a VM on Azure needs a certificate. How do you get this certificate into this VM today?
- [How to set up Key Vault with end to end key rotation and auditing](key-vault-key-rotation-log-monitoring.md) - This walks through how to set up key rotation and auditing with Azure Key Vault.
- [Deploying Azure Web App Certificate through Key Vault]( https://blogs.msdn.microsoft.com/appserviceteam/2016/05/24/deploying-azure-web-app-certificate-through-key-vault/) provides step-by-step instructions for deploying certificates stored in Key Vault as part of [App Service Certificate](https://azure.microsoft.com/blog/internals-of-app-service-certificate/) offering.

For more task-specific guidance on integrating and using Key Vaults with Azure, see [Ryan Jones' Azure Resource Manager template examples for Key Vault](https://github.com/rjmax/ArmExamples/tree/master/keyvaultexamples).

## Key Vault overviews and concepts

- [Key Vault security worlds](key-vault-ovw-security-worlds.md)
- [Key Vault soft-delete](key-vault-ovw-soft-delete.md)

## Social

- [Key Vault Blog](http://aka.ms/kvblog)
- [Key Vault Forum](http://aka.ms/kvforum)


## Supporting Libraries

- [Azure Key Vault Core Library](http://www.nuget.org/packages/Microsoft.Azure.KeyVault.Core) provides **IKey** and **IKeyResolver** interfaces for locating keys from identifiers and performing operations with keys.
- [Azure Key Vault Extensions](http://www.nuget.org/packages/Microsoft.Azure.KeyVault.Extensions) provides extended capabilities for Azure Key Vault.

## Other Key Vault resources


