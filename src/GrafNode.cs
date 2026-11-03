/// <summary>
/// GrafNode-klassen bruges til modelering af grafer (kan være at vi skal smide den ud)
/// </summary>
class GrafNode
{
    protected string name;
    protected Dictionary<string, GrafNode> edges = new Dictionary<string, GrafNode>();

    public GrafNode(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public void AddEdge(string name, GrafNode node)
    {
        edges.Add(name, node);
    }

    public virtual GrafNode FollowEdge(string direction)
    {
        return edges[direction];
    }
}
