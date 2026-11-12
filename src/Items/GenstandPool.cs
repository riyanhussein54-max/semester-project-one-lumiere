/// <summary>
/// GenstandPool-klassen opbevarer og udleverer alle spillets genstande.
/// </summary>
public static class GenstandPool
{
    // Indgang
    public static Genstand sikkerhedsUdstyr = new(GenstandType.Sikkerhedsudstyr, "Beskytter dig ved højspænding");
    public static Genstand Lommelygte = new(GenstandType.Lommelygte, "");
    public static Genstand Gadelamper = new(GenstandType.Gadelamper, "");
    public static Genstand Sut = new(GenstandType.Sut ,"");
    //Centrum
    public static Genstand Voltmåler = new(GenstandType.Voltmåler,"");
    public static Genstand TermiskKamera = new(GenstandType.TermiskKamera,"");
    public static Genstand Radio = new(GenstandType.Radio ,"");
    public static Genstand DiagnostiskTablet = new(GenstandType.DiagnostiskTablet,"");

    // Tek Kontoret
    public static Genstand Lyskilder = new(GenstandType.Lyskilder,"");
    public static Genstand LysStyringsPanel = new(GenstandType.LysStyringsPanel ,"");

    //Kælderen
    public static Genstand Luxmåler = new(GenstandType.Luxmåler,"");
    public static Genstand VarmLedPære = new(GenstandType.VarmLedPære,"");
    public static Genstand Spektrometer = new(GenstandType.Spektrometer,"");
    public static Genstand LedPære = new(GenstandType.LedPære,"");
    public static Genstand Bevægelsessensor = new(GenstandType.Bevægelsessensor,"");

    // Byparken
    public static Genstand Gadelamper = new(GenstandType.Gadelamper,"");
    public static Genstand ParkLysstyringspanel = new(GenstandType.ParkLysstyringspanel,"");

    // Zehra
    public static Genstand RaSkulptur = new(GenstandType.RaSkulptur,"");
}
    /*
    private static List<Genstand> _genstande =
    [
        // Indgang
        new(GenstandType.Sikkerhedsudstyr, "Sikkerhedsudstyr", "Beskytter dig ved højspænding."),
        new(GenstandType.Sikkerhedsudstyr, "Lommelygte", ""),
        new(GenstandType.Gadelamper, "Gryde", ""),
        // Sut,

        // // Centrum
        // Voltmåler,
        // TermiskKamera,
        // Radio,
        // DiagnostiskTablet,

        // // Tek Kontoret
        // Lyskilder,
        // LysStyringsPanel,

        // //Kælderen
        // Luxmåler,
        // VarmLedPære,
        // Spektrometer,
        // LedPære,
        // Bevægelsessensor,

        // // Byparken
        // Gadelamper,
        // ParkLysstyringspanel,

        // // Zehra
        // RaSkulptur
    ];
    /// <summary>
    /// Henter en kopi af en genstand ud fra dens GenstandType.
    /// </summary>
    public static Genstand HentGenstand(GenstandType type)
    {
        foreach (Genstand genstand in _genstande)
        {
            if (genstand.Type == type)
            {
                return genstand.Kopier();
            }
        }
        throw new KeyNotFoundException($"Ukendt genstand: {type}");
    }
    */
}
