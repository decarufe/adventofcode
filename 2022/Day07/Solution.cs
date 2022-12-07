using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2022.Day07;

[ProblemName("No Space Left On Device")]      
class Solution : Solver {

    public object PartOne(string input) {
        var mainNode = new Node("/");
        BuildTree(input, mainNode);

        var size = Traverse(mainNode)
            .Where(n => n.GetType() == typeof(Node) && n.Size < 100000)
            .Sum(n => n.Size);

        return size;
    }

    public object PartTwo(string input) {
        var mainNode = new Node("/");
        mainNode.Parent = mainNode;
        BuildTree(input, mainNode);

        var used = mainNode.Size;
        var toFree = 30000000 - (70000000 - used);

        var size = Traverse(mainNode)
            .Where(n => n.GetType() == typeof(Node) && n.Size >= toFree)
            .OrderBy(n => n.Size)
            .First()
            .Size;


        return size;
    }

    private void BuildTree(string input, Node mainNode)
    {
        var currentNode = mainNode;
        foreach(var line in input.SplitLine())
        {
            if (Match(line, "$ cd /"))
            {
                currentNode = mainNode;
            } else if (Match(line, "$ cd .."))
            {
                currentNode = currentNode.Parent;
            } else if (Match(line, "$ cd"))
            {
                var name = line.Substring(5);
                var node = new Node(name);
                currentNode.Add(node);
                currentNode = node;
            } else if (Match(line, "$ ls"))
            {

            } else if (Match(line, "dir "))
            {

            } else 
            {
                var parts = line.Split(" ");
                var name = parts[1];
                var size = int.Parse(parts[0]);
                var file = new File(name, size);
                currentNode.Add(file);
            }
        }
    }

    private IEnumerable<Node> Traverse(Node start)
    {

        foreach (Node node in start.Children)
        {
            foreach (Node n in Traverse(node)) yield return n;
        }

        yield return start;
    }

    private bool Match(string line, string text) => line.Substring(0, Math.Min(text.Length, line.Length)) == text;


}

class Node
{
    public string Name { get; set; }
    public virtual int Size { 
        get { return
            Children.Sum(c => c.Size);
        }
        set {}
    }
    public List<Node> Children { get; set; }
    public Node Parent { get; set; }

    public Node(string name)
    {
        Name = name;
        Children = new List<Node>();
    }

    public void Add(Node node)
    {
        if (!Children.Any(n => n.Name == node.Name))
        {
            node.Parent = this;
            Children.Add(node);
        }
    } 
}

class File : Node
{
    public override int Size { get; set; }

    public File(string name, int size) : base(name)
    {
        Size = size;
    }
}