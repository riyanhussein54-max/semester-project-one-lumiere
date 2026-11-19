public static class DialogPool
{
    public static Begivenhed OpretBegivenhedZehra()
    {
        Opgave opgave = new(
            titel: "Grædende pige",
            beskrivelse: "Hjælp den grædende pige med at finde sin sut",
            lysforureningReduktion: 15
        );

        Dictionary<DialogTilstand, Replik[]> dialog = new()
        {
            [DialogTilstand.FørOpgave] =
            [
                new Replik("Jeg er meget ked af det.", Følelse.KedAfDet),
                new Replik("Please find mig min sut", Følelse.Græder)
            ],
            [DialogTilstand.OpgaveAktiv] =
            [
                new Replik("Jeg har altså stadig ikke fået min sut.", Følelse.Tåre),
                new Replik("Please jeg har brug for min sut.", Følelse.Græder)
            ],
            [DialogTilstand.OpgaveFuldført] =
            [
                new Replik("TUSIND TAK DET VAR LIGE DET JEG HAVDE BRUG FOR!!!", Følelse.Glad)
            ],
            [DialogTilstand.EnAndenPersonsOpgaveErAktiv] =
            [
                new Replik("Du ser ud til at have travlt. Kom tilbage, når du har tid!", Følelse.Neutral)
            ]
        };

        return new Begivenhed(dialog, opgave);
    }

    public static Begivenhed OpretBegivenhedMuhsin()
    {
        Opgave testOpgave = new Opgave(
            titel: "Uangivet",
            beskrivelse: "",
            lysforureningReduktion: 0
        );

        Dictionary<DialogTilstand, Replik[]> test = new()
        {
            [DialogTilstand.FørOpgave] =
            [
                new Replik("Hej!", Følelse.KedAfDet),
            ],
            [DialogTilstand.OpgaveAktiv] =
            [
                new Replik("Dette er en test", Følelse.KedAfDet)
            ],
            [DialogTilstand.OpgaveFuldført] =
            [
                new Replik("2 + 2 = 5", Følelse.Glad)
            ],
            [DialogTilstand.EnAndenPersonsOpgaveErAktiv] =
            [
                new Replik("Farvel", Følelse.Neutral)
            ]
        };

        return new Begivenhed(test, testOpgave);
    }

    public static Begivenhed OpretBegivenhedIvana()
    {
        Opgave testOpgave = new Opgave(
            titel: "Uangivet",
            beskrivelse: "",
            lysforureningReduktion: 0
        );

        Dictionary<DialogTilstand, Replik[]> test = new()
        {
            [DialogTilstand.FørOpgave] =
            [
                new Replik("Hej!", Følelse.KedAfDet),
            ],
            [DialogTilstand.OpgaveAktiv] =
            [
                new Replik("Dette er en test", Følelse.KedAfDet)
            ],
            [DialogTilstand.OpgaveFuldført] =
            [
                new Replik("2 + 2 = 5", Følelse.Glad)
            ],
            [DialogTilstand.EnAndenPersonsOpgaveErAktiv] =
            [
                new Replik("Farvel", Følelse.Neutral)
            ]
        };

        return new Begivenhed(test, testOpgave);
    }

    public static Begivenhed OpretBegivenhedRiyan()
    {
        Opgave testOpgave = new Opgave(
            titel: "Uangivet",
            beskrivelse: "",
            lysforureningReduktion: 0
        );

        Dictionary<DialogTilstand, Replik[]> test = new()
        {
            [DialogTilstand.FørOpgave] =
            [
                new Replik("Hej!", Følelse.KedAfDet),
            ],
            [DialogTilstand.OpgaveAktiv] =
            [
                new Replik("Dette er en test", Følelse.KedAfDet)
            ],
            [DialogTilstand.OpgaveFuldført] =
            [
                new Replik("2 + 2 = 5", Følelse.Glad)
            ],
            [DialogTilstand.EnAndenPersonsOpgaveErAktiv] =
            [
                new Replik("Farvel", Følelse.Neutral)
            ]
        };

        return new Begivenhed(test, testOpgave);
    }

    public static Begivenhed OpretBegivenhedLucius()
    {
        Opgave testOpgave = new Opgave(
            titel: "Uangivet",
            beskrivelse: "",
            lysforureningReduktion: 0
        );

        Dictionary<DialogTilstand, Replik[]> test = new()
        {
            [DialogTilstand.FørOpgave] =
            [
                new Replik("Hej!", Følelse.KedAfDet),
            ],
            [DialogTilstand.OpgaveAktiv] =
            [
                new Replik("Dette er en test", Følelse.KedAfDet)
            ],
            [DialogTilstand.OpgaveFuldført] =
            [
                new Replik("2 + 2 = 5", Følelse.Glad)
            ],
            [DialogTilstand.EnAndenPersonsOpgaveErAktiv] =
            [
                new Replik("Farvel", Følelse.Neutral)
            ]
        };

        return new Begivenhed(test, testOpgave);
    }

    public static Begivenhed OpretBegivenhedAdam()
    {
        Opgave testOpgave = new Opgave(
            titel: "Uangivet",
            beskrivelse: "",
            lysforureningReduktion: 0
        );

        Dictionary<DialogTilstand, Replik[]> test = new()
        {
            [DialogTilstand.FørOpgave] =
            [
                new Replik("Hej!", Følelse.KedAfDet),
            ],
            [DialogTilstand.OpgaveAktiv] =
            [
                new Replik("Dette er en test", Følelse.KedAfDet)
            ],
            [DialogTilstand.OpgaveFuldført] =
            [
                new Replik("2 + 2 = 5", Følelse.Glad)
            ],
            [DialogTilstand.EnAndenPersonsOpgaveErAktiv] =
            [
                new Replik("Farvel", Følelse.Neutral)
            ]
        };

        return new Begivenhed(test, testOpgave);
    }
}
