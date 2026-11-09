public class NPC
{
    // private variabler
    private string _navn;
    private Event _ev;

    // public methode/konstruktøren, der tildeler værdier til de private variabler
    public NPC(string navn, Event ev)
    {
        if (navn != "") // safeguard
            _navn = navn;

        if (ev != null) // safeguard
            _ev = ev;
    }

    // public methode som  udløser en event
    public void UdløsEvent()
    {
        if (_ev != null) // safeguard
        {
            // bestemmer hvilket methode at køre (hvilket slags event at udløse) afhængigt af "eventType"-parameteren
            /*
            switch (_ev.eventType)
            {
                // DialogLæser()
                case "dialog":
                    _ev.DialogLæser();
                    break;

                // UdløsOpgave()
                case "opgave":
                    _ev.UdløsOpgave();
                    break;

                // Begge? hvis der er brug for det
                case "begge":
                    _ev.DialogLæser();
                    _ev.UdløsOpgave();
                    break;

                // default fallback
                default:
                    break;
            }
             */
        }
    }
}
