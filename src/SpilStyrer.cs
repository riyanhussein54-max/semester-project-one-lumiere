/// <summary>
/// SpilStyren holder styr på spillets kontekst og andet relavant info.
/// Derudover har den også styr på spillets flow, regler og tilstand.
/// </summary>
class SpilStyrer
{
    public Lokation NuværendeLokation { get; private set; }

    bool done = false;

    public SpilStyrer(Lokation node)
    {
        NuværendeLokation = node;
    }

    public void Transition(string direction)
    {
        Lokation next = NuværendeLokation.FollowEdge(direction);
        if (next == null)
        {
            Console.WriteLine($"You are confused, and walk in a circle looking for '{direction}'. In the end you give up. 😩");
        }
        else
        {
            NuværendeLokation = next;
            NuværendeLokation.Welcome();
        }
    }

    public void MakeDone()
    {
        done = true;
    }

    public bool IsDone()
    {
        return done;
    }
}
