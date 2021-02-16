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

using Xecrets.Words.Abstractions;
using Xecrets.Words.Model;

namespace Xecrets.Words.Implementation;

public class Builder(IRandom random) : IBuilder
{
    private record Group(Part[] Parts, Strategy Strategy)
    {
        public HashSet<Op> LastChance { get; set; } = [];
    }

    private readonly List<Group> _groups = [];

    private readonly HashSet<Op> _requiredOps = [];

    private readonly HashSet<Op> _foundOps = [];

    public IBuilder Add(Part[] parts, Strategy strategy)
    {
        _groups.Add(new(parts, strategy));
        return this;
    }

    public IEnumerable<Part> Build(Policy policy)
    {
        if (policy.Special.Length > 0)
        {
            _requiredOps.Add(Op.Special);
        }
        if (policy.Digits)
        {
            _requiredOps.Add(Op.Digit);
        }

        for (int i = 0; i < _groups.Count; ++i)
        {
            HashSet<Op> ops = new(_groups[i].Parts.Select(part => part.Op));
            _foundOps.UnionWith(ops);

            _groups[i].LastChance = ops.Intersect(_requiredOps).ToHashSet();
            for (int j = i - 1; j >= 0; --j)
            {
                _groups[j].LastChance.ExceptWith(_groups[i].LastChance);
            }
        }

        if (!_requiredOps.IsSubsetOf(_foundOps))
        {
            throw new InvalidOperationException("The required operations are not all present.");
        }

        HashSet<Op> generated = [];
        foreach (Group group in _groups)
        {
            List<Part> parts = [.. group.Parts.OrderBy(p => random.Random(0, 100, nameof(Build)))];

            // First generate all the required parts, overriding any strategy
            bool lastChance = group.LastChance.Count != 0;
            foreach (Op op in group.LastChance)
            {
                if (!generated.Contains(op))
                {
                    int i = parts.IndexOf(parts.First(p => p.Op == op));
                    Part part = parts[i];
                    parts.RemoveAt(i);
                    generated.Add(part.Op);
                    yield return part;
                }
            }

            switch (group.Strategy)
            {
                case Strategy.All:
                    foreach (Part part in parts)
                    {
                        generated.Add(part.Op);
                        yield return part;
                    }
                    break;
                case Strategy.Some:
                    foreach (Part part in parts)
                    {
                        if (random.Random(0, 100, nameof(Build) + nameof(Strategy.Some)) < 100 / group.Parts.Length)
                        {
                            generated.Add(part.Op);
                            yield return part;
                        }
                    }
                    break;

                case Strategy.ZeroOrOne:
                    if (!lastChance && random.Random(0, 100, nameof(Build) + nameof(Strategy.ZeroOrOne)) >= 50)
                    {
                        Part part = parts[0];
                        generated.Add(part.Op);
                        yield return part;
                    }
                    break;

                case Strategy.IfRequired:
                    break;

                case Strategy.One:
                    if (!lastChance)
                    {
                        Part part = parts[0];
                        generated.Add(part.Op);
                        yield return part;
                    }
                    break;

                case Strategy.OneRequired:
                    if (!lastChance)
                    {
                        Part part = parts.FirstOrDefault(p => _requiredOps.Contains(p.Op) && !generated.Contains(p.Op)) ?? parts[0];
                        generated.Add(part.Op);
                        yield return part;
                    }
                    break;

                case Strategy.None:
                default:
                    throw new InvalidOperationException($"Invalid strategy {group.Strategy} specified.");
            }
        }
    }
}
