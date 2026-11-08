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

        if (ev)
            _ev = ev;
    }

    // public methode som  udløse den npcs event
    public void UdløsEvent()
    {
        if (_ev)
        {
            _ev.UdløsOpgave();
        }
    }

}
