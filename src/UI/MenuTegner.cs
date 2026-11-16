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

    //public static void VisRygsækMenu() => throw new NotImplementedException();
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

    public static void VisNPCDialogMenu() => throw new NotImplementedException();
    public static void VisOpgaveMenu() => throw new NotImplementedException();
    public static void VisKortMenu() => throw new NotImplementedException();
}
