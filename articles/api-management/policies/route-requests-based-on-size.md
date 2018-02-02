---
title: Azure API managment policy sample - Route the request based on the size of its body
description: Azure API managment policy sample - Demonstrates how to route requests based on the size of their bodies.
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

# Route the request based on the size of its body

This article shows an Azure API management policy sample that demonstrates how to route requests based on the size of their bodies. To set or edit a policy code, follow the steps described in [Set or edit a policy](../set-edit-policies.md). To see other examples, see [policy samples](../policy-samples.md).

## Policy

Paste the code into the **inbound** block.

```xml
<!-- The policy defined in this file demonstrates how to route requests based on the size of the message body. -->
<!-- Content-Length header contains the size of the message body. -->

<!--  256 KB, a limitation on message size in the Azure Service Bus.  -->
<!-- The snippet checks if the message is smaller than 256000 bytes. If it's larger, request is routed somewhere else. -->

<!-- Copy the following snippet into the inbound section. -->

<policies>
    <inbound>
	    <base/>
		    <set-variable name="bodySize" value="@(context.Request.Headers["Content-Length"][0])"/>
		    <choose>
			    <when condition="@(int.Parse(context.Variables.GetValueOrDefault<string>("bodySize"))<256000)">
				    <!-- let it pass through by doing nothing -->
			    </when>
			    <otherwise>
				    <rewrite-uri template="{{alternate-path-and-query}}"/>
				    <set-backend-service base-url="{{alternate-host}}"/>
			    </otherwise>
		    </choose>

		    <!-- In rare cases where Content-Length header is not present we'll have to read the body to get its length. -->
            <!--
            <choose>
        	    <when condition="@(context.Request.Body.As<string>(preserveContent: true).Length<256000)">

        	    </when>
        	    <otherwise>
        		    <rewrite-uri template=""/>
        		    <set-backend-service base-url=""/>
        	    </otherwise>
            </choose>
		    -->
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

