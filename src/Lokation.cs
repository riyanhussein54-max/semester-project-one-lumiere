/// <summary>
/// Lokation-klassen definerer en lokations layout, genstande, NPCer, osv...
/// </summary>
public class Lokation
{
    private Dictionary<Retning, Lokation> edges = new();
    private List<Genstand> items = new List<Genstand>();

    public string Navn { get; set; }

    public Lokation(string navn)
    {
        Navn = navn;
    }

    public void AddEdge(Retning direction, Lokation lokation)
    {
        edges[direction] = lokation;
    }

    public Lokation? FollowEdge(Retning direction)
    {
        edges.TryGetValue(direction, out Lokation? lokation);
        return lokation;
    }

    public void Welcome()
    {
        Console.WriteLine($"Du er nu ved {Navn}.");

        Console.WriteLine("Current exits are:");
        foreach (Retning exit in edges.Keys)
        {
            Console.WriteLine($" - {exit}");
        }
        ViseItem();
        Koordinatsystem();
    }

    public void TilføjItem(Genstand item)
    {
        items.Add(item);
    }
    
    public void ViseItem()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Der er ingen genstande her.");
            return;
        }
        Console.WriteLine("Genstande på denne lokation:");
        foreach (Genstand g in items)
        {
            Console.WriteLine($"{g.Navn}: {g.Beskrivelse}");
        }
    }

    public void Koordinatsystem()
    {
        int size = 5;
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