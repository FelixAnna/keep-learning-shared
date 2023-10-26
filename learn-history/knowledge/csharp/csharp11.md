## csharp 11

**Raw String Literals**: use **"""** to avoid escape characters.
```C#
"""YourJson or XML"""

$$"""Your Json or XML with {{interpolation}}"""
$$"""YouJson with {{interpolation}}"""  // it already have "{" so we use 2 "{" and 2 "$" here
$"""Your XML with {interpolation}"""  //it don't have "{" so we use it as normal
```

**List Patterns**：test elements in a list/array
```C#
var numbers =  {1, 2, 3}

Console

if(numbers is [var first, _, _])
if(numbers is [var first, .. var rest)
{
    Console.WriteLine(first)
}

var text = numbers switch
{
    [] => "array is empty",
    [var first, var second, _] => $"{first} + {second} = {first+second}"
}

Console.WriteLine(text);
```
**Generic Attribute**:The attribute can be generic, it is a type-safe

```C#
public class ValidatorAttribute<T> : Attribute where T : IValidator
{
    public Type ValidatorType {get;}
    public ValidatorAttribute(){
        ValidatorType=typeof(T)
    }
}

[Validator<UserValidator>]
public class User{

}

public interface IValidator{

}
public class UserValidator : IValidator{

}
```

**nameof**: extended nameof scope to attribute
```C#
[Name(nameof(text))] //C# 10 or older： [Name("text")]
public void Test(string text){

}
```

**Utf8 String Literals**: easy to transfer in utf8 byte array from string, as utf8 is the language of th web
```C#
ReadOnlySpan<byte> input = Encoding.UTF8.GetBytes("Abc");
ReadOnlySpan<byte> efg = "Abc"u8;  //same as previouse one
```

**String Interpolation New Line**: support write in multiple lines
```C#
//C# 10: var text = $"Hello, {World.ToLower()}";
var text = $"Hello, {World
.ToLower()}";
```
**Generic Math**:  constraint a type parameter to by "number-like"
```C#
var numbers = new[] { 1, 2, 3, 0.69f };
Console.WriteLine(CSharp11.AddAll(numbers));

public T AddAll<T>(T[] values) where T: INumber<T>{
    T result = T.Zero;
    foreach(var value in values){
        result+=value;
    }
    return result;
}
```
**Required Field/Property**: use required to ensure initilized while instantiated
```C#
var user = new User() { 
    Name="this must be assigned"  //this cannot be missed
};
user.Name = "other";

public class User
{
    public required string Name { get; set; }
    public string Password { get; set; }
}
```
**FileScopedTypes**:define class only visiable in a file
```C#
file class HiddenQuestion{
    public string Question{get;set;}
}
```
**PatternMatchSpan**: match span with a pattern or macth part of it
```C#
ReadOnlySpan<char> text = "Some Text"

//or: if(text is "Some Text")
if( text is ['S', ..])
{
}
```
**AutoDefaultStruct**: partially assigned struct is allowed from C# 11
```C#
public struct Data{
    public int X;
    public int Y;

    public Data(int x, int y){
        X=x;
        // y=y;  csharp 11 doesnt need this
    }
}
```
**Improved Method Group**: performance are same in below 2 different ways now
```
private static readonly int[] numbers = Enumerable.Range(0, 100).ToList();

numbers.Where(x=>Filter(x)).ToList();
numbers.Where(Filter).ToList();  //also cached and optimized in csharp 11 now

public bool Filter(int x){
    return x < 0;
}
```
**NumbericIntP**: alias nint for IntPtr
```C#
IntPtr value = IntPtr.Zero
nint value = nint.Zero
```
**RefFiledsScoped**: ensure the stack-allocated memory will not outlive the ref struct that we created
```C#
Span<char> values = stackalloc char[3] { 'T', 'o', 'm' };
new Test().TestMethod(values);

ref struct Test
{
    public void TestMethod(scoped ReadOnlySpan<char> characters)
    {
        // The body of the method must only use characters in the local scope, and cannot assign it directly to any field or classes unles they themselves would be scoped.
    }

    Span<int> CreateSpan(scoped ref int parameter)
    {
        // body
    }
}

scoped Span<int> span stackalloc int[10];
```