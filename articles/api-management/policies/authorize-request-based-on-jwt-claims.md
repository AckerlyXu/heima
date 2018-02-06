---
title: Azure API managment policy sample - authorize acces based on JWT claims
description: Azure API managment policy sample - Demonstrates how to authorize access to specific HTTP methods on an API based on JWT claims.
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

# Authorize access based on JWT claims

This article shows an Azure API management policy sample that demonstrates how to authorize access to specific HTTP methods on an API based on JWT claims. To set or edit a policy code, follow the steps described in [Set or edit a policy](../set-edit-policies.md). To see other examples, see [policy samples](../policy-samples.md).

## Policy

Paste the code into the **inbound** block.

```xml
<!-- The policy defined in this file shows how to authorize access to specific HTTP methods on an API based on JWT claims. -->
<!-- To test the policy you can use https://jwt.io to generate tokens. -->

<!-- Copy the following snippet into the inbound section. -->

<policies>
  <inbound>
    <base />
      <choose>
        <when condition="@(context.Request.Method.Equals("patch=""",StringComparison.OrdinalIgnoreCase))">
          <validate-jwt header-name="Authorization">
            <issuer-signing-keys>
              <key>{{signing-key}}</key>
            </issuer-signing-keys>
            <required-claims>
              <claim name="edit">
                <value>true</value>
              </claim>
            </required-claims>
          </validate-jwt>
        </when>
        <when condition="@(new [] {"post=""", "put="""}.Contains(context.Request.Method,StringComparer.OrdinalIgnoreCase))">
          <validate-jwt header-name="Authorization">
            <issuer-signing-keys>
              <key>{{signing-key}}</key>
            </issuer-signing-keys>
            <required-claims>
              <claim name="create">
                <value>true</value>
              </claim>
            </required-claims>
          </validate-jwt>
        </when>
        <otherwise>
          <validate-jwt header-name="Authorization">
            <issuer-signing-keys>
              <key>{{signing-key}}</key>
            </issuer-signing-keys>
          </validate-jwt>
        </otherwise>
      </choose>    
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

