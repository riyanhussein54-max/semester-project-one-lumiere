public static class DialogPool
{
    public static Begivenhed OpretBegivenhedIvana()
    {
        Opgave opgave = new Opgave(
            titel: "Den manglende sut",
            beskrivelse: "Find Zehras sut",
            lysforureningReduktion: 0,
            låsOpLokationer: [LokationType.NørreGade],
            løsesVedSamtale: true
        );

        Dictionary<DialogTilstand, Replik[]> dialog = new()
        {
            [DialogTilstand.FørOpgave] =
            [
                new Replik("Godmorgen, mit navn er Ivana.", Følelse.Neutral),
                new Replik("Jeg er her for at hjælpe dig i gang med dit eventyr.", Følelse.KedAfDet),
                new Replik("Som du ved er vores by præget af lysforurening.", Følelse.Overrasket),
                new Replik("Jeg beder dig nu om at hjælpe 5 personer, som er mest udsat for lysforurening.", Følelse.KedAfDet),
                new Replik("Tryk [M] for at åbne minimapet. Den kan hjælpe dig med at finde rundt i byen.", Følelse.Neutral),
                new Replik("Held og lykke.", Følelse.KedAfDet),
            ],
            [DialogTilstand.OpgaveFuldført] =
            [
                new Replik("Held og lykke.", Følelse.Neutral),
            ],
            [DialogTilstand.EnAndenPersonsOpgaveErAktiv] =
            [
                new Replik("Farvel", Følelse.Neutral)
            ]
        };

        return new Begivenhed(dialog, opgave);
    }

    public static Begivenhed OpretBegivenhedZehra()
    {
        Opgave opgave = new(
            titel: "Grædende pige",
            beskrivelse: "Hjælp den grædende pige med at finde sin sut",
            lysforureningReduktion: 15,
            påkrævetGenstand: GenstandType.Sut,
            låsOpLokationer: [LokationType.Kontor, LokationType.Elgiganten]
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
        Opgave opgave = new Opgave(
            titel: "Lorte lys",
            beskrivelse: "Hjælp Muhsin med at skifte sin elpære",
            lysforureningReduktion: 15,
            påkrævetGenstand: GenstandType.Elpære,
            låsOpLokationer: [LokationType.VesterGade]
        );

        Dictionary<DialogTilstand, Replik[]> dialog = new()
        {
            [DialogTilstand.FørOpgave] =
            [
                new Replik("Det her fucking lorte lokale er så dårligt belyset!!", Følelse.MegetSur),
                new Replik("Jeg bliver helt deprimeteret at sidde herinde.", Følelse.KedAfDet),
                new Replik("Jeg kunne virkelig godt trænge til en ny elpære...", Følelse.Træt),
                new Replik("Det kan være at de har en i Elgiganten.", Følelse.KedAfDet),
            ],
            [DialogTilstand.OpgaveAktiv] =
            [
                new Replik("Jeg kunne virkelig godt trænge til en ny elpære...", Følelse.Træt),
            ],
            [DialogTilstand.OpgaveFuldført] =
            [
                new Replik("Damn bro, den her elpære er meget bedre!", Følelse.Glad),
            ],
            [DialogTilstand.EnAndenPersonsOpgaveErAktiv] =
            [
                new Replik("Farvel", Følelse.Neutral)
            ]
        };

        return new Begivenhed(dialog, opgave);
    }

    public static Begivenhed OpretBegivenhedLucius()
    {
        Opgave opgave = new Opgave(
            titel: "Lektielæsning",
            beskrivelse: "Tænd lampen inde på Lucius værelse",
            lysforureningReduktion: 0,
            låsOpLokationer: [LokationType.ØsterGade]
        );

        Dictionary<DialogTilstand, Replik[]> dialog = new()
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

        return new Begivenhed(dialog, opgave);
    }

    public static Begivenhed OpretBegivenhedRiyan()
    {
        Opgave testOpgave = new Opgave(
            titel: "Uangivet",
            beskrivelse: "",
            lysforureningReduktion: 0,
            opgavePremie: GenstandPool.Telefon
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
        Opgave opgave = new Opgave(
            titel: "Uangivet",
            beskrivelse: "",
            lysforureningReduktion: 0
        );

        Dictionary<DialogTilstand, Replik[]> dialog = new()
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

        return new Begivenhed(dialog, opgave);
    }
}
