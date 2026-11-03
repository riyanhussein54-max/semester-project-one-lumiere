/// <summary>
/// Lokation-klassen definerer en lokations layout, genstande, NPCer, osv...
/// </summary>
class Lokation : GrafNode
{
    public Lokation(string name) : base(name)
    {
    }

    public void Welcome()
    {
        Console.WriteLine($"You are now at {name}");
        HashSet<string> exits = edges.Keys.ToHashSet();
        Console.WriteLine("Current exits are:");
        foreach (string exit in exits)
        {
            Console.WriteLine($" - {exit}");
        }
    }

    public override Lokation FollowEdge(string direction)
    {
        return (Lokation)(base.FollowEdge(direction));
    }
}
