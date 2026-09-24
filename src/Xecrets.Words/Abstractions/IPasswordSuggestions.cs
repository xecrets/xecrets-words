#region Copyright and GPL License

/*
 * Xecrets Words - Copyright © 2024-2025 Svante Seleborg, All Rights Reserved.
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

namespace Xecrets.Words.Abstractions;

/// <summary>
/// Suggest passwords and words using default settings and trigrams matching
/// <see cref="System.Globalization.CultureInfo.CurrentUICulture"/>, falling back
/// to English when no trigrams for that culture are available.
/// </summary>
public interface IPasswordSuggestions
{
    /// <summary>
    /// Suggest a simple password, easy to remember and type, but with lower
    /// entropy.
    /// </summary>
    /// <returns>A simple password.</returns>
    string SimplePassword();

    /// <summary>
    /// Suggest a strong password with high entropy.
    /// </summary>
    /// <returns>A strong password.</returns>
    string StrongPassword();

    /// <summary>
    /// Suggest a pronounceable word with an upper case first letter.
    /// </summary>
    /// <param name="length">The length of the word, at least 3.</param>
    /// <returns>A word of the given length.</returns>
    string Word(int length);
}
