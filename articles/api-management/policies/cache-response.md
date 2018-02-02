---
title: Azure API managment policy sample - Add capabilities to a backend service
description: Azure API managment policy sample - Demonstrates how to add capabilities to a backend service. For example, accept a name of the place instead of latitude and longitude in a weather forecast API.
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

# Add capabilities to a backend service

This article shows an Azure API management policy sample that demonstrates how to add capabilities to a backend service. For example, accept a name of the place instead of latitude and longitude in a weather forecast API. To set or edit a policy code, follow the steps described in [Set or edit a policy](../set-edit-policies.md). To see other examples, see [policy samples](../policy-samples.md).

## Policy

Paste the code into the **inbound** block.

```xml
<!-- The policy defined in this file shows how to use a few policies to add a capability to a backend service. -->

<!-- https://darksky.net/dev API was used as a backend service in this example. The snippet contains enough information for reconstituting the setup and testing the policy. -->
<!-- The snippet shows how to accept a name of the place instead of latitude and longitude in a weather forecast API. -->

<!-- Copy the following snippet into the inbound section and look at the trace window to see it work. -->

<policies>
  <inbound>
    <base />
    <!-- Check if lat/long has already been cached for this place and fetch it into a variable. -->
    <cache-lookup-value key="@(context.Request.MatchedParameters.GetValueOrDefault("place="""))" variable-name="latlong"/>

    <!-- If no lat/long found, use external API to get lat/long of the place and cache it. -->
    <choose>
      <when condition="@(!context.Variables.ContainsKey("latlong="""))">

        <!-- Lookup lat/long for the place. -->
        <send-request mode="new" response-variable-name="response" timeout="10" ignore-error="false">
          <set-url>
            @{
            var code = context.Request.MatchedParameters.GetValueOrDefault("place");
            var key = "{{google-geo-api-key}}";
            return $"https://maps.googleapis.com/maps/api/geocode/json?address={code}&key={key}";
            }
          </set-url>
          <set-method>GET</set-method>
        </send-request>

        <!-- Extract a JSON object containing lat/long from the response and serialize it into a variable. -->
        <set-variable name="latlong" value="@(((IResponse)context.Variables["response="""]).Body.As<JObject>
          ()["results"][0]["geometry"]["location"].ToString())"/>

          <!-- Cache lat/long for a an hour (coould be for much longer of course, since places don't move very often). -->
          <cache-store-value key="@(context.Request.MatchedParameters.GetValueOrDefault("latlong="""))" value="@((string)context.Variables["latlong="""])" duration="3600"/>
        </when>
    </choose>

    <!-- Change forwarding URL to the form expected by the backend, i.e. containing the key and lat/lng.  -->
    <rewrite-uri template="@{
            var loc = JObject.Parse((string)context.Variables["latlong=""
                               lat=""
                               lng=""
                         forecast=""/{{dark-sky-api-key}}/{lat},{lng}";}"/>

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

