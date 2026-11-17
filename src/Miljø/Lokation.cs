/// <summary>
/// Lokation-klassen definerer en lokations layout, genstande, NPCer, osv...
/// </summary>
public class Lokation
{
    // TODO:
    // - Metode til at fjerne genstande fra gulvet, fx:
    // --- FjernGenstand(int række, int søjle) => genstand = null;

    private readonly Dictionary<Retning, Lokation> _udgange = new();

    public Lokation(LokationType lokationType, FeltType[,] gitter, Genstand? genstand = null)
    {
        Type = lokationType;
        Gitter = gitter;
        Genstand = genstand;
    }

    public LokationType Type { get; private set; }
    public FeltType[,] Gitter { get; private set; }
    public Genstand? Genstand { get; private set; }
    public string Navn
    {
        // FIX: Find en løsning som formatter navnet korrekt (evt. med switch-expression)
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
}
