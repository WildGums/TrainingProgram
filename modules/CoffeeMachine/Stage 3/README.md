# Coffee Machine

## Stage 3

In stis stage you should be able to make two types of coffee and to add supplies.

**For making one portion of capuccino you need:**

1 cup

10g of sugar

30g of coffee

50ml of water

50 ml of milk

**For making one portion of americano you need:**

1 cup

5g of sugar

40g of coffee

50ml of water

0 ml of milk

##### This is example how it should look like:

****
Making coffee example:

```html
Hello, how can I help you?
1. Make coffee
2. Service mode
0. Exit
1
What type of coffee do you prefer?
1. Americano
2. Capuccino
0. Back
1
Good choice, enjoy your coffee!
```
Then make sure if the available quantity of supplies has decreased by recipe required value

Add supplies example:

```html
=====
Service mode:
1. Show remainings
2. Add supplies
0. Back
2
Please add supply:
Coffe beans (g)
20
Sugar (g)
15
Milk (ml)
22
Water (ml)
50
Cups
2
```
Then make sure if the available quantity of supplies has increased by the entered values

****

To complete this stage the links below might be helpful:

[TryParse Method](https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=net-5.0)  
[Boolean logical operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators)