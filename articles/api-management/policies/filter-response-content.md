---
title: Azure API managment policy sample - Filter response content
description: Azure API managment policy sample - Demonstrates how to filter data elements from the response payload based on the product associated with the request.
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

# Filter response content

This article shows an Azure API management policy sample that demonstrates how to filter data elements from the response payload based on the product associated with the request. To set or edit a policy code, follow the steps described in [Set or edit a policy](../set-edit-policies.md). To see other examples, see [policy samples](../policy-samples.md).

## Policy

Paste the code into the **outbound** block.

```xml
<!-- The policy defined in this file demonstrates how to filter data elements from the response payload based on the product associated with the request.
<!-- The snippet assumes that response content is formatted as JSON and contains root-level properties named "minutely", "hourly", "daily", "flags". -->

<!-- Use https://darksky.net/dev/ API to test this policy. -->

<!-- Copy this snippet into the outbound section. -->

<policies>
  <inbound>
    <base />
  </inbound>
  <backend>
    <base />
  </backend>
  <outbound>
    <base />
    <choose>
      <when condition="@(context.Response.StatusCode == 200 && context.Product.Name.Equals("Starter="""))">
        <set-body>
          @{
            <!-- NOTE that we are not using preserveContent=true when deserializing response body stream into a JSON object since we don't intend to access it again. See details on https://docs.azure.cn/zh-cn/api-management/api-management-transformation-policies#SetBody -->
            var response = context.Response.Body.As<JObject>();
            foreach (var key in new [] {"minutely", "hourly", "daily", "flags"}) {
            response.Property (key).Remove ();
           }
          return response.ToString();
          }
		</set-body>
      </when>
    </choose>    
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

