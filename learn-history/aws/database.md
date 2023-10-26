## EC2 Database
	Run any database with full control and utimate flexibility, but need manage everything about the database(backups/redundancy/patching/scale), 
	good if db not supported by RDS, such as IBM DB2, SAP HANA.
	
## RDS
	managed database service support mysql/sql server/ oracle/ ....
	automated backups / patching in customer defined maintenance windows;
	support config autoscaling, replication, redundancy.
	Multiple AZ replication: standby instances, use sync replication;
	Global Replication: read replicas, use Async Replication.
	
	master on a AZ failed, standby in same region becomes master automatically; whole region failed, read replica becomes master manually.

	Need deployed into a subnet group (create first).

	Storage Type:
	General Purpose: performance / iops scale depending on the size.
	Provisioned: archieve high performance/ iops even with small size.

	Encryption: encrypt EBS used by the DB instance

	Able to choose reserved instance

	Automatic Backup: real point in time recovery (backup volume + transaction log).

	Explict volume snapshot backup not support point in time recovery.

	integrated with cloud watch: able to use standard / enhanced monitoring,

	Restore snapshot need restore to new DB (not to existing DB)

	master-slave: synchronous replication (can )
	read-replica: asynchronous replication (can cross region, can have different db version)

	aurora: 
		master + read replicas (can use read replicas to read data, not like other RDS --), 
		support multiple master mode in future(multiple write), Mysql & PostgreSQL compatible Amazon RDS, 
		Utilizes Cluster Storage Volume - faster than RDS, 
		backtrack to previous state, 
		support auto scalling read replicas.
		aurora global database - delegate replicate server/agents to  provide more read replicas in another region,
		(Allows a single Amazon Aurora database to span multiple AWS Regions)
		support serverless capacity type (also can connect via Data API).

 	on 2022 mysql also support multi-AZ standby or read replicas, standby instances doesn't serve read traffic, but can be used as failover when planned or unplanned changes

## DynamoDB
	Autoscaling nosql database. Managed multi AZ, with Cross-Region Replication option. 
	Default eventual consistency, support change to strongly consistency.
	priced on Throughput (IOPS), autoscale capacity adjusts per configured min/max levels.
	Support On-Demand Capacity;
	DynamoDB Transactions support ACID compliance;
	Need Primary Key must be unique.
	Also have sort key like timestamp;
	Primary key can be partition key(like orderId), also can be Partition Key + sort key (this key is optional);
	
	Index also have performance (RWU) allocated.
	RWU distributed between partitions(ex: 9000 read, 3000 on 3 partition each)
	Global Secondary Index: index on columns which is not a primary key for query; (query by global secondary key only)
	Local Secondary Index: when we already know the partition key, we want retrive only these records with some other attribute. (query by primarykey + local secondary key)
	
	Projection: a global/local Secondary Index can have up to 20 attributes projected with that index;
	
	// Can create table replicas via Global Secondary Index.
	billing on storage and performance consumed (read/write)
	
	Query can only query a single partition key. while scan can show all items in a table, filter on scan still will consume all size of data read cost.
	
	backup table data and performance data;
	default not encrypted;
	support purchase reserved capacity.

	Autoscaling: min/max read/write capacity basis on the load. otherwise use on-demand mode.
	Adaptive Capacity: partition can borrow RCU/WCU if performance less then table capacity, enabled by default.
	Streams: can be used to store changes (key, old image, new image or both)
	trigger can be enable on the top of stream to call a lambda
	TTL is a mechanism to enable expiration of items based on a timestamp attribute in the table

	Global tables allow replica tables in multiple regions. Works as multi master tables. Need streams enabled and regions added before adding any data
	//Can remove replicas after deleting. //Deletion only stops replication.

	DynamoDB accelerator (DAX) can be used to enable caching similar to ElastiCache

## Redshift
	
	Managed, Clusterd data warehouse, cost effective compare with on-prem dw;
	PostgreSQL compatible, compatible with most BI tools;
	Parallel processing & columnar data store
	Option to query directly from S3 via Redshift Spec
	
	Redshift Spectrum: help query raw data, then use by analytics tools.
	
## Neptune
	Managed Graph Database, support Gremlin ...

## Elasticache
	managed implementions for Redis / Memcached
	Scalability for memory, writes and reads.
	Billed by node size and hours of use
	Redis support encryption at rest. both support encrypt in transit
	Memcached: multip-thread, multiple instances.
	Redis: single-thread, multiple instances, auto failover

## Amazon Athena
	SQL Engine overlaid on s3 base on Presto (an open source distributed SQL engione for BigData)
	Similar in concept to Redshift Spectrum, but not support join with other data source,
	while Redshift Spectrum can join s3 data with Redshift tables.
	
	It will work with a number of data formats including "JSON", "Apache Parquet", "Apache ORC" amongst others, but "XML" is not a format that is supported.
	
	Athena support query many AWS service logs, like VPC, CloudFront, WAF, ELB, CloudTrail, S3 logs....
	
## EMR - Elastic MapReduce
	Managed Hadoop/Hive/HBase/Presto Cluster
	Master Node: Act as HDFS Name node, control the distribution of workloads and monitor the component health
	Core Node:  Act as HDFS data node, perform tasks within a cluster
	Task Node: optional, suited for spot instance, compute occurs on task node.

	data can be retrived from s3 and output to s3, imtermediate data can be stored on HDFS or EMRFS.

	by default all cluster node in a same AZ to allow efficient communication.

## Amazon Quantum Ledger Database
	Based on blockchain concept, provide an immutable and transparent journal as a service;
	ACID based DB;
	Serverless product;
	But use centralized design for higher performance and scalability.
## Amazon Managed Blockchain
	fullay managed blockchain framework, use Ledger database to maintain complete history.
## Amazon Timestream Database
	for storing and analyzing time-series data

## DocumentDB
	MongoDB compatibility, auto backup settings up to 35 days, point-in-time recovery in backup period (also use cluster storage volume) to seperate cluster, upt-to 15 read replicas. auto failover if primary fails.
	scaleup instance supported.

## ElasticSearch
	Document store and search engine