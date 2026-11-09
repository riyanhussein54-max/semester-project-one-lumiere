/// <summary>
/// Her starter vi spillet!
/// </summary>
public class Program
{
    private static Verden _verden = new Verden();
    private static SpilStyrer _spilStyrer = new SpilStyrer(_verden.StartLokation);

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

        SkærmTegner.TegnSkærm(_spilStyrer.Lysforurening, _spilStyrer.NuværendeLokation, _spilStyrer, "");
        // SkærmTegner.TegnSkærm(_spilStyrer.Lysforurening,_spilStyrer.NuværendeLokation);

        KørSpil();
        AfslutSpil();
    }

    private static void KørSpil()
    {
        while (_spilStyrer.TjekStatus() == SpilStatus.Aktiv)
        {
            Console.Write("\nBrug piletasterne til at bevæge dig, H for hjælpemenu eller Esc for at afslutte: ");

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    _spilStyrer.BevægSpiller(Retning.Nord);
                    break;

                case ConsoleKey.DownArrow:
                    _spilStyrer.BevægSpiller(Retning.Syd);
                    break;

                case ConsoleKey.RightArrow:
                    _spilStyrer.BevægSpiller(Retning.Øst);
                    break;

                case ConsoleKey.LeftArrow:
                    _spilStyrer.BevægSpiller(Retning.Vest);
                    break;

                case ConsoleKey.Escape:
                    _spilStyrer.AfslutSpil();
                    break;

                case ConsoleKey.H:
                    UdskrivKommandoer();
                    Console.WriteLine("\nTryk på en vilkårlig tast for at fortsætte...");
                    Console.ReadKey(true);
                    break;

                default:
                    Console.WriteLine("Ukendt tast");
                    break;
            }

            if (_spilStyrer.TjekStatus() == SpilStatus.Aktiv)
            {
                Console.Clear();

                SkærmTegner.TegnSkærm(
                    _spilStyrer.Lysforurening,
                    _spilStyrer.NuværendeLokation,
                    _spilStyrer
                );
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
            - esc, quit, exit    Forlad spil
            - to                 Følg en udgang
            - h, help            Vis hjælpemenu
            """
        );
    }
}
