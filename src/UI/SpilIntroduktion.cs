public class SpilIntroduktion
{
    // NOTE: Eventuelt udskriv brugerens navn når vi skriver "Held og lykke".
    public static void UdskrivIntro()
    {
        Console.Clear();

        Thread.Sleep(500);

        TypeWriter.Print("Velkommen til Lumiére.");
        Thread.Sleep(2400);

        Console.Clear();
        TypeWriter.Print("En by hvor lyset aldrig slukker.");
        Thread.Sleep(2600);

        Console.Clear();
        TypeWriter.Print("Dette har fysiske og mentale konsekvenser for de lokale.");
        Thread.Sleep(3400);

        Console.Clear();
        TypeWriter.Print("Du er den eneste der kan redde byen.");
        Thread.Sleep(2400);

        Console.Clear();
        TypeWriter.Print("Held og lykke.");
        Thread.Sleep(2000);
    }
}
