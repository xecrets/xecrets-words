#### [Xecrets.Words](index.md 'index')

## Xecrets.Words.Model Namespace

| Classes | |
| :--- | :--- |
| [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part') | A part of a password. |
| [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy') | A password policy. |
| [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') | Trigrams extracted from text by an analyzer. |
| [Vocabulary](Xecrets.Words.Model.Vocabulary.md 'Xecrets.Words.Model.Vocabulary') | The parsed vocabulary of words after analyzation of text, along with<br/>occurrence statistics in a dictionary. |
### Enums

<a name='Xecrets.Words.Model.Casing'></a>

## Casing Enum

An enumeration of different casing tactics.

```csharp
public enum Casing
```
### Fields

<a name='Xecrets.Words.Model.Casing.Camel'></a>

`Camel` 2

Camel case, e.g. camelCase - but in a random position if a starting trigram is found in the  
word, otherwise at a random position starting from the second character to the next to last.

<a name='Xecrets.Words.Model.Casing.Ignore'></a>

`Ignore` 0

Don't do any casing

<a name='Xecrets.Words.Model.Casing.Lower'></a>

`Lower` 1

All lower case, e.g. a noop

<a name='Xecrets.Words.Model.Casing.Pascal'></a>

`Pascal` 4

Pascal case, e.g. PascalCase, where the second part is chosen randomly if possible, otherwise  
at a random posiition starting from the second character to the next to last.

<a name='Xecrets.Words.Model.Casing.Random'></a>

`Random` 5

Randomly choose between lower and upper case in the whole word.

<a name='Xecrets.Words.Model.Casing.Title'></a>

`Title` 6

Unconditionally the first character upper case.

<a name='Xecrets.Words.Model.Casing.TitleOrCamel'></a>

`TitleOrCamel` 3

Camel case, e.g. camelCase or Title case, e.g. Titlecase chosen randomly.

<a name='Xecrets.Words.Model.Casing.Upper'></a>

`Upper` 7

Unconditionally the whole word is upper case.

<a name='Xecrets.Words.Model.Op'></a>

## Op Enum

An enumeration of typical password part operations.

```csharp
public enum Op
```
### Fields

<a name='Xecrets.Words.Model.Op.Digit'></a>

`Digit` 2

Generate a sequence of digits.  
The Min value is the minimum length of the sequence.  
The Max value is the maximum length of the sequence.

<a name='Xecrets.Words.Model.Op.None'></a>

`None` 0

No operation, invalid value.

<a name='Xecrets.Words.Model.Op.Special'></a>

`Special` 3

Generate a sequence of special characters.  
The Min value is the minimum length of the sequence.  
The Max value is the maximum length of the sequence.

<a name='Xecrets.Words.Model.Op.Word'></a>

`Word` 1

Generate a word.  
The Min value is the minimum length of the word.  
The Max value is the maximum length of the word.

<a name='Xecrets.Words.Model.Strategy'></a>

## Strategy Enum

A set of strategies of how to select from a set of parts.

```csharp
public enum Strategy
```
### Fields

<a name='Xecrets.Words.Model.Strategy.All'></a>

`All` 1

Generated all parts

<a name='Xecrets.Words.Model.Strategy.IfRequired'></a>

`IfRequired` 6

Generate only required parts, and only if it's the last chance to generate them.

<a name='Xecrets.Words.Model.Strategy.None'></a>

`None` 0

No strategy, not a valid strategy

<a name='Xecrets.Words.Model.Strategy.One'></a>

`One` 3

Generate exactly one of the parts with equal probability.

<a name='Xecrets.Words.Model.Strategy.OneRequired'></a>

`OneRequired` 4

Generate exactly one part, with preference to required part that has not yet been generated.

<a name='Xecrets.Words.Model.Strategy.Some'></a>

`Some` 2

Generate zero or more of the parts with equal probability in random order.

<a name='Xecrets.Words.Model.Strategy.ZeroOrOne'></a>

`ZeroOrOne` 5

Generate zero or one of the parts with equal probability, but only if no required parts have been generated.