# go summary

## gin
a restful framework, with middleware support, and good performance.

## micro
go-micro is used to build microservices, 
micro is working on top of go-micro, used to manage microservices

### micro API

1. work as a API gateway to forward request to our API services
2. work as a event gateway to pub message to some eventhub (might be sub by some API services)
3. can also work as a proxy or websocket proxy

### micro Web

1. start dashboard to monitor services
2. start proxy to forward request to micro RPC services

### micro CLI
micro command

### plugins

    registry to consul
    setup consul: https://learn.hashicorp.com/tutorials/consul/docker-container-agents?in=consul/docker

    1. start server

        ```
        docker run \
        -d \
        -p 8500:8500 \
        -p 8600:8600/udp \
        --name=badger \
        consul agent -server -ui -node=server-1 -bootstrap-expect=1 -client=0.0.0.0
        
        ```

    check ip of the consul server by exec command inside badger server

        ```
        docker exec badger consul members
        ```

    2. register a client

        ```
        docker run \
    --name=fox \
    consul agent -node=client-1 -join=172.17.0.2
        ```

## docker

1. prepare Dockerfile
2. build: docker build -t date-api .
3. check image: docker image ls
4. tag: docker image tag date-api:latest date-api:v1.0
5. untag: docker image rm docker-gs-ping:v1.0
6. run: docker run --publish host_post:container_port docker-gs-ping

ex: docker run -d -e AWS_ACCESS_KEY_ID=xyz -e AWS_SECRET_ACCESS_KEY=abc -e AWS_REGION=ap-southeast-1 --publish 8383:8383 date-api:1.0.0

7. stop/restart: docker stop/restart containerName

8. connect to containerc cli: 
    windows: winpty docker exec -it yourContainerId //bin//sh
    linux:          docker exec -it yourContainerId /bin/sh

https://docs.docker.com/language/golang/build-images/

## Raft

a consensus algorithm used in distributed system, 
it has one leader + many followers, leader will send heartbeat to all followers

### Election
when init or heartbeat from leader timeout (random value for different node), a new election term start,
a follower which not receive heartbeat before timeout become a candidate, it set it term +1, 
and send election messages to all other node, every node elect for the first candidate who send message to them, 
if a candidate send message to another candidate, the candidate with large term become the leader, other one become a follower, 
after one term, if a candidate have more than half support, it become the new leader. otherwise start a new term.

### Log Replication
leader's responsibility is to do log replication, leader receive client request and add the request to it log entry, 
then forward the request(s) to all it followers as a appendEntries messages, 
if a follower is unavailable, leader will retries send appendEntries message indefinitely, 
until the log entries eventually stored by all followers 

once majority of the followers received the message, leader apply the entry to it local statemachine, 
the message is considered as committed (will also commit all previous entries in the leader's log). 
Once a follower learn that a log entry is committed, it will apply the log entries to it local statemachine.

in case of leader crash, the log can be inconsistent, the new leader will force all followers duplicate it own log, 
then the leader will compare with that, find the last common log entry on both side, 
then append remaining entries from leader 
(delete follower's entries after the common entry, append remaining entries to follower's entries), 
finally sync to all followers to ensure they have same entry

## kubernetes

### summary
Help run distributed system resiliently, it take care of scaling and failover, provide deployment partten, 
Have Control Panel and Nodes,
It provider:
1. service discovery and load balancing
    expose container using DNS name or IP, 
    load balance and distribute traffic to containers
2. Storage orchestration
    allow mount storage from local or cloud providers
3. Automate rollout and rollback
    describe desired state for your deployed containers, 
    kubernetes will help change the actual state to the desired state at a controlled rate, 
    such as create new containers for a deployment, remove existing, and adopt to the new container
4. Automatic bin packing
    You tell kubernetes how much CPU/RAM each container needs, 
    kubernetes will fit containers onto the nodes to make best use of your resources
5. Self-healing
    kubernetes restart/re-create containers who are fail or not health (healthcheck), 
    and doesnt advertise them to client until they are ready to serve
6. Secret and configuration Managemet
    Store and manage secret and sensitive information, 
    so you can deploy and update config without rebuilding your container images

### control plane components
make global decisions about the cluster, as well as detecting and responding to cluster event

#### kube-apiserver
for exposes kubernetes API, it can horizontally scalling to multiple instances. 
when use kubectl / api / dashboard to access/update the cluster resources, we actually use the kube-apiserver to communicate with the cluster.

#### etcd
it is used as kubernetes backing store to store all cluster data, it should have snapshot backup for disaster recovery scenarios. (etcd bultin snapshot, or EBS snapshot when use ebs to store data) 

#### kube-scheduler
watch for newly created pods with no node assigned, find for best node for them to run on

#### kube-controller-manager
In Kubernetes, a controller is a control loop that watches the shared state of the cluster through the apiserver and makes changes attempting to move the current state towards the desired state.
for controller processes, ex: node controller for notify and response when node goes down, job controller for watch for one-off task, then create pods for those task to run

#### cloud-controller-mamanger (optional)
link cluster into your cloud provider's API.

### node controller
run on every node, maintain running node and providing kubernetes runtime environment

#### kubelet
 An agent runs on each node in the cluster, responsible for communicate with control panel, ensure containers describe in PodSpecs are running and healthy.
 use this tool to registry node to cluster

#### kube-proxy
a network proxy runs on each node. maintains network rules on nodes. these rules allow network communication to your pods inside or outside of your cluster

#### container runtime

software responsible for running containers, like docker, containerd ...

### Addons

#### clusterDNS

all kubernetes should have this DNS server.

#### Web UI (dashboard)
a UI for manage and troubleshoot applications running in the cluster, as well as the cluster it self.
setup refer: https://kubernetes.io/zh/docs/tasks/access-application-cluster/web-ui-dashboard/

#### Container resource monitoring
records time-series metrics about containers and provide UI for browsing that data

#### Cluster level logging
save container logs to a central log store with search/browsing interface

### namespace
 an isolated env for seperate communities to share the same kubernetes cluster.
 deffierent team can access, manage (attach policy and authorization) their own namespace.
 dns in kubernetes: <service-name>.<namespace-name>.svc.cluster.local

#### initial namespace
    kube-system : for objects created by kubernetes system
    kube-public: for resources who should be public for the whole kubernetes cluster
    default: the default namespace for object with no other namespace

#### set preference namesapce
    kubectl config set-context --current --namespace=<insert-namespace-name-here>
    # Validate it
    kubectl config view --minify | grep namespace:

#### set namespace for a request
    kubectl run nginx --image=nginx --namespace=<insert-namespace-name-here>
    kubectl get pods --namespace=<insert-namespace-name-here>

### minikube
download and use "minikube start" command to create a kubernetes cluster with local system as the only node.

### kubectl

kubectl version : get the kubernetes version 

kubectl get nodes ： see available nodes in the cluster

//kubectl create deployment [deployment name] and [app image location]
kubectl create deployment kubernetes-bootcamp --image=gcr.io/google-samples/kubernetes-bootcamp:v1
//do 3 things: search node for deployment, schedule to deploy the app to node(s)，monitoring and re-healing the app when needed

kubecrl get pod -o wide : more information for output
kubectl get deployments : check all deployments state
kubectl get deployment xxx -o yaml >fileName.yaml  : get full deployment yaml and save to file (remove some fields before use it to deploy)

kubectl apply/delete -f xx.yaml : deploy or remove resources

kubectl describe pod/deployments xxx: get details message, status, event for the pod / deployment

kubectl logs xxx : get logs for pod

kubectl exec -it xxx -- /bin/bash  : enter container's iteractive terminal
kubectl exec -it xxx -- env  : run individual command in containers (example to list all env)
winpty kubectl exec -it xxx -- //bin//bash : enter container's iteractive terminal(from windows)
winpty kubectl exec -it xxx -- ls al: run individual command in containers(from windows)

kubectl edit deployment xxx : edit deployment yaml in vim and apply to cluster when saved

kubectl [action] [resource] --help : for detail help

kubectl top nodes : get metrics for all nodes
kubectl top pods -n xxx : get metrics for all pods in the namespace

### Pod

Pod is the smallest deployable unit of computing that can create and manage in kubernetes, it can contains one or more containers,
these containers will share same resources like network, storage. pod also have specification for how to run the containers.
single container is the common case as kubernetes manages pods rather than containers.
if have multiple containers in a pods, normaly for they are relativily coupled.
we usually deploy workload resources like: deployment, Jobs, and DaemonSets. Rather than deploy pod directly.
Workload resource have pod template. 
Update the pod template will result in (Deployment Controller) create new pods and finally replace old pods.
Pod level can specify a set of shared volumes, then all containers in the pod can access the volumes, so they can share data.

Ip address is assigned to pod level, containers inside pod can communicate by localhost, containers in different pods cannot communicate without special configuration.


## ref

micro & go-micro
https://www.youtube.com/watch?v=OcjMi9cXItY
https://www.youtube.com/watch?v=ucTwnDB1m2U 
