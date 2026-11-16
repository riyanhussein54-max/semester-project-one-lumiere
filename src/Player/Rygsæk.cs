/// <summary>
/// Repræsenterer spillerens rygsæk og håndterer dens genstande.
/// </summary>
public class Rygsæk
{
    private List<Genstand> _genstande = new List<Genstand>();

    // Skal implementeres:
    public void TilføjGenstand(Genstand genstand) => _genstande.Add(genstand);
    public void VisIndhold()
    {
        if (_genstande.Count > 0)
        {
            Console.WriteLine(
                $"""
                │ Genstande ______________________________________ │
                """
            );
            foreach (Genstand g in _genstande)
            {
                Console.WriteLine(FormaterStatusLinjeRygsæk(g));
            }
        }
        else
        {
            Console.WriteLine(
                $"""
                │                Rygsækken er tom.                 │
                """
            );
            return;
        }
    }

    private static string FormaterStatusLinjeRygsæk(Genstand g)
    {
        int indreBredde = 51;
        string navn = g.Navn;
        string beskrivelse = g.Beskrivelse;

        int antalPrikker = Math.Max(2, indreBredde - navn.Length - beskrivelse.Length - 2);
        string prikker = new string('.', antalPrikker);

        return $"│ {navn} {prikker} {beskrivelse} │";
    }
}
