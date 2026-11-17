public class NPC
{
    private NPCType _person;
    private Begivenhed _ev;
    
    public NPC(NPCType person, int række, int søjle)
    {
        _person = person;
        Position = (række, søjle);
    }
    
    // npc position er public så npc spawn funktionen kan få fat til den
    public (int række, int søjle) Position { get; set; }
    public string Navn => _person.ToString();
}
