Azure offers the following VPN gateway SKUs:

|**SKU**   | **S2S/VNet-to-VNet<br>Tunnels** | **P2S<br>Connections** | **Aggregate<br>Throughput Benchmark** |
|---       | ---                             | ---                    | ---                         |
|**VpnGw1**| Max. 30                         | Max. 128               | 650 Mbps                    |
|**VpnGw2**| Max. 30                         | Max. 128               | 1 Gbps                      |
|**VpnGw3**| Max. 30                         | Max. 128               | 1.25 Gbps                   |
|**Basic** | Max. 10                         | Max. 128               | 100 Mbps                    | 
|          |                                 |                        |                             | 

- Aggregate Throughput Benchmark is based on measurements of multiple tunnels aggregated through a single gateway. It is not a guaranteed throughput due to Internet traffic conditions and your application behaviors.

- Pricing information can be found on the [Pricing](https://www.azure.cn/pricing/details/vpn-gateway) page.

- SLA (Service Level Agreement) information can be found on the [SLA](https://www.azure.cn/support/sla/vpn-gateway/) page.

<!-- ms.date: 09/01/2017 -->