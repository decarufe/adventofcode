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
        let parts = line.Split(",").SelectMany(p => p.Split("-")).Select(int.Parse).ToArray()
        where parts[0] >= parts[2] && parts[1] <= parts[3] ||
            parts[2] >= parts[0] && parts[3] <= parts[1]
        select line).Count();        

    public object PartTwo(string input) =>
        (from line in input.SplitLine()
        let parts = line.Split(",").SelectMany(p => p.Split("-")).Select(int.Parse).ToArray()
        where parts[1] >= parts[2] && parts[0] <= parts[3] ||
            parts[2] >= parts[1] && parts[3] <= parts[0]
        select line).Count();        
}
