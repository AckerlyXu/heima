---
title: Azure API managment policy sample - Send errors to Stackify for logging
description: Azure API managment policy sample - Demonstrates how to add an error logging policy to send errors to Stackify for logging..
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

# Send errors to Stackify for logging

This article shows an Azure API management policy sample that demonstrates how to add an error logging policy to send errors to Stackify for logging. To set or edit a policy code, follow the steps described in [Set or edit a policy](../set-edit-policies.md). To see other examples, see [policy samples](../policy-samples.md).

## Policy

Paste the code into the **on-error** block.

```xml
<!-- The policy defined in this file shows how to add an error logging policy to send errors to Stackify for logging. -->
<!-- You must specify the following named values: -->
  <!-- your-stackify-api-key  -->
  <!-- stackify-api-key  - Get this from your Stackify account -->
  <!-- environment-name - This will be send to Stackify for the environment filter, (Production, Dev, Test, etc) -->
  <!-- app-name - The Application name that will be sent to Stackify -->

<!-- Copy the following snippet into the on-error section. -->

<policies>
  <inbound>
    <base />
  </inbound>
  <backend>
    <base />
  </backend>
  <outbound>
    <base />
  </outbound>
  <on-error>
    <trace source="OnError">
      On Error
    </trace>
    <send-one-way-request mode="new">
      <set-url>https://api.stackify.com/Log/Save</set-url>
      <set-method>POST</set-method>
      <set-header name="Content-Type" exists-action="override">
        <value>value</value>
      </set-header>
      <set-header name="X-Stackify-PV" exists-action="override">
        <value>V1</value>
      </set-header>
      <set-header name="X-Stackify-Key" exists-action="override">
        <value>{{stackify-api-key}}</value>
      </set-header>
      <set-body>
        @{
        return new JObject(
        new JProperty("Environment","{{environment-name}}"),
        new JProperty("ServerName", context.Deployment.ServiceName),
        new JProperty("AppName", "{{app-name}}"),
        new JProperty("AppLoc", "/usr/local/stackify/stackify-agent"),
        new JProperty("Logger", "stackify-log-log4j12-1.0.12"),
        new JProperty("Platform", "java"),
        new JProperty("Msgs",
        new JArray(
        new JObject(
        new JProperty("Msg", context.LastError.Message),
        new JProperty("Th", "main"),
        new JProperty("EpochMs", (new DateTimeOffset(DateTime.Now)).ToUnixTimeSeconds() * 1000 ),
        new JProperty("Level", "error"),
        new JProperty("SrcMethod", context.LastError.Source)
        )))
        ).ToString();
        }
      </set-body>
    </send-one-way-request>
  </on-error>
</policies>
```

## Next steps

Learn more about APIM policies:

+ [Transformation policies](../api-management-transformation-policies.md)
+ [Policy samples](../policy-samples.md)

