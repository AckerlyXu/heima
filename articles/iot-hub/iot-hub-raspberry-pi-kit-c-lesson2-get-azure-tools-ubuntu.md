<properties
    pageTitle="Get Azure tools (Ubuntu 16.04) | Azure"
    description="Install Python and Azure command-line interface (Azure CLI) on Ubuntu."
    services="iot-hub"
    documentationcenter=""
    author="shizn"
    manager="timtl"
    tags=""
    keywords="iot cloud service, azure cli" />
<tags
    ms.assetid="a03512f2-fabe-40c5-8505-b93eef8e5bec"
    ms.service="iot-hub"
    ms.devlang="c"
    ms.topic="article"
    ms.tgt_pltfrm="na"
    ms.workload="na"
    ms.date="11/28/2016"
    wacn.date=""
    ms.author="xshi" />

# Get Azure tools (Ubuntu 16.04)
>[AZURE.SELECTOR]
[Windows 7 and later](/documentation/articles/iot-hub-raspberry-pi-kit-c-lesson2-get-azure-tools-win32/)
[Ubuntu 16.04](/documentation/articles/iot-hub-raspberry-pi-kit-c-lesson2-get-azure-tools-ubuntu/)
[macOS 10.10](/documentation/articles/iot-hub-raspberry-pi-kit-c-lesson2-get-azure-tools-mac/)

## What you will do
Install the Azure command-line interface (Azure CLI). If you have any problems, look for solutions on the [troubleshooting page](/documentation/articles/iot-hub-raspberry-pi-kit-c-troubleshooting/).

## What you will learn
In this article, you will learn:
* How to install the Azure CLI.
* How to add an IoT subgroup of the Azure CLI.

## What you need
* An Ubuntu computer with an Internet connection.
* An active Azure subscription. If you don't have an account, you can create a [trial account](/pricing/1rmb-trial/) in just a few minutes.

## Install the Azure CLI
The Azure CLI provides a multiplatform command-line experience for Azure, enabling you to work directly from your command line to provision and manage resources.

To install the latest Azure CLI, follow these steps:

1. Run the following commands in a terminal window. It might take five minutes to install the Azure CLI.

   ```bash
   sudo apt-get update
   sudo apt-get install -y libssl-dev libffi-dev
   sudo apt-get install -y python-dev
   sudo apt-get install -y build-essential
   sudo apt-get install -y python-pip
   sudo pip install --upgrade azure-cli
   sudo pip install --upgrade azure-cli-iot
   ```
2. Verify the installation by running the following command:

   ```bash
   az iot -h
   ```

You should see the following output if the installation is successful.

![Output that indicates success](./media/iot-hub-raspberry-pi-lessons/lesson2/az_iot_help_ubuntu.png)

## Summary
You've installed the Azure CLI. Your next task is to create your Azure IoT hub and device identity using the Azure CLI.

## Next steps
[Create your IoT hub and register Raspberry Pi 3](/documentation/articles/iot-hub-raspberry-pi-kit-c-lesson2-prepare-azure-iot-hub/)

