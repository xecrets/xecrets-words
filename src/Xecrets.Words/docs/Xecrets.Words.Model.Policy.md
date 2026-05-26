#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Model](Xecrets.Words.Model.md 'Xecrets.Words.Model')

## Policy Class

A password policy.

```csharp
public record Policy : System.IEquatable<Xecrets.Words.Model.Policy>
```

Inheritance [System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System.Object') → Policy

Implements [System.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System.IEquatable`1')[Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System.IEquatable`1')
### Constructors

<a name='Xecrets.Words.Model.Policy.Policy(int,int,bool,bool,string)'></a>

## Policy(int, int, bool, bool, string) Constructor

A password policy.

```csharp
public Policy(int Length, int Entropy=-1, bool UpperLowerCase=true, bool Digits=true, string Special="!@#$%&*+-_=;:'\",./?");
```
#### Parameters

<a name='Xecrets.Words.Model.Policy.Policy(int,int,bool,bool,string).Length'></a>

`Length` [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

The minimum length to meet the policy.

<a name='Xecrets.Words.Model.Policy.Policy(int,int,bool,bool,string).Entropy'></a>

`Entropy` [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

The minimum entropy to meet the policy, or -1 if not
            part of the policy.

<a name='Xecrets.Words.Model.Policy.Policy(int,int,bool,bool,string).UpperLowerCase'></a>

`UpperLowerCase` [System.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System.Boolean')

Whether both upper and lower case characters
            are required.

<a name='Xecrets.Words.Model.Policy.Policy(int,int,bool,bool,string).Digits'></a>

`Digits` [System.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System.Boolean')

Whether digits are required.

<a name='Xecrets.Words.Model.Policy.Policy(int,int,bool,bool,string).Special'></a>

`Special` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

A set of special characters of which at least one must
            be included, or an empty string.
### Properties

<a name='Xecrets.Words.Model.Policy.Default'></a>

## Policy.Default Property

A default strong policy.

```csharp
public static Xecrets.Words.Model.Policy Default { get; }
```

#### Property Value
[Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')

<a name='Xecrets.Words.Model.Policy.Digits'></a>

## Policy.Digits Property

Whether digits are required.

```csharp
public bool Digits { get; init; }
```

#### Property Value
[System.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System.Boolean')

<a name='Xecrets.Words.Model.Policy.Entropy'></a>

## Policy.Entropy Property

The minimum entropy to meet the policy, or -1 if not
            part of the policy.

```csharp
public int Entropy { get; init; }
```

#### Property Value
[System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

<a name='Xecrets.Words.Model.Policy.Length'></a>

## Policy.Length Property

The minimum length to meet the policy.

```csharp
public int Length { get; init; }
```

#### Property Value
[System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

<a name='Xecrets.Words.Model.Policy.SingleWord'></a>

## Policy.SingleWord Property

A simple policy for a word.

```csharp
public static Xecrets.Words.Model.Policy SingleWord { get; }
```

#### Property Value
[Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')

<a name='Xecrets.Words.Model.Policy.Special'></a>

## Policy.Special Property

A set of special characters of which at least one must
            be included, or an empty string.

```csharp
public string Special { get; init; }
```

#### Property Value
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

<a name='Xecrets.Words.Model.Policy.UpperLowerCase'></a>

## Policy.UpperLowerCase Property

Whether both upper and lower case characters
            are required.

```csharp
public bool UpperLowerCase { get; init; }
```

#### Property Value
[System.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System.Boolean')