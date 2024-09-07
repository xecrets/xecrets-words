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
/// Builds a password from a set of <see cref="Part"/>s and <see
/// cref="Strategy"/> options.
/// </summary>
public interface IBuilder
{
    /// <summary>
    /// Add group of parts to the password, using the provided strategy for inclusion.
    /// </summary>
    /// <param name="parts"></param>
    /// <param name="strategy"></param>
    /// <returns>A reference to the builder.</returns>
    IBuilder Add(Part[] parts, Strategy strategy);

    /// <summary>
    /// Produce the sequence of <see cref="Part"/>s according to the strategies
    /// and policy.
    /// </summary>
    /// <param name="policy">The <see cref="Policy"/> for required types and
    /// determine what constitutes special characters.</param>
    /// <returns>A sequence of <see cref="Part"/>s that can be used to actually
    /// generate the password.</returns>
    IEnumerable<Part> Build(Policy policy);
}
