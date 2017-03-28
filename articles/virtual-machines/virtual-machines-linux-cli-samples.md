<properties
    pageTitle="Azure CLI Samples | Azure"
    description="Azure CLI Samples"
    services="virtual-machines-linux"
    documentationcenter="virtual-machines"
    author="neilpeterson"
    manager="timlt"
    editor="tysonn"
    tags="azure-service-management" />
<tags
    ms.assetid=""
    ms.service="virtual-machines-linux"
    ms.devlang="na"
    ms.topic="article"
    ms.tgt_pltfrm="vm-linux"
    ms.workload="infrastructure"
    ms.date="03/08/2017"
    wacn.date=""
    ms.author="nepeters" />

# Azure CLI Samples for Linux virtual machines

The following table includes links to bash scripts built using the Azure CLI.

| | |
|---|---|
|**Create virtual machines**||
| [Create a virtual machine](/documentation/articles/virtual-machines-linux-cli-sample-create-vm-quick-create/) | Creates a Linux virtual machine with minimal configuration. |
| [Create a fully configured virtual machine](/documentation/articles/virtual-machines-linux-cli-sample-create-vm/) | Creates a resource group, virtual machine, and all related resources.|
| [Create highly available virtual machines](/documentation/articles/virtual-machines-linux-cli-sample-nlb/) | Creates several virtual machines in a highly available and load balanced configuration. |
| [Create a VM with Docker enabled](/documentation/articles/virtual-machines-linux-cli-sample-create-docker-host/) | Creates a virtual machine, configures this VM as a Docker host, and runs an NGINX container. |
| [Create a VM and run configuration script](/documentation/articles/virtual-machines-linux-cli-sample-create-vm-nginx/) | Creates a virtual machine and uses the Azure Custom Script extension to install NGINX. |
| [Create a VM with WordPress installed](/documentation/articles/virtual-machines-linux-cli-sample-create-vm-wordpress/) | Creates a virtual machine and uses the Azure Custom Script extension to install WordPress. |
|**Network virtual machines**||
| [Secure network traffic between virtual machines](/documentation/articles/virtual-machines-linux-cli-sample-create-vm-nsg/) | Creates two virtual machines, all related resources, and an internal and external network security groups (NSG). |
|**Monitor virtual machines**||
| [Monitor a VM with Operations Management Suite](/documentation/articles/virtual-machines-linux-cli-sample-create-vm-oms/) | Creates a virtual machine, installs the Operations Management Suite agent, and enrolls the VM in an OMS Workspace.  |
|**Troubleshoot virtual machines**||
| [Troubleshoot a VMs operating system disk](/documentation/articles/virtual-machines-linux-cli-sample-mount-os-disk/) | Mounts the operating system disk from one VM as a data disk on a second VM. |
| | |