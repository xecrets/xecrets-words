#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Implementation](Xecrets.Words.Implementation.md 'Xecrets.Words.Implementation')

## StrengthMeter Class

Estimate the strength of a password and map it to a color suitable for a strength indicator.

```csharp
public class StrengthMeter : Xecrets.Words.Abstractions.IStrengthMeter
```

Inheritance [System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System.Object') → StrengthMeter

Implements [IStrengthMeter](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IStrengthMeter 'Xecrets.Words.Abstractions.IStrengthMeter')
### Methods

<a name='Xecrets.Words.Implementation.StrengthMeter.StrengthPercent(string)'></a>

## StrengthMeter.StrengthPercent(string) Method

Estimate the strength of a password as a percentage, where 128 bits of entropy is 100%.

```csharp
public int StrengthPercent(string password);
```
#### Parameters

<a name='Xecrets.Words.Implementation.StrengthMeter.StrengthPercent(string).password'></a>

`password` [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')

The password to estimate the strength of.

Implements [StrengthPercent(string)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IStrengthMeter.StrengthPercent(string) 'Xecrets.Words.Abstractions.IStrengthMeter.StrengthPercent(string)')

#### Returns
[System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')  
The estimated strength in percent. A non-empty password is always at least 1.

<a name='Xecrets.Words.Implementation.StrengthMeter.ToStrengthColor(int)'></a>

## StrengthMeter.ToStrengthColor(int) Method

Map a strength percentage, as returned by [StrengthPercent(string)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IStrengthMeter.StrengthPercent(string) 'Xecrets.Words.Abstractions.IStrengthMeter.StrengthPercent(string)'), to a color.

```csharp
public Xecrets.Words.Model.StrengthColor ToStrengthColor(int strength);
```
#### Parameters

<a name='Xecrets.Words.Implementation.StrengthMeter.ToStrengthColor(int).strength'></a>

`strength` [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

The strength in percent.

Implements [ToStrengthColor(int)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IStrengthMeter.ToStrengthColor(int) 'Xecrets.Words.Abstractions.IStrengthMeter.ToStrengthColor(int)')

#### Returns
[StrengthColor](Xecrets.Words.Model.StrengthColor.md 'Xecrets.Words.Model.StrengthColor')  
The [StrengthColor](Xecrets.Words.Model.StrengthColor.md 'Xecrets.Words.Model.StrengthColor') for the strength.