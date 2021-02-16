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
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Xecrets.Words.Abstractions;
using Xecrets.Words.Implementation;
using Xecrets.Words.Model;

namespace Xecrets.Words.Test;

[TestClass]
public class TestAnalyzer
{
    [AllowNull]
    private static IServiceProvider Container { get; set; }

    private static ServiceProvider GetServices()
    {
        var services = new ServiceCollection();
        services.AddTransient(typeof(IRandom), typeof(FakeRandom));
        services.AddTransient(typeof(IAnalyzer), typeof(Analyzer));
        services.AddTransient(typeof(Trigrams));
        services.AddTransient(typeof(ICulture), typeof(DefaultCulture));
        services.AddTransient(typeof(IEntropyCalculator), typeof(EntropyCalculator));

        return services.BuildServiceProvider();
    }

    [ClassInitialize]
    public static void ClassInit(TestContext _)
    {
        Container = GetServices();
    }

    [TestMethod]
    public async Task TestSimpleAnalysisOfOneWord()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();

        await analyzer.AddAsync(culture, new StringReader("word"));

        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);
        Assert.AreEqual(1, trigrams.Starting.Count, "starting");
        Assert.AreEqual(0, trigrams.Middle.Count, "middle");
        Assert.AreEqual(1, trigrams.Ending.Count, "ending");
    }

    [TestMethod]
    public async Task TestSimpleAnalysisOfSomeShortWords()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();

        await analyzer.AddAsync(culture, new StringReader("a one is word two"));

        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);
        Assert.AreEqual(3, trigrams.Starting.Count, "starting");
        Assert.AreEqual(0, trigrams.Middle.Count, "middle");
        Assert.AreEqual(1, trigrams.Ending.Count, "ending");
    }

    [TestMethod]
    public async Task TestSimpleAnalysisOfAFewWords()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();

        await analyzer.AddAsync(culture, new StringReader("The quick brown fox"));

        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);
        Assert.AreEqual(4, trigrams.Starting.Count, "starting");
        Assert.AreEqual(2, trigrams.Middle.Count, "middle");
        Assert.AreEqual(2, trigrams.Ending.Count, "ending");
    }

    [TestMethod]
    public async Task TestSimpleAnalysisOfAFewDuplicatedWords()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();

        await analyzer.AddAsync(culture, new StringReader("The quick brown fox is a brown fox"));

        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);
        Assert.AreEqual(4, trigrams.Starting.Count, "starting");
        Assert.AreEqual(2, trigrams.Middle.Count, "middle");
        Assert.AreEqual(2, trigrams.Ending.Count, "ending");
    }

    [TestMethod]
    public async Task TestSimpleAnalysisCountsOfAFewDuplicatedWords()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();

        await analyzer.AddAsync(culture, new StringReader("The quick brown fox is a brown fox"));

        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);
        Assert.AreEqual(1, trigrams.Starting["the"], "the");
        Assert.AreEqual(1, trigrams.Starting["bro"], "bro");
        Assert.AreEqual(1, trigrams.Middle["row"], "row");
        Assert.AreEqual(1, trigrams.Ending["own"], "own");
    }

    [TestMethod]
    public async Task TestSimpleAnalysisOfVocabularyWords()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();

        await analyzer.AddAsync(culture, new StringReader("The quick brown fox is a brown fox"));

        Vocabulary vocabulary = analyzer.Vocabulary;
        Assert.AreEqual(1, vocabulary.Words["the"], "the");
        Assert.AreEqual(1, vocabulary.Words["quick"], "quick");
        Assert.AreEqual(2, vocabulary.Words["brown"], "brown");
        Assert.AreEqual(2, vocabulary.Words["fox"], "fox");
    }

    [TestMethod]
    public async Task TestBigBookVocabulary()
    {
        IAnalyzer analyzer = Container.GetRequiredService<IAnalyzer>();
        ICulture culture = Container.GetRequiredService<ICulture>();

        await analyzer.AddAsync(culture, new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Xecrets.Words.Test.Resources.pg98.txt")!));

        Vocabulary vocabulary = analyzer.Vocabulary;
        Assert.AreEqual(8241, vocabulary.Words["the"], "the");
        Assert.AreEqual(97, vocabulary.Words["gutenberg"], "gutenberg");
        Assert.AreEqual(1, vocabulary.Words["handsomest"], "handsomest");

        Trigrams trigrams = analyzer.Trigrams(asciiOnly: true);
        Assert.AreEqual(23, trigrams.Starting["the"], "the");
    }
}
