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

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Xecrets.Words.Abstractions;
using Xecrets.Words.Implementation;
using Xecrets.Words.Model;

namespace Xecrets.Words.Test;

[TestClass]
public class TestGenerator
{
    [AllowNull]
    IServiceProvider _serviceProvider;

    readonly ServiceCollection _services = [];

    private IServiceProvider Container => _serviceProvider ??= _services.BuildServiceProvider();

    private void RegisterServices()
    {
        _services.ConfigureWords();

        _services.Replace(ServiceDescriptor.Singleton<IRandom, FakeRandom>());
    }

    [TestInitialize]
    public void TestInit()
    {
        RegisterServices();
    }

    [TestMethod]
    public void TestTooShortLengthWord()
    {
        IGenerator generator = Container.GetRequiredService<IGenerator>();
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => generator.Word(new Trigrams(), 0));
    }

    [TestMethod]
    public async Task TestGenerateThreeShortWords()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = new DefaultCulture { AsciiOnly = false, };

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));

        IGenerator generator = Container.GetRequiredService<IGenerator>();

        string word;
        Trigrams trigrams = analyzer.Trigrams(asciiOnly: false);

        word = generator.Word(trigrams, 5);
        Assert.AreEqual("demon", word, "word #1");

        word = generator.Word(trigrams, 5);
        Assert.AreEqual("spude", word, "word #2");

        word = generator.Word(trigrams, 5);
        Assert.AreEqual("hyphe", word, "word #3");
    }

    [TestMethod]
    public async Task TestGenerateTenLongNonAsciiWords()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));
        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg4300.txt")!));
        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg28948.txt")!));

        IGenerator generator = Container.GetRequiredService<IGenerator>();
        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);

        string[] words = new string[100];
        for (int i = 0; i < words.Length; ++i)
        {
            words[i] = generator.Word(trigrams, 9);
        }
    }

    [TestMethod]
    public async Task TestGenerateTenLongAsciiWords()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));
        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg4300.txt")!));
        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg28948.txt")!));

        IGenerator generator = Container.GetRequiredService<IGenerator>();
        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);

        string[] words = new string[100];
        for (int i = 0; i < words.Length; ++i)
        {
            words[i] = generator.Word(trigrams, 9);
        }
    }

    [TestMethod]
    public async Task TestGenerateEntropyEstimate()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();
        IEntropyCalculator entropyCalculator = Container.GetRequiredService<IEntropyCalculator>();

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));

        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);

        double entropy = entropyCalculator.EstimateEntropy(trigrams, 8);
        Assert.IsTrue(entropy is >= 25 and <= 26, "25 bits of entropy");
    }

    [TestMethod]
    public async Task TestGenerateEntropyExact6()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();
        IEntropyCalculator entropyCalculator = Container.GetRequiredService<IEntropyCalculator>();

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));

        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);

        double entropy = entropyCalculator.EstimateEntropy(trigrams, 6);
        Assert.IsTrue(entropy is >= 19 and <= 20, $"19 expected bits of estimated entropy was {entropy}");

        entropy = entropyCalculator.ExactEntropy(trigrams, 6);
        Assert.IsTrue(entropy is >= 20 and <= 21, $"20 expected bits of exact entropy was {entropy}");
    }

#if CALIBRATE
    [TestMethod] // Not run freqently, takes a long time
    public async Task TestGenerateEntropyExact8()
    {
        DefaultFactory factory = Container.GetRequiredService<DefaultFactory>();
        IAnalyzer analyzer = factory.CreateAnalyzer(ascii: true, CultureInfo.InvariantCulture);

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));

        IGenerator generator = factory.CreateGenerator(analyzer.Vocabulary, Container.GetRequiredService<IRandom>(), new DefaultCulture());

        double entropy = generator.EstimateEntropyBits(8);
        Assert.IsTrue(entropy is >= 25 and <= 26, $"25 expected bits of estimated entropy was {entropy}");

        entropy = generator.ExactEntropyBits(8);
        Assert.IsTrue(entropy is >= 27 and <= 28, $"27 expected bits of exact entropy was {entropy}");
    }
#endif

    [TestMethod]
    public async Task TestGenerateEntropyEstimateWithLargerBase()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();
        IEntropyCalculator entropyCalculator = Container.GetRequiredService<IEntropyCalculator>();

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));
        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg4300.txt")!));

        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);

        double entropy = entropyCalculator.EstimateEntropy(trigrams, 7);
        Assert.IsTrue(entropy is >= 25 and <= 26, "25 bits of entropy");
    }

    [TestMethod]
    public async Task TestGenerateEntropyEstimateWithEvenLargerBase()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();
        IEntropyCalculator entropyCalculator = Container.GetRequiredService<IEntropyCalculator>();

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));
        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg4300.txt")!));
        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg28948.txt")!));

        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);

        double entropy = entropyCalculator.EstimateEntropy(trigrams, 7);
        Assert.IsTrue(entropy is >= 25 and <= 26, "25 bits of entropy");
    }

    [TestMethod]
    public async Task TestGenerateWordTitleCase()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));

        IGenerator generator = Container.GetRequiredService<IGenerator>();
        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);

        IBuilder builder = Container.GetRequiredService<IBuilder>();
        builder.Add([new(Op.Word, 7, 7, Casing.Title)], Strategy.All);
        Policy policy = Policy.SingleWord with { Length = 7, UpperLowerCase = true, };

        string word;
        word = generator.Generate(trigrams, builder.Build(policy), policy);
        Assert.AreEqual("Oblanst", word, "Title cased word.");
    }

    [TestMethod]
    public async Task TestGenerateWordRandomCase()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));

        IGenerator generator = Container.GetRequiredService<IGenerator>();
        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);

        IBuilder builder = Container.GetRequiredService<IBuilder>();
        builder.Add([new(Op.Word, 7, 7, Casing.Random)], Strategy.All);
        Policy policy = Policy.SingleWord with { Length = 7, UpperLowerCase = true, };

        string word;
        word = generator.Generate(trigrams, builder.Build(policy), policy);
        Assert.AreEqual("oBlAnSt", word, "Random cased word.");
    }

    [TestMethod]
    public async Task TestGenerateWordCamelCase()
    {
        IServiceProvider container = Container;
        IAnalyzer analyzer = container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));

        IGenerator generator = container.GetRequiredService<IGenerator>();
        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);

        IBuilder builder = Container.GetRequiredService<IBuilder>();
        builder.Add([new(Op.Word, 10, 10, Casing.Camel)], Strategy.All);
        Policy policy = Policy.SingleWord with { Length = 10, };

        string word;

        word = generator.Generate(trigrams, builder.Build(policy), policy);
        Assert.AreEqual("oblansLend", word, "Camel cased word.");
        word = generator.Generate(trigrams, builder.Build(policy), policy);
        Assert.AreEqual("tinenArced", word, "Camel cased word.");
    }

    [TestMethod]
    public async Task TestGenerateSimpleParts()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();
        IGenerator generator = Container.GetRequiredService<IGenerator>();
        IEntropyCalculator entropyCalculator = Container.GetRequiredService<IEntropyCalculator>();

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));

        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);

        string word;

        IBuilder builder = Container.GetRequiredService<IBuilder>();
        builder
            .Add([new(Op.Special, 1, 1)], Strategy.All)
            .Add([new(Op.Word, 6, 8, Casing.Camel)], Strategy.All)
            .Add([new(Op.Digit, 1, 2)], Strategy.All)
            .Add([new(Op.Word, 6, 8, Casing.Pascal)], Strategy.All)
            ;

        Policy policy = Policy.Default with { Entropy = 48, Length = 15, };
        word = generator.Generate(trigrams, builder.Build(policy), policy);

        Assert.AreEqual("&doUlgry25PoVonse", word, "Camel and Pascal cased words.");

        double entropy = entropyCalculator.Entropy(trigrams, word, policy);
        const int expectedEntropy = 71;
        Assert.IsTrue(entropy is >= expectedEntropy and <= expectedEntropy + 1, $"Entropy was {entropy}, expected ~{expectedEntropy}.");
    }

    [TestMethod]
    public void TestBitStrength()
    {
        IValidation validation = Container.GetRequiredService<IValidation>();
        Policy policy = Policy.Default with { Length = 15, };
        int bits, expected;
        bits = validation.Entropy(".spyrim1TakAdom", policy);
        expected = 95;
        Assert.IsTrue(bits == expected, $"Expected {expected} bits, got {bits}.");

        bits = validation.Entropy("MySecretPassword", policy);
        expected = 11;
        Assert.IsTrue(bits == expected, $"Expected {expected} bits, got {bits}.");

        bits = validation.Entropy("MyPfdsfuQbttxpse", policy);
        expected = 91;
        Assert.IsTrue(bits == expected, $"Expected {expected} bits, got {bits}.");
    }

    [TestMethod]
    public async Task TestGenerateStrategyOne()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));

        IGenerator generator = Container.GetRequiredService<IGenerator>();
        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);

        IBuilder builder = Container.GetRequiredService<IBuilder>();
        builder.Add([new(Op.Special, 1, 1), new(Op.Digit, 1, 1)], Strategy.One);
        Policy policy = Policy.Default with { Length = 1, UpperLowerCase = false, Special = string.Empty, Entropy = -1, };

        string word;
        word = generator.Generate(trigrams, builder.Build(policy), policy);

        Assert.AreEqual("2", word, "A single digit.");

    }

    [TestMethod]
    public async Task TestGenerateStandardStrong()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));

        IGenerator generator = Container.GetRequiredService<IGenerator>();
        IRandom random = Container.GetRequiredService<IRandom>();
        IValidation validation = Container.GetRequiredService<IValidation>();
        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);

        string[] words = new string[10];

        Builder builder = new(random);
        builder
            .Add([new(Op.Special, 1, 1), new(Op.Digit, 1, 2)], Strategy.ZeroOrOne)
            .Add([new(Op.Word, 8, 10, Casing.TitleOrCamel)], Strategy.All)
            .Add([new(Op.Special, 1, 1), new(Op.Digit, 1, 2)], Strategy.OneRequired)
            .Add([new(Op.Word, 8, 10, Casing.TitleOrCamel)], Strategy.All)
            .Add([new(Op.Special, 1, 1), new(Op.Digit, 1, 2)], Strategy.IfRequired)
            ;

        Policy policy = Policy.Default with { Length = 18, Entropy = 70, };

        for (int i = 0; i < words.Length; ++i)
        {
            words[i] = generator.Generate(trigrams, builder.Build(policy), policy);
        }

        for (int i = 0; i < words.Length; ++i)
        {
            Assert.IsTrue(validation.Validate(trigrams, words[i], policy), $"Validation failed for {words[i]}");
        }
    }
}