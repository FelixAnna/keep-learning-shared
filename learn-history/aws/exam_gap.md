## X-Ray
    help identify performance issues and errors.

    trace user requests through entire application,
    pinpoint which application cause performance issue,
    
    X-Ray service map let you see relationship between your application and resource in real time.
## 504 Gateway Timeout
    means your web server didn't receive a timely response from another server upstream


## gp3 SSD volumes
    IOPS governed by volume size,  more IOPS then gp2
## gp2 SSD volumes
    IOPS governed by volume size,  3000 IPOS / TB: 1TB-3000, 3TB-9000, with 16000 maxinum IPOS - 5.34TB

## dynamoDB streams
    captures a time-ordered sequence of item-level modifications in any DynamoDB table and stores it in a log for up to 24 hours
## Tags
    Principle Tags & resource tags can be used to control access to resources.

        ## Dms
            Can not migrates data as a source(can be a target)

## cross region copy
    EBS and RDS support cross-region snapshot
## Deticate host with host affinity:

    When affinity is set to Host, an instance launched onto a specific host always restarts on the same host if stopped. 


## NAT
    NAT-Gateway can not be used through VPC peering

## Aws privatelink


## volumes
    You can now increase volume size, adjust performance, or change the volume type while the volume is in use. You can continue to use your application while the change takes effect


## route53 health check
    HTTP and HTTPS health checks – Route 53 must be able to establish a TCP connection with the endpoint:
        within four seconds. 
    In addition, the endpoint must respond:
        with an HTTP status code of 2xx or 3xx within two seconds after connecting. 
    After a Route 53 health checker receives the HTTP status code, it must receive the response body from the endpoint:
        within the next two seconds. 
    Route 53 searches the response body for a string that you specify. The string must:
        appear entirely in the first 5,120 bytes of the response body 
    or the endpoint fails the health check

## Aurora storage auto scale
    Aurora storage scales automatically and yet is cost effective because you are billed for what you use.

## Amazon Connect / Lex
    Amazon connect to setup contact center for inbound/outbound calls

    Amazon Lex to build voice/text chatbots

## EC2 
    a recoved instance is identical to the original instance (ip/instanceID/metadata).

## ACL for web server subnet
    inbound for port 80
    outbound traffic will be going through the ephimeral port range (1024 - 65535)
## SMS Connector
    only supprt VM for now.
## CloudEndure
    support migrate physical servers
## AD one-way trust
    not support SSO


## Others
    401: 504 gateway error - troubleshoot by use cloudwatch logs + X-Ray
    404: NAT cannot used means outbound traffic not possible, then VPN cannot used also.
    408: C/D - C SLA not enough & static content, D - geobased + fargate + multi-master
    
    462: Active-active failover
    464: AWS Serverless Application Model
    468: Appstream
    480: Write messages to cloudwatch log, lambda or kinesis write the data to s3, 
    476
    480
    501
    505
    518: Service limit check by api need basic support plan?
    520: Kinesis stream+firehose
    528: S3+js+lambda+cognito
    533: Size, instances
    550: DNSSEC
    574
    581: Transcribe
    584: Service.com Available Zone
    586: macie for s3, Codecommit trigger for new cide
    589: Cloudformmation+retain
    595: Sms for migrate root and data volumes
    597: Cloudformation*cloudformation, Inline policy deny all other service
    598: Bulk owner full access?assume write access role
    602: Origin + behaviour
    605: Canary lambda, alias traffic shifting
    612: Not sure
    613: Dynamo db for millions of small size items
    614: S3 Transfer Acceleration:use edge location
    617: Sso not support mobile app
    621: Failover,aurora write to one region
    628: NAT Gateway needs to be created in a Public Subnet. It needs to be accessed from the private subnet via a route table attached to it that routes outbound traffic to the NAT Gateway which is in the public subnet and from there to the internet via the Internet Gateway attached to the VPC.

        IoT Rules
        give things ability to interact with aws service

        scp can enforce tag policy applied (condition with tag = null, action will be denied on target resources)
    640
    647: NLB
    653: Codepipeline to create and execute changeset
    656
    657: Service catalog+budget notification
    671: trust policy have set the SAML provider as the principal
        Call sts 
        User group mapped
    696: Acm not support ec2 ,Kms encrypted ebs no need explict encrypt again
    698: Firehose+es+kibana provide near realtime visualization
