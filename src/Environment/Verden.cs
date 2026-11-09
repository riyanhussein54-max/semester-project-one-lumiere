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

    public Verden()
    {
        OpretLokationer();
        ForbindLokationer();
        StartLokation = _lokationer[LokationType.Hjem];
    }

    /// <summary>
    /// Spillets startspunkt. Definers til at være Hjem i Konstrukturen.
    /// </summary>
    public Lokation StartLokation { get; }

    /// <summary>
    /// Opret alle lokationer her. Dette kan betegnes som en "LokationsPool".
    /// </summary>
    private void OpretLokationer()
    {
        Tilføj(new Lokation(LokationType.Hjem, new FeltType[5, 7]));
        Tilføj(new Lokation(LokationType.GadeV, new FeltType[7, 11]));
        Tilføj(new Lokation(LokationType.Park, new FeltType[6, 9]));
        Tilføj(new Lokation(LokationType.GadeN, new FeltType[7, 11]));
        Tilføj(new Lokation(LokationType.BobsHus, new FeltType[7, 5]));
        Tilføj(new Lokation(LokationType.Bytorv, new FeltType[9, 15]));
        Tilføj(new Lokation(LokationType.GadeØ, new FeltType[7, 10]));
        Tilføj(new Lokation(LokationType.Nabo, new FeltType[5, 7]));
        Tilføj(new Lokation(LokationType.Station, new FeltType[11, 6]));
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
        Forbind(LokationType.Hjem, Retning.Nord, LokationType.GadeV, Retning.Syd);
        Forbind(LokationType.GadeV, Retning.Vest, LokationType.Station, Retning.Øst);
        Forbind(LokationType.GadeV, Retning.Nord, LokationType.Park, Retning.Syd);
        Forbind(LokationType.GadeV, Retning.Øst, LokationType.GadeØ, Retning.Vest);
        Forbind(LokationType.GadeØ, Retning.Syd, LokationType.Nabo, Retning.Nord);
        Forbind(LokationType.GadeØ, Retning.Nord, LokationType.Bytorv, Retning.Syd);
        Forbind(LokationType.Park, Retning.Øst, LokationType.Bytorv, Retning.Vest);
        Forbind(LokationType.Park, Retning.Nord, LokationType.GadeN, Retning.Syd);
        Forbind(LokationType.GadeN, Retning.Vest, LokationType.BobsHus, Retning.Øst);

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
}
