public class NPC
{
    // de private variabler
    private string _navn;
    private Event _ev;

    // public methode som giver værdier til de private variabler
    public NPC(string navn, Event ev)
    {
        if (navn != "")
            _navn = navn;

        if (ev != null)
            _ev = ev;
    }

    // public methode som  udløse den npcs event
    public void UdløsEvent()
    {
        if (_ev != null)
        {
            // bestemmer hvilke methode at køre afhængigt af "eventType" parameteren
            switch (_ev.eventType)
            {
                case "dialog":
                    _ev.DialogLæser();
                    break;

                case "opgave":
                    _ev.UdløsOpgave();
                    break;

                case "begge":
                    _ev.DialogLæser();
                    _ev.UdløsOpgave();
                    break;

                default:
                    break;
            }
        }
    }
}
