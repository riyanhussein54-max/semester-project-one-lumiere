using System;
using System.Collections.Generic;
public class Event
{
    private EventType eventType;
    private List<string> dialog;
    private Opgave? opgave;

    public Event(Eventtype eventType, List<string> dialog, Opgave? opgave)
    {
        this.eventType = eventType;
        this.dialog = dialog;
        this.opgave = opgave;
    }
    public void DialogLæser()
    {
        foreach (string linje in dialog)
        {
            Console.WriteLine(linje);
        }
    }
    public void UdløsOpgave()
    {
        if (opgave != null)
        {
            Console.WriteLine("En opgave er blevet udløst!");
        }
        else
        {
            ConsoleWriteLine("Dette event har ingen opgave.");
        }
    }
}
