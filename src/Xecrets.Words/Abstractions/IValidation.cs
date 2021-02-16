#region Coypright and GPL License

/*
 * Xecrets Words - Copyright © 2024, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets Words, a library and sample app to produce rememberable and pronounceable strong passwords.
 * 
 * If you use any part of this code in your software, please see https://www.gnu.org/licenses/ for details of what this means for you.
 *
 * Xecrets Words is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *
 * Xecrets Words is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along with Xecrets Words.  If not, see <https://www.gnu.org/licenses/>.
 *
 * The source repository can be found at https://github.com/ please go there for more information, suggestions and
 * contributions. You may also visit https://www.axantum.com for more information about the author.
*/

#endregion Coypright and GPL License

using Xecrets.Words.Model;

namespace Xecrets.Words.Abstractions;

public interface IValidation
{
    /// <summary>
    /// Validate a password against the policy.
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    bool Validate(Trigrams trigrams, string password, Policy policy);

    /// <summary>
    /// Calculate the bit strength of a password, only based on the password itself, not
    /// taking into account any other factors like how it is generated or with what policy.
    /// The assumption is that if one instance of a character class, like lower case, is in
    /// the password, then all instances of that character class may be in the password.
    /// </summary>
    /// <param name="password"></param>
    /// <returns>An upper bound estimate of the entropy in bits.</returns>
    /// <remarks>
    /// The password is filtered using a list of common passwords in various european contries,
    /// compiled from https://www.kaggle.com/datasets/prasertk/top-200-passwords-by-country-2021
    /// which in turn is based on https://nordpass.com/most-common-passwords-list/ . If part of
    /// the provided password is found in this list, that part is removed from the password before
    /// calculating, thus effectively treating such a part as adding 0 bits of entropy.
    /// The estimate should be considered a maximum value under optimal conditions, it is probably
    /// lower if the attacker knows or guesses any part of the policy used to generate the password.
    /// </remarks>
    int Entropy(string password, Policy policy);
}
