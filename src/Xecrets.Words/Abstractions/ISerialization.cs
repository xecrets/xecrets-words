﻿#region Coypright and GPL License

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
/// Serialize and deserialize trigrams.
/// </summary>
public interface ISerialization
{
    /// <summary>
    /// Serialize trigrams to a JSON string.
    /// </summary>
    /// <param name="trigrams">The <see cref="Trigrams"/> to serialize.</param>
    /// <returns>A string with JSON.</returns>
    string Serialize(Trigrams trigrams);

    /// <summary>
    /// Deserialize a JSON string to a type.
    /// </summary>
    /// <typeparam name="T">The type to deserialize to.</typeparam>
    /// <param name="json">A string with JSON to deserialize.</param>
    /// <returns>The deserialized object instance.</returns>
    T Deserialize<T>(string json) where T : new();
}
