---
title: Resource Manager Template Functions | Azure
description: Describes the functions to use in an Azure Resource Manager template to retrieve values, work with strings and numerics, and retrieve deployment information.
services: azure-resource-manager
documentationcenter: na
author: rockboyfor
manager: digimobile
editor: tysonn

ms.assetid: 0644abe1-abaa-443d-820d-1966d7d26bfd
ms.service: azure-resource-manager
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: na
origin.date: 04/09/2018
ms.date: 04/30/2018
ms.author: v-yeche

---
# Azure Resource Manager template functions
This article describes all the functions you can use in an Azure Resource Manager template.

You add functions in your templates by enclosing them within brackets: `[` and `]`, respectively. The expression is evaluated during deployment. While written as a string literal, the result of evaluating the expression can be of a different JSON type, such as an array, object, or integer. Just like in JavaScript, function calls are formatted as `functionName(arg1,arg2,arg3)`. You reference properties by using the dot and [index] operators.

A template expression cannot exceed 24,576 characters.

Template functions and their parameters are case-insensitive. For example, Resource Manager resolves **variables('var1')** and **VARIABLES('VAR1')** as the same. When evaluated, unless the function expressly modifies case (such as toUpper or toLower), the function preserves the case. Certain resource types may have case requirements irrespective of how functions are evaluated.

<a name="array" />
<a name="coalesce" />
<a name="concatarray" />
<a name="contains" />
<a name="createarray" />
<a name="empty" />
<a name="first" />
<a name="intersection" />
<a name="json" />
<a name="last" />
<a name="length" />
<a name="min" />
<a name="max" />
<a name="range" />
<a name="skip" />
<a name="take" />
<a name="union" />

## Array and object functions
Resource Manager provides several functions for working with arrays and objects.

* [array](resource-group-template-functions-array.md#array)
* [coalesce](resource-group-template-functions-array.md#coalesce)
* [concat](resource-group-template-functions-array.md#concat)
* [contains](resource-group-template-functions-array.md#contains)
* [createArray](resource-group-template-functions-array.md#createarray)
* [empty](resource-group-template-functions-array.md#empty)
* [first](resource-group-template-functions-array.md#first)
* [intersection](resource-group-template-functions-array.md#intersection)
* [json](resource-group-template-functions-array.md#json)
* [last](resource-group-template-functions-array.md#last)
* [length](resource-group-template-functions-array.md#length)
* [min](resource-group-template-functions-array.md#min)
* [max](resource-group-template-functions-array.md#max)
* [range](resource-group-template-functions-array.md#range)
* [skip](resource-group-template-functions-array.md#skip)
* [take](resource-group-template-functions-array.md#take)
* [union](resource-group-template-functions-array.md#union)

<a name="equals" />
<a name="less" />
<a name="lessorequals" />
<a name="greater" />
<a name="greaterorequals" />

## Comparison functions
Resource Manager provides several functions for making comparisons in your templates.

* [equals](resource-group-template-functions-comparison.md#equals)
* [less](resource-group-template-functions-comparison.md#less)
* [lessOrEquals](resource-group-template-functions-comparison.md#lessorequals)
* [greater](resource-group-template-functions-comparison.md#greater)
* [greaterOrEquals](resource-group-template-functions-comparison.md#greaterorequals)

<a name="deployment" />
<a name="parameters" />
<a name="variables" />

## Deployment value functions
Resource Manager provides the following functions for getting values from sections of the template and values related to the deployment:

* [deployment](resource-group-template-functions-deployment.md#deployment)
* [parameters](resource-group-template-functions-deployment.md#parameters)
* [variables](resource-group-template-functions-deployment.md#variables)

<a name="and" />
<a name="bool" />
<a name="if" />
<a name="not" />
<a name="or" />

## Logical functions
Resource Manager provides the following functions for working with logical conditions:

* [and](resource-group-template-functions-logical.md#and)
* [bool](resource-group-template-functions-logical.md#bool)
* [if](resource-group-template-functions-logical.md#if)
* [not](resource-group-template-functions-logical.md#not)
* [or](resource-group-template-functions-logical.md#or)

<a name="add" />
<a name="copyindex" />
<a name="div" />
<a name="float" />
<a name="int" />
<a name="minint" />
<a name="maxint" />
<a name="mod" />
<a name="mul" />
<a name="sub" />

## Numeric functions
Resource Manager provides the following functions for working with integers:

* [add](resource-group-template-functions-numeric.md#add)
* [copyIndex](resource-group-template-functions-numeric.md#copyindex)
* [div](resource-group-template-functions-numeric.md#div)
* [float](resource-group-template-functions-numeric.md#float)
* [int](resource-group-template-functions-numeric.md#int)
* [min](resource-group-template-functions-numeric.md#min)
* [max](resource-group-template-functions-numeric.md#max)
* [mod](resource-group-template-functions-numeric.md#mod)
* [mul](resource-group-template-functions-numeric.md#mul)
* [sub](resource-group-template-functions-numeric.md#sub)

<a name="listkeys" />
<a name="list" />
<a name="providers" />
<a name="reference" />
<a name="resourcegroup" />
<a name="resourceid" />
<a name="subscription" />

## Resource functions
Resource Manager provides the following functions for getting resource values:

* [listKeys](resource-group-template-functions-resource.md#listkeys)
* [listSecrets](resource-group-template-functions-resource.md#list)
* [list*](resource-group-template-functions-resource.md#list)
* [providers](resource-group-template-functions-resource.md#providers)
* [reference](resource-group-template-functions-resource.md#reference)
* [resourceGroup](resource-group-template-functions-resource.md#resourcegroup)
* [resourceId](resource-group-template-functions-resource.md#resourceid)
* [subscription](resource-group-template-functions-resource.md#subscription)

<a name="base64" />
<a name="base64tojson" />
<a name="base64tostring" />
<a name="concat" />
<a name="containsstring" />
<a name="datauri" />
<a name="datauritostring" />
<a name="emptystring" />
<a name="endswith" />
<a name="firststring" />
<a name="guid" />
<a name="indexof" />
<a name="laststring" />
<a name="lastindexof" />
<a name="lengthstring" />
<a name="padleft" />
<a name="replace" />
<a name="skipstring" />
<a name="split" />
<a name="startswith" />
<a name="string" />
<a name="substring" />
<a name="takestring" />
<a name="tolower" />
<a name="toupper" />
<a name="trim" />
<a name="uniquestring" />
<a name="uri" />
<a name="uricomponent" />
<a name="uricomponenttostring" />

## String functions
Resource Manager provides the following functions for working with strings:

* [base64](resource-group-template-functions-string.md#base64)
* [base64ToJson](resource-group-template-functions-string.md#base64tojson)
* [base64ToString](resource-group-template-functions-string.md#base64tostring)
* [concat](resource-group-template-functions-string.md#concat)
* [contains](resource-group-template-functions-string.md#contains)
* [dataUri](resource-group-template-functions-string.md#datauri)
* [dataUriToString](resource-group-template-functions-string.md#datauritostring)
* [empty](resource-group-template-functions-string.md#empty)
* [endsWith](resource-group-template-functions-string.md#endswith)
* [first](resource-group-template-functions-string.md#first)
* [guid](resource-group-template-functions-string.md#guid)
* [indexOf](resource-group-template-functions-string.md#indexof)
* [last](resource-group-template-functions-string.md#last)
* [lastIndexOf](resource-group-template-functions-string.md#lastindexof)
* [length](resource-group-template-functions-string.md#length)
* [padLeft](resource-group-template-functions-string.md#padleft)
* [replace](resource-group-template-functions-string.md#replace)
* [skip](resource-group-template-functions-string.md#skip)
* [split](resource-group-template-functions-string.md#split)
* [startsWith](resource-group-template-functions-string.md#startswith)
* [string](resource-group-template-functions-string.md#string)
* [substring](resource-group-template-functions-string.md#substring)
* [take](resource-group-template-functions-string.md#take)
* [toLower](resource-group-template-functions-string.md#tolower)
* [toUpper](resource-group-template-functions-string.md#toupper)
* [trim](resource-group-template-functions-string.md#trim)
* [uniqueString](resource-group-template-functions-string.md#uniquestring)
* [uri](resource-group-template-functions-string.md#uri)
* [uriComponent](resource-group-template-functions-string.md#uricomponent)
* [uriComponentToString](resource-group-template-functions-string.md#uricomponenttostring)

## Next steps
* For a description of the sections in an Azure Resource Manager template, see [Authoring Azure Resource Manager templates](resource-group-authoring-templates.md)
* To merge multiple templates, see [Using linked templates with Azure Resource Manager](resource-group-linked-templates.md)
* To iterate a specified number of times when creating a type of resource, see [Create multiple instances of resources in Azure Resource Manager](resource-group-create-multiple.md)
* To see how to deploy the template you have created, see [Deploy an application with Azure Resource Manager template](resource-group-template-deploy.md)

<!--Update_Description: update meta properties, update link, wording update -->