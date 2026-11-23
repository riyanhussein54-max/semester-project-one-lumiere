/// <summary>
/// Lokation-klassen definerer en lokations layout, genstande, NPCer, osv...
/// </summary>
public class Lokation
{
    public Genstand? SamlGenstand(int r, int s, bool samles = false)
    {
        if (_genstande.TryGetValue((r, s), out Genstand? fundetGenstand))
        {
            if (fundetGenstand.Samles != true)
                return null;

            if (samles)
                return fundetGenstand;

            _genstande.Remove((r, s));
            Gitter[r, s] = FeltType.Gulv;
            return fundetGenstand;
        }

        return null;
    }

    private readonly Dictionary<Retning, Lokation> _udgange = new();

    public Lokation(LokationType lokationType, FeltType[,] gitter /* Genstand? genstand = null */)
    {
        Type = lokationType;
        Gitter = gitter;
        //Genstand = genstand;
    }

    public LokationType Type { get; private set; }
    public FeltType[,] Gitter { get; private set; }

    /// -------------------- Ivanas ændringer START ----------------------------

    // Lavet "Genstand" om til en dictionary så vi kan spawne flere genstande i en lokation
    //public Genstand? Genstand { get; private set; }
    private Dictionary<(int r, int s), Genstand> _genstande = new();

    // NPC dictionary så vi kan spawn flere npcer i en lokation
    private Dictionary<(int r, int s), NPC> _npcs = new();

    /// <summary>
    /// Spawner en eller flere genstand(e) i spillet ved angivet koordinater
    /// Genstande udskrives med den genstand symbol "¤"
    /// </summary>
    public void SpawnGenstand(Genstand genstand /*, int r, int s*/)
    {
        int r = genstand.Position.række;
        int s = genstand.Position.søjle;

        try
        {
            _genstande[(r, s)] = genstand;
            Gitter[r, s] = FeltType.Genstand;
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException($"Kunne ikke placere {genstand.Navn} på ({r}, {s}) i {Type}, da koordinatet er uden for gittert");
        }
    }

    /// <summary>
    /// Spawner en eller flere npc(er) i spillet ved angivet koordinater
    /// Genstande udskrives med den genstand symbol "@"
    /// </summary>
    public void SpawnNPC(NPC npc)
    {
        int r = npc.Position.række;
        int s = npc.Position.søjle;

        try
        {
            _npcs[(r, s)] = npc;
            Gitter[r, s] = FeltType.NPC;
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException($"Kunne ikke placere {npc.Navn} på ({r}, {s}) i {Type}, da koordinatet er uden for gittert");
        }
    }

    /// -------------------- Ivanas ændringer SLUT ----------------------------

    public string Navn
    {
        // TODO: Find en løsning som formatter navnet korrekt (evt. med switch-expression)
        get => Type.ToString();
    }

    /// <summary>
    /// Tilføjer en udgang til lokationen.
    /// Den retning der vælges er lokationens placering ift. destinationen.
    /// </summary>
    public void TilføjUdgang(Retning retning, Lokation destination)
    {
        _udgange[retning] = destination;
        (int række, int søjle) = HentDørKoordinat(retning);
        Gitter[række, søjle] = FeltType.Dør;
    }

    // TODO: Overvej om vi skal lave en Struct i stedet for disse tuples
    // ! Kunne fx hedde
    public (int Række, int Søjle) HentDørKoordinat(Retning retning)
    {
        int rækker = Gitter.GetLength(0);
        int søjler = Gitter.GetLength(1);

        return retning switch
        {
            Retning.Nord => (0, søjler / 2),
            Retning.Syd => (rækker - 1, søjler / 2),
            Retning.Vest => (rækker / 2, 0),
            Retning.Øst => (rækker / 2, søjler - 1),
        };
    }

    public Lokation? HentUdgangFraKoordinat(int række, int søjle)
    {
        foreach ((Retning retning, Lokation? destination) in _udgange)
        {
            if (HentDørKoordinat(retning) == (række, søjle))
            {
                return destination;
            }
        }
        return null;
    }

    public (int Række, int Søjle) HentDørKoordinatTil(Lokation destination)
    {
        foreach ((Retning retning, Lokation? lokation) in _udgange)
        {
            if (lokation == destination)
            {
                return HentDørKoordinat(retning);
            }
        }

        // In case noget går galt, spawner spilleren i midten
        return (Gitter.GetLength(0) / 2, Gitter.GetLength(1) / 2);
    }

    public Lokation? HentUdgang(Retning retning)
    {
        return _udgange.GetValueOrDefault(retning);
    }

    public NPC? HentNPCFraKoordinat(int række, int søjle)
    {
        return _npcs.GetValueOrDefault((række, søjle));
    }
}
