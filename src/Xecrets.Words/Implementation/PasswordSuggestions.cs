#region Copyright and GPL License

/*
 * Xecrets Words - Copyright © 2024-2025 Svante Seleborg, All Rights Reserved.
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

using System.Globalization;

using Xecrets.Words.Abstractions;
using Xecrets.Words.Internal;
using Xecrets.Words.Model;

namespace Xecrets.Words.Implementation;

/// <inheritdoc/>
public class PasswordSuggestions(IGenerator generator, IBuilderFactory builderFactory) : IPasswordSuggestions
{
    private readonly EmbeddedTrigrams _embeddedTrigrams = new();

    private Trigrams Trigrams => _embeddedTrigrams.For(CultureInfo.CurrentUICulture);

    /// <inheritdoc/>
    public string SimplePassword()
    {
        IBuilder builder = builderFactory.Create()
            .Add([new(Op.Special, 1, 1), new(Op.Digit, 1, 2)], Strategy.ZeroOrOne)
            .Add([new(Op.Word, 8, 8, Casing.TitleOrCamel)], Strategy.All)
            .Add([new(Op.Special, 1, 1), new(Op.Digit, 1, 2)], Strategy.IfRequired);
        Policy policy = Policy.Default with { Length = 10, Entropy = 35, };

        return Generate(policy, builder);
    }

    /// <inheritdoc/>
    public string StrongPassword()
    {
        IBuilder builder = builderFactory.Create()
            .Add([new(Op.Special, 1, 1), new(Op.Digit, 1, 2)], Strategy.ZeroOrOne)
            .Add([new(Op.Word, 8, 10, Casing.TitleOrCamel)], Strategy.All)
            .Add([new(Op.Special, 1, 1), new(Op.Digit, 1, 2)], Strategy.OneRequired)
            .Add([new(Op.Word, 8, 10, Casing.TitleOrCamel)], Strategy.All)
            .Add([new(Op.Special, 1, 1), new(Op.Digit, 1, 2)], Strategy.IfRequired);
        Policy policy = Policy.Default with { Length = 18, Entropy = 75, };

        return Generate(policy, builder);
    }

    /// <inheritdoc/>
    public string Word(int length)
    {
        string word = generator.Word(Trigrams, length);
        word = char.ToUpper(word[0], CultureInfo.CurrentCulture) + word[1..];
        return word;
    }

    private string Generate(Policy policy, IBuilder builder)
    {
        IEnumerable<Part> parts = builder.Build(policy);
        string pw = generator.Generate(Trigrams, parts, policy);

        return pw;
    }
}
