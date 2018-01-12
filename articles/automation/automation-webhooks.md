---
title: Starting an Azure Automation runbook with a webhook | Azure
description: A webhook that allows a client to start a runbook in Azure Automation from an HTTP call.  This article describes how to create a webhook and how to call one to start a runbook.
services: automation
documentationcenter: ''
author: yunan2016
manager: digimobile
editor: tysonn

ms.assetid: 9b20237c-a593-4299-bbdc-35c47ee9e55d
ms.service: automation
ms.devlang: na
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: infrastructure-services
origin.date: 02/22/2017
ms.date: 01/15/2018
ms.author: v-nany


---
# Starting an Azure Automation runbook with a webhook
A *webhook* allows you to start a particular runbook in Azure Automation through a single HTTP request. This allows external services such as Visual Studio Team Services, GitHub, Microsoft Operations Management Suite Log Analytics, or custom applications to start runbooks without implementing a full solution using the Azure Automation API.  
![WebhooksOverview](media/automation-webhooks/webhook-overview-image.png)

You can compare webhooks to other methods of starting a runbook in [Starting a runbook in Azure Automation](automation-starting-a-runbook.md)

## Details of a webhook
The following table describes the properties that you must configure for a webhook.

| Property | Description |
|:--- |:--- |
| Name |You can provide any name you want for a webhook since this is not exposed to the client.  It is only used for you to identify the runbook in Azure Automation. <br>  As a best practice, you should give the webhook a name related to the client that will use it. |
| URL |The URL of the webhook is the unique address that a client calls with an HTTP POST to start the runbook linked to the webhook.  It is automatically generated when you create the webhook.  You cannot specify a custom URL. <br> <br>  The URL contains a security token that allows the runbook to be invoked by a third party system with no further authentication. For this reason, it should be treated like a password.  For security reasons, you can only view the URL in the Azure portal at the time the webhook is created. You should note the URL in a secure location for future use. |
| Expiration date |Like a certificate, each webhook has an expiration date at which time it can no longer be used.  This expiration date can be modified after the webhook is created. |
| Enabled |A webhook is enabled by default when it is created.  If you set it to Disabled, then no client will be able to use it.  You can set the **Enabled** property when you create the webhook or anytime once it is created. |

### Parameters
A webhook can define values for runbook parameters that are used when the runbook is started by that webhook. The webhook must include values for any mandatory parameters of the runbook and may include values for optional parameters. A parameter value configured to a webhook can be modified even after creating the webhoook. Multiple webhooks linked to a single runbook can each use different parameter values.

When a client starts a runbook using a webhook, it cannot override the parameter values defined in the webhook.  To receive data from the client, the runbook can accept a single parameter called **$WebhookData** of type [object] that will contain data that the client includes in the POST request.

![Webhookdata properties](media/automation-webhooks/webhook-data-properties.png)

The **$WebhookData** object will have the following properties:

| Property | Description |
|:--- |:--- |
| WebhookName |The name of the webhook. |
| RequestHeader |Hash table containing the headers of the incoming POST request. |
| RequestBody |The body of the incoming POST request.  This will retain any formatting such as string, JSON, XML, or form encoded data. The runbook must be written to work with the data format that is expected. |

There is no configuration of the webhook required to support the **$WebhookData** parameter, and the runbook is not required to accept it.  If the runbook does not define the parameter, then any details of the request sent from the client is ignored.

If you specify a value for $WebhookData when you create the webhook, that value will be overriden when the webhook starts the runbook with the data from the client POST request, even if the client does not include any data in the request body.  If you start a runbook that has $WebhookData using a method other than a webhook, you can provide a value for $Webhookdata that will be recognized by the runbook.  This value should be an object with the same [properties](#details-of-a-webhook) as $Webhookdata so that the runbook can properly work with it as if it was working with actual WebhookData passed by a webhook.

For example, if you are starting the following runbook from the Azure Portal and want to pass some sample WebhookData for testing, since WebhookData is an object, it should be passed as JSON in the UI.

![WebhookData parameter from UI](media/automation-webhooks/WebhookData-parameter-from-UI.png)

For the above runbook, if you have the following properties for the WebhookData parameter:

1. WebhookName: *MyWebhook*
2. RequestHeader: *From=Test User*
3. RequestBody: *[“VM1”, “VM2”]*

Then you would pass the following JSON value in the UI for the WebhookData parameter:  

* {"WebhookName":"MyWebhook", "RequestHeader":{"From":"Test User"}, "RequestBody":"[\"VM1\",\"VM2\"]"}

![Start WebhookData parameter from UI](media/automation-webhooks/Start-WebhookData-parameter-from-UI.png)

> [!NOTE]
> The values of all input parameters are logged with the runbook job.  This means that any input provided by the client in the webhook request will be logged and available to anyone with access to the automation job.  For this reason, you should be cautious about including sensitive information in webhook calls.
>

## Security
The security of a webhook relies on the privacy of its URL which contains a security token that allows it to be invoked. Azure Automation does not perform any authentication on the request as long as it is made to the correct URL. For this reason, webhooks should not be used for runbooks that perform highly sensitive functions without using an alternate means of validating the request.

You can include logic within the runbook to determine that it was called by a webhook by checking the **WebhookName** property of the $WebhookData parameter. The runbook could perform further validation by looking for particular information in the **RequestHeader** or **RequestBody** properties.

Another strategy is to have the runbook perform some validation of an external condition when it received a webhook request.  For example, consider a runbook that is called by GitHub whenever there is a new commit to a GitHub repository.  The runbook might connect to GitHub to validate that a new commit had actually just occurred before continuing.

## Creating a webhook
Use the following procedure to create a new webhook linked to a runbook in the Azure portal.

1. From the **Runbooks page** in the Azure portal, click the runbook that the webhook will start to view its detail page.
2. Click **Webhook** at the top of the page to open the **Add Webhook** page. <br>
   ![Webhooks button](media/automation-webhooks/webhooks-button.png)
3. Click **Create new webhook** to open the **Create webhook page**.
4. Specify a **Name**, **Expiration Date** for the webhook and whether it should be enabled. See [Details of a webhook](#details-of-a-webhook) for more information these properties.
5. Click the copy icon and press Ctrl+C to copy the URL of the webhook.  Then record it in a safe place.  **Once you create the webhook, you cannot retrieve the URL again.** <br>
   ![Webhook URL](media/automation-webhooks/copy-webhook-url.png)
6. Click **Parameters** to provide values for the runbook parameters.  If the runbook has mandatory parameters, then you will not be able to create the webhook unless values are provided.
7. Click **Create** to create the webhook.

## Using a webhook
To use a webhook after it has been created, your client application must issue an HTTP POST with the URL for the webhook.  The syntax of the webhook will be in the following format.

    http://<Webhook Server>/token?=<Token Value>

The client will receive one of the following return codes from the POST request.  

| Code | Text | Description |
|:--- |:--- |:--- |
| 202 |Accepted |The request was accepted, and the runbook was successfully queued. |
| 400 |Bad Request |The request was not accepted for one of the following reasons. <ul> <li>The webhook has expired.</li> <li>The webhook is disabled.</li> <li>The token in the URL is invalid.</li>  </ul> |
| 404 |Not Found |The request was not accepted for one of the following reasons. <ul> <li>The webhook was not found.</li> <li>The runbook was not found.</li> <li>The account was not found.</li>  </ul> |
| 500 |Internal Server Error |The URL was valid, but an error occurred.  Please resubmit the request. |

Assuming the request is successful, the webhook response contains the job id in JSON format as follows. It will contain a single job id, but the JSON format allows for potential future enhancements.

    {"JobIds":["<JobId>"]}  

The client cannot determine when the runbook job completes or its completion status from the webhook.  It can determine this information using the job id with another method such as [Windows PowerShell](http://msdn.microsoft.com/library/azure/dn690263.aspx) or the [Azure Automation API](https://msdn.microsoft.com/library/azure/mt163826.aspx).

### Example
The following example uses Windows PowerShell to start a runbook with a webhook.  Note that any language that can make an HTTP request can use a webhook; Windows PowerShell is just used here as an example.

The runbook is expecting a list of virtual machines formatted in JSON in the body of the request. We also are including information about who is starting the runbook and the date and time it is being started in the header of the request.      

    $uri = "https://s1events.azure-automation.cn/webhooks?token=8ud0dSrSo%2fvHWpYbklW%3c8s0GrOKJZ9Nr7zqcS%2bIQr4c%3d"
    $headers = @{"From"="user@contoso.com";"Date"="05/28/2015 15:47:00"}

    $vms  = @(
                @{ Name="vm01";ServiceName="vm01"},
                @{ Name="vm02";ServiceName="vm02"}
            )
    $body = ConvertTo-Json -InputObject $vms

    $response = Invoke-RestMethod -Method Post -Uri $uri -Headers $headers -Body $body
    $jobid = ConvertFrom-Json $response


The following image shows the header information (using a [Fiddler](http://www.telerik.com/fiddler) trace) from this request. This includes standard headers of an HTTP request in addition to the custom Date and From headers that we added.  Each of these values is available to the runbook in the **RequestHeaders** property of **WebhookData**.

![Webhooks button](media/automation-webhooks/webhook-request-headers.png)

The following image shows the body of the request (using a [Fiddler](http://www.telerik.com/fiddler) trace)  that is available to the runbook in the **RequestBody** property of **WebhookData**. This is formatted as JSON because that was the format that was included in the body of the request.     

![Webhooks button](media/automation-webhooks/webhook-request-body.png)

The following image shows the request being sent from Windows PowerShell and the resulting response.  The job id is extracted from the response and converted to a string.

![Webhooks button](media/automation-webhooks/webhook-request-response.png)

The following sample runbook accepts the previous example request and starts the virtual machines specified in the request body.

    workflow Test-StartVirtualMachinesFromWebhook
    {
        param (
            [object]$WebhookData
        )

        # If runbook was called from Webhook, WebhookData will not be null.
        if ($WebhookData -ne $null) {

            # Collect properties of WebhookData
            $WebhookName     =     $WebhookData.WebhookName
            $WebhookHeaders =     $WebhookData.RequestHeader
            $WebhookBody     =     $WebhookData.RequestBody

            # Collect individual headers. VMList converted from JSON.
            $From = $WebhookHeaders.From
            $VMList = ConvertFrom-Json -InputObject $WebhookBody
            Write-Output "Runbook started from webhook $WebhookName by $From."

            # Authenticate to Azure resources
            $Cred = Get-AutomationPSCredential -Name 'MyAzureCredential'
            Add-AzureAccount -Credential $Cred

            # Start each virtual machine
            foreach ($VM in $VMList)
            {
                $VMName = $VM.Name
                Write-Output "Starting $VMName"
                Start-AzureVM -Name $VM.Name -ServiceName $VM.ServiceName
            }
        }
        else {
            Write-Error "Runbook mean to be started only from webhook."
        }
    }





## Next steps
* For details on different ways to start a runbook, see [Starting a Runbook](automation-starting-a-runbook.md).
* For information on viewing the Status of a Runbook Job, refer to [Runbook execution in Azure Automation](automation-runbook-execution.md).
