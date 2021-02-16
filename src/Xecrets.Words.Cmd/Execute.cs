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

using System.Globalization;

using Xecrets.Words.Abstractions;
using Xecrets.Words.Cmd.Properties;
using Xecrets.Words.Implementation;
using Xecrets.Words.Model;

namespace Xecrets.Word.Cmd;

internal class Execute(IAnalyzer analyzer, IGenerator generator, ISerialization serialization, IBuilder builder)
{
    public async Task<int> RunAsync()
    {
        builder.Add([new(Op.Word, 8, 10, Casing.Pascal)], Strategy.All);

        // The texts are from Project Gutenberg and Litteraturbanken for sv-SE respectively, and are in the public domain.
        await Generate([Resources.pg4300], CultureInfo.GetCultureInfo("en-US"), asciiOnly: true);
        await Generate([Resources.pg17489], CultureInfo.GetCultureInfo("fr-FR"), asciiOnly: false);
        await Generate([Resources.pg2000], CultureInfo.GetCultureInfo("es-ES"), asciiOnly: false);
        await Generate([Resources.LagerlofS_HerrArnesPenningar, Resources.LagerlofS_GostaBerlingsSaga1933, Resources.LagerlofS_JerusalemI],
            CultureInfo.GetCultureInfo("sv-SE"), asciiOnly: false);
        await Generate([Resources.pg65661], CultureInfo.GetCultureInfo("de-DE"), asciiOnly: false);
        await Generate([Resources.pg47786, Resources.pg57040], CultureInfo.GetCultureInfo("it-IT"), asciiOnly: true);

        return 0;
    }

    private bool firstOutput = true;

    private async Task Generate(string[] texts, CultureInfo cultureInfo, bool asciiOnly)
    {
        foreach (string text in texts)
        {
            await analyzer.AddAsync(new DefaultCulture() { CultureInfo = cultureInfo, AsciiOnly = asciiOnly, }, new StringReader(text));
        }

        Trigrams trigrams = analyzer.Trigrams(asciiOnly);
        string json = serialization.Serialize(trigrams);
        File.WriteAllText($"trigrams-{cultureInfo.TwoLetterISOLanguageName}.json", json);

        if (!firstOutput)
        {
            Console.WriteLine();
        }
        firstOutput = false;

        Console.WriteLine($"--- {cultureInfo.EnglishName} ---");
        Console.WriteLine($"{analyzer.Vocabulary.Words.Count} distinct words, with a total of {analyzer.Vocabulary.Words.Values.Sum(c => c)} occurrences.");
        Console.WriteLine($"{trigrams.Starting.Count} starting, {trigrams.Middle.Count} middle and {trigrams.Ending.Count} ending trigrams.");
        Console.WriteLine($"Estimated entropy of an 8 character word is {trigrams.LengthEntropy[8]}.");

        Console.WriteLine($"10 sample Pascal cased passwords 8-10 characters:");
        Policy policy = Policy.SingleWord with { Length = 8, UpperLowerCase = true, };
        for (int i = 0; i < 10; ++i)
        {
            Console.WriteLine(generator.Generate(trigrams, builder.Build(policy), policy));
        }
    }
}
