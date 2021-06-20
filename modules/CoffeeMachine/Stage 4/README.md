# Coffee Machine

## Stage 4

In at this stage it should be possible to have standard recipes like capuccino and americano and add new coffee recipes and the number of required consumables for them. 
And also add new ingredients to consumables, increase their quantity and create recipes with their use.
They should appear in the list of available drinks

****
This is how it should look like:

#### Adding recipe:

```html
Enter the following details or ` (~) if you want to cancel the input
Please enter the name of the coffee product:
Espresso
Please enter the required number of supplies:
Coffe beans (g):
40
Sugar (g):
0
Milk (ml):
0
Water (ml):
50
Cups
1
```


#### Adding new ingredient:  

```html
Enter the following details or ` (~) if you want to cancel the input
Please add new ingredient:
Ingredient name:
Salt
Measure
g
```
If ~ or `` is pressed, there should be a return to the service mode

Also implement the ability to delete recipes and ingredients. If there is a recipe with an ingredient to be removed, it must also be removed.

#### Removing the ingredient: 
```html
Enter the number of the ingredient you want to delete
1. Coffee Beans
2. Sugar
3. Milk
4. Water
5. Cups
0. Back
1
A recipe containing this ingredient has been found.
This will remove the recipe with that ingredient.
Do you want to continue? Yes (y) / No (n):
y
Ingredient and recipe have been removed
```
#### Removing the recipe: 
```html
Enter the number of the recipe you want to delete
1. Americano
2. Capuccino
0. Back
1
Recipe has been removed
```

****

To complete this stage the links below might be helpful:

[Dictionary Overview in C#](https://www.c-sharpcorner.com/UploadFile/b17487/dictionary-overview-in-C-Sharp/)

[How to initialize a dictionary with a collection initializer](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer)  

[C# Dictionary Code Examples](https://www.c-sharpcorner.com/UploadFile/mahesh/dictionary-in-C-Sharp/)

[Methods in C#](https://docs.microsoft.com/en-us/dotnet/csharp/methods)

[C# Collections](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections)

[IEnumerable Interface](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=net-5.0)

[LINQ overview](https://docs.microsoft.com/en-us/dotnet/standard/linq/)

[Queryable.FirstOrDefault Method](https://docs.microsoft.com/en-us/dotnet/api/system.linq.queryable.firstordefault?view=netcore-3.1)
