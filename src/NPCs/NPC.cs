public class NPC
{
    private NPCType _person;
    private Begivenhed _ev;
    private (int r, int s) _position { get; set; }

    public NPC(NPCType person, int række, int søjle)
    {
        _person = person;
        _position = (række, søjle);
    }

    public string Navn => _person.ToString();
}
