/// <summary>
/// Lokation-klassen definerer en lokations layout, genstande, NPCer, osv...
/// </summary>
public class Lokation
{
    public string Navn { get; set; }
    public int[,] Gitter { get; private set; }
    public LokationType LokationType { get; private set; }
    public List<Genstand> Genstande { get; private set; }

    public Lokation(LokationType lokationType, int[,] gitter, List<Genstand> genstande)
    {
        LokationType = lokationType;
        Gitter = gitter;
        Genstande = genstande;
        GenerateName();
    }

    /*
    if (Nærliggende.Nord)
    {
        makeDoorWayNorth
    }

    */

    public Lokation FollowEdge(string direction) => FollowEdge(direction);

    /// <summary>
    /// Generer et navn baseret på LokationsType-enumen
    /// </summary>
    private void GenerateName() => Navn = nameof(LokationType);
}
