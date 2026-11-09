/// <summary>
/// SpilStyren holder styr på spillets kontekst og andet relavant info.
/// Derudover har den også styr på spillets flow, regler og tilstand.
/// </summary>
public class SpilStyrer
{
    public SpilStatus status = SpilStatus.Aktiv;

    public SpilStyrer(Lokation startLokation, Spiller spiller)
    {
        NuværendeLokation = startLokation;
        Spiller = spiller;

        SætSpillerStartPosition(startLokation);
    }

    private void SætSpillerStartPosition(Lokation startLokation)
    {
        int startRække = startLokation.Gitter.GetLength(0) / 2;
        int startSøjle = startLokation.Gitter.GetLength(1) / 2;
        Spiller.SætPosition(startRække, startSøjle);
    }

    public int Lysforurening { get; private set; } = 100;
    public Lokation NuværendeLokation { get; private set; }
    public Spiller Spiller { get; private set; }

    // TODO: Implementer nedenstående så snart det er muligt
    // public Lokation NuværendeOpgave { get; private set; }

    public void BevægSpiller(Retning retning)
    {
        (int nyRække, int nySøjle) = Spiller.BeregnNæstePosition(retning);

        if (!ErIndenForGitter(nyRække, nySøjle))
        {
            return;
        }

        if (TjekOgUdførDørSkift(nyRække, nySøjle, out (int Række, int Søjle) nyDørPosition))
        {
            Spiller.SætPosition(nyDørPosition.Række, nyDørPosition.Søjle);
            return;
        }

        Spiller.SætPosition(nyRække, nySøjle);
    }

    public bool ErIndenForGitter(int række, int søjle)
    {
        int maxRækker = NuværendeLokation.Gitter.GetLength(0);
        int maxSøjler = NuværendeLokation.Gitter.GetLength(1);

        return række >= 0 && række < maxRækker &&
               søjle >= 0 && søjle < maxSøjler;
    }

    private bool TjekOgUdførDørSkift(int række, int søjle, out (int Række, int Søjle) nySpillerPosition)
    {
        nySpillerPosition = (række, søjle);

        if (NuværendeLokation.Gitter[række, søjle] != FeltType.Dør)
        {
            return false;
        }

        Lokation? næste = NuværendeLokation.HentUdgangFraKoordinat(række, søjle);
        if (næste == null)
        {
            return false;
        }

        nySpillerPosition = næste.HentDørKoordinatTil(NuværendeLokation);
        NuværendeLokation = næste;
        return true;
    }

    public bool ErSpillerPå(int række, int søjle)
    {
        return Spiller.Række == række && Spiller.Søjle == søjle;
    }

    public void AfslutSpil() => status = SpilStatus.Slut;
    public SpilStatus TjekStatus() => status;
}
