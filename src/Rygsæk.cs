public class Rygsæk
{
    // TODO: Erstat string med genstand type
    private List<Genstand> genstande = new List<Genstand>();
    public void TilføjGenstand(Genstand genstand)
    {
        genstande.Add(genstand);
    }
    public void VisIndhold()
    {
        foreach (Genstand genstand in genstande)
        {
            Console.WriteLine(genstand);
        }
    }
}
