/// <summary>
/// Her starter vi spillet!
/// </summary>
public class Program
{
    private static Verden _world = new Verden();
    private static SpilStyrer _spilStyrer = new SpilStyrer(_world.GetEntry());

    /// <summary>
    /// 1. Spørger brugeren om de er en Spiller eller Dev
    /// 2. Hvis Spiller vælges –> afspil introduktion
    ///    Hvis Dev vælges –> ignorer introduktion
    /// 3. Tegn og print skærm
    /// 4. Game loopet køres
    /// 5. Spil afsluttes
    /// </summary>
    static void Main(string[] args)
    {
        Console.Clear();
        BrugerOpretter.VælgAdgangsniveau();

        if (BrugerOpretter.Brugertilstand == Brugertilstand.Spiller)
            SpilIntroduktion.UdskrivIntro();

        SkærmTegner.TegnSkærm(
            _spilStyrer.Lysforurening,
            _spilStyrer.NuværendeLokation
        );
        KørSpil();
        AfslutSpil();
    }

    [Obsolete("Dette skal udskiftes med et nyt Movement system!")]
    private static void KørSpil()
    {
        while (_spilStyrer.TjekStatus() == SpilStatus.Aktiv)
        {
            Console.Write("\n> ");
            string? line = Console.ReadLine();

            if (line == null)
                continue;

            // parse line
            string[] elementer = line.Split(" ");
            string kommando = elementer[0];
            string[] parametre = HentParametre(elementer);

            switch (kommando)
            {
                case "to":
                    if (parametre.Length != 1)
                    {
                        Console.WriteLine("Jeg kan ikke helt finde ud af hvor det er for et sted");
                        return;
                    }
                    _spilStyrer.Transition(parametre[0]);
                    break;
                case "h":
                case "help":
                    UdskrivKommandoer();
                    Console.WriteLine("\nTryk på en vilkårlig tast for at fortsætte...");
                    Console.ReadKey(true);
                    break;
                case "q":
                case "quit":
                case "exit":
                    _spilStyrer.AfslutSpil();
                    break;
                default:
                    Console.WriteLine($"Ups, jeg forstår ikke kommandoen '{kommando}'");
                    break;
            }
        }
    }

    private static void AfslutSpil()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Spillet er slut.");
        Console.ResetColor();
    }
    private static void UdskrivKommandoer()
    {
        Console.WriteLine(
            $"""
            Muligheder:
            - q, quit, exit    Forlad spil
            - to               Følg en udgang
            - h, help          Vis hjælpemenu
            """
        );
    }

    private static string[] HentParametre(string[] input)
    {
        string[] output = new string[input.Length - 1];
        for (int i = 0; i < output.Length; i++)
        {
            output[i] = input[i + 1];
        }
        return output;
    }
}
