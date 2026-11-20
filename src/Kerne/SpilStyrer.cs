/// <summary>
/// SpilStyren holder styr på spillets kontekst og andet relavant info.
/// Derudover har den også styr på spillets flow, regler og tilstand.
/// </summary>
public class SpilStyrer
{
    public SpilStatus Status = SpilStatus.Aktiv;

    public SpilStyrer(Lokation startLokation, Spiller spiller)
    {
        NuværendeLokation = startLokation;
        Spiller = spiller;

        SætSpillerStartPosition(startLokation);
    }

    public int Lysforurening { get; private set; } = 100;
    public Lokation NuværendeLokation { get; private set; }
    public Spiller Spiller { get; private set; }
    public Opgave? NuværendeOpgave { get; private set; }
    public Genstand? SenestOpsamletGenstand { get; private set; }

    public void BevægSpiller(Retning retning)
    {
        SenestOpsamletGenstand = null;
        (int nyRække, int nySøjle) = Spiller.BeregnNæstePosition(retning);

        if (!ErIndenForGitter(nyRække, nySøjle))
        {
            return;
        }

        // Dette er vores kollision detectionm, hvis feltet er en NPC, så stopper vi op
        FeltType målFelt = NuværendeLokation.Gitter[nyRække, nySøjle];
        if (målFelt == FeltType.NPC || målFelt == FeltType.Væg)
        {
            return;
        }

        if (TjekOgUdførDørSkift(nyRække, nySøjle, out (int Række, int Søjle) nyDørPosition))
        {
            Spiller.SætPosition(nyDørPosition.Række, nyDørPosition.Søjle);
            return;
        }

        Spiller.SætPosition(nyRække, nySøjle);
        TjekSamlGenstand(nyRække, nySøjle);
    }

    public bool ErIndenForGitter(int række, int søjle)
    {
        int maxRækker = NuværendeLokation.Gitter.GetLength(0);
        int maxSøjler = NuværendeLokation.Gitter.GetLength(1);

        return række >= 0 && række < maxRækker && søjle >= 0 && søjle < maxSøjler;
    }

    public bool ErSpillerPå(int række, int søjle)
    {
        return Spiller.Række == række && Spiller.Søjle == søjle;
    }

    public NPC? HentNærliggendeNPC()
    {
        Retning[] retninger = [Retning.Nord, Retning.Syd, Retning.Øst, Retning.Vest];

        for (int i = 0; i < retninger.Length; i++)
        {
            Retning retning = retninger[i];
            (int tjekRække, int tjekSøjle) = Spiller.BeregnNæstePosition(retning);
            NPC? npc = NuværendeLokation.HentNPCFraKoordinat(tjekRække, tjekSøjle);

            if (npc != null)
            {
                return npc;
            }
        }

        return null;
    }

    public void SætSpilStatusTilSlut() => Status = SpilStatus.Slut;
    public SpilStatus TjekStatus() => Status;

    /// <summary>
    /// Tildeler spilleren en ny opgave KUN hvis der ikke allerede er en aktiv opgave
    /// </summary>
    public bool SætNuværendeOpgave(Opgave opgave)
    {
        if (NuværendeOpgave != null)
        {
            return false;
        }

        NuværendeOpgave = opgave;
        return true;
    }

    /// <summary>
    /// Afslutter den nuværende opgave, reducerer lysforureningen og tjekker om spillet er vundet.
    /// </summary>
    public void FuldførNuværendeOpgave()
    {
        if (NuværendeOpgave == null)
        {
            return;
        }

        ReducerLysforurening(NuværendeOpgave.LysforureningReduktion);
        NuværendeOpgave = null;
    }

    /// <summary>
    /// Sænker lysforureningen og sætter spilstatus til Slut, hvis den rammer 0
    /// </summary>
    public void ReducerLysforurening(int mængde)
    {
        Lysforurening = (Lysforurening - mængde > 0) ? Lysforurening - mængde : 0;
        if (Lysforurening == 0)
        {
            SætSpilStatusTilSlut();
        }
    }

    private void SætSpillerStartPosition(Lokation startLokation)
    {
        int startRække = startLokation.Gitter.GetLength(0) / 2;
        int startSøjle = startLokation.Gitter.GetLength(1) / 2;
        Spiller.SætPosition(startRække, startSøjle);
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

    private void TjekSamlGenstand(int række, int søjle)
    {
        if (NuværendeLokation.Gitter[række, søjle] == FeltType.Genstand)
        {
            Genstand? genstand = NuværendeLokation.SamlGenstand(række, søjle);
            if (genstand != null)
            {
                Spiller.SamlGenstand(genstand);
                SenestOpsamletGenstand = genstand;
            }
        }
    }
}
