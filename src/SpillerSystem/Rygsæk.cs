/// <summary>
/// Repræsenterer spillerens rygsæk og håndterer dens genstande.
/// </summary>
public class Rygsæk
{
    private List<Genstand> _genstande = new List<Genstand>();

    public IReadOnlyList<Genstand> Genstande => _genstande;

    public void TilføjGenstand(Genstand genstand) => _genstande.Add(genstand);

    /// <summary>
    /// Bruges til opgave for at check om spilleren har dn nødvendige genstand til at løse opgaven
    /// </summary>
    public bool HarGenstand(GenstandType type)
    {
        foreach (Genstand genstand in _genstande)
        {
            if (genstand.Type == type)
            {
                return true;
            }
        }
        return false;
    }
}
