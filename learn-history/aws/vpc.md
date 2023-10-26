# vpc

we have a default VPC, can have IPv4 and IPv6 CIDR. Tenacy: default on shared resource/hardware, we can also selected decidated if required.

## DHCP dynamic host configuration protocol
    control DNS server, NTP, NetBIOS Server used by VPC

## subnet
    in a single az (need select az when create subnet) 
    (az name is not consistent btw accounts, but az id does)

    reserved 5 ip address: primary+4, and last ip:
    +2 for DNS, +1 for VPC router, +3 for future use, 
    +0 for network address, last for broadcast.

    by default is private


## Resource Access Manager
    share resource within you organization (also support share to account in other org).
    subnet can be shared (not in default VPC) only in the same org.

## routing
    every VPC have a default route table contains a defaut 'local' route allow any traffic inside vpc.

    every subnet can associated with one route table.

    local > static > longest prefix /31 /30... > direct connect > static vpn > dynamic(bgp) vpn 

    define rules (or routes) which determine where network traffics from your subenet or gateway is directed.
    like:
        172.31.0.0/16 redirect to local
        0.0.0.0/0 redirect to igw-xxx (internet gateway)
## Network ACLs
    protect subnet in side a VPC, VPC have default ACLs.
    have inbound rules / outbound rules.
    stateless, need ensure both inbound/outbound allow traffic.

    allow / deny traffic : ip range + protocol + port + imcomming/outgoing
    
## security groups
    protect Network Interfaces inside VPC.
    stateful, inbound tracffic by defualt allow return traffic also.
    can create rule refer security group themselves, allow all traffic inside the group.

    not support explicit deny traffic

## Internet Gateway
    allow connect to internet through VPC, (public subnet)
    create IGW -> attach to VPC
    create route table and attche to VPC -> add route for the IGW -> associate subnet

    subnet level can enable auto-assigne public ipv4 address (also can assign manually if not enabled)

## NAT gateway
     need a elastic (static) ip address, not HA, provide 2+ in every az if need HA. created in a subnet with a elastic ip provided.

     provide out-going access only (AWS public zone, internet)

## EGRESS Only Internet Gateway
    ipv6 version NAT gateway, only allow out-going traffic.

## DNS in VPC
    DNS forwarding through VPN or direct connect.

    inbound endpoints in route53, allow on-premise vpc connected to route53 resolver, to use internal dns record define for aws vpc. act as a relay in the media.

    outbound endpoints in route53 for out-going dns queries.

    rule: forward specific DNS queries from the inbound/outbound endpoints to the target ip address (target DNS server)

## Flow Logs
    gather metadata of VPC flowing across a VPC, not log actual traffic, just log traffic ip/status/time/port/... information, 
    can placed monitoring at VPC/subnet/ENI (endpoint network interface), not real time.

## VPC Endpoint

### Gateway endpoint
    access service in public zone without public internet access and public ip address.
    s3 + gateway endpoint: s3 with bucket policy only access through VPC endpoint, get a fully private s3 bucket.

    HA, not in a specific AZ.
    only support s3 and dynamoDB.

    secure private connection
    cannot be extened outside a VPC

### Interface endpoint
    network level device, deploy in 2+ subnet to archive HA, also need security group to restrict access.

    private connection.

    also accessible outside VPC (VPN, peering, direct connect)
## VPC peering
    create peering connection, 
    accept peer request (migth in different account),
    config route table of subnet who need access other vpc on both side
    ensure ACL not block traffic from other VPC
    ensure security groups allow traffic from  other VPC (CIDR or security group)

    can peer with VPC in another account, another region


    cross region peering:
         DNS resolution option need to be enabled so can access private DNS in another VPC 
         (if same region, can be resolved by default)
        security group can be only reference by ID
        not support ipv6

## VPN
    connect VPC with on-premise network, using dynamic VPN in production (not static),
    quick, cheap, data charge is higher than direct connect.

    HA solution: 2 customer gateway, and 2 connections with them, each with 2 tunnel.
    
### Customer Gateway
    config with on-premise vpn ip address

### Virtual Private Gateway
    attached to a VPC, act as the endpoint for the VPC tunnel 

### VPN connection
    connect VPN connection with 2 tunnels between VPG and Cutomer Gateway, then download the configuration and use that to config on-premise VPN device

## Direct Connect
    connect VPC with on-premise, high bandwidth, lower data transfer price, not travel public network, not encrypted.

    need some time to setup.

## Transit Gateway
    connect VPC , on-premise VPN with a single gateway (same region).
    can have multiple route table (VPC , dynamic VPN  the route table auto propogated to the route table, but for static need config manually in route table)

    attach VPC/VPN to the gateway, update route table if necessary

    Transit Gateway can peering with other Transit Gateway in a different region.


# Public zone
    S3, DynomaDB are in public zone, not in VPC.