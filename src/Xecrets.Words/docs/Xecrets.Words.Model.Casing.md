#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Model](Xecrets.Words.Model.md 'Xecrets.Words.Model')

## Casing Enum

An enumeration of different casing tactics.

```csharp
public enum Casing
```
### Fields

<a name='Xecrets.Words.Model.Casing.Ignore'></a>

`Ignore` 0

Don't do any casing

<a name='Xecrets.Words.Model.Casing.Lower'></a>

`Lower` 1

All lower case, e.g. a noop

<a name='Xecrets.Words.Model.Casing.Camel'></a>

`Camel` 2

Camel case, e.g. camelCase - but in a random position if a starting trigram is found in the
word, otherwise at a random position starting from the second character to the next to last.

<a name='Xecrets.Words.Model.Casing.TitleOrCamel'></a>

`TitleOrCamel` 3

Camel case, e.g. camelCase or Title case, e.g. Titlecase chosen randomly.

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

<a name='Xecrets.Words.Model.Casing.Upper'></a>

`Upper` 7

Unconditionally the whole word is upper case.