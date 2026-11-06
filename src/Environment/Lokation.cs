/// <summary>
/// Lokation-klassen definerer en lokations layout, genstande, NPCer, osv...
/// </summary>
public class Lokation
{
    private readonly Dictionary<Retning, Lokation> _udgange = new();

    public Lokation(LokationType lokationType, int[,] gitter, Genstand? genstand = null)
    {
        Type = lokationType;
        Gitter = gitter;
        Genstand = genstand;
    }

    public LokationType Type { get; private set; }
    public int[,] Gitter { get; private set; }
    public Genstand? Genstand { get; private set; }
    public string Navn
    {
        get => Type.ToString();
        // private set;
    }

    public void TilføjUdgang(Retning retning, Lokation destination)
    {
        _udgange[retning] = destination;
    }

    public Lokation? HentUdgang(Retning retning)
    {
        return _udgange.GetValueOrDefault(retning);
    }
}
