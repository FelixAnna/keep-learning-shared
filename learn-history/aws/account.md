# account

## IAM

    Groups, Users, Policies, Account Settings（MFA, possword policies）, Access Keys Management
    Access Reports (Credential Reports, Access Analyzer: Find Unintended access to resource/servcie, Organization Activities)

### Policy
    Identity Policy: IAM users/roles have attached polices.
    Policy statement contains Resource/Action/Effect/Condition.

        Resource: arn of resource
        Action: permission list
        Effect: Allow / Deny
        Condition: condition need to match, can use IAM variables like： ${aws:username}, condition support string compare, datetime compare, ip check, boolen check like ${aws:SecureTransport}, etc.

    explict deny / implicit deny.

    Resource Policy: apply to resource, also have Principle - identity of the resource policies. 

### Role Delegation
    An identity (external / internal) can assume a role.

    instance metadata: http://169.254.169.254/latest/meta-data/***
    EC2 instance use the url to retrive credentials (token + expiry date), 
    can be revoked: affect previous sessions (previouse token invalided), not for new sessions.
    If change policy of the rule then will take effect immediately and affect everyone who use this role.

    service like EC2 also can assume role.

### STS IAM Security Token Service

    can revoke token in role level.

#### AssumeRole
    userA have assume role permission(*)， 
    userB from another account allow userA or all user from a account assume certain role.
    userA assume certain ROLE in userB's account.

#### AssumeRoleWithWebIdentity
    login to google and allow aws federation, get a id_token,  
    call AssumeRoleWithWebIdentity from aws with the id_token, get access_key/ session_token / expiration. 
    use the session token to access/manage resources in aws.
    cannot access console
    access from 3rd party application/site

#### AssumeRoleWithSAML
    like AssumeRoleWithWebIdentity but also support access aws console

### Access Keys
    beside username+pwd, we can generate access key for access aws api (via commandline or API)
    
    * Also can generate SSH key or HTTP git credentials for AWS CodeCommit

### ACL / Bucket Policy / Assume Role
    ACL not recommanded, owner is who upload the file by default, others dont have access.

    Bucket Policy: also better to set policy to ensure owner have access.

    Assume Role: cross account assume role and get access of that rule, ensure bucket owner is still the owner.

## Organization
    have a master account.  have a root container, root container can have org unit / account, account/org unit can have nested org unit/account.

    sevice control policy can be inherited.

    consolidated billings can archieve discount (greater volume, cheaper price)

### Service control policies (SCPs) 
    offer central control over the maximum available permissions for all accounts in your organization, allowing you to ensure your accounts stay within your organization’s access control guidelines. 

    only the overlap of many polices applied: s3+rds and s3+dynamoDN = s3 only.

    Not work for master account.

### IAM Permissions Boundaries
    like SCPs, apply to user, role level.
    
    define max polices for a user/role can have.
    effective permission is the overlap of the boundaries and assign permissions.

### service limit
    to many details, ex: 5000 IAM users in an AWS account
    refer: 
    https://docs.aws.amazon.com/general/latest/gr/aws_service_limits.html
    https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_iam-quotas.html

### support tiers
    D: basic support, recommended for testing， 29$/m
    B: production workloads, prod support 1-4 hours, event management for additional fee, prog. API supp. 100$/m
    E: business/mission critical workloads; prod support 15 min-1 hr, event mgmt included, TAM, prog API supp,15K/m