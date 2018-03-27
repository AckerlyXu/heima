The following table lists quotas and limits specific to [Azure Event Hubs](https://www.azure.cn/home/features/event-hubs/). For information about Event Hubs pricing, see [Event Hubs pricing](https://www.azure.cn/pricing/details/event-hubs/).

| Limit | Scope | Notes | Value |
| ----- | ----- | ----- | ----- |
| Number of event hubs per namespace |Namespace |Subsequent requests for creation of a new event hub will be rejected. |10 |
| Number of partitions per event hub |Entity |- |32 |
| Number of consumer groups per event hub |Entity |- |20 |
| Number of AMQP connections per namespace |Namespace |Subsequent requests for additional connections will be rejected and an exception is received by the calling code. |5,000 |
| Maximum size of Event Hubs event|Entity |- |256 KB |
| Maximum size of an event hub name |Entity |- |50 characters |
| Number of non-epoch receivers per consumer group |Entity |- |5 |
| Maximum retention period of event data |Entity |- |1-7 days |
| Maximum throughput units |Namespace |Exceeding the throughput unit limit causes your data to be throttled and generates a **[ServerBusyException](https://docs.azure.cn/zh-cn/dotnet/api/microsoft.servicebus.messaging.serverbusyexception?view=azure-dotnet)**. [Additional throughput units](../articles/event-hubs/event-hubs-auto-inflate.md) are available in blocks of 20 on a committed purchase basis. |20 |
<!-- Not Available on [support request](/azure-supportability/how-to-create-azure-support-request) -->
| Number of authorization rules per namespace |Namespace|Subsequent requests for authorization rule creation will be rejected.|12 |
<!-- ms.date: 04/02/2017 -->
<!-- Update_Description: update meta properties -->