The following table lists quotas and limits specific to Azure Event Hubs. For information about Event Hubs pricing, see [Event Hubs pricing](https://www.azure.cn/pricing/details/event-hubs/).

| Limit | Scope | Type | Behavior when exceeded | Value |
| --- | --- | --- | --- | --- |
| Number of Event Hubs per namespace |Namespace |Static |Subsequent requests for creation of a new namespace will be rejected. |10 |
| Number of partitions per Event Hub |Entity |Static |- |32 |
| Number of consumer groups per Event Hub |Entity |Static |- |20 |
| Number of AMQP connections per namespace |Namespace |Static |Subsequent requests for additional connections will be rejected and an exception is received by the calling code. |5,000 |
| Maximum size of Event Hubs event|System-wide |Static |- |256 KB |
| Maximum size of an Event Hub name |Entity |Static |- |50 characters |
| Number of non-epoch receivers per consumer group |Entity |Static |- |5 |
| Maximum retention period of event data |Entity |Static |- |1-7 days |
| Maximum throughput units |Namespace |Static |Exceeding the throughput unit limit causes your data to be throttled and generates a **[ServerBusyException](https://docs.microsoft.com/zh-cn/dotnet/api/microsoft.servicebus.messaging.serverbusyexception)**. |20 |
| Number of Authorization Rules per namespace |Namespace|Static |Subsequent requests for authorization rule creation will be rejected.|12 |
<!-- Not Available /azure-supportability/*.md , event-hubs/event-hubs-auto-inflate.md-->
<!-- md.date: 09/25/2017-->
