public class Opgave
{
    public Opgave(
        string titel,
        string beskrivelse,
        int lysforureningReduktion = 15,
        GenstandType? påkrævetGenstand = null,
        LokationType[]? låsOpLokationer = null,
        bool løsesVedSamtale = false)
    {
        Titel = titel;
        Beskrivelse = beskrivelse;
        LysforureningReduktion = lysforureningReduktion;
        PåkrævetGenstand = påkrævetGenstand;
        LåsOpLokationer = låsOpLokationer ?? [];
        LøsesVedSamtale = løsesVedSamtale;
    }

    public string Titel { get; }
    public string Beskrivelse { get; }
    public int LysforureningReduktion { get; }
    public GenstandType? PåkrævetGenstand { get; }
    public LokationType[] LåsOpLokationer { get; }
    public bool ErFuldført { get; private set; }
    public bool LøsesVedSamtale { get; }

    public void MarkerSomFuldført() => ErFuldført = true;

    public bool HarGenstandTilOpgave(Spiller spiller)
    {
        if (PåkrævetGenstand == null)
        {
            return true;
        }

        return spiller.HarGenstand(PåkrævetGenstand.Value);
    }
}
