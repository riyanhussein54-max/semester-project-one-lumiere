class SkærmTegner
{
    private static readonly int[,] _gitter = new int[7, 11];

    /// <summary>
    /// Opdaterer og tegner hele spilskærmen baseret på spillets aktuelle tilstand
    /// </summary>
    public static void TegnSkærm(int lysforurening, Lokation nuværendeLokation, string opgaveNavn = "Ingen")
    {
        Console.Clear();
        Console.WriteLine(
            $"""
            –––––––––––––––––––– [Info] ––––––––––––––––––––
            | Lysforurening:      {lysforurening,-18} |
            | Lokation:           {nuværendeLokation.GetName(),-18} |
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
