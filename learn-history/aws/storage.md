# Storage

## S3
	 S3 is an object store, recommand use multi-part uploads if larger than 100MB.
	 S3 provide an eventual consistency level, multi AZ supported (maybe multiple AZ) data store.
	 updates to a single key are atomic.

	tier: 
	standard, 
	IA - infrequent access, 
	One Zone IA, 
	intelligent tiering: move from frequent and in frequent, pay monthly monitor fee also.
	Glacier(minutes to hours to retrive, 90days min), 
	Glacier Deep Archive (12 hours to retrive, 180day min).

	lifecycle policy: define rules expire, move, delete object to accordingly.

	Versioning: once enable cannot be disabled, only can suspend.
	 add delete mark when delete (unless delete by objectId to hard delete)

	Object lock: enable for new bucket, enable write once read many

	Cross-region replication (system event not replicated, like lifecycle event).

	presigned URL for object in S3.

	Standard (up to 5GB in on connection) 
	Multipart Upload: get upload ID, upload parallel, more reliable;

	Transfer Acceleration: use local cloudfront edge location

	S3 can split object by prefixs (seems like folder), if want archieve high read/write performance, need arrange object naming (in different prefix).
	
### Security
	
	Resource-based (Object ACL, Bucket Policy)
	User-based (IAM policies)
	Optional MFA before delete (when versioning enabled)
	
### Data Protection

	Versioning: new version each write
	MFA for delete or change the versioning state of your bucket
	Cross region replication
	
### Lifecycle Management
	
	Optmize storage cost;
	Adhere to data retention policies;
	Keep S3 volumes well-maintained;
	
	archieve this by define rules (base on prefixes, tags, current verisons, previous versions...) and apply to objects, transition between different storage classes/tiers, or transition at L2, archive, delete, expire version based object)
	
### Analytics
	Data Lake Concept: work with Athena, Redshift Spectrum, QuickSight
	IoT Streaming Data Repo: Kinesis Firehose
	Machine Learning and AI storage: Rekognition, Lex,MxNet...
	Storage Class Analysis: S3 Management Analytics (assess what data gets access frequently or infrequently, you can change that data storage class over to a cheaper class of storage.)

### Encryption at Rest
	
	Default use built-in encryption key (AES-256 key)
	support upload/create customize AES-256 key
	use key generated and managed by AWS KMS (Key Management Service)
	encrypt at client side then upload to S3.
	
### S3 Tricks
	
	Transfer Acceleration: use CloudFront in reverse to speed up data upload;
	Request Pays: the requester pays for request and data transfer;
	Tags: assign to objects for costing, billing, security, management purpose;
	Events: trigger notification to SNS, SQS, or lambda when certain event happen in your bucket;
	Static Web Hosting: 
	BitTorrent: supports the BitTorrent protocol, generate a .torrent file to distribute objects to other users, then leveraging the peer-to-peer distribution network.
		
### Server access logging 
	provides detailed records for the requests that are made to a bucket, 
	when enabled, will send log to another S3 bucket, will also grant S3 log delivery group read/write permission on target buckets so it can send log.

## Glacier
	
	Archieve storage,
	Integrated with S3 via Lifecycle Management
	Glacier Vault: like S3 bucket
		archive: like s3 object
	Glacier vault lock: 24hours to confirm, once confirmed not able to change later, it is immutable (can be overwrite or delete), can enforce MFA or no deletes (immutable)
	
## Elastic Block Store
	Virtual hard drivers can only be used with EC2, tied to Single AZ (not provide multi AZ redundancy for your data), Snapshots feature, write data over network;
	Snapshots:
		Cost-effective and easy to backup;
		Share data sets with other accounts or users;
		Migrate a system to new AZ or Region;
		Convert unencryoted volume to encrypted volume.
	Amazon Data Lifecycle Manager
		allow us to schedule snapshot for volume every few hours, and also provide some retention rules to remove some old snapshots.
	Can only attached to one EC2 in same AZ at a time.

## EC2 Instance Storage
	Temporary, for cache, buffers, directly attached volume
	
## Elastic File System
	Implemention of NFS file share, have Elastic storage capacity, only pay for what you use (incontrast to EBS)
	Distributed across multiple AZs in a given region.
	Data Replicated across the AZ in a region.
	Can config mount point in EC2 in one or many AZs (Create EFS mount targets in each AZ and configure each EC2 instance to mount the common mount target FQDN).
	Mount from on-prem (support, but not secure and stable, so recommand Amazon DataSync)
	No Secure.
	No support for Windows.
	Price: 1 EFS = 3*EBS = 20*S3
	
## Amazon FSx
	like EFS, but spport share storage to Windows, not relisient by default, but have ways to enable replication.

## Amazon DataSync
	A service to keep storage on-prem in sync with EFS, FSx or S3 over direct connect or internet securely.
	(Not for datastore, for data transfer)
	
## Storage Gateway
	a VM you can run on-premise, provide local storage backed by S3 and Glacier. 
	Often used in disaster recovery preparedness to sync to aws 
	(a easy way to sync data from on-premise to cloud, if there is a disaster, then data already in AWS, easy to failover).
	also a lazy way to sync data to aws when do cloud migration.
	modes:
		File Gateway: NFS or SMB share while EC2 can mount and wite object to S3
		(ISCSI for below 3)
		Volume Gateway Stored Mode: async replicate data to s3
		Volume Gateway Cached Mode: primary data stored in s3, frequently access data cached on-prem
		Tape Gateway: designed to be a virtual media or tape library for use with existing backup software.
	
## Amazon WorkDocs
	Secure, fully managed file collaboration service, have web/mobile/native client, can integrate with AD for SSO, HIPAA / PCI DSS / ISO compliance requirements.

## Snow Family
	for data migration
### Snowball
	for transfer larger quantities of data from or to aws (more than 10TB, up to 80TB), less then 10TB can be used other option like storage gateway

### Snowmobile
	for data center migrate, more then 10PB (less then 10PB can use one or more Snowball)

### Snowball Edge
	similar with snowball but also provide compute service

### Snowcone
	transfer data less than 8T, can ship the device to AWS to transfer offline, or transfer online with AWS DataSync.

