---
ms.assetid: 
title: Azure Key Vault security worlds | Microsoft Docs
ms.service: key-vault
author: BrucePerlerMS
ms.author: v-junlch
manager: mbaldwin
ms.topic: article
ms.date: 05/10/2017
wacn.date: ''
---
# Azure Key Vault security worlds and geographic boundaries

A backup taken of a key from a key vault in one Azure location can be restored to a key vault in another Azure location, as long as both of these conditions are true:

- Both of the Azure locations belong to the same geographical location
- Both of the key vaults belong to the same Azure subscription

For example, a backup taken by a given subscription of a key in a key vault in West India, can only be restored to another key vault in the same subscription and geo location; West India, Central India or South India. 



