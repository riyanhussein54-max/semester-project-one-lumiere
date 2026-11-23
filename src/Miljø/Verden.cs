/// <summary>
/// Verden-klassen bruges til at definerer hele spilleverden, ved at skabe og forbind lokationer.
/// Overvej at lave den til en statisk klasse.
/// </summary>
public class Verden
{
    /// <summary>
    /// Alle lokationer gemmes i denne dictionary.
    /// </summary>
    private readonly Dictionary<LokationType, Lokation> _lokationer = new();

    /// <summary>
    /// Husk at ligge funktioner der skal køres her.
    /// </summary>
    public Verden()
    {
        OpretLokationer();
        ForbindLokationer();
        SpawnNPCer();
        SpawnGenstande();

        StartLokation = _lokationer[LokationType.Centrum];
    }

    /// <summary>
    /// Spillets startspunkt. Definers til at være Hjem i Konstrukturen.
    /// </summary>
    public Lokation StartLokation { get; }

    public Lokation HentLokation(LokationType type) => _lokationer[type];

    /// <summary>
    /// Opret alle lokationer her. Dette kan betegnes som en "LokationsPool".
    /// </summary>
    private void OpretLokationer()
    {
        Tilføj(new Lokation(LokationType.Centrum, new FeltType[11, 11]));
        Tilføj(new Lokation(LokationType.NørreGade, new FeltType[5, 7]));
        Tilføj(new Lokation(LokationType.VesterGade, new FeltType[5, 9]));
        Tilføj(new Lokation(LokationType.ØsterGade, new FeltType[5, 9]));
        Tilføj(new Lokation(LokationType.SønderGade, new FeltType[5, 7]));
        Tilføj(new Lokation(LokationType.ZehrasHjem, new FeltType[7, 8]));
        Tilføj(new Lokation(LokationType.Kontor, new FeltType[4, 9]));
        Tilføj(new Lokation(LokationType.LuciusHjem, new FeltType[7, 8]));
        Tilføj(new Lokation(LokationType.ParkingsPlads, new FeltType[9, 10]));
        Tilføj(new Lokation(LokationType.Park, new FeltType[8, 8]));
        Tilføj(new Lokation(LokationType.IvanasHjem, new FeltType[7, 8]));
        Tilføj(new Lokation(LokationType.HaraldNyborg, new FeltType[9, 8]));
        Tilføj(new Lokation(LokationType.Elgiganten, new FeltType[8, 9]));
    }

    /// <summary>
    /// Privat API til at tilføje en ny lokation.
    /// </summary>
    private void Tilføj(Lokation lokation)
    {
        _lokationer[lokation.Type] = lokation;
    }

    /// <summary>
    /// Forbinder to Lokationer med hinanden ved at definere ind- og
    /// udgangen i mellem dem.
    ///
    /// Eksempel:
    /// - Hjem (Dør i nordlig side til GadeV)
    /// - GadeV (Dør i sydlig side til Hjem)
    /// </summary>
    private void ForbindLokationer()
    {
        Forbind(LokationType.Centrum, Retning.Nord, LokationType.NørreGade, Retning.Syd);
        Forbind(LokationType.Centrum, Retning.Vest, LokationType.VesterGade, Retning.Øst);
        Forbind(LokationType.Centrum, Retning.Øst, LokationType.ØsterGade, Retning.Vest);
        Forbind(LokationType.Centrum, Retning.Syd, LokationType.SønderGade, Retning.Nord);
        //starter med zone 1
        Forbind(LokationType.NørreGade, Retning.Nord, LokationType.Kontor, Retning.Syd);
        Forbind(LokationType.NørreGade, Retning.Øst, LokationType.ZehrasHjem, Retning.Vest);
        Forbind(LokationType.NørreGade, Retning.Vest, LokationType.Elgiganten, Retning.Øst);
        //zone 2
        Forbind(LokationType.VesterGade, Retning.Vest, LokationType.LuciusHjem, Retning.Øst);
        Forbind(LokationType.VesterGade, Retning.Syd, LokationType.ParkingsPlads, Retning.Nord);
        Forbind(LokationType.ParkingsPlads, Retning.Øst, LokationType.SønderGade, Retning.Vest);
        //zone S
        Forbind(LokationType.SønderGade, Retning.Syd, LokationType.Park, Retning.Nord);
        Forbind(LokationType.ØsterGade, Retning.Øst, LokationType.HaraldNyborg, Retning.Vest);
        Forbind(LokationType.ØsterGade, Retning.Syd, LokationType.IvanasHjem, Retning.Nord);
    }

    /// <summary>
    /// 1. Vi henter dictionary-værdien, som er en vilkårlig Lokation.
    /// 2. Dernæst kalder vi TilføjUdgang() på den afhentede lokation for at
    ///    skabe en udgang.
    /// </summary>
    private void Forbind(LokationType fra, Retning retningFra, LokationType til, Retning retningTil)
    {
        _lokationer[fra].TilføjUdgang(retningFra, _lokationer[til]);
        _lokationer[til].TilføjUdgang(retningTil, _lokationer[fra]);
    }

    /// <summary>
    /// Spawner NPCs fra NPCPool i specifikke defineret lokationer.
    ///(Tjek "SpawnNPC" funktionen i "Lokation.cs" for mere info.)
    /// </summary>
    private void SpawnNPCer()
    {
        _lokationer[LokationType.Park].SpawnNPC(NPCPool.Adam);
        _lokationer[LokationType.Centrum].SpawnNPC(NPCPool.Ivana);
        _lokationer[LokationType.Kontor].SpawnNPC(NPCPool.Muhsin);
        _lokationer[LokationType.ZehrasHjem].SpawnNPC(NPCPool.Zehra);
        _lokationer[LokationType.IvanasHjem].SpawnNPC(NPCPool.Riyan);
        _lokationer[LokationType.LuciusHjem].SpawnNPC(NPCPool.Lucius);
    }

    /// <summary>
    /// Spawner Genstande fra GenstandPool i specifikke defineret lokationer.
    ///(Tjek "SpawnGenstand" funktionen i "Lokation.cs" for mere info.)
    /// </summary>
    private void SpawnGenstande()
    {
        _lokationer[LokationType.Centrum].SpawnGenstand(GenstandPool.Sut);
        _lokationer[LokationType.Elgiganten].SpawnGenstand(GenstandPool.Elpære);
        _lokationer[LokationType.IvanasHjem].SpawnGenstand(GenstandPool.Telefon);
        _lokationer[LokationType.HaraldNyborg].SpawnGenstand(GenstandPool.Hammer);

        for (int g = 0; g < GenstandPool.GadeLamper.Length; g++)
        {
            _lokationer[LokationType.Park].SpawnGenstand(GenstandPool.GadeLamper[g]);
        }

        // TODO: få evt genstande fra genstandpool
        // ! Vi angiver koordinater på genstandene her, men for NPCer er det anderledes? Det gør det svært at balancer det
        /*
        _lokationer[LokationType.Centrum].SpawnGenstand(new(GenstandType.Sut, "Farven er lyserød"), 1, 1);
        _lokationer[LokationType.Elgiganten].SpawnGenstand(new(GenstandType.Elpære, "PHILIPS LED-pære"), 2, 2);
        _lokationer[LokationType.IvanasHjem].SpawnGenstand(new(GenstandType.Telefon, "Samsung Galaxy A"), 2, 4);
        _lokationer[LokationType.HaraldNyborg].SpawnGenstand(new(GenstandType.Hammer, "Den slår hårdt"), 2, 4);
         */
    }
}
