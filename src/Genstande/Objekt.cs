public class Objekt
{
    public Objekt(
        ObjektType type,
        int række,
        int søjle,
        string handlingsTekst,
        NPCType opgaverGiver,
        GenstandType? påkrævetGenstand = null
        )
    {
        Type = type;
        Position = (række, søjle);
        HandlingsTekst = handlingsTekst;
        OpgaveGiver = opgaverGiver;
        PåkrævetGenstand = påkrævetGenstand;
    }

    public ObjektType Type { get; private set; }
    public bool ErBrugt { get; private set; }
    public (int række, int søjle) Position { get; set; }
    public string HandlingsTekst { get; }
    public NPCType OpgaveGiver { get; }
    public GenstandType? PåkrævetGenstand { get; }

    public string Navn => Type.ToString();

    public void MarkerSomBrugt() => ErBrugt = true;
}
