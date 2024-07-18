#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Implementation](Xecrets.Words.Implementation.md 'Xecrets.Words.Implementation')

## EntropyCalculator Class

Various methods to calculate the entropy of a password.

```csharp
public class EntropyCalculator :
Xecrets.Words.Abstractions.IEntropyCalculator
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntropyCalculator

Implements [IEntropyCalculator](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IEntropyCalculator 'Xecrets.Words.Abstractions.IEntropyCalculator')
### Methods

<a name='Xecrets.Words.Implementation.EntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy)'></a>

## EntropyCalculator.Entropy(Trigrams, string, Policy) Method

Estimate the entropy of a given password.

```csharp
public double Entropy(Xecrets.Words.Model.Trigrams trigrams, string password, Xecrets.Words.Model.Policy policy);
```
#### Parameters

<a name='Xecrets.Words.Implementation.EntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to use.

<a name='Xecrets.Words.Implementation.EntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy).password'></a>

`password` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The password to calculate.

<a name='Xecrets.Words.Implementation.EntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy).policy'></a>

`policy` [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')

The [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy') to use.

Implements [Entropy(Trigrams, string, Policy)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IEntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy) 'Xecrets.Words.Abstractions.IEntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams, string, Xecrets.Words.Model.Policy)')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
An estimated policy.

<a name='Xecrets.Words.Implementation.EntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy)'></a>

## EntropyCalculator.Entropy(Trigrams, IEnumerable<Part>, Policy) Method

Estimate the low and high entropy range for a given set of [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')s.

```csharp
public (double lo,double hi) Entropy(Xecrets.Words.Model.Trigrams trigrams, System.Collections.Generic.IEnumerable<Xecrets.Words.Model.Part> parts, Xecrets.Words.Model.Policy policy);
```
#### Parameters

<a name='Xecrets.Words.Implementation.EntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to use.

<a name='Xecrets.Words.Implementation.EntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy).parts'></a>

`parts` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')s to use.

<a name='Xecrets.Words.Implementation.EntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy).policy'></a>

`policy` [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')

The [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy') to use.

Implements [Entropy(Trigrams, IEnumerable&lt;Part&gt;, Policy)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IEntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy) 'Xecrets.Words.Abstractions.IEntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams, System.Collections.Generic.IEnumerable<Xecrets.Words.Model.Part>, Xecrets.Words.Model.Policy)')

#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
A (lo, hi) tuple of entropy estimates.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')

<a name='Xecrets.Words.Implementation.EntropyCalculator.EstimateEntropy(Xecrets.Words.Model.Trigrams,int)'></a>

## EntropyCalculator.EstimateEntropy(Trigrams, int) Method

Estimate reasonably quickly the entropy in bits of a word of a given  
length. It's not exact, but generally from ad hoc testing it appears to  
consistently produce lower values than the exact calculation, which is  
what we want. A reasonable estimate is that it's perhaps 0.5 bits lower  
than the exact value / character

```csharp
public double EstimateEntropy(Xecrets.Words.Model.Trigrams trigrams, int length);
```
#### Parameters

<a name='Xecrets.Words.Implementation.EntropyCalculator.EstimateEntropy(Xecrets.Words.Model.Trigrams,int).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to use.

<a name='Xecrets.Words.Implementation.EntropyCalculator.EstimateEntropy(Xecrets.Words.Model.Trigrams,int).length'></a>

`length` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The number of characters to calculate for

Implements [EstimateEntropy(Trigrams, int)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IEntropyCalculator.EstimateEntropy(Xecrets.Words.Model.Trigrams,int) 'Xecrets.Words.Abstractions.IEntropyCalculator.EstimateEntropy(Xecrets.Words.Model.Trigrams, int)')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
An estimated entropy in bits

<a name='Xecrets.Words.Implementation.EntropyCalculator.ExactEntropy(Xecrets.Words.Model.Trigrams,int)'></a>

## EntropyCalculator.ExactEntropy(Trigrams, int) Method

Typically only used for internal calibration, it's probably very slow.

```csharp
public double ExactEntropy(Xecrets.Words.Model.Trigrams trigrams, int length);
```
#### Parameters

<a name='Xecrets.Words.Implementation.EntropyCalculator.ExactEntropy(Xecrets.Words.Model.Trigrams,int).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to use.

<a name='Xecrets.Words.Implementation.EntropyCalculator.ExactEntropy(Xecrets.Words.Model.Trigrams,int).length'></a>

`length` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Number of characters in word.

Implements [ExactEntropy(Trigrams, int)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IEntropyCalculator.ExactEntropy(Xecrets.Words.Model.Trigrams,int) 'Xecrets.Words.Abstractions.IEntropyCalculator.ExactEntropy(Xecrets.Words.Model.Trigrams, int)')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
The entropy in bits of that length