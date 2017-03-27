<properties
    pageTitle="Consume monitoring data from Azure | Azure"
    description="Learn about all the monitoring data sources available on Azure today."
    author="johnkemnetz"
    manager="rboucher"
    editor=""
    services="monitoring-and-diagnostics"
    documentationcenter="monitoring-and-diagnostics" />
<tags
    ms.assetid="ms.service: monitoring-and-diagnostics"
    ms.workload="na"
    ms.tgt_pltfrm="na"
    ms.devlang="na"
    ms.topic="article"
    ms.date="3/17/2017"
    wacn.date=""
    ms.author="johnkem" />

# Consume monitoring data from Azure

Across the Azure platform, we are bringing together monitoring data in a single place with the Azure Monitor pipeline, but practically acknowledge that today not all monitoring data is available in that pipeline yet. In this article, we will summarize the various ways you can programmatically access monitoring data from Azure services.

## Options for data consumption

| Data type | Category | Supported Services | Methods of access |
| --- | --- | --- | --- |
| Azure Monitor platform-level metrics | Metrics | [See list here](/documentation/articles/monitoring-supported-metrics/) | <ul><li>**REST API:** [Azure Monitor Metric API](https://docs.microsoft.com/rest/api/monitor/metrics)</li><li>**Storage blob or event hub:** [Diagnostic Settings](/documentation/articles/monitoring-overview-of-diagnostic-logs/#diagnostic-settings)</li></ul> |
| Compute guest OS metrics (eg. perf counters) | Metrics | [Windows](/documentation/articles/virtual-machines-dotnet-diagnostics/) and Linux Virtual Machines (v2), [Cloud Services](/documentation/articles/cloud-services-dotnet-diagnostics-trace-flow/), [Service Fabric](/documentation/articles/service-fabric-diagnostics-how-to-monitor-and-diagnose-services-locally/) | <ul><li>**Storage table or blob:** [Windows or Linux Azure diagnostics](/documentation/articles/cloud-services-dotnet-diagnostics-storage/)</li><li>**Event hub:** [Windows Azure diagnostics](/documentation/articles/event-hubs-streaming-azure-diags-data/)</li></ul> |
| Custom or application metrics | Metrics | Any application instrumented with Application Insights | <ul><li>**REST API:** [Application Insights REST API](https://dev.applicationinsights.io/reference)</li></ul> |
| Storage metrics | Metrics | Azure Storage | <ul><li>**Storage table:** [Storage Analytics](https://docs.microsoft.com/rest/api/storageservices/fileservices/storage-analytics)</li></ul> |
| Activity Log | Events | All Azure services | <ul><li>**REST API:** [Azure Monitor Events API](https://docs.microsoft.com/rest/api/monitor/events)</li><li>**Storage blob or event hub:** [Log Profile](/documentation/articles/monitoring-overview-activity-logs/#export-the-activity-log-with-log-profiles)</li></ul> |
| Azure Monitor Diagnostic Logs | Events | [See list here](monitoring-overview-of-diagnostic-logs/#supported-services-and-schema-for-diagnostic-logs) | <ul><li>**Storage blob or event hub:** [Diagnostic Settings](/documentation/articles/monitoring-overview-of-diagnostic-logs/#diagnostic-settings)</li></ul> |
| Compute guest OS logs (eg. IIS, ETW, syslogs) | Events | [Windows](../virtual-machines-dotnet-diagnostics/) and Linux Virtual Machines (v2), [Cloud Services](../cloud-services/cloud-services-dotnet-diagnostics-trace-flow/), [Service Fabric](/documentation/articles/service-fabric-diagnostics-how-to-monitor-and-diagnose-services-locally/) | <ul><li>**Storage table or blob:** [Windows or Linux Azure diagnostics](/documentation/articles/cloud-services-dotnet-diagnostics-storage/)</li><li>**Event hub:** [Windows Azure diagnostics](/documentation/articles/event-hubs-streaming-azure-diags-data/)</li></ul> |
| App Service logs | Events | App services | <ul><li>**File, table, or blob storage:** [Web app diagnostics](/documentation/articles/web-sites-enable-diagnostic-log/)</li></ul> |
| Storage logs | Events | Azure Storage | <ul><li>**Storage table:** [Storage Analytics](https://docs.microsoft.com/rest/api/storageservices/fileservices/storage-analytics)</li></ul> |
| Security Center alerts | Events | Azure Security Center | <ul><li>**REST API:** [Security Alerts](https://msdn.microsoft.com/library/mt704050.aspx)</li></ul> |
| Active Directory reporting | Events | Azure Active Directory | <ul><li>**REST API:** [Azure Active Directory graph API](/documentation/articles/active-directory-reporting-api-getting-started/)</li></ul> |
| Security Center resource status | Status | [All supported resources](https://msdn.microsoft.com/library/mt704041.aspx#Anchor_1) | <ul><li>**REST API:** [Security Statuses](https://msdn.microsoft.com/library/mt704041.aspx)</li></ul> |
| Resource Health | Status | Supported services | <ul><li>**REST API:** [Resource health REST API](https://azure.microsoft.com/blog/reduce-troubleshooting-time-with-azure-resource-health/)</li></ul> |
| Azure Monitor metric alerts | Notifications | [See list here](/documentation/articles/monitoring-supported-metrics/) | <ul><li>**Webhook:** [Azure metric alerts](/documentation/articles/insights-webhooks-alerts/)</li></ul> |
| Azure Monitor Activity Log alerts | Notifications | All Azure services | <ul><li>**Webhook:** Azure Activity Log alerts</li></ul> |
| Autoscale notifications | Notifications | [See list here](/documentation/articles/monitoring-overview-autoscale/#supported-services-for-autoscale) | <ul><li>**Webhook:** [Autoscale notification webhook payload schema](/documentation/articles/insights-autoscale-to-webhook-email/#autoscale-notification-webhook-payload-schema)</li></ul> |
| OMS Log Search Query alerts | Notifications | OMS Log Analytics | <ul><li>**Webhook:** [Log Analytics alerts](/documentation/articles/log-analytics-alerts-actions/#webhook-actions)</li></ul> |
| Application Insights metric alerts | Notifications | Application Insights | <ul><li>**Webhook:** [Application Insights alerts](/documentation/articles/app-insights-alerts/)</li></ul> |
| Application Insights web tests | Notifications | Application Insights | <ul><li>**Webhook:** [Application Insights alerts](/documentation/articles/app-insights-alerts/)</li></ul> |

## Next steps

- Learn more about [Azure Monitor metrics](/documentation/articles/monitoring-overview-metrics/)
- Learn more about [the Azure Activity Log](/documentation/articles/monitoring-overview-activity-logs/)
- Learn more about [Azure Diagnostic Logs](/documentation/articles/monitoring-overview-of-diagnostic-logs/)
