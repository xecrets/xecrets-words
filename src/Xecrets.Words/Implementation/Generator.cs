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
using System.Text;

using Xecrets.Words.Abstractions;
using Xecrets.Words.Internal;
using Xecrets.Words.Model;

namespace Xecrets.Words.Implementation;

/// <inheritdoc/>
/// <param name="random">The <see cref="IRandom"/> random number generator to use.</param>
/// <param name="culture">The <see cref="ICulture"/> culture to use.</param>
/// <param name="validation">The <see cref="IValidation"/> validation to use.</param>
public class Generator(IRandom random, ICulture culture, IValidation validation) : IGenerator
{
    /// <inheritdoc/>
    public string Generate(Trigrams trigrams, IEnumerable<Part> parts, Policy policy)
    {
        string result;
        do
        {
            result = GenerateTry(trigrams, parts, policy);
        } while (!validation.Validate(trigrams, result, policy));
        return result;
    }

    private string GenerateTry(Trigrams trigrams, IEnumerable<Part> parts, Policy policy)
    {
        StringBuilder generated = new();
        int length;

        foreach (Part part in parts)
        {
            string value;
            switch (part.Op)
            {
                case Op.Word:
                    length = random.Random(part.Min, part.Max + 1, nameof(Op) + nameof(Op.Word));
                    value = Word(trigrams, length);
                    break;
                case Op.Digit:
                    length = random.Random(part.Min, part.Max + 1, nameof(Op) + nameof(Op.Digit));
                    value = Digits(length);
                    break;
                case Op.Special:
                    length = random.Random(part.Min, part.Max + 1, nameof(Op) + nameof(Op.Special));
                    value = Special(length, policy.Special);
                    break;
                case Op.None:
                default:
                    throw new ArgumentException($"Invalid/unsupported part class '{part.Op}'.");
            }
            if (value.Length > 0)
            {
                value = part.Casing switch
                {
                    Casing.Ignore => value,
                    Casing.Lower => value.ToLower(culture.CultureInfo),
                    Casing.Camel => CamelCasing(trigrams.Strings, value),
                    Casing.TitleOrCamel => TitleOrCamelCasing(trigrams.Strings, value),
                    Casing.Pascal => CamelCasing(trigrams.Strings, TitleCasing(value)),
                    Casing.Random => RandomCasing(value),
                    Casing.Title => TitleCasing(value),
                    Casing.Upper => value.ToUpper(culture.CultureInfo),
                    _ => throw new ArgumentException($"Invalid/unsupported casing '{part.Casing}'."),
                };

                generated.Append(value);
            }
        }

        return generated.ToString();
    }

    internal string TitleCasing(string value)
    {
        value = char.ToUpper(value[0], culture.CultureInfo) + value.Substring(1);
        return value;
    }

    internal string RandomCasing(string value)
    {
        for (int i = 0; i < value.Length; ++i)
        {
            if (random.Random(0, 2, nameof(Generator) + nameof(RandomCasing)) == 1)
            {
                value = value.Substring(0, i) + char.ToUpper(value[i], culture.CultureInfo) + value.Substring(i + 1);
            }
        }
        return value;
    }

    internal string CamelCasing(TrigramStrings trigramStrings, string value) => TitleOrCamelCasing(trigramStrings, value, 2);

    internal string TitleOrCamelCasing(TrigramStrings trigramStrings, string value) => TitleOrCamelCasing(trigramStrings, value, 0);

    internal string TitleOrCamelCasing(TrigramStrings trigramStrings, string value, int start)
    {
        List<int> possibleCamelPositions = [];
        for (int i = start; i <= value.Length - 3; i++)
        {
            if (trigramStrings.Starting.Contains(value.Substring(i, 3), StringComparer.Ordinal))
            {
                possibleCamelPositions.Add(i);
            }
        }

        int camelIndex;
        int positionIndex = possibleCamelPositions.Count > 0
            ? random.Random(0, possibleCamelPositions.Count, nameof(Generator) + nameof(CamelCasing) + "Position")
            : -1;
        if (positionIndex == -1)
        {
            camelIndex = start > 0
                ? random.Random(1, value.Length - 1, nameof(Generator) + nameof(CamelCasing) + "CamelIndex")
                : 1;
            value = value.Substring(0, start) + char.ToUpper(value[start], culture.CultureInfo) + value.Substring(start + 1);
            return value;
        }

        camelIndex = possibleCamelPositions[positionIndex];
        value = value.Substring(0, camelIndex) + char.ToUpper(value[camelIndex], culture.CultureInfo) + value.Substring(camelIndex + 1);

        return value;
    }

    /// <inheritdoc/>
    public string Word(Trigrams trigrams, int length)
    {
        if (length < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(length), "The length must be at least 5.");
        }

        int i = random.Random(0, trigrams.Strings.Starting.Length, nameof(Generator) + nameof(Word));
        int j = i;
        do
        {
            string start = trigrams.Strings.Starting[j];
            if (Middle(trigrams.Strings, start, length - 3, out string result))
            {
                return result;
            }
            j = (j + 1) % trigrams.Strings.Starting.Length;
        } while (j != i);

        throw new InvalidOperationException($"Failed to generate a {length} character word.");
    }

    [SuppressMessage("Performance", "CA1845:Use span-based 'string.Concat'", Justification = "Readability before efficiency.")]
    private bool Middle(TrigramStrings trigramStrings, string word, int additionalLength, out string result)
    {
        result = word;

        if (additionalLength == 0)
        {
            return true;
        }
        if (additionalLength == 1)
        {
            return Ending(trigramStrings, word, out result);
        }


        string last2Chars = word.Substring(word.Length - 2);
        string[] candidateMiddles = trigramStrings.Middle.Where((s) => s.StartsWith(last2Chars, StringComparison.Ordinal)).ToArray();
        if (candidateMiddles.Length == 0)
        {
            return false;
        }

        int i = random.Random(0, candidateMiddles.Length, nameof(Generator) + nameof(Middle));
        int j = i;
        do
        {
            string middle = candidateMiddles[j];
            if (Middle(trigramStrings, word + middle.Substring(2), additionalLength - 1, out result))
            {
                return true;
            }
            j = (j + 1) % candidateMiddles.Length;
        }
        while (j != i);

        return false;
    }

    [SuppressMessage("Performance", "CA1845:Use span-based 'string.Concat'", Justification = "Readability before efficiency.")]
    private bool Ending(TrigramStrings trigramStrings, string word, out string result)
    {
        string last2Chars = word.Substring(word.Length - 2);
        string[] candidateEndings = trigramStrings.Ending.Where((s) => s.StartsWith(last2Chars, StringComparison.Ordinal)).ToArray();
        if (candidateEndings.Length == 0)
        {
            result = word;
            return false;
        }

        int i = random.Random(0, candidateEndings.Length, nameof(Generator) + nameof(Ending));
        result = word + candidateEndings[i].Substring(2);
        return true;
    }

    private string Digits(int length)
    {
        StringBuilder sb = new();
        for (int i = 0; i < length; ++i)
        {
            sb.Append("0123456789"[random.Random(0, 10, nameof(Generator) + nameof(Digits))]);
        }
        return sb.ToString();
    }

    private string Special(int length, string special)
    {
        if (special.Length == 0)
        {
            return string.Empty;
        }

        StringBuilder sb = new();
        for (int i = 0; i < length; ++i)
        {
            sb.Append(special[random.Random(0, special.Length, nameof(Generator) + nameof(Special))]);
        }
        return sb.ToString();
    }
}