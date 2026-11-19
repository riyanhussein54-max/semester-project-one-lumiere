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
            │ I _________________________________ Åben rygsæk │
            │ M ________________________________ Åben minimap │
            │ O _________________________________ Vis opgaver │
            │ Q ______________________________ Forlad spillet │
            ├─────────────────────────────────────────────────┤
            │ Tryk på en valgfri knap for at fortsætte...     │
            └─────────────────────────────────────────────────┘
            """
        );
    }

    /// <summary>
    /// Viser spillerens inventory/rygsæks indhold ved at trykke på I-knappen.
    /// Tjek "VisIndhold()" funktionen i Player/Rygsæk.cs for mere info.
    /// </summary>
    public static void VisRygsækMenu(Spiller s)
    {
        Console.Clear();
        Console.WriteLine(
            $"""
            ┌──────────────────── [Rygsæk] ────────────────────┐
            """
        );

        s.KiglRygsæk();

        Console.WriteLine(
            $"""
            ├──────────────────────────────────────────────────┤
            │ Tryk på en valgfri knap for at fortsætte...      │
            └──────────────────────────────────────────────────┘
            """
        );
    }

    /// <summary>
    /// TODO: Overvej at forbedre strukturen?
    /// </summary>
    public static void VisNPCDialogMenu(string npcNavn, Replik[] replikker)
    {
        for (int i = 0; i < replikker.Length; i++)
        {
            Console.Clear();
            Replik replik = replikker[i];
            (string linje1, string linje2, string linje3) = HentFølelsePortræt(replik.Følelse);

            // Bygger top-linjen
            // Sørger også for at vi har en dynamisk tæller (1/2)
            string tæller = $"({i + 1}/{replikker.Length})";
            int topStregLængde = 52 - tæller.Length - 4; // 52 er bredden på højre boks
            string topStreg = new string('─', topStregLængde);

            // Gør at NPC-navnet står centralt
            int venstrePad = (13 - npcNavn.Length) / 2;
            string centreretNavn = npcNavn.PadLeft(venstrePad + npcNavn.Length).PadRight(13);

            string knapTekst = (i == replikker.Length - 1)
                ? "[Enter] Afslut"
                : "[Enter] Næste";

            Console.WriteLine($"┌─────────────┬{topStreg} {tæller} ──┐");
            Console.WriteLine($"│{linje1}│                                                    │");
            Console.WriteLine($"│{linje2}│                                                    │");
            Console.WriteLine($"│{linje3}│                                                    │");
            Console.WriteLine($"├─────────────┤                                                    │");
            Console.WriteLine($"│{centreretNavn}│ {knapTekst,50} │");
            Console.WriteLine($"└─────────────┴────────────────────────────────────────────────────┘");

            // Her opdeller vi replikken i linjer på maks 48 tegn (52 - 4) og skriver dem inde i boksen med TypeWriter
            List<string> tekstLinjer = OpdelTekstILinjer(replik.Tekst, maxBredde: 48);

            for (int linjeIndex = 0; linjeIndex < tekstLinjer.Count; linjeIndex++)
            {
                // X = 16 (lige efter portræt-væggen)
                // Y = 2 + linjeIndex8
                Console.SetCursorPosition(16, 2 + linjeIndex);

                string prefix = (linjeIndex == 0) ? "\"" : " ";
                string suffix = (linjeIndex == tekstLinjer.Count - 1)
                    ? "\""
                    : "";

                TypeWriter.PrintLine($"{prefix}{tekstLinjer[linjeIndex]}{suffix}");
            }

            // Flytter cursoren ned under boksen og vent på Enter
            Console.SetCursorPosition(0, 8);
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }

    private static (string, string, string) HentFølelsePortræt(Følelse følelse)
    {
        return følelse switch
        {
            Følelse.Glad => (
                "   ^     ^   ",
                "   o     o   ",
                "   └─────┘   "
            ),
            Følelse.Neutral => (
                "             ",
                "   o     o   ",
                "    ─────    "
            ),
            Følelse.KedAfDet => (
                "   ,     ,   ",
                "   o     o   ",
                "   ┌─────┐   "
            ),
            Følelse.Tåre => (
                "   ,     ,   ",
                "   o,   ,o   ",
                "    ─────    "
            ),
            Følelse.Græder => (
                "   ,     ,   ",
                "   >,   ,<   ",
                "   ┌─────┐   "
            ),
            Følelse.Sur => (
                @"   \     /   ",
                "   o     o   ",
                "    ─────    "
            ),
            Følelse.MegetSur => (
                @"   \     /   ",
                "   o     o   ",
                "   ┌─────┐   "
            ),
            Følelse.Overrasket => (
                "   ^     ^   ",
                "   O     O   ",
                "    ┌───┐    "
            ),
            Følelse.Træt => (
                "             ",
                "   —     —   ",
                "    ─────    "
            ),
            _ => (
                "             ",
                "   o     o   ",
                "    ─────    "
            )
        };
    }

    /// <summary>
    /// Bryder automatisk en lang replik op i flere linjer ved mellemrum, så den ikke går gennem højre kant.
    /// </summary>
    private static List<string> OpdelTekstILinjer(string tekst, int maxBredde)
    {
        List<string> linjer = new();
        string[] ord = tekst.Split(' ');
        string nuværendeLinje = "";

        for (int i = 0; i < ord.Length; i++)
        {
            string etOrd = ord[i];
            if ((nuværendeLinje + etOrd).Length > maxBredde)
            {
                linjer.Add(nuværendeLinje.TrimEnd());
                nuværendeLinje = "";
            }
            nuværendeLinje += etOrd + " ";
        }

        if (!string.IsNullOrWhiteSpace(nuværendeLinje))
        {
            linjer.Add(nuværendeLinje.TrimEnd());
        }

        return linjer;
    }

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
            for (int j = 0; j < søjler; j++)
            {
                string rum = kortLayout[i, j];

                if (rum != "")
                {
                    Console.Write("│ ");
                    if (rum == spilStyrer.NuværendeLokation.Navn)
                    {
                        Color.Write(rum.PadRight(9), ConsoleColor.Red);
                    }
                    else
                    {
                        Color.Write(rum.PadRight(9), ConsoleColor.White);
                    }
                    Console.Write(" │");
                }
                else
                {
                    Console.Write("             ");
                }

                bool harRumTilHøjre = j + 1 < søjler && rum != "" && kortLayout[i, j + 1] != "";
                if (j < søjler - 1)
                    Console.Write(harRumTilHøjre ? "──" : "  ");
            }
            Console.WriteLine();
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
            if (i < rækker - 1)
            {
                for (int j = 0; j < søjler; j++)
                {
                    bool harRumUnder = kortLayout[i, j] != "" && kortLayout[i + 1, j] != "";
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
    public static void VisOpgaveMenu()
    {
        Console.Clear();
        Console.WriteLine(
            """
            ┌──────────────────── [Opgaver] ──────────────────┐
            │                                                 │
            │                   DINE OPGAVER                  │
            │   Her vises dine aktuelle opgaver.              │
            │                                                 │
            ├─────────────────────────────────────────────────┤
            │ Tryk på en valgfri knap for at fortsætte...     │
            └─────────────────────────────────────────────────┘
            """
        );
        // Tjek hvis spillestyren har en aktiv opgave
        // Hvis ikke så print "du har ikke nogen nuværende opgaver."
    }

}
