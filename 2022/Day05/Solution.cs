using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2022.Day05;

[ProblemName("Supply Stacks")]      
class Solution : Solver {

    public object PartOne(string input) {
        var splits = input.Split2Lines().ToArray();
        var stacks = BuildStacks(splits[0].SplitLine().ToArray());
        var moves = BuildMoves(splits[1].SplitLine());
        foreach(var move in moves)
        {
            ApplyMove(stacks, move);
        }
        var result = new List<string>();
        foreach (var stack in stacks)
        {
            result.Add(stack.Peek().ToString());
        }
        return String.Join("", result);
    }

    public object PartTwo(string input) {
        var splits = input.Split2Lines().ToArray();
        var stacks = BuildStacks(splits[0].SplitLine().ToArray());
        var moves = BuildMoves(splits[1].SplitLine());
        foreach(var move in moves)
        {
            ApplyMove2(stacks, move);
        }
        var result = new List<string>();
        foreach (var stack in stacks)
        {
            result.Add(stack.Peek().ToString());
        }
        return String.Join("", result);    }

    private void ApplyMove(Stack<char>[] stacks, Move move)
    {
        for (int i = 0; i < move.Count; i++)
        {
            stacks[move.To-1].Push(stacks[move.From-1].Pop());
        }
    }

    private void ApplyMove2(Stack<char>[] stacks, Move move)
    {
        Stack<char> cup = new();
        for (int i = 0; i < move.Count; i++)
        {
            cup.Push(stacks[move.From-1].Pop());
        }
        for (int i = 0; i < move.Count; i++)
        {
            stacks[move.To-1].Push(cup.Pop());
        }
    }


    private Stack<char>[] BuildStacks(string[] line)
    {
        var stackIds = line.Last().Replace(" ", "");
        var pos = Enumerable.Range(0, stackIds.Length);

        var stacks = new List<Stack<char>>();
        for (int i = 0; i < stackIds.Length; i++) 
        {
            var stack = new Stack<char>();
            for (int j = line.Length - 2; j >= 0; j --){
                var col = line.Last().IndexOf(stackIds[i]);
                char item = line[j].Substring(col, 1).ToCharArray()[0];
                if (item == ' ') break;
                stack.Push(item);
            }
            stacks.Add(stack);
        }
        return stacks.ToArray();
    }

    private IEnumerable<Move> BuildMoves(IEnumerable<string> moveParts)
    {
        var parts = moveParts.Select(s => s.Replace("move ", "").Replace(" from ", ",").Replace(" to ", ","));
        var moves = new List<Move>();
        foreach(var part in parts)
        {
            moves.Add(new Move(part.Split(",").Select(int.Parse).ToArray()));
        }

        return moves;
    }

}

class Move
{
    public int From { get; set; }
    public int To { get; set; }
    public int Count { get; set; }

    public Move(int[] parts)
    {
        Count = parts[0];
        From = parts[1];
        To = parts[2];
    }
}
