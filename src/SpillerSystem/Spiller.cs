/// <summary>
/// Repræsenterer spilleren og håndterer spillerens handlinger og interaktioner.
/// </summary>
public class Spiller
{
    private Rygsæk _rygsæk = new Rygsæk();

    public int Række { get; private set; }
    public int Søjle { get; private set; }

    public IReadOnlyList<Genstand> HentRygsækIndhold() => _rygsæk.Genstande;

    public (int Række, int Søjle) BeregnNæstePosition(Retning retning)
    {
        return retning switch
        {
            Retning.Nord => (Række - 1, Søjle),
            Retning.Syd => (Række + 1, Søjle),
            Retning.Vest => (Række, Søjle - 1),
            Retning.Øst => (Række, Søjle + 1),
            _ => (Række, Søjle)
        };
    }

    public bool HarGenstand(GenstandType type) => _rygsæk.HarGenstand(type);

    public void SætPosition(int række, int søjle)
    {
        Række = række;
        Søjle = søjle;
    }

    // Skal implementeres:
    public void SamlGenstand(Genstand genstand)
    {
        _rygsæk.TilføjGenstand(genstand);
    }

    public void InteragerMedNPC(NPC npc) { }
    public bool LøsOpgave() => true;
}
