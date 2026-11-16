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
    public static void VisOpgaveMenu() => throw new NotImplementedException();
    public static void VisKortMenu() => throw new NotImplementedException();
}
