#region Coypright and GPL License

/*
 * Xecrets Words - Copyright � 2024-2025 Svante Seleborg, All Rights Reserved.
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

using System.Globalization;

using Xecrets.Words.Abstractions;

namespace Xecrets.Words.Test;

[TestClass]
public class TestPasswordSuggestions
{
    private static IServiceProvider CreateContainer()
    {
        ServiceCollection services = [];
        services.ConfigureWords();
        return services.BuildServiceProvider();
    }

    [TestMethod]
    public void TestStrongPassword()
    {
        IPasswordSuggestions suggestions = CreateContainer().GetRequiredService<IPasswordSuggestions>();

        string password = suggestions.StrongPassword();

        Assert.IsGreaterThanOrEqualTo(18, password.Length);
        Assert.IsTrue(password.Any(char.IsUpper) && password.Any(char.IsLower));
    }

    [TestMethod]
    public void TestSimplePassword()
    {
        IPasswordSuggestions suggestions = CreateContainer().GetRequiredService<IPasswordSuggestions>();

        string password = suggestions.SimplePassword();

        Assert.IsGreaterThanOrEqualTo(10, password.Length);
    }

    [TestMethod]
    public void TestWord()
    {
        IPasswordSuggestions suggestions = CreateContainer().GetRequiredService<IPasswordSuggestions>();

        string word = suggestions.Word(8);

        Assert.AreEqual(8, word.Length);
        Assert.IsTrue(char.IsUpper(word[0]));
    }

    [TestMethod]
    public void TestFallbackToEnglishForUnsupportedCulture()
    {
        IPasswordSuggestions suggestions = CreateContainer().GetRequiredService<IPasswordSuggestions>();
        CultureInfo original = CultureInfo.CurrentUICulture;
        try
        {
            CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("sv-SE");

            string word = suggestions.Word(8);

            Assert.AreEqual(8, word.Length);
        }
        finally
        {
            CultureInfo.CurrentUICulture = original;
        }
    }
}
