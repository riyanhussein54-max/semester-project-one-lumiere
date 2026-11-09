using System;
using System.Collections.Generic;

public class Event
{
    private EventType eventType;
    private List<string> dialog;
    private Opgave? opgave;

    // Skal implementeres:
    public void DialogLæser() { }
    public void UdløsOpgave() { }
}
