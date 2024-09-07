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
/// Generate passwords.
/// </summary>
public interface IGenerator
{
    /// <summary>
    /// Generate a new word of a given length. As long as there's at least one valid word in the vocabulary of the given length,
    /// it's guaranteed to generate something. Otherwise it may actually fail, but in practice it won't happen with a reasonable
    /// vocabulary.
    /// </summary>
    /// <param name="trigrams">The <see cref="Trigrams"/> to use.</param>
    /// <param name="length">The length of the word to generate</param>
    /// <returns>A word of the given length</returns>
    /// <exception cref="ArgumentOutOfRangeException">The length must be at least 3.</exception>
    /// <exception cref="InvalidOperationException">No word was possible to generate of that length.</exception>
    /// <remarks>
    /// Word generation is done in a recursive fashion with backtracking if a dead end is hit.
    /// </remarks>
    string Word(Trigrams trigrams, int length);

    /// <summary>
    /// Generate a password.
    /// </summary>
    /// <param name="trigrams">The <see cref="Trigrams"/> to use.</param>
    /// <param name="parts">The <see cref="Part"/>s to use.</param>
    /// <param name="policy">The <see cref="Policy"/> to use.</param>
    /// <returns></returns>
    string Generate(Trigrams trigrams, IEnumerable<Part> parts, Policy policy);
}
