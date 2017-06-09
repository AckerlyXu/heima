---
title: Azure CLI Script Sample - Running a job with Batch | Microsoft Docs
description: Azure CLI Script Sample - Running a job with Batch
services: batch
documentationcenter: ''
author: annatisch
manager: daryls
editor: tysonn

ms.assetid:
ms.service: batch
ms.devlang: azurecli
ms.topic: article
ms.tgt_pltfrm: multiple
ms.workload: na
ms.date: 03/20/2017
ms.author: v-junlch
---

# Running jobs on Azure Batch with Azure CLI

This script creates a Batch job and adds a series of tasks to the job. It also demonstrates
how to monitor a job and its tasks.
Running this script assumes that a Batch account has already been set up, and both a pool and
an application have been configured. For more information, please see the [sample scripts](../batch-cli-samples.md) covering
each of these topics.

If needed, install the Azure CLI using the instructions found in the [Azure CLI installation guide](https://docs.microsoft.com/cli/azure/install-azure-cli), 
and then run `az login` to log into Azure.

## Sample script

```azurecli
#!/bin/bash

# Authenticate Batch account CLI session.
az batch account login -g myresource group -n mybatchaccount

# Create a new job to encapsulate the tasks that we want to add.
# We'll assume a pool has already been created with the ID 'mypool' - for more information
# see the sample script for managing pools.
az batch job create --id myjob --pool-id mypool

# Now we will add tasks to the job.
# We'll assume an application package has already been uploaded with the ID 'myapp' - for
# more information see the sample script for adding applications.
az batch task create \
    --job-id myjob \
    --id task1 \
    --application-package-references myapp#1.0
    --command-line "cmd /c %AZ_BATCH_APP_PACKAGE_MYAPP#1.0%\\myapp.exe"

# If we want to add many tasks at once - this can be done by specifying the tasks
# in a JSON file, and passing it into the command. See tasks.json for formatting.
az batch task create --job-id myjob --json-file tasks.json

# Now that all the tasks are added - we can update the job so that it will automatically
# be marked as completed once all the tasks are finished.
az batch job set --on-all-tasks-complete terminateJob

# Monitor the status of the job.
az batch job show --job-id myjob

# Monitor the status of a task.
az batch task show --task-id task1
```

## Clean up job

After you run the above sample script, run the following command to remove the
job and all of its tasks. Note that the pool will need to be deleted separately; please see
the [tutorial on managing pools](./batch-cli-sample-manage-pool.md).

```azurecli
az batch job delete --job-id myjob
```

## Script explanation

This script uses the following commands to create a Batch job and tasks. Each command in the table links to command-specific documentation.

| Command | Notes |
|---|---|
| [az batch account login](https://docs.microsoft.com/cli/azure/batch/account#login) | Authenticate against a Batch account.  |
| [az batch job create](https://docs.microsoft.com/cli/azure/batch/job#create) | Creates a Batch job.  |
| [az batch job set](https://docs.microsoft.com/cli/azure/batch/job#set) | Updates properties of a Batch job.  |
| [az batch job show](https://docs.microsoft.com/cli/azure/batch/job#show) | Retrieves details of a specified Batch job.  |
| [az batch task create](https://docs.microsoft.com/cli/azure/batch/task#create) | Adds a task to the specified Batch job.  |
| [az batch task show](https://docs.microsoft.com/cli/azure/batch/task#show) | Retrieves the details of a task from the specified Batch job.  |

## Next steps

For more information on the Azure CLI, see [Azure CLI documentation](https://docs.microsoft.com/cli/azure/overview).

Additional Batch CLI script samples can be found in the [Azure Batch CLI documentation](../batch-cli-samples.md).

