/// <summary>
/// Repræsenterer spilleren og håndterer spillerens handlinger og interaktioner.
/// </summary>
public class Spiller
{
    [Obsolete("Find ud af hvad vi skal bruge navnet til. Ellers slet det")]
    private string _navn;
    //private Rygsæk _rygsæk;
    private Rygsæk _rygsæk = new Rygsæk();

    public Spiller()
    {
        // Hurtigt genstand test, kan godt fjernes
        _rygsæk.TilføjGenstand(new Genstand(GenstandType.RaSkulptur, "En gylden skulptur af den egyptiske gud Ra."));
        _rygsæk.TilføjGenstand(new Genstand(GenstandType.Radio, "En lille grå radio."));
    }

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
    public void SamlGenstand(Genstand genstand)
    {
        _rygsæk.TilføjGenstand(genstand);
    }
    
    public void InteragerMedNPC(NPC npc) { }
    public void KiglRygsæk() => _rygsæk.VisIndhold();
    public bool LøsOpgave() => true;
}
