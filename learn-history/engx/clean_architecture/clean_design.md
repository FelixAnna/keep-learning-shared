# clean design (clean architecture)
design code that is <blue>easy to understand and reuse, and easy to replace component part</blue>.

clean design include: **SOLID** principles, Don’t Ask Principle, the Law of Demeter, Package Design Principles, and Package Design Strategies. It also involves establishing clear boundaries to prevent unnecessary dependencies in code.

- <hint>SOLID</hint>
- <hint>Don't Ask: data exposure & anemic domain model</hint>
- <hint>The Law of Demeter: least knowledge</hint>
- <hint>Package Design: high cohesion && low coupling, class goruped, structure describe it intention</hint>
  
## SOLID

### SRP - Single Responsibility Principle
- Class should be <blue>simple and small</blue>
- Can be describe with <blue>one sentence</blue>
- Should have only <blue>one reason to change</blue>

### OCP - Open Close Principle
Use an <blue>abstraction</blue> to compose functionality out of existing objects and avoid reworking existing code

Two ways to create abstractions:
* <blue>extension point</blue>, like
    Virtual methods, Abstract methods, Interface inheritance
    Parameter to function, Setter of another class, Higher-order function

* <blue>design patterns</blue>, like
    Plugin Architecture Pattern,
    Template Method Pattern (use inheritance),
    Strategy Pattern (use delegations)

Apply TDD to maintain a balance between overdesign and the required abstraction for the OCP.

### Tell, Don't Ask Principle
<blue>Data encapsulated by a class should be the responsibility of its class</blue> instead of being passed to another class to process it.

check violations: check if there is any <blue>data exposure</blue> or whether there are signs of the <blue>anemic domain model</blue>.

- data exposure: Exposing data (violating encapsulation) from objects to other classes for alteration

- anemic domain model: classes that do not contain behaviors, making them little more than bags of getters and setters

## Liskov Substitution Principle (LSP)
Subtypes must be <blue>substitutable</blue> for their base types

The LSP is about ```child classes fulfilling the contract of their parent class```. Breaking the defined contract violates the LSP.

## Interface Segregation Principle (ISP)
<blue>Clients should not be forced to depend on methods they do not use</blue>

- No client should be provided an interface with functionality it does not use.
- For languages that do not have interfaces: subtypes should not be forced to inherit or implement methods that have specific semantics, signature
- Interfaces should describe groups of operations that logically belong together.
- The ISP makes it easier to mock interfaces in unit tests, reuse them throughout your code, and understand the logic behind the design.

## Dependency Inversion Principle (DIP)
High level modules should not depend on low level models, they should both <blue>depend on abstractions</blue>, abstractions should not depend on details, details should depend on abstractions.

Avoid a source code dependency from the business logic to the database using the dependency inversion technique.

## Law of Demeter(Least Knowledge)
Also known as the <blue>Principle of Least Knowledge</blue>, ```chaining method indicate a knot of dependencies```

```
car.getEngine().start();
```
Instead of retrieving data from the object to make some actions, tell the object what to do, and let the object handle the behavior.

```
car.startEngine();
```

Exceptions to the LoD: creational pattern “builder” , data structure,  Extracting data from containers

## Code Organization
 
 <blue>Low coupling stresses the separation of unrelated parts of code</blue>, while <blue>high cohesion emphasizes keeping related code in the same location</blue>.

    classes in a module/component should be grouped, released, reused, and maintained together
    
make it's <blue>easy to understand</blue> the project <blue>from the first sight</blue>, <blue>bring orders to the project</blue>, reduce coupling, make dependencies between business and plugins more abvious.

layers help you see the bigger picture: <blue>top layer structure already describes its intent</blue>


### Cohesion Principles

- Common Closure Principle (CCP):
 the classes in a module should be <blue>closed together against the same kinds of changes</blue>.
 A change that affects a module affects all the classes in that module and does not affect other modules. (module level SRP)

- Common Reuse Principle:  Classes in a module are reused together
- Reuse/Release Equivalence Principle (REP): grouped, released, reused, and maintained together

###  Coupling principles 
 Coupling principles support the idea that one module should not directly affect or modify another module's state or behavior. A module is tightly coupled when it relies on other modules and can modify those modules’ states.

- Acyclic Dependencies Principle
- that modules that are difficult to change do not depend on modules that are easy to change
- make sure a stable module is also abstract so that its stability does not prevent it from being extended

## Clean Architecture
DB, Web :: Controller, Presenter and Gateway :: UserCases :: Entities

- The <blue>structure of a project</blue> should <blue>scream about its nature</blue>.
- An application typically has three layers: Domain, Interface, and Framework and Drivers layers
- Framework and Drivers layer depends on the Interface layer, and the Interface layer, in turn, depends on the Domain layer
- It means that <blue>components of the system do not depend on others directly but depend on boundary interfaces</blue>

### benifit:
 - <blue>Testability</blue>：
    The code of your app is decoupled, so you can test every part in isolation from other components. You should only mock missing dependencies.

- <blue>Maintainability</blue>：
    The functionality of the app is strictly separated from the business logic. If you want to add new features, you can implement them in separate files without impacting the existing code.

- <blue>No rush in choosing Framework, UI, Database</blue>：
    You can think about these elements later because your app does not depend on any Framework, UI, Database, etc. This becomes possible because the core part of your app is written in pure Java/.Net code and all other modules are plugins that can be easily changed.



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