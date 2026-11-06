/// <summary>
/// Verden-klassen bruges til at modulerer og definerer hele spilleverden.
/// </summary>
public class Verden
{
    private readonly Dictionary<LokationType, Lokation> _lokationer = new();

    public Verden()
    {
        OpretLokationer();
        ForbindLokationer();
        StartLokation = _lokationer[LokationType.Hjem];
    }

    public Lokation StartLokation { get; }

    private void OpretLokationer()
    {
        Tilføj(new Lokation(LokationType.Hjem, new int[4, 5]));
        Tilføj(new Lokation(LokationType.GadeV, new int[7, 11]));
        Tilføj(new Lokation(LokationType.Station, new int[11, 6]));
    }

    private void ForbindLokationer()
    {
        Forbind(LokationType.Hjem, Retning.Syd, LokationType.GadeV, Retning.Nord);
        Forbind(LokationType.GadeV, Retning.Øst, LokationType.Station, Retning.Vest);
    }

    private void Tilføj(Lokation lokation)
    {
        _lokationer[lokation.Type] = lokation;
    }

    private void Forbind(LokationType fra, Retning retningFra, LokationType til, Retning retningTil)
    {
        _lokationer[fra].TilføjUdgang(retningFra, _lokationer[til]);
        _lokationer[til].TilføjUdgang(retningTil, _lokationer[fra]);
    }
}
