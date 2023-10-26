# csharp

<hint>Generic</hint>， <hint>Delegate</hint>， <hint>event</hint>，<hint>asynchronous</hint>\
<hint>Linq</hint>， <hint>Attribute</hint>，<hint>Reflection</hint>， <hint>General</hint>\
<hint>dotnet 5,6,7</hint>, <hint>C# 7-11</hint>

## Generic
<blue>Constraints</blue>, Code reusability, type safety, efficiency

## delegate

assign to any method <blue>conforms</blue> in signature(return type and parameter)

<blue>multicast</blue>, 
<blue>covariance</blue> (out, return type,  same or subtype),
<blue>contravariance</blue> (in, parameters,  same or less derived types)

bulit-in: Func<in T1, out T2>, Action<in T1>, Predicate<in T1, bool>

## event

signature: public event EventHandler<CustomEventArgs> SomeEvent;

<blue>provider/Observable</blue>, <blue>Subscriber</blue>,  
built-in class：IObservable<T>, IObserver<T>

## asynchronous

<blue>await Task.WhenAll(xx)</blue> is asynchronous way

<blue>CancelationTokenSource</blue> can only cancel un-started tasks, need to hanlde <blue>TaskCanceledException</blue>

## Linq
Linq to objects, linq to entities, linq <blue>method sytanx</blue>, <blue>queries sytanx</blue>,\
<blue>deferred</blue> execution (<blue>lazy evaluation</blue>), <blue>immediate</blue> execution,\
implemented by extension method, lambda expression

## Attribute
extends System.Attribute, define metadata

## Reflection
Assembly -> Type -> MethodInfo, PropertyInfo, Actovator.CreateInstance to <blue>instantiate</blue> an object
<blue>late</blue> binding (doesnt not have complie time knowledge of the target assembly）

## General
C++ C#  ... -> Common Intermediated Language (<blue>CIL</blue>)\
CORE FX(FCL-Framework class library for framework)\
<blue>CLR</blue> (Common Lanague Runtime , like dotnet virtual machine)： <blue>JIT, Memory Management, Security, Exception Handling</blue>

## dotnet 5,6,7
.net 5 unified of dotnet\
dotnet 6(C# 10)\
<blue>Blazor Desktop Web Apps</blue> \
mini web apis for cloud native apps\
<blue>Endpoint filter for controllers （easy to create at endpoint level, another is middleware)</blue>

## csharp

C# 11

<blue>Required Field/Property</blue>, <blue>Raw String Literals</blue>,<blue>List Patterns</blue>, \
<blue>Generic Attribute</blue>, <blue>nameof scope extended</blue>, <blue>String Interpolation New Line</blue>, \
<blue>FileScopedTypes</blue>, <blue>AutoDefaultStruct</blue>,<blue>Improved Method Group</blue>, \
<blue>Generic Math</blue>, <blue>Utf8 String Literals</blue>, \
<blue>PatternMatchSpan</blue>,<blue>RefFiledsScoped</blue>,<blue>NumbericIntP<blue>

C# 10 or older

<blue>Tuples with names and Deconstruct</blue>, <blue>default interface implementation</blue>,\
<blue>Nullable reference Types</blue>, <blue>IAsyncEnumerable & await foreach(...)</blue>,\
<blue>switch and pattern match</blue>, <blue>global using</blue>, <blue>record (immutable)</blue>,\
<blue>File Scoped NameSpace</blue>,<blue>ConstantInterpolatedStrings</blue>,<blue>record struct<blue>

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