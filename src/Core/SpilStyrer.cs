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
    
    public void Transition(string direction)
    {
        Retning? retning = direction switch
        {
            "Nord (↑)" => Retning.Nord,
            "Syd (↓)" => Retning.Syd,
            "Øst (→)" => Retning.Øst,
            "Vest (←)" => Retning.Vest,
            _ => null
        };
    
        if (retning == null)
        {
            Console.WriteLine("Ukendt retning.");
            return;
        }
    
        Transition(retning.Value);
    }

    public void Transition(Retning direction)
    {
        Lokation? næsteLokation = NuværendeLokation.FollowEdge(direction);
    
        if (næsteLokation == null)
        {
            Console.WriteLine($"Du kan ikke bevæge dig mod {direction}.");
            return;
        }
    
        NuværendeLokation = næsteLokation;
        NuværendeLokation.Welcome();
    }

    public void BevægSpiller(Retning direction)
    {
        switch (direction)
        {
            case Retning.North:
                if (spillerY > -3) spillerY--;
                break;
    
            case Retning.South:
                if (spillerY < 3) spillerY++;
                break;
    
            case Retning.West:
                if (spillerX > -5) spillerX--;
                break;
    
            case Retning.East:
                if (spillerX < 5) spillerX++;
                break;
        }
    }
    
    public bool ErSpillerPå(int x, int y)
    {
        return spillerX == x -5 && spillerY == y -3;
    }
    
    public void AfslutSpil() => status = SpilStatus.Slut;
    public SpilStatus TjekStatus() => status;
}