---
title: Create an Azure Service Fabric container application on Linux | Azure
description: In this quickstart, you create your first Linux container application on Azure Service Fabric.  Build a Docker image with your application, push the image to a container registry, build and deploy a Service Fabric container application.
services: service-fabric
documentationcenter: linux
author: rockboyfor
manager: digimobile
editor: ''

ms.assetid: 
ms.service: service-fabric
ms.devlang: python
ms.topic: quickstart
ms.tgt_pltfrm: NA
ms.workload: NA
origin.date: 04/11/2018
ms.date: 04/30/2018
ms.author: v-yeche
ms.custom: mvc

---

# Quickstart: deploy an Azure Service Fabric Linux container application on Azure
Azure Service Fabric is a distributed systems platform for deploying and managing scalable and reliable microservices and containers. 

This quickstart shows how to deploy Linux containers to a Service Fabric cluster. Once complete, you have a voting application consisting of a Python web front end and a Redis back end running in a Service Fabric cluster. You also learn how to fail over an application and how to scale an application in your cluster.

![Voting app web page][quickstartpic]

In this quickstart, you use the Bash environment in local Shell to run Service Fabric CLI commands. If you don't have an Azure subscription, create a [trial account](https://www.azure.cn/pricing/1rmb-trial/) before you begin.

[!INCLUDE [azure-cli-2-azurechinacloud-environment-parameter](../../includes/azure-cli-2-azurechinacloud-environment-parameter.md)]

## Get the application package
To deploy containers to Service Fabric, you need a set of manifest files (the application definition), which describe the individual containers and the application.

In the local shell, use git to clone a copy of the application definition; then change directories to the `Voting` directory in your clone.

```bash
git clone https://github.com/Azure-Samples/service-fabric-containers.git

cd service-fabric-containers/Linux/container-tutorial/Voting
```

## Create a Service Fabric cluster
To deploy the application to Azure, you need a Service Fabric cluster to run the application. The cluster uses a single, self-signed certificate for node-to-node and client-to-node security.

<!-- Not Avaiable on Party cluster content -->

For information about creating your own cluster, see [Create a Service Fabric cluster on Azure](service-fabric-tutorial-create-vnet-and-linux-cluster.md).

> [!Note]
>If you do create your own cluster, note that the web front end service is configured to listen on port 80 for incoming traffic. Make sure that port is open in your cluster.
>

## Configure your environment
Service Fabric provides several tools that you can use to manage a cluster and its applications:

- Service Fabric Explorer, a browser-based tool.
- Service Fabric Command Line Interface (CLI), which runs on top of Azure CLI 2.0.
- PowerShell commands. 

In this quickstart, you use the Service Fabric Explorer.

<!-- Not Available on ### Configure certificate for the Service Fabric CLI -->

## Deploy the Service Fabric application 
1. In local Shell, connect to the Service Fabric cluster in Azure using the CLI.

```bash
sfctl cluster select --endpoint https://linh1x87d1d.chinanorth.cloudapp.chinacloudapi.cn:19080 --pem party-cluster-1277863181-client-cert.pem --no-verify
```


2. Use the install script to copy the Voting application definition to the cluster, register the application type, and create an instance of the application.

    ```bash
    ./install.sh
    ```

2. Open a web browser and navigate to the Service Fabric Explorer endpoint for your cluster. The endpoint has the following format:  https://\<my-azure-service-fabric-cluster-url>:19080/Explorer; for example, `https://linh1x87d1d.chinanorth.cloudapp.chinacloudapi.cn:19080/Explorer`. </br>

3. Expand the **Applications** node to see that there is now an entry for the Voting application type and the instance you created.

    ![Service Fabric Explorer][sfx]

3. To connect to the running container, open a web browser and navigate to the URL of your cluster; for example, `http://linh1x87d1d.chinanorth.cloudapp.chinacloudapi.cn:80`. You should see the Voting application in the browser.

    ![Voting app web page][quickstartpic]

> [!NOTE]
> You can also deploy Service Fabric applications with Docker compose. For example, the following command could be used to deploy and install the application on the cluster using Docker Compose.
>  ```bash
> sfctl compose create --deployment-name TestApp --file-path ../docker-compose.yml
> ```

## Fail over a container in a cluster
Service Fabric makes sure that your container instances automatically move to other nodes in the cluster if a failure occurs. You can also manually drain a node for containers and move then gracefully to other nodes in the cluster. Service Fabric provides several ways to scale your services. In the following steps, you use Service Fabric Explorer.

To fail over the front-end container, do the following steps:

1. Open Service Fabric Explorer in your cluster; for example, `https://linh1x87d1d.chinanorth.cloudapp.chinacloudapi.cn:19080/Explorer`.
2. Click the **fabric:/Voting/azurevotefront** node in the tree view and expand the partition node (represented by a GUID). Notice the node name in the treeview, which shows you the nodes that the container is currently running on; for example, `_nodetype_4`.
3. Expand the **Nodes** node in the tree view. Click the ellipsis (...) next to the node that is running the container.
4. Choose **Restart** to restart that node and confirm the restart action. The restart causes the container to fail over to another node in the cluster.

    ![Node view in Service Fabric Explorer][sfxquickstartshownodetype]

## Scale applications and services in a cluster
Service Fabric services can easily be scaled across a cluster to accommodate for the load on the services. You scale a service by changing the number of instances running in the cluster.

To scale the web front-end service, do the following steps:

1. Open Service Fabric Explorer in your cluster; for example,`https://linh1x87d1d.chinanorth.cloudapp.chinacloudapi.cn:19080`.
2. Click the ellipsis (three dots) next to the **fabric:/Voting/azurevotefront** node in the treeview and choose **Scale Service**.

    ![Service Fabric Explorer scale service start][containersquickstartscale]

  You can now choose to scale the number of instances of the web front-end service.

3. Change the number to **2** and click **Scale Service**.
4. Click the **fabric:/Voting/azurevotefront** node in the tree-view and expand the partition node (represented by a GUID).

    ![Service Fabric Explorer scale service finished][containersquickstartscaledone]

    You can now see that the service has two instances. In the tree view, you can see which nodes the instances run on.

Through this simple management task, you've doubled the resources available for the front-end service to process user load. It's important to understand that you don't need multiple instances of a service for it to run reliably. If a service fails, Service Fabric makes sure that a new service instance runs in the cluster.

## Clean up resources
1. Use the uninstall script (uninstall.sh) provided in the template to delete the application instance from the cluster and unregister the application type. This script takes some time to clean up the instance, so you should not run the install script immediately after this script. You can use Service Fabric Explorer to determine when the instance has been removed and the application type unregistered. 

```bash
./uninstall.sh
```

2. If you are finished working with your cluster, you can remove the certificate from your certificate store. For example:
   - On Windows: Use the [Certificates MMC snap-in](https://docs.microsoft.com/dotnet/framework/wcf/feature-details/how-to-view-certificates-with-the-mmc-snap-in?view=azure-dotnet). Be sure to select **My user account** when adding the snap-in. Navigate to `Certificates - Current User\Personal\Certificates` and remove the certificate.
   - On Mac: Use the Keychain app.
   - On Ubuntu: Follow the steps you used to view certificates and remove the certificate.
## Next steps

<!-- Not Availabel on [Create a Linux container app](./service-fabric-tutorial-create-container-images.md)-->

[sfx]: ./media/service-fabric-quickstart-containers-linux/containersquickstartappinstance.png
[quickstartpic]: ./media/service-fabric-quickstart-containers-linux/votingapp.png
[sfxquickstartshownodetype]:  ./media/service-fabric-quickstart-containers-linux/containersquickstartrestart.png
[containersquickstartscale]: ./media/service-fabric-quickstart-containers-linux/containersquickstartscale.png
[containersquickstartscaledone]: ./media/service-fabric-quickstart-containers-linux/containersquickstartscaledone.png

<!--Update_Description: update meta properties, wording update -->