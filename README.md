# PropLoader

A class library that helps load EF Core-related entity properties.

## How to Use

1. Clone/download the project.
2. Open and build the solution.
3. Go to PropLoader > bin > Debug > net8.0.
4. Copy the PropLoader.dll > Create a lib folder in your project > Paste the .dll file.
5. Right click your project > Add > Reference > Browse
6. Select and add the .dll file.
7. Use the utility classes to load related entity properties. (see below example usages)

## PropLoader Utility Classes
1. ListOptions<TEntity>
2. IncludeOptions<TEntity>
3. OptionsBuilder

## Example Usages
### ListOptions and IncludeOptions 
```csharp
// Option 1
var listOpt = new ListOptions<TEntity>();
listOptions.Add(x => x.ObjectA);
var includeOptions = new IncludeOptions<TEntity>(listOptions)

// Option 2
var includeOpt1 = new IncludeOptions<TEntity>(
       x => x.ObjectA,
       x => x.ObjectB);

// Option 3 - including a child object
var includeOpt2 = new IncludeOptions<TEntity>(
       x => x.ObjectA,
       x => x.ObjectA.ChildObjectA);
```

### OptionsBuilder
```csharp
// Generic repository GetByID() method
public async Task<TEntity?> GetByID(TID id, IncludeOptions<TEntity>? includeOptions = null)
{
    IQueryable<TEntity> query = OptionsBuilder.Build<TEntity>(this.dbContext.Set<TEntity>(), includeOptions);
    return query.SingleOrDefault(e => EF.Property<TID>(e, this.PropertyID)!.Equals(id));
}
