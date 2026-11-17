/// <summary>
/// Genstand-klassen repræsenterer ting (items), som findes i spilverdenen.
/// </summary>
public class Genstand
{
    public string Beskrivelse { get; private set; }
    public GenstandType Type { get; private set; }

    public Genstand(GenstandType type, string beskrivelse)
    {
        Beskrivelse = beskrivelse;
        Type = type;
    }

    public string Navn => Type.ToString();

    public Genstand Kopier() => new Genstand(Type, Beskrivelse);
}
