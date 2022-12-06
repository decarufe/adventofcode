using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2022.Day06;

[ProblemName("Tuning Trouble")]      
class Solution : Solver {

    public object PartOne(string input) {
        var pos = 4;
        while (true)
        {
            var range = new Range(pos-4, pos);
            if (input[range].Distinct().Count() == 4) break;
            pos++;
        }
        return pos;
    }

    public object PartTwo(string input) {
        var pos = 14;
        while (true)
        {
            var range = new Range(pos-14, pos);
            if (input[range].Distinct().Count() == 14) break;
            pos++;
        }
        return pos;    }
}
