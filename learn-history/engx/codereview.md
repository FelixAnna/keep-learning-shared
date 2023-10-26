# code review

## benifit
- find code issues (bug, performance, security, standard)
- knowledge share

## code review strategy

### High-level summary and scope
- Improve <blue>knowledge-sharing</blue> to <blue>reduce the bus factor problem</blue>.
- Use <blue>consistent coding standards</blue> to enhance code quality.
### Coding standards
format / naming / organizing / error handling / logging / testing(when and ow to write test) / framework specific / restrictions (no goto, no log4j)

* when a reviewer sees a violation, they should <blue>leave a comment with a link to the corresponding coding standard<blue>

### Tools for automating the code review process
### Tools for code quality control
SonarQube detect bugs, vulnerabilities and code smells in 17 programming languages
### Rules for choosing a reviewer
Leader / Peer / Mixed / All-peer review
set minimum number of approvals and maximum number of rejections
### Code review quality control
##### Code Review Quality Metrics
- Review/inspection quality metrics

    Lines of Code (LOC): 200 - 400
    Code Review Rate: 100 - 200
    Identified Defects per LOC
    Defect Rate
    Defect Density
    Missed Defect Count

- Timeline metrics

    Pre-Review/Queuing/Review/Correction Time

- Process-related metrics

    approved and rejected request ratio
    number of iterations during a review
    load distribution 
    The number of untagged code reviews
    
### Other agreements and rules

## Code Review Best Practices

### Code Review Checklist
- review preparation checklist

    Add the <blue>ticket number</blue> to the title of the pull request

    Add a <blue>description of the task</blue> to the pull request

    Clean <blue>commit history</blue>

    Check to make sure <blue>unit tests are green</blue>

    Check to make sure <blue>code quality gates</blue> are met

- author's checklist:
- 
    Review preparation checklist – completed

    Code quality checklist – completed

    Code change is documented

    Code change is approved

    Code change is merged

    Development branch was deleted

- design team's check list
  
    functional business requirements

    non-functional business requirements

        Functionality - What the customer wants! Note that this includes security-related needs.

        Usability - How effective is the product from the standpoint of the person who must use it? Is it aesthetically acceptable? Is the documentation accurate and complete?

        Reliability - What is the maximum acceptable system downtime? Are failures predictable? Can we demonstrate the accuracy of results? How is the system recovered?

        Performance - How fast must it be? What's the maximum response time? What's the throughput? What's the memory consumption?

        Supportability - Is it testable, extensible, serviceable, installable, and configurable? Can it be monitored?

    Example:
        The review request is commented on according to the comment template.
        The code corresponds to the practices and methods in the coding standards.
        The code style is designed according to the coding standards.
        It passed control tests for memory leaks
        The code change corresponds to one type of task (refactoring, new feature, but fix,
        config change, etc.).
        The code has unit tests.
        Tests are designed according to unit test guidelines.
        Test coverage ≥ 70%.
        The code or solution is appropriately documented according to the
        recommendations in the user story/task.

### Optimize Code Review on Distributed Teams
    Set clear asynchronous communication guidelines for the entire team
    Plan Reviewer Assignments
    Prioritize Calls Over Messaging If Time Permits
    Use Instant Code Review Approach

## Feedback
mindset: A code reviewer should <blue>write comments in a respectful and friendly way</blue>, while the code author should not take comments as a personal attack but as a genuine attempt to reach the common goal: a high-quality product.
- Make Feedback <blue>Actionable</blue>
- <blue>Avoid Offensive</blue> Statements
- <blue>Comment on the Code, Not the Author</blue>
- <blue>Provide Reasoning</blue>
- Use the <blue>"Hamburger" Approach</blue>

## Suggestion from other mentor
Please do not forget about a <blue>final feedback</blue> for mentee after resolving all the issues.
You may <blue>add some inspiring sentences</blue> like "My congratulations on completing the task!", "Good job!", "Nicely done!".
Also please don't forget about Ethical Task Review. Let's use phrases: I think, I believe, It seems, It looks like...
Those are not related to your solution personally, it's just a general advices.
Nevertheless, your solution is approved, good job!



<style>
blue {
  color: lightblue;
  font-weight: bold;
}


hint {
  color: lightgreen;
  font-weight: bold;
}
</style>