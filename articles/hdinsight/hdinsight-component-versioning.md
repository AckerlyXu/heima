---
title: Hadoop components and versions - Azure HDInsight | Azure
description: Learn the Hadoop components and versions in HDInsight and the service levels available in this cloud distribution of Hortonworks Data Platform.
keywords: hadoop versions,hadoop ecosystem components,hadoop components,how to check hadoop version
services: hdinsight
editor: cgronlun
manager: asadk
author: bprakash
tags: azure-portal
documentationcenter: ''

ms.assetid: 367b3f4a-f7d3-4e59-abd0-5dc59576f1ff
ms.service: hdinsight
ms.custom: hdinsightactive,hdiseo17may2017
ms.workload: big-data
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: article
origin.date: 04/14/2017
ms.date: 09/18/2017
ms.author: v-haiqya

---
# What are the Hadoop components and versions available with HDInsight?

Learn about the Hadoop ecosystem components and versions in Azure HDInsight. Also, learn how to check Hadoop component versions in HDInsight. 

[!INCLUDE [hdinsight-linux-acn-version.md](../../includes/hdinsight-linux-acn-version.md)]

Each HDInsight version is a cloud distribution of a version of Hortonworks Data Platform (HDP).

## Hadoop components available with different HDInsight versions
Azure HDInsight supports multiple Hadoop cluster versions that can be deployed at any time. Each version choice creates a specific version of the HDP distribution and a set of components that are contained within that distribution. As of February 17, 2017, the default cluster version used by Azure HDInsight is 3.5 and is based on HDP 2.5.

The component versions associated with HDInsight cluster versions are listed in the following table. 

> [!NOTE]
> The default version for the HDInsight service might change without notice. If you have a version dependency, specify the HDInsight version when you create your clusters with the .NET SDK with Azure PowerShell and Azure CLI.

| Component | HDInsight 3.6 (default) | HDInsight 3.5 |HDInsight 3.3 | HDInsight 3.2 | HDInsight 3.1 | HDInsight 3.0 |
| --- | --- | --- | --- | --- | --- | --- |
| Hortonworks Data Platform |2.6 |2.5 |2.3 |2.2 |2.1.7 |2.0 |
| Apache Hadoop and YARN |2.7.3 |2.7.3 |2.7.1 |2.6.0 |2.4.0 |2.2.0 |
| Apache Tez |0.7.0 |0.7.0 |0.7.0 |0.5.2 |0.4.0 |-|
| Apache Pig |0.16.0 |0.16.0 |0.15.0 |0.14.0 |0.12.1 |0.12.0 |
| Apache Hive and HCatalog |1.2.1 |1.2.1 |1.2.1 |0.14.0 |0.13.1 |0.12.0 |
| Apache Hive2 | 2.1.0 |-|-|-|-|-|
| Apache Tez Hive2 | 0.8.4 |-|-|-|-|-|
| Apache Ranger | 0.7.0 |0.6.0 |-|-|-|
| Apache HBase |1.1.2 |1.1.2 |0.98.4 |0.98.0 |-|
| Apache Sqoop |1.4.6 |1.4.6 |1.4.5 |1.4.4 |1.4.4 |
| Apache Oozie |4.2.0 |4.2.0 |4.1.0 |4.0.0 |4.0.0 |
| Apache Zookeeper |3.4.6 |3.4.6 |3.4.6 |3.4.5 |3.4.5 |
| Apache Storm |1.1.0 |1.0.1 |0.9.3 |0.9.1 |-|
| Apache Mahout |0.9.0+ |0.9.0+ |0.9.0 |0.9.0 |-|
| Apache Phoenix |4.7.0 |4.7.0 |4.2.0 |4.0.0.2.1.7.0-2162 |-|
| Apache Spark |2.1.0 (Linux only) |1.6.2 + 2.0 (Linux only) |1.3.1 (Windows-only) |-|-|
| Apache Ambari | 2.5.0 | 2.4.0 |-|-|-|
| Apache Zeppelin | 0.7.0 |-|-|-|-|
| Mono |4.2.1 |4.2.1 |-|-|-|

## Check for current Hadoop component version information

The Hadoop ecosystem component versions associated with HDInsight cluster versions can change with updates to HDInsight. To check the Hadoop components and to verify which versions are being used for a cluster, use the Ambari REST API. The **GetComponentInformation** command retrieves information about service components. For details, see the [Ambari documentation][ambari-docs].

For Windows clusters, another way to check the component version is to log in to a cluster by using Remote Desktop and examine the contents of the C:\apps\dist\ directory.

> [!IMPORTANT]
> Linux is the only operating system used on HDInsight version 3.4 or later. For more information, see [Windows retirement on HDInsight](#hdinsight-windows-retirement).

### Release notes

See [HDInsight release notes](hdinsight-release-notes.md) for additional release notes on the latest versions of HDInsight.

## Supported HDInsight versions
The following table lists the versions of HDInsight that are currently available on the Azure portal. The HDP versions that correspond to each HDInsight version are listed along with the product release dates. The support expiration and retirement dates are also provided, when they're known.

* Highly available clusters with two head nodes are deployed by default for HDInsight 2.1 and above. They are not available for HDInsight 1.6 clusters.
* Once the support has expired for a particular version, it may not be available through the Azure portal. The following table indicates which versions are available on the Azure Classic Management Portal. Cluster versions  continue to be available using the `Version` parameter in the Windows PowerShell [New-AzureRmHDInsightCluster](https://msdn.microsoft.com/library/mt619331.aspx) command and the .NET SDK until its retirement date.

| HDInsight Version | HDP Version | VM OS | High Availability | Available on Azure portal |
| --- | --- | --- | --- | --- |
| HDI 3.6 |HDP 2.6 |Ubuntu 16 |Yes |Yes |
| HDI 3.5 |HDP 2.5 |Ubuntu 16 |Yes |Yes |
| HDI 3.3 |HDP 2.3 |Windows Server 2012R2 |Yes |Yes |
| HDI 3.2 |HDP 2.2 |Windows Server 2012R2 |Yes |No |
| HDI 3.1 |HDP 2.1 |Windows Server 2012R2 |Yes |No |
| HDI 3.0 |HDP 2.0 |Windows Server 2012R2 |Yes |No |
| HDI 2.1 |HDP 1.3 |Windows Server 2012R2 |Yes |No |
| HDI 1.6 |HDP 1.1 | |No |No |

## HDInsight Windows retirement
Azure HDInsight version 3.3 was the last version of HDInsight on Windows. The retirement date for HDInsight on Windows is July 31, 2018. If you have any HDInsight clusters on Windows 3.3 or earlier, you must migrate to HDInsight on Linux (HDInsight version 3.5 or later) before July 31, 2018. Migrating to the Linux OS enables you to retain the ability to create or resize your HDInsight clusters. Support for HDInsight version 3.3 on Windows expired on June 27, 2016.

Starting with HDInsight version 3.4, Microsoft has released HDInsight only on the Linux OS. As a result, some of the components within HDInsight are available for Linux only. These include Apache Ranger, Kafka, Interactive Hive, Spark and HDInsight applications. Future releases of HDInsight are available only on the Linux OS. There will be no future releases of HDInsight on Windows. 

## FAQs

### What is the timeline for retiring HDInsight on Windows?
July 31, 2018, is the retirement date for HDInsight on Windows. If the planned retirement date is different for your region, you will be notified separately. 

### What is the impact of retiring HDInsight on Windows for existing customers?
After HDInsight on Windows is retired, you can't create a new HDInsight Windows cluster, or resize an existing HDInsight Windows cluster. Support for HDInsight version 3.3 expired on June 27, 2016. Therefore, there is no support or bug fixes for HDInsight 3.3 or earlier versions. Future releases of HDInsight are available only on the Linux OS. There will be no future releases of HDInsight on Windows.

### Which versions of HDInsight on Windows are affected?
Azure HDInsight version 3.3 is the last version of HDInsight for Windows. Before HDInsight on Windows is retired, all HDInsight Windows clusters version 3.3 or earlier must be migrated to HDInsight on Linux version 3.5 or later. Migrating your clusters to HDInsight on Linux enables you to retain the ability to create new clusters or resize existing clusters. 

### What do I need to do?
Migrate your HDInsight Windows clusters to a supported HDInsight Linux cluster before July 31, 2018. Learn more in the [HDInsight migration document](/hdinsight/hdinsight-migrate-from-windows-to-linux). For details about Azure HDInsight versions, see the list of [supported versions](/hdinsight/hdinsight-component-versioning#supported-hdinsight-versions). 

### Where do I find the cluster OS type?
In the Azure portal, go to the HDInsight Cluster overview page and locate **Cluster type** under **Essentials**. The cluster OS types are listed on that page. 

### I can't migrate to an HDInsight Linux cluster by July 31, 2018. What is the impact to my HDInsight Windows cluster?
The HDInsight Windows cluster runs as-is, but you cannot create a new HDInsight Windows cluster, or resize an existing HDInsight Windows cluster. 

### My cluster has a .NET dependency. How do I resolve this dependency on Linux?
You can resolve your Linux cluster dependency by using the [Mono project](http://www.mono-project.com/). This open source implementation of .NET is available for HDInsight Linux clusters. Learn more in the [HDInsight migration document](/hdinsight/hdinsight-migrate-from-windows-to-linux). 

### I'm a new customer for HDInsight on Windows. How can I create an HDInsight Windows cluster?
As of July 3, 2017, only existing HDInsight Windows customers can create new HDInsight Windows clusters. New customers cannot create an HDInsight Windows cluster in the Azure portal by using PowerShell or the SDK. We recommend that new customers create a Linux HDInsight cluster. Existing customers can create new HDInsight Windows clusters until the HDInsight on Windows retirement date. 

### Is there a pricing impact associated with moving from HDInsight on Windows to HDInsight on Linux?
No, the pricing is the same for HDInsight on either OS. 

### What are the customer advantages associated with the move to only using HDInsight on Linux?
* Faster time-to-market for open source big data technologies through the HDInsight service
* A large community and ecosystem for support
* Ability to exercise active development by the open source community for Hadoop and other big data technologies

### Does HDInsight on Linux provide additional functionality beyond what is available in HDInsight on Windows?
Starting with HDInsight version 3.4, Microsoft has released HDInsight only on the Linux OS. As a result, some of the components within HDInsight are available for Linux only. These include Apache Ranger, Kafka, Interactive Hive, Spark, and HDInsight applications. 

## Service level agreement for HDInsight cluster versions
The service level agreement (SLA) is defined in terms of a _support window_. The support window is the period of time that an HDInsight cluster version is supported by Microsoft Customer Service and Support. If the version has a _support expiration date_ that has passed, the HDInsight cluster is outside the support window. For more information about supported versions, see the list of [supported HDInsight cluster versions](/hdinsight/hdinsight-migrate-from-windows-to-linux). The support expiration date for a specified HDInsight version X (after a newer X+1 version is available) is calculated as the later of:  

* Formula 1: Add 180 days to the date when the HDInsight cluster version X was released.
* Formula 2: Add 90 days to the date when the HDInsight cluster version X+1 is made available in Azure portal.

The _retirement date_ is the date after which the cluster version cannot be created on HDInsight. Starting July 31, 2017, you cannot resize an HDInsight cluster after its retirement date. 

> [!NOTE]
> Windows-based HDInsight clusters (including version 2.1, 3.0, 3.1, 3.2 and 3.3) run on Azure Guest OS Family 4, which uses the 64-bit version of Windows Server 2012 R2 and supports .NET Framework 4.0, 4.5, 4.5.1, and 4.5.2.
>
>

## Hortonworks release notes associated with HDInsight versions

The section provides links to release notes for the Hortonworks Data Platform distributions and Apache components that are used with HDInsight.
* HDInsight cluster version 3.6 uses a Hadoop distribution that is based on [Hortonworks Data Platform 2.6](http://docs.hortonworks.com/HDPDocuments/HDP2/HDP-2.6.0/bk_release-notes/content/ch_relnotes.html). 
* HDInsight cluster version 3.5 uses a Hadoop distribution that is based on [Hortonworks Data Platform 2.5](http://docs.hortonworks.com/HDPDocuments/HDP2/HDP-2.5.0/bk_release-notes/content/ch_relnotes_v250.html). HDInsight cluster version 3.5 is the _default_ Hadoop cluster that is created in the Azure portal.
* HDInsight cluster version 3.4 uses a Hadoop distribution that is based on [Hortonworks Data Platform 2.4](http://docs.hortonworks.com/HDPDocuments/HDP2/HDP-2.4.0/bk_HDP_RelNotes/content/ch_relnotes_v240.html). 
* HDInsight cluster version 3.3 uses a Hadoop distribution that is based on [Hortonworks Data Platform 2.3](http://docs.hortonworks.com/HDPDocuments/HDP2/HDP-2.3.0/bk_HDP_RelNotes/content/ch_relnotes_v230.html).

  * [Apache Storm release notes](https://storm.apache.org/2015/11/05/storm0100-released.html) are available on the Apache website.
  * [Apache Hive release notes](https://issues.apache.org/jira/secure/ReleaseNote.jspa?version=12332384&styleName=Text&projectId=12310843) are available on the Apache website.
* HDInsight cluster version 3.2 uses a Hadoop distribution that is based on [Hortonworks Data Platform 2.2][hdp-2-2].  

  * Release notes for specific Apache components are available as follows: [Hive 0.14](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12310843&version=12326450), [Pig 0.14](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12310730&version=12326954), [HBase 0.98.4](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12310753&version=12326810), [Phoenix 4.2.0](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12315120&version=12327581), [M/R 2.6](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12310941&version=12327180), [HDFS 2.6](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12310942&version=12327181), [YARN 2.6](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12313722&version=12327197), [Common](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12310240&version=12327179), [Tez 0.5.2](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12314426&version=12328742), [Ambari 2.0](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12312020&version=12327486), [Storm 0.9.3](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12314820&version=12327112), and [Oozie 4.1.0](https://issues.apache.org/jira/secure/ReleaseNote.jspa?version=12324960&projectId=12311620).
* HDInsight cluster version 3.1 uses a Hadoop distribution that is based on [Hortonworks Data Platform 2.1.7][hdp-2-1-7]. HDInsight 3.1 clusters created before November, 7, 2014, are based on [Hortonworks Data Platform 2.1.1][hdp-2-1-1].
* HDInsight cluster version 3.0 uses a Hadoop distribution that is based on [Hortonworks Data Platform 2.0][hdp-2-0-8].
* HDInsight cluster version 2.1 uses a Hadoop distribution that is based on [Hortonworks Data Platform 1.3][hdp-1-3-0].
* HDInsight cluster version 1.6 uses a Hadoop distribution that is based on Hortonworks Data Platform 1.1.

### Pricing and SLA
For information on pricing and SLA for HDInsight, see [HDInsight pricing](https://www.azure.cn/pricing/details/hdinsight/).

## Default node configuration and virtual machine sizes for clusters
The following tables list the default virtual machine (VM) sizes for HDInsight clusters.

> [!IMPORTANT]
> If you need more than 32 worker nodes in a cluster, you must select a head node size with at least 8 cores and 14 GB of RAM.
>
>
| Cluster type | Hadoop | HBase | Storm | Spark |
| --- | --- | --- | --- | --- |
| Head: default VM size |D3 v2 |D3 v2 |A3 |D12 v2 |
| Head: recommended VM sizes |D3 v2, D4 v2, D12 v2 |D3 v2, D4 v2, D12 v2 |A3, A4, A5 |D12 v2, D13 v2, D14 v2 |
| Worker: default VM size |D3 v2 |D3 v2 |D3 v2 |Windows: D12 v2; Linux: D4 v2 |
| Worker: recommended VM sizes |D3 v2, D4 v2, D12 v2 |D3 v2, D4 v2, D12 v2 |D3 v2, D4 v2, D12 v2 |Windows: D12 v2, D13 v2, D14 v2; Linux: D4 v2, D12 v2, D13 v2, D14 v2 |
| ZooKeeper: default VM size | |A3 |A2 | |
| ZooKeeper: recommended VM sizes | |A3, A4, A5 |A2, A3, A4 | |

> [!NOTE]
> - Head is known as *Nimbus* for the Storm cluster type.
> - Worker is known as *Supervisor* for the Storm cluster type.
> - Worker is known as *Region* for the HBase cluster type.

## Next steps
- [Cluster setup for Hadoop, Spark, and more on HDInsight](hdinsight-hadoop-provision-linux-clusters.md)
- [Work in Hadoop on HDInsight from a Windows PC](hdinsight-hadoop-windows-tools.md)

[Supported HDInsight versions]:(#supported-hdinsight-versions)

[image-hdi-versioning-versionscreen]: ./media/hdinsight-component-versioning/hdi-versioning-version-screen.png

[wa-forums]: https://www.azure.cn/support/forums/

[connect-excel-with-hive-ODBC]: hdinsight-connect-excel-hive-ODBC-driver.md

[hdp-2-2]: http://docs.hortonworks.com/HDPDocuments/HDP2/HDP-2.2.0/bk_HDP_RelNotes/content/ch_relnotes_v220.html

[hdp-2-1-7]: http://docs.hortonworks.com/HDPDocuments/HDP2/HDP-2.1.7-Win/bk_releasenotes_HDP-Win/content/ch_relnotes-HDP-2.1.7.html

[hdp-2-1-1]: http://docs.hortonworks.com/HDPDocuments/HDP2/HDP-2.1.1/bk_releasenotes_hdp_2.1/content/ch_relnotes-hdp-2.1.1.html

[hdp-2-0-8]: http://docs.hortonworks.com/HDPDocuments/HDP2/HDP-2.0.8.0/bk_releasenotes_hdp_2.0/content/ch_relnotes-hdp2.0.8.0.html

[hdp-1-3-0]: http://docs.hortonworks.com/HDPDocuments/HDP1/HDP-1.3.0/bk_releasenotes_hdp_1.x/content/ch_relnotes-hdp1.3.0_1.html

[ambari-docs]: https://github.com/apache/ambari/blob/trunk/ambari-server/docs/api/v1/index.md

[zookeeper]: http://zookeeper.apache.org/

<!--Update_Description: wording update-->