public class ObjektPool
{
    public static readonly Objekt LysdæmperKontakt = new(
        type: ObjektType.LysdæmperKontakt,
        række: 0,
        søjle: 7,
        opgaverGiver: NPCType.Zehra,
        handlingsTekst: "Skru ned for lyset"
    );

    public static readonly Objekt Lampe = new(
        type: ObjektType.LuciusLampe,
        række: 0,
        søjle: 0,
        opgaverGiver: NPCType.Lucius,
        handlingsTekst: "Sluk for lampen"
    );

    public static readonly Objekt Lygtepæl = new(
        type: ObjektType.Lygtepæl,
        række: 1,
        søjle: 1,
        opgaverGiver: NPCType.Adam,
        handlingsTekst: "Ødelæg med hammeren",
        påkrævetGenstand: GenstandType.Hammer
    );
}
