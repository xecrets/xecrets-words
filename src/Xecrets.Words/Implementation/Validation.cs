#region Copyright and GPL License

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

#endregion Copyright and GPL License

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Xecrets.Words.Abstractions;
using Xecrets.Words.Model;

namespace Xecrets.Words.Implementation;

/// <inheritdoc/>
public class Validation(ICulture culture, IEntropyCalculator entropyCalculator) : IValidation
{
    /// <inheritdoc/>
    [SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "Readability")]
    public bool Validate(Trigrams trigrams, string password, Policy policy)
    {
        if (password.Length < policy.Length)
        {
            return false;
        }
        if (policy.UpperLowerCase &&
            (!password.Any(c => char.IsUpper(c) && culture.CultureInfo.TextInfo.ToUpper(c) == c) ||
             !password.Any(c => char.IsLower(c) && culture.CultureInfo.TextInfo.ToLower(c) == c)))
        {
            return false;
        }
        if (policy.Special.Length > 0 && !password.Any(c => policy.Special.Contains(c)))
        {
            return false;
        }
        if (policy.Digits && !password.Any(c => char.IsDigit(c)))
        {
            return false;
        }
        if (entropyCalculator.Entropy(trigrams, password, policy) < policy.Entropy)
        {
            return false;
        }
        return true;
    }

    private string[]? _commonPasswords;

    private string[] CommonPasswords => _commonPasswords ??= ReadCommonPasswords();

    private string[] ReadCommonPasswords()
    {
        StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Xecrets.Words.Resources.common-passwords.txt")!);

        List<string> lines = [];
        while (!reader.EndOfStream)
        {
            lines.Add(reader.ReadLine() ?? string.Empty);
        }

        return lines.OrderByDescending(line => line.Length)
            .Where(line => line.Length > 0)
            .Select(line => line.ToLower(culture.CultureInfo)).ToArray();
    }

    /// <inheritdoc/>
    public int Entropy(string password, Policy policy)
    {
        string lowerCasePassword = password.ToLower(culture.CultureInfo);
        foreach (string common in CommonPasswords)
        {
            int i;
            do
            {
                // Ordinal comparison is order of magnitudes faster...
                i = lowerCasePassword.IndexOf(common, StringComparison.Ordinal);
                if (i >= 0)
                {
                    password = password.Remove(i, common.Length);
                    lowerCasePassword = lowerCasePassword.Remove(i, common.Length);
                }
            } while (i >= 0);
        }

        int charsetSize = 0;
        charsetSize += password.Any(char.IsAsciiLetterLower) ? 26 : 0;
        charsetSize += password.Any(char.IsAsciiLetterUpper) ? 26 : 0;
        charsetSize += password.Any(char.IsDigit) ? 10 : 0;
        charsetSize += password.Any(c => policy.Special.Contains(c)) ? policy.Special.Length : 0;
        charsetSize += password.Sum(c => !char.IsAsciiLetterOrDigit(c) && !policy.Special.Contains(c) ? 1 : 0);

        double bits = Math.Log2(charsetSize) * password.Length;
        return (int)Math.Round(bits);
    }
}
