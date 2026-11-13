public class NPC
{
    private NPCType _person;
    private Event _ev;

    // npc position er public så npc spawn funktionen kan få fat til den
    public (int r, int s) position { get; set; }

    public NPC(NPCType person, int række, int søjle)
    {
        _person = person;
        position = (række, søjle);
    }

    public string Navn => _person.ToString();

    public void UdløsEvent()
    {
        if (_ev != null)
        {
            // TODO: udløse npc events og opgaver
        }
    }
}
