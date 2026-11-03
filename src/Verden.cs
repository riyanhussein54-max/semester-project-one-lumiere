/// <summary>
/// Verden-klassen bruges til at modulerer og definerer hele spilleverden.
/// </summary>
class Verden
{
    Lokation entry;

    public Verden()
    {
        Lokation entry = new Lokation("Entry");
        Lokation corridor = new Lokation("Corridor");
        Lokation cave = new Lokation("Cave");
        Lokation pit = new Lokation("Darkest Pit");
        Lokation outside = new Lokation("Outside");

        entry.AddEdge("door", corridor);
        corridor.AddEdge("door", cave);
        cave.AddEdge("north", pit);
        cave.AddEdge("south", outside);
        pit.AddEdge("door", cave);
        outside.AddEdge("door", cave);

        this.entry = entry;
    }

    public Lokation GetEntry()
    {
        return entry;
    }
}
