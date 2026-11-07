/// <summary>
/// Lokation-klassen definerer en lokations layout, genstande, NPCer, osv...
/// </summary>
class Lokation : GrafNode
{
    // A List<Genstand> stores multiple Genstand objects
    // List<T> is a built in C# collection
    //
    // Useful List methods:
    // .Count  = Returns the number of elements in the List
    // .Add()  = Adds an element to the List
    // .Remove() = Removes an element from the List
    //
    // If needed List<T> could later be replaced with another collection type such as Dictionary<TKey, TValue>.
    private List<Genstand> items = new List<Genstand>();

    // public Lokation(string name, int x, int) : base(name)
    // {
    //     // X = x;
    //     // Y = y;
    // }
    public Lokation(string name): base(name)
    {
        
    }
    
    public void Welcome()
    {
        Console.WriteLine($"You are now at {name}");
        HashSet<Retning> exits = edges.Keys.ToHashSet();
        Console.WriteLine("Current exits are:");
        foreach (Retning exit in exits)
        {
            Console.WriteLine($" - {exit}");
        }
        ShowItems();
        Koordinatsystem();
    }

    public void AddItem(Genstand item)
    {
        items.Add(item);
    }

    public void ShowItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("There are no items here");
            return;
        }

        Console.WriteLine("Items in this location:");
        foreach (Genstand g in items)
        {
            Console.WriteLine($"{g.Navn}: {g.Beskrivelse}");
        }
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
