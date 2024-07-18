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

/// <summary>
/// Perform trigram analysis of text streams.
/// </summary>
public interface IAnalyzer
{
    /// <summary>
    /// The <see cref="Vocabulary"/> of words found in the text stream,
    /// including occurrence statistics.
    /// </summary>
    Vocabulary Vocabulary { get; }

    /// <summary>
    /// Extract <see cref="Trigrams"/> from the vocabulary.
    /// </summary>
    /// <param name="asciiOnly">Set to true if only A-Z ASCII should be
    /// included.</param>
    /// <returns>The <see cref="Trigrams"/></returns>
    Trigrams Trigrams(bool asciiOnly);

    /// <summary>
    /// Add words from a text stream to the vocabulary.
    /// </summary>
    /// <param name="culture">An <see cref="ICulture"/> instance, primarily used
    /// to ensure proper lower casing.</param>
    /// <param name="reader">A <see cref="TextReader"/> to analyze.</param>
    /// <returns>A waitable <see cref="Task"/>.</returns>
    Task AddAsync(ICulture culture, TextReader reader);
}
