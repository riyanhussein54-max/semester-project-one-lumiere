/// <summary>
/// Verden-klassen bruges til at modulerer og definerer hele spilleverden.
/// </summary>
class Verden
{

    public Verden()
    {
        Lokation hjem = new Lokation(LokationType.Hjem, new int[4, 5], new());
        // Lokation entry = new Lokation("Entry");
        // Lokation corridor = new Lokation("Corridor");
        // Lokation cave = new Lokation("Cave");
        // Lokation pit = new Lokation("Darkest Pit");
        // Lokation outside = new Lokation("Outside");

        // entry.AddEdge("door", corridor);
        // corridor.AddEdge("door", cave);
        // cave.AddEdge("north", pit);
        // cave.AddEdge("south", outside);
        // pit.AddEdge("door", cave);
        // outside.AddEdge("door", cave);

    }
}
