---
title: Sign-in instructions for the Azure Toolkit for IntelliJ | Microsoft Docs
description: Learn how to sign in to Azure by using the Azure Toolkit for IntelliJ.
services: ''
documentationcenter: java
author: alexchen2016
manager: digimobile
editor: ''

ms.assetid: 
ms.service: multiple
ms.workload: na
ms.tgt_pltfrm: multiple
ms.devlang: Java
ms.topic: article
origin.date: 04/14/2017
ms.date: 08/25/2017
ms.author: v-junlch

---

# Sign-in instructions for the Azure Toolkit for IntelliJ

The Azure Toolkit for IntelliJ provides two methods for signing in to your Azure account:

  - **Interactive**: You enter your Azure credentials each time you sign in to your Azure account. Azure China account are not supported by this way currently.
  - **Automated**: You create a credentials file that you can use to automatically sign in to your Azure account.

The following sections describe how to use **Automated** method.

[!INCLUDE [azure-toolkit-for-intellij-prerequisites](../includes/azure-toolkit-for-intellij-prerequisites.md)]

## How to create a credentials file for your Azure account <a name="create-a-credentials-file"></a>

[!INCLUDE [azure-eclipse-login-guide](../includes/azure-eclipse-login-guide.md)]

## Sign in to your Azure account automatically by using an existing credentials file

If you sign out of your Azure account when you are using IntelliJ IDEA, you must use an existing credentials file to automatically sign back in to the account. To configure the Azure Toolkit for Eclipse to use an existing credentials file, do the following:

1. Open your project with IntelliJ IDEA.

2. On the **Tools** menu, point to **Azure**, and then click **Azure Sign In**.

   ![The IntelliJ Azure Sign In command][A01]

3. In the **Azure Sign In** window, select **Automated**, and then click **Browse**.

   ![The Azure Sign In window with Automated selected][A02]

4. In the **Select Authentication File** dialog box, select a previously created credentials file, and then click **Select**.

   ![The Select Authentication File dialog box][A08]

5. In the **Azure Sign In** window, click **Sign in**.

   ![The Azure Sign In window with Automated selected][A06]

6. In the **Select Subscriptions** dialog box, select the subscriptions that you want to use, and then click **OK**.

   ![The Select Subscriptions dialog box][A07]

## Sign out of your Azure account after you have signed in automatically

After you have configured your account by using the preceding steps, the Azure Toolkit automatically signs you in to your Azure account each time you restart IntelliJ IDEA. However, to sign out of your Azure account and prevent the Azure Toolkit from signing you in automatically, do the following:

1. In IntelliJ IDEA, on the **Tools** menu, point to **Azure**, and then click **Azure Sign Out**.

   ![The IntelliJ Azure Sign Out command][L01]

2. In the **Azure Sign Out** confirmation window, click **Yes**.

   ![The Azure Sign Out confirmation window][L03]

## Next steps
For more information about the Azure Toolkits for Java IDEs, see the following links:

- [Azure Toolkit for Eclipse]
  - [What's new in the Azure Toolkit for Eclipse]
  - [Installing the Azure Toolkit for Eclipse]
  - [Sign-in instructions for the Azure Toolkit for Eclipse]
  - [Create a Hello World web app for Azure in Eclipse]
- [Azure Toolkit for IntelliJ]
  - [What's new in the Azure Toolkit for IntelliJ]
  - [Installing the Azure Toolkit for IntelliJ]
  - *Sign-in instructions for the Azure Toolkit for IntelliJ* (this article)
  - [Create a Hello World web app for Azure in IntelliJ]

For more information about using Azure with Java, see the [Azure Java Developer Center] and the [Java Tools for Visual Studio Team Services].

<!-- URL List -->

[Azure Toolkit for Eclipse]: ./azure-toolkit-for-eclipse.md
[Azure Toolkit for IntelliJ]: ./azure-toolkit-for-intellij.md
[Create a Hello World Web App for Azure in Eclipse]: ./app-service-web/app-service-web-eclipse-create-hello-world-web-app.md
[Create a Hello World web app for Azure in IntelliJ]: ./app-service-web/app-service-web-intellij-create-hello-world-web-app.md
[Installing the Azure Toolkit for Eclipse]: ./azure-toolkit-for-eclipse-installation.md
[Installing the Azure Toolkit for IntelliJ]: ./azure-toolkit-for-intellij-installation.md
[Sign-in instructions for the Azure Toolkit for Eclipse]: ./azure-toolkit-for-eclipse-sign-in-instructions.md
[Sign-in instructions for the Azure Toolkit for IntelliJ]: ./azure-toolkit-for-intellij-sign-in-instructions.md
[What's new in the Azure Toolkit for Eclipse]: ./azure-toolkit-for-eclipse-whats-new.md
[What's new in the Azure Toolkit for IntelliJ]: ./azure-toolkit-for-intellij-whats-new.md

[Azure Java Developer Center]: /develop/java/
[Java Tools for Visual Studio Team Services]: https://java.visualstudio.com/

<!-- IMG List -->

[I01]: ./media/azure-toolkit-for-intellij-sign-in-instructions/I01.png
[I02]: ./media/azure-toolkit-for-intellij-sign-in-instructions/I02.png
[I03]: ./media/azure-toolkit-for-intellij-sign-in-instructions/I03.png
[I04]: ./media/azure-toolkit-for-intellij-sign-in-instructions/I04.png

[A01]: ./media/azure-toolkit-for-intellij-sign-in-instructions/A01.png
[A02]: ./media/azure-toolkit-for-intellij-sign-in-instructions/login_automated.png
[A03]: ./media/azure-toolkit-for-intellij-sign-in-instructions/A03.png
[A04]: ./media/azure-toolkit-for-intellij-sign-in-instructions/A04.png
[A05]: ./media/azure-toolkit-for-intellij-sign-in-instructions/A05.png
[A06]: ./media/azure-toolkit-for-intellij-sign-in-instructions/A06.png
[A07]: ./media/azure-toolkit-for-intellij-sign-in-instructions/A07.png
[A08]: ./media/azure-toolkit-for-intellij-sign-in-instructions/A08.png

[L01]: ./media/azure-toolkit-for-intellij-sign-in-instructions/L01.png
[L02]: ./media/azure-toolkit-for-intellij-sign-in-instructions/L02.png
[L03]: ./media/azure-toolkit-for-intellij-sign-in-instructions/L03.png

