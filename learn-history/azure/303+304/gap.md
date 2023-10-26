
### Also support point-to-site connection.
		
#### VPN type
	Policy-based VPNs: for legacy vpn compatibility.

	Route-based VPNs:  more resilient to topology changes.
		
## Azure ExpressRoute
	it construct a private connection from on-premises to cloud connections
	
		
### Application security group

	Group network interfaces (ex: VM have that) together, 
	then in network security group create a inbound or outbound rule by application security group
		
### virtual networking peering
	only connected if have direct peering and both sides. 
	communicate over microsoft backbone infrastructure (not through a gateway or public network, 
		vm in peered network connect directly as is they are in same network, with same latency).


### Route table:

	custom route: define route rules in a route table, and overwrite subnet default routes.
	Border Gateway Protocol to exchange routes between vnet (no example)
	network virtual appliance: a virtual appliance you can choose from azure market place 
			(firewall, load balances, proxies,...),which can filter and forward routes in the middle layer.

### IP Addressing schema

	public ip address type (SKUs):
		basic: open to inbound/outbound by default, (use network security group to restrict), 
				not support for avaiability zone scenarios.
		Standard: close to inbound traffic by default, support avaiability zone scenarios.
		
		
### Hybrid network services:

	ExpressRoute with VPN failover: VPN as failover, ExpressRoute with fast bandwidth
	hub-spoke topology (ExpressRoute/VPN as hub, use jumpbox to connect to peered vnet): 
		hub become the core of business have provide the foundations for much deeper business insight. 
	https://docs.microsoft.com/en-us/learn/modules/design-a-hybrid-network-architecture/6-summary
	
### Disk
		OS disk: for OS.
		Data disk: we can add one or more.
		Temporary disk: each vm have one.
		Performance: 
			Ultra SSD: 
				fastest,high IOPS, low latency (only for vm in availablity zone, in a subnet, used as data disk) 
				up to 160000 IPOS, 2000 MBps Throughput, 64T disk

			Premuim SSD: 
				high performance, 
				up to 20000 IPOS, 900 MBps Throughput, 32T disk
				7500IPOS, 250 MBps Throughput 2T
				performance figures are guaranteed

			Standard SSD: 
				high performance
				up to 6000 IPOS, 750 MBps Throughput, 32T disk
				500IPOS, 60 Throughput 2T
				Not guaranteed

	
## Automate our business processes
### Design first
	Logic Apps: a service we can use to automate, orchestrate, 
		and integrate disparate components of a distributed application. 
		can design or write less code. 
		have many connectors we can communicate to external service (like twitter..), 
		also support define customer connector.
	Microsoft Power Automate: create workflow, like logic app, but not support coding.

## High performance computing - HPC

### HPC Pack
	allow batch runs on cloud and on-premise HPC instances.

### VM size
	Hxxx: farest CPU, high-thoughput network, HPC, support RDMA.
	Nxxx: GPU optimized, for graphic/video/model trainning for deep learning.
	Lvs2: Storage optimized, high throughput/ipos, great for nosql, and large transactional db;
	Gxxx: Memory + Storage optimized VMs.(32u+512G)
	Exxx/MXX: Memory optimized, greate for sql db, cache, in-memory analytics;
	Fxxx: compute optimized, High CPU-to-memory ratio, meduim traffic web/application
	Bxxx or Dxxx: general purpose, for testing, development, small traffic web/application
	Dxx: Optimal CUP-to-memory configution, can run most of production workloads. 
		(consider a little weak then Hxxx series)
	Bxx: burstable, can scale up/down without resizing.

### VM boot diagnostics
	Not support premium or zone redundant storage account, aslo need in same region

	
## Service Trust Portal
	 contains microsoft cloud service related audit / compliance report, 
	 also have entry for Compliance Manager.

## Compliance Manager
	 track, assign and verify our organization's compliance activities 
	 related to microsoft professional servics and cloud service.

## Service Health
	notify and help you understand about azure service issue, 
	and keep us updated when that resolved. 
	help us prepare for planned maintenance and changes 
	which could affect our availability.
	
## Security Center
	manage the security of your infrastructure from a centralized location 
	(on-premise or in cloud), 
		for PaaS, it is integrated by default
		for IaaS, please enable "automatic provisioning" to install a service on the VM so it can 
		collect data from that machine.
	
	Securty Center can:
		monitoring cloud and on-premise workloads;
		automatically apply security setting to new onboarded resources;
		provide security recommandations;
		use machine learning to detect malware process on your VM;
		detect any potantial threats or breaches;
		provide JIT access control for network ports.
		(security here also contains goverment policies)
	
	In security center, we can find threats, and response automatically to that 
	by create logic app
	

## Azure Sentinel
	 for analyze enterprise security cross cloud provide or on-premise, 
	 need first setup a log Analytics workspace, 
	 then added to Sentinel, 
	 finally add different resources.
	 Connect to data source -> detect threats -> investigate and response
	
## Azure Monitor(collect Metric, Logs)
	Alert(resource, condition, action, alert details):
		Metric Alert: trigger when a defined threshold is exceeded.
		Activity Log Alert: trigger when a defined azure resource changed state.
		Log Alert: base on things write to log files.
	Smart groups: using machine learning algorithms, 
		join alert base one repeat occurrence and similarity automatically.
	Alert state: New, Acknowledged, Closed.
	Query: Logs using Kusto to query by resource and conditions, Metric support filter.

# data platform
	

## Azure postgreSQL/SQL: 
		base on community edition db engine

## cosmos db: 
		create a cosmos db account first, select an API (SQL/mongo/etc.), create database, create container with partition key, then CURD data.
			RU: request units, 
			if exceeding RU, request will be limited.

			Cosmos Stored procedures: 
				they are javascript functions with document context, they are the only way to ensure ACID transactions runs on server.
			UDFs(user-defined function) are also on server, but they dont have document context, they can only support implement some reusable calculations.
		
## Azure synapse analytics: 
		with a SQL pool using data warehouse units (DWU: bundle CPU+memory+throughput, maximum 30000), adjust the DWU and storage seperately.
	
		Massively parallel processing(Control node + cumpute nodes with Data movement service: DMS ), workload management (control resource/importance level/timeout for queries), result-set cache(cache query result in SQL pool storage), materialized views(keep an up to date pre-compute data), CI/CD use database project to track/deploy/test schema changes...

		obtain source data -> update to blob storage -> get storage account access key + resource url -> open synapse query editor -> (Using PolyBase then) create an database credential using the access key -> create an datasource using the resource url + credential created ->
		
		create a file format -> create a temp table with the datasource created + file format created -> create an destination table from temp table -> query or add statistics then query.
	
		to increase upload speed, we can split the file and define parallel upload + import processes.

# Severless app, Message & event

## Benefit of queues
	 increased reliability, message delivery guarantees(At-Least-Once, At-Most-Once, FIFO),Transactional support.

# Containerized Service in Azure(PaaS), Redis

### Dockerfile:

    RUN: execute a command in the container;
    ENTRYPOINT: container will run the command when it start;
    CMD: command triggers while we launch the image.

## Container
    immutable: once build can deploy and run with same behaviour in different env;
    lightweight: not like vm have os, it only have applications rely on the host OS for kernal specific services.
	

## Azure Cache for Redis
    support transaction(ensure multiple message queue and then send together)

    Transaction: just ensure they queued together, but not ensure they all executed successfully.

# API Management

Azure API Gateway is an instance of Azure API Management service we need create.

## Pricing
    besides Basic/Standard/Premium tier, we can also user developer and Consumption tier.
    Developer: no scale units;
    Basic: 2 scale units, 1000 requests/sec, 99.9% SLA;
    Standard: 4 scale units, 2500 requests/sec, 99.9% SLA;
    Premium: Multi region deployment, 99.95% SLA, 4000 requests/sec, 10 scale units per region;
    Consumption: pay for waht we use, dont have dedicated resource, setup in seconds, built-in high-availability, auto-scaling.
    

# Migration, Business Continuity, Disaster Recovery


## Azure Site Recovery
    Replicate workloads between a primary and secondary site.
    setup and manage replication settings, failover and failback in azure portal.
        Service Recovery Vault: use storage account to keep data backup, configuration settings and workloads;
        Target Resources;
        Configure network outbound conectivity;
        Set up replication on existsing VMs (install certification and mobility service)
        create recovery plan..
        
##  VM backup:
            App consistent / File system consistent / Crash consistent (doesnt guarantee OS and app data consistency)
        Policy:
            Snapshot tie: only store in local for up to 5 days;
            Vault tier: additionaly transfer to vault for security and longer retention.


## SQL backup
        store backups in RA-GRS storage account, once database created, backup immediately.

        App Server Autoscaling:
          
            Multiple Rules: Scale Out/Up if one rule match, Scale Down/In if all rule macth;
			
            App Service Plan:
                free: 1GB disk space, up to 10 apps, a single shared instance, no SLA , 60 min/day
                shared: upto 100 apps, 240 min/day, no SLA;
                Basic: 3 dedicated instances, 99.95%SLA, unlimited apps;
                Standard: 10 dedicated instances, 99.95%SLA;
                Premium: 20 dedicated instances, 99.95%SLA;
                Isolated: 100 dedicated instances, 99.95%SLA;

## Design a geographically distributed architecture

### Application Gateway
    not global distributed;

### Azure Storage Queues
    GRS or GZRS storage account (async copy);
        Redis Cache: create in both Region;

### Azure SQL Database: 
      geo-replication: the primary is writable, secondary is readonly (can manually change, or change in code, cannot automatically failover)

      auto failover groups: like geo-replication, but we can define a policy to make the secondary writable.
        
### Azure Cosmos DB:
            choose multiple-region accounts with multiple write regions;
            Multiple-region accounts with a single write region (we can enable automatic failover option)

            in Cosmos, data sync is synchronous,  when a change is applied, the transaction is not considered complete until replicated to a quorum of replices, then an ackownledgement is sent to the client
### Aure migrate
    VM Disk: 
        must disable bitlock; 
        OS disk less then 2TB, 
        data disk less than 32TB, 
        UEFI-boot OS Disk can be up to 4GB;
    prepare migration
        always install appliance/provider on cluster;
        for Microsoft Azure Recovery Service agent, need install on node or Hyper-V host.

    create migrate project:
        create migrate project -> select assessment tool -> select migration tool;
    prepare:
        install: install appliance on cluster;
        config: configure and connect to migration project;
        connect: connect appliance to VMWare VCenter Server; 
    migration:
        replicate each vm to azure;
        run a test migration;
        migrate the vms and complete the migration;


# Knowledge gap found in practices

## Service Fabric:

    Microsoft Container Orchstator for deploying and managing microservice across a cluster of machines.
    Support Tier:
        Bronze: minimum 3 nodes, can scale up to Silver or Gold;
        Silver: minimum 5 nodes, can scale up to Gold, not able to scale down;
        Gold: minimum 7 nodes, can scale down to Silver.

## GRS (geo-redundant storage):

    Replicate data to the paired region, nearly all paired region in the same geo-political boundary
    (besides Brazil South paired with South Central US)

## Storage:

    you can config blob storage policies to require time-based retention, blob storage/storage account v2 also support point in time restore.


## Azure SQL Database (Azure SQL Database single instance):

    Transparent Data Encryption: protect data at rest;

    DTU-based service tier:
        Premium: support in-memory OLTP and columnstore index
		... up to 32GB (4000 DTUs)
        1000 DTUs: up to 8GB in-memory OLTP storage per pool;
        500 DTUs: up to 4GB...
        125 DTUs: up to 1GB...

    Support Hyperscale (up to 4 read replicas)

## Azure SQL Database elastic pool

    A pool for multiple database on a single server. Support DTU and vCore based model.
    DTU based:
        basic: 1600 DTU
        standard: 3000 DTU
        premium: 4000 DTU
    VCore Based: 2-80cores,1-512GBspace
    Business Critical: 4-80cores, 1G-1T space


## SQL Server on VM
    Always On Availability groups, provide HA, DR and read-scale balancing.
    Mirror is not recommanded (not supported in feature).

    Standard Load Balance (required if sql server VMs ar in different availability zone), 
    or Basic Load Balance (sql server VM in a same availability set).

## Azure Migration Tools:

    Azure Migrate: discory, assess and migrate vm servers, physical servers to azure.
    Web app migration assistant: assess ad migrate web apps;
    Azure Data Block: migrate large amount of data.
    (no tool for migrate non-relational database)

## Azure Active Directory(Azure AD)

    Access Review: can be perforem once or periodically to remove users who no longer need access (or be a membership), 
    	use whom review is not performed also can be removed automatically.

    Azure AD Identity Protection: detect and prevent risky sign-ins.(Azure AD Premium P2 license)

    Conditional Access: control access to cloud apps, specify who and from which device,
		and other conditions that must met before the user can access the app (include MFA).

    Azure AD Privileged Identity Management: JIT, time-bound access to resource, 
	    required approval to active priviledged roles, 
	    notification when priviledged roles activited, 
	    Access audit history. (Azure AD Premium P2 license)

    Azure AD Connect (help integrate your on-premise directories with Azure AD): 
        Password hash synchronization;
        Pass-through authentication:
            (complex then Password hash sync,require install agent on an on-premise server);
        Federation integration;
        Sychronization；
        Health Monitoring (Azure AD Connect Heath is a premium feature).
    Prerequisite: domain controller or joined domain member with Server 2012+, with full GUI interface.
    
    Self-service Password Reset: allow end users to reset their password easily (not include on-premise admin).
        SSPR writes back: write back password to on-premise AD via Azure AD Connect Service.
    
    Authentication Methods: config smart lock-out, banned password, password protection...

## BC DR

    Data Protection Manager: backup date to on-premise storage or azure storage, 
		also support backup data to Azure Backup Vault;
		help restore data to the original source when outage occurs or the service unavailable. 
		support bare-metal backups of physical server with windows os.

    Azure Backup Vault: helps backup you data and recovery it from Azure Cloud. 

    Azure Site Recovery Service agent: can backup data, but not support bare-metal backup.

    Azure Site Recovery Provider: used for replicate VM to Azure, not for creating backup.

    Date Explorer: enable us view telemetry data in Azure.

## AzCopy

     A command line tool to copy files and blobs to or from Azure storage accounts.
	
## Event Hub , Event Grid, Service Bus

    Event Hub: Telemetry and distributed data streaming (but not IoT, IoT have IoT Hub)
    Event Grid: React to status changes
    Service Bus: Order processing and financial transactions

## Azure Migrate Appliance

    discover and assess on-premise servers, 
	only install on on-premise server, only one install is needed even have multiple location.
    it write the data it collected to CosmosDB.

## Network-intensive solution

    RDMA： Remote Direct Memory Access, allow computers exchange data in main memory directly 
		without involving the processor, cache or OS.

    some Hxx series and A8, A9, Nxx series vms support RDMA.

    some Hxx and Fxx series also can have 4 or more NICs.

    if not support RDMA, Enable configure for Accelerated Networking is another option.

## App Service, VM Scale Set

    App service: up to 100 instances;
    VM Scale Set: up to 1000 instances, support multiple datacenters high availability.

## Azure File Sync

    A service allow us cache a number of azure file shares to on-premise windows servers or cloud VM

## Azure Hybrid Benefit on the VMs

    saving cost by leveraging existing on-premise license, so you just pay for the infrastructure cost.

## MFA features

    Mobile APP / SMS / Phone as second factor / Remember trusted devices/admin control over verification methods: 
		office 365 apps/ Azure AD Global Admin/ Azure AD Premium P1 or P2

    others(Fraud alerts, MFA reports, customer call, trusted IPs, MFA for on-premise applications): 
		Azure AD Premium P1 or P2 license

## Microsoft Graph API

    Microsoft Graph API:
        Exposes REST APIs to access data on many Microsoft 356 services, including Azure AD Identity Protection.
    
    Azure AD API:
        Grant permission to Azure AD, read directory data, read/write devices/groups...

## Key Vault:

    Backup and restore works if they are in the same geography and subscription.
    (You CANNOT backup a secret from a key vault from one region and restore to another region in a different geographfy or subscription)
	otherwise you need download and import to bypassing the restriction.

## IoT hub

    Provide communicate between IoT (internet of Things) devices and IoT Application(like Stream Analystics).
	
	IoT Central: build base on IoT hub, provide Central UI (Management Center) so we can monitoring and interactive with IoT device.
	IoT Sphere: IoT security solution with hardware, OS, cloud component.


## ExpressRoute Global Reach
    To enable ExpressRoute Global Reach between different geopolitical regions(not geographical region), your circuits must be Premium SKU.
    
    If data not in different geo-political regions, then dont need premium SKU version.

   
# Knowledge foun in AZ-303 practice

## IP Address
    Static/Dynamic
    Basic: not support available zones, Standard: support available zones.

## Performance Counter (send to azure monitor)
    Windows: Diagnostics extension
    Linux: Telegraf agent

## DNS verify
    When you ask azure to verify a custom domain, it issues DNS queries for TXT records.
	
## MFA
    MFA in the cloud does NOT support one-time bypass that grant user access;

    if phone lost, we can clear MFA settings and specify a landline as new contact method.

## Security defaults
    Recommand for free AAD license, available for all version, for Premium, you should use conditional access instead.

    protect your tenant against common identity-related attacks.
    (config include enable MFA)

## guest users
    to enable MFA for guest users from another tenant, enable MFA in the source tenant (another tenant)

## Seamless SSO
    Seamless SSO only support pass-through and password hash sync methods, NOT support federation XXX.

## AAD Connect Staging mode
    for validate the connect before make it active, need disable then.

## Get-AzLog
    retrive activity log events.

## az role define and create
    az role definition create ...
    az role assignment create ...

## Ruby2.6
    Only supported by app service plan on Linux

## App Service Environment (ASE)
    provide isolated environment for app service apps.
	
## Function + Premium tier
    always run the function on warm instances.
	
## elastic transactions
    run transactions across several Azure SQL Databases.
    horizontal partitioning: when same schema (sharded);
    vertical partitioning: when different tables
	
## Microsoft Distributed Transaction Coordinator
    when transactions accross several on-premise SQL server databases.
	
## Managed SQL Instance
    Support SQL Agent and Database Mail...
## DTU
    number of db * avg dtu = actually DTU (n*100)
    or peak of db * number of peak
