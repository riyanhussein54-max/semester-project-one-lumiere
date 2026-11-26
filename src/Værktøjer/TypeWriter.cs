/// <summary>
/// TypeWriter-klassen udskriver tekst et tegn ad gangen med forsinkelse for at skabe en skrivemaskineeffekt i konsollen.
/// </summary>
public static class TypeWriter
{
    public static int Hastighed { get; set; } = 30;

    public static bool PrintLine(string tekst, bool kanSkippes = true)
    {
        bool blevSkippet = PrintBogstaver(tekst, kanSkippes);
        Console.Write("\n");
        return blevSkippet;
    }

    public static bool Print(string tekst, bool kanSkippes = true)
    {
        return PrintBogstaver(tekst, kanSkippes);
    }

    private static bool PrintBogstaver(string tekst, bool kanSkippes)
    {
        char[] bogstaver = tekst.ToCharArray();
        bool skipResten = false;
        for (int i = 0; i < bogstaver.Length; i++)
        {
            if (kanSkippes && !skipResten && Console.KeyAvailable)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    skipResten = true;
                }
            }

            Console.Write(tekst[i]);

            if (!skipResten)
            {
                Thread.Sleep(Hastighed);
            }
        }

        return skipResten;
    }
}
