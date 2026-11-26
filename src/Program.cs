/// <summary>
/// Her starter vi spillet!
/// </summary>
public class Program
{
    private static Verden _verden = new Verden();
    private static Spiller _spiller = new Spiller();
    private static SpilStyrer _spilStyrer = new SpilStyrer(_verden, _spiller);

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
        {
            SpilIntroduktion.UdskrivIntro();
        }

        SkærmTegner.TegnSkærm(_spilStyrer);

        KørSpil();
        AfslutSpil();
    }

    private static void KørSpil()
    {
        while (_spilStyrer.TjekStatus() == SpilStatus.Aktiv)
        {
            ConsoleKey tast = Console.ReadKey(true).Key;

            switch (tast)
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            switch (key)
            {
                case ConsoleKey.E:
                case ConsoleKey.Enter:
                    NPC? npc = _spilStyrer.HentNærliggendeNPC();
                    if (npc?.Begivenhed != null)
                    {
                        Replik[] replikker = npc.Begivenhed.HentAktuelDialog(_spilStyrer);
                        MenuTegner.VisNPCDialogMenu(npc.Navn, replikker);
                        break;
                    }
                    Objekt? objekt = _spilStyrer.HentNærliggendeObjekt();
                    if (objekt != null && _spilStyrer.KanInteragereMedObjekt(objekt))
                    {
                        if (SkærmTegner.TegnObjektInteraktionBoks(objekt))
                        {
                            _spilStyrer.InteragerMedObjekt(objekt);
                        }
                    }
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    _spilStyrer.BevægSpiller(Retning.Nord);
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    _spilStyrer.BevægSpiller(Retning.Syd);
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    _spilStyrer.BevægSpiller(Retning.Øst);
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    _spilStyrer.BevægSpiller(Retning.Vest);
                    break;
                case ConsoleKey.R:
                    SkærmTegner.SkiftMenuSynlighed();
                    break;
                case ConsoleKey.H:
                    MenuTegner.VisKommandoMenu();
                    Console.ReadKey(true);
                    break;
                case ConsoleKey.I:
                    MenuTegner.VisRygsækMenu(_spiller);
                    Console.ReadKey(true);
                    break;
                case ConsoleKey.O:
                    MenuTegner.VisOpgaveMenu(_spilStyrer);
                    Console.ReadKey(true);
                    break;
                case ConsoleKey.Q:
                case ConsoleKey.Escape:
                    if (AfslutSpilMenu.BekræftAfslut())
                    {
                        _spilStyrer.SætSpilStatusTilSlut();
                    }
                    break;
                case ConsoleKey.M:
                    MenuTegner.VisKortMenu(_spilStyrer, _verden);
                    Console.ReadKey(true);
                    break;
                default:
                    Console.WriteLine("Ukendt tast");
                    break;
            }

            if (_spilStyrer.TjekStatus() == SpilStatus.Aktiv)
            {
                SkærmTegner.TegnSkærm(_spilStyrer);
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
}
