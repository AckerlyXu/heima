---
 title: include file
 description: include file
 services: virtual-machines
 author: rockboyfor
 ms.service: virtual-machines
 ms.topic: include
 origin.date: 03/09/2018
 ms.date: 04/16/2018
 ms.author: v-yeche
 ms.custom: include file
---

Some database workloads like SQL Server or Oracle require high memory, storage, and I/O bandwidth, but not a high core count. Many database workloads are not CPU-intensive. Azure offers certain VM sizes where you can constrain the VM vCPU count to reduce the cost of software licensing, while maintaining the same memory, storage, and I/O bandwidth.

The vCPU count can be  constrained to one half or one quarter of the original VM size. These new VM sizes have a suffix that specifies the number of active vCPUs to make them easier for you to identify.
<!-- Not Available on GS series -->

The licensing fees charged for SQL Server or Oracle are constrained to the new vCPU count, and other products should be charged based on the new vCPU count. This results in a 50% to 75% increase in the ratio of the VM specs to active (billable) vCPUs. These new VM sizes that are only available in Azure, allowing workloads to push higher CPU utilization at a fraction of the (per-core) licensing cost. At this time, the compute cost, which includes OS licensing, remains the same one as the original size. For more information, see [Azure VM sizes for more cost-effective database workloads](https://azure.microsoft.com/blog/announcing-new-azure-vm-sizes-for-more-cost-effective-database-workloads/).

| Name                | vCPU | Specs           |
|---------------------|------|-----------------|
<!-- Not Available on| Standard_DS11-1_v2  | 1    | Same as DS11_v2 |-->
<!-- Not Available on| Standard_DS12-2_v2  | 2    | Same as DS12_v2 |-->
<!-- Not Available on| Standard_DS12-1_v2  | 1    | Same as DS12_v2 |-->
| Standard_DS13-4_v2  | 4    | Same as DS13_v2 |
| Standard_DS13-2_v2  | 2    | Same as DS13_v2 |
| Standard_DS14-8_v2  | 8    | Same as DS14_v2 |
| Standard_DS14-4_v2  | 4    | Same as DS14_v2 |
<!-- Not Available on Standard M, E, GS seriese -->
<!-- Update_Description: wording update-->