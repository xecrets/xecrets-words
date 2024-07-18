#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Implementation](Xecrets.Words.Implementation.md 'Xecrets.Words.Implementation')

## Generator Class

Generate passwords.

```csharp
public class Generator :
Xecrets.Words.Abstractions.IGenerator
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Generator

Implements [IGenerator](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IGenerator 'Xecrets.Words.Abstractions.IGenerator')
### Methods

<a name='Xecrets.Words.Implementation.Generator.Generate(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy)'></a>

## Generator.Generate(Trigrams, IEnumerable<Part>, Policy) Method

Generate a password.

```csharp
public string Generate(Xecrets.Words.Model.Trigrams trigrams, System.Collections.Generic.IEnumerable<Xecrets.Words.Model.Part> parts, Xecrets.Words.Model.Policy policy);
```
#### Parameters

<a name='Xecrets.Words.Implementation.Generator.Generate(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to use.

<a name='Xecrets.Words.Implementation.Generator.Generate(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy).parts'></a>

`parts` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')s to use.

<a name='Xecrets.Words.Implementation.Generator.Generate(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy).policy'></a>

`policy` [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')

The [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy') to use.

Implements [Generate(Trigrams, IEnumerable&lt;Part&gt;, Policy)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IGenerator.Generate(Xecrets.Words.Model.Trigrams,System.Collections.Generic.IEnumerable_Xecrets.Words.Model.Part_,Xecrets.Words.Model.Policy) 'Xecrets.Words.Abstractions.IGenerator.Generate(Xecrets.Words.Model.Trigrams, System.Collections.Generic.IEnumerable<Xecrets.Words.Model.Part>, Xecrets.Words.Model.Policy)')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Xecrets.Words.Implementation.Generator.Word(Xecrets.Words.Model.Trigrams,int)'></a>

## Generator.Word(Trigrams, int) Method

Generate a new word of a given length. As long as there's at least one valid word in the vocabulary of the given length,  
it's guaranteed to generate something. Otherwise it may actually fail, but in practice it won't happen with a reasonable  
vocabulary.

```csharp
public string Word(Xecrets.Words.Model.Trigrams trigrams, int length);
```
#### Parameters

<a name='Xecrets.Words.Implementation.Generator.Word(Xecrets.Words.Model.Trigrams,int).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to use.

<a name='Xecrets.Words.Implementation.Generator.Word(Xecrets.Words.Model.Trigrams,int).length'></a>

`length` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The length of the word to generate

Implements [Word(Trigrams, int)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IGenerator.Word(Xecrets.Words.Model.Trigrams,int) 'Xecrets.Words.Abstractions.IGenerator.Word(Xecrets.Words.Model.Trigrams, int)')

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