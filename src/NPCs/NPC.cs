public class NPC
{
    private string _navn;
    private Event _ev;

    public NPC(string navn, Event ev)
    {
        // Safeguarding
        if (navn != "")
            _navn = navn;

        if (ev != null)
            _ev = ev;
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
