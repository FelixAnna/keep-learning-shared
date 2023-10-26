# elastic beanstalk

    PaaS, provide common preconfigured environment
    maintain application versions, 
    can deploy multiple applications to EB,
    can swap 2 different applications urls for blue-green depoyment to allow very repaid failover.

    can provision db inside eb but not recommand.

    able to save config for an existing environment, so can use this to restore it later.

## configuration
    can change instance from single to load balanced (with detail config) 

### deployment policy
    can deploy all at once (modify and replace old env) or immutable (provide new env and active it then remove old one)

### rolling update type
    once enabled, when change some config about vm or vpc, will trigger rolling update or replace without downtime.
