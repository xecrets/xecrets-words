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

using System.Collections.Concurrent;
using System.Globalization;
using System.Text.Json;

using Xecrets.Words.Model;

namespace Xecrets.Words.Internal;

internal class EmbeddedTrigrams
{
    private const string _fallbackLanguage = "en";

    private readonly ConcurrentDictionary<string, Trigrams> _trigrams = new();

    public Trigrams For(CultureInfo culture) => _trigrams.GetOrAdd(ResourceName(culture), Load);

    private static string ResourceName(CultureInfo culture)
    {
        for (CultureInfo current = culture; current.Name.Length > 0; current = current.Parent)
        {
            string resourceName = ResourceName(current.TwoLetterISOLanguageName);
            if (typeof(EmbeddedTrigrams).Assembly.GetManifestResourceInfo(resourceName) != null)
            {
                return resourceName;
            }
        }
        return ResourceName(_fallbackLanguage);
    }

    private static string ResourceName(string language) => $"Xecrets.Words.Resources.trigrams-{language}.json";

    private static Trigrams Load(string resourceName)
    {
        using Stream stream = typeof(EmbeddedTrigrams).Assembly.GetManifestResourceStream(resourceName)!;
        return JsonSerializer.Deserialize(stream, SourceGenerationContext.Default.Trigrams)
            ?? throw new InvalidOperationException("Failed to deserialize trigrams.");
    }
}
