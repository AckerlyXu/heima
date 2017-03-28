<!-- not suitable for Mooncake -->

<properties
    pageTitle="Join a RedHat Linux VM to an Azure Active Directory DS | Azure"
    description="How to join an existing RedHat Enterprise Linux 7 VM to an Azure Active Directory Domain Service."
    services="virtual-machines-linux"
    documentationcenter="virtual-machines-linux"
    author="vlivech"
    manager="timlt"
    editor="" />
<tags
    ms.assetid=""
    ms.service="virtual-machines-linux"
    ms.devlang="NA"
    ms.topic="article"
    ms.tgt_pltfrm="vm-linux"
    ms.workload="infrastructure"
    ms.date="12/14/2016"
    wacn.date=""
    ms.author="v-livech" />

# Join a RedHat Linux VM to an Azure Active Directory Domain Service

This article shows you how to join a Red Hat Enterprise Linux (RHEL) 7 virtual machine to an Azure Active Directory Domain Services (AADDS) managed domain.  The requirements are:

- [an Azure account](/pricing/1rmb-trial/)

- [SSH public and private key files](/documentation/articles/virtual-machines-linux-mac-create-ssh-keys/)

- [an Azure Active Directory Domain Services DC](/documentation/articles/active-directory-ds-getting-started/)

## Quick Commands

_Replace any examples with your own settings._

### Switch the azure-cli to classic deployment mode

    azure config mode asm

### Search for a RHEL version and image

    azure vm image list | grep "Red Hat"

### Create a Redhat Linux VM

    azure vm create myVM \
    -o a879bbefc56a43abb0ce65052aac09f3__RHEL_7_2_Standard_Azure_RHUI-20161026220742 \
    -g ahmet \
    -p myPassword \
    -e 22 \
    -t "~/.ssh/id_rsa.pub" \
    -z "Small" \
    -l "China North"

### SSH to the VM

    ssh -i ~/.ssh/id_rsa ahmet@myVM

### Update YUM packages

    sudo yum update

### Install packages needed

    sudo yum -y install realmd sssd krb5-workstation krb5-libs

Now that the required packages are installed on the Linux virtual machine, the next task is to join the virtual machine to the managed domain.

### Discover the AAD Domain Services managed domain

    sudo realm discover mydomain.com

### Initialize kerberos

Ensure that you specify a user who belongs to the 'AAD DC Administrators' group. Only these users can join computers to the managed domain.

    kinit ahmet@mydomain.com

### Join the machine to the domain

    sudo realm join --verbose mydomain.com -U 'ahmet@mydomain.com'

### Verify the machine is joined to the domain

    ssh -l ahmet@mydomain.com mydomain.chinacloudapp.cn

## Next Steps

* [Red Hat Update Infrastructure (RHUI) for on-demand Red Hat Enterprise Linux VMs in Azure](/documentation/articles/virtual-machines-linux-update-infrastructure-redhat/)
* [Set up Key Vault for virtual machines in Azure Resource Manager](/documentation/articles/virtual-machines-linux-key-vault-setup/)
* [Deploy and manage virtual machines by using Azure Resource Manager templates and the Azure CLI](/documentation/articles/virtual-machines-linux-cli-deploy-templates/)