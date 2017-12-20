
# Advent of Code 2017
```
.-----------------------------------------------.       
|                                               |  25
|                                               |  24
|                                               |  23
|                                               |  22
|       *                                       |  21
|       └─┐┌────*                               |  20 **
| ┌───────┘└──┬o└─────────*                     |  19 **
| └─∧∧∧──┬┴┴┴┬┘*───┤[]├───┘                     |  18 **
| *──────┤  S├─┘                                |  17 **
| └─┤|├─┐┤  R├─────────*                        |  16 **
| ┌─────┘┤  A├─────┬───┤     ┌─────┐ ┌────────* |  15 **
| ├──────┤  M├o────┘┌─┐=┌────┴──┬┴┴┴┴┼───o*───┤ |  14 **
| └──────┴┬┬┬┴──────┴o└─┤o───┐*─┤    ├┬┴┴┴┤o──┘ |  13 **
| o*───────────────┤|├─┐└────┘└─┤  6 ├┤ AC├───┐ |  12 **
| ┌┘┌──────*o──────────┴───┤[]├┐┤  x ├┤ D0├───┤ |  11 **
| ├─┘o────┐└───[─]──┬┴┴┴┴┴┬*┌─o│┤  94├┤ vD├┌─o│ |  10 **
| └──────┐└───────┐*┤     ├┘└──┴┤  =2├┤ TE├┴──┘ |   9 **
| ┌──────┴────────┘└┤ BCM ├─────┴┬┬┬┬┴┤   ├───* |   8 **
| └─────o*─[─]──────┤2837 ├───────────┴┬┬┬┴───┘ |   7 **
| *──────┘o──┬──o┌──┴┬┬┬┬┬┴──────────────oTo──┐ |   6 **
| └─────────*└───┴───────────oTo──────┐┌──────┘ |   5 **
| ┌─────────┘┌─┤[]├─────┤[]├───*┌─────┘├──────┐ |   4 **
| └──────────┴─o*───────────|(─┘└────┐o┴──o┌─┬┘ |   3 **
| ┌──────|(─────┘┌*o─────┬─────[─]──o└─────┘┌┘V |   2 **
| └─oTo──────────┘└─────*└─┤[]├─────────────┴─┘ |   1 **
'-----------------------------------------------'       

```
C# solutions to http://adventofcode.com/2017 using .NET Core 2.0.

## Dependencies

- This library is based on `.NET Core 2.0`. It should work on Windows, Linux and OS X.
- `HtmlAgilityPack.NetCore` is used for problem download.

## Running

To run the project:

1. Install .NET Core.
2. Download the code.
3. Run `dotnet run <day>`.

To prepare for the next day:

1. Run `dotnet run update <day>`.