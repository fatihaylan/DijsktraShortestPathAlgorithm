using DijsktraShortestPathAlgorithm;

var nodes = new Dictionary<string, Node>
{
    {"A", new Node("A")},
    {"B", new Node("B")},
    {"C", new Node("C")},
    {"D", new Node("D")},
    {"E", new Node("E")},
    {"F", new Node("F")}
};

nodes["A"].AddEdge(nodes["B"], 4).AddEdge(nodes["C"], 5);
nodes["B"].AddEdge(nodes["A"], 4).AddEdge(nodes["C"], 11).AddEdge(nodes["D"], 9).AddEdge(nodes["E"], 7);
nodes["C"].AddEdge(nodes["A"], 5).AddEdge(nodes["B"], 11).AddEdge(nodes["E"], 3);
nodes["D"].AddEdge(nodes["B"], 9).AddEdge(nodes["E"], 13).AddEdge(nodes["F"], 2);
nodes["E"].AddEdge(nodes["B"], 7).AddEdge(nodes["C"], 3).AddEdge(nodes["D"], 13).AddEdge(nodes["F"], 6);
nodes["F"].AddEdge(nodes["D"], 2).AddEdge(nodes["E"], 6);

var firstNode = nodes["A"];
var finalNode = nodes["F"];

var paths = nodes.Select(node => new NodePath { Node = node.Value }).ToList();

paths.GetNodePath(firstNode)!.SetNewDistance(0);

while (paths.Any(path => !path.IsDiscovered))
{
    var currentPath = paths.Where(node => !node.IsDiscovered).MinBy(node => node.Distance);
    currentPath!.MarkAsDiscovered();

    if (currentPath.Node == finalNode)
        break;

    foreach (var (neighborNode, distance) in currentPath.Node?.Edges!)
    {
        var neighborPath = paths.GetNodePath(neighborNode);
        var currentDistance = currentPath.Distance + distance;

        if (currentDistance < neighborPath!.Distance)
        {
            neighborPath.Parent = currentPath.Node;
            neighborPath.SetNewDistance(currentDistance);
        }
    }
}

var pathNodes = new List<Node>();
var currentNode = finalNode;

while (currentNode is not null)
{
    pathNodes.Insert(0, currentNode);
    currentNode = paths.GetNodePath(currentNode)?.Parent;
}

Console.WriteLine(string.Join(" -> ", pathNodes.Select(i => i.Name)));
Console.WriteLine($"Total Distance: {paths.GetNodePath(finalNode)?.Distance}");
Console.ReadLine();