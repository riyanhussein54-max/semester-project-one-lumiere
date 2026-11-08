/// <summary>
/// SpilStyren holder styr på spillets kontekst og andet relavant info.
/// Derudover har den også styr på spillets flow, regler og tilstand.
/// </summary>
class SpilStyrer
{
    public SpilStatus status = SpilStatus.Aktiv;

    public SpilStyrer(Lokation node)
    {
        NuværendeLokation = node;
    }

    public int Lysforurening { get; private set; } = 100;
    public Lokation NuværendeLokation { get; private set; }

    // TODO: Implementer nedenstående så snart det er muligt
    // public Lokation NuværendeOpgave { get; private set; }
    // public int[,] SpillerLokation { get; private set; }

    /// <summary>
    /// Skifter direkte til en ny lokation ud fra en retning
    /// </summary>
    public bool SkiftLokation(Retning retning)
    {
        Lokation? næste = NuværendeLokation.HentUdgang(retning);
        if (næste == null)
            return false;

        NuværendeLokation = næste;
        return true;
    }

    /// <summary>
    /// Tjekker om et koordinat er inden for den nuværende lokations gitter.
    /// AKA Bounds-checking.
    /// Kan være at vi skal lave det på en anden måde ift Bevægelse
    /// </summary>
    public bool ErIndenForGitter(int række, int søjle)
    {
        int maxRækker = NuværendeLokation.Gitter.GetLength(0);
        int maxSøjler = NuværendeLokation.Gitter.GetLength(1);

        return række >= 0 && række < maxRækker &&
               søjle >= 0 && søjle < maxSøjler;
    }

    /// <summary>
    /// Kaldes når spilleren træder på et nyt felt.
    /// Hvis feltet er en dør, så skiftes lokation.
    /// TODO: Vi skal respawne spilleren, så den får en ny position
    /// </summary>
    public bool TjekOgUdførDørSkift(int række, int søjle, out (int Række, int Søjle) nySpillerPosition)
    {
        nySpillerPosition = (række, søjle);

        if (!ErIndenForGitter(række, søjle) || NuværendeLokation.Gitter[række, søjle] != FeltType.Dør)
            return false;

        Lokation? næste = NuværendeLokation.HentUdgangFraKoordinat(række, søjle);
        if (næste == null)
            return false;

        // Finder døren i det nye rum der fører tilbage til det rum vi kom fra
        nySpillerPosition = næste.HentDørKoordinatTil(NuværendeLokation);
        NuværendeLokation = næste;
        return true;
    }

    public void AfslutSpil() => status = SpilStatus.Slut;
    public SpilStatus TjekStatus() => status;
}
