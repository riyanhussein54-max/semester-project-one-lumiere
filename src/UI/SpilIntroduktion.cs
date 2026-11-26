public class SpilIntroduktion
{
    // NOTE: Eventuelt udskriv brugerens navn når vi skriver "Held og lykke".
    public static void UdskrivIntro()
    {
        string[] introLinjer =
        [
            "Velkommen til Lumiére.",
            "En by hvor lyset aldrig slukker.",
            "Dette har fysiske og mentale konsekvenser for de lokale.",
            "Du er den eneste der kan redde byen.",
            "Held og lykke."
        ];

        int pauseMellemLinjerMs = 1800;

        for (int i = 0; i < introLinjer.Length; i++)
        {
            string linje = introLinjer[i];
            Console.Clear();
            bool blevSkippet = TypeWriter.Print(linje);

            if (!blevSkippet)
            {
                Thread.Sleep(pauseMellemLinjerMs);
            }
        }
    }
}
