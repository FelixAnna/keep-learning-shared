# GoF design patterns

- <hint>Builder： produce objects step by step</hint>
- <hint>Factory Method: interface and implementations for creating objects</hint>
- <hint>Abstract Factory: produce families of related objects</hint>
- <hint>Prototype: clone/copy current object</hint>
- <hint>Adapter： allow objects with incompatible interface to collabrate</hint>
- <hint>Bridge： split class into two dimensions, they can grow independently</hint>
- <hint>Composite： Composite objects into tree structure, work as if it is a invidiual object</hint>
- <hint>Decorator： Wrapper object and add behaviors</hint>
- <hint>Facade： Provides simplified interface to complex set of interfaces</hint>
- <hint>Flyweight： Share common parts of state between multiple objects</hint>
- <hint>Proxy： Control access to the original object by wrapper it</hint>
- <hint>ChainOfResponsibility： process request along a chain of handlers</hint>
- <hint>Command： encapsulates request into objects with anything about the request, support execute and undo</hint>
- <hint>Iterator: traverse a collection without exposing its underlying representation</hint>
- <hint>Mediator： forces objects communication via a mediator object</hint>
- <hint>Memento： save and restore previous state of an object</hint>
- <hint>Observer： define a subscription system to notify subscribers</hint>
- <hint>State： object change internal state when do some behavior, and the behavior also changed </hint>
- <hint>Stratergy： define a family of algorithms and make them exchangable</hint>
- <hint>Template Method：define an skeleton of an algorithm and lets subclass override specific steps</hint>
- <hint>Visitor： define operation(accept(IVisitor v)) to be perform on objects, define new operation (AnotherImplementationOfIVisitor) without changing object class again</hint>
  
## Builder

Let you construct complex objects step by step. 

Allows you to produce different types and representations of an object using the same construction process.

## Factory Method

provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created.

## Abstract Factory

Let you produce families of related objects without specifying their concrete classes.

## Prototype

Let you copy existing objects without making your code dependent on their classes.

## Singleton 

Let you ensure that a class has only one instance, while providing a global access point to this instance.

## Adapter

Allows objects with incompatible interfaces to collaborate.

## Bridge

Lets you split a large class or a set of closely related classes into two separate hierarchies ( abstraction and implementation )

Which can be developed independently of each other.

## Composite

Let you compose objects into tree structures,
and then work with these structures as if they were individual objects.

## Decorator

Lets you attach new behaviors to objects by placing these objects inside special wrapper objects that contain the behaviors.

## Facade

Provides a simplified interface to a library, a framework, or any other complex set of classes.

## Flyweight

Lets you fit more objects into the available amount of RAM,
by sharing common parts of state between multiple objects instead of keeping all of the data in each object.

## Proxy

A proxy controls access to the original object, 
Allowing you to perform something either before or after the request gets through to the original object.

## Chain Of Responsibility

Lets you pass requests along a chain of handlers. 
Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain.

## Command

Turns a request into a stand-alone object that contains all information about the request. 

This transformation lets you pass requests as a method arguments, delay or queue a request’s execution, and support undoable operations.

## Iterator

that lets you traverse elements of a collection without exposing its underlying representation (list, stack, tree, etc.).

## Mediator

lets you reduce chaotic dependencies between objects. 

The pattern restricts direct communications between the objects and forces them to collaborate only via a mediator object.

## Memento

Lets you save and restore the previous state of an object without revealing the details of its implementation.

## Observer

Lets you define a subscription mechanism to notify multiple objects about any events that happen to the object they’re observing.

## State

Lets an object alter its behavior when its internal state changes. 
It appears as if the object changed its class.

## Strategy

Lets you define a family of algorithms, put each of them into a separate class, and make their objects interchangeable.

## Template Method

Defines the skeleton of an algorithm in the superclass but lets subclasses override specific steps of the algorithm without changing its structure.

## Visitor

Lets you separate algorithms from the objects on which they operate.


<style>
blue {
  color: deepskyblue;
  font-weight: bold;
}


hint {
  color: deeppink;
  font-weight: bold;
}
</style>