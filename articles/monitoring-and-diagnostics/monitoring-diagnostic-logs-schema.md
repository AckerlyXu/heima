---
title: Azure Diagnostic Logs Supported Services and Schemas
description: Understand the supported services and event schema for Azure Diagnostic Logs.
author: johnkemnetz
manager: orenr
editor: ''
services: monitoring-and-diagnostics
documentationcenter: monitoring-and-diagnostics

ms.assetid: fe8887df-b0e6-46f8-b2c0-11994d28e44f
ms.service: monitoring-and-diagnostics
ms.workload: na
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 01/24/2018
ms.date: 03/19/2018
ms.author: v-yiso

---
# Supported services, schemas, and categories for Azure Diagnostic Logs

[Azure resource diagnostic logs](monitoring-overview-of-diagnostic-logs.md) are logs emitted by your Azure resources that describe the operation of that resource. These logs are resource-type specific. In this article, we outline the set of supported services and event schema for events emitted by each service. This article also includes a full list of available log categories per resource type.

## Supported services and schemas for resource diagnostic logs
The schema for resource diagnostic logs varies depending on the resource and log category.   

| Service | Schema & Docs |
| --- | --- |
| Analysis Services | Schema not available. |
| API Management | [API Management Diagnostic Logs](../api-management/api-management-howto-use-azure-monitor.md#diagnostic-logs) |
| Application Gateways |[Diagnostics Logging for Application Gateway](../application-gateway/application-gateway-diagnostics.md) |
| Azure Automation |[Log analytics for Azure Automation](../automation/automation-manage-send-joblogs-log-analytics.md) |
| Azure Batch |[Azure Batch diagnostic logging](../batch/batch-diagnostics.md) |
| Customer Insights | Schema not available. |
| Content Delivery Network | Schema not available. |
| CosmosDB | [Azure Cosmos DB Logging](../cosmos-db/logging.md) |
| Event Hubs |[Azure Event Hubs diagnostic logs](../event-hubs/event-hubs-diagnostic-logs.md) |
| IoT Hub | [IoT Hub Operations](../iot-hub/iot-hub-monitor-resource-health.md#use-azure-monitor) |
| Key Vault |[Azure Key Vault Logging](../key-vault/key-vault-logging.md) |
| Load Balancer |[Log analytics for Azure Load Balancer](../load-balancer/load-balancer-monitor-log.md) |
| DDOS Protection | Schema not available. |
| Recovery Services | [Data Model for Azure Backup](../backup/backup-azure-reports-data-model.md)|
| Search |[Enabling and using Search Traffic Analytics](../search/search-traffic-analytics.md) |
| Server Management | Schema not available. |
| Service Bus |[Azure Service Bus diagnostic logs](../service-bus-messaging/service-bus-diagnostic-logs.md) |
| SQL Database | [Azure SQL Database diagnostic logging](../sql-database/sql-database-metrics-diag-logging.md) |
| Stream Analytics |[Job diagnostic logs](../stream-analytics/stream-analytics-job-diagnostic-logs.md) |
| Virtual Networks | Schema not available. |

# Supported Diagnostic Log categories
|Resource Type|Category|Category Display Name|
|---|---|---|
|Microsoft.AnalysisServices/servers|Engine|Engine|
|Microsoft.AnalysisServices/servers|Service|Service|
|Microsoft.ApiManagement/service|GatewayLogs|Logs related to ApiManagement Gateway|
|Microsoft.Automation/automationAccounts|JobLogs|Job Logs|
|Microsoft.Automation/automationAccounts|JobStreams|Job Streams|
|Microsoft.Automation/automationAccounts|DscNodeStatus|Dsc Node Status|
|Microsoft.Devices/IotHubs|Connections|Connections|
|Microsoft.Devices/IotHubs|DeviceTelemetry|Device Telemetry|
|Microsoft.Devices/IotHubs|C2DCommands|C2D Commands|
|Microsoft.Devices/IotHubs|DeviceIdentityOperations|Device Identity Operations|
|Microsoft.Devices/IotHubs|FileUploadOperations|File Upload Operations|
|Microsoft.Devices/IotHubs|Routes|Routes|
|Microsoft.Devices/IotHubs|D2CTwinOperations|D2CTwinOperations|
|Microsoft.Devices/IotHubs|C2DTwinOperations|C2D Twin Operations|
|Microsoft.Devices/IotHubs|TwinQueries|Twin Queries|
|Microsoft.Devices/IotHubs|JobsOperations|Jobs Operations|
|Microsoft.Devices/IotHubs|DirectMethods|Direct Methods|
|Microsoft.Devices/IotHubs|E2EDiagnostics|E2E Diagnostics (Preview)|
|Microsoft.Devices/provisioningServices|DeviceOperations|Device Operations|
|Microsoft.Devices/provisioningServices|ServiceOperations|Service Operations|
|Microsoft.Devices/ElasticPools/IotHubTenants|Connections|Connections|
|Microsoft.Devices/ElasticPools/IotHubTenants|DeviceTelemetry|Device Telemetry|
|Microsoft.Devices/ElasticPools/IotHubTenants|C2DCommands|C2D Commands|
|Microsoft.Devices/ElasticPools/IotHubTenants|DeviceIdentityOperations|Device Identity Operations|
|Microsoft.Devices/ElasticPools/IotHubTenants|FileUploadOperations|File Upload Operations|
|Microsoft.Devices/ElasticPools/IotHubTenants|Routes|Routes|
|Microsoft.Devices/ElasticPools/IotHubTenants|D2CTwinOperations|D2CTwinOperations|
|Microsoft.Devices/ElasticPools/IotHubTenants|C2DTwinOperations|C2D Twin Operations|
|Microsoft.Devices/ElasticPools/IotHubTenants|TwinQueries|Twin Queries|
|Microsoft.Devices/ElasticPools/IotHubTenants|JobsOperations|Jobs Operations|
|Microsoft.Devices/ElasticPools/IotHubTenants|DirectMethods|Direct Methods|
|Microsoft.Devices/ElasticPools/IotHubTenants|E2EDiagnostics|E2E Diagnostics (Preview)|
|Microsoft.EventHub/namespaces|ArchiveLogs|Archive Logs|
|Microsoft.EventHub/namespaces|OperationalLogs|Operational Logs|
|Microsoft.EventHub/namespaces|AutoScaleLogs|Auto Scale Logs|
|Microsoft.KeyVault/vaults|AuditEvent|Audit Logs|
|Microsoft.Network/networksecuritygroups|NetworkSecurityGroupEvent|Network Security Group Event|
|Microsoft.Network/networksecuritygroups|NetworkSecurityGroupRuleCounter|Network Security Group Rule Counter|
|Microsoft.Network/networksecuritygroups|NetworkSecurityGroupFlowEvent|Network Security Group Rule Flow Event|
|Microsoft.Network/applicationGateways|ApplicationGatewayAccessLog|Application Gateway Access Log|
|Microsoft.Network/applicationGateways|ApplicationGatewayPerformanceLog|Application Gateway Performance Log|
|Microsoft.Network/applicationGateways|ApplicationGatewayFirewallLog|Application Gateway Firewall Log|
|Microsoft.Network/virtualNetworkGateways|GatewayDiagnosticLog|Gateway Diagnostic Logs|
|Microsoft.Network/virtualNetworkGateways|TunnelDiagnosticLog|Tunnel Diagnostic Logs|
|Microsoft.Network/virtualNetworkGateways|RouteDiagnosticLog|Route Diagnostic Logs|
|Microsoft.RecoveryServices/Vaults|AzureBackupReport|Azure Backup Reporting Data|
|Microsoft.RecoveryServices/Vaults|AzureSiteRecoveryJobs|Azure Site Recovery Jobs|
|Microsoft.RecoveryServices/Vaults|AzureSiteRecoveryEvents|Azure Site Recovery Events|
|Microsoft.RecoveryServices/Vaults|AzureSiteRecoveryReplicatedItems|Azure Site Recovery Replicated Items|
|Microsoft.RecoveryServices/Vaults|AzureSiteRecoveryReplicationStats|Azure Site Recovery Replication Stats|
|Microsoft.RecoveryServices/Vaults|AzureSiteRecoveryRecoveryPoints|Azure Site Recovery Recovery Points|
|Microsoft.RecoveryServices/Vaults|AzureSiteRecoveryReplicationDataUploadRate|Azure Site Recovery Replication Data Upload Rate|
|Microsoft.RecoveryServices/Vaults|AzureSiteRecoveryProtectedDiskDataChurn|Azure Site Recovery Protected Disk Data Churn|
|Microsoft.ServiceBus/namespaces|OperationalLogs|Operational Logs|
|Microsoft.StreamAnalytics/streamingjobs|Execution|Execution|
|Microsoft.StreamAnalytics/streamingjobs|Authoring|Authoring|

## Next Steps

* [Learn more about diagnostic logs](monitoring-overview-of-diagnostic-logs.md)
* [Stream resource diagnostic logs to **Event Hubs**](monitoring-stream-diagnostic-logs-to-event-hubs.md)
* [Change resource diagnostic settings using the Azure Monitor REST API](https://msdn.microsoft.com/library/azure/dn931931.aspx)
