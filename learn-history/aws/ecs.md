# elastic containser service

## ecs
ECS can have multiple task defination directly, or multiple service defination (include task defination), also can register external instances.

### Task defination (have 1-many container defination)
EC2 /Fargate /External: Fargate is a managed platform for containers running on them, only support integrate with aws vpc

### service defination
Based on task defination, define how many copy of task running, how to scale, deployment options, 
Can include a load balancer to distribute incomming traffic.


