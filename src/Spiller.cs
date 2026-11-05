class Spiller
{
    private string _navn;
    private Rygsæk _rygsæk;

    public Spiller(string navn, Rygsæk rygsæk)
    {
        this._navn = navn;
        this._rygsæk = rygsæk;
    }

    public void Bevæg(string retning)
    {
        Console.WriteLine($"{_navn} bevæger sig mod {retning}");
    }

    public void SamlGenstandOp(Genstand genstand)
    {

    }

    // TODO: Til NPC parameter når det er
    public void InteragerMedNPC()
    {
    }

    public void KiglRygsæk()
    {
        _rygsæk.VisIndhold();
    }

    public bool LøsOpgave()
    {
        // sConsole.WriteLine(Navn + " løste en opgave!");
        return true;
    }
}
