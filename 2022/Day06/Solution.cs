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

    private int GetMarker(string input, int markerLenght) => 
        (from pos in Enumerable.Range(markerLenght, input.Length - markerLenght)
        let range = new Range(pos-markerLenght, pos)
        where input[range].Distinct().Count() == markerLenght
        select pos).First();
}
