public static class GenstandPool
{
    private static List<Genstand> _genstande =
    [
    ];
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
