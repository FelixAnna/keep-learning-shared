# Summary
- DbContextPool
- First-Level Cache
- Disable AutoDetectChanges
- NoTracking
- Avoid multiple include
- User Lazy Loading instead of Eager Loading when necessary
- Query Plan caching
- CompiledQuery
- Second Level Cache

# DbContextPool
### Benifit
Introduce DbContextPool to reuse connections and reduce the cost of create new connection for every request ([default scope](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.entityframeworkservicecollectionextensions.adddbcontext?view=efcore-3.1))
* Make sure the DbContext dont hold any state (private filed / properties)
* DbContextPool only supported after ef core 2.0+ (that means EF6.0 dont have this feature)
    ```
    In version 2.0 we are introducing a new way to register custom DbContext types in dependency injection which transparently * * * introduces a pool of reusable DbContext instances.
    ```
### Code
```
services.AddDbContextPool<BloggingContext>(options => options.UseSqlServer(connectionString));
```
[Refer Link](https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-2.0)



# First-Level Cache
### Benifit
If we have frequently query on same dateset in same DBContext, the first level cache can reduce the return time.
* If we are using DbSet<SomeTable>.Find(xx) method, it will first try to find in caching, if have data, it will return data from cache without materialize cost; if no expected data then query from database and perform materialize.
* This is current connection level cache, not share by different connections

### Code
```
var product = context.Products.Find(productId);
```
[Refer Link](https://docs.microsoft.com/en-us/ef/ef6/fundamentals/performance/perf-whitepaper?redirectedfrom=MSDN#31-object-caching)
[EF core](https://www.learnentityframeworkcore.com/dbcontext#object-caching)


# Disable AutoDetectChanges
### Benifit
When using Find, invocations to this methods by default will trigger a validation of the object cache in order to detect changes that are still pending to commit to database. This can be very expensive if there are many items in the object cache or if there are many items being added to the object cache. We can disable this to improve performance.
* But if we need modify data in database, we either dont use this or call DetectChanges () manually after saving.
### Code
```
context.Configuration.AutoDetectChangesEnabled = false;
var product = context.Products.Find(productId);
context.Configuration.AutoDetectChangesEnabled = true;
```
[Refer Link](https://docs.microsoft.com/en-us/ef/ef6/fundamentals/performance/perf-whitepaper?redirectedfrom=MSDN#31-object-caching)
[EF Core](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.changetracking.changetracker.autodetectchangesenabled?view=efcore-2.1#Microsoft_EntityFrameworkCore_ChangeTracking_ChangeTracker_AutoDetectChangesEnabled)



# NoTracking
### Benifit
By default, if we change (CUD) some data, ef will change the related entity state to(added, modified, deleted) from unchanged, and if we query some enity (return some entity), EF will loading the result into [ObjectStateManager](https://referencesource.microsoft.com/#System.Data.Entity/System/Data/Objects/ObjectStateManager.cs), we can disable this if we dont need repeatly query the same set in one request and we dont need change data in database (readonly case). 

* If we are in a read-only scenario, we can use this option, this means we have disable object cache (First Level cache).
* But if we are repeatedly querying for the same entities on the same context, we can see a performance benefit from enabling change tracking.
* Or If we need modify data in database, then dont use NoTracking.

### Code
```
var productsForCategory = from p in context.Products.AsNoTracking()
                                where p.Category.CategoryName == selectedCategory
                                select p;
```
[Refer Link](https://docs.microsoft.com/en-us/ef/ef6/fundamentals/performance/perf-whitepaper?redirectedfrom=MSDN#5-notracking-queries)
[EF Core](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.changetracking.changetracker.querytrackingbehavior?view=efcore-2.1)



# Avoid multiple include
# Benifit
Avoid multiple include can reduce the tables joined in one query, finally reduce the memory/cpu used by this sql query on database side.
* If we use many include in Linq, the generated command will contains many Outer Join or Union for each include, Queries like this will bring large connected graphs in our database in a single payload, which will cost a lot of resources and result in performance issue.
* to solve this, we can break down unnecessary inlude into a few sub-queries 
### Code
###### Before breaking the query:
```
using (NorthwindEntities context = new NorthwindEntities())
{
	var customers = from c in context.Customers.Include(c => c.Orders)
					where c.LastName.StartsWith(lastNameParameter)
					select c;

	foreach (Customer customer in customers)
	{
		...
	}
}
```
###### After breaking the query:
```
using (NorthwindEntities context = new NorthwindEntities())
{
	var orders = from o in context.Orders
				 where o.Customer.LastName.StartsWith(lastNameParameter)
				 select o;

	orders.Load();

	var customers = from c in context.Customers
					where c.LastName.StartsWith(lastNameParameter)
					select c;

	foreach (Customer customer in customers)
	{
		...
	}
}
```
[Refer Link](https://docs.microsoft.com/en-us/ef/ef6/fundamentals/performance/perf-whitepaper?redirectedfrom=MSDN#822-performance-concerns-with-multiple-includes)





# User Lazy Loading instead of Eager Loading when necessary
### Benifit

Eager loading will send a big query to db and query many data at once (may need many cpu and memory on both sides in a short time), while lazy loading can only return target data set quickly, and get navigation properties data whenever we used them (get the navigation properties in one query, and stored in object cache).
### Code
```
context.ContextOptions.LazyLoadingEnabled = true;
//Notice that the Include method call is missing in the query
var ukCustomers = context.Customers.Where(c => c.Address.Country == "UK");
```
[Refer Link](https://docs.microsoft.com/en-us/ef/ef6/fundamentals/performance/perf-whitepaper?redirectedfrom=MSDN#82-how-to-choose-between-lazy-loading-and-eager-loading)



# Query Plan caching
### Benifit
Enable query plan caching to reduce the cost of complie for Linq to Entities, Linq to Queries, Enity SQL, CompiledQuery
* By default, they are enabled
### Code
```
var q = context.Products.Where(p => p.Category.CategoryName == "Beverages");
var query = from customer in context.Customer
								where customer.CustomerId == id
								select new
								{
									customer.CustomerId,
									customer.Name
								};
```
[Refer Link](https://docs.microsoft.com/en-us/ef/ef6/fundamentals/performance/perf-whitepaper?redirectedfrom=MSDN#32-query-plan-caching)

# CompiledQuery
### Benifit
Skip(), Take(), Contains() and DefautIfEmpty() might polluting query plan cache if we pass variables to them, because those LINQ operation does not generate query plan with parameters but with constants. for skip and take, we can use lambda to avoid this case.

### Code 
```
var customers = context.Customers.OrderBy(c => c.LastName);
for (var i = 0; i < count; ++i)
{
	var currentCustomer = customers.Skip(() => i).FirstOrDefault();
	ProcessCustomer(currentCustomer);
}
```
[Refer Link](https://docs.microsoft.com/en-us/ef/ef6/fundamentals/performance/perf-whitepaper?redirectedfrom=MSDN#42-using-functions-that-produce-queries-with-constants)

# Second Level Cache
### Benifit
With results caching (also known as "second-level caching"), you keep the results of queries in a local cache. When issuing a query, you first see if the results are available locally before you query against the store. **While results caching isn't directly supported by Entity Framework**, it's possible to add a second level cache by using a wrapping provider (like redis, memcache).

###### for EF core 2.0+ we have several options:
- EntityFramework-Plus: https://github.com/zzzprojects/EntityFramework-Plus (open source, 1.5k star, last commit in 15days)
- EntityFrameworkCore.Cacheable: https://github.com/SteffenMangold/EntityFrameworkCore.Cacheable (open source, 100+ star, last commit in 1 year ago)
- NCache: https://www.alachisoft.com/ncache/ef-core-cache.html (need licence)

[Refer Link](https://docs.microsoft.com/en-us/ef/ef6/fundamentals/performance/perf-whitepaper?redirectedfrom=MSDN#35-results-caching)
[EF Core](https://docs.microsoft.com/en-us/ef/core/extensions/#entityframeworkcorecacheable)
