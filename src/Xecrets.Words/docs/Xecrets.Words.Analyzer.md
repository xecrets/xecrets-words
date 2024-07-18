#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words](Xecrets.Words.md 'Xecrets.Words')

## Analyzer Class

Perform trigram analysis of text streams.

```csharp
public class Analyzer :
Xecrets.Words.Abstractions.IAnalyzer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Analyzer

Implements [IAnalyzer](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IAnalyzer 'Xecrets.Words.Abstractions.IAnalyzer')
### Properties

<a name='Xecrets.Words.Analyzer.Vocabulary'></a>

## Analyzer.Vocabulary Property

The [Vocabulary](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IAnalyzer.Vocabulary 'Xecrets.Words.Abstractions.IAnalyzer.Vocabulary') of words found in the text stream,  
including occurrence statistics.

```csharp
public Xecrets.Words.Model.Vocabulary Vocabulary { get; }
```

Implements [Vocabulary](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IAnalyzer.Vocabulary 'Xecrets.Words.Abstractions.IAnalyzer.Vocabulary')

#### Property Value
[Vocabulary](Xecrets.Words.Model.Vocabulary.md 'Xecrets.Words.Model.Vocabulary')
### Methods

<a name='Xecrets.Words.Analyzer.AddAsync(Xecrets.Words.Abstractions.ICulture,System.IO.TextReader)'></a>

## Analyzer.AddAsync(ICulture, TextReader) Method

Add words from a text stream to the vocabulary.

```csharp
public System.Threading.Tasks.Task AddAsync(Xecrets.Words.Abstractions.ICulture culture, System.IO.TextReader reader);
```
#### Parameters

<a name='Xecrets.Words.Analyzer.AddAsync(Xecrets.Words.Abstractions.ICulture,System.IO.TextReader).culture'></a>

`culture` [ICulture](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.ICulture 'Xecrets.Words.Abstractions.ICulture')

An [ICulture](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.ICulture 'Xecrets.Words.Abstractions.ICulture') instance, primarily used  
            to ensure proper lower casing.

<a name='Xecrets.Words.Analyzer.AddAsync(Xecrets.Words.Abstractions.ICulture,System.IO.TextReader).reader'></a>

`reader` [System.IO.TextReader](https://docs.microsoft.com/en-us/dotnet/api/System.IO.TextReader 'System.IO.TextReader')

A [System.IO.TextReader](https://docs.microsoft.com/en-us/dotnet/api/System.IO.TextReader 'System.IO.TextReader') to analyze.

Implements [AddAsync(ICulture, TextReader)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IAnalyzer.AddAsync(Xecrets.Words.Abstractions.ICulture,System.IO.TextReader) 'Xecrets.Words.Abstractions.IAnalyzer.AddAsync(Xecrets.Words.Abstractions.ICulture, System.IO.TextReader)')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
A waitable [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').

<a name='Xecrets.Words.Analyzer.Trigrams(bool)'></a>

## Analyzer.Trigrams(bool) Method

Extract [Trigrams(bool)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IAnalyzer.Trigrams(bool) 'Xecrets.Words.Abstractions.IAnalyzer.Trigrams(bool)') from the vocabulary.

```csharp
public Xecrets.Words.Model.Trigrams Trigrams(bool asciiOnly);
```
#### Parameters

<a name='Xecrets.Words.Analyzer.Trigrams(bool).asciiOnly'></a>

`asciiOnly` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Set to true if only A-Z ASCII should be  
            included.

Implements [Trigrams(bool)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IAnalyzer.Trigrams(bool) 'Xecrets.Words.Abstractions.IAnalyzer.Trigrams(bool)')

#### Returns
[Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')  
The [Trigrams(bool)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IAnalyzer.Trigrams(bool) 'Xecrets.Words.Abstractions.IAnalyzer.Trigrams(bool)')