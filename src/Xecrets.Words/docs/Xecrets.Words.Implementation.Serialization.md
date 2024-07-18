#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Implementation](Xecrets.Words.Implementation.md 'Xecrets.Words.Implementation')

## Serialization Class

Serialize and deserialize trigrams.

```csharp
public class Serialization :
Xecrets.Words.Abstractions.ISerialization
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Serialization

Implements [ISerialization](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.ISerialization 'Xecrets.Words.Abstractions.ISerialization')
### Methods

<a name='Xecrets.Words.Implementation.Serialization.Deserialize_T_(string)'></a>

## Serialization.Deserialize<T>(string) Method

Deserialize a JSON string to a type.

```csharp
public T Deserialize<T>(string json)
    where T : new();
```
#### Type parameters

<a name='Xecrets.Words.Implementation.Serialization.Deserialize_T_(string).T'></a>

`T`

The type to deserialize to.
#### Parameters

<a name='Xecrets.Words.Implementation.Serialization.Deserialize_T_(string).json'></a>

`json` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A string with JSON to deserialize.

Implements [Deserialize&lt;T&gt;(string)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.ISerialization.Deserialize_T_(string) 'Xecrets.Words.Abstractions.ISerialization.Deserialize<T>(string)')

#### Returns
[T](Xecrets.Words.Implementation.Serialization.md#Xecrets.Words.Implementation.Serialization.Deserialize_T_(string).T 'Xecrets.Words.Implementation.Serialization.Deserialize<T>(string).T')  
The deserialized object instance.

<a name='Xecrets.Words.Implementation.Serialization.Serialize(Xecrets.Words.Model.Trigrams)'></a>

## Serialization.Serialize(Trigrams) Method

Serialize trigrams to a JSON string.

```csharp
public string Serialize(Xecrets.Words.Model.Trigrams trigrams);
```
#### Parameters

<a name='Xecrets.Words.Implementation.Serialization.Serialize(Xecrets.Words.Model.Trigrams).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to serialize.

Implements [Serialize(Trigrams)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.ISerialization.Serialize(Xecrets.Words.Model.Trigrams) 'Xecrets.Words.Abstractions.ISerialization.Serialize(Xecrets.Words.Model.Trigrams)')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A string with JSON.