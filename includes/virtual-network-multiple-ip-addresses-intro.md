> [AZURE.SELECTOR]
- [Portal](/documentation/articles/virtual-network-multiple-ip-addresses-portal/)
- [PowerShell](/documentation/articles/virtual-network-multiple-ip-addresses-powershell/)
- [CLI 2.0](/documentation/articles/virtual-network-multiple-ip-addresses-cli/)
- [CLI 1.0](/documentation/articles/virtual-network-multiple-ip-addresses-cli-nodejs/)
- [Template](/documentation/articles/virtual-network-multiple-ip-addresses-template/)

An Azure Virtual Machine (VM) has one or more network interfaces (NIC) attached to it. Any NIC can have one or more static or dynamic public and private IP addresses assigned to it. Assigning multiple IP addresses to a VM enables the following capabilities:

* Hosting multiple websites or services with different IP addresses and SSL certificates on a single server.
* Serve as a network virtual appliance, such as a firewall or load balancer.
* The ability to add any of the private IP addresses for any of the NICs to an Azure Load Balancer back-end pool. In the past, only the primary IP address for the primary NIC could be added to a back-end pool. To learn more about how to load balance multiple IP configurations, read the [Load balancing multiple IP configurations](/documentation/articles/load-balancer-multiple-ip/) article.

Every NIC attached to a VM has one or more IP configurations associated to it. Each configuration is assigned one static or dynamic private IP address. Each configuration may also have one public IP address resource associated to it. A public IP address resource has either a dynamic or static public IP address assigned to it. To learn more about IP addresses in Azure, read the [IP addresses in Azure](/documentation/articles/virtual-network-ip-addresses-overview-arm/) article. You can assign up to 250 private IP addresses to each NIC. While you can assign multiple public IP addresses to each NIC, there are limits to how many public IP addresses that can be used in an Azure subscription. See the [Azure limits](/documentation/articles/azure-subscription-service-limits/#networking-limits) article for details.