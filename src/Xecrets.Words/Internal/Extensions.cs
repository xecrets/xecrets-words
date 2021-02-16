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

using Xecrets.Words.Abstractions;
using Xecrets.Words.Model;

namespace Xecrets.Words.Internal;

internal static class Extensions
{
    public static void AddWord(this IDictionary<string, int> trigrams, string word)
    {
        if (word.Length < 3)
        {
            throw new ArgumentException("A vocabulary word must consist of at least three characters.", nameof(word));
        }
        trigrams[word] = trigrams.TryGetValue(word, out int count) ? count + 1 : 1;
    }

    public static void AddTrigram(this IDictionary<string, int> trigrams, char[] word)
    {
        if (word.Length < 3)
        {
            throw new ArgumentException("A vocabulary word must consist of at least three characters.", nameof(word));
        }
        if (word.All(c => c == word[0]))
        {
            return;
        }
        string key = new string(word);
        trigrams[key] = trigrams.TryGetValue(key, out int count) ? count + 1 : 1;
    }

    public static Trigrams Trigrams(this Vocabulary vocabulary, IEntropyCalculator entropyCalculator, bool asciiOnly)
    {
        Trigrams trigrams = new();
        foreach (string word in vocabulary.Words.Keys)
        {
            if (asciiOnly && word.Any(c => c is < 'a' or > 'z'))
            {
                continue;
            }

            char[] chars = word.ToCharArray();
            trigrams.Starting.AddTrigram(chars[..3]);

            if (word.Length == 3)
            {
                continue;
            }

            for (int i = 1; i < chars.Length - 3; i++)
            {
                trigrams.Middle.AddTrigram(chars[i..(i + 3)]);
            }
            trigrams.Ending.AddTrigram(chars[^3..]);
        }

        trigrams.Starting = trigrams.Starting.OrderBy(ts => ts.Key).ToDictionary();
        trigrams.Middle = trigrams.Middle.OrderBy(ts => ts.Key).ToDictionary();
        trigrams.Ending = trigrams.Ending.OrderBy(ts => ts.Key).ToDictionary();

        for (int i = 5; i <= 12; ++i)
        {
            trigrams.LengthEntropy[i] = entropyCalculator.EstimateEntropy(trigrams, i);
        }
        return trigrams;
    }
}
