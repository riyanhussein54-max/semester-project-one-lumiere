/// <summary>
/// Genstand-klassen repræsenterer ting (items), som findes i spilverdenen.
/// </summary>
class Genstand
{
    public string Navn;
    public string Beskrivelse;

    public Genstand(string navn, string beskrivelse)
    {
        Navn = navn;
        Beskrivelse = beskrivelse;
    }
}
