## Sign in to Azure

Log in to your Azure subscription with the `Login-AzureRmAccount -EnvironmentName AzureChinaCloud` command and follow the on-screen directions.

```powershell
Login-AzureRmAccount -EnvironmentName AzureChinaCloud
```

If you don't know which location you want to use, you can list the available locations. After the list is displayed, find the one you want to use. This example will use **China East**. Store this in a variable and use the variable so you can change it in one place.

```powershell
Get-AzureRmLocation | select Location 
$location = "China East"
```

## Create a resource group

Create an Azure resource group with [New-AzureRmResourceGroup](https://docs.microsoft.com/powershell/module/azurerm.resources/new-azurermresourcegroup). A resource group is a logical container into which Azure resources are deployed and managed. 

```powershell
$resourceGroup = "myResourceGroup"
New-AzureRmResourceGroup -Name $resourceGroup -Location $location 
```

## Create a storage account

Create a standard general-purpose storage account with LRS replication using [New-AzureRmStorageAccount](https://docs.microsoft.com/powershell/module/azurerm.storage/New-AzureRmStorageAccount), then retrieve the storage account context that defines the storage account to be used. When acting on a storage account, you reference the context instead of repeatedly providing the credentials. This example creates a storage account called *mystorageaccount* with locally redundant storage and blob encryption enabled.

```powershell
$storageAccount = New-AzureRmStorageAccount -ResourceGroupName $resourceGroup `
  -Name "mystorageaccount" `
  -Location $location `
  -SkuName Standard_LRS `
  -Kind Storage `
  -EnableEncryptionService Blob

$ctx = $storageAccount.Context
```
