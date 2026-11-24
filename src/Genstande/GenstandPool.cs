/// <summary>
/// GenstandPool-klassen opbevarer og udleverer alle spillets genstande.
/// </summary>
public static class GenstandPool
{
    // Centrum
    public static Genstand Sut = new(GenstandType.Sut, 1, 1, "Farven er lyserød.");

    // Elgiganten
    public static Genstand Elpære = new(GenstandType.Elpære, 2, 2, "PHILIPS LED-pære.");

    // Ivanas Hjem
    public static Genstand Telefon = new(GenstandType.Telefon, 2, 4, "Samsung Galaxy A.");

    // Harald Nyborg
    public static Genstand Hammer = new(GenstandType.Hammer, 2, 4, "Den slår hårdt.");

    // Park
    public static Genstand[] GadeLamper =
    {
        new(GenstandType.GadeLampe, 0, 1, "The street lamp is evil and must be punished.", false),
        new(GenstandType.GadeLampe, 0, 6, "The street lamp is evil and must be punished.", false),
        new(GenstandType.GadeLampe, 2, 0, "The street lamp is evil and must be punished.", false),
        new(GenstandType.GadeLampe, 5, 0, "The street lamp is evil and must be punished.", false),
        new(GenstandType.GadeLampe, 7, 1, "The street lamp is evil and must be punished.", false),
        new(GenstandType.GadeLampe, 7, 6, "The street lamp is evil and must be punished.", false),
        new(GenstandType.GadeLampe, 5, 7, "The street lamp is evil and must be punished.", false),
        new(GenstandType.GadeLampe, 2, 7, "The street lamp is evil and must be punished.", false),
    };

    /*
    // Indgang
    public static Genstand sikkerhedsUdstyr = new(GenstandType.Sut, "Beskytter dig ved højspænding");
    public static Genstand Lommelygte = new(GenstandType.Hammer, "Lyser mørke områder op");
    public static Genstand Sut = new(GenstandType.Elpære, "Trøster zara");
    //Centrum
    public static Genstand Voltmåler = new(GenstandType.Telefon, "Måler elektrisk spænding");
    */
}
