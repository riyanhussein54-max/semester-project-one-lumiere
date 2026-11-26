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
    public static void TegnSkærm(SpilStyrer spilStyrer)
    {
        Console.Clear();
        string opgaveNavn = spilStyrer.NuværendeOpgave?.Titel ?? "Ingen";
        TegnTopPanel(spilStyrer, opgaveNavn);
        Console.WriteLine();
        TegnKoordinatSystem(spilStyrer.NuværendeLokation.Gitter, spilStyrer);

        if (spilStyrer.SenestOpsamletGenstand != null)
        {
            Console.WriteLine();
            TegnBeskedBoks($"Du lagde {spilStyrer.SenestOpsamletGenstand.Navn.ToLower()} i rygsækken.");
        }

        if (spilStyrer.SenesteInteraktionsBesked != null)
        {
            Console.WriteLine();
            TegnBeskedBoks(spilStyrer.SenesteInteraktionsBesked);
        }

        if (spilStyrer.LåstDørLokation != null)
        {
            Console.WriteLine();
            TegnBeskedBoks($"Indgangen til {spilStyrer.LåstDørLokation.Navn} er låst.");
        }

        if (spilStyrer.SenestOplåsteLokationer.Count > 0)
        {
            Console.WriteLine();
            string navne = string.Join(", ", spilStyrer.SenestOplåsteLokationer.Select(lokation => lokation.Navn));
            TegnBeskedBoks($"Du låste op for: {navne}!");
        }
    }

    private static void TegnTopPanel(SpilStyrer spilStyrer, string opgaveNavn)
    {
        string lys = $"{spilStyrer.Lysforurening}%";
        string lokation = spilStyrer.NuværendeLokation.Navn;
        string tid = spilStyrer.NuværendeTid.ToString();

        TegnStatusTop();
        Console.WriteLine("");
        Console.Write(FormaterStatusLinje("Tid", tid));
        Console.WriteLine("");
        Console.Write(FormaterStatusLinje("Lysforurening", lys));
        Console.WriteLine("");
        Console.Write(FormaterStatusLinje("Lokation", lokation));
        Console.WriteLine("");
        Console.Write(FormaterStatusLinje("Opgave", opgaveNavn));
        Console.WriteLine("");

        if (_visControls)
        {
            Console.WriteLine(
                $"""
                ├──────────────────────────────────────────────────┤
                │ [WASD] Bevæg   [M] Minimap   [H] Hjælp           │
                └──────────────────────────────────────────────────┘
                """
            );
        }
        else
        {
            Console.WriteLine("└──────────────────────────────────────────────────┘");
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
                    case FeltType.Objekt:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" %");
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

    private static void TegnBeskedBoks(string besked)
    {
        Console.WriteLine("┌──────────────────────────────────────────────────┐");
        // FIX: Er det nødvendigt med char array?
        foreach (char[] linje in besked.Chunk(48))
        {
            Console.WriteLine($"│ {new string(linje),-48} │");
        }
        Console.WriteLine("└──────────────────────────────────────────────────┘");
    }

    public static bool TegnObjektInteraktionBoks(Objekt objekt)
    {
        // 0 = Handling og 1 = Annuller
        int valgtIndex = 0;
        int venstreBredde = Math.Max(19, objekt.Navn.Length + 4);
        int højreBredde = Math.Max(21, objekt.HandlingsTekst.Length + 7);

        string venstreStreg = new string('─', venstreBredde);
        string højreStreg = new string('─', højreBredde);
        string venstreMellemrum = new string(' ', venstreBredde + 1);

        int startY = Console.CursorTop + 1;

        while (true)
        {
            Console.SetCursorPosition(0, startY);

            string markør0 = valgtIndex == 0 ? ">" : " ";
            string markør1 = valgtIndex == 1 ? ">" : " ";

            string linje0 = $" {markør0}  {objekt.HandlingsTekst}".PadRight(højreBredde);
            string linje1 = $" {markør1}  Annuller".PadRight(højreBredde);

            Console.WriteLine($"┌{venstreStreg}┬{højreStreg}┐");
            Console.WriteLine($"│ {objekt.Navn.PadRight(venstreBredde - 1)}│{linje0}│");
            Console.WriteLine($"└{venstreStreg}┤{linje1}│");
            Console.WriteLine($"{venstreMellemrum}└{højreStreg}┘");

            ConsoleKey tast = Console.ReadKey(true).Key;
            switch (tast)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    valgtIndex = 0;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    valgtIndex = 1;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.E:
                    return valgtIndex == 0;
                case ConsoleKey.Escape:
                    return false;
            }
        }
    }
}
