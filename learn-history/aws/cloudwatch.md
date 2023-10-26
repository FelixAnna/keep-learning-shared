# cloudwatch
    metrics  is a collection of time-based data points, collected from aws services, or on-premise servers. metrics can be like CPUUltilization, WriteIOPS, ReadIOPS.

    service publish datapoint to cloudwatch in a certain period (customized by us, can be less than 60 seconds to several month)

    metrics group by Namespace, like EC2, Lambda...

    can create alarm for a metrics. alerms can invoke actions as well as autoscaling actions.

## cloudwatch logs
    Log group have many log stream, log stream accept log event(log message) from source and write to log files or other destinations.

    log group level can define metric filter, to generate datapoint of that metric and used in clouldwatch metrics.

## cloudwatch eventbridge
    an event bus service can integrate with applications and aws services.

# cloudtrail
    enabled by default, activities taken by people, groups, aws service, keep for 90 days by default.

## Trails
    continously log your aws account activities
    
    config a customized cloudtrail, can apply to full organization or all region.
    can save management events as well as data events;
    Management events: after been enabled would log control panel events, like user login events, configuring security events, setting up logging events.

    Data events: object level event(like GetObject, PutObject) in S3, functional level events in lambda

    Insights events: identify unusual activity, errors, or user behavior in your account

    Save logs to S3, once trails created for all org, can track all activities for all users, other user can see that (trails), but not able to re-config or modify.

    Logs encrypted by s3 Server-side encryption by default (enabled), can switch to KMS.

    Can enable configure CloudWatch Logs to monitor your trail logs and notify you when specific activity occurs. 