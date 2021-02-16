# README

Xecrets Words - a library and sample app to produce rememberable and
pronounceable strong passwords C# for .NET 8+

## Command Line Arguments

The library is intended to be used as a nuget package in your own code, but
there is a sample application that can be used from the command line. The sample
application does not take any arguments, and the output is written to the
console and files are written in the current directory.

## Quick Start

To run the sample app:

`Xecrets.Words.Cmd`

This will produce output similar to:
```
--- English (United States) ---
28579 distinct words, with a total of 209961 occurrences.
2442 starting, 5382 middle and 2128 ending trigrams.
Estimated entropy of an 8 character word is 29.
10 sample Pascal cased passwords 8-10 characters:
Orrarael
Renhipsit
teaievadgy
briquebiv
Fatnicap
Noziodyd
opusTymmen
frihiFoier
cyconplate
AswaySmer

--- French (France) ---
11864 distinct words, with a total of 76494 occurrences.
1629 starting, 3246 middle and 1266 ending trigrams.
Estimated entropy of an 8 character word is 26.
10 sample Pascal cased passwords 8-10 characters:
Fiemêlés
[... Omitted for brevity]
Lésasémi

[... Omitted for brevity]

--- Swedish (Sweden) ---
17894 distinct words, with a total of 191516 occurrences.
1852 starting, 4998 middle and 1513 ending trigrams.
Estimated entropy of an 8 character word is 27.
10 sample Pascal cased passwords 8-10 characters:
inorFunhus
Nisgåelbo
reundSnöl
[... Omitted for brevity]
```

Xecrets Words is free software, licensed under the GNU GPL Version 3 or later license. This means
you can use it anywhere and any way you like for free, and you are also free to modify it as you
wish as long as you do not redistribute it. If you do redistribute it, please check with the Free
Software Foundation how this works, https://www.gnu.org/licenses/ .

### How To Build?

Download the [xecrets-cli](https://github.com/xecrets/xecrets-words) repository. Open the 
solution in Visual Studio or the workspace in Visual Studio Code and build. There are no
external dependencies that are not resolved with Nuget.

### How to Contribute

Talk to us. Due to the nature of the application, pull requests are audited very
carefully. Before requesting a pull it's best if we discuss things.

Minimum requirement is that there are no compiler warnings and no failed tests.

### Contact

Contact us via our [support](https://www.axantum.com/support "Xecrets Support
Site") or through github .
