/// <summary>
/// SpilStyren holder styr på spillets kontekst og andet relavant info.
/// Derudover har den også styr på spillets flow, regler og tilstand.
/// </summary>
public class SpilStyrer
{
    public SpilStatus status = SpilStatus.Aktiv;

    public SpilStyrer(Lokation node)
    {
        NuværendeLokation = node;
    }

    public int Lysforurening { get; private set; } = 100;
    public Lokation NuværendeLokation { get; private set; }
    private int spillerX = 0;
    private int spillerY = 0;

    // TODO: Implementer nedenstående så snart det er muligt
    // public Lokation NuværendeOpgave { get; private set; }
    // public int[,] SpillerLokation { get; private set; }

    public void BevægSpiller(Retning direction)
    {
        switch (direction)
        {
            case Retning.Nord:
                if (spillerY > -NuværendeLokation.Gitter.GetLength(0)) spillerY--;
                break;

            case Retning.Syd:
                if (spillerY < NuværendeLokation.Gitter.GetLength(1)) spillerY++;
                break;

            case Retning.Øst:
                if (spillerX < NuværendeLokation.Gitter.GetLength(0)) spillerX++;
                break;

            case Retning.Vest:
                if (spillerX > -NuværendeLokation.Gitter.GetLength(1)) spillerX--;
                break;
        }
    }

    public bool ErSpillerPå(int x, int y)
    {
        return spillerX == x - 5 && spillerY == y - 3;
    }

    public void AfslutSpil() => status = SpilStatus.Slut;
    public SpilStatus TjekStatus() => status;
}
