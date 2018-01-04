Geo-redundant storage (GRS) is designed to provide at least 99.99999999999999% (16 9's) durability of objects over a given year by replicating your data to a secondary region that is hundreds of miles away from the primary region. If your storage account has GRS enabled, then your data is durable even in the case of a complete regional outage or a disaster in which the primary region is not recoverable.

For a storage account with GRS enabled, an update is first committed to the primary region. Then the update is replicated asynchronously to the secondary region, where it is also replicated.

With GRS, both the primary and secondary regions manage replicas across separate fault domains and upgrade domains within a storage scale unit as described with LRS.

Considerations:

* Since asynchronous replication involves a delay, in the event of a regional disaster it is possible that changes that have not yet been replicated to the secondary region will be lost if the data cannot be recovered from the primary region.
* The replica is not available unless 21Vianet initiates failover to the secondary region. If 21Vianet does initiate a failover to the secondary region, you will have read and write access to that data after the failover has completed. For more information, please see [Disaster Recovery Guidance](../articles/storage/common/storage-disaster-recovery-guidance.md). 
* If an application wants to read from the secondary region, the user should enable RA-GRS.

When you create a storage account, you select the primary region for the account. The secondary region is determined based on the primary region, and cannot be changed. The following table shows the primary and secondary region pairings.

| Primary | Secondary |
| --- | --- |
| East China | North China |
| North China | East China |
