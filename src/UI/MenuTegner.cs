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
    public static void VisKortMenu() => throw new NotImplementedException();
}

{
    Console.Clear();
    Console.WriteLine(
        """
        ┌──────────────────── [Opgaver] ──────────────────┐
        │                                                 │
        │                   DINE OPGAVER                  │
        │                                                 │
        │    [] Find genstande i byen                     │
        │    [] Tal med NPC'er                            │
        │    [] Hjælp NPC'er med deres opgaver            │
        ├─────────────────────────────────────────────────┤
        │ Tryk på en valgfri knap for at fortsætte...     │
        └─────────────────────────────────────────────────┘
        """
    );
    Console.RedKey(true);

    )
}
