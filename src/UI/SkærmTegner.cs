/// <summary>
/// Håndterer tegning af spillets brugerflade, herunder informationer og koordinatsystem.
/// </summary>
public class SkærmTegner
{
    private static readonly int _bredde = 7, _længde = 11;
    private static readonly int[,] _gitter = new int[_bredde, _længde];

    /// <summary>
    /// Opdaterer og tegner hele spilskærmen baseret på spillets aktuelle tilstand
    /// </summary>
    public static void TegnSkærm(int lysforurening, Lokation nuværendeLokation, SpilStyrer spilStyrer, string opgaveNavn = "Ingen", int spillerRække = 2, int spillerSøjle = 2 )
    {
        Console.Clear();

        switch (BrugerOpretter.Brugertilstand)
        {
            case Brugertilstand.Dev:
                Console.Write("–––––––––––––––––––– [");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Info");
                Console.ResetColor();
                Console.WriteLine("] ––––––––––––––––––––");
                break;
            case Brugertilstand.Spiller:
                Console.WriteLine("–––––––––––––––––––– [Info] ––––––––––––––––––––");
                break;
        }

        Console.WriteLine(
            $"""
            | Lysforurening:      {lysforurening,-18} |
            | Lokation:           {nuværendeLokation.Navn,-18} |
            | Opgave:             {opgaveNavn,-18} |
            ––––––––––––––––––––––––––––––––––––––––––––––––
            """
        );

        TegnKoordinatSystem(nuværendeLokation.Gitter, spillerRække, spillerSøjle,spilStyrer);
    }

    private static void TegnKoordinatSystem(FeltType[,] gitterRamme, SpilStyrer spillerRække, int spillerSøjle)
    {
        for (int række = 0; række < gitterRamme.GetLength(0); række++)
        {
            Console.Write("|");
            for (int søjle = 0; søjle < gitterRamme.GetLength(1); søjle++)
            {
                // Her tegner spilleren øverst
                // In case hvis spilleren står på dette koordinat
                // TODO: Burde måske lave noget kollisiontjek, så man ikke kan gå på en NPC
                if (række == spillerRække && søjle == spillerSøjle)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" S");
                    Console.ResetColor();
                    continue;
                }

                switch (gitterRamme[række, søjle])
                {
                    case FeltType.Dør:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" ▀");
                        Console.ResetColor();
                        break;
                    case FeltType.Genstand:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" ♦");
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
            Console.WriteLine(" |");
        }
    }
}
