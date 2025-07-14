#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Model](Xecrets.Words.Model.md 'Xecrets.Words.Model')

## Strategy Enum

A set of strategies of how to select from a set of parts.

```csharp
public enum Strategy
```
### Fields

<a name='Xecrets.Words.Model.Strategy.None'></a>

`None` 0

No strategy, not a valid strategy

<a name='Xecrets.Words.Model.Strategy.All'></a>

`All` 1

Generated all parts

<a name='Xecrets.Words.Model.Strategy.Some'></a>

`Some` 2

Generate zero or more of the parts with equal probability in random order.

<a name='Xecrets.Words.Model.Strategy.One'></a>

`One` 3

Generate exactly one of the parts with equal probability.

<a name='Xecrets.Words.Model.Strategy.OneRequired'></a>

`OneRequired` 4

Generate exactly one part, with preference to required part that has not yet been generated.

<a name='Xecrets.Words.Model.Strategy.ZeroOrOne'></a>

`ZeroOrOne` 5

Generate zero or one of the parts with equal probability, but only if no required parts have been generated.

<a name='Xecrets.Words.Model.Strategy.IfRequired'></a>

`IfRequired` 6

Generate only required parts, and only if it's the last chance to generate them.