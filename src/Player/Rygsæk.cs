/// <summary>
/// Repræsenterer spillerens rygsæk og håndterer dens genstande.
/// </summary>
public class Rygsæk
{
    // TODO: Erstat string med genstand type
    private List<Genstand> genstande = new List<Genstand>();

    /// <summary>
    /// Tilføjer den genstand til spillerens rygsæk.
    /// </summary>
    public void TilføjGenstand(Genstand genstand)
    {
        genstande.Add(genstand);
    }
    /// <summary>
    /// Viser alle genstande, der befinder sig i rygsækken.
    /// </summary>
    public void VisIndhold()
    {
        foreach (Genstand genstand in genstande)
        {
            Console.WriteLine(genstand);
        }
    }
}
