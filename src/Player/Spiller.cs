/// <summary>
/// Repræsenterer spilleren og håndterer spillerens handlinger og interaktioner.
/// </summary>
public class Spiller
{
    [Obsolete("Find ud af hvad vi skal bruge navnet til. Ellers slet det")]
    private string _navn;
    private Rygsæk _rygsæk;

    public int Række { get; private set; }
    public int Søjle { get; private set; }

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

    public void SætPosition(int række, int søjle)
    {
        Række = række;
        Søjle = søjle;
    }

    // Skal implementeres:
    public void SamlGenstandOp(Genstand genstand) { }
    public void InteragerMedNPC(NPC npc) { }
    public void KiglRygsæk() => _rygsæk.VisIndhold();
    public bool LøsOpgave() => true;
}
