public static class MenuTegner
{
    public static void VisKommandoMenu()
    {
        Console.Clear();
        Console.WriteLine(
            $"""
            ┌──────────────────── [Hjælp] ────────────────────┐
            │ WASD, Piletaster ______________ Bevæg spilleren │
            │ E, Enter ____________________ Interager med NPC │
            │ M ________________________________ Åben minimap │
            │ I _________________________________ Åben rygsæk │
            │ O ________________________________ Åben opgaver │
            │ H _____________________________ Åben hjælpemenu │
            │ R _____________________________ Skjul hjælpebar │
            │ Q, Esc _________________________ Forlad spillet │
            ├─────────────────────────────────────────────────┤
            │ Tryk på en valgfri knap for at fortsætte...     │
            └─────────────────────────────────────────────────┘
            """
        );
    }

    /// <summary>
    /// Viser spillerens inventory/rygsæks indhold ved at trykke på I-knappen.
    /// </summary>
    public static void VisRygsækMenu(Spiller spiller)
    {
        Console.Clear();
        IReadOnlyList<Genstand> genstande = spiller.HentRygsækIndhold();

        Console.WriteLine("┌──────────────────── [Rygsæk] ────────────────────┐");

        if (genstande.Count > 0)
        {
            Console.WriteLine("│ Genstande ______________________________________ │");
            for (int i = 0; i < genstande.Count; i++)
            {
                Genstand genstand = genstande[i];
                Console.WriteLine(FormaterRygsækLinje(genstand));
            }
        }
        else
        {
            Console.WriteLine("│                Rygsækken er tom.                 │");
        }

        Console.WriteLine("├──────────────────────────────────────────────────┤");
        Console.WriteLine("│ Tryk på en valgfri knap for at fortsætte...      │");
        Console.WriteLine("└──────────────────────────────────────────────────┘");
    }

    private static string FormaterRygsækLinje(Genstand genstand)
    {
        int indreBredde = 48;
        int antalPrikker = Math.Max(2, indreBredde - genstand.Navn.Length - genstand.Beskrivelse.Length - 2);
        string prikker = new string('.', antalPrikker);

        return $"│ {genstand.Navn} {prikker} {genstand.Beskrivelse} │";
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
                TypeWriter.PrintLine($"{tekstLinjer[linjeIndex]}");
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

    public static void VisKortMenu(SpilStyrer spilStyrer, Verden verden)
    {
        Console.Clear();
        LokationType?[,] kortLayout =
        {
            { null,                 null,                      null,                        LokationType.Kontor,     null,                    null },
            { null,                 null,                      LokationType.Elgiganten,     LokationType.NørreGade,  LokationType.ZehrasHjem, null },
            { null,                 LokationType.LuciusHjem,   LokationType.VesterGade,     LokationType.Centrum,    LokationType.ØsterGade,  LokationType.HaraldNyborg },
            { null,                 null,                      LokationType.ParkingsPlads,  LokationType.SønderGade, LokationType.IvanasHjem, null },
            { null,                 null,                      null,                        LokationType.Park,       null,                    null },
        };

        int rækker = kortLayout.GetLength(0);
        int søjler = kortLayout.GetLength(1);
        const string tomBoks = "                 ";
        const ConsoleColor aktivFarve = ConsoleColor.Green;

        for (int i = 0; i < rækker; i++)
        {
            for (int j = 0; j < søjler; j++)
            {
                LokationType? type = kortLayout[i, j];
                if (type != null)
                {
                    bool erHer = type == spilStyrer.NuværendeLokation.Type;
                    bool erLåst = verden.HentLokation(type.Value).ErLåst;
                    ConsoleColor farve = erHer ? aktivFarve : erLåst ? ConsoleColor.DarkGray : ConsoleColor.White;
                    Color.Write("┌───────────────┐", farve);
                }
                else
                {
                    Console.Write(tomBoks);
                }

                if (j < søjler - 1)
                {
                    Console.Write("  ");
                }
            }
            Console.WriteLine();

            for (int j = 0; j < søjler; j++)
            {
                LokationType? type = kortLayout[i, j];

                if (type != null)
                {
                    Lokation lok = verden.HentLokation(type.Value);
                    string visningsNavn = FormaterLokationsNavn(type.Value);
                    bool erHer = type == spilStyrer.NuværendeLokation.Type;
                    bool erLåst = lok.ErLåst;
                    ConsoleColor farve = erHer ? aktivFarve : erLåst ? ConsoleColor.DarkGray : ConsoleColor.White;
                    Color.Write($"│ {visningsNavn.PadRight(13)} │", farve);

                    if (j < søjler - 1)
                    {
                        bool harØstUdgang = lok.HentUdgang(Retning.Øst) != null;
                        Console.Write(harØstUdgang ? "──" : "  ");
                    }
                }
                else
                {
                    Console.Write(tomBoks);
                    if (j < søjler - 1)
                    {
                        Console.Write("  ");
                    }
                }
            }
            Console.WriteLine();

            for (int j = 0; j < søjler; j++)
            {
                LokationType? type = kortLayout[i, j];
                if (type != null)
                {
                    bool erHer = type == spilStyrer.NuværendeLokation.Type;
                    bool erLåst = verden.HentLokation(type.Value).ErLåst;
                    ConsoleColor farve = erHer ? aktivFarve : erLåst ? ConsoleColor.DarkGray : ConsoleColor.White;
                    Color.Write("└───────────────┘", farve);
                }
                else
                {
                    Console.Write(tomBoks);
                }

                if (j < søjler - 1)
                {
                    Console.Write("  ");
                }
            }
            Console.WriteLine();

            if (i < rækker - 1)
            {
                for (int j = 0; j < søjler; j++)
                {
                    LokationType? type = kortLayout[i, j];
                    bool harSydUdgang = type != null && verden.HentLokation(type.Value).HentUdgang(Retning.Syd) != null;

                    Console.Write(harSydUdgang ? "        │        " : tomBoks);
                    if (j < søjler - 1)
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }

        Console.Write("\nDu er her: ");
        Color.WriteLine($"■ {FormaterLokationsNavn(spilStyrer.NuværendeLokation.Type)}", aktivFarve);
        Console.WriteLine("Tryk på en valgfri tast for at vende tilbage...");
    }

    private static string FormaterLokationsNavn(LokationType type) => type switch
    {
        LokationType.NørreGade => "Nørregade",
        LokationType.VesterGade => "Vestergade",
        LokationType.ØsterGade => "Østergade",
        LokationType.SønderGade => "Søndergade",
        LokationType.ZehrasHjem => "Zehras Hjem",
        LokationType.LuciusHjem => "Lucius Hjem",
        LokationType.IvanasHjem => "Ivanas Hjem",
        LokationType.ParkingsPlads => "P-plads",
        LokationType.HaraldNyborg => "Harald Nyborg",
        _ => type.ToString()
    };

    public static void VisOpgaveMenu(SpilStyrer spilStyrer)
    {
        Console.Clear();
        if (spilStyrer.NuværendeOpgave == null)
        {
            Console.WriteLine(
                """
                ┌──────────────────── [Opgaver] ──────────────────┐
                │                                                 │
                │                   DINE OPGAVER                  │
                │            Ingen aktuelle opgaver.              │
                │                                                 │
                ├─────────────────────────────────────────────────┤
                │ Tryk på en valgfri knap for at fortsætte...     │
                └─────────────────────────────────────────────────┘
                """
            );
        }
        if (spilStyrer.NuværendeOpgave != null)
        {
            Console.WriteLine(
               $"""
                ┌──────────────────── [Opgaver] ──────────────────┐
                │                                                 │
                │                   DINE OPGAVER                  │
                │     {spilStyrer.NuværendeOpgave.Beskrivelse}    │
                │                                                 │
                ├─────────────────────────────────────────────────┤
                │ Tryk på en valgfri knap for at fortsætte...     │
                └─────────────────────────────────────────────────┘
                """
            );
        }


        // Tjek hvis spillestyren har en aktiv opgave
        // Hvis ikke så print "du har ikke nogen nuværende opgaver."
    }
}
