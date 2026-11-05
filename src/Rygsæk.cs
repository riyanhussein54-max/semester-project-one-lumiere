public class Rygsæk
{
    // TODO: Erstat string med genstand type
    private List<string> genstande = new List<string>();
    public void TilføjGenstand(string genstand)
    {
        genstande.Add(genstand);
    }
    public void VisIndhold()
    {
        foreach (string genstand in genstande)
        {
            System.Console.WriteLine(genstand);
        }
    }
}
