---
 title: include file
 description: include file
 services: vpn-gateway
 author: cherylmc
 ms.service: vpn-gateway
 ms.topic: include
origin.date: 03/29/2018
ms.date: 05/08/2018
ms.author: v-junlch
 ms.custom: include file
---
You can verify that your connection succeeded by using the 'Get-AzureRmVirtualNetworkGatewayConnection' cmdlet, with or without '-Debug'. 

1. Use the following cmdlet example, configuring the values to match your own. If prompted, select 'A' in order to run 'All'. In the example, '-Name' refers to the name of the connection that you want to test.

    ```powershell
    Get-AzureRmVirtualNetworkGatewayConnection -Name VNet1toSite1 -ResourceGroupName TestRG1
    ```
2. After the cmdlet has finished, view the values. In the example below, the connection status shows as 'Connected' and you can see ingress and egress bytes.
   
    ```
    "connectionStatus": "Connected",
    "ingressBytesTransferred": 33509044,
    "egressBytesTransferred": 4142431
    ```

<!-- ms.date: 05/08/2018 -->