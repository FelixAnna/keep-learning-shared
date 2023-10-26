## Auto Scaling

## auto scaling

### Launch Configuration
    define what instance to be deployed to autoscaling group, once created, cannot be modified, legacy way.

### Launch Template
    New way to do same thing as Launch Confuguration, support create new version use previous as template, have more options: like placement group, EBS-optimized instance, shutdown/stop behavior, termination protection, instance role, ...

## Auto Scaling Group
    When and where these instances launch happens. built in heath check, scale policy, notification when changes.

    Instance can be detached from ASG, can be set to standby, can be set to protection mode prevent delete.
    
## Application Load Balancers
    Layer 7 LB, recommand to use in VPC instead of classical Load Balancers. Better performance and cheaper than classical.
    Content Rules are used to direct traffic towards target group.
    Support host-based rules / path-based rules.
    Also support ECS, EKS, Lambda, https, http/2, websockets, access logs, sticky session, WAF.
    allow routing requests to multiple app on one EC2 instances (like containers in EC2)
    target can below to multiple target group.
    Multiple SSL certificate can be managed by a single ALB using SNI.
    Support individual heath check for different target group, support specify heathy response code.
    SSL offloading, User authentication.
    not a single unintrupted encryption.
    
## Network Load Balancers
    Similar as ALB, but design for extreme performance, operate at Layer-4,  support static IP and ultra low lantency.
    also support target group, listener, target.

    end-to-end un-interrupted connection, (TCP traffic pass through) also support TLS offerloading now.

    https://aws.amazon.com/elasticloadbalancing/features/#compare