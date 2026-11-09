/// <summary>
/// Håndterer tegning af spillets brugerflade, herunder informationer og koordinatsystem.
/// </summary>
public class SkærmTegner
{
    private static bool _visControls = true;

    public static void SkiftMenuSynlighed() => _visControls = !_visControls;

    /// <summary>
    /// Opdaterer og tegner hele spilskærmen baseret på spillets aktuelle tilstand
    /// </summary>
    public static void TegnSkærm(SpilStyrer spilStyrer, string opgaveNavn = "Ingen")
    {
        Console.Clear();
        TegnTopPanel(spilStyrer, opgaveNavn);
        Console.WriteLine();
        TegnKoordinatSystem(spilStyrer.NuværendeLokation.Gitter, spilStyrer);
    }

    private static void TegnTopPanel(SpilStyrer spilStyrer, string opgaveNavn)
    {
        string lys = $"{spilStyrer.Lysforurening}%";
        string lokation = spilStyrer.NuværendeLokation.Navn;

        TegnStatusTop();
        Console.WriteLine("  ┌─── [Symboler] ───┐");

        Console.Write(FormaterStatusLinje("Lysforurening", lys));
        Console.WriteLine("  │ & = Dig          │");

        Console.Write(FormaterStatusLinje("Lokation", lokation));
        Console.WriteLine("  │ # = Udgang/Dør   │");

        Console.Write(FormaterStatusLinje("Opgave", opgaveNavn));
        Console.WriteLine("  │ ¤ = Genstand     │");

        if (_visControls)
        {
            Console.WriteLine("├──────────────────────────────────────────────────┤  │ @ = NPC          │");
            Console.WriteLine("│ [WASD] Bevæg   [R] Skjul Menu   [H] Hjælp        │  └──────────────────┘");
            Console.WriteLine("└──────────────────────────────────────────────────┘");
        }
        else
        {
            Console.WriteLine("└──────────────────────────────────────────────────┘  │ @ = NPC          │");
            Console.WriteLine("                                                      └──────────────────┘");
        }
    }

    /// <summary>
    /// Her udregner vi automatisk antallet af punktummer, så linjen altid er præcis 52 tegn bred
    ///
    /// Math.Max bruges i tilfældet af at opgave-stringen bliver for lang, som kan crashe spillet
    /// </summary>
    private static string FormaterStatusLinje(string label, string værdi)
    {
        int indreBredde = 48; // 50 minus 1 mellemrum i hver side
        int antalPrikker = Math.Max(2, indreBredde - label.Length - værdi.Length - 2);
        string prikker = new string('.', antalPrikker);
        return $"│ {label} {prikker} {værdi} │";
    }

    private static void TegnStatusTop()
    {
        if (BrugerOpretter.Brugertilstand == Brugertilstand.Dev)
        {
            Console.Write("┌──────────────────── [");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Status");
            Console.ResetColor();
            Console.Write("] ────────────────────┐");
        }
        else
        {
            Console.Write("┌──────────────────── [Status] ────────────────────┐");
        }
    }

    private static void TegnKoordinatSystem(FeltType[,] gitterRamme, SpilStyrer spilStyrer)
    {
        int rækker = gitterRamme.GetLength(0);
        int søjler = gitterRamme.GetLength(1);

        // Centrerer gitteret automatisk under Status-boksen (52 tegn bred)
        int gitterVisuelBredde = søjler * 2;
        int venstreMargin = Math.Max(2, (52 - gitterVisuelBredde) / 2);
        string indrykning = new string(' ', venstreMargin);

        for (int række = 0; række < rækker; række++)
        {
            Console.Write(indrykning);
            for (int søjle = 0; søjle < søjler; søjle++)
            {
                if (spilStyrer.ErSpillerPå(række, søjle))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" &");
                    Console.ResetColor();
                    continue;
                }

                switch (gitterRamme[række, søjle])
                {
                    case FeltType.Dør:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" #");
                        Console.ResetColor();
                        break;
                    case FeltType.Genstand:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" ¤");
                        Console.ResetColor();
                        break;
                    case FeltType.NPC:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" @");
                        Console.ResetColor();
                        break;
                    case FeltType.Væg:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" #");
                        Console.ResetColor();
                        break;
                    case FeltType.Gulv:
                    default:
                        Console.Write(" ·");
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}
