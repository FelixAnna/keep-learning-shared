# cloudformation, service catalog

## cloudformation
### Template & Stack
    use cloudformation stack by uploading and applying cloudformation template, 
    cloudformation template support json or yaml, it define resources in the template, 
    and cloudformation stack will create/update/delete physical resources according to the template.

    When change the template or parameters used by the stack, 
    the resource in the stack can be not changed, updated with no interruption, update with some interruption (like change instance type), replacement

        Changeset: create from stack & template,  allow preview proposal changes to a stack, can be excuted or deleted (or created by junior engineer executed by senior engineer)

        Output in template with an export command, then Fn::Import the export Name, to build a cross template reference

        nested template: parent stack template can reference any other stack template, able share output between these stack. 
        when deployed, will create the main stack and many sub-stack.

        stack role: if not specify permission, cloudformation stack use the permission base on who interactive with the stack 
        (junior user with less permission would not able to update/apply stack). 
        we can specify a role so cloudformation use that role for any operations (create/update/delete resources...)

    stack operation will generate some events, which can send to SNS
    AMI ID is unique in each region

    stack policy: Defines the resources that you want to protect from unintentional updates during a stack update.

    Support customer resource (SNS backed or Lambda backed)

#### Portability & reusable template: 
      not hardcode values, 
      provide default value for parameters, 
      use parameter store for provide default parameter value for different region.
      use Pseduo parameters (predefined by AWS cloudformation)： AWS::AccountId, Region, Partition(like aws-cn for china), StackId, StackName
      use Instrinsic Functions: like Fn::GetAzs, Fn::Select
  
### Stack set

    define stack Administrator account and stack target(Execution) account + region, 
    admin create stacks and execution role will deploy stacks across region/ account basic on configruantions, 
    can define deploy to many region when provisioned.

    usefull, when want to deploy or enforce settings or resources to multiple account and regions.


## Service Catalog
     admin define portfolios, a portfolio is a set of products.
     a product created with a CFN Template/stack
     admin can assign end user permissions to access and deploy (provision right) the portfolio.
     end user can access and deploy the product stack (can also check from CFN stack).

     (end user dont need permission to access the services)
