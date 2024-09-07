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

using Xecrets.Words.Model;

namespace Xecrets.Words.Abstractions;

/// <summary>
/// Various methods to calculate the entropy of a password.
/// </summary>
public interface IEntropyCalculator
{
    /// <summary>
    /// Estimate the low and high entropy range for a given set of <see
    /// cref="Part"/>s.
    /// </summary>
    /// <param name="trigrams">The <see cref="Trigrams"/> to use.</param>
    /// <param name="parts">The <see cref="Part"/>s to use.</param>
    /// <param name="policy">The <see cref="Policy"/> to use.</param>
    /// <returns>A (lo, hi) tuple of entropy estimates.</returns>
    /// <exception cref="ArgumentException"></exception>
    (double lo, double hi) Entropy(Trigrams trigrams, IEnumerable<Part> parts, Policy policy);

    /// <summary>
    /// Estimate the entropy of a given password.
    /// </summary>
    /// <param name="trigrams">The <see cref="Trigrams"/> to use.</param>
    /// <param name="password">The password to calculate.</param>
    /// <param name="policy">The <see cref="Policy"/> to use.</param>
    /// <returns>An estimated policy.</returns>
    double Entropy(Trigrams trigrams, string password, Policy policy);

    /// <summary>
    /// Estimate reasonably quickly the entropy in bits of a word of a given
    /// length. It's not exact, but generally from ad hoc testing it appears to
    /// consistently produce lower values than the exact calculation, which is
    /// what we want. A reasonable estimate is that it's perhaps 0.5 bits lower
    /// than the exact value / character
    /// </summary>
    /// <param name="trigrams">The <see cref="Trigrams"/> to use.</param>
    /// <param name="length">The number of characters to calculate for</param>
    /// <returns>An estimated entropy in bits</returns>
    double EstimateEntropy(Trigrams trigrams, int length);

    /// <summary>
    /// Typically only used for internal calibration, it's probably very slow.
    /// </summary>
    /// <param name="trigrams">The <see cref="Trigrams"/> to use.</param>
    /// <param name="length">Number of characters in word.</param>
    /// <returns>The entropy in bits of that length</returns>
    double ExactEntropy(Trigrams trigrams, int length);
}
