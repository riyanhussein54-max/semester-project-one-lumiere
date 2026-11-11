public static class Color
{
    public static int Speed { get; set; } = 30;
    // skriver med farve linjeskift
    public static void WriteLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;

        foreach (char letter in text)
        {
            Console.Write(letter);
            Thread.Sleep(Speed);
        }
        Console.Write("\n");

        Console.ResetColor();
    }
    // skriver med farve uden linjeskift
    public static void Write(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;

        foreach (char letter in text)
        {
            Console.Write(letter);
            Thread.Sleep(Speed);
        }

        Console.ResetColor();
    }
}
