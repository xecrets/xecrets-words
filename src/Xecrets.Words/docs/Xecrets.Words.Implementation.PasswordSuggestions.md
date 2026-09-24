#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Implementation](Xecrets.Words.Implementation.md 'Xecrets.Words.Implementation')

## PasswordSuggestions Class

Suggest passwords and words using default settings and trigrams matching
[System.Globalization.CultureInfo.CurrentUICulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentuiculture 'System.Globalization.CultureInfo.CurrentUICulture'), falling back
to English when no trigrams for that culture are available.

```csharp
public class PasswordSuggestions : Xecrets.Words.Abstractions.IPasswordSuggestions
```

Inheritance [System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System.Object') → PasswordSuggestions

Implements [IPasswordSuggestions](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IPasswordSuggestions 'Xecrets.Words.Abstractions.IPasswordSuggestions')
### Methods

<a name='Xecrets.Words.Implementation.PasswordSuggestions.SimplePassword()'></a>

## PasswordSuggestions.SimplePassword() Method

Suggest a simple password, easy to remember and type, but with lower
entropy.

```csharp
public string SimplePassword();
```

Implements [SimplePassword()](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IPasswordSuggestions.SimplePassword() 'Xecrets.Words.Abstractions.IPasswordSuggestions.SimplePassword()')

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')  
A simple password.

<a name='Xecrets.Words.Implementation.PasswordSuggestions.StrongPassword()'></a>

## PasswordSuggestions.StrongPassword() Method

Suggest a strong password with high entropy.

```csharp
public string StrongPassword();
```

Implements [StrongPassword()](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IPasswordSuggestions.StrongPassword() 'Xecrets.Words.Abstractions.IPasswordSuggestions.StrongPassword()')

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')  
A strong password.

<a name='Xecrets.Words.Implementation.PasswordSuggestions.Word(int)'></a>

## PasswordSuggestions.Word(int) Method

Suggest a pronounceable word with an upper case first letter.

```csharp
public string Word(int length);
```
#### Parameters

<a name='Xecrets.Words.Implementation.PasswordSuggestions.Word(int).length'></a>

`length` [System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System.Int32')

The length of the word, at least 3.

Implements [Word(int)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IPasswordSuggestions.Word(int) 'Xecrets.Words.Abstractions.IPasswordSuggestions.Word(int)')

#### Returns
[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System.String')  
A word of the given length.