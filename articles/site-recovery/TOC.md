# Overview
## [What is Site Recovery?](site-recovery-overview.md)
## How does Site Recovery work?
### [Azure to Azure architecture](site-recovery-azure-to-azure-architecture.md)
### [Hyper-V to Azure architecture](site-recovery-architecture-hyper-v-to-azure.md)
### [Replication to a secondary site architecture](site-recovery-architecture-to-secondary-site.md)
## [What workloads can you protect?](site-recovery-workload.md)
## Site Recovery support matrix
### [Azure to Azure support](site-recovery-support-matrix-azure-to-azure.md)
### [On-premises to Azure support](site-recovery-support-matrix-to-azure.md)
### [On-premises to secondary site support](site-recovery-support-matrix-to-sec-site.md)
## [FAQ](site-recovery-faq.md)

# Get Started
## [Replicate Hyper-V VMs to Azure](hyper-v-site-walkthrough-overview.md)
### [Step 1: Review the architecture](hyper-v-site-walkthrough-architecture.md)
### [Step 2: Review prerequisites and limitations](hyper-v-site-walkthrough-prerequisites.md)
### [Step 3: Plan capacity](hyper-v-site-walkthrough-capacity.md)
### [Step 4: Plan networking](hyper-v-site-walkthrough-network.md)
### [Step 5: Prepare Azure](hyper-v-site-walkthrough-prepare-azure.md)
### [Step 6: Prepare Hyper-V hosts](hyper-v-site-walkthrough-prepare-hyper-v.md)
### [Step 7: Create a vault](hyper-v-site-walkthrough-create-vault.md)
### [Step 8: Set up the source and target](hyper-v-site-walkthrough-source-target.md)
### [Step 9: Create a replication policy](hyper-v-site-walkthrough-replication.md)
### [Step 10: Enable replication](hyper-v-site-walkthrough-enable-replication.md)
### [Step 11: Run a test failover](hyper-v-site-walkthrough-test-failover.md)
## [Replicate Hyper-V VMs to Azure (with VMM)](site-recovery-vmm-to-azure.md)
## [Replicate physical servers to Azure](physical-walkthrough-overview.md)
### [Step 1: Review the architecture](physical-walkthrough-architecture.md)
### [Step 2: Review prerequisites and limitations](physical-walkthrough-prerequisites.md)
### [Step 3: Plan capacity](physical-walkthrough-capacity.md)
### [Step 4: Plan networking](physical-walkthrough-network.md)
### [Step 5: Prepare Azure](physical-walkthrough-prepare-azure.md)
### [Step 6: Create a vault](physical-walkthrough-create-vault.md)
### [Step 7: Set up the source and target](physical-walkthrough-source-target.md)
### [Step 8: Create a replication policy](physical-walkthrough-replication.md)
### [Step 9: Install the Mobility service](physical-walkthrough-install-mobility.md)
### [Step 10: Enable replication](physical-walkthrough-enable-replication.md)
### [Step 11: Run a test failover](physical-walkthrough-test-failover.md)
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
## Configure


#### [Deploy the Mobility service with System Center Configuration Manager](site-recovery-install-mobility-service-using-sccm.md)
#### [Deploy the Mobility service with Azure Automation DSC](site-recovery-automate-mobility-service-install.md)
## Fail over and fail back
### [Set up recovery plans](site-recovery-create-recovery-plans.md)
#### [Add Azure runbooks to recovery plans](site-recovery-runbook-automation.md)
### Run a test failover
#### [Run a test failover to Azure](site-recovery-test-failover-to-azure.md)
#### [Run a test failover between VMM clouds](site-recovery-test-failover-vmm-to-vmm.md)
### [Fail over protected machines](site-recovery-failover.md)

### Fail back from Azure
#### [Fail back from Azure to Hyper-V](site-recovery-failback-from-azure-to-hyper-v.md)
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
### [Delete Recovery Services vault](delete-vault.md)
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

## [Blog](http://azure.microsoft.com/blog/tag/azure-site-recovery/)
## [Forum](https://social.msdn.microsoft.com/Forums/azure/en-US/home?forum=hypervrecovmgr)
## [Pricing](https://www.azure.cn/pricing/details/site-recovery/)
