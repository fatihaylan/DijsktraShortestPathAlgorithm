namespace DijsktraShortestPathAlgorithm;
public class NodePath
{
    private bool _isDiscovered = false;
    private int _distance = int.MaxValue;

    public Node Node { get; set; }
    public bool IsDiscovered => _isDiscovered;
    public int Distance => _distance;
    public Node? Parent { get; set; }

    public void MarkAsDiscovered() => _isDiscovered = true;
    public void SetNewDistance(int distance) => _distance = distance > 0 ? distance : 0;
}

public static class NodePathExtensions
{
    public static NodePath? GetNodePath(this List<NodePath>? list, Node? node)
    {
        return list?.Find(path => path.Node == node);
    }
}