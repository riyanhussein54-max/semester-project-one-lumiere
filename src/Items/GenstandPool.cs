/// <summary>
/// GenstandPool-klassen opbevarer og udleverer alle spillets genstande.
/// </summary>
public static class GenstandPool
{
    // Indgang
    public static Genstand sikkerhedsUdstyr = new(GenstandType.Sikkerhedsudstyr,"Beskytter dig ved højspænding");
    public static Genstand Lommelygte = new(GenstandType.Lommelygte,"Lyser mørke områder op");
    public static Genstand Sut = new(GenstandType.Sut ,"Trøster zara");
    //Centrum
    public static Genstand Voltmåler = new(GenstandType.Voltmåler,"Måler elektrisk spænding");
    public static Genstand TermiskKamera = new(GenstandType.TermiskKamera,"Viser varme og temperaturforskelle");
    public static Genstand Radio = new(GenstandType.Radio ,"Bruges til kommunikation");
    public static Genstand DiagnostiskTablet = new(GenstandType.DiagnostiskTablet,"Hjælper med at diagnosticere tekniske problemer");

    // Tek Kontoret
    public static Genstand Lyskilder = new(GenstandType.Lyskilder,"Lyskilder");
    public static Genstand LysStyringsPanel = new(GenstandType.LysStyringsPanel ,"Styrer lysstyrken");

    //Kælderen
    public static Genstand Luxmåler = new(GenstandType.Luxmåler,"Måler lysstyrken i et område");
    public static Genstand VarmLedPære = new(GenstandType.VarmLedPære,"Udsender et varmt lys");
    public static Genstand Spektrometer = new(GenstandType.Spektrometer,"Analyserer lysets spektrum og dens egenskaber");
    public static Genstand LedPære = new(GenstandType.LedPære,"Energieffektiv pære");
    public static Genstand Bevægelsessensor = new(GenstandType.Bevægelsessensor,"Registrerer bevægelse og aktiverer lyset");

    // Byparken
    public static Genstand Gadelamper = new(GenstandType.Gadelamper,"Oplyser veje og stier i parken");
    public static Genstand ParkLysstyringspanel = new(GenstandType.ParkLysstyringspanel,"Styrer parkens belysning");

    // Zehra
    public static Genstand RaSkulptur = new(GenstandType.RaSkulptur,"En rå skulptur med ukendte egenskaber");
}