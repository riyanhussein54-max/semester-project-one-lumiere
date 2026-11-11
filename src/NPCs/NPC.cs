public class NPC
{
    // private variables/parametre
    private Person _person;
    private string _navn => _person.ToString();
    private Event _ev;
    private (int r, int s) _position { get; set; }

    // constructor
    public NPC(Person person, Event ev, int r, int s)
    {
        if (person)
            _person = person;

        if (ev != null)
            _ev = ev;

        _position = (r, s);
    }

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
