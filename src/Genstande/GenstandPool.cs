/// <summary>
/// GenstandPool-klassen opbevarer og udleverer alle spillets genstande.
/// </summary>
public static class GenstandPool
{
    public static Genstand Elpære = new(GenstandType.Elpære, 2, 2, "PHILIPS LED-pære.");
    public static Genstand Telefon = new(GenstandType.Telefon, 2, 4, "Samsung Galaxy A.");
    public static Genstand Hammer = new(GenstandType.Hammer, 2, 4, "Den slår hårdt.");
}
