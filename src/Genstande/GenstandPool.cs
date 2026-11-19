/// <summary>
/// GenstandPool-klassen opbevarer og udleverer alle spillets genstande.
/// </summary>
public static class GenstandPool
{
    // Indgang
    public static Genstand sikkerhedsUdstyr = new(GenstandType.Sut, "Beskytter dig ved højspænding");
    public static Genstand Lommelygte = new(GenstandType.Hammer, "Lyser mørke områder op");
    public static Genstand Sut = new(GenstandType.Elpære, "Trøster zara");
    //Centrum
    public static Genstand Voltmåler = new(GenstandType.Telefon, "Måler elektrisk spænding");
}
