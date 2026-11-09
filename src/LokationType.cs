/// <summary>
/// Definerer de forskellige typer af lokationer, der kan findes i spillets verden.
/// </summary>
public enum LokationType
{
    Opstart = 0,

    // Generelt
    Bygning,
    UdenForByen,

    // Lokationer
    //[Description("Indendørs")]
    Butik,
    Bibliotek,
    Sygehus,
    Bopæl,
    Inkøbscenter,
    Restaurant,
    Cafe,
    Kraftværk,
    Politistation,
    Lager,
    Park,
    Hospital,
    Universitet,

    // Mulighvis forbindelsesstier?
    Gyde,
    Gang,
    Gade,

    /*
        [Description("Indendørs")]
        LilleRum,
        [Description("Indendørs")]
        StortRum,
     */
}
