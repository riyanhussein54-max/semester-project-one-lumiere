/// <summary>
/// GrafNode-klassen bruges til modelering af grafer (kan være at vi skal smide den ud)
/// </summary>
class GrafNode
{
    protected string name;
    protected Dictionary<Retning, GrafNode> edges = new Dictionary<Retning, GrafNode>();

    public GrafNode(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public void AddEdge(Retning direction, GrafNode node)
    {
        edges.Add(direction, node);
    }

    public virtual GrafNode? FollowEdge(Retning direction)
    {
        if (edges.TryGetValue(direction, out GrafNode? node))
        {
            return node;
        }
    
        return null;
    }
}
