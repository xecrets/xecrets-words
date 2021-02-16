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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

using Xecrets.Words.Abstractions;
using Xecrets.Words.Model;
using Xecrets.Words.RestApi.Properties;

namespace Xecrets.Words.RestApi;

public class WordApi(ILogger<WordApi> logger, ISerialization serialization, IGenerator generator, IEntropyCalculator entropyCalculator, IBuilderFactory builderFactory)
{
    private static Trigrams? _trigrams;

    private Trigrams Trigrams => _trigrams ??= serialization.Deserialize<Trigrams>(Resource.trigrams_en_json);

    private readonly ILogger _logger = logger;

    [Function("strong")]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "It just has to be there...")]
    public IActionResult Strong([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest httpRequest)
    {
        IBuilder builder = builderFactory.Create()
            .Add([new(Op.Special, 1, 1), new(Op.Digit, 1, 2)], Strategy.ZeroOrOne)
            .Add([new(Op.Word, 8, 10, Casing.TitleOrCamel)], Strategy.All)
            .Add([new(Op.Special, 1, 1), new(Op.Digit, 1, 2)], Strategy.OneRequired)
            .Add([new(Op.Word, 8, 10, Casing.TitleOrCamel)], Strategy.All)
            .Add([new(Op.Special, 1, 1), new(Op.Digit, 1, 2)], Strategy.IfRequired);
        Policy policy = Policy.Default with { Length = 18, Entropy = 75, };

        return Generate(policy, builder, "strong");

    }

    [Function("weak")]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "It just has to be there...")]
    public IActionResult Weak([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest httpRequest)
    {
        IBuilder builder = builderFactory.Create()
            .Add([new(Op.Special, 1, 1), new(Op.Digit, 1, 2)], Strategy.ZeroOrOne)
            .Add([new(Op.Word, 8, 8, Casing.TitleOrCamel)], Strategy.All)
            .Add([new(Op.Special, 1, 1), new(Op.Digit, 1, 2)], Strategy.IfRequired);
        Policy policy = Policy.Default with { Length = 10, Entropy = 35, };

        return Generate(policy, builder, "weak");
    }

    [Function("word")]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "It just has to be there...")]
    public IActionResult Word([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest httpRequest)
    {
        IBuilder builder = builderFactory.Create()
            .Add([new(Op.Word, 8, 10, Casing.TitleOrCamel)], Strategy.All);
        Policy policy = Policy.Default with { Length = 8, Entropy = -1, Digits = false, Special = string.Empty, UpperLowerCase = true };

        return Generate(policy, builder, "weak");
    }

    private JsonResult Generate(Policy policy, IBuilder builder, string level)
    {
        IEnumerable<Part> parts = builder.Build(policy);
        string pw = generator.Generate(Trigrams, parts, policy);
        (double lo, double hi) = entropyCalculator.Entropy(Trigrams, parts, policy);
        double ge = entropyCalculator.Entropy(Trigrams, pw, policy);

        _logger.LogInformation("Generated a {level} password.", level);

        return new JsonResult(new { pw, lo, ge, hi, });
    }
}
