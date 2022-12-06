using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2022.Day06;

[ProblemName("Tuning Trouble")]      
class Solution : Solver {

    public object PartOne(string input) => GetMarker(input, 4);

    public object PartTwo(string input) => GetMarker(input, 14);

    private int GetMarker(string input, int makerLenght)
    {
        for (int pos = makerLenght; pos < input.Length; pos++)
        {
            var range = new Range(pos-makerLenght, pos);
            if (input[range].Distinct().Count() == makerLenght) return pos;
        }
        return 0;    
    }    
}
