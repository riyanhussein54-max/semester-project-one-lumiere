/// <summary>
/// Genstand-klassen repræsenterer ting (items), som findes i spilverdenen.
/// </summary>
class Genstand
{
    public string Navn{get; private set;}
    public string Beskrivelse{get; private set;}

    public Genstand(string navn, string beskrivelse)
    {
        Navn = navn;
        Beskrivelse = beskrivelse;
    }
}
