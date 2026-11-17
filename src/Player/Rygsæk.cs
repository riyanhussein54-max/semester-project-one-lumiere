/// <summary>
/// Repræsenterer spillerens rygsæk og håndterer dens genstande.
/// </summary>
public class Rygsæk
{
    private List<Genstand> _genstande = new List<Genstand>();

    // Skal implementeres:
    public void TilføjGenstand(Genstand genstand) => _genstande.Add(genstand);

    /// <summary>
    /// Print rygsækkets indhold. Bruges i "MenuTegner.cs" til "VisRygsækMenu"
    /// </summary>
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
                Console.WriteLine(FormaterRygsækMenuLinje(g));
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

    // TODO: bedre formatterings funktion
    // evt. kode så hvis linjens tekst er for langt den udskriver resten på den næste linje
    /// <summary>
    /// Kopi af FormaterStatusLinje funktionen fra "Skærmtegner".
    /// Viser genstandens navn og beskrivelse.
    /// </summary>
    private static string FormaterRygsækMenuLinje(Genstand g)
    {
        int indreBredde = 51;
        string navn = g.Navn;
        string beskrivelse = g.Beskrivelse;

        int antalPrikker = Math.Max(2, indreBredde - navn.Length - beskrivelse.Length - 2);
        string prikker = new string('.', antalPrikker);

        return $"│ {navn} {prikker} {beskrivelse} │";
    }
}
