#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Implementation](Xecrets.Words.Implementation.md 'Xecrets.Words.Implementation')

## DefaultCulture Class

A default implementation of [ICulture](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.ICulture 'Xecrets.Words.Abstractions.ICulture'), using [System.Globalization.CultureInfo.InvariantCulture](https://docs.microsoft.com/en-us/dotnet/api/System.Globalization.CultureInfo.InvariantCulture 'System.Globalization.CultureInfo.InvariantCulture') and [AsciiOnly](Xecrets.Words.Implementation.DefaultCulture.md#Xecrets.Words.Implementation.DefaultCulture.AsciiOnly 'Xecrets.Words.Implementation.DefaultCulture.AsciiOnly') set to  
`true`.

```csharp
public class DefaultCulture :
Xecrets.Words.Abstractions.ICulture
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DefaultCulture

Implements [ICulture](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.ICulture 'Xecrets.Words.Abstractions.ICulture')
### Properties

<a name='Xecrets.Words.Implementation.DefaultCulture.AsciiOnly'></a>

## DefaultCulture.AsciiOnly Property

Use only ASCII characters.

```csharp
public bool AsciiOnly { get; set; }
```

Implements [AsciiOnly](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.ICulture.AsciiOnly 'Xecrets.Words.Abstractions.ICulture.AsciiOnly')

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Xecrets.Words.Implementation.DefaultCulture.CultureInfo'></a>

## DefaultCulture.CultureInfo Property

The Invariant Culture.

```csharp
public System.Globalization.CultureInfo CultureInfo { get; set; }
```

Implements [CultureInfo](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.ICulture.CultureInfo 'Xecrets.Words.Abstractions.ICulture.CultureInfo')

#### Property Value
[System.Globalization.CultureInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Globalization.CultureInfo 'System.Globalization.CultureInfo')