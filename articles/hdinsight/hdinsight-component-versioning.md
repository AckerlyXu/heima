---
title: Hadoop components & versions - Azure HDInsight | Azure
description: Learn the Hadoop components and versions in HDInsight and the service levels available in this cloud distribution of HortonWorks Data Platform.
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
ms.date: 04/14/2017
wacn.date: ''
ms.author: bprakash

---
# What are the Hadoop components and versions available with HDInsight?

Learn about the Hadoop ecosystem components and versions in Azure HDInsight, learn how to check Hadoop component versions in HDInsight. 

[!INCLUDE [hdinsight-linux-acn-version.md](../../includes/hdinsight-linux-acn-version.md)]

Each HDInsight version is a cloud distribution of a version of the HortonWorks Data Platform (HDP).

## Hadoop components available with different HDInsight versions
Azure HDInsight supports multiple Hadoop cluster versions that can be deployed at any time. Each version choice creates a specific version of the Hortonworks Data Platform (HDP) distribution and a set of components that are contained within that distribution. The default cluster version used by Azure HDInsight is currently 3.5, and, as of February 17, 2017, based on HDP 2.5.

The component versions associated with HDInsight cluster versions are itemized in the following table: 

> [!NOTE]
> The default version from the service may change without notice. If you have a version dependency, we recommend that you specify the version when you create clusters using .NET SDK/Azure PowerShell and Azure CLI. 
>
>

| Component | HDInsight version 3.6 | HDInsight version 3.5 (Default) | HDInsight version 3.4 | HDInsight Version 3.3 | HDInsight Version 3.2 | HDInsight Version 3.1 | HDInsight Version 3.0 |
| --- | --- | --- | --- | --- | --- | --- |--- |
| Hortonworks Data Platform |2.6 |2.5 |2.4 |2.3 |2.2 |2.1.7 |2.0 |
| Apache Hadoop & YARN |2.7.3 |2.7.3 |2.7.1 |2.7.1 |2.6.0 |2.4.0 |2.2.0 |
| Apache Tez |0.7.0 |0.7.0 |0.7.0 |0.7.0 |0.5.2 |0.4.0 |-|
| Apache Pig |0.16.0 |0.16.0 |0.15.0 |0.15.0 |0.14.0 |0.12.1 |0.12.0 |
| Apache Hive & HCatalog |1.2.1 |1.2.1 |1.2.1 |1.2.1 |0.14.0 |0.13.1 |0.12.0 |
| Apache Hive2 | 2.1.0 |-|-|-|-|-|-|
| Apache Tez-Hive2 | 0.8.4 |-|-|-|-|-|-|
| Apache Ranger | 0.7.0 |0.6.0 |-|-|-|-|-|
| Apache HBase |1.1.2 |1.1.2 |1.1.2 |1.1.1 |0.98.4 |0.98.0 |-|
| Apache Sqoop |1.4.6 |1.4.6 |1.4.6 |1.4.6 |1.4.5 |1.4.4 |1.4.4 |
| Apache Oozie |4.2.0 |4.2.0 |4.2.0 |4.2.0 |4.1.0 |4.0.0 |4.0.0 |
| Apache Zookeeper |3.4.6 |3.4.6 |3.4.6 |3.4.6 |3.4.6 |3.4.5 |3.4.5 |
| Apache Storm |1.1.0 |1.0.1 |0.10.0 |0.10.0 |0.9.3 |0.9.1 |-|
| Apache Mahout |0.9.0+ |0.9.0+ |0.9.0+ |0.9.0+ |0.9.0 |0.9.0 |-|
| Apache Phoenix |4.7.0 |4.7.0 |4.4.0 |4.4.0 |4.2.0 |4.0.0.2.1.7.0-2162 |-|
| Apache Spark |2.1.0 (Linux only) |1.6.2 + 2.0 (Linux only) |1.6.0 (Linux only) |1.5.2 (Linux only/Experimental build) |1.3.1 (Windows-only) |-|-|
| Apache Kafka | 0.10.0 | 0.10.0 | 0.9.0 |-|-|-|-|
| Apache Ambari | 2.5.0 | 2.4.0 | 2.2.1 | 2.1.0 |-|-|-|
| Apache Zeppelin | 0.7.0 |-|-|-|-|-|-|
| Mono |4.2.1 |4.2.1 |3.2.8 |-|-|-|

## How to check current Hadoop component version information

The Hadoop ecosystem component versions associated with HDInsight cluster versions can change with updates to HDInsight. To check the Hadoop components and to verify which versions are being used for a cluster, use the Ambari REST API. The **GetComponentInformation** command retrieves information about service components. For details, see the [Ambari documentation][ambari-docs].

For Windows-based clusters only: Another way to get component versions is to log in to a cluster by using Remote Desktop and examine the contents of the "C:\apps\dist\" directory directly.

> [!IMPORTANT]
> Linux is the only operating system used on HDInsight version 3.4 or greater. For more information, see [HDInsight 3.3 deprecation](#hdi-version-33-nearing-deprecation-date). 

### Release notes

See [HDInsight release notes](hdinsight-release-notes.md) for additional release notes on the latest versions of HDInsight.

## Supported HDInsight versions
The following table lists the versions of HDInsight currently available, the corresponding Hortonworks Data Platform versions that they use, and their release dates. When known, their support expiration and deprecation dates are also provided. Note the following version information:

* Highly available clusters with two head nodes are deployed by default for HDInsight 2.1 and above. They are not available for HDInsight 1.6 clusters.
* Once the support has expired for a particular version, it may not be available through the Azure portal preview. The following table indicates which versions are available on the Azure Classic Management Portal. Cluster versions  continue to be available using the `Version` parameter in the Windows PowerShell [New-AzureRmHDInsightCluster](https://msdn.microsoft.com/library/mt619331.aspx) command and the .NET SDK until its deprecation date.

| HDInsight Version | HDP Version | VM OS | High Availability | Available on Azure portal preview |
| --- | --- | --- | --- | --- |
| HDI 3.6 |HDP 2.6 |Ubuntu 16 |Yes |Yes |
| HDI 3.5 |HDP 2.5 |Ubuntu 16 |Yes |Yes |
| HDI 3.3 |HDP 2.3 |Windows Server 2012R2 |Yes |Yes |
| HDI 3.2 |HDP 2.2 |Windows Server 2012R2 |Yes |No |
| HDI 3.1 |HDP 2.1 |Windows Server 2012R2 |Yes |No |
| HDI 3.0 |HDP 2.0 |Windows Server 2012R2 |Yes |No |
| HDI 2.1 |HDP 1.3 |Windows Server 2012R2 |Yes |No |
| HDI 1.6 |HDP 1.1 | |No |No |

## HDI Version 3.3 nearing deprecation date
If you have HDI 3.3 Cluster, then upgrade your Cluster to HDI 3.5 or HDI 3.6 soon. Deprecation timelines for HDI 3.3 Windows may vary by region. If your region's planned deprecation date is different, you are notified separately.

### The service-level agreement for HDInsight cluster versions
The SLA is defined in terms of a **Support Window**. A Support Window refers to the period of time that an HDInsight cluster version is supported by Microsoft Customer Service and Support. An HDInsight cluster is outside the Support Window if its version has a **Support Expiration Date** past the current date. A list of supported HDInsight cluster versions can be found in the table above. The support expiration date for a given HDInsight version X (once a newer X+1 version is available) is calculated as the later of:  

* Formula 1: Add 180 days to the date HDInsight cluster version X was released.
* Formula 2: Add 90 days to the date HDInsight cluster version X+1 (the subsequent version after X) is made available in the Portal.

The **Deprecation Date** is the date after which the cluster version cannot be created on HDInsight.

> [!NOTE]
> Windows-based HDInsight clusters (including version 2.1, 3.0, 3.1, 3.2 and 3.3) run on Azure Guest OS Family 4, which uses the 64-bit version of Windows Server 2012 R2 and supports .NET Framework 4.0, 4.5, 4.5.1, and 4.5.2.
>
>

## Hortonworks release notes associated with HDInsight versions
* HDInsight cluster version 3.4 uses a Hadoop distribution that is based on [Hortonworks Data Platform 2.4](http://docs.hortonworks.com/HDPDocuments/HDP2/HDP-2.4.0/bk_HDP_RelNotes/content/ch_relnotes_v240.html). This is the **default** Hadoop cluster created when using the portal.
* HDInsight cluster version 3.3 uses a Hadoop distribution that is based on [Hortonworks Data Platform 2.3](http://docs.hortonworks.com/HDPDocuments/HDP2/HDP-2.3.0/bk_HDP_RelNotes/content/ch_relnotes_v230.html).

    * Apache Storm release notes are available [here](https://storm.apache.org/2015/11/05/storm0100-released.html).
    * Apache Hive release notes are available [here](https://issues.apache.org/jira/secure/ReleaseNote.jspa?version=12332384&styleName=Text&projectId=12310843).
* HDInsight cluster version 3.2 uses a Hadoop distribution that is based on [Hortonworks Data Platform 2.2][hdp-2-2].  

    * Release notes for specific Apache components - [Hive 0.14](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12310843&version=12326450), [Pig 0.14](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12310730&version=12326954), [HBase 0.98.4](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12310753&version=12326810), [Phoenix 4.2.0](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12315120&version=12327581), [M/R 2.6](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12310941&version=12327180), [HDFS 2.6](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12310942&version=12327181), [YARN 2.6](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12313722&version=12327197), [Common](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12310240&version=12327179), [Tez 0.5.2](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12314426&version=12328742), [Ambari 2.0](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12312020&version=12327486), [Storm 0.9.3](https://issues.apache.org/jira/secure/ReleaseNote.jspa?projectId=12314820&version=12327112), [Oozie 4.1.0](https://issues.apache.org/jira/secure/ReleaseNote.jspa?version=12324960&projectId=12311620).
* HDInsight cluster version 3.1 uses a Hadoop distribution that is based on [Hortonworks Data Platform 2.1.7][hdp-2-1-7].
* HDInsight cluster version 3.0 uses a Hadoop distribution that is based on [Hortonworks Data Platform 2.0][hdp-2-0-8].
* HDInsight cluster version 2.1 uses a Hadoop distribution that is based on [Hortonworks Data Platform 1.3][hdp-1-3-0].
* HDInsight cluster version 1.6 uses a Hadoop distribution that is based on [Hortonworks Data Platform 1.1][hdp-1-1-0].

### Pricing and SLA
For information on pricing and SLA for HDInsight, see [HDInsight pricing](https://www.azure.cn/pricing/details/hdinsight/).

[image-hdi-versioning-versionscreen]: ./media/hdinsight-component-versioning/hdi-versioning-version-screen.png

[wa-forums]: https://www.azure.cn/support/forums/

[connect-excel-with-hive-ODBC]: hdinsight-connect-excel-hive-ODBC-driver.md

[hdp-2-2]: http://docs.hortonworks.com/HDPDocuments/HDP2/HDP-2.2.0/bk_HDP_RelNotes/content/ch_relnotes_v220.html

[hdp-2-1-7]: http://docs.hortonworks.com/HDPDocuments/HDP2/HDP-2.1.7-Win/bk_releasenotes_HDP-Win/content/ch_relnotes-HDP-2.1.7.html

[hdp-2-1-1]: http://docs.hortonworks.com/HDPDocuments/HDP2/HDP-2.1.1/bk_releasenotes_hdp_2.1/content/ch_relnotes-hdp-2.1.1.html

[hdp-2-0-8]: http://docs.hortonworks.com/HDPDocuments/HDP2/HDP-2.0.8.0/bk_releasenotes_hdp_2.0/content/ch_relnotes-hdp2.0.8.0.html

[hdp-1-3-0]: http://docs.hortonworks.com/HDPDocuments/HDP1/HDP-1.3.0/bk_releasenotes_hdp_1.x/content/ch_relnotes-hdp1.3.0_1.html

[hdp-1-1-0]: http://docs.hortonworks.com/HDPDocuments/HDP1/HDP-Win-1.1/bk_releasenotes_HDP-Win/content/ch_relnotes-hdp-win-1.1.0_1.html

[ambari-docs]: https://github.com/apache/ambari/blob/trunk/ambari-server/docs/api/v1/index.md

[zookeeper]: http://zookeeper.apache.org/
