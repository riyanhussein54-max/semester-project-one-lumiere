/// <summary>
/// GenstandPool-klassen opbevarer og udleverer alle spillets genstande.
/// </summary>
public static class GenstandPool
{
    public static readonly Genstand Elpære = new(
        type: GenstandType.Elpære,
        række: 2,
        søjle: 2,
        beskrivelse: "PHILIPS LED-pære."
    );

    public static readonly Genstand Telefon = new(
        type: GenstandType.Telefon,
        række: 2,
        søjle: 4,
        beskrivelse: "Samsung Galaxy A."
    );

    public static readonly Genstand Hammer = new(
        type: GenstandType.Hammer,
        række: 2,
        søjle: 4,
        beskrivelse: "Den slår hårdt."
    );
}
