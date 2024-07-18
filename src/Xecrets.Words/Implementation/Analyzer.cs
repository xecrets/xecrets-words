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
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;

using Xecrets.Words.Abstractions;
using Xecrets.Words.Internal;
using Xecrets.Words.Model;

namespace Xecrets.Words;

/// <inheritdoc/>
/// <param name="entropyCalculator">
/// An instance of an <see cref="IEntropyCalculator"/> used to incluce
/// pre-calculated entropy estimates for words of varying lengths.
/// </param>
public partial class Analyzer(IEntropyCalculator entropyCalculator) : IAnalyzer
{
    /// <inheritdoc/>
    public Vocabulary Vocabulary { get; } = new();

    /// <inheritdoc/>
    public Trigrams Trigrams(bool asciiOnly) => Vocabulary.Trigrams(entropyCalculator, asciiOnly: asciiOnly);

    /// <inheritdoc/>
    public async Task AddAsync(ICulture culture, TextReader reader)
    {
        BufferBlock<string> buffer = new BufferBlock<string>();

        Task producer = ProduceAsync(reader, buffer, culture);
        Task consumer = ConsumeAsync(buffer);

        await Task.WhenAll(producer, consumer).ConfigureAwait(false);

        Vocabulary.Words = Vocabulary.Words.OrderBy((pair) => pair.Value).ToDictionary();
    }

    private static async Task ProduceAsync(TextReader reader, BufferBlock<string> target, ICulture culture)
    {
        StringBuilder word = new();
        int i;
        do
        {
            word.Clear();
            char c;
            bool skipToWhiteSpace = false;
            bool skippedNonWhiteSpace = false;
            while ((i = reader.Read()) != -1)
            {
                c = (char)i;
                if (skipToWhiteSpace && !char.IsWhiteSpace(c))
                {
                    skippedNonWhiteSpace = true;
                    continue;
                }
                if (skipToWhiteSpace && skippedNonWhiteSpace)
                {
                    word.Clear();
                }
                skipToWhiteSpace = skippedNonWhiteSpace = false;

                if (c is '\'' or '’' or '"')
                {
                    skipToWhiteSpace = true;
                    continue;
                }

                if (!char.IsLetter(c))
                {
                    break;
                }

                word.Append(char.ToLower(c, culture.CultureInfo));
            }

            string value = word.ToString();
            if (RomanNumeral().IsMatch(value))
            {
                continue;
            }
            if (ThreeOrMoreSameCharsInSequence().IsMatch(value))
            {
                continue;
            }

            await target.SendAsync(value);
        } while (i != -1);
        target.Complete();
    }

    private async Task ConsumeAsync(ISourceBlock<string> source)
    {
        while (await source.OutputAvailableAsync().ConfigureAwait(false))
        {
            string word = await source.ReceiveAsync().ConfigureAwait(false);
            if (word.Length < 3)
            {
                continue;
            }

            Vocabulary.Words.AddWord(word);
        }
    }

    [GeneratedRegex("^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex RomanNumeral();
    [GeneratedRegex(@"(\w)\1{2,}")]
    private static partial Regex ThreeOrMoreSameCharsInSequence();
}