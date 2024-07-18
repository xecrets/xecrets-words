#### [Xecrets.Words](index.md 'index')
### [Xecrets.Words.Implementation](Xecrets.Words.Implementation.md 'Xecrets.Words.Implementation')

## Validation Class

Validate a password against a policy and calculate the entropy of a password.

```csharp
public class Validation :
Xecrets.Words.Abstractions.IValidation
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Validation

Implements [IValidation](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IValidation 'Xecrets.Words.Abstractions.IValidation')
### Methods

<a name='Xecrets.Words.Implementation.Validation.Entropy(string,Xecrets.Words.Model.Policy)'></a>

## Validation.Entropy(string, Policy) Method

Calculate the bit strength of a password, only based on the password itself, not  
taking into account any other factors like how it is generated or with what policy.  
The assumption is that if one instance of a character class, like lower case, is in  
the password, then all instances of that character class may be in the password.

```csharp
public int Entropy(string password, Xecrets.Words.Model.Policy policy);
```
#### Parameters

<a name='Xecrets.Words.Implementation.Validation.Entropy(string,Xecrets.Words.Model.Policy).password'></a>

`password` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The string to calculate the entropy of.

<a name='Xecrets.Words.Implementation.Validation.Entropy(string,Xecrets.Words.Model.Policy).policy'></a>

`policy` [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')

The [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy') to use.

Implements [Entropy(string, Policy)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IValidation.Entropy(string,Xecrets.Words.Model.Policy) 'Xecrets.Words.Abstractions.IValidation.Entropy(string, Xecrets.Words.Model.Policy)')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
An upper bound estimate of the entropy in bits.

### Remarks
The password is filtered using a list of common passwords in various european contries,  
compiled from https://www.kaggle.com/datasets/prasertk/top-200-passwords-by-country-2021  
which in turn is based on https://nordpass.com/most-common-passwords-list/ . If part of  
the provided password is found in this list, that part is removed from the password before  
calculating, thus effectively treating such a part as adding 0 bits of entropy.  
The estimate should be considered a maximum value under optimal conditions, it is probably  
lower if the attacker knows or guesses any part of the policy used to generate the password.

<a name='Xecrets.Words.Implementation.Validation.Validate(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy)'></a>

## Validation.Validate(Trigrams, string, Policy) Method

Compare a given password against a policy. It's the callers responsibility to ensure that the generator  
is configured so it's actually possibly to comply with the policy.

```csharp
public bool Validate(Xecrets.Words.Model.Trigrams trigrams, string password, Xecrets.Words.Model.Policy policy);
```
#### Parameters

<a name='Xecrets.Words.Implementation.Validation.Validate(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy).trigrams'></a>

`trigrams` [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams')

The [Trigrams](Xecrets.Words.Model.Trigrams.md 'Xecrets.Words.Model.Trigrams') to use.

<a name='Xecrets.Words.Implementation.Validation.Validate(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy).password'></a>

`password` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The password to validate against the policy.

<a name='Xecrets.Words.Implementation.Validation.Validate(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy).policy'></a>

`policy` [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy')

The [Policy](Xecrets.Words.Model.Policy.md 'Xecrets.Words.Model.Policy') to use.

Implements [Validate(Trigrams, string, Policy)](Xecrets.Words.Abstractions.md#Xecrets.Words.Abstractions.IValidation.Validate(Xecrets.Words.Model.Trigrams,string,Xecrets.Words.Model.Policy) 'Xecrets.Words.Abstractions.IValidation.Validate(Xecrets.Words.Model.Trigrams, string, Xecrets.Words.Model.Policy)')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the password conforms to the policy, false otherwise.