<!-- F-series, Fs-series* -->

Compute optimized VM sizes have a high CPU-to-memory ratio and are good for medium traffic web servers, network appliances, batch processes, and application servers. This article provides information about the number of vCPUs, data disks, and NICs as well as storage throughput and network bandwidth for each size in this grouping.

F-series is based on the 2.4 GHz Intel Xeon® E5-2673 v3 (Haswell) processor, which can achieve clock speeds as high as 3.1 GHz with the Intel Turbo Boost Technology 2.0. This is the same CPU performance as the Dv2-series of VMs.  

F-series VMs are an excellent choice for workloads that demand faster CPUs but do not need as much memory or temporary storage per vCPU.  Workloads such as analytics, gaming servers, web servers, and batch processing will benefit from the value of the F-series.

The Fs-series provides all the advantages of the F-series, in addition to Premium storage.

<!-- Not Available ## Fsv2-series -->
## Fs-series <sup>1</sup>

<!-- NOTICE: 最大 NIC 数/预期网络带宽 (Mbps) SHOULD BE (Mbps) -->
ACU: 210 - 250

| Size | vCPU | Memory: GiB | Temp storage (SSD) GiB | Max data disks | Max cached and temp storage throughput: IOPS / MBps (cache size in GiB) | Max uncached disk throughput: IOPS / MBps | Max NICs / Expected network bandwidth (Mbps) |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Standard_F1s |1 |2 |4 |4 |4,000 / 32 (12) |3,200 / 48 |2 / 750 |
| Standard_F2s |2 |4 |8 |8 |8,000 / 64 (24) |6,400 / 96 |2 / 1500 |
| Standard_F4s |4 |8 |16 |16 |16,000 / 128 (48) |12,800 / 192 |4 / 3000 |
| Standard_F8s |8 |16 |32 |32 |32,000 / 256 (96) |25,600 / 384 |8 / 6000 |
| Standard_F16s |16 |32 |64 |64 |64,000 / 512 (192) |51,200 / 768 |8 / 12000 |
<!-- Correct the Fs series Max Disk Count 4,8,16,32,64 -->

MBps = 10^6 bytes per second, and GiB = 1024^3 bytes.

<sup>1</sup> The maximum disk throughput (IOPS or MBps) possible with a Fs series VM may be limited by the number, size and striping of the attached disk(s).  For details, see [Premium Storage: High-performance storage for Azure virtual machine workloads](../articles/virtual-machines/windows/premium-storage.md).

<br>

## F-series

ACU: 210 - 250

| Size         | vCPU | Memory: GiB | Temp storage (SSD) GiB | Max temp storage throughput: IOPS / Read MBps / Write MBps | Max data disks / throughput: IOPS | Max NICs / Expected network bandwidth (Mbps) |
|--------------|-----------|-------------|----------------|----------------------------------------------------------|-----------------------------------|------------------------------|
| Standard_F1  | 1         | 2           | 16             | 3000 / 46 / 23                                           | 4 / 4x500                         | 2 / 750                 |
| Standard_F2  | 2         | 4           | 32             | 6000 / 93 / 46                                           | 8 / 8x500                         | 2 / 1500                     |
| Standard_F4  | 4         | 8           | 64             | 12000 / 187 / 93                                         | 16 / 16x500                         | 4 / 3000                     |
| Standard_F8  | 8         | 16          | 128            | 24000 / 375 / 187                                        | 32 / 32x500                       | 8 / 6000                     |
| Standard_F16 | 16        | 32          | 256            | 48000 / 750 / 375                                        | 64 / 64x500                       | 8 / 12000           |
<!-- Correct the F-Series Max Disk Count 4,8,16,32,64 -->
<!-- NOTICE: 最大 NIC 数/预期网络带宽 (Mbps) SHOULD BE (Mbps) -->
<br>
<!-- ms.date: 03/19/2018 -->
<!-- Update_Description: wording update -->