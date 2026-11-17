/// <summary>
/// TypeWriter-klassen udskriver tekst et tegn ad gangen med forsinkelse for at skabe en skrivemaskineeffekt i konsollen.
/// </summary>
public static class TypeWriter
{
    public static int Speed { get; set; } = 30;

    public static void PrintLine(string text)
    {
        PrintBogstaver(text);
        Console.Write("\n");
    }

    public static void Print(string text)
    {
        PrintBogstaver(text);
    }

    private static void PrintBogstaver(string text)
    {
        char[] Letter = text.ToCharArray();
        for (int i = 0; i < Letter.Length; i++)
        {
            Console.Write(Letter[i]);
            Thread.Sleep(Speed);
        }
    }
}
