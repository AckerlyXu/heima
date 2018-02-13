---
title: Azure API managment policy sample - Add a Forwarded header
description: Azure API managment policy sample - Demonstrates how to add a Forwarded header in the inbound request to allow the backend API to construct proper URLs.
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

# Add a Forwarded header

This article shows an Azure API management policy sample that demonstrates how to add a Forwarded header in the inbound request to allow the backend API to construct proper URLs. To set or edit a policy code, follow the steps described in [Set or edit a policy](../set-edit-policies.md). To see other examples, see [policy samples](../policy-samples.md).

## Code

Paste the code into the **inbound** block.

```xml
<!-- The policy defined in this file demonstrates how to add a Forwarded header in the inbound request to allow the backend API to construct proper URLs.

<!-- Forwarded header is defined in the IETF RFC 7239 https://tools.ietf.org/html/rfc7239  -->

<!-- Copy this snippet into the inbound section. -->

<policies>
  <inbound>
    <base />
    <set-header exists-action="override" name="Forwarded">
      <value>@("proto=" + context.Request.OriginalUrl.Scheme + ";host=" + context.Request.OriginalUrl.Host + ";")</value>
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
