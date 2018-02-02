---
title: Azure API managment policy sample - Add a header containing a correlation id 
description: Azure API managment policy sample - Demonstrates how to add a header containing a correlation id to the inbound request.
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

# Add a header containing a correlation id

This article shows an Azure API management policy sample that demonstrates how to add a header containing a correlation id to the inbound request. To set or edit a policy code, follow the steps described in [Set or edit a policy](../set-edit-policies.md). To see other examples, see [policy samples](../policy-samples.md).

## Policy

Paste the code into the **inbound** block.

```xml
<!-- The policy defined in this file demonstrates how to add a header containing a correlation id to the inbound request. -->
<!-- The id could be used to correlate requests forwarded by Azure API Management to requests in your backend. -->
<!-- The snippet uses a COMB GUID as an id value for efficient query performance. -->

<!-- NOTE: If COMB format is not needed, context.RequestId should be used as a value of correlation id. -->
<!-- context.RequestId is unique for each request and is stored as part of gateway log records. -->

<!-- Copy the following snippet into the inbound section. Applying this snippet at the global level will ensure that correlation id is added to all requests. -->




<policies>
    <inbound>
        <base />
        <set-header name="correlationid" exists-action="skip">
	        <value>@{ var guidBinary = new byte[16];
				        Array.Copy(Guid.NewGuid().ToByteArray(), 0, guidBinary, 0, 10);
				        long time = DateTime.Now.Ticks;
				        byte[] bytes = new byte[8];
				        unchecked
				        {
					        bytes[7] = (byte)(time >> 56);
					        bytes[6] = (byte)(time >> 48);
					        bytes[5] = (byte)(time >> 40);
					        bytes[4] = (byte)(time >> 32);
					        bytes[3] = (byte)(time >> 24);
					        bytes[2] = (byte)(time >> 16);
					        bytes[1] = (byte)(time >> 8);
					        bytes[0] = (byte)(time);
				        }
				        Array.Copy(bytes, 0, guidBinary, 8, 6);
				        return new Guid(guidBinary).ToString();
			        }
	        </value>
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

