using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijsktraShortestPathAlgorithm
{
    public class Node
    {
        public string Name { get; set; }
        public Dictionary<Node, int> Edges { get; set; } = new();

        public Node(string name) => Name = name;

        public Node(string name, Dictionary<Node, int> edges)
        {
            Name = name;
            Edges = edges;
        }

        public Node AddEdge(Node node, int distance)
        {
            Edges.Add(node, distance);
            return this;
        }
    }
}
