using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2022.Day08;

[ProblemName("Treetop Tree House")]      
class Solution : Solver {

    public object PartOne(string input) {
        var grid = input.SplitLine();

        var numberVisible = 0;
        foreach (int y in 1..(grid.Length))
        {
            foreach (int x in 1..(grid[0].Length))
            {
                if (IsVisible(grid, x, y)) {
                    numberVisible++;
                    Console.Write($"X");
                } else {
                    Console.Write($" ");
                }
            }
            Console.WriteLine();
        }

        return numberVisible;
    }

    public object PartTwo(string input) {
        return 0;
    }

    private int GetGridValue(string[] grid, int x, int y)
    {
        return grid[y-1][x-1]-'0';
    }

    private bool IsVisible(string[] grid, int x, int y)
    {
        if (x == 1 || x == grid[0].Length || y == 1 || y == grid.Length) return true;
        var thisHeight = GetGridValue(grid, x, y);
        var maxHeight = 0;
        for (int lx = x-1; lx >= 1; lx--) 
        {
            maxHeight = Math.Max(maxHeight, GetGridValue(grid, lx, y));
        }
        if (maxHeight < thisHeight) return true;
        maxHeight = 0;
        for (int lx = x+1; lx <= grid[0].Length; lx++) 
        {
            maxHeight = Math.Max(maxHeight, GetGridValue(grid, lx, y));
        }
        if (maxHeight < thisHeight) return true;
        maxHeight = 0;
        for (int ly = y-1; ly >= 1; ly--) 
        {
            maxHeight = Math.Max(maxHeight, GetGridValue(grid, x, ly));
        }
        if (maxHeight < thisHeight) return true;
        maxHeight = 0;
        for (int ly = y+1; ly <= grid.Length; ly++) 
        {
            maxHeight = Math.Max(maxHeight, GetGridValue(grid, x, ly));
        }
        if (maxHeight < thisHeight) return true;
        return false;
    }

    private int VisibleDistanceLeft(string[] grid, int x, int y)
    {
        if (x == 1 || x == grid[0].Length || y == 1 || y == grid.Length) return true;
        var thisHeight = GetGridValue(grid, x, y);
        var maxDistance = 0;
        for (int lx = x-1; lx >= 1; lx--) 
        {
            if (GetGridValue(grid, lx, y) < thisHeight) maxDistance++;
        }
        return maxDistance;
    }

    private int VisibleDistanceRight(string[] grid, int x, int y)
    {
        if (x == 1 || x == grid[0].Length || y == 1 || y == grid.Length) return true;
        var thisHeight = GetGridValue(grid, x, y);
        var maxDistance = 0;
        for (int lx = x+1; lx <= grid[0].Length; lx++) 
        {
            if (GetGridValue(grid, lx, y) < thisHeight) maxDistance++;
        }
        return maxDistance;
    }

    private int VisibleDistanceTop(string[] grid, int x, int y)
    {
        if (x == 1 || x == grid[0].Length || y == 1 || y == grid.Length) return true;
        var thisHeight = GetGridValue(grid, x, y);
        var maxDistance = 0;
        for (int ly = y-1; ly >= 1; ly--) 
        {
            if (GetGridValue(grid, x, ly) < thisHeight) maxDistance++;
            else return maxDistance;
        }
        return maxDistance;
    }
    
    private int VisibleDistanceDown(string[] grid, int x, int y)
    {
        if (x == 1 || x == grid[0].Length || y == 1 || y == grid.Length) return true;
        var thisHeight = GetGridValue(grid, x, y);
        var maxDistance = 0;
        for (int ly = y+1; ly <= grid.Length; ly++) 
        {
            if(GetGridValue(grid, x, ly) < thisHeight) maxDistance++;
        }
        return maxDistance;
    }
}