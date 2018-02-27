---
title: Azure API managment policy sample - Send request context information to the backend service
description: Azure API managment policy sample - Demonstrates how to send request context information to the backend service.
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

# Send request context information to the backend service

This article shows an Azure API management policy sample that demonstrates how to send request context information to the backend service. To set or edit a policy code, follow the steps described in [Set or edit a policy](../set-edit-policies.md). To see other examples, see [policy samples](../policy-samples.md).

## Policy

Paste the code into the **inbound** block.

```xml
<!-- The policies described in this file show how to send some context information to the backend service for logging or processing. -->

<!-- Copy these snippets into the inbound element -->

<policies>
  <inbound>
    <base />
      <!-- Forward the name of the product associated with the subscription key in the request to the backend service. -->
      <set-query-parameter name="x-product-name" exists-action="override">
        <value>@(context.Product.Name)</value>
      </set-query-parameter>

      <!-- Forward the user id associated with the subscription key in the request as well as the region where the proxy processing the request is hosted. -->
      <set-header name="x-request-context-data" exists-action="override">
        <value>@(context.User.Id)</value>
        <value>@(context.Deployment.Region)</value>
      </set-header>    
  </inbound>
  <backend>
    <base />
  </backend>
  <outbound>
    <base />
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

