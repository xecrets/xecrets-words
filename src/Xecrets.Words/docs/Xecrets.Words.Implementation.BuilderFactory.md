#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Implementation](Xecrets.Words.Implementation.md 'Xecrets.Words.Implementation')

## BuilderFactory Class

A factory to produce [IBuilder](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilder 'Xecrets.Words.Abstractions.IBuilder') instances.

```csharp
public class BuilderFactory :
Xecrets.Words.Abstractions.IBuilderFactory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BuilderFactory

Implements [IBuilderFactory](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilderFactory 'Xecrets.Words.Abstractions.IBuilderFactory')
### Methods

<a name='Xecrets.Words.Implementation.BuilderFactory.Create()'></a>

## BuilderFactory.Create() Method

Create an [IBuilder](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilder 'Xecrets.Words.Abstractions.IBuilder') instance.

```csharp
public Xecrets.Words.Abstractions.IBuilder Create();
```

Implements [Create()](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilderFactory.Create() 'Xecrets.Words.Abstractions.IBuilderFactory.Create()')

#### Returns
[IBuilder](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilder 'Xecrets.Words.Abstractions.IBuilder')  
A new instance.