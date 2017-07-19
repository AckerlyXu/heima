# Overview
## [What is Site Recovery?](site-recovery-overview.md)
## How does Site Recovery work?
### [Azure to Azure architecture](site-recovery-azure-to-azure-architecture.md)
### [Replication to a secondary site architecture](site-recovery-architecture-to-secondary-site.md)
## [What workloads can you protect?](site-recovery-workload.md)
## Site Recovery support matrix
### [Azure to Azure support](site-recovery-support-matrix-azure-to-azure.md)
### [On-premises to Azure support](site-recovery-support-matrix-to-azure.md)
### [On-premises to secondary site support](site-recovery-support-matrix-to-sec-site.md)
## [FAQ](site-recovery-faq.md)

# Get Started
## [Replicate Hyper-V VMs to Azure (with VMM)](site-recovery-vmm-to-azure.md)
## [Replicate Hyper-V VMs to Azure](site-recovery-hyper-v-site-to-azure.md)
## [Replicate Hyper-V VMs to a secondary site (with VMM)](site-recovery-vmm-to-vmm.md)


# How To
## Plan
### [Prerequisites for Azure replication](site-recovery-azure-to-azure-prereq.md)
### Plan networking
#### [Plan networking for Azure to Azure replication (preview)](site-recovery-azure-to-azure-networking-guidance.md)
#### [Plan networking for on-premises machine replication](site-recovery-network-design.md)
#### [Plan network mapping for Hyper-V VM replication](site-recovery-network-mapping.md)
### Plan capacity and scalability
#### [Capacity Planner for Hyper-V replication](site-recovery-capacity-planner.md)
### [Plan role-based access for VM replication](site-recovery-role-based-linked-access-control.md)
## Deploy


## Fail over and fail back
### [Set up recovery plans](site-recovery-create-recovery-plans.md)
#### [Add Azure runbooks to recovery plans](site-recovery-runbook-automation.md)
### Run a test failover
#### [Run a test failover to Azure](site-recovery-test-failover-to-azure.md)
#### [Run a test failover between VMM clouds](site-recovery-test-failover-vmm-to-vmm.md)
### [Fail over protected machines](site-recovery-failover.md)

### Fail back from Azure
## Migrate
### [Migrate to Azure](site-recovery-migrate-to-azure.md)
### [Migrate between Azure regions](site-recovery-migrate-azure-to-azure.md)
### [Migrate AWS Windows instances to Azure](site-recovery-migrate-aws-to-azure.md)
## Workloads
### [Active Directory and DNS](site-recovery-active-directory.md)
### [Replicate SQL Server](site-recovery-sql.md)
### [RDS](site-recovery-workload.md#protect-rds)
### [Exchange](site-recovery-workload.md#protect-exchange)
### [SAP](site-recovery-workload.md#protect-sap)
### [Other workloads](site-recovery-workload.md#workload-summary)
## Automate replication
### [Automate Hyper-V replication to Azure (no VMM)](site-recovery-deploy-with-powershell-resource-manager.md)
### [Automate Hyper-V replication to Azure (with VMM)](site-recovery-vmm-to-azure-powershell-resource-manager.md)
### [Automate Hyper-V replication to a secondary site (with VMM)](site-recovery-vmm-to-vmm-powershell-resource-manager.md)
## Manage

### [Remove servers and disable protection](site-recovery-manage-registration-and-protection.md)
## Monitor and troubleshoot
### [Azure to Azure replication issues](site-recovery-azure-to-azure-troubleshoot-errors.md)
### [Collect logs and troubleshoot on-premises issues](site-recovery-monitoring-and-troubleshooting.md)

# Reference
## [PowerShell](https://docs.microsoft.com/zh-cn/powershell/module/azurerm.siterecovery)
## [PowerShell classic](https://docs.microsoft.com/zh-cn/powershell/module/azure/?view=azuresmps-3.7.0)
## [REST](https://msdn.microsoft.com/zh-cn/library/mt750497)

# Related
## [Azure Automation](https://docs.azure.cn/zh-cn/automation/)

# Resources
## [Forum](https://social.msdn.microsoft.com/Forums/en-US/home?forum=hypervrecovmgr)
## [Blog](http://azure.microsoft.com/blog/tag/azure-site-recovery/)
## [Pricing](https://www.azure.cn/pricing/details/site-recovery/)
