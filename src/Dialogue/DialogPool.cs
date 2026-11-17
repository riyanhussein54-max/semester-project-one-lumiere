public static class DialogPool
{
    public static Begivenhed OpretTestBegivenhed()
    {
        Opgave testOpgave = new Opgave(
            titel: "Sluk reklameskiltet",
            beskrivelse: "",
            lysforureningReduktion: 25
        );

        Dictionary<DialogTilstand, Replik[]> test = new()
        {
            [DialogTilstand.FørOpgave] =
            [
                new Replik("Hej! Jeg kan slet ikke sove for det skarpe neonlys.", Følelse.KedAfDet),
                new Replik("Kan du hjælpe mig med at slukke reklameskiltet på gaden?", Følelse.Neutral)
            ],
            [DialogTilstand.OpgaveAktiv] =
            [
                new Replik("Skiltet lyser stadig derude... Har du fundet kontakten?", Følelse.KedAfDet)
            ],
            [DialogTilstand.OpgaveFuldført] =
            [
                new Replik("Tusind tak! Endelig kan man se stjernerne igen.", Følelse.Glad)
            ],
            [DialogTilstand.EnAndenPersonsOpgaveErAktiv] =
            [
                new Replik("Du ser ud til at have travlt. Kom tilbage, når du har tid!", Følelse.Neutral)
            ]
        };

        return new Begivenhed(test, testOpgave);
    }

    public static Begivenhed OpretBegivenhedZehra()
    {
        Opgave opgave = new(
            titel: "Grædende pige",
            beskrivelse: "Hjælp den grædende pige med at finde hendes sut",
            lysforureningReduktion: 25
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
}
