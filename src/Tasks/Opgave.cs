public class Opgave
{
    public Opgave(string beskrivelse, int lysforureningReduktion = 15, GenstandType? påkrævetGenstand = null)
    {
        Beskrivelse = beskrivelse;
        LysforureningReduktion = lysforureningReduktion;
        PåkrævetGenstand = påkrævetGenstand;
    }

    public string Beskrivelse { get; }
    public int LysforureningReduktion { get; }
    public GenstandType? PåkrævetGenstand { get; }
    public bool ErFuldført { get; private set; }

    public void MarkerSomFuldført() => ErFuldført = true;
}
