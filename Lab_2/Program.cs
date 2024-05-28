using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Lab_5
{
    class Program
    {
        static void Main()
        {
            var frequencies = new Dictionary<char, double>
            {
                {'a', 0.31},
                {'b', 0.08},
                {'c', 0.05},
                {'d', 0.14},
                {'e', 0.02},
                {'f', 0.20},
                {'g', 0.08},
                {'h', 0.07},
                {'i', 0.05}
            };

            // Huffman Coding
            Console.WriteLine("Huffman Coding:");
            HuffmanTree huffmanTree = new HuffmanTree(frequencies);
            var huffmanCodes = huffmanTree.GetCodes();
            foreach (var pair in huffmanCodes)
            {
                Console.WriteLine($"Symbol: {pair.Key}, Code: {pair.Value}");
            }

            Console.WriteLine("\nShannon-Fano Coding:");
            ShannonFanoTree shannonFanoTree = new ShannonFanoTree(frequencies);
            var shannonFanoCodes = shannonFanoTree.GetCodes();
            foreach (var pair in shannonFanoCodes)
            {
                Console.WriteLine($"Symbol: {pair.Key}, Code: {pair.Value}");
            }
        }
    }
}