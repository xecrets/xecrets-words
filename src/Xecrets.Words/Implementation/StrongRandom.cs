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

using System.Security.Cryptography;

using Xecrets.Words.Abstractions;

namespace Xecrets.Words.Implementation;

/// <inheritdoc/>
public class StrongRandom : IRandom
{
    private readonly RandomNumberGenerator _random = RandomNumberGenerator.Create();

    /// <inheritdoc/>
    public int Random(int min, int max, string id)
    {
        if (min < 0 || max < 0)
        {
            throw new ArgumentException($"Min and Max must be positive integers [{id}].");
        }

        if (min == max)
        {
            return min - 1;
        }
        if (min > max)
        {
            return max;
        }

        byte[] bytes = new byte[sizeof(long)];
        _random.GetBytes(bytes);
        long value = Math.Abs(BitConverter.ToInt64(bytes, 0));

        return (int)((value % (max - min)) + min);
    }
}
