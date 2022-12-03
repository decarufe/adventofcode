using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2022.Day03;

[ProblemName("Rucksack Reorganization")]      
class Solution : Solver {

    public object PartOne(string input) =>
        input.SplitLine()
            .Select(line => line.Chunk(line.Length/2))
            .Select(Matching)
            .Select(GetCharValue)
            .Sum();

    public object PartTwo(string input) =>
        input.SplitLine()
            .Chunk(3)
            .Select(Matching)
            .Select(GetCharValue)
            .Sum();

    private char Matching(IEnumerable<IEnumerable<char>> chunks) =>
        (from c in chunks.First()
        where chunks.All(chunk => chunk.Contains(c))
        select c).First();

    private int GetCharValue(char c) => c < 'a' ? c - 'A' + 27 : c - 'a' + 1;
}

