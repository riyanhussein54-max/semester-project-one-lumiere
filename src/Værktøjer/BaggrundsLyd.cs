public static class BaggrundsLyd
{
    public static string HentLyd(LokationType type)
    {
        return type switch
        {
            LokationType.Centrum => "centrum.wav",
            LokationType.NørreGade => "trafik.wav",
            LokationType.VesterGade => "trafik.wav",
            LokationType.ØsterGade => "trafik.wav",
            LokationType.SønderGade => "trafik.wav",

            LokationType.ZehrasHjem => "hjem.wav",
            LokationType.LuciusHjem => "hjem.wav",
            LokationType.IvanasHjem => "hjem.wav",

            LokationType.Kontor => "kontor.wav",
            LokationType.ParkingsPlads => "biler.wav",
            LokationType.Park => "park.wav",

            LokationType.HaraldNyborg => "butik.wav",
            LokationType.Elgiganten => "butik.wav",

            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };
    }
}
