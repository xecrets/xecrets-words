#### [Xecrets.Words](index.md 'index')

## Xecrets.Words.Implementation Namespace

| Classes | |
| :--- | :--- |
| [Builder](Xecrets.Words.Implementation.Builder.md 'Xecrets.Words.Implementation.Builder') | Builds a password from a set of [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')s and [Strategy](Xecrets.Words.Model.Strategy.md 'Xecrets.Words.Model.Strategy') options. |
| [BuilderFactory](Xecrets.Words.Implementation.BuilderFactory.md 'Xecrets.Words.Implementation.BuilderFactory') | A factory to produce [IBuilder](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilder 'Xecrets.Words.Abstractions.IBuilder') instances. |
| [DefaultCulture](Xecrets.Words.Implementation.DefaultCulture.md 'Xecrets.Words.Implementation.DefaultCulture') | A default implementation of [ICulture](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.ICulture 'Xecrets.Words.Abstractions.ICulture'), using [System.Globalization.CultureInfo.InvariantCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture 'System.Globalization.CultureInfo.InvariantCulture') and [AsciiOnly](Xecrets.Words.Implementation.DefaultCulture.md#Xecrets.Words.Implementation.DefaultCulture.AsciiOnly 'Xecrets.Words.Implementation.DefaultCulture.AsciiOnly') set to `true`. |
| [EntropyCalculator](Xecrets.Words.Implementation.EntropyCalculator.md 'Xecrets.Words.Implementation.EntropyCalculator') | Various methods to calculate the entropy of a password. |
| [Generator](Xecrets.Words.Implementation.Generator.md 'Xecrets.Words.Implementation.Generator') | Generate passwords. |
| [PasswordSuggestions](Xecrets.Words.Implementation.PasswordSuggestions.md 'Xecrets.Words.Implementation.PasswordSuggestions') | Suggest passwords and words using default settings and trigrams matching [System.Globalization.CultureInfo.CurrentUICulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentuiculture 'System.Globalization.CultureInfo.CurrentUICulture'), falling back to English when no trigrams for that culture are available. |
| [Serialization](Xecrets.Words.Implementation.Serialization.md 'Xecrets.Words.Implementation.Serialization') | Serialize and deserialize trigrams. |
| [StrengthMeter](Xecrets.Words.Implementation.StrengthMeter.md 'Xecrets.Words.Implementation.StrengthMeter') | Estimate the strength of a password and map it to a color suitable for a strength indicator. |
| [StrongRandom](Xecrets.Words.Implementation.StrongRandom.md 'Xecrets.Words.Implementation.StrongRandom') | A random number generator |
| [Validation](Xecrets.Words.Implementation.Validation.md 'Xecrets.Words.Implementation.Validation') | Validate a password against a policy and calculate the entropy of a password. |
