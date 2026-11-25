/// <summary>
/// SpilStyren holder styr på spillets kontekst og andet relavant info.
/// Derudover har den også styr på spillets flow, regler og tilstand.
/// </summary>
public class SpilStyrer
{
    public SpilStatus Status = SpilStatus.Aktiv;

    private readonly Verden _verden;

    public SpilStyrer(Verden verden, Spiller spiller)
    {
        _verden = verden;
        NuværendeLokation = _verden.StartLokation;
        Spiller = spiller;

        SætSpillerStartPosition(NuværendeLokation);
    }

    public int Lysforurening { get; private set; } = 100;
    public Spiller Spiller { get; private set; }
    public Lokation NuværendeLokation { get; private set; }
    public Genstand? SenestOpsamletGenstand { get; private set; }
    public Lokation? LåstDørLokation { get; private set; }
    public List<Lokation> SenestOplåsteLokationer { get; } = new();
    public Opgave? NuværendeOpgave { get; private set; }
    public TidspunktPåDagen NuværendeTid { get; private set; } = TidspunktPåDagen.Morgen;
    public string? SenesteInteraktionsBesked { get; set; }

    public void BevægSpiller(Retning retning)
    {
        SenestOpsamletGenstand = null;
        LåstDørLokation = null;
        SenestOplåsteLokationer.Clear();

        (int nyRække, int nySøjle) = Spiller.BeregnNæstePosition(retning);

        if (!ErIndenForGitter(nyRække, nySøjle))
        {
            return;
        }

        // Dette er vores kollision detection, hvis feltet er en NPC, så stopper vi op
        FeltType målFelt = NuværendeLokation.Gitter[nyRække, nySøjle];
        if (målFelt == FeltType.NPC || målFelt == FeltType.Væg || målFelt == FeltType.Objekt)
        {
            return;
        }

        if (TjekOgUdførDørSkift(nyRække, nySøjle, out (int Række, int Søjle) nyDørPosition))
        {
            Spiller.SætPosition(nyDørPosition.Række, nyDørPosition.Søjle);
            return;
        }

        Spiller.SætPosition(nyRække, nySøjle);
        SenesteInteraktionsBesked = null; // FLYT IKKE LINJEN ELLERS GÅ DET I STYKKER :D
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

    public Objekt? HentNærliggendeObjekt()
    {
        Retning[] retninger = [Retning.Nord, Retning.Syd, Retning.Øst, Retning.Vest];

        for (int i = 0; i < retninger.Length; i++)
        {
            Retning retning = retninger[i];
            (int tjekRække, int tjekSøjle) = Spiller.BeregnNæstePosition(retning);
            Objekt? objekt = NuværendeLokation.HentObjektFraKoordinat(tjekRække, tjekSøjle);

            if (objekt != null)
            {
                return objekt;
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

        foreach (LokationType lokationType in NuværendeOpgave.LåsOpLokationer)
        {
            Lokation lokationDerÅbnes = _verden.HentLokation(lokationType);
            lokationDerÅbnes.ErLåst = false;
            SenestOplåsteLokationer.Add(lokationDerÅbnes);
        }

        ReducerLysforurening(NuværendeOpgave.LysforureningReduktion);
        NuværendeOpgave = null;
        TidenFremad();
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

        if (næste.ErLåst)
        {
            LåstDørLokation = næste;
            nySpillerPosition = (Spiller.Række, Spiller.Søjle);
            return true; // gør så spilleren ikke går ind i dørfeltet
        }

        nySpillerPosition = næste.HentDørKoordinatTil(NuværendeLokation);
        NuværendeLokation = næste;
        return true;
    }

    public void TidenFremad()
    {
        switch (NuværendeTid)
        {
            case TidspunktPåDagen.Morgen:
                NuværendeTid = TidspunktPåDagen.Formiddag;
                break;
            case TidspunktPåDagen.Formiddag:
                NuværendeTid = TidspunktPåDagen.Middag;
                break;
            case TidspunktPåDagen.Middag:
                NuværendeTid = TidspunktPåDagen.Eftermiddag;
                break;
            case TidspunktPåDagen.Eftermiddag:
                NuværendeTid = TidspunktPåDagen.Aften;
                break;
            case TidspunktPåDagen.Aften:
                NuværendeTid = TidspunktPåDagen.Nat;
                break;
            default:
                NuværendeTid = TidspunktPåDagen.Morgen;
                break;
        }
    }
}
