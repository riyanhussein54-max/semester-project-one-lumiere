/// <summary>
/// Repræsenterer spilleren og håndterer spillerens handlinger og interaktioner.
/// </summary>
public class Spiller
{
    private string _navn;
    private Rygsæk _rygsæk;

    /// <summary>
    /// Opretter en spiller med et navn og en rygsæk.
    /// </summary>
    public Spiller(string navn, Rygsæk rygsæk)
    {
        _navn = navn;
        _rygsæk = rygsæk;
    }

    /// <summary>
    /// Angiver den retning, spilleren bevæger sig i.
    /// </summary>
    public void Bevæg(string retning)
    {
        Console.WriteLine($"{_navn} bevæger sig mod {retning}");
    }

    /// <summary>
    /// Håndterer opsamling af en genstand.
    /// </summary>
    public void SamlGenstandOp(Genstand genstand) { }

    /// <summary>
    /// Håndterer spillerens interaktion med en NPC.
    //  TODO: Tilføj NPC parameter når det er
    /// </summary>
    public void InteragerMedNPC() { }

    /// <summary>
    /// Viser indholdet af spillerens rygsæk.
    /// </summary>
    public void KiglRygsæk() => _rygsæk.VisIndhold();

    /// <summary>
    /// Forsøger at løse en opgave.
    /// </summary>
    public bool LøsOpgave() => true;

}
