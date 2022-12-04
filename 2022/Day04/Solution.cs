using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2022.Day04;

[ProblemName("Camp Cleanup")]      
class Solution : Solver {

    public object PartOne(string input) =>
        (from line in input.SplitLine()
        let parts = line.Split(",").SelectMany(p => p.Split("-")).Select(n => Int32.Parse(n)).ToArray()
        where parts[0] >= parts[2] && parts[1] <= parts[3] ||
            parts[2] >= parts[0] && parts[3] <= parts[1]
        select line).Count();        

    public object PartTwo(string input) =>
            (from line in input.SplitLine()
        let parts = line.Split(",").SelectMany(p => p.Split("-")).Select(n => Int32.Parse(n)).ToArray()
        let range1 = Enumerable.Range(parts[0], parts[1] - parts[0] + 1)
        let range2 = Enumerable.Range(parts[2], parts[3] - parts[2] + 1)
        where range1.Intersect(range2).Count() > 0
        select line).Count();        

}
