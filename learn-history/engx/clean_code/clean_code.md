# clean code

- <hint>DRY</hint>
- <hint>KISS</hint>
- <hint>YAGNI</hint>
- <hint>Single Purpose</hint>
- <hint>Easy to follow</hint>
- <hint>Minimal dependency</hint>
- <hint>Tested</hint>
- <hint>Good solutions, No workaround</hint>
- <hint>Expressive</hint>
## criterias

### Clean Code is Nonredundant

Clean code complies with the <blue>DRY</blue> rule (**Don’t Repeat Yourself**). When the DRY rule is successfully applied throughout a piece of code, modifications of single elements are simple and do not require changes to logically unrelated items.

### Clean Code is Pleasant

Looking through clean code is like reading a well authored reference book—it’s easy to follow and simple to find what you’re looking for. This ease comes from following popular programming principles like <blue>KISS</blue> (**Keep It Simple, Stupid**) and <blue>YAGNI</blue> (You Ain’t Gonna Need It).

### Clean Code is **Focused**
In a piece of cleanly written code, each class, method, and function are separate and undisturbed by one another. Every object fulfills a <blue>single purpose that is entirely encapsulated</blue> in its class and all services are narrowly aligned with that purpose.

### Clean Code is **Easily Extended**
Clean code is written with other developers in mind. The programmer knows that they might not be the maintainer, so they ensure the code is <blue>an easy map to follow</blue> for future developers.

### Clean Code has **Minimal Dependencies**
The <blue>minimal dependencies</blue> in clean code make it easier to maintain. Classes and methods are short and the code itself is well divided. Clear divisions make reading the code straightforward and simple.

### Clean Code has **Unit and Acceptance Tests**
Clean code is <blue>tested</blue> to ensure it complies with requirements. Being tested means that the code can be maintained and extended without the fear of breaking it.

### Clean Code is **Well Thought Out**
There are <blue>no confusing workarounds</blue> in clean code. Developers spend time finding <blue>good solutions</blue> that keep the language simple and easy to follow.

### Clean Code is **Expressive**
Clean code has meaningful names that are distinct and <blue>express their intentions</blue>. This expressiveness makes the code itself a document, which makes the need for separate documentation less important.

## Naming

### reveal intention

### Dont be cute
    Say what you mean, mean what you say

### searchable name
    name should be easy to locate across a body of text, if a name occurs in multiple places, it is important to give it a search-friendly name. Single-letter names should ONLY be used in a local variables insides short methods.

### Avoid encoding
    Avoid hungarian notation, member prefixes,etc.

### One word, one meaning
    Be consistent throughout your code by using one word per abstract concept, and use word only have one meaning to eliminate confusion.

### Meaningful distinctions
    When attempt to differentiate code, make distinctions that are meaningful without changing the searchability or intention of the code. (classA, classB over klass, clazz)

### Use Pronounceable Names

## Length Rules

### Method & Class
- Longer scope -> shorter name
- Shorter scope -> long meaningful name (long descriptive names will help readability)

### Variable

Longer scope -> long name

Shorter scope -> short name


### Grammar Rules

Class & Object : noun phrase name

Function: verb phrase name

- Solution Domains: Use programming terms
- Problem Domains: Use simple terms that clearly identify the problem + Avoid programmer language

## functions

### small
    
    ideal length is less than 20 lines, 
    but still can make it easy to read and test, 
    adhere to th DRY principle,
    the code still can explain itself (Expressive)

    Extracting Blocks and Sections by following:
    * Only Do One Thing
    * One level of abstraction

### rules
* Only Do One Thing
* One level of abstraction
* Command-Query Seperation (either be a command or a query)
* Descriptive Names
* No side-effects (perform the action indicated by its name and that’s it)
* Use exceptions instead of error code
* Extract try/catch blocks in their own functions

### parameters
* less than 2 or 3
* no bool
* do not pass or return null (can return optional<>)
* avoid using output parameters

### structure
* avoid switch if necessary (use ploymorphisms, map)
* no goto (signle entrance and exit)
* a file with not much lines
* horizontal length should not exceed screen width
* other rules agreed by team to follow

### general
* good code is self-documenting (Code should be self-explanatory)
    
    The Good
    1. Legal Comments
    2. Informative Comments
    3. Explanation of Intent
    4. TODO Comments
    5. Improving the Code
    
    The Bad
    1. Irrelevant Comments
    2. Bad Code (spend time clean the code)
    3. Redundant Comments 
    4. Commented Out Code (should delete)
    5. Journaling Comments (duplicate with git)
    6. Noise Comments
    7. Closing Brace Comments

* Do Not Repeat Yourself
  
    a software coding principle focused on reducing the duplication of information

    1. decrease maintenance efforts, 
    2. increase readability of code,
    3. saves time and money

    kinds of duplications:

    4. Imposed（强加的： project standards） Duplication,
   
    (fix: self-explanatory, Keep low-level knowledge in the code and reserve comments for high-level explanations)

    5. Inadvertent(无意的) Duplication, (fix: review)

    6. Impatient Duplication, (fix: culture and education)

    7. Interdeveloper Duplication (fix: code analysis tools)
   

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