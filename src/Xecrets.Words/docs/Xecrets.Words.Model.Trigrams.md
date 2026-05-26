#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Model](Xecrets.Words.Model.md 'Xecrets.Words.Model')

## Trigrams Class

Trigrams extracted from text by an analyzer.

```csharp
public class Trigrams
```

Inheritance [System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System.Object') → Trigrams
### Properties

<a name='Xecrets.Words.Model.Trigrams.Ending'></a>

## Trigrams.Ending Property

All ending trigrams found, along with occurrence statistics.

```csharp
public System.Collections.Generic.Dictionary<string,int> Ending { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='Xecrets.Words.Model.Trigrams.LengthEntropy'></a>

## Trigrams.LengthEntropy Property

A set of precalculated estimates for entropy for different lengths of a
generated word.

```csharp
public System.Collections.Generic.Dictionary<int,double> LengthEntropy { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='Xecrets.Words.Model.Trigrams.Middle'></a>

## Trigrams.Middle Property

All middle trigrams found, along with occurrence statistics.

```csharp
public System.Collections.Generic.Dictionary<string,int> Middle { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='Xecrets.Words.Model.Trigrams.Starting'></a>

## Trigrams.Starting Property

All starting trigrams found, along with occurrence statistics.

```csharp
public System.Collections.Generic.Dictionary<string,int> Starting { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System.Collections.Generic.Dictionary`2')