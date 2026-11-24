/// <summary>
/// Genstand-klassen repræsenterer ting (items), som findes i spilverdenen.
/// </summary>
public class Genstand
{
    public Genstand(GenstandType type, int række, int søjle, string beskrivelse)
    {
        Beskrivelse = beskrivelse;
        Position = (række, søjle);
        Type = type;
    }

    public string Beskrivelse { get; private set; }
    public GenstandType Type { get; private set; }
    public (int række, int søjle) Position { get; set; }
    public string Navn => Type.ToString();

    public Genstand Kopier() => new Genstand(
        Type,
        Position.række,
        Position.søjle,
        Beskrivelse
    );
}
