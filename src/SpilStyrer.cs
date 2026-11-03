/// <summary>
/// SpilStyren holder styr på spillets kontekst og andet relavant info.
/// Derudover har den også styr på spillets flow, regler og tilstand.
/// </summary>
class SpilStyrer
{
    public Lokation nuværendeLokation { get; private set; }

    bool done = false;

    public SpilStyrer(Lokation node)
    {
        nuværendeLokation = node;
    }

    public void Transition(string direction)
    {
        Lokation next = nuværendeLokation.FollowEdge(direction);
        if (next == null)
        {
            Console.WriteLine($"You are confused, and walk in a circle looking for '{direction}'. In the end you give up. 😩");
        }
        else
        {
            nuværendeLokation = next;
            nuværendeLokation.Welcome();
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
