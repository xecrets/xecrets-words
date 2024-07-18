#### [Xecrets.Words](index.md 'index')

## Xecrets.Words.Implementation Namespace

| Classes | |
| :--- | :--- |
| [Builder](Xecrets.Words.Implementation.Builder.md 'Xecrets.Words.Implementation.Builder') | Builds a password from a set of [Part](Xecrets.Words.Model.Part.md 'Xecrets.Words.Model.Part')s and [Strategy](Xecrets.Words.Model.md#Xecrets.Words.Model.Strategy 'Xecrets.Words.Model.Strategy') options. |
| [BuilderFactory](Xecrets.Words.Implementation.BuilderFactory.md 'Xecrets.Words.Implementation.BuilderFactory') | A factory to produce [IBuilder](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IBuilder 'Xecrets.Words.Abstractions.IBuilder') instances. |
| [DefaultCulture](Xecrets.Words.Implementation.DefaultCulture.md 'Xecrets.Words.Implementation.DefaultCulture') | A default implementation of [ICulture](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.ICulture 'Xecrets.Words.Abstractions.ICulture'), using [System.Globalization.CultureInfo.InvariantCulture](https://docs.microsoft.com/en-us/dotnet/api/System.Globalization.CultureInfo.InvariantCulture 'System.Globalization.CultureInfo.InvariantCulture') and [AsciiOnly](Xecrets.Words.Implementation.DefaultCulture.md#Xecrets.Words.Implementation.DefaultCulture.AsciiOnly 'Xecrets.Words.Implementation.DefaultCulture.AsciiOnly') set to<br/>`true`. |
| [EntropyCalculator](Xecrets.Words.Implementation.EntropyCalculator.md 'Xecrets.Words.Implementation.EntropyCalculator') | Various methods to calculate the entropy of a password. |
| [Generator](Xecrets.Words.Implementation.Generator.md 'Xecrets.Words.Implementation.Generator') | Generate passwords. |
| [Serialization](Xecrets.Words.Implementation.Serialization.md 'Xecrets.Words.Implementation.Serialization') | Serialize and deserialize trigrams. |
| [StrongRandom](Xecrets.Words.Implementation.StrongRandom.md 'Xecrets.Words.Implementation.StrongRandom') | A random number generator |
| [Validation](Xecrets.Words.Implementation.Validation.md 'Xecrets.Words.Implementation.Validation') | Validate a password against a policy and calculate the entropy of a password. |
