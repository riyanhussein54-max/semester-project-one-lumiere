public static class AfslutSpilMenu
{
    private static readonly string[] muligheder =
    [
        "Ja",
        "Nej"
    ];
    private static int valgteMulighed = 0;
    public static bool BekræftAfslut()
    {
        bool færdig = false;

        Console.Clear();
        Console.WriteLine("Vil du afslutte spillet?");
        Console.CursorVisible = false;
        while (færdig is false)
        {
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < muligheder.Length; i++)
            {
                if (i == valgteMulighed)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($" > [{muligheder[i]}]");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write($" {muligheder[i]}");
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

        return valgteMulighed == 0;
    }
}
