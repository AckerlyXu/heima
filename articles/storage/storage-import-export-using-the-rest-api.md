<properties
    pageTitle="Using the Azure Import/Export service REST API | Azure"
    description="Learn how to use the Azure Import/Export service REST API"
    author="muralikk"
    manager="syadav"
    editor="tysonn"
    services="storage"
    documentationcenter="" />
<tags
    ms.assetid="233f80e9-2e7f-48e0-9639-5c7785e7d743"
    ms.service="storage"
    ms.workload="storage"
    ms.tgt_pltfrm="na"
    ms.devlang="na"
    ms.topic="article"
    ms.date="01/15/2017"
    wacn.date=""
    ms.author="muralikk" />

# Using the Azure Import/Export service REST API

The Azure Import/Export service exposes a REST API to enable programmatic control of import/export jobs. You can use the REST API to perform all of the import/export operations that you can perform with the [Azure portal](https://portal.azure.cn/). Additionally, you can use the REST API to perform certain granular operations, such as querying the percentage completion of a job, which are not currently available in the classic portal.

See [Using the Azure Import/Export service to Transfer Data to Blob Storage](/documentation/articles/storage-import-export-service/) for an overview of the Import/Export service and a tutorial that demonstrates how to use the classic portal to create and manage import and export jobs.

## Service endpoints

The Azure Import/Export service is a resource provider for Azure Resource Manager and provides a set of REST APIs at the following HTTPS endpoint for managing import/export jobs:


	https://management.chinacloudapi.cn/subscriptions/<subscription-id>/resourceGroups/<resource-group>/providers/Microsoft.ImportExport/jobs/<job-name>


## Versioning

Requests to the Import/Export service must specify the `api-version` parameter and set its value to `2016-11-01`.

## In this section

[Creating an Import Job](/documentation/articles/storage-import-export-creating-an-import-job/)

[Creating an Export Job](/documentation/articles/storage-import-export-creating-an-export-job/)

[Retrieving State Information for a Job](/documentation/articles/storage-import-export-retrieving-state-info-for-a-job/)

[Enumerating Jobs](/documentation/articles/storage-import-export-enumerating-jobs/)

[Cancelling and Deleting Jobs](/documentation/articles/storage-import-export-cancelling-and-deleting-jobs/)

[Backing Up Drive Manifests](/documentation/articles/storage-import-export-backing-up-drive-manifests/)

[Diagnostics and Error Recovery for Import-Export Jobs](/documentation/articles/storage-import-export-diagnostics-and-error-recovery/)

## See Also
 [Storage Import/Export REST](https://docs.microsoft.com/rest/api/storageimportexport)