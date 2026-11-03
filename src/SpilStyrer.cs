/// <summary>
/// SpilStyren holder styr på spillets kontekst og andet relavant info.
/// Derudover har den også styr på spillets flow, regler og tilstand.
/// </summary>
class SpilStyrer
{
    Lokation current;
    bool done = false;

    public SpilStyrer(Lokation node)
    {
        current = node;
    }

    public Lokation GetCurrentLocation()
    {
        return current;
    }

    public void Transition(string direction)
    {
        Lokation next = current.FollowEdge(direction);
        if (next == null)
        {
            Console.WriteLine($"You are confused, and walk in a circle looking for '{direction}'. In the end you give up. 😩");
        }
        else
        {
            current = next;
            current.Welcome();
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
