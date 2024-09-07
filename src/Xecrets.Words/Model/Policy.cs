#region Copyright and GPL License

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

#endregion Copyright and GPL License

namespace Xecrets.Words.Model;

/// <summary>
/// A password policy.
/// </summary>
/// <param name="Length">The minimum length to meet the policy.</param>
/// <param name="Entropy">The minimum entropy to meet the policy, or -1 if not
/// part of the policy.</param>
/// <param name="UpperLowerCase">Whether both upper and lower case characters
/// are required.</param>
/// <param name="Digits">Whether digits are required.</param>
/// <param name="Special">A set of special characters of which at least one must
/// be included, or an empty string.</param>
public record Policy(int Length, int Entropy = -1, bool UpperLowerCase = true, bool Digits = true, string Special = "!@#$%&*+-_=;:'\",./?")
{
    /// <summary>
    /// A default strong policy.
    /// </summary>
    public static Policy Default { get; } = new Policy(16, 96);

    /// <summary>
    /// A simple policy for a word.
    /// </summary>
    public static Policy SingleWord { get; } = new Policy(8, -1, UpperLowerCase: false, Digits: false, Special: string.Empty);
}
