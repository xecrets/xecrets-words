#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Implementation](Xecrets.Words.Implementation.md 'Xecrets.Words.Implementation')

## Builder Class

Builds a password from a set of [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')s and [Strategy](Xecrets.Words.Model.md#Xecrets.Words.Model.Strategy 'Xecrets.Words.Model.Strategy') options.

```csharp
public class Builder :
Xecrets.Words.Abstractions.IBuilder
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Builder

Implements [IBuilder](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilder 'Xecrets.Words.Abstractions.IBuilder')
### Methods

<a name='Xecrets.Words.Implementation.Builder.Add(Xecrets.Words.Model.Part[],Xecrets.Words.Model.Strategy)'></a>

## Builder.Add(Part[], Strategy) Method

Add group of parts to the password, using the provided strategy for inclusion.

```csharp
public Xecrets.Words.Abstractions.IBuilder Add(Xecrets.Words.Model.Part[] parts, Xecrets.Words.Model.Strategy strategy);
```
#### Parameters

<a name='Xecrets.Words.Implementation.Builder.Add(Xecrets.Words.Model.Part[],Xecrets.Words.Model.Strategy).parts'></a>

`parts` [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='Xecrets.Words.Implementation.Builder.Add(Xecrets.Words.Model.Part[],Xecrets.Words.Model.Strategy).strategy'></a>

`strategy` [Strategy](Xecrets.Words.Model.md#Xecrets.Words.Model.Strategy 'Xecrets.Words.Model.Strategy')

Implements [Add(Part[], Strategy)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilder.Add(Xecrets.Words.Model.Part[],Xecrets.Words.Model.Strategy) 'Xecrets.Words.Abstractions.IBuilder.Add(Xecrets.Words.Model.Part[], Xecrets.Words.Model.Strategy)')

#### Returns
[IBuilder](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilder 'Xecrets.Words.Abstractions.IBuilder')  
A reference to the builder.

<a name='Xecrets.Words.Implementation.Builder.Build(Xecrets.Words.Model.Policy)'></a>

## Builder.Build(Policy) Method

Produce the sequence of [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')s according to the strategies  
and policy.

```csharp
public System.Collections.Generic.IEnumerable<Xecrets.Words.Model.Part> Build(Xecrets.Words.Model.Policy policy);
```
#### Parameters

<a name='Xecrets.Words.Implementation.Builder.Build(Xecrets.Words.Model.Policy).policy'></a>

`policy` [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')

The [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy') for required types and  
            determine what constitutes special characters.

Implements [Build(Policy)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilder.Build(Xecrets.Words.Model.Policy) 'Xecrets.Words.Abstractions.IBuilder.Build(Xecrets.Words.Model.Policy)')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
A sequence of [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')s that can be used to actually  
            generate the password.