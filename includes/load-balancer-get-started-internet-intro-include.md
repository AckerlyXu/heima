An Azure load balancer is a Layer-4 (TCP, UDP) load balancer. The load balancer provides high availability by distributing incoming traffic among healthy service instances in cloud services or virtual machines in a load balancer set. Azure Load Balancer can also present those services on multiple ports, multiple IP addresses, or both.

You can configure a load balancer to:

* Load balance incoming Internet traffic to virtual machines (VMs). We refer to a load balancer in this scenario as an [Internet-facing load balancer](/documentation/articles/load-balancer-internet-overview/).
* Load balance traffic between VMs in a virtual network (VNet), between VMs in cloud services, or between on-premises computers and VMs in a cross-premises virtual network. We refer to a load balancer in this scenario as an [internal load balancer (ILB)](/documentation/articles/load-balancer-internal-overview/).
* Forward external traffic to a specific VM instance.