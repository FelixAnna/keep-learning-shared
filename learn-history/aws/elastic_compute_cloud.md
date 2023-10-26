# ec2 instance types

## AMI
    besides aws provided ami, we can create one from ec2 instance.

    owner/launch permissions (public, explitcit or implicit),architecture of os, and block device mapping of all volumes.

    can have any volumes reference EBS volumes in the same region

    ami are region based, but can copy to other region (def and volumes also copied)

    can be sold, need charge for the base image of the ami and the creator of the ami.

## Virtualization Technology
AWS Nitro provide near bare metal performance with hardware virtualization for almost every main hardware (CPU/Netfork IO/Local Storage/ Remote Storage/Interrupts,Timer), compare to software level virtualization (very slow)

## EC2 Instance Types
### General Purpose
balance of compute, memory and networking resources,
    Mxx:  
    Txx: Burstable (Turbo) CPU, 24hours above baseline for free (credit for 24 hours).
    a1.xx / xxg /xxgd : arm based CPU
    Mxxn: improved network

### Computer Optimized
    Cxxx: high performance processor

### Memory Optimized
    Rxxx: up to 768 GB
    Xxx:  up-to-3094 GB, lowest per GB price of memory
    High Memory: up-to 24567 GB (24TB)
    z1d: up-to 384 GB

### Accelerated Computing
    Px / Gx: GPU optimized
    Inf1: amazon built 
    F1: GPU optimized, also support FPGA Features (for machine learning)
    ***  FPGAs contain an array of programmable logic blocks, and a hierarchy of reconfigurable interconnects.

### Storage Optimized
    Ix /Dx/H1: high IPOS

## EBS volumn types

### General Purpose
    for small to medium app

### Provisioned
    for large relational db or nosql

### Throughput Optimized HDD

### Cold HDD
    for no frequently access data

## EBS optimized
    provide dedicated storage network

## instance store
    disk physically attached to the host computer. high IPOS, local storage, always used as temporary storage. easy to lose data.

## EC2 Assume role
    inside EC2 instance, IAM role credentials can be obtained from: 
    http://169.254.169.254/latest/meta-data/iam/security-credentials/rolename

## Placement group
    some ec2 instances created in a same physical location, so they have low network latency.

### Cluster Placement group    
    The default placement group, deploy ec2 instance in same AZ.

### Partition placement groups
    HA, can deploy to multiple az in same region, 
    each partition have it own power and network device. 
    each zone have several partitions.

### Spread Placement group
    Deploy one instance in each rack 
    (single power and network, like partition concept), 
    can spread accross multiple az in same region, 
    for small business

## Cloudwatch
    Monitor instance and gather metrics and logs

## AWS System manager
    run command on selected EC2 instances, support define parameters and used by the command to run on EC2 (need have GetParameter permission, not GetParameters permission)

## Service Relisence
    EC2: run in a single host in single AZ, not relisience
    EBS: created in the same AZ,
    EBS snapshot: store in S3, inside same region replicated across different AZ. could copy manually to different region.
    S3: replicate across multiple AZ in same region( except OneZone class)
    Route53: operate it name servers from edge locations positioned globally.
    Elastic Load Balanacer: regional service, can enable for one or multiple AZs in the same region (when enabled a NLB node and a network interface is provisioned in a special subnet in the selected AZ)
    VPC: spread across AZs in a region, subnet of VPC are in special AZ
    NAT Gateway: implement with redundancy inside a subnet, provide NAT GW in each AZ to provide HA.
    Auto Scaling Groups: can be provisioned across AZs in a region according to config.
    VPN: have multiple VPN endpoints in different AZs in a region, can tolerate single AZ failure.

## Reserved Instance
    can be applied to EC2, RDS, DynamoDB