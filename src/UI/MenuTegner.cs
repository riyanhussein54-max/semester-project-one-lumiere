public static class MenuTegner
{
    public static void VisKommandoMenu()
    {
        Console.Clear();
        Console.WriteLine(
            $"""

            - WASD, Piletaster       Bevæg spilleren
            - H                      Vis hjælpemenu
            - R                      Skjul Menu
            - Q                      Forlad spil

            Tryk på en knap for at fortsætte...
            """
        );
    }

    public static void VisRygsækMenu() => throw new NotImplementedException();
    public static void VisOpgaveMenu() => throw new NotImplementedException();
    public static void VisKortMenu() => throw new NotImplementedException();
}
