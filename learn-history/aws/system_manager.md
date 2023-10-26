## System Manager
    An EC2/on-premise physical or virtual management platform. This manages resources on ec2 or on-premise server through an agent and IAM permissions (in cloud) or with an activation process (on-premise).

    Functionally, Systems Manager lets you:
    Inventory - Collect metadata - from your managed instances: software and configurations required by your software policy, instances need to be updated.

    Automation - automatically install packages
    Manage patches
    Run commands

## AppConfig
    For roll out application configurations across application hosts.

## Parameter Store 
    provide secure storage for configuration data and secret. values can be store as plaintext or encrypted data using KMS. 

## Secrets Manager
    like parameter store, both can store secure string/secrets, more capacity, support rotate secrets safely (use lambda function), work with cloudformation (access from cloudformation)

