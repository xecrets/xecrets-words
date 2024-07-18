#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Implementation](Xecrets.Words.Implementation.md 'Xecrets.Words.Implementation')

## StrongRandom Class

A random number generator

```csharp
public class StrongRandom :
Xecrets.Words.Abstractions.IRandom
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; StrongRandom

Implements [IRandom](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IRandom 'Xecrets.Words.Abstractions.IRandom')
### Methods

<a name='Xecrets.Words.Implementation.StrongRandom.Random(int,int,string)'></a>

## StrongRandom.Random(int, int, string) Method

Return a cryptographically random integer between min and max (exclusive).

```csharp
public int Random(int min, int max, string id);
```
#### Parameters

<a name='Xecrets.Words.Implementation.StrongRandom.Random(int,int,string).min'></a>

`min` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The lowest value returned

<a name='Xecrets.Words.Implementation.StrongRandom.Random(int,int,string).max'></a>

`max` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The value returned is less than this

<a name='Xecrets.Words.Implementation.StrongRandom.Random(int,int,string).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

An arbitrary identifier, primarily used for unit testing, diagnostics and debugging.

Implements [Random(int, int, string)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IRandom.Random(int,int,string) 'Xecrets.Words.Abstractions.IRandom.Random(int, int, string)')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A value, such that min LE value GT max, except for special cases:  
min == max returns min - 1  
min > max return max