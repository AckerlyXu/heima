---
title: Azure API managment policy sample - Set response cache duration
description: Azure API managment policy sample - Demonstrates how to set response cache duration using maxAge value in Cache-Control header sent by the backend..
services: api-management
documentationcenter: ''
author: juliako
manager: cfowler
editor: ''

ms.service: api-management
ms.workload: mobile
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 10/13/2017
ms.date: 02/26/2018
ms.author: v-yiso
---

# Set response cache duration

This article shows an Azure API management policy sample that demonstrates how to set response cache duration using maxAge value in Cache-Control header sent by the backend. To set or edit a policy code, follow the steps described in [Set or edit a policy](../set-edit-policies.md). To see other examples, see [policy samples](../policy-samples.md).

## Policy

Paste the code into the **inbound** block.

```xml
<!-- This snippet demonstrates how to set response cache duration using maxAge value in Cache-Control header sent by the backend. -->

<!-- Copy the following snippet into the outbound section. -->
      
<policies>
  <inbound>
    <base />
  </inbound>
  <backend>
    <base />
  </backend>
  <outbound>
    <base />
    <!-- The following policy can be tested by setting up an API and operation mapped to GET http://httpbin.org/cache/{duration} -->
    <cache-store duration="@{
        var header = context.Response.Headers.GetValueOrDefault("Cache-Control","");
		    var maxAge = Regex.Match(header, @"max-age=(?<maxAge>\d+)").Groups["maxAge"]?.Value;
		    return (!string.IsNullOrEmpty(maxAge))?int.Parse(maxAge):300;
	    }"
     />
  </outbound>
  <on-error>
    <base />
  </on-error>
</policies>
```

## Next steps

Learn more about APIM policies:

+ [Transformation policies](../api-management-transformation-policies.md)
+ [Policy samples](../policy-samples.md)

