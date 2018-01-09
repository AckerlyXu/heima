---
title: Supportability of adding Azure VMs to an existing availability set | Azure
description: Supportability of adding Azure VMs to an existing availability set.
services: virtual-machines-linux
documentationcenter: ''
author: rockboyfor
manager: digimobile
editor: ''

ms.assetid: 
ms.service: virtual-machines
ms.workload: virtual-machines
ms.tgt_pltfrm: na
ms.devlang: na
ms.topic: troubleshooting
origin.date: 11/03/2017
ms.date: 12/18/2017
ms.author: v-yeche

---
# Supportability of adding Azure VMs to an existing availability set

You may occasionally encounter limitations when you add new virtual machines (VMs) to an existing availability set. The following chart details which VM series you can mix in the same availability set.

Here is the supportability matrix to mix different types of VMs:

Series & Availability Set|Second VM|A|Av2|D|Dv2|Dv3|
|---|---|---|---|---|---|---|
|First VM|||||||
|A||OK|OK|OK|OK|OK|
|Av2||OK|OK|OK|OK|OK|
|D||OK|OK|OK|OK|OK|
|Dv2||OK|OK|OK|OK|OK|
|Dv3||OK|OK|OK|OK|OK|

All other series could not be in the same availability set because they require a specific hardware.

<!--Not Available on A8/A9 -->

<!--Update_Description: update meta properties -->
