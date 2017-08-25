## Create a resource group

Create a resource group with the [az group create](https://docs.microsoft.com/cli/azure/group#create) command. An Azure resource group is a logical container into which Azure resources are deployed and managed. 

The following example creates a resource group named *myResourceGroup* in the *China North* location.

```cli
az group create --name myResourceGroup --location "China North"
```

## Create a virtual machine

Create a VM with the [az vm create](https://docs.microsoft.com/cli/azure/vm#create) command. 

The following example creates a VM named *myVM* and creates SSH keys if they do not already exist in a default key location. To use a specific set of keys, use the `--ssh-key-value` option.  

```cli
az vm create \
    --resource-group myResourceGroup \
    --name myVM \
    --image UbuntuLTS \
    --admin-username azureuser \
    --generate-ssh-keys
```

When the VM has been created, the Azure CLI shows information similar to the following example. Take note of the `publicIpAddress`. This address is used to access the VM.

```cli
{
  "fqdns": "",
  "id": "/subscriptions/<subscription ID>/resourceGroups/myResourceGroup/providers/Microsoft.Compute/virtualMachines/myVM",
  "location": "China North",
  "macAddress": "00-0D-3A-23-9A-49",
  "powerState": "VM running",
  "privateIpAddress": "10.0.0.4",
  "publicIpAddress": "40.68.254.142",
  "resourceGroup": "myResourceGroup"
}
```



## Open port 80 for web traffic 

By default, only SSH connections are allowed into Linux VMs deployed in Azure. Because this VM is going to be a web server, you need to open port 80 from the internet. Use the [az vm open-port](https://docs.microsoft.com/cli/azure/vm#open-port) command to open the desired port.  
 
```cli
az vm open-port --port 80 --resource-group myResourceGroup --name myVM
```
## SSH into your VM


If you don't already know the public IP address of your VM, run the [az network public-ip list](https://docs.microsoft.com/cli/azure/network/public-ip#list) command:


```cli
az network public-ip list --resource-group myResourceGroup --query [].ipAddress
```

Use the following command to create an SSH session with the virtual machine. Substitute the correct public IP address of your virtual machine. In this example, the IP address is *40.68.254.142*.

```bash
ssh azureuser@40.68.254.142
```

