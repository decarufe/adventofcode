using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2022.Day09;

[ProblemName("Rope Bridge")]      
class Solution : Solver {

    public object PartOne(string input) {
        var tailPositions = Execute(input, 2).Select(s => s.ToString()).Distinct();
        return tailPositions.Count();
    }

    public object PartTwo(string input) {
        var tailPositions = Execute(input, 10).Select(s => s.ToString()).Distinct();
        return tailPositions.Count();
    }

    private IEnumerable<Segment> Execute(string input, int lenght)
    {
        var rope = new Segment[lenght];
        for (int i = 0; i < lenght; i++) rope[i] = new Segment(0,0);

        foreach(var line in input.SplitLine())
        {
            var parts = line.Split(' ');
            var direction = parts[0];
            var distance = int.Parse(parts[1]);

            for (int i = 0; i < distance; i++)
            {
                Move(rope, direction);
                yield return new Segment(rope.Last().X, rope.Last().Y);
            }
        }
    }

    private void Move(Segment[] rope, string direction)
    {
        switch(direction)
        {
            case "U": rope[0].Y--; break;
            case "D": rope[0].Y++; break;
            case "L": rope[0].X--; break;
            case "R": rope[0].X++; break;
        }

        for (int i = 1; i < rope.Length; i++)
        {
            var dx = rope[i-1].X - rope[i].X;
            var dy = rope[i-1].Y - rope[i].Y;

            if (NeedToMove(dx, dy)) {
                rope[i].X += Math.Sign(dx);
                rope[i].Y += Math.Sign(dy);
            }
        }
    }

    private bool NeedToMove(int dx, int dy) => Math.Abs(dx) > 1 || Math.Abs(dy) > 1;

    class Segment
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Segment(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
