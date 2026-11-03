/// <summary>
/// SpilStyren holder styr på spillets kontekst og andet relavant info.
/// Derudover har den også styr på spillets flow, regler og tilstand.
/// </summary>
class SpilStyrer
{
    public SpilStatus status = SpilStatus.Aktiv;
    private readonly int[,] gitter = new int[7, 11];

    public SpilStyrer(Lokation node)
    {
        NuværendeLokation = node;
    }

    public int Lysforurening { get; private set; } = 100;
    public Lokation NuværendeLokation { get; private set; }
    // TODO: Implementer nedenstående så snart det er muligt
    // public Lokation NuværendeOpgave { get; private set; }
    // public int[,] SpillerLokation { get; private set; }

    #region Public APIs
    public void TegnSkærm()
    {
        Console.WriteLine(
            $"""
            –––––––––––––––––––– [Info] ––––––––––––––––––––
            | Lysforurening:  {Lysforurening}                   |
            | Lokation:       {NuværendeLokation.GetName()}                    |
            | Opgave:         Ingen                   |
            ––––––––––––––––––––––––––––––––––––––––––––––––
            """
        );
        TegnKoordinatSystem(gitter);
    }

    [Obsolete("String skal udskiftes med enum!")]
    public void Transition(string direction)
    {
        Lokation næsteLokation = NuværendeLokation.FollowEdge(direction);

        if (næsteLokation == null)
        {
            Console.WriteLine($"You are confused, and walk in a circle looking for '{direction}'. In the end you give up. 😩");
        }
        else
        {
            NuværendeLokation = næsteLokation;
            NuværendeLokation.Welcome();
        }
    }

    public void AfslutSpil() => status = SpilStatus.Slut;
    public SpilStatus TjekStatus() => status;
    #endregion

    #region Private Methods
    private void TegnKoordinatSystem(int[,] gitterRamme)
    {
        for (int række = 0; række < gitterRamme.GetLength(0); række++)
        {
            Console.Write($"| ·");
            for (int søjle = 0; søjle < gitterRamme.GetLength(1); søjle++)
            {
                // TEST: Denne if-block visualiser hvordan spillerens lokation vil se ud:
                if (række == 3 && søjle == 7)
                {
                    Console.Write($" S");
                    continue;
                }
                Console.Write($" ·");
            }
            Console.WriteLine();
        }
    }
    #endregion
}
