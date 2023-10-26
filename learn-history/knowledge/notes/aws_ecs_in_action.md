# deploy rest api to ecs
1. create a vpc, with 2+ subnets in different AZs, one of them is private(link to private route table), one of them is public (link to public route table); 
2. create ECR:
		private, allow "ecsTaskExecutionRole" iam role with action: ecr:BatchGetImage, ecr:DescribeImages, ecr:ListImages
		
		policy:
		{
		  "Version": "2008-10-17",
		  "Statement": [
			{
			  "Sid": "Allow ECS Task def download image",
			  "Effect": "Allow",
			  "Principal": {
				"AWS": "arn:aws:iam::365358585348:role/ecsTaskExecutionRole"
			  },
			  "Action": [
				"ecr:BatchGetImage",
				"ecr:DescribeImages",
				"ecr:ListImages"
			  ]
			}
		  ]
		}
3. build and upload image to ECR from linux;
4. create external alb with no target group (listeners and routing), mapping to a VPC and its AZs;
5. create ecs task definition:
	- Task execution IAM role: ecsTaskExecutionRole (create new one if not exists) for pull ecr images and push logs to cloudwatch logs;
	- Container definitions: config a image url from ecr we just uploaded;
6. create ecs cluster with certain vpc;
7. create service for the cluster:
	- select the task definition we created;
	- config deployment option: rolling, blue/green;
	- config vpc, and the alb we created
	- config auto scaling
	- finish, then wait for first deploy results
8. create private link (vpc endpoint) for, ecr + s3 + cloudwatch logs if fargate are in private subnet
