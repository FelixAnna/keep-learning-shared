# directory service

## Simple AD
    provide basic AD service for AWS or no-AWS products, integrate with AWS for SSO, but not support TRUST relationship with MS AD. 
    Not support MFA also.
    low-scale, low cost.

## Microsoft AD
    multiple AZs, running Windows Server.

## AD connect
    allow EC2 and workspace interact with on-premise AD.

## Cognito
    User pool pools for signin/up, ID federation, used by web / mobile applications.
    also can use identity pool (link to user pool of aws or 3rd party)

## Amazon Cloud Directory
    Graph based store of informations, manages object information, relationships and schema management. not for user/group or identities workloads.

