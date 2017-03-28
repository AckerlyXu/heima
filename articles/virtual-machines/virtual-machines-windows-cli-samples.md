<properties
    pageTitle="Azure CLI Samples Windows | Azure"
    description="Azure CLI Samples Windows"
    services="virtual-machines-windows"
    documentationcenter="virtual-machines"
    author="neilpeterson"
    manager="timlt"
    editor="tysonn"
    tags="azure-service-management" />
<tags
    ms.assetid=""
    ms.service="virtual-machines-windows"
    ms.devlang="na"
    ms.topic="article"
    ms.tgt_pltfrm="vm-windows"
    ms.workload="infrastructure"
    ms.date="02/27/2017"
    wacn.date=""
    ms.author="nepeters" />

# Azure CLI Samples for Windows virtual machines

The following table includes links to bash scripts built using the Azure CLI that deploy Windows virtual machines.

| | |
|---|---|
|**Create virtual machines**||
| [Create a virtual machine](/documentation/articles/virtual-machines-windows-cli-sample-create-vm-quick-create/) | Creates a Windows virtual machine with minimal configuration. |
| [Create a fully configured virtual machine](/documentation/articles/virtual-machines-windows-cli-sample-create-vm/) | Creates a resource group, virtual machine, and all related resources.|
| [Create highly available virtual machines](/documentation/articles/virtual-machines-windows-cli-sample-nlb/) | Creates several virtual machines in a highly available and load balanced configuration. |
| [Create a VM and run configuration script](/documentation/articles/virtual-machines-windows-cli-sample-create-vm-iis/) | Creates a virtual machine and uses the Azure Custom Script extension to install IIS. |
| [Create a VM and run DSC configuration](/documentation/articles/virtual-machines-windows-cli-sample-create-iis-using-dsc/) | Creates a virtual machine and uses the Azure Desired State Configuration (DSC) extension to install IIS. |
|**Network virtual machines**||
| [Secure network traffic between virtual machines](/documentation/articles/virtual-machines-windows-cli-sample-create-vm-nsg/) | Creates two virtual machines, all related resources, and an internal and external network security groups (NSG). |
|**Monitor virtual machines**||
| [Monitor a VM with Operations Management Suite](/documentation/articles/virtual-machines-windows-cli-sample-create-vm-oms/) | Creates a virtual machine, installs the Operations Management Suite agent, and enrolls the VM in an OMS Workspace.  |
| | |