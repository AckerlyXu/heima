Memory optimized VM sizes offer a high memory-to-CPU ratio that are great for relational database servers, medium to large caches, and in-memory analytics. This article provides information about the number of vCPUs, data disks and NICs as well as storage throughput and network bandwidth for each size in this grouping. 
<!-- Not Available M-Series -->
<!-- Not Available on G, GS series -->
* Dv2-series, D-series, and the DS counterpartsare ideal for applications that demand faster vCPUs, better temporary storage performance, or have higher memory demands.  They offer a powerful combination for many enterprise-grade applications.

* D-series VMs are designed to run applications that demand higher compute power and temporary disk performance. D-series VMs provide faster processors, a higher memory-to-vCPU ratio, and a solid-state drive (SSD) for temporary storage. For details, see the announcement on the Azure blog, [New D-Series Virtual Machine Sizes](https://azure.microsoft.com/blog/2014/09/22/new-d-series-virtual-machine-sizes/).

* Dv2-series, a follow-on to the original D-series, features a more powerful CPU. The Dv2-series CPU is about 35% faster than the D-series CPU. It is based on the latest generation 2.4 GHz Intel Xeon® E5-2673 v3 (Haswell) processor, and with the Intel Turbo Boost Technology 2.0, can go up to 3.1 GHz. The Dv2-series has the same memory and disk configurations as the D-series.


<!--PENDIND ON Esv3-series, Updte carefully -->

## Esv3-series <sup>1</sup>

ACU: 160-190

ESv3-series instances are based on the 2.3 GHz Intel XEON ® E5-2673 v4 (Broadwell) processor and can achieve 3.5GHz with Intel Turbo Boost Technology 2.0 and use premium storage. Ev3-series instances are ideal for memory-intensive enterprise applications.

| Size             | vCPU | Memory: GiB | Temp storage (SSD) GiB | Max data disks | Max cached and temp storage throughput: IOPS / MBps (cache size in GiB) | Max uncached disk throughput: IOPS / MBps | Max NICs / Expected network bandwidth (Mbps) |
|------------------|--------|-------------|----------------|----------------|-----------------------------------------------------------------------|-------------------------------------------|------------------------------------------------|
| Standard_E2s_v3  | 2      | 16          | 32             | 4              | 4,000 / 32 (50)                                                       | 3,200 / 48                                | 2 / 1,000                                   |
| Standard_E4s_v3  | 4      | 32          | 64             | 8              | 8,000 / 64 (100)                                                      | 6,400 / 96                                | 2 / 2,000                                   |
| Standard_E8s_v3  | 8      | 64          | 128            | 16             | 16,000 / 128 (200)                                                    | 12,800 / 192                              | 4 / 4,000                                       |
| Standard_E16s_v3 | 16     | 128         | 256            | 32             | 32,000 / 256 (400)                                                    | 25,600 / 384                              | 8 / 8,000                                       |
| Standard_E32s_v3 <sup>2</sup> | 32     | 256         | 512            | 32             | 64,000 / 512 (800)                                                    | 51,200 / 768                              | 8 / 16,000                             |
| Standard_E64s_v3 <sup>2,3</sup> | 64     | 432         | 864            | 32             | 128,000/1024 (1600)                                                   | 80,000 / 1200                             | 8 / 30,000                             |

<sup>1</sup> Esv3-series VM's feature Intel® Hyper-Threading Technology

<sup>2</sup> Constrained core sizes available 

<sup>3</sup> Instance is isolated to hardware dedicated to a single customer.
<!--PENDIND ON Esv3-series, Updte carefully -->

<!--PENDIND ON Ev3-series, Updte carefully -->
## Ev3-series <sup>1</sup>

ACU: 160 - 190 

Ev3-series instances are based on the 2.3 GHz Intel XEON ® E5-2673 v4 (Broadwell) processor and can achieve 3.5GHz with Intel Turbo Boost Technology 2.0. Ev3-series instances are ideal for memory-intensive enterprise applications.

Data disk storage is billed separately from virtual machines. To use premium storage disks, use the ESv3 sizes. The pricing and billing meters for ESv3 sizes are the same as Ev3-series. 

| Size            | vCPU | Memory: GiB | Temp storage (SSD) GiB | Max data disks | Max temp storage throughput: IOPS / Read MBps / Write MBps | Max NICs / Network bandwidth |
|-----------------|-----------|-------------|----------------|----------------|----------------------------------------------------------|------------------------------|
| Standard_E2_v3  | 2         | 16          | 50             | 4              | 3000/46/23                                               | 2 / 1,000                 |
| Standard_E4_v3  | 4         | 32          | 100            | 8              | 6000/93/46                                               | 2 / 2,000                 |
| Standard_E8_v3  | 8         | 64          | 200            | 16             | 12000/187/93                                             | 4 / 4,000                     |
| Standard_E16_v3 | 16        | 128         | 400            | 32             | 24000/375/187                                            | 8 / 8,000                     |
| Standard_E32_v3 | 32        | 256         | 800            | 32             | 48000/750/375                                            | 8 / 16,000                 |
| Standard_E64_v3<sup>2</sup> | 64        | 432         | 1600           | 32             | 96000/1000/500                                           | 8 / 30,000           |

<sup>1</sup> Ev3-series VM's feature Intel® Hyper-Threading Technology

<sup>2</sup> Instance is isolated to hardware dedicated to a single customer.

<!--PENDIND ON Ev3-series, Updte carefully -->
<!-- Not Available ## M-series* -->
<!-- Not Available ## GS-series*-->
<!-- Not Available ## G-series-->
## DSv2-series <sup>1</sup>
<!-- NOTICE: 最大 NIC 数/预期网络带宽 (Mbps) SHOULD BE (Mbps) -->
ACU: 210 - 250

| Size | vCPU | Memory: GiB | Temp storage (SSD) GiB | Max data disks | Max cached and temp storage throughput: IOPS / MBps (cache size in GiB) | Max uncached disk throughput: IOPS / MBps | Max NICs / Expected network bandwidth (Mbps) |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Standard_DS11_v2 |2 |14 |28 |8 |8,000 / 64 (72) |6,400 / 96 |2 / 1500 |
| Standard_DS12_v2 |4 |28 |56 |16 |16,000 / 128 (144) |12,800 / 192 |4 / 3000 |
| Standard_DS13_v2 |8 |56 |112 |32 |32,000 / 256 (288) |25,600 / 384 |8 / 6000 |
| Standard_DS14_v2 |16 |112 |224 |64 |64,000 / 512 (576) |51,200 / 768 |8 / 12000 |
| Standard_DS15_v2 <sup>2</sup> |20 |140 |280 |64 |80,000 / 640 (720) |64,000 / 960 |8 / 25000 <sup>3</sup> |
<!-- Please acknowledge that DSv2 Max Disk Count are 8,16,32,64,64 -->

<sup>1</sup> The maximum disk throughput (IOPS or MBps) possible with a DSv2 series VM may be limited by the number, size and striping of the attached disk(s).  For details, see [Premium Storage: High-performance storage for Azure virtual machine workloads](../articles/virtual-machines/windows/premium-storage.md).

<sup>2</sup> Instance is isolated to hardware dedicated to a single customer. 

<sup>3</sup> 25000 Mbps with Accelerated Networking.

<br>

## Dv2-series

ACU: 210 - 250

| Size              | vCPU | Memory: GiB | Temp storage (SSD) GiB | Max temp storage throughput: IOPS / Read MBps / Write MBps | Max data disks / throughput: IOPS | Max NICs / Expected network bandwidth (Mbps) |
|-------------------|-----------|-------------|----------------|----------------------------------------------------------|-----------------------------------|------------------------------|
| Standard_D11_v2   | 2         | 14          | 100            | 6000 / 93 / 46                                           | 8 / 8x500                         | 2 / 1500                     |
| Standard_D12_v2   | 4         | 28          | 200            | 12000 / 187 / 93                                         | 16 / 16x500                         | 4 / 3000                     |
| Standard_D13_v2   | 8         | 56          | 400            | 24000 / 375 / 187                                        | 32 / 32x500                       | 8 / 6000                     |
| Standard_D14_v2   | 16        | 112         | 800            | 48000 / 750 / 375                                        | 64 / 64x500                       | 8 / 12000          |
| Standard_D15_v2 <sup>1</sup> | 20        | 140         | 1,000          | 60000 / 937 / 468                                        | 64 / 64x500                       | 8 / 25000 <sup>2</sup> |
<!-- Please acknowledge that Dv2 Max Disk Count are 8,16,32,64,64 -->

<sup>1</sup> Instance is isolated to hardware dedicated to a single customer. 

<sup>2</sup> 25000 Mbps with Accelerated Networking.

<br>

## DS-series <sup>1</sup>

ACU: 160

| Size | vCPU | Memory: GiB | Temp storage (SSD) GiB | Max data disks | Max cached and temp storage throughput: IOPS / MBps (cache size in GiB) | Max uncached disk throughput: IOPS / MBps | Max NICs / Expected network bandwidth (Mbps) |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Standard_DS11 |2 |14 |28 |8 |8,000 / 64 (72) |6,400 / 64 |2 / 1000 |
| Standard_DS12 |4 |28 |56 |16 |16,000 / 128 (144) |12,800 / 128 |4 / 2000 |
| Standard_DS13 |8 |56 |112 |32 |32,000 / 256 (288) |25,600 / 256 |8 / 4000 |
| Standard_DS14 |16 |112 |224 |64 |64,000 / 512 (576) |51,200 / 512 |8 / 8000 |
<!-- Please acknowledge that DS Max Disk Count are 8,16,32,64 -->

<sup>1</sup> The maximum disk throughput (IOPS or MBps) possible with a DS series VM may be limited by the number, size and striping of the attached disk(s).  For details, see [Premium Storage: High-performance storage for Azure virtual machine workloads](../articles/virtual-machines/windows/premium-storage.md).

## D-series

ACU: 160

| Size         | vCPU | Memory: GiB | Temp storage (SSD) GiB | Max temp storage throughput: IOPS / Read MBps / Write MBps | Max data disks / throughput: IOPS | Max NICs / Expected network bandwidth (Mbps) |
|--------------|-----------|-------------|----------------|----------------------------------------------------------|-----------------------------------|------------------------------|
| Standard_D11 | 2         | 14          | 100            | 6000 / 93 / 46                                           | 8 / 8x500                         | 2 / 1000                     |
| Standard_D12 | 4         | 28          | 200            | 12000 / 187 / 93                                         | 16 / 16x500                         | 4 / 2000                     |
| Standard_D13 | 8         | 56          | 400            | 24000 / 375 / 187                                        | 32 / 32x500                       | 8 / 4000                     |
| Standard_D14 | 16        | 112         | 800            | 48000 / 750 / 375                                        | 64 / 64x500                       | 8 / 8000                |
<!-- Please acknowledge that D-series Max Disk Count are 8,16,32,64-->
<!-- NOTICE: 最大 NIC 数/预期网络带宽 (Mbps) SHOULD BE (Mbps) -->

<br>
<!--Update_Description: wording update, update link -->
<!--ms.date: 03/19/2018-->
<!--PENDING to EV3 configuration list-->