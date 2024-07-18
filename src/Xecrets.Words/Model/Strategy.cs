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
/// A set of strategies of how to select from a set of parts.
/// </summary>
public enum Strategy
{
    /// <summary>
    /// No strategy, not a valid strategy
    /// </summary>
    None,

    /// <summary>
    /// Generated all parts
    /// </summary>
    All,

    /// <summary>
    /// Generate zero or more of the parts with equal probability in random order.
    /// </summary>
    Some,

    /// <summary>
    /// Generate exactly one of the parts with equal probability.
    /// </summary>
    One,

    /// <summary>
    /// Generate exactly one part, with preference to required part that has not yet been generated.
    /// </summary>
    OneRequired,

    /// <summary>
    /// Generate zero or one of the parts with equal probability, but only if no required parts have been generated.
    /// </summary>
    ZeroOrOne,

    /// <summary>
    /// Generate only required parts, and only if it's the last chance to generate them.
    /// </summary>
    IfRequired,
}
