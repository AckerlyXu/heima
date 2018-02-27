---
title: Azure API managment policy sample - Implement X-CSRF pattern
description: Azure API managment policy sample - Demonstrates how to implement X-CSRF pattern used by many APIs. This example is specific to SAP Gateway.
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

# Implement X-CSRF pattern

This article shows an Azure API management policy sample that demonstrates how to implement X-CSRF pattern used by many APIs. This example is specific to SAP Gateway. To set or edit a policy code, follow the steps described in [Set or edit a policy](../set-edit-policies.md). To see other examples, see [policy samples](../policy-samples.md).

## Policy

Paste the code into the **inbound** block.

```xml
<!-- The policy defined in this file shows how to implement X-CSRF pattern used by many APIs. The example is specific to SAP Gateway.  -->

<!--	Detailed description of the scenario and solution can be found on: -->
<!--      http://blog.ibiz-solutions.se/uncategorized/exposing-sap-gateway-services-with-api-management/. -->

<!-- Copy the following snippet into the inbound section. -->

<policies>
  <inbound>
    <base/>
    <!-- Set the URL to the service. -->
    <rewrite-uri template="sap/opu/odata/sap/ZCAV_AZURE_CS_ORDER_SRV/ItHeaderSet('{oid}')" />

    <!-- Creating a subrequest "fetchtokenresponse" and set it as GET request to get the token and cookie.-->
    <send-request mode="new" response-variable-name="fetchtokenresponse" timeout="10" ignore-error="false">
      <set-url>@(context.Request.Url.ToString())</set-url>
      <set-method>GET</set-method>
      <set-header name="X-CSRF-Token" exists-action="override">
        <value>Fetch</value>
      </set-header>
      <set-header name="Authorization" exists-action="override">
        <value>{{http-basic-auth-header-value}}</value>
      </set-header>
      <set-body>
      </set-body>
    </send-request>

    <!-- Extract the token from the "fetchtokenresponse" and set as header in the POST request. -->
    <set-header name="X-CSRF-Token" exists-action="skip">
      <value>@(((IResponse)context.Variables["fetchtokenresponse"]).Headers.GetValueOrDefault("x-csrf-token"))</value>
    </set-header>

    <!-- Extract the Cookie from the "fetchtokenresponse" and set as header in the POST request. -->
    <set-header name="Cookie" exists-action="skip">
      <value>
        @{
        string rawcookie = ((IResponse)context.Variables["fetchtokenresponse"]).Headers.GetValueOrDefault("Set-Cookie");
        string[] cookies = rawcookie.Split(';');
        string xsrftoken = cookies.FirstOrDefault( ss => ss.Contains("sap-XSRF"));
        return xsrftoken.Split(',')[1];}
      </value>
    </set-header>
  </inbound>
  <backend>
    <base/>
  </backend>
  <outbound>
    <base/>
  </outbound>
  <on-error>
    <base/>
  </on-error>
</policies>
```

## Next steps

Learn more about APIM policies:

+ [Transformation policies](../api-management-transformation-policies.md)
+ [Policy samples](../policy-samples.md)

