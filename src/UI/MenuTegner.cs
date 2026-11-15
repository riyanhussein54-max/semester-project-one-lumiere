public static class MenuTegner
{
    public static void VisKommandoMenu()
    {
        Console.Clear();
        Console.WriteLine(
            $"""
            ┌──────────────────── [Hjælp] ────────────────────┐
            │ WASD, Piletaster ______________ Bevæg spilleren │
            │ H ______________________________ Vis hjælpemenu │
            │ R __________________________________ Skjul Menu │
            │ Q ______________________________ Forlad spillet │
            ├─────────────────────────────────────────────────┤
            │ Tryk på en valgfri knap for at fortsætte...     │
            └─────────────────────────────────────────────────┘
            """
        );
    }

    public static void VisRygsækMenu() => throw new NotImplementedException();
    public static void VisNPCDialogMenu() => throw new NotImplementedException();
    public static void VisOpgaveMenu() => throw new NotImplementedException();
    public static void VisKortMenu(SpilStyrer spilStyrer)
    {
        Console.Clear();
        Console.WriteLine("[minimap]");
        Console.WriteLine("Din nuværende lokation: " + spilStyrer.NuværendeLokation.Navn);
        Console.WriteLine("--------------------");

        string[,] kortLayout =
        {
            { "",        "BobsHus", "GadeN",   "" },
            { "",        "",        "Park",    "Bytorv" },
            { "",        "Station", "GadeV",   "GadeØ" },
            { "",        "",        "Hjem",    "Nabo" }
        };

        int rækker = kortLayout.GetLength(0);
        int søjler = kortLayout.GetLength(1);

        for (int i = 0; i < rækker; i++)
        {
            // Top borders
            for (int j = 0; j < søjler; j++)
            {
                string rum = kortLayout[i, j];

                if (rum != "")
                    Console.Write("┌───────────┐");
                else
                    Console.Write("             ");

                if (j < søjler - 1)
                    Console.Write("  ");
            }

            Console.WriteLine();

            // Room names and horizontal connections
            for (int j = 0; j < søjler; j++)
            {
                string rum = kortLayout[i, j];

                if (rum != "")
                    Console.Write($"│ {rum,-9} │");
                else
                    Console.Write("             ");

                bool harRumTilHøjre =
                    j + 1 < søjler &&
                    rum != "" &&
                    kortLayout[i, j + 1] != "";

                if (j < søjler - 1)
                    Console.Write(harRumTilHøjre ? "──" : "  ");
            }

            Console.WriteLine();

            // Bottom borders
            for (int j = 0; j < søjler; j++)
            {
                string rum = kortLayout[i, j];

                if (rum != "")
                    Console.Write("└───────────┘");
                else
                    Console.Write("             ");

                if (j < søjler - 1)
                    Console.Write("  ");
            }

            Console.WriteLine();

            // Vertical connections
            if (i < rækker - 1)
            {
                for (int j = 0; j < søjler; j++)
                {
                    bool harRumUnder =
                        kortLayout[i, j] != "" &&
                        kortLayout[i + 1, j] != "";

                    Console.Write("      ");
                    Console.Write(harRumUnder ? "│" : " ");
                    Console.Write("      ");

                    if (j < søjler - 1)
                        Console.Write("  ");
                }

                Console.WriteLine();
            }
        }
    }
}
