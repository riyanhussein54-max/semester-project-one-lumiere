/// <summary>
/// Lokation-klassen definerer en lokations layout, genstande, NPCer, osv...
/// </summary>
class Lokation : GrafNode
{
    private List<Genstand> items = new List<Genstand>();
    
    public Lokation(string name, int x, int y) : base(name)
    {
        X = x;
        Y = y;
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
        Koordinatsystem();
    }
    public void AddItem(Genstand item)
    {
        items.Add(item);
    }

    public void ShowItems()
        {
            foreach (Genstand g in items)
            {
                Console.WriteLine($"{g.Navn}: {g.Beskrivelse}");
            }

    public override Lokation FollowEdge(string direction)
    {
        return (Lokation)(base.FollowEdge(direction));
    }
    
    public void Koordinatsystem()
    {
        int size = 5; // Grid scale
        int[,] array = new int[size, size];
        int limit = size / 2; 
        int r = 0;
    
        for (int y = limit; y >= -limit; y--)
        {
            int c = 0;
            for (int x = -limit; x <= limit; x++)
            {
                Console.Write($"[{array[r, c]}] ");
                c++;
            }
            Console.WriteLine();
            r++;
        }
    }
}

