---
title: Monitor and troubleshoot a cloud storage application in Azure | Microsoft Docs 
description: Use diagnostic tools, metrics, and alerting to troubleshoot and monitor a cloud application.
services: storage
author: forester123
manager: josefree

ms.service: storage
ms.workload: web
ms.devlang: csharp
ms.topic: tutorial
origin.date: 02/20/2018
ms.date: 05/07/2018
ms.author: v-johch
ms.custom: mvc
---

# Monitor and troubleshoot a cloud storage application

This tutorial is part four and the final part of a series. You learn how to monitor and troubleshoot a cloud storage application.

In part four of the series, you learn how to:

> [!div class="checklist"]
> * Turn on logging and metrics
> * Enable alerts for authorization errors
> * Run test traffic with incorrect SAS tokens
> * Download and view logs

[Azure storage analytics](../common/storage-analytics.md) provides logging and metric data for a storage account. This data provides insights into the health of your storage account. Before you can be visibility into your storage account, you need to set up data collection. This process involves turning on logging, configuring metrics, and enabling alerts.

Logging and metrics from storage accounts are enabled from the **Diagnostics** tab in the Azure portal. There are two types of metrics. **Aggregate** metrics collect ingress/egress, availability, latency, and success percentages. These metrics are aggregated for the blob, queue, table, and file services. **Per API** collects the same set of metrics for each storage operation in the Azure Storage service API. Storage logging enables you to record details for both successful and failed requests in your storage account. These logs enable you to see details of read, write, and delete operations against your Azure tables, queues, and blobs. They also enable you to see the reasons for failed requests such as timeouts, throttling, and authorization errors.

## Log in to the Azure portal

Log in to the [Azure portal](https://portal.azure.cn)

## Turn on logging and metrics

From the left menu, select **Resource Groups**, select **myResourceGroup**, and then select your storage account in the resource list.

Under **Diagnostics** set **Status** to **On**. Ensure all of the options under **Blob properties** are enabled.

When complete, click **Save**

![Diagnostics pane](media/storage-monitor-troubleshoot-storage-application/contoso.png)

## Enable alerts

Alerts provide a way to email administrators or trigger a webhook based on a metric breaching a threshold. In this example, you enable an alert for the `SASClientOtherError` metric.

### Navigate to the storage account in the Azure portal

From the left menu, select **Resource Groups**, select **myResourceGroup**, and then select your storage account in the resource list.

Under the **Monitoring** section, select **Alert rules**.

Select **+ Add alert**, under **Add an alert rule**, fill in the required information. Choose `SASClientOtherError` from the **Metric** drop-down.

![Diagnostics pane](media/storage-monitor-troubleshoot-storage-application/figure2.png)

## Simulate an error

To simulate a valid alert, you can attempt to request a non-existent blob from your storage account. To do this, replace the `<incorrect-blob-name>` value with a value that does not exist. Run the following code sample a few times to simulate failed blob requests.

```azurecli
sasToken=$(az storage blob generate-sas \
    --account-name <storage-account-name> \
    --account-key <storage-account-key> \
    --container-name <container> \
    --name <incorrect-blob-name> \
    --permissions r \
    --expiry `date --date="next day" +%Y-%m-%d` \
    --output tsv)

curl https://<storage-account-name>.blob.core.chinacloudapi.cn/<container>/<incorrect-blob-name>?$sasToken
```

The following image is an example alert that is based off the simulated failure ran with the preceding example.

 ![Example alert](media/storage-monitor-troubleshoot-storage-application/alert.png)

## Download and view logs

Storage logs store data in a set of blobs in a blob container named **$logs** in your storage account. This container does not show up if you list all the blob containers in your account but you can see its contents if you access it directly.


## Next steps

In part four and the final part of the series, you learned how to monitor and troubleshoot your storage account, such as how to:

> [!div class="checklist"]
> * Turn on logging and metrics
> * Enable alerts for authorization errors
> * Run test traffic with incorrect SAS tokens
> * Download and view logs

Follow this link to see pre-built storage samples.

> [!div class="nextstepaction"]
> [Azure storage script samples](storage-samples-blobs-cli.md)