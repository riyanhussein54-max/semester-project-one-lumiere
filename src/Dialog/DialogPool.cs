public static class DialogPool
{
    public static Begivenhed OpretBegivenhedIvana()
    {
        Opgave opgave = new Opgave(
            titel: "Introduktion",
            beskrivelse: "Få redegørende information fra Ivana",
            lysforureningReduktion: 0,
            låsOpLokationer: [LokationType.NørreGade],
            løsesVedSamtale: true
        );

        Dictionary<DialogTilstand, Replik[]> dialog = new()
        {
            [DialogTilstand.FørOpgave] =
            [
                new Replik("*tager cigaret ude af munden* Godmorgen, mit navn er Ivana.", Følelse.Neutral),
                new Replik("Jeg er her for at hjælpe dig i gang med dit eventyr.", Følelse.KedAfDet),
                new Replik("Som du ved er vores by præget af lysforurening.", Følelse.Overrasket),
                new Replik("Jeg beder dig nu om at hjælpe 5 personer, som er mest udsat for lysforurening.", Følelse.KedAfDet),
                new Replik("Tryk [M] for at åbne minimappet. Den kan hjælpe dig med at finde rundt i byen.", Følelse.Neutral),
                new Replik("Tryk [E] eller [Enter] for at interagerer med NPC og store objekter på jorden. Den kommer du til at gøre meget brug af på dit eventyr.", Følelse.Overrasket),
                new Replik("Finder du en lille genstand på jorden, er det bedst at samle den op. Genstande kan bruges til at løse specifikke opgaver.", Følelse.Træt),
                new Replik("Nogle rum kan være låste. For at tilgå disse, skal du løse en specifik opgave.", Følelse.Neutral),
                new Replik("Hvis du bliver i tvivl om noget, kan du altid komme tilbage til mig. Så skal jeg nok gentage mig selv.", Følelse.KedAfDet),
                new Replik("Ellers kan du trykke [H] for at tilgå din hjælpemenu.", Følelse.Overrasket),
                new Replik("Byen har desparat brug for din hjælp.", Følelse.KedAfDet),
                new Replik("Du er den skarpeste ingeniør.", Følelse.Smirk),
                new Replik("Held og lykke.", Følelse.Neutral),
            ],
            [DialogTilstand.OpgaveFuldført] =
            [
                new Replik("Tryk [M] for at åbne minimappet. Den kan hjælpe dig med at finde rundt i byen.", Følelse.Neutral),
                new Replik("Tryk [E] eller [Enter] for at interagerer med NPC og objekter. Den kommer du til at gøre meget brug af på dit eventyr.", Følelse.Neutral),
                new Replik("Finder du en genstand på jorden, er det bedst at samle den op. Genstande kan bruges til at løse specifikke opgaver.", Følelse.Neutral),
                new Replik("Nogle rum kan være låste. For at tilgå disse, skal du løse en specifik opgave.", Følelse.Neutral),
                new Replik("Hvis du bliver i tvivl om noget, kan du altid komme tilbage til mig. Så skal jeg nok gentage mig selv.", Følelse.KedAfDet),
                new Replik("Ellers kan du trykke [H] for at tilgå din hjælpemenu.", Følelse.KedAfDet),
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
            titel: "Vidunderbarnet",
            beskrivelse: "Skru ned for lyset inde på Zehras værelse",
            lysforureningReduktion: 15,
            påkrævetObjekt: ObjektType.LysdæmperKontakt,
            låsOpLokationer: [LokationType.Kontor, LokationType.Elgiganten],
            fagbeskrivelse: ""
        );

        Dictionary<DialogTilstand, Replik[]> dialog = new()
        {
            [DialogTilstand.FørOpgave] =
            [
                new Replik("Mit navn er Zehra.", Følelse.KedAfDet),
                new Replik("Jeg er et 2-årig vidunderbarn, der er kognitivt begavet.", Følelse.KedAfDet),
                new Replik("Lysstyrken på mit værelse er for højt, da der både er kunstigt lys tændt.", Følelse.KedAfDet),
                new Replik("For at holde min hjerne skarp, skal lysstyrken i mit værelse sænkes.", Følelse.KedAfDet),
                new Replik("Som du ved kan lysstyrke påvirke børns kognitive udvikling.", Følelse.KedAfDet),
                new Replik("Dæmpet lys beroliger mig, især for børn på min alder, der hurtigt kan blive overvældet af for høj lysstyrke.", Følelse.KedAfDet),
                new Replik("Vil du være sød at skrue ned for lysstyrken.", Følelse.KedAfDet)
            ],
            [DialogTilstand.OpgaveAktiv] =
            [
                new Replik("Vil du være sød at skrue ned for lysstyrken.", Følelse.KedAfDet),
                new Replik("Lysstyrken på mit værelse er for højt, da der både er kunstigt lys tændt.", Følelse.KedAfDet),
                new Replik("Dæmpet lys beroliger mig, især for børn på min alder, der hurtigt kan blive overvældet af for høj lysstyrke.", Følelse.KedAfDet),
            ],
            [DialogTilstand.OpgaveFuldført] =
            [
                new Replik("TUSIND TAK DET VAR LIGE DET JEG HAVDE BRUG FOR!!!", Følelse.Glad),
                new Replik("Ej periodddd.", Følelse.Glad),
                new Replik("Og nu er der kun det gode naturlige lys fra vinduet tilbage.", Følelse.Glad),
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
                new Replik("Mit navn er Muhsin.", Følelse.Overrasket),
                new Replik("Jeg er en stresset kontorarbejder.", Følelse.KedAfDet),
                new Replik("Det her fucking lorte lokale er så dårligt belyset!!", Følelse.MegetSur),
                new Replik("Jeg bliver helt deprimeteret at sidde herinde.", Følelse.KedAfDet),
                new Replik("Jeg tror at lysgengivelsen på min nuværende elpære er ringe.", Følelse.KedAfDet),
                new Replik("Jeg ku' virkelig godt trænge til en ny...", Følelse.Træt),
                new Replik("Gad vide hvor man kan finde en ny elpære fra?", Følelse.Træt),
            ],
            [DialogTilstand.OpgaveAktiv] =
            [
                new Replik("Jeg har stadig brug for en ny elpære...", Følelse.Træt),
                new Replik("Måske har de en i Elgiganten?", Følelse.KedAfDet),
            ],
            [DialogTilstand.OpgaveFuldført] =
            [
                new Replik("Damn tak bro, den her elpære er meget bedre!", Følelse.Glad),
                new Replik("Du får en scone som belønning.", Følelse.Glad),
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
            lysforureningReduktion: 15,
            påkrævetObjekt: ObjektType.LuciusLampe,
            låsOpLokationer: [LokationType.ØsterGade]
        );

        Dictionary<DialogTilstand, Replik[]> dialog = new()
        {
            [DialogTilstand.FørOpgave] =
            [
                new Replik("Hey mit navn er Lucius.", Følelse.KedAfDet),
                new Replik("De fleste kalder mig for lord never-ending-name-ton.", Følelse.KedAfDet),
                new Replik("Jeg prøver at lave mine lektier, men jeg kan virkelig ikke koncentrere mig.", Følelse.KedAfDet),
                new Replik("Men fuck det, back to businesses.", Følelse.KedAfDet),
                new Replik("Jeg tror at det har noget med lyset at gøre.", Følelse.Sur),
                new Replik("Kan du hjælpe mig?", Følelse.Sur),
            ],
            [DialogTilstand.OpgaveAktiv] =
            [
                new Replik("Jeg tror at det har noget med lyset at gøre.", Følelse.Sur),
                new Replik("Kan du hjælpe mig?", Følelse.Sur),
            ],
            [DialogTilstand.OpgaveFuldført] =
            [
                new Replik("Tak bro!", Følelse.Glad),
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
            titel: "Telefonen",
            beskrivelse: "Aktiver blålysfilter på Riyans telefon",
            lysforureningReduktion: 0,
            opgavePremie: GenstandPool.Telefon
        );

        Dictionary<DialogTilstand, Replik[]> test = new()
        {
            [DialogTilstand.FørOpgave] =
            [
                new Replik("Hvad laver du i mit hjem??", Følelse.KedAfDet),
                new Replik("Ahh, du er ingeniøren min mormor Ivana har sendt.", Følelse.Sur),
                new Replik("Hun sagde at du skulle hjælpe mig med min telefon afhængighed.", Følelse.Sur),
                new Replik("Men jeg gider ikke at give min telefon væk!", Følelse.Sur),
                new Replik("Min mormor siger at min telefon gør at jeg ikke kan sove, men det jeg IKKE!", Følelse.Sur),
                new Replik("Min mormor siger også at jeg ikke kan koncentrere mig, da jeg kigger for meget på min telefon.", Følelse.Sur),
                new Replik("JEG HAR IKKE BRUG FOR HJÆLP!", Følelse.Sur),
            ],
            [DialogTilstand.OpgaveAktiv] =
            [
                new Replik("Eugh du skal hjælpe mig med min telefon...", Følelse.Sur),
                new Replik("Men bare lad mig være!", Følelse.Sur),
            ],
            [DialogTilstand.OpgaveFuldført] =
            [
                new Replik("Oooo I like that.", Følelse.Sur),
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
            lysforureningReduktion: 0,
            påkrævetObjekt: ObjektType.Lygtepæl
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
