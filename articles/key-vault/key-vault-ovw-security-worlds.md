---
ms.assetid: 
title: Azure Key Vault security worlds | Microsoft Docs
ms.service: key-vault
author: alexchen2016
ms.author: v-junlch
manager: digimobile
origin.date: 07/03/2017
ms.date: 08/02/2017
---
# Azure Key Vault security worlds and geographic boundaries

## Back up and restore behavior

A backup taken of a key from a key vault in one Azure location can be restored to a key vault in another Azure location, as long as both of these conditions are true:

- Both of the Azure locations belong to the same geographical location
- Both of the key vaults belong to the same Azure subscription

For example, a backup taken by a given subscription of a key in a key vault in West India, can only be restored to another key vault in the same subscription and geo location; West India, Central India or South India.

## Regions and products

- [Azure regions](https://azure.microsoft.com/regions/)
- [Microsoft products by region](https://azure.microsoft.com/regions/services/)

Regions are mapped to security worlds, shown as major headings in the tables:

In the products by region article, for example, the **Americas** tab contains EAST US, CENTRAL US, WEST US all mapping to the Americas region. 

>[!NOTE]
>An exception is that US DOD EAST and US DOD CENTRAL have their own security worlds. 

Similarly, on the **Europe** tab, NORTH EUROPE and WEST EUROPE both map to the Europe region. The same is also true on the **Asia Pacific** tab.



<!-- Update_Description: wording update -->
