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

using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Xecrets.Words.Abstractions;
using Xecrets.Words.Model;

namespace Xecrets.Words.Test;

[TestClass]
public class TestStrengthMeter
{
    private static IStrengthMeter CreateStrengthMeter()
    {
        ServiceCollection services = [];
        services.ConfigureWords();
        return services.BuildServiceProvider().GetRequiredService<IStrengthMeter>();
    }

    [TestMethod]
    public void TestEmptyPasswordHasNoStrength()
    {
        Assert.AreEqual(0, CreateStrengthMeter().StrengthPercent(string.Empty));
    }

    [TestMethod]
    public void TestNonEmptyPasswordHasSomeStrength()
    {
        Assert.IsGreaterThanOrEqualTo(1, CreateStrengthMeter().StrengthPercent("a"));
    }

    [TestMethod]
    public void TestStrongPasswordIsStrongerThanWeakPassword()
    {
        IStrengthMeter strengthMeter = CreateStrengthMeter();

        int weak = strengthMeter.StrengthPercent("abc");
        int strong = strengthMeter.StrengthPercent("Xq7#vLm2!pRt9$wZk4&nB");

        Assert.IsGreaterThan(weak, strong);
    }

    [TestMethod]
    [DataRow(0, StrengthColor.Red)]
    [DataRow(19, StrengthColor.Red)]
    [DataRow(20, StrengthColor.Orange)]
    [DataRow(39, StrengthColor.Orange)]
    [DataRow(40, StrengthColor.Yellow)]
    [DataRow(59, StrengthColor.Yellow)]
    [DataRow(60, StrengthColor.LightGreen)]
    [DataRow(79, StrengthColor.LightGreen)]
    [DataRow(80, StrengthColor.Green)]
    [DataRow(100, StrengthColor.Green)]
    public void TestToStrengthColor(int strength, StrengthColor expected)
    {
        Assert.AreEqual(expected, CreateStrengthMeter().ToStrengthColor(strength));
    }
}
