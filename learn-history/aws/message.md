# Simple Queue Service
    a message queue service, message between servers are retrived through polling. message size can be up to 256kb

    (not designed for multiple consumers for the same message, while kinessis support that)

    Visibility Timeout: msg keep unvisible to others when consumed by one consumer;
    aws CLI and SDK already have retry and exponential backoff algorithms integrated.
    Dead queue: when failed x times, can move to dead queue
    retention period: keeps messages not long for the time
    Reciever wait time out: reciver will wait for x seconds when no message available in the queue

    mode: standard vs FIFO, standard ensure at least once delovery, no order gurrantee.

## Polling
    Long polling: when pool from sqs, can wait for 1-20seconds to see if message is available.

## Types
    Standard Queue: guarantees delivery at least once. scale almost unlimited level
    FIFO Queue:  have scale limitation, up-to 3000 messages / second

## Visibility Timeout
    message become invisible when been processed, when timeout (30s default) but not deleted, then visiable again.

## Auto Scaling
    can config scale base on queue size

# Simple Notification Service
    Pub/sub messaging for microservices and serverless applications. Send message/notification to different endpoint.

    fan-out: sns + multiple sqs for make sqs 
    publisher: application / s3 event/cloudwatch event
    topic: save message <=256kb
    subscriber: http, https, sqs, email, application, lambda, sms.

    cloudwatch + sns : config a full env monitor solution.

## EventBridge (formerly Cloudwatch event)
    support pre-defined aws service event (like login, backup service state changed), 
    also support customer event, and trigger a target (api dest, lambda, sns, sqs, ...) when event happens

# Amazon MQ
    Managed service,
    
    Base on apache ActiveMQ / RabbitMQ, support topic , queue and virtual topic (topic with one queue as subscriber)
    
    ordered message reliable delivery in finacial / trading system.

    Broker: single instance or highly available pair(active/standby)

    Doesn't integrate with many AWS service, need have public access (private access +  VPC endpoint not working)