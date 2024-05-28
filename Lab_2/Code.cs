using System;
using System.Collections.Generic;
using System.Linq;

public class HuffmanNode
{
    public char Symbol { get; set; }
    public double Probability { get; set; }
    public HuffmanNode Left { get; set; }
    public HuffmanNode Right { get; set; }

    public HuffmanNode(char symbol, double probability)
    {
        Symbol = symbol;
        Probability = probability;
        Left = null;
        Right = null;
    }
}

public class HuffmanTree
{
    private HuffmanNode Root { get; set; }

    public HuffmanTree(Dictionary<char, double> frequencies)
    {
        var nodes = new List<HuffmanNode>();
        foreach (var pair in frequencies)
        {
            nodes.Add(new HuffmanNode(pair.Key, pair.Value));
        }

        while (nodes.Count > 1)
        {
            nodes.Sort((a, b) => a.Probability.CompareTo(b.Probability));

            var left = nodes[0];
            var right = nodes[1];
            var parent = new HuffmanNode('\0', left.Probability + right.Probability)
            {
                Left = left,
                Right = right
            };

            nodes.Remove(left);
            nodes.Remove(right);
            nodes.Add(parent);
        }

        Root = nodes[0];
    }

    private void PrintPaths(HuffmanNode node, string path, Dictionary<char, string> result)
    {
        if (node.Left == null && node.Right == null)
        {
            result[node.Symbol] = path;
            return;
        }

        if (node.Left != null)
            PrintPaths(node.Left, path + "0", result);

        if (node.Right != null)
            PrintPaths(node.Right, path + "1", result);
    }

    public Dictionary<char, string> GetCodes()
    {
        var result = new Dictionary<char, string>();
        PrintPaths(Root, "", result);
        return result;
    }
}

public class ShannonFanoNode
{
    public char Symbol { get; set; }
    public double Probability { get; set; }
    public string Code { get; set; }

    public ShannonFanoNode(char symbol, double probability)
    {
        Symbol = symbol;
        Probability = probability;
        Code = string.Empty;
    }
}

public class ShannonFanoTree
{
    public List<ShannonFanoNode> Nodes { get; set; }

    public ShannonFanoTree(Dictionary<char, double> frequencies)
    {
        Nodes = frequencies.Select(pair => new ShannonFanoNode(pair.Key, pair.Value)).ToList();
        Nodes = Nodes.OrderByDescending(n => n.Probability).ToList();
        BuildTree(Nodes);
    }

    private void BuildTree(List<ShannonFanoNode> nodes)
    {
        if (nodes.Count <= 1)
            return;

        double totalProbability = nodes.Sum(node => node.Probability);
        double halfProbability = totalProbability / 2;
        double runningSum = 0;
        int splitIndex = -1;

        for (int i = 0; i < nodes.Count; i++)
        {
            runningSum += nodes[i].Probability;
            if (runningSum >= halfProbability)
            {
                splitIndex = i;
                break;
            }
        }

        var leftGroup = nodes.Take(splitIndex + 1).ToList();
        var rightGroup = nodes.Skip(splitIndex + 1).ToList();

        foreach (var node in leftGroup)
            node.Code += "0";

        foreach (var node in rightGroup)
            node.Code += "1";

        BuildTree(leftGroup);
        BuildTree(rightGroup);
    }

    public Dictionary<char, string> GetCodes()
    {
        return Nodes.ToDictionary(node => node.Symbol, node => node.Code);
    }
}