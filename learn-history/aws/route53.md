# route53

Domain Regstration & Hosted Zone management

## Hosted Zone
    Support public hosted zone & private hosted zone,
    private hosted zone works in a VPC.
    public hosted zone support enable send Logs resolutions requests to cloudwatch logs (to US East N.Virginal as it is gloabl service)
    
    Support heath check.

    TTL value: seconds for DNS recursive resolvers to cache this record.
### Records Types
    A-IPv4, AAAA-IPV6, CNAME-host/name mapping, MX-mail exhange, TXT

    Name Servers on registred domain should updated to point to domain servers on hosted zone records.

    for any aws resources, use A record type + alias + resource selected to create a records.
### Routing Policy
    Simple: routing to one record (or one record with multiple ips, the ips are returned to client, client random choose one and resubmit the query)
    weighted,
    Failover: one primary, on secondary(ELB or S3)
    Geolocation,
    Latency,
    Multiple-values: one record, multiple endpoints

    Combined Policy: like Weighted + failover
    Version Control on policy (beyond the scope of the exam).