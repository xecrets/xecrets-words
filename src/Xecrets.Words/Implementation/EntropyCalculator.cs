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

using System.Text;

using Xecrets.Words.Abstractions;
using Xecrets.Words.Model;

namespace Xecrets.Words.Implementation;

public class EntropyCalculator : IEntropyCalculator
{
    public (double lo, double hi) Entropy(Trigrams trigrams, IEnumerable<Part> parts, Policy policy)
    {
        double lo = 0;
        double hi = 0;
        foreach (Part part in parts)
        {
            switch (part.Op)
            {
                case Op.Word:
                    double loWord = LengthEntropy(trigrams, part.Min);
                    lo += loWord;
                    hi += part.Max != part.Min ? LengthEntropy(trigrams, part.Max) : loWord;
                    break;
                case Op.Digit:
                    double loDigit = Math.Log2(Math.Pow(10, part.Min));
                    lo += loDigit;
                    hi += part.Max != part.Min ? Math.Log2(Math.Pow(10, part.Max)) : loDigit;
                    break;
                case Op.Special:
                    double loSpecial = Math.Log2(Math.Pow(policy.Special.Length, part.Min));
                    lo += loSpecial;
                    hi += part.Max != part.Min ? Math.Log2(Math.Pow(policy.Special.Length, part.Max)) : loSpecial;
                    break;
                case Op.None:
                default:
                    throw new ArgumentException($"Invalid/unsupported part class '{part.Op}'.");
            }

            double loCasing = part.Casing switch
            {
                Casing.Ignore => 0,
                Casing.Lower => 0,
                Casing.Camel => 1,
                Casing.TitleOrCamel => 1,
                Casing.Pascal => 2,
                Casing.Random => part.Min,
                Casing.Title => 1,
                Casing.Upper => 0,
                _ => throw new ArgumentException($"Invalid/unsupported casing '{part.Casing}'."),
            };

            lo += loCasing;
            hi += part.Casing == Casing.Random && part.Min != part.Max ? part.Max : loCasing;
        }

        return (lo, hi);
    }

    /// <summary>
    /// Estimate the entropy of a given password.
    /// </summary>
    /// <param name="password"></param>
    /// <param name="policy"></param>
    /// <returns></returns>
    public double Entropy(Trigrams trigrams, string password, Policy policy)
    {
        double entropy = 0;
        StringBuilder word = new();
        double upperExtra = 0;
        foreach (char c in password)
        {
            if (char.IsLetter(c))
            {
                word.Append(c);
                if (char.IsUpper(c))
                {
                    upperExtra += Math.Log2(word.Length + 1);
                }
                continue;
            }
            if (word.Length > 0)
            {
                entropy += LengthEntropy(trigrams, word.Length);
                entropy += upperExtra;
                word.Clear();
            }
            if (char.IsDigit(c))
            {
                entropy += Math.Log2(10);
            }
            entropy += policy.Special.Length > 0 ? Math.Log2(policy.Special.Length) : 0;
        }
        if (word.Length > 0)
        {
            entropy += LengthEntropy(trigrams, word.Length);
            entropy += upperExtra;
        }
        return entropy;
    }

    private static double LengthEntropy(Trigrams trigrams, int length)
    {
        int extra = 0;
        double wordEntropy;
        while (!trigrams.LengthEntropy.TryGetValue(length - extra, out wordEntropy))
        {
            ++extra;
        }
        if (extra == 0)
        {
            return wordEntropy;
        }
        double additionalEntropy = wordEntropy - trigrams.LengthEntropy[length - extra - 1];
        return wordEntropy + (additionalEntropy * extra);
    }

    /// <summary>
    /// Estimate reasonably quickly the entropy in bits of a word of a given length. It's not exact, but generally from ad hoc
    /// testing it appears to consistently produce lower values than the exact calculation, which is what we want. A reasonable
    /// estimate is that it's perhaps 0.5 bits lower than the exact value / character
    /// </summary>
    /// <param name="length">The number of characters to calculate for</param>
    /// <returns>An estimated entropy in bits</returns>
    public double EstimateEntropy(Trigrams trigrams, int length)
    {
        double entropyBits = Math.Log2(trigrams.Strings.Starting.Length);
        length -= 3;

        (string tail, long count)[] current = trigrams.Strings.Starting.Select(s => (s, (long)1)).ToArray();

        while (length-- > 1)
        {
            current = NextEstimatedTailCount(current, trigrams.Strings.Middle);
        }

        current = NextEstimatedTailCount(current, trigrams.Strings.Ending);
        entropyBits = Math.Log2(current.Sum(c => c.count));

        return entropyBits;
    }

    private static (string tail, long count)[] NextEstimatedTailCount((string tail, long count)[] current, string[] continuationTrigrams)
    {
        List<(string tail, long count)> allTails = [];
        foreach ((string tail, long count) in current)
        {
            allTails.AddRange(continuationTrigrams
                .Where((s) => s.StartsWith(tail.Substring(1), StringComparison.Ordinal))
                .Select(s => (s, count)));
        }

        Dictionary<string, long> distinctTails = [];
        foreach ((string tail, long count) in allTails)
        {
            distinctTails[tail] = distinctTails.TryGetValue(tail, out long existingCount) ? existingCount + count : count;
        }

        return distinctTails.Select(kvp => (kvp.Key, kvp.Value)).ToArray();
    }

    /// <summary>
    /// Typically only used for internal calibration, it's very slow
    /// </summary>
    /// <param name="length">Number of characters in word</param>
    /// <returns>The entropy in bits of that length</returns>
    public double ExactEntropy(Trigrams trigrams, int length)
    {
        double entropyBits = Math.Log2(trigrams.Strings.Starting.Length);
        length -= 3;

        string[][] current = trigrams.Strings.Starting.Select((s) => new string[] { s }).ToArray();

        long count;
        string[] deadEnds;

        while (length-- > 1)
        {
            current = NextCharCount(current, trigrams.Strings.Middle, out count);
        }
        current = NextCharCount(current, trigrams.Strings.Ending, out count);

        deadEnds = current.Select((s, i) => (s.Length, i)).Where((l) => l.Length == 0).Select((l) => trigrams.Strings.Starting[l.i]).ToArray();

        count = current.SelectMany(c => c).Sum(c => c.Length);
        entropyBits = Math.Log2(count);
        return entropyBits;
    }

    private static string[][] NextCharCount(string[][] current, string[] continuationTrigrams, out long count)
    {
        count = 0;
        string[][] continuation = new string[current.Length][];
        for (int i = 0; i < current.Length; ++i)
        {
            List<string> continuations = [];
            for (int j = 0; j < current[i].Length; ++j)
            {
                string tail = current[i][j];
                continuations.AddRange(continuationTrigrams.Where((s) => s.StartsWith(tail.Substring(1), StringComparison.Ordinal)));
            }
            continuation[i] = [.. continuations];
            count += continuation[i].Length;
        }
        return continuation;
    }
}
