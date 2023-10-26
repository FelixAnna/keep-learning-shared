## csharp 7，8，9，10

**Tuples**: tuples can have name
```C#
var tuple = new Tuple<string, int>("hello", 123);

var tuple = (name: "hello", weight: 123);

//Desconstruct an object (not as a tuple)
public class Person{
    ...
    public void Deconstruct(out string name, out int weight){
        name =Name;
        weight = Weight;
    }
}

var person = new Person("Hello", 100);
var (name, age)=person;

```

**default interface implementation**: default implementations
```C#
public interface IRepository{
    Task<Product> FindByAsync() => Task.FromResult(default);
}
```
**Nullable reference Types**: enable <Nullable>enabled</Nullable> from csproj file, will alert possibility of null for reference types
```C#
public class User{
    public string? Name;
    public string Address;
}

ArgumentNullException.ThrowIfNull(user.Name);
```

**Async Streams， await foreach**
```C#
async IAsyncEnumerable<T> ReadAsync(){
    while(await XXXasnyc is string line){
        ...
    }
    yield return xx;
}

await foreach(var line in ReadAsync()){

}
```
**switch and pattern match**: positional / relational pattern
```C#
var whatFruit = fruit switch 
{
    Apple => "apple",
    (_, isValid: false) => "bad fruit",  //deconstruct
    Orangle { Weight: >100 and <200=} => "Big Orangle",
    _ => "Others"
}
```
**global using**
**record**: is immutable
```C#
var san=new Person("xx","yy");
var si = san with {lastName = "zz"};

record Person(string name, string lastName){

}
``` 
**File Scoped NameSpace**: declare in the first line without "{" and "}"
```C#
namespace xxx;

public class xxxxxx{

}
```
**ConstantInterpolatedStrings**: interpolated string can still define as constant
```C#
private const string Base="ABC";
private const string GetById=$"{Base}/getbyId";
```
**record struct**: recoard is comipled as class by default, but we can defined it as struct by:
```C#
record struct / class(default is class) Person(xx)
```