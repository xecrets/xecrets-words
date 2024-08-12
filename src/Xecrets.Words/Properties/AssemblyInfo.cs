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

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;

[assembly: InternalsVisibleTo("Xecrets.Words.Test")]
[assembly: AssemblyMetadata("IsTrimmable", "True")]

[assembly: AssemblyTitle("Xecrets Words BETA GPL - main assembly")]
[assembly: AssemblyDescription("Generate strong passwords easy to type and remember")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyCompany("Axantum Software AB")]
[assembly: AssemblyProduct("Xecrets Words")]
[assembly: AssemblyCopyright("Copyright © 2024, Svante Seleborg, All Rights Reserved")]
[assembly: AssemblyTrademark("Xecrets is a trademark of Axantum Software AB")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xecrets/xecrets-words")]
[assembly: NeutralResourcesLanguage("en-US")]

[assembly: AssemblyVersion("2.3.0.0")]
[assembly: AssemblyFileVersion("2.3.0.0")]

[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
