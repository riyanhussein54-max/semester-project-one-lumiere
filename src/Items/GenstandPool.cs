/// <summary>
/// GenstandPool-klassen opbevarer og udleverer alle spillets genstande.
/// </summary>
public static class GenstandPool
{
    private static List<Genstand> _genstande =
    [
        // Indgang
        new(GenstandType.Sikkerhedsudstyr, "Sikkerhedsudstyr", "Beskytter dig ved højspænding."),
        new(GenstandType.Sikkerhedsudstyr, "Lommelygte", ""),
        // Sut,
    
        // // Centrum
        // Voltmåler,
        // TermiskKamera,
        // Radio,
        // DiagnostiskTablet,
    
        // // Tek Kontoret
        // Lyskilder,
        // LysStyringsPanel,
    
        // //Kælderen
        // Luxmåler,
        // VarmLedPære,
        // Spektrometer,
        // LedPære,
        // Bevægelsessensor,
    
        // // Byparken
        // Gadelamper,
        // ParkLysstyringspanel,
    
        // // Zehra
        // RaSkulptur
    ];
    /// <summary>
    /// Henter en kopi af en genstand ud fra dens GenstandType.
    /// </summary>
    public static Genstand HentGenstand(GenstandType type)
    {
        foreach (Genstand genstand in _genstande)
        {
            if (genstand.Type == type)
            {
                return genstand.Kopier();
            }
        }
        throw new KeyNotFoundException($"Ukendt genstand: {type}");
    }
}
