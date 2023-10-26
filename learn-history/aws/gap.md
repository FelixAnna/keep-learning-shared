## AWS Control Tower
	setup and govern a secure multiple accounts environment

	landing zone: helps automated setup well-architected, multiple account environment based on best practise
	Guardrails: prevent (cfn+scp) / detection-remediable (config), to ensure the resources provisioned always conform to your policies
	Dashboard: get continuously visibility of how our resource comply with policies.

	Aws Landing zone (old, replaced by AWS Control Tower)

## service quotas

## Outposts
	extend aws cloud service to local, like a private data center, you can extend many service to the rack 

## Local Zone
	extension of region, low lantency

## Wavelength
	5G low lantency, connect with Wavelength zone, comminucate with service provide data center

## s3 VPC endpoint service

## SSO

## Fargate vs EC2
	Fargate: aws manage infrastucture, EC2: we manage infrastucture, can use EC2/Fargate as launch types (a mix them)

## ECS
	create by amazon, like EKS, but able to manage infrastructure, free, only pay for resource used by it.

## EKS
	container orchestration service, like ecs, pay a little for each cluster, not integrated with IAM very well (but have something similar: KIAM)

## Firewall Manager
	need work with aws organization, config ACLs across account / application within organization

## Network Firewall
	protect on VPC or transist gateway side

## Lake Information

## S3 Batch Operations

## Lambda
	run up to 15 mins + 10GB memory

## Global Accelerator
	like DNS load balance, support failover, and load balance.

### Anycast IP
	decide send traffic to which location

## Savings Plans

## AWS SMS
	migrate VM to aws

## AWS CloudEndure

## Migrate Hub

## DMS
	database migrate service
	+ snowball edge : for large data migrate

## SCT schema conversion
	migrate to different database.

###############
	ISCSI