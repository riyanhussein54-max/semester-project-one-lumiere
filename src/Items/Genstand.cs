/// <summary>
/// Genstand-klassen repræsenterer ting (items), som findes i spilverdenen.
/// </summary>
public class Genstand
{
    public string Navn { get; private set; }
    public string Beskrivelse { get; private set; }
    public GenstandType Type { get; private set; }

    public Genstand(string navn, string beskrivelse, GenstandType type)
    {
        Navn = navn;
        Beskrivelse = beskrivelse;
        Type = type;
    }
    public Genstand Kopier()
    {
        return new Genstand(Type, Navn, Beskrivelse);
    }
    public override string ToString()
    {
        return $"{Navn}:{Beskrivelse}";
    }
}
