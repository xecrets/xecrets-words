#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Model](Xecrets.Words.Model.md 'Xecrets.Words.Model')

## Part Class

A part of a password.

```csharp
public class Part :
System.IEquatable<Xecrets.Words.Model.Part>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Part

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='Xecrets.Words.Model.Part.Part(Xecrets.Words.Model.Op,int,int,Xecrets.Words.Model.Casing)'></a>

## Part(Op, int, int, Casing) Constructor

A part of a password.

```csharp
public Part(Xecrets.Words.Model.Op Op, int Min, int Max, Xecrets.Words.Model.Casing Casing=Xecrets.Words.Model.Casing.Ignore);
```
#### Parameters

<a name='Xecrets.Words.Model.Part.Part(Xecrets.Words.Model.Op,int,int,Xecrets.Words.Model.Casing).Op'></a>

`Op` [Op](Xecrets.Words.Model.md#Xecrets.Words.Model.Op 'Xecrets.Words.Model.Op')

The [operation](Xecrets.Words.Model.Part.md#Xecrets.Words.Model.Part.Op 'Xecrets.Words.Model.Part.Op') for this part.

<a name='Xecrets.Words.Model.Part.Part(Xecrets.Words.Model.Op,int,int,Xecrets.Words.Model.Casing).Min'></a>

`Min` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The minimum number of characters.

<a name='Xecrets.Words.Model.Part.Part(Xecrets.Words.Model.Op,int,int,Xecrets.Words.Model.Casing).Max'></a>

`Max` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The maximum number of characters.

<a name='Xecrets.Words.Model.Part.Part(Xecrets.Words.Model.Op,int,int,Xecrets.Words.Model.Casing).Casing'></a>

`Casing` [Casing](Xecrets.Words.Model.md#Xecrets.Words.Model.Casing 'Xecrets.Words.Model.Casing')

The [Casing](Xecrets.Words.Model.Part.md#Xecrets.Words.Model.Part.Casing 'Xecrets.Words.Model.Part.Casing') to use, if relevant.
### Properties

<a name='Xecrets.Words.Model.Part.Casing'></a>

## Part.Casing Property

The [Casing](Xecrets.Words.Model.Part.md#Xecrets.Words.Model.Part.Casing 'Xecrets.Words.Model.Part.Casing') to use, if relevant.

```csharp
public Xecrets.Words.Model.Casing Casing { get; set; }
```

#### Property Value
[Casing](Xecrets.Words.Model.md#Xecrets.Words.Model.Casing 'Xecrets.Words.Model.Casing')

<a name='Xecrets.Words.Model.Part.Max'></a>

## Part.Max Property

The maximum number of characters.

```csharp
public int Max { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='Xecrets.Words.Model.Part.Min'></a>

## Part.Min Property

The minimum number of characters.

```csharp
public int Min { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='Xecrets.Words.Model.Part.Op'></a>

## Part.Op Property

The [operation](Xecrets.Words.Model.Part.md#Xecrets.Words.Model.Part.Op 'Xecrets.Words.Model.Part.Op') for this part.

```csharp
public Xecrets.Words.Model.Op Op { get; set; }
```

#### Property Value
[Op](Xecrets.Words.Model.md#Xecrets.Words.Model.Op 'Xecrets.Words.Model.Op')