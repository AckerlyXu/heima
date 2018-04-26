---
title: Azure API managment policy sample - Use OAuth2 for authorization between the gateway and a backend
description: Azure API managment policy sample - Demonstrates how to use OAuth2 for authorization between the gateway and a backend. It shows how to obtain an access token from AAD and forward it to the backend.
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
ms.date: 05/07/2018
ms.author: v-yiso
---

# Use OAuth2 for authorization between the gateway and a backend

This article shows an Azure API management policy sample that demonstrates how to use OAuth2 for authorization between the gateway and a backend. It shows how to obtain an access token from AAD and forward it to the backend. 

To set or edit a policy code, follow the steps described in [Set or edit a policy](../set-edit-policies.md). To see other examples, see [policy samples](../policy-samples.md).

The following script uses properties that appear in {{property}}. To learn about properties and how to use them in API Management policies, see [this](../api-management-howto-properties.md) topic.
 
## Policy

Paste the code into the **inbound** block.

```xml
<!-- The policy defined in this file provides an example of using OAuth2 for authorization between the gateway and a backend. -->
<!-- It shows how to obtain an access token from AAD and forward it to the backend. -->

<!-- Send request to AAD to obtain a bearer token -->
<!-- Parameters: authorizationServer - format https://login.windows.net/TENANT-GUID/oauth2/token -->
<!-- Parameters: scope - a URI encoded scope value -->
<!-- Parameters: clientId - an id obtained during app registration -->
<!-- Parameters: clientSecret - a URL encoded secret, obtained during app registration -->

<!-- Copy the following snippet into the inbound section. -->

<policies>
  <inbound>
    <base />
      <send-request ignore-error="true" timeout="20" response-variable-name="bearerToken" mode="new">
        <set-url>{{authorizationServer}}</set-url>
        <set-method>POST</set-method>
        <set-header name="Content-Type" exists-action="override">
          <value>application/x-www-form-urlencoded</value>
        </set-header>
        <set-body>
          @{
          return "client_id={{clientId}}&resource={{scope}}&client_secret={{clientSecret}}&grant_type=client_credentials";
          }
        </set-body>
      </send-request>

      <set-header name="Authorization" exists-action="override">
        <value>
          @("Bearer " + (String)((IResponse)context.Variables["bearerToken"]).Body.As<JObject>()["access_token"])
	  </value>
      </set-header>

      <!--  Don't expose APIM subscription key to the backend. -->
      <set-header exists-action="delete" name="Ocp-Apim-Subscription-Key"/>
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

