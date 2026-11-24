public class Opgave
{
    public Opgave(
        string titel,
        string beskrivelse,
        int lysforureningReduktion = 15,
        GenstandType? påkrævetGenstand = null,
        Genstand? opgavePremie = null)
    {
        Titel = titel;
        Beskrivelse = beskrivelse;
        LysforureningReduktion = lysforureningReduktion;
        PåkrævetGenstand = påkrævetGenstand;
        OpgavePremie = opgavePremie;
    }

    public string Titel { get; }
    public string Beskrivelse { get; }
    public int LysforureningReduktion { get; }
    public GenstandType? PåkrævetGenstand { get; }
    public bool ErFuldført { get; private set; }
    public Genstand? OpgavePremie { get; }

    public void MarkerSomFuldført() => ErFuldført = true;
    public bool HarGenstandtilOpgave(Rygsæk rygsæk)
    {
        if (PåkrævetGenstand == null)
        {
            return true;
        }
        return rygsæk.HarGenstand(PåkrævetGenstand.Value);
    }
}
