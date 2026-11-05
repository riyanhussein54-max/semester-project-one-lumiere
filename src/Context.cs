class Spiller
{
    private string navn;
    // private Rygsæk Rygsæk;

    public Spiller(string navn /* Rygsæk Rygsæk  */)
    {
        this.navn = navn;
        // this.Rygsæk = Rygsæk;
    }

    public void Bevæg(string retning)
    {
        Console.WriteLine($"{navn} bevæger sig mod {retning}");
    }

    // TODO: Tilføj Genstand parameter når det er
    public void SamlGenstandOp()
    {

    }

    // TODO: Til NPC parameter når det er
    public void InteragerMedNPC()
    {
    }

    public void KiglRygsæk()
    {
        // rygsæk.VisGenstande();
    }

    public bool LøsOpgave()
    {
        // sConsole.WriteLine(Navn + " løste en opgave!");
        return true;
    }
}
