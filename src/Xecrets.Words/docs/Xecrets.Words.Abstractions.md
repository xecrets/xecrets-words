#### [Xecrets.Words](index.md 'index')

## Xecrets.Words.Abstractions Namespace
### Interfaces

<a name='Xecrets.Words.Abstractions.IAnalyzer'></a>

## IAnalyzer Interface

Perform trigram analysis of text streams.

```csharp
public interface IAnalyzer
```

Derived  
&#8627; [Analyzer](Xecrets.Words.Analyzer.md 'Xecrets.Words.Analyzer')
### Properties

<a name='Xecrets.Words.Abstractions.IAnalyzer.Vocabulary'></a>

## IAnalyzer.Vocabulary Property

The [Vocabulary](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IAnalyzer.Vocabulary 'Xecrets.Words.Abstractions.IAnalyzer.Vocabulary') of words found in the text stream,  
including occurrence statistics.

```csharp
Xecrets.Words.Model.Vocabulary Vocabulary { get; }
```

#### Property Value
[Vocabulary](Xecrets.Words.Model.Vocabulary.md 'Xecrets.Words.Model.Vocabulary')
### Methods

<a name='Xecrets.Words.Abstractions.IAnalyzer.AddAsync(Xecrets.Words.Abstractions.ICulture,System.IO.TextReader)'></a>

## IAnalyzer.AddAsync(ICulture, TextReader) Method

Add words from a text stream to the vocabulary.

```csharp
System.Threading.Tasks.Task AddAsync(Xecrets.Words.Abstractions.ICulture culture, System.IO.TextReader reader);
```
#### Parameters

<a name='Xecrets.Words.Abstractions.IAnalyzer.AddAsync(Xecrets.Words.Abstractions.ICulture,System.IO.TextReader).culture'></a>

`culture` [ICulture](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.ICulture 'Xecrets.Words.Abstractions.ICulture')

An [ICulture](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.ICulture 'Xecrets.Words.Abstractions.ICulture') instance, primarily used  
            to ensure proper lower casing.

<a name='Xecrets.Words.Abstractions.IAnalyzer.AddAsync(Xecrets.Words.Abstractions.ICulture,System.IO.TextReader).reader'></a>

`reader` [System.IO.TextReader](https://docs.microsoft.com/en-us/dotnet/api/System.IO.TextReader 'System.IO.TextReader')

A [System.IO.TextReader](https://docs.microsoft.com/en-us/dotnet/api/System.IO.TextReader 'System.IO.TextReader') to analyze.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
A waitable [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').

<a name='Xecrets.Words.Abstractions.IAnalyzer.Trigrams(bool)'></a>

## IAnalyzer.Trigrams(bool) Method

Extract [Trigrams(bool)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IAnalyzer.Trigrams(bool) 'Xecrets.Words.Abstractions.IAnalyzer.Trigrams(bool)') from the vocabulary.

```csharp
Xecrets.Words.Model.Trigrams Trigrams(bool asciiOnly);
```
#### Parameters

<a name='Xecrets.Words.Abstractions.IAnalyzer.Trigrams(bool).asciiOnly'></a>

`asciiOnly` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Set to true if only A-Z ASCII should be  
            included.

#### Returns
[Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')  
The [Trigrams(bool)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IAnalyzer.Trigrams(bool) 'Xecrets.Words.Abstractions.IAnalyzer.Trigrams(bool)')

<a name='Xecrets.Words.Abstractions.IBuilder'></a>

## IBuilder Interface

Builds a password from a set of [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')s and [Strategy](Xecrets.Words.Model.md#Xecrets.Words.Model.Strategy 'Xecrets.Words.Model.Strategy') options.

```csharp
public interface IBuilder
```

Derived  
&#8627; [Builder](Xecrets.Words.Implementation.Builder.md 'Xecrets.Words.Implementation.Builder')
### Methods

<a name='Xecrets.Words.Abstractions.IBuilder.Add(Xecrets.Words.Model.Part[],Xecrets.Words.Model.Strategy)'></a>

## IBuilder.Add(Part[], Strategy) Method

Add group of parts to the password, using the provided strategy for inclusion.

```csharp
Xecrets.Words.Abstractions.IBuilder Add(Xecrets.Words.Model.Part[] parts, Xecrets.Words.Model.Strategy strategy);
```
#### Parameters

<a name='Xecrets.Words.Abstractions.IBuilder.Add(Xecrets.Words.Model.Part[],Xecrets.Words.Model.Strategy).parts'></a>

`parts` [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='Xecrets.Words.Abstractions.IBuilder.Add(Xecrets.Words.Model.Part[],Xecrets.Words.Model.Strategy).strategy'></a>

`strategy` [Strategy](Xecrets.Words.Model.md#Xecrets.Words.Model.Strategy 'Xecrets.Words.Model.Strategy')

#### Returns
[IBuilder](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilder 'Xecrets.Words.Abstractions.IBuilder')  
A reference to the builder.

<a name='Xecrets.Words.Abstractions.IBuilder.Build(Xecrets.Words.Model.Policy)'></a>

## IBuilder.Build(Policy) Method

Produce the sequence of [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')s according to the strategies  
and policy.

```csharp
System.Collections.Generic.IEnumerable<Xecrets.Words.Model.Part> Build(Xecrets.Words.Model.Policy policy);
```
#### Parameters

<a name='Xecrets.Words.Abstractions.IBuilder.Build(Xecrets.Words.Model.Policy).policy'></a>

`policy` [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')

The [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy') for required types and  
            determine what constitutes special characters.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A sequence of [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')s that can be used to actually  
            generate the password.

<a name='Xecrets.Words.Abstractions.IBuilderFactory'></a>

## IBuilderFactory Interface

A factory to produce [IBuilder](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilder 'Xecrets.Words.Abstractions.IBuilder') instances.

```csharp
public interface IBuilderFactory
```

Derived  
&#8627; [BuilderFactory](Xecrets.Words.Implementation.BuilderFactory.md 'Xecrets.Words.Implementation.BuilderFactory')
### Methods

<a name='Xecrets.Words.Abstractions.IBuilderFactory.Create()'></a>

## IBuilderFactory.Create() Method

Create an [IBuilder](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilder 'Xecrets.Words.Abstractions.IBuilder') instance.

```csharp
Xecrets.Words.Abstractions.IBuilder Create();
```

#### Returns
[IBuilder](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilder 'Xecrets.Words.Abstractions.IBuilder')  
A new instance.

<a name='Xecrets.Words.Abstractions.ICulture'></a>

## ICulture Interface

Culture specific settings.

```csharp
public interface ICulture
```

Derived  
&#8627; [DefaultCulture](Xecrets.Words.Implementation.DefaultCulture.md 'Xecrets.Words.Implementation.DefaultCulture')
### Properties

<a name='Xecrets.Words.Abstractions.ICulture.AsciiOnly'></a>

## ICulture.AsciiOnly Property

If true, only ASCII characters are used and considered.

```csharp
bool AsciiOnly { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Xecrets.Words.Abstractions.ICulture.CultureInfo'></a>

## ICulture.CultureInfo Property

The culture to use, primarily to handle upper-/lower case properly.

```csharp
System.Globalization.CultureInfo CultureInfo { get; }
```

#### Property Value
[System.Globalization.CultureInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Globalization.CultureInfo 'System.Globalization.CultureInfo')

<a name='Xecrets.Words.Abstractions.IEntropyCalculator'></a>

## IEntropyCalculator Interface

Various methods to calculate the entropy of a password.

```csharp
public interface IEntropyCalculator
```

Derived  
&#8627; [EntropyCalculator](Xecrets.Words.Implementation.EntropyCalculator.md 'Xecrets.Words.Implementation.EntropyCalculator')
### Methods

<a name='Xecrets.Words.Abstractions.IEntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy)'></a>

## IEntropyCalculator.Entropy(Trigrams, string, Policy) Method

Estimate the entropy of a given password.

```csharp
double Entropy(Xecrets.Words.Model.Trigrams trigrams, string password, Xecrets.Words.Model.Policy policy);
```
#### Parameters

<a name='Xecrets.Words.Abstractions.IEntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to use.

<a name='Xecrets.Words.Abstractions.IEntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy).password'></a>

`password` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The password to calculate.

<a name='Xecrets.Words.Abstractions.IEntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy).policy'></a>

`policy` [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')

The [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy') to use.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
An estimated policy.

<a name='Xecrets.Words.Abstractions.IEntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy)'></a>

## IEntropyCalculator.Entropy(Trigrams, IEnumerable<Part>, Policy) Method

Estimate the low and high entropy range for a given set of [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')s.

```csharp
(double lo,double hi) Entropy(Xecrets.Words.Model.Trigrams trigrams, System.Collections.Generic.IEnumerable<Xecrets.Words.Model.Part> parts, Xecrets.Words.Model.Policy policy);
```
#### Parameters

<a name='Xecrets.Words.Abstractions.IEntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to use.

<a name='Xecrets.Words.Abstractions.IEntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy).parts'></a>

`parts` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')s to use.

<a name='Xecrets.Words.Abstractions.IEntropyCalculator.Entropy(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy).policy'></a>

`policy` [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')

The [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy') to use.

#### Returns
[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')  
A (lo, hi) tuple of entropy estimates.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')

<a name='Xecrets.Words.Abstractions.IEntropyCalculator.EstimateEntropy(Xecrets.Words.Model.Trigrams,int)'></a>

## IEntropyCalculator.EstimateEntropy(Trigrams, int) Method

Estimate reasonably quickly the entropy in bits of a word of a given  
length. It's not exact, but generally from ad hoc testing it appears to  
consistently produce lower values than the exact calculation, which is  
what we want. A reasonable estimate is that it's perhaps 0.5 bits lower  
than the exact value / character

```csharp
double EstimateEntropy(Xecrets.Words.Model.Trigrams trigrams, int length);
```
#### Parameters

<a name='Xecrets.Words.Abstractions.IEntropyCalculator.EstimateEntropy(Xecrets.Words.Model.Trigrams,int).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to use.

<a name='Xecrets.Words.Abstractions.IEntropyCalculator.EstimateEntropy(Xecrets.Words.Model.Trigrams,int).length'></a>

`length` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The number of characters to calculate for

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
An estimated entropy in bits

<a name='Xecrets.Words.Abstractions.IEntropyCalculator.ExactEntropy(Xecrets.Words.Model.Trigrams,int)'></a>

## IEntropyCalculator.ExactEntropy(Trigrams, int) Method

Typically only used for internal calibration, it's probably very slow.

```csharp
double ExactEntropy(Xecrets.Words.Model.Trigrams trigrams, int length);
```
#### Parameters

<a name='Xecrets.Words.Abstractions.IEntropyCalculator.ExactEntropy(Xecrets.Words.Model.Trigrams,int).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to use.

<a name='Xecrets.Words.Abstractions.IEntropyCalculator.ExactEntropy(Xecrets.Words.Model.Trigrams,int).length'></a>

`length` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Number of characters in word.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
The entropy in bits of that length

<a name='Xecrets.Words.Abstractions.IGenerator'></a>

## IGenerator Interface

Generate passwords.

```csharp
public interface IGenerator
```

Derived  
&#8627; [Generator](Xecrets.Words.Implementation.Generator.md 'Xecrets.Words.Implementation.Generator')
### Methods

<a name='Xecrets.Words.Abstractions.IGenerator.Generate(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy)'></a>

## IGenerator.Generate(Trigrams, IEnumerable<Part>, Policy) Method

Generate a password.

```csharp
string Generate(Xecrets.Words.Model.Trigrams trigrams, System.Collections.Generic.IEnumerable<Xecrets.Words.Model.Part> parts, Xecrets.Words.Model.Policy policy);
```
#### Parameters

<a name='Xecrets.Words.Abstractions.IGenerator.Generate(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to use.

<a name='Xecrets.Words.Abstractions.IGenerator.Generate(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy).parts'></a>

`parts` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')s to use.

<a name='Xecrets.Words.Abstractions.IGenerator.Generate(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy).policy'></a>

`policy` [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')

The [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy') to use.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Xecrets.Words.Abstractions.IGenerator.Word(Xecrets.Words.Model.Trigrams,int)'></a>

## IGenerator.Word(Trigrams, int) Method

Generate a new word of a given length. As long as there's at least one valid word in the vocabulary of the given length,  
it's guaranteed to generate something. Otherwise it may actually fail, but in practice it won't happen with a reasonable  
vocabulary.

```csharp
string Word(Xecrets.Words.Model.Trigrams trigrams, int length);
```
#### Parameters

<a name='Xecrets.Words.Abstractions.IGenerator.Word(Xecrets.Words.Model.Trigrams,int).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to use.

<a name='Xecrets.Words.Abstractions.IGenerator.Word(Xecrets.Words.Model.Trigrams,int).length'></a>

`length` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The length of the word to generate

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A word of the given length

#### Exceptions

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
The length must be at least 3.

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
No word was possible to generate of that length.

### Remarks
Word generation is done in a recursive fashion with backtracking if a dead end is hit.

<a name='Xecrets.Words.Abstractions.IRandom'></a>

## IRandom Interface

A random number generator

```csharp
public interface IRandom
```

Derived  
&#8627; [StrongRandom](Xecrets.Words.Implementation.StrongRandom.md 'Xecrets.Words.Implementation.StrongRandom')
### Methods

<a name='Xecrets.Words.Abstractions.IRandom.Random(int,int,string)'></a>

## IRandom.Random(int, int, string) Method

Return a cryptographically random integer between min and max (exclusive).

```csharp
int Random(int min, int max, string id);
```
#### Parameters

<a name='Xecrets.Words.Abstractions.IRandom.Random(int,int,string).min'></a>

`min` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The lowest value returned

<a name='Xecrets.Words.Abstractions.IRandom.Random(int,int,string).max'></a>

`max` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The value returned is less than this

<a name='Xecrets.Words.Abstractions.IRandom.Random(int,int,string).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

An arbitrary identifier, primarily used for unit testing, diagnostics and debugging.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A value, such that min LE value GT max, except for special cases:  
min == max returns min - 1  
min > max return max

<a name='Xecrets.Words.Abstractions.ISerialization'></a>

## ISerialization Interface

Serialize and deserialize trigrams.

```csharp
public interface ISerialization
```

Derived  
&#8627; [Serialization](Xecrets.Words.Implementation.Serialization.md 'Xecrets.Words.Implementation.Serialization')
### Methods

<a name='Xecrets.Words.Abstractions.ISerialization.Deserialize_T_(string)'></a>

## ISerialization.Deserialize<T>(string) Method

Deserialize a JSON string to a type.

```csharp
T Deserialize<T>(string json)
    where T : new();
```
#### Type parameters

<a name='Xecrets.Words.Abstractions.ISerialization.Deserialize_T_(string).T'></a>

`T`

The type to deserialize to.
#### Parameters

<a name='Xecrets.Words.Abstractions.ISerialization.Deserialize_T_(string).json'></a>

`json` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A string with JSON to deserialize.

#### Returns
[T](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.ISerialization.Deserialize_T_(string).T 'Xecrets.Words.Abstractions.ISerialization.Deserialize<T>(string).T')  
The deserialized object instance.

<a name='Xecrets.Words.Abstractions.ISerialization.Serialize(Xecrets.Words.Model.Trigrams)'></a>

## ISerialization.Serialize(Trigrams) Method

Serialize trigrams to a JSON string.

```csharp
string Serialize(Xecrets.Words.Model.Trigrams trigrams);
```
#### Parameters

<a name='Xecrets.Words.Abstractions.ISerialization.Serialize(Xecrets.Words.Model.Trigrams).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to serialize.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A string with JSON.

<a name='Xecrets.Words.Abstractions.IValidation'></a>

## IValidation Interface

Validate a password against a policy and calculate the entropy of a password.

```csharp
public interface IValidation
```

Derived  
&#8627; [Validation](Xecrets.Words.Implementation.Validation.md 'Xecrets.Words.Implementation.Validation')
### Methods

<a name='Xecrets.Words.Abstractions.IValidation.Entropy(string,Xecrets.Words.Model.Policy)'></a>

## IValidation.Entropy(string, Policy) Method

Calculate the bit strength of a password, only based on the password itself, not  
taking into account any other factors like how it is generated or with what policy.  
The assumption is that if one instance of a character class, like lower case, is in  
the password, then all instances of that character class may be in the password.

```csharp
int Entropy(string password, Xecrets.Words.Model.Policy policy);
```
#### Parameters

<a name='Xecrets.Words.Abstractions.IValidation.Entropy(string,Xecrets.Words.Model.Policy).password'></a>

`password` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The string to calculate the entropy of.

<a name='Xecrets.Words.Abstractions.IValidation.Entropy(string,Xecrets.Words.Model.Policy).policy'></a>

`policy` [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')

The [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy') to use.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
An upper bound estimate of the entropy in bits.

### Remarks
The password is filtered using a list of common passwords in various european contries,  
compiled from https://www.kaggle.com/datasets/prasertk/top-200-passwords-by-country-2021  
which in turn is based on https://nordpass.com/most-common-passwords-list/ . If part of  
the provided password is found in this list, that part is removed from the password before  
calculating, thus effectively treating such a part as adding 0 bits of entropy.  
The estimate should be considered a maximum value under optimal conditions, it is probably  
lower if the attacker knows or guesses any part of the policy used to generate the password.

<a name='Xecrets.Words.Abstractions.IValidation.Validate(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy)'></a>

## IValidation.Validate(Trigrams, string, Policy) Method

Compare a given password against a policy. It's the callers responsibility to ensure that the generator  
is configured so it's actually possibly to comply with the policy.

```csharp
bool Validate(Xecrets.Words.Model.Trigrams trigrams, string password, Xecrets.Words.Model.Policy policy);
```
#### Parameters

<a name='Xecrets.Words.Abstractions.IValidation.Validate(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to use.

<a name='Xecrets.Words.Abstractions.IValidation.Validate(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy).password'></a>

`password` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The password to validate against the policy.

<a name='Xecrets.Words.Abstractions.IValidation.Validate(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy).policy'></a>

`policy` [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')

The [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy') to use.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the password conforms to the policy, false otherwise.