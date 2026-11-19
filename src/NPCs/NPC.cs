public class NPC
{
    private NPCType _person;

    public NPC(NPCType person, int række, int søjle, Begivenhed? begivenhed = null)
    {
        _person = person;
        Position = (række, søjle);
        Begivenhed = begivenhed;
    }

    public Begivenhed Begivenhed { get; }
    public (int række, int søjle) Position { get; set; }
    public string Navn => _person.ToString();
}
