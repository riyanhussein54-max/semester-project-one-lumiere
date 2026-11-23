using System;
using System.IO;
using NetCoreAudio;

namespace semester_project_one_lumiere.src.Værktøjer
{
    public static class LydManager
    {
        private static readonly Player _musikPlayer = new Player();
        private static readonly Player _effektPlayer = new Player();
        private static string _nuværendeMusikFil = "";

        public static async void SpilBaggrundsMusik(string filSti, float lydstyrke = 1.0f)
        {
            try
            {
                if (_nuværendeMusikFil == filSti) return;

                await _musikPlayer.Stop();

                _nuværendeMusikFil = filSti;
                string fuldSti = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Lyd", filSti);

                if (File.Exists(fuldSti))
                {
                    await _musikPlayer.Play(fuldSti);
                }
                else
                {
                    Console.WriteLine($"[LydManager] Kunne ikke finde musikfil: {fuldSti}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LydManager] Fejl ved afspilning af musik: {ex.Message}");
            }
        }

        public static async void SpilLydEffekt(string filSti, float lydstyrke = 1.0f)
        {
            try
            {
                string fuldSti = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Lyd", filSti);

                if (File.Exists(fuldSti))
                {
                    await _effektPlayer.Play(fuldSti);
                }
                else
                {
                    Console.WriteLine($"[LydManager] Kunne ikke finde lydeffekt: {fuldSti}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LydManager] Fejl ved afspilning af lydeffekt: {ex.Message}");
            }
        }

        public static async void StopMusik()
        {
            try
            {
                await _musikPlayer.Stop();
                _nuværendeMusikFil = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LydManager] Fejl ved stop af musik: {ex.Message}");
            }
        }
    }
}
