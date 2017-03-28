<properties
    pageTitle="Get started with Apache Spark cluster in Azure HDInsight | Azure"
    description="Step-by-step instructions on how to quickly create an Apache Spark cluster in HDInsight and then use Spark SQL from Jupyter notebooks to run interactive queries."
    services="hdinsight"
    documentationcenter=""
    author="nitinme"
    manager="jhubbard"
    editor="cgronlun"
    tags="azure-portal" />
<tags
    ms.assetid="91f41e6a-d463-4eb4-83ef-7bbb1f4556cc"
    ms.service="hdinsight"
    ms.workload="big-data"
    ms.tgt_pltfrm="na"
    ms.devlang="na"
    ms.topic="get-started-article"
    ms.date="03/13/2017"
    wacn.date=""
    ms.author="nitinme" />

# Get started: Create Apache Spark cluster in Azure HDInsight and run interactive queries using Spark SQL

Learn how to create an [Apache Spark](/documentation/articles/hdinsight-apache-spark-overview/) cluster in HDInsight and then use [Jupyter](https://jupyter.org) notebook to run Spark SQL interactive queries on the Spark cluster.

![Get started using Apache Spark in HDInsight](./media/hdinsight-apache-spark-jupyter-spark-sql/hdispark.getstartedflow.png "Get started using Apache Spark in HDInsight tutorial. Steps illustrated: create a storage account; create a cluster; run Spark SQL statements")

## Prerequisites
* **An Azure subscription**. Before you begin this tutorial, you must have an Azure subscription. See [Create your trial Azure account today](https://www.azure.cn/pricing/1rmb-trial/).

## Create a Spark cluster
In this section, you create a Spark cluster in HDInsight using an [Azure Resource Manager template](https://github.com/Azure/azure-quickstart-templates/tree/master/101-hdinsight-spark-linux/). For other cluster creation methods, see [Create HDInsight clusters](/documentation/articles/hdinsight-hadoop-provision-linux-clusters/).

1. Click the following image to open the template in the Azure portal preview.         

    <a href="https://portal.azure.cn/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FAzure%2Fazure-quickstart-templates%2Fmaster%2F101-hdinsight-spark-linux%2Fazuredeploy.json" target="_blank"><img src="./media/hdinsight-apache-spark-jupyter-spark-sql/deploy-to-azure.png" alt="Deploy to Azure"></a>

    >[AZURE.NOTE] Templates you downloaded from the GitHub Repo "azure-quickstart-templates" must be modified in order to fit in the Azure China Cloud Environment. For example, replace some endpoints -- "blob.core.windows.net" by "blob.core.chinacloudapi.cn", "cloudapp.azure.com" by "chinacloudapp.cn"; change the allowed location to "China North" and "China East"; change the HDInsight Linux version to Azure China supported one, 3.5.

2. Enter the following values:

    * **Subscription**: Select your Azure subscription for this cluster.
    * **Resource group**: Create a resource group or select an existing one. Resource group is used to manage Azure resources for your projects.
    * **Location**: Select a location for the resource group.  This location is also used for the default cluster storage and the HDInsight cluster.
    * **ClusterName**: Enter a name for the Hadoop cluster that you create.
    * **Spark version**: Select the Spark version that you want to install on the cluster.
    * **Cluster login name and password**: The default login name is admin.
    * **SSH user name and password**.

   Write down these values.  You need them later in the tutorial.

3. Select **Pin to dashboard**; in **Legal terms**, click **Purchase**; and then, click **Create**. You can see a new tile titled Submitting deployment for Template deployment. It takes about 20 minutes to create the cluster.

> [AZURE.NOTE]
> This article creates a Spark cluster that uses [Azure Storage Blobs as the cluster storage](/documentation/articles/hdinsight-hadoop-use-blob-storage/). You can also create a Spark cluster that uses [Azure Data Lake Store](/documentation/articles/data-lake-store-overview/) as additional storage, in addition to Azure Storage Blobs as the default storage. For instructions, see [Create an HDInsight cluster with Data Lake Store](/documentation/articles/data-lake-store-hdinsight-hadoop-use-portal/).
>
>

## Run a Spark SQL query

In this section, you use Jupyter notebook to run Spark SQL queries against the Spark cluster. HDInsight Spark clusters provide three kernels that you can use with the Jupyter notebook. These are:

* **PySpark** (for applications written in Python)
* **PySpark3** (for applications written in Python3)
* **Spark** (for applications written in Scala)

In this article, you use the **PySpark** kernel. For more information about the kernels, see [Use Jupyter notebook kernels with Apache Spark clusters in HDInsight](/documentation/articles/hdinsight-apache-spark-jupyter-notebook-kernels/). Some of the key benefits of using the PySpark kernel are:

* The contexts for Spark and Hive are set automatically.
* Use cell magics, such as `%%sql`, to directly run SQL or Hive queries, without any preceding code snippets.
* The output for the SQL or Hive queries is automatically visualized.

### Create Jupyter notebook with PySpark kernel

1. Open the [Azure portal preview](https://portal.azure.cn/).

2. If you opted to pin the cluster to the dashboard, click the cluster tile from the dashboard to launch the cluster blade.

    If you did not pin the cluster to the dashboard, from the left pane, click **HDInsight clusters**, and then click the cluster you created.

3. From **Quick links**, click **Cluster dashboards**, and then click **Jupyter Notebook**. If prompted, enter the admin credentials for the cluster.

    ![HDInsight cluster dashboards](./media/hdinsight-apache-spark-jupyter-spark-sql/hdinsight-azure-portal-cluster-dashboards.png "HDInsight cluster dashboards")

    > [AZURE.NOTE]
    > You may also reach the Jupyter Notebook for your cluster by opening the following URL in your browser. Replace **CLUSTERNAME** with the name of your cluster:
    ><p>
    > `https://CLUSTERNAME.azurehdinsight.cn/jupyter`
    >
    >
3. Create a notebook. Click **New**, and then click **PySpark**.

    ![Create a Jupyter notebook](./media/hdinsight-apache-spark-jupyter-spark-sql/hdispark.note.jupyter.createnotebook.png "Create a Jupyter notebook")

    A new notebook is created and opened with the name Untitled(Untitled.pynb).

4. Click the notebook name at the top, and enter a friendly name if you want.

    ![Provide a name for the notebook](./media/hdinsight-apache-spark-jupyter-spark-sql/hdispark.note.jupyter.notebook.name.png "Provide a name for the notebook")

5. Paste the following code in an empty cell, and then press **SHIFT + ENTER** to execute the code. The code imports the types required for this scenario:

        from pyspark.sql.types import *

    Because you created a notebook using the PySpark kernel, you do not need to create any contexts explicitly. The Spark and Hive contexts are automatically created for you when you run the first code cell.

    ![Status of a Jupyter notebook job](./media/hdinsight-apache-spark-jupyter-spark-sql/hdispark.jupyter.job.status.png "Status of a Jupyter notebook job")

    Every time you run a job in Jupyter, your web browser window title shows a **(Busy)** status along with the notebook title. You also see a solid circle next to the **PySpark** text in the top-right corner. After the job is completed, it changes to a hollow circle.

6. Register a sample data set as a temporary table (**hvac**) by running the following code.

        # Load the data
        hvacText = sc.textFile("wasbs:///HdiSamples/HdiSamples/SensorSampleData/hvac/HVAC.csv")

        # Create the schema
        hvacSchema = StructType([StructField("date", StringType(), False),StructField("time", StringType(), False),StructField("targettemp", IntegerType(), False),StructField("actualtemp", IntegerType(), False),StructField("buildingID", StringType(), False)])

        # Parse the data in hvacText
        hvac = hvacText.map(lambda s: s.split(",")).filter(lambda s: s[0] != "Date").map(lambda s:(str(s[0]), str(s[1]), int(s[2]), int(s[3]), str(s[6]) ))

        # Create a data frame
        hvacdf = sqlContext.createDataFrame(hvac,hvacSchema)

        # Register the data fram as a table to run queries against
        hvacdf.registerTempTable("hvac")

    Spark clusters in HDInsight come with a sample data file, **hvac.csv**, under **\HdiSamples\HdiSamples\SensorSampleData\hvac**.

7. To query the data run the following code.

        %%sql
        SELECT buildingID, (targettemp - actualtemp) AS temp_diff, date FROM hvac WHERE date = \"6/1/13\"

    Because you are using a PySpark kernel, you can now directly run a SQL query on the temporary table **hvac** that you created by using the `%%sql` magic. For more information about the `%%sql` magic, and other magics available with the PySpark kernel, see [Kernels available on Jupyter notebooks with Spark HDInsight clusters](/documentation/articles/hdinsight-apache-spark-jupyter-notebook-kernels/#parameters-supported-with-the-sql-magic).

    The following tabular output is displayed by default.

    ![Table output of query result](./media/hdinsight-apache-spark-jupyter-spark-sql/tabular.output.png "Table output of query result")

    You can also see the results in other visualizations as well. For example, an area graph for the same output would look like the following.

    ![Area graph of query result](./media/hdinsight-apache-spark-jupyter-spark-sql/area.output.png "Area graph of query result")

9. Shut down the notebook to release the cluster resources after you have finished running the application. To do so, from the **File** menu on the notebook, click **Close and Halt**.

## Troubleshoot

Here are some common issues that you might run into while working with HDInsight clusters.

### Access control requirements
[AZURE.INCLUDE [access-control](../../includes/hdinsight-access-control-requirements.md)]

## Delete the cluster
[AZURE.INCLUDE [delete-cluster-warning](../../includes/hdinsight-delete-cluster-warning.md)]

## See also
* [Overview: Apache Spark on Azure HDInsight](/documentation/articles/hdinsight-apache-spark-overview/)

### Scenarios
* [Spark with BI: Perform interactive data analysis using Spark in HDInsight with BI tools](/documentation/articles/hdinsight-apache-spark-use-bi-tools/)
* [Spark with Machine Learning: Use Spark in HDInsight for analyzing building temperature using HVAC data](/documentation/articles/hdinsight-apache-spark-ipython-notebook-machine-learning/)
* [Spark with Machine Learning: Use Spark in HDInsight to predict food inspection results](/documentation/articles/hdinsight-apache-spark-machine-learning-mllib-ipython/)
* [Spark Streaming: Use Spark in HDInsight for building real-time streaming applications](/documentation/articles/hdinsight-apache-spark-eventhub-streaming/)
* [Website log analysis using Spark in HDInsight](/documentation/articles/hdinsight-apache-spark-custom-library-website-log-analysis/)

### Create and run applications
* [Create a standalone application using Scala](/documentation/articles/hdinsight-apache-spark-create-standalone-application/)
* [Run jobs remotely on a Spark cluster using Livy](/documentation/articles/hdinsight-apache-spark-livy-rest-interface/)

### Tools and extensions
* [Use Zeppelin notebooks with a Spark cluster on HDInsight](/documentation/articles/hdinsight-apache-spark-use-zeppelin-notebook/)
* [Kernels available for Jupyter notebook in Spark cluster for HDInsight](/documentation/articles/hdinsight-apache-spark-jupyter-notebook-kernels/)
* [Use external packages with Jupyter notebooks](/documentation/articles/hdinsight-apache-spark-jupyter-notebook-use-external-packages/)
* [Install Jupyter on your computer and connect to an HDInsight Spark cluster](/documentation/articles/hdinsight-apache-spark-jupyter-notebook-install-locally/)

### Manage resources
* [Manage resources for the Apache Spark cluster in Azure HDInsight](/documentation/articles/hdinsight-apache-spark-resource-manager/)
* [Track and debug jobs running on an Apache Spark cluster in HDInsight](/documentation/articles/hdinsight-apache-spark-job-debugging/)

[hdinsight-versions]: /documentation/articles/hdinsight-component-versioning/
[hdinsight-upload-data]: /documentation/articles/hdinsight-upload-data/
[hdinsight-storage]: /documentation/articles/hdinsight-hadoop-use-blob-storage/

[azure-purchase-options]: /pricing/overview/
[azure-member-offers]: /pricing/member-offers/
[azure-trial]: /pricing/1rmb-trial/
[azure-management-portal]: https://manage.windowsazure.cn/
[azure-create-storageaccount]: /documentation/articles/storage-create-storage-account/