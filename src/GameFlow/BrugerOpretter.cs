public class BrugerOpretter
{
    public static Brugertilstand Brugertilstand { get; private set; }
    private static readonly string[] muligheder =
    [
        "Spiller",
        "Dev"
    ];
    private static int valgteMulighed = 0;
    private static bool færdig = false;

    public static void VælgAdgangsniveau()
    {
        Console.WriteLine("Vælg brugertilstand:");
        Console.CursorVisible = false;

        while (færdig is false)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < muligheder.Length; i++)
            {
                if (i == valgteMulighed)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($" > [{muligheder[i]}] ");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write($"   {muligheder[i]}");
                }
                Console.ResetColor();
                Console.WriteLine(new string(' ', 10));
            }

            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    valgteMulighed = (valgteMulighed - 1 + muligheder.Length) % muligheder.Length;
                    break;
                case ConsoleKey.DownArrow:
                    valgteMulighed = (valgteMulighed + 1) % muligheder.Length;
                    break;
                case ConsoleKey.Enter:
                    færdig = true;
                    break;
            }
        }

        Console.CursorVisible = true;
        Console.ResetColor();
        Brugertilstand = (Brugertilstand)valgteMulighed;
    }
}
