public class NPC
{
    private NPCType _person;
    private Event _ev;
    private (int r, int s) _position { get; set; }

    public NPC(NPCType person, int række, int søjle)
    {
        _person = person;
        _position = (række, søjle);
    }

    public string Navn => _person.ToString();

    public void UdløsEvent()
    {
        if (_ev != null)
        {
            // bestemmer hvilket methode at køre (hvilket slags event at udløse) afhængigt af "eventType"-parameteren
            /*
            switch (_ev.eventType)
            {
                case "dialog":
                    _ev.DialogLæser();
                    break;
                case "opgave":
                    _ev.UdløsOpgave();
                    break;
                // Begge? hvis der er brug for det
                case "begge":
                    _ev.DialogLæser();
                    _ev.UdløsOpgave();
                    break;
                default:
                    break;
            }
             */
        }
    }
}
