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

using System.Diagnostics.CodeAnalysis;

using Xecrets.Words.Abstractions;

namespace Xecrets.Words.Test;

internal class FakeRandom : IRandom
{
    private int _next = 0;

    private readonly Dictionary<string, int> _calls = [];

    public FakeRandom()
    {
        RandomFunc = DefaultRandom;
    }

    public int DefaultRandom(int min, int max, string id, int call)
    {
        if (min < 0 || max < 0)
        {
            throw new ArgumentException($"Min and Max must be positive integers [{id}].");
        }

        if (min > max)
        {
            return max;
        }

        _next = Math.Abs(_next + 293);
        return min == max ? -1 : (_next % (max - min)) + min;
    }

    public int Random(int min, int max, string id)
    {
        if (_calls.TryGetValue(id, out int value))
        {
            ++value;
        }
        _calls[id] = value;
        return RandomFunc(min, max, id, value);
    }

    [AllowNull]
    public Func<int, int, string, int, int> RandomFunc { get; set; }
}