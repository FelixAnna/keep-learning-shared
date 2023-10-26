# Kinesis
Collect, process, and analyze data streams in real time.

## Producers
    IOT devices/ application /EC2 instances/on-premise server

## Consumes
    Read data records of the given stream

## Kinesis Data Streams
    Real-time data capture
    Ingest and store data streams from hundreds of thousands of data sources:
    Log and event data collection
        IoT device data capture
        Mobile data collection
        Gaming data feed
    Encrypt at rest;

    Shard: 24hour data retention by default, up to 7 days. stream could have many shard, that how it scale capacity, need define read capacity and write capacity.

    producers / consumers bandwidth = stream bandwidth / number of producers or consumers.

    stream level metrics logged to cloudwatch by default, can enable shard level metrics manually.

    if need access from private VPC, use VPC endpoint.
    Enhanced fan out allows specifying consumers with dedicated bandwidth.
## Kinesis Data Firehose
    Load real-time data (from Data Streams or from Direct Put or Other service)
    Load streaming data into data lakes, data stores, and analytics tools for:
        Log and event analytics
        IoT data analytics
        Clickstream analytics
        Security monitoring
    support: s3, redshift, elasticsearch, splunk as destination
    support transform (like use lambda) before load to dest
## Kinesis Data Analytics
    Get insights in real time (real-time sql query)
    Analyze streaming data and gain actionable insights in real time:
        Real-time streaming ETL
        Real-time log analytics
        Ad tech and digital marketing analytics
        Real-time IoT device monitoring
    support config new stream or use Kinesis Data Streams/ Kinesis Data Firehose delivery stream
    support transform data from soure stream