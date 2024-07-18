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

namespace Xecrets.Words.Model;

/// <summary>
/// An enumeration of different casing tactics.
/// </summary>
public enum Casing
{
    /// <summary>
    /// Don't do any casing
    /// </summary>
    Ignore,

    /// <summary>
    /// All lower case, e.g. a noop
    /// </summary>
    Lower,

    /// <summary>
    /// Camel case, e.g. camelCase - but in a random position if a starting trigram is found in the
    /// word, otherwise at a random position starting from the second character to the next to last.
    /// </summary>
    Camel,

    /// <summary>
    /// Camel case, e.g. camelCase or Title case, e.g. Titlecase chosen randomly.
    /// </summary>
    TitleOrCamel,

    /// <summary>
    /// Pascal case, e.g. PascalCase, where the second part is chosen randomly if possible, otherwise
    /// at a random posiition starting from the second character to the next to last.
    /// </summary>
    Pascal,

    /// <summary>
    /// Randomly choose between lower and upper case in the whole word.
    /// </summary>
    Random,

    /// <summary>
    /// Unconditionally the first character upper case.
    /// </summary>
    Title,

    /// <summary>
    /// Unconditionally the whole word is upper case.
    /// </summary>
    Upper,
}

