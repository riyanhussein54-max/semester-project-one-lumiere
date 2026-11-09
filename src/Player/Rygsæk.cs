/// <summary>
/// Repræsenterer spillerens rygsæk og håndterer dens genstande.
/// </summary>
public class Rygsæk
{
    private List<Genstand> genstande = new List<Genstand>();

    // Skal implementeres:
    public void TilføjGenstand(Genstand genstand) => genstande.Add(genstand);
    public void VisIndhold() { }
}
