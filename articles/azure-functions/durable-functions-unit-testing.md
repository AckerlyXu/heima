---
title: Azure Durable Functions unit testing
description: Learn how to unit test Durable Functions.
services: functions
author: kadimitr
manager: cfowler
editor: ''
tags: ''
keywords:
ms.service: functions
ms.devlang: multiple
ms.topic: article
ms.tgt_pltfrm: multiple
ms.workload: na
origin.date: 02/28/2018
ms.date: 04/13/2018
ms.author: v-junlch
---

# Durable Functions unit testing

Unit testing is an important part of modern software development practices. Unit tests verify business logic behavior and protect from introducing unnoticed breaking changes in the future. Durable Functions can easily grow in complexity so introducing unit tests will help to avoid breaking changes. The following sections explain how to unit test the three function types - Orchestration client, Orchestrator, and Activity functions. 

## Prerequisites

The examples in this article require knowledge of the following concepts and frameworks: 

- Unit testing

- Durable Functions 

- [xUnit](https://xunit.github.io/) - Testing framework

- [moq](https://github.com/moq/moq4) - Mocking framework


## Base classes for mocking 

Mocking is supported via two abstract classes in Durable Functions:

- DurableOrchestrationClientBase

- DurableOrchestrationContextBase

These classes are base classes for [DurableOrchestrationClient](https://azure.github.io/azure-functions-durable-extension/api/Microsoft.Azure.WebJobs.DurableOrchestrationClient.html) and [DurableOrchestrationContext](https://azure.github.io/azure-functions-durable-extension/api/Microsoft.Azure.WebJobs.DurableOrchestrationContext.html) that define Orchestration Client and Orchestrator methods. The mocks will set expected behavior for base class methods so the unit test can verify the business logic. There is a two-step workflow for unit testing the business logic in the Orchestration Client and Orchestrator:

1. Use the base classes instead of the concrete implementation when defining Orchestration Client and Orchestrator's signatures.
2. In the unit tests mock the behavior of the base classes and verify the business logic. 

Find more details in the following paragraphs for testing functions that use the orchestration client binding and the orchestrator trigger binding.

## Unit testing trigger functions

In this section, the unit test will validate the logic of the following HTTP trigger function for starting new orchestrations.

```csharp
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace VSSample
{
    public static class HttpStart
    {
        [FunctionName("HttpStart")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, methods: "post", Route = "orchestrators/{functionName}")] HttpRequestMessage req,
            [OrchestrationClient] DurableOrchestrationClientBase starter,
            string functionName,
            TraceWriter log)
        {
            // Function input comes from the request content.
            dynamic eventData = await req.Content.ReadAsAsync<object>();
            string instanceId = await starter.StartNewAsync(functionName, eventData);

            log.Info($"Started orchestration with ID = '{instanceId}'.");

            var res = starter.CreateCheckStatusResponse(req, instanceId);
            res.Headers.RetryAfter = new RetryConditionHeaderValue(TimeSpan.FromSeconds(10));
            return res;
        }
    }
}
```

The unit test task will be to verify the value of the `Retry-After` header provided in the response payload. So the unit test will mock some of DurableOrchestrationClientBase methods to ensure predictable behavior. 

First, a mock of the base class is required, DurableOrchestrationClientBase. The mock can be a new class that implements DurableOrchestrationClientBase. However, using a mocking framework like [moq](https://github.com/moq/moq4) simplifies the process:    

```csharp
    // Mock DurableOrchestrationClientBase
    var durableOrchestrationClientBaseMock = new Mock<DurableOrchestrationClientBase>();
```

Then `StartNewAsync` method is mocked to return a well-known instance ID.

```csharp
    // Mock StartNewAsync method
    durableOrchestrationClientBaseMock.
        Setup(x => x.StartNewAsync(functionName, It.IsAny<object>())).
        ReturnsAsync(instanceId);
```

Next `CreateCheckStatusResponse` is mocked to always return an empty HTTP 200 response.

```csharp
    // Mock CreateCheckStatusResponse method
    durableOrchestrationClientBaseMock
        .Setup(x => x.CreateCheckStatusResponse(It.IsAny<HttpRequestMessage>(), instanceId))
        .Returns(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(string.Empty),
        });
```

`TraceWriter` is also mocked:

```csharp
    // Mock TraceWriter
    var traceWriterMock = new Mock<TraceWriter>(TraceLevel.Info);

```  

Now the `Run` method is called from the unit test:

```csharp
    // Call Orchestration trigger function
    var result = await HttpStart.Run(
        new HttpRequestMessage()
        {
            Content = new StringContent("{}", Encoding.UTF8, "application/json"),
            RequestUri = new Uri("http://localhost:7071/orchestrators/E1_HelloSequence"),
        },
        durableOrchestrationClientBaseMock.Object, 
        functionName,
        traceWriterMock.Object);
 ``` 

 The last step is to compare the output with the expected value:

```csharp
    // Validate that output is not null
    Assert.NotNull(result.Headers.RetryAfter);

    // Validate output's Retry-After header value
    Assert.Equal(TimeSpan.FromSeconds(10), result.Headers.RetryAfter.Delta);
```

After combining all steps, the unit test will have the following code: 

```csharp
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace VSSample.Tests
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using Moq;
    using Xunit;

    public class HttpStartTests
    {
        [Fact]
        public async Task HttpStart_returns_retryafter_header()
        {
            // Define constants
            const string functionName = "SampleFunction";
            const string instanceId = "7E467BDB-213F-407A-B86A-1954053D3C24";

            // Mock TraceWriter
            var traceWriterMock = new Mock<TraceWriter>(TraceLevel.Info);

            // Mock DurableOrchestrationClientBase
            var durableOrchestrationClientBaseMock = new Mock<DurableOrchestrationClientBase>();

            // Mock StartNewAsync method
            durableOrchestrationClientBaseMock.
                Setup(x => x.StartNewAsync(functionName, It.IsAny<object>())).
                ReturnsAsync(instanceId);

            // Mock CreateCheckStatusResponse method
            durableOrchestrationClientBaseMock
                .Setup(x => x.CreateCheckStatusResponse(It.IsAny<HttpRequestMessage>(), instanceId))
                .Returns(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(string.Empty),
                });

            // Call Orchestration trigger function
            var result = await HttpStart.Run(
                new HttpRequestMessage()
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json"),
                    RequestUri = new Uri("http://localhost:7071/orchestrators/E1_HelloSequence"),
                },
                durableOrchestrationClientBaseMock.Object,
                functionName,
                traceWriterMock.Object);

            // Validate that output is not null
            Assert.NotNull(result.Headers.RetryAfter);

            // Validate output's Retry-After header value
            Assert.Equal(TimeSpan.FromSeconds(10), result.Headers.RetryAfter.Delta);
        }
    }
}
```

## Unit testing orchestrator functions

Orchestrator functions are even more interesting for unit testing since they usually have a lot more business logic. Currently, Orchestrator functions can be implemented only in C#.

In this section the unit tests will validate the output of the `E1_HelloSequence` Orchestrator function:

```csharp
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace VSSample
{
    public static class HelloSequence
    {
        [FunctionName("E1_HelloSequence")]
        public static async Task<List<string>> Run(
            [OrchestrationTrigger] DurableOrchestrationContextBase context)
        {
            var outputs = new List<string>();

            outputs.Add(await context.CallActivityAsync<string>("E1_SayHello", "Tokyo"));
            outputs.Add(await context.CallActivityAsync<string>("E1_SayHello", "Seattle"));
            outputs.Add(await context.CallActivityAsync<string>("E1_SayHello", "London"));

            // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]
            return outputs;
        }

        [FunctionName("E1_SayHello")]
        public static string SayHello([ActivityTrigger] string name)
        {
            return $"Hello {name}!";
        }
    }
 }
```

The unit test code will start with creating a mock:

```csharp
    var durableOrchestrationContextMock = new Mock<DurableOrchestrationContextBase>();
```

Then the activity method calls will be mocked:

```csharp
    durableOrchestrationContextMock.Setup(x => x.CallActivityAsync<string>("E1_SayHello", "Tokyo")).ReturnsAsync("Hello Tokyo!");
    durableOrchestrationContextMock.Setup(x => x.CallActivityAsync<string>("E1_SayHello", "Seattle")).ReturnsAsync("Hello Seattle!");
    durableOrchestrationContextMock.Setup(x => x.CallActivityAsync<string>("E1_SayHello", "London")).ReturnsAsync("Hello London!");
```

Next the unit test will call `HelloSequence.Run` method:

```csharp
    var result = await HelloSequence.Run(durableOrchestrationContextMock.Object);
```

And finally the output will be validated:

```csharp
    Assert.Equal(3, result.Count);
    Assert.Equal("Hello Tokyo!", result[0]);
    Assert.Equal("Hello Seattle!", result[1]);
    Assert.Equal("Hello London!", result[2]);
```

After combining all steps, the unit test will have the following code:

```csharp
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace VSSample.Tests
{
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Moq;
    using Xunit;

    public class HelloSequenceTests
    {
        [Fact]
        public async Task Run_returns_multiple_greetings()
        {
            var durableOrchestrationContextMock = new Mock<DurableOrchestrationContextBase>();
            durableOrchestrationContextMock.Setup(x => x.CallActivityAsync<string>("E1_SayHello", "Tokyo")).ReturnsAsync("Hello Tokyo!");
            durableOrchestrationContextMock.Setup(x => x.CallActivityAsync<string>("E1_SayHello", "Seattle")).ReturnsAsync("Hello Seattle!");
            durableOrchestrationContextMock.Setup(x => x.CallActivityAsync<string>("E1_SayHello", "London")).ReturnsAsync("Hello London!");

            var result = await HelloSequence.Run(durableOrchestrationContextMock.Object);

            Assert.Equal(3, result.Count);
            Assert.Equal("Hello Tokyo!", result[0]);
            Assert.Equal("Hello Seattle!", result[1]);
            Assert.Equal("Hello London!", result[2]);
        }
    }
}
```

## Unit testing activity functions

Activity functions can be unit tested in the same way as non-durable functions. Activity functions don't have a base class for mocking. So the unit tests use the parameter types directly.

In this section the unit test will validate the behavior of the `E1_SayHello` Activity function:

```csharp
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace VSSample
{
    public static class HelloSequence
    {
        [FunctionName("E1_HelloSequence")]
        public static async Task<List<string>> Run(
            [OrchestrationTrigger] DurableOrchestrationContextBase context)
        {
            var outputs = new List<string>();

            outputs.Add(await context.CallActivityAsync<string>("E1_SayHello", "Tokyo"));
            outputs.Add(await context.CallActivityAsync<string>("E1_SayHello", "Seattle"));
            outputs.Add(await context.CallActivityAsync<string>("E1_SayHello", "London"));

            // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]
            return outputs;
        }

        [FunctionName("E1_SayHello")]
        public static string SayHello([ActivityTrigger] string name)
        {
            return $"Hello {name}!";
        }
    }
 }
```

And the unit test will verify the format of the output:

```csharp
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace VSSample.Tests
{
    using Xunit;

    public class HelloSequenceActivityTests
    {
        [Fact]
        public void SayHello_returns_greeting()
        {
            var result = HelloSequence.SayHello("John");
            Assert.Equal("Hello John!", result);
        }
    }
}
```

## Next steps

> [!div class="nextstepaction"]
> [Learn more about xUnit](http://xunit.github.io/docs/getting-started-dotnet-core)

> [Learn more about moq](https://github.com/Moq/moq4/wiki/Quickstart)

