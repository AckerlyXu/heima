---
 title: include file
 description: include file
 services: azure-resource-manager
 author: rockboyfor
 manager: digimobile
 ms.service: azure-resource-manager
 ms.topic: include
 origin.date: 02/20/2018
 ms.date: 03/26/2018
 ms.author: v-yeche
 ms.custom: include file
---

To add two tags to a resource group, use the [az group update](https://docs.microsoft.com/cli/azure/group#az_group_update) command:

```azurecli
az group update -n myResourceGroup --set tags.Environment=Test tags.Dept=IT
```

Let's suppose you want to add a third tag. Run the command again with the new tag. It is appended to the existing tags.

```azurecli
az group update -n myResourceGroup --set tags.Project=Documentation
```

Resources don't inherit tags from the resource group. Currently, your resource group has three tags but the resources do not have any tags. To apply all tags from a resource group to its resources, and retain existing tags on resources, use the following script:

```azurecli
# Get the tags for the resource group
jsontag=$(az group show -n myResourceGroup --query tags)

# Reformat from JSON to space-delimited and equals sign
t=$(echo $jsontag | tr -d '"{},' | sed 's/: /=/g')

# Get the resource IDs for all resources in the resource group
r=$(az resource list -g myResourceGroup --query [].id --output tsv)

# Loop through each resource ID
for resid in $r
do
  # Get the tags for this resource
  jsonrtag=$(az resource show --id $resid --query tags)

  # Reformat from JSON to space-delimited and equals sign
  rt=$(echo $jsonrtag | tr -d '"{},' | sed 's/: /=/g')

  # Reapply the updated tags to this resource
  az resource tag --tags $t$rt --id $resid
done
```

Alternatively, you can apply tags from the resource group to the resources without keeping the existing tags:

```azurecli
# Get the tags for the resource group
jsontag=$(az group show -n myResourceGroup --query tags)

# Reformat from JSON to space-delimited and equals sign
t=$(echo $jsontag | tr -d '"{},' | sed 's/: /=/g')

# Get the resource IDs for all resources in the resource group
r=$(az resource list -g myResourceGroup --query [].id --output tsv)

# Loop through each resource ID
for resid in $r
do
  # Apply tags from resource group to this resource
  az resource tag --tags $t --id $resid
done
```

To combine several values in a single tag, use a JSON string.

```azurecli
az group update -n myResourceGroup --set tags.CostCenter='{"Dept":"IT","Environment":"Test"}'
```

To remove all tags on a resource group, use:

```azurecli
az group update -n myResourceGroup --remove tags
```
<!--ms.date: 03/26/2018-->