<properties
	pageTitle="Create Azure Service Bus topic subscription and rule using template"
	description="Create a Service Bus namespace with topic, subscription, and rule using Azure Resource Manager template"
	services=" service-bus-messaging"
	documentationcenter=" .net"
	author="sethmanheim"
	manager="timlt"
	editor="" />

<tags
	ms.date="01/18/2017"
	ms.service = "service-bus"/>
	

---
# Create a Service Bus namespace with topic, subscription, and rule using an Azure Resource Manager template
This article shows how to use an Azure Resource Manager template that creates a Service Bus namespace with a topic, subscription, and rule (filter). You learn how to define which resources are deployed and how to define parameters that are specified when the deployment is executed. You can use this template for your own deployments, or customize it to meet your requirements

For more information about creating templates, see [Authoring Azure Resource Manager templates][Authoring Azure Resource Manager templates].

For more information about practice and patterns on Azure resources naming conventions, see [Recommended naming conventions for Azure resources][Recommended naming conventions for Azure resources].

For the complete template, see the [Service Bus namespace with topic, subscription, and rule][Service Bus namespace with topic, subscription, and rule] template.

> [!NOTE]
> The following Azure Resource Manager templates are available for download and deployment.
> 
>-  [Create a Service Bus namespace with queue and authorization rule](/documentation/artices/service-bus-resource-manager-namespace-auth-rule/)
>-  [Create a Service Bus namespace with queue](/documentation/artices/service-bus-resource-manager-namespace-queue/)
>-  [Create a Service Bus namespace](/documentation/artices/service-bus-resource-manager-namespace/)
>-  [Create a Service Bus namespace with topic and subscription](/documentation/artices/service-bus-resource-manager-namespace-topic/)
> 
> To check for the latest templates, visit the [Azure Quickstart Templates][Azure Quickstart Templates] gallery and search for Service Bus.
> 
> 

## What will you deploy?
With this template, you deploy a Service Bus namespace with topic, subscription, and rule (filter).

[Service Bus topics and subscriptions](/documentation/artices/service-bus-queues-topics-subscriptions/#topics-and-subscriptions) provide a one-to-many form of communication, in a *publish/subscribe* pattern. When using topics and subscriptions, components of a distributed application do not communicate directly with each other, instead they exchange messages via topic that acts as an intermediary.A subscription to a topic resembles a virtual queue that receives copies of messages that were sent to the topic. A filter on subscription enables you to specify which messages sent to a topic should appear within a specific topic subscription.

## What are rules (filters)?
In many scenarios, messages that have specific characteristics must be processed in different ways. To enable this, you can configure subscriptions to find messages that have desired properties and then perform certain modifications to those properties. While Service Bus subscriptions see all messages sent to the topic, you can only copy a subset of those messages to the virtual subscription queue. This is accomplished using subscription filters. To learn more on rules(filters), see [Service Bus queues, topics, and subscriptions][Service Bus queues, topics, and subscriptions].

To run the deployment automatically, click the following button:

[![Deploy to Azure](./media/service-bus-resource-manager-namespace-topic/deploybutton.png)](https://portal.azure.cn/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-quickstart-templates%2Fmaster%2F201-servicebus-create-topic-subscription-rule%2Fazuredeploy.json)

## Parameters
With Azure Resource Manager, you should define parameters for values you want to specify when the template is deployed. The template includes a section called `Parameters` that contains all the parameter values. You should define a parameter for those values that vary based on the project you are deploying or based on the environment you are deploying to. Do not define parameters for values that always stay the same. Each parameter value is used in the template to define the resources that are deployed.

The template defines the following parameters:

### serviceBusNamespaceName
The name of the Service Bus namespace to create.

```
"serviceBusNamespaceName": {
"type": "string"
}
```

### serviceBusTopicName
The name of the topic created in the Service Bus namespace.

```
"serviceBusTopicName": {
"type": "string"
}
```

### serviceBusSubscriptionName
The name of the subscription created in the Service Bus namespace.

```
"serviceBusSubscriptionName": {
"type": "string"
}
```
### serviceBusRuleName
The name of the rule(filter) created in the Service Bus namespace.

```
   "serviceBusRuleName": {
   "type": "string",
  }
```
### serviceBusApiVersion
The Service Bus API version of the template.

```
"serviceBusApiVersion": {
"type": "string"
}
```
## Resources to deploy
Creates a standard Service Bus namespace of type **Messaging**, with topic and subscription and rules.

```
 "resources": [{
        "apiVersion": "[variables('sbVersion')]",
        "name": "[parameters('serviceBusNamespaceName')]",
        "type": "Microsoft.ServiceBus/Namespaces",
        "location": "[variables('location')]",
        "sku": {
            "name": "Standard",
            "tier": "Standard"
        },
        "resources": [{
            "apiVersion": "[variables('sbVersion')]",
            "name": "[parameters('serviceBusTopicName')]",
            "type": "Topics",
            "dependsOn": [
                "[concat('Microsoft.ServiceBus/namespaces/', parameters('serviceBusNamespaceName'))]"
            ],
            "properties": {
                "path": "[parameters('serviceBusTopicName')]"
            },
            "resources": [{
                "apiVersion": "[variables('sbVersion')]",
                "name": "[parameters('serviceBusSubscriptionName')]",
                "type": "Subscriptions",
                "dependsOn": [
                    "[parameters('serviceBusTopicName')]"
                ],
                "properties": {},
                "resources": [{
                    "apiVersion": "[variables('sbVersion')]",
                    "name": "[parameters('serviceBusRuleName')]",
                    "type": "Rules",
                    "dependsOn": [
                        "[parameters('serviceBusSubscriptionName')]"
                    ],
                    "properties": {
                        "filter": {
                            "sqlExpression": "StoreName = 'Store1'"
                        },
                        "action": {
                            "sqlExpression": "set FilterTag = 'true'"
                        }
                    }
                }]
            }]
        }]
    }]
```

## Commands to run deployment
[AZURE.INCLUDE [app-service-deploy-commands](../../includes/app-service-deploy-commands.md)]

## PowerShell
```
New-AzureResourceGroupDeployment -Name \<deployment-name\> -ResourceGroupName \<resource-group-name\> -TemplateUri <https://raw.githubusercontent.com/azure/azure-quickstart-templates/master/201-servicebus-create-topic-subscription-rule/azuredeploy.json>
```

## Azure CLI
```
azure config mode arm

azure group deployment create \<my-resource-group\> \<my-deployment-name\> --template-uri <https://raw.githubusercontent.com/azure/azure-quickstart-templates/master/201-servicebus-create-topic-subscription-rule/azuredeploy.json>
```

## Next steps
Now that you've created and deployed resources using Azure Resource Manager, learn how to manage these resources by viewing these articles:

* [Manage Azure Service Bus using Azure Automation](/documentation/artices/service-bus-automation-manage/)
* [Manage Service Bus with PowerShell](/documentation/artices/service-bus-powershell-how-to-provision/)
* [Manage Service Bus resources with the Service Bus Explorer](https://github.com/paolosalvatori/ServiceBusExplorer/releases)

[Authoring Azure Resource Manager templates]: /documentation/artices/resource-group-authoring-templates/
[Azure Quickstart Templates]: https://azure.microsoft.com/documentation/templates/?term=service+bus
[Learn more about Service Bus topics and subscriptions]: /documentation/artices/service-bus-queues-topics-subscriptions/
[Using Azure PowerShell with Azure Resource Manager]: /documentation/artices/powershell-azure-resource-manager/
[Using the Azure CLI for Mac, Linux, and Windows with Azure Resource Management]: /documentation/artices/xplat-cli-azure-resource-manager/
[Recommended naming conventions for Azure resources]: https://azure.microsoft.com/en-us/documentation/articles/guidance-naming-conventions/
[Service Bus namespace with topic, subscription, and rule]: https://github.com/Azure/azure-quickstart-templates/blob/master/201-servicebus-create-topic-subscription-rule/
[Service Bus queues, topics, and subscriptions]:/documentation/artices/service-bus-queues-topics-subscriptions/

