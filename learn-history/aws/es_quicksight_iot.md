## Elastic Search
  Nosql database base on Lucene, design for repaid data retrive. integrate with many aws service like cloudwatch logs.
  implement ELK stack: Kabana + elastic search + Logstash/beats
  Logstash: fully featured log workflow system
  Kabana: log / metric visualization
  prod: 3 master nodes (manage function cross the cluster) so if one failed still have 2 which can continue elect, many data instances (compute + memory + storage) perform search and return data
  use persistent instance, can purchase reserved capacity
  store data in document, have index of the doc
  
  can integrate with kinesis firehose
  
## QuickSight
  BI service, Data visualization (integrate with other service to get data, like s3, kinesis, athena, aurora, redshift)
  (kinesis Data Analytics focus on analysis, quicksight focus on visualize)

## IoT
  Things or Sensors : actual systems generating data
  Device Gateway : AWS Gateway device to accept feeds from Sensors/Things use x503 cert
  Topic : Industry standard-MQQT Topic that can be subscribed by IOT-Rules(then into AWS services) 
          or Other Subscribers that can consume data from Things/Sensors and work through them
  Shadows : Shadow of Each Thing or Sensor sitting behind Device Gateway into AWS. This actually maintains the sproadic feeds from Things/Sensors.
            So Services can syncrhonously work with shadows rather than sproadic feeds coming out of Things
  IOT Rules : Can listen from MQQT-Topic or Directly from Device Gateway and then invoke AWS services 
              (like Dynamo DB, S3, Lambda, Kinesis, Step functions) to react to those feeds
  Basic ingest allows devices to directly interact with IOT Rules using aws/rules/rule-name. Thereby saving Topic cost.
