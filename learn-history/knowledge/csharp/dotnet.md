# csharp notes

https://www.youtube.com/watch?v=YT8s-90oDC0
## delegate
a type safe method pointer, 
Func<in T1, out T2>
Action<in T1>
Predicate<in T1, bool>

concept: multicast delegate, covariance and contravariance,

covariance: delegate return type can be any of it derived types （more derived，协变）

contravariance: delegate parameter type can be any of it paraent types （less derived, 逆向，逆变）
```
delegate Car GetRewards(string carId, string name);
delegate void PaintCar(Car2 car);
internal class DelegateCovariance
{
    public DelegateCovariance() {
        //covariance: return type of GetCar2 is drived from Car (delegate return type)
        GetRewards getRewards = GetCar2;
        var car = getRewards("1", "BMW");

        //covariance: return type of GetCar2 is drived from Car (delegate return type)
        PaintCar paintCar = PaintCarFunc;
        paintCar(car as Car2);  //still have to pass Car2

    }

    //variance: return type use drived type Car2 instead of base type in delegate
    public Car2 GetCar2(string id, string name)
    {
        return new Car2(id, name);
    }

    //contravariance, parameter use base type Car instead of Car2 in delegate
    public void PaintCarFunc(Car car) { }
}

public class Car
{
    protected string Id;
    protected string Name;

    public Car(string id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class Car2 : Car
{
    public Car2(string id, string name) : base(id, name)
    {
    }
}

```

**conforms** in signature(return type and parameter)

## events

//Events enable a class(publisher) to notify other classes(subscribers) when something of interest occurs

public event EventHandler<CustomEventArgs> SomeEvent;

//inherit EventArgs and then provide custom fields/properties
public class CustomEventArgs : EventArgs {

}

provider/Observable, Subscriber
build-in Observe classes: IObservable<T>, IObserver<T>


```
    //
    // 摘要:
    //     Defines a provider for push-based notification.
    //
    // 类型参数:
    //   T:
    //     The object that provides notification information.
    public interface IObservable<out T>
    {
        //
        // 摘要:
        //     Notifies the provider that an observer is to receive notifications.
        //
        // 参数:
        //   observer:
        //     The object that is to receive notifications.
        //
        // 返回结果:
        //     A reference to an interface that allows observers to stop receiving notifications
        //     before the provider has finished sending them.
        IDisposable Subscribe(IObserver<T> observer);
    }

    //
    // 摘要:
    //     Provides a mechanism for receiving push-based notifications.
    //
    // 类型参数:
    //   T:
    //     The object that provides notification information.
    public interface IObserver<in T>
    {
        //
        // 摘要:
        //     Notifies the observer that the provider has finished sending push-based notifications.
        void OnCompleted();
        //
        // 摘要:
        //     Notifies the observer that the provider has experienced an error condition.
        //
        // 参数:
        //   error:
        //     An object that provides additional information about the error.
        void OnError(Exception error);
        //
        // 摘要:
        //     Provides the observer with new data.
        //
        // 参数:
        //   value:
        //     The current notification information.
        void OnNext(T value);
    }
```

## Generics

Constraints, Code reusability, type safety, efficiency

## asynchronous

await Task.WhenAll(xx) instead of Task.WaitAll(xx)  which is Synchronous way

cancellation token can only cancel un-started tasks:
```c#
try
{
    cancelationTokenSource.CancelAfter(300000);
    // await cancellableTask.CalculateAsync1(datapoints, cancelationTokenSource.Token); // not ideal, as all task are queued

    await cancellableTask.CalculateAsync2(datapoints, cancelationTokenSource.Token); //good effect
}
catch (TaskCanceledException)
{
    Console.WriteLine("Task cancelled");
}

public async Task<IEnumerable<string>> CalculateAsync2(IEnumerable<int> datapoints, CancellationToken token)
{
    var results = new List<string>();
    foreach(var datapoint in datapoints)
    {
        var data = await CalculateByBlockAsync(datapoint, token);
        results.Add(data);
    }

    return results;
}

public async Task<IEnumerable<string>> CalculateAsync(IEnumerable<int> datapoints, CancellationToken token)
{
    var tasks = datapoints.Select(data => CalculateByBlockAsync(data, token)).ToArray();
    await Task.WhenAll(tasks);
    return tasks.Select(x => x.Result).ToList();
}
```
## LINQ

linq to objects, linq to entities, linq method sytanx, queries sytanx(from/join/on/into/where/select/group by/let/order by) apply to collections who implemented IEnumerable<T>,\
implemented by extension method, lambda expression

deferred execution: still can modify before it been accessed (lazy evaluation)

## Attribute
extends System.Attribute, define metadata, use reflection to get this metadata for some purpose(ex： valication)， predefined: Conditional, JsonIgnore, Assembly**, AttributeUsage ......

## Reflection
Assembly -> Type -> MethodInfo, PropertyInfo, Actovator.CreateInstance to instantiate an object\
late binding (doesnt not have complie time knowledge of the target assembly）

## General
C++ C#  ... -> Common Intermediated Language\
CORE FX(FCL  for framework)\
CLR (Common Lanague Runtime , like dotnet virtual machine)： JIT, Memory Management, Security, Exception Handling

dotnet core: optiomzed for the cloud, performance, microservice, high scaleablility

## dotnet 6
.net 5 unionfined of dotnet\
dotnet 6(C# 10)

MAUI (develop apps for all major platform with one code base)\
**Blazor Desktop Web Apps** (use html, css, blazor, instead of xaml)\
mini web apis for cloud native apps\
more devices targets\
**hot reload**\
improvements in Runtime/Build Time\
EF core performance improvements

## dotnet 7

upgrade assitance\
http3(QUIC)\
improvements in Runtime/Build Time\
Can group MiniApi with a same perfix\
**Endpoint filter for controllers （easy to create at endpoint level, another is middleware)**\
gRPC improvements\
SingleR improvements\
Blazor improvements\
hot reload improvements\