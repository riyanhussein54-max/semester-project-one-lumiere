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
}
