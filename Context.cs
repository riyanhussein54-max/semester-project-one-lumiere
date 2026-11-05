class Spiller
{
    private string navn;
    private Rygsæk Rygsæk;

    public Spiller(string navn, Rygsæk Rygsæk)
    {
        this.Navn = navn;
        this.Rygsæk = Rygsæk;
    }

    public void Bevæg(string Retning)
    {
        Console.WriteLine(Navn + "bevæger sig mod" + Retning);
    }

    public void SamlGenstandOp(Genstand genstand)
    {

    }
    public void InteragerMedNPC(NPC npc)
    {
        npc.UdløsEvent();
    }

    public void KiglRygsæk()
    {
        rygsæk.VisGenstande();
    }

    public bool LøsOpgave()
    {
        Console.WriteLine(Navn + " løste en opgave!");
    }
}
