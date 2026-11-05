class SkærmTegner
{
    private static readonly int _bredde = 7, _længde = 11;
    private static readonly int _playerX = 2, _playerY = 4;
    private static readonly int[,] _gitter = new int[_bredde, _længde];

    /// <summary>
    /// Opdaterer og tegner hele spilskærmen baseret på spillets aktuelle tilstand
    /// </summary>
    public static void TegnSkærm(int lysforurening, Lokation nuværendeLokation, string opgaveNavn = "Ingen")
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

        TegnKoordinatSystem(_gitter);
    }

    private static void TegnKoordinatSystem(int[,] gitterRamme)
    {
        for (int række = 0; række < gitterRamme.GetLength(0); række++)
        {
            Console.Write($"| ·");
            for (int søjle = 0; søjle < gitterRamme.GetLength(1); søjle++)
            {
                // TODO: Her skal spiller-position kobles på i stedet for faste koordinater
                if (række == 3 && søjle == 7)
                {
                    Console.Write($" S");
                    continue;
                }
                Console.Write($" ·");
            }
            Console.WriteLine();
        }
    }
}
