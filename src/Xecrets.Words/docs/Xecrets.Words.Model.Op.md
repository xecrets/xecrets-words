#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Model](Xecrets.Words.Model.md 'Xecrets.Words.Model')

## Op Enum

An enumeration of typical password part operations.

```csharp
public enum Op
```
### Fields

<a name='Xecrets.Words.Model.Op.None'></a>

`None` 0

No operation, invalid value.

<a name='Xecrets.Words.Model.Op.Word'></a>

`Word` 1

Generate a word.
The Min value is the minimum length of the word.
The Max value is the maximum length of the word.

<a name='Xecrets.Words.Model.Op.Digit'></a>

`Digit` 2

Generate a sequence of digits.
The Min value is the minimum length of the sequence.
The Max value is the maximum length of the sequence.

<a name='Xecrets.Words.Model.Op.Special'></a>

`Special` 3

Generate a sequence of special characters.
The Min value is the minimum length of the sequence.
The Max value is the maximum length of the sequence.