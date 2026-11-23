public class Begivenhed
{
    private readonly Dictionary<DialogTilstand, Replik[]> _dialoger;

    public Begivenhed(Dictionary<DialogTilstand, Replik[]> dialoger, Opgave? opgave = null)
    {
        _dialoger = dialoger;
        Opgave = opgave;
    }

    public Opgave? Opgave { get; }
    public bool ErOpgaveFærdig { get; private set; }

    public void DialogLæser() { }
    public void UdløsOpgave() { }

    /// <summary>
    /// Bestemmer hvilken DialogTilstand NPCen er og håndterer opgave-tildeling samt fuldførelse
    /// og returnerer de replikker som MenuTegner skal vise
    /// </summary>
    public Replik[] HentAktuelDialog(SpilStyrer spilStyrer)
    {
        // Hvis NPCen ikke har en opgave så returner FørOpgave dialog
        if (Opgave == null)
        {
            return _dialoger[DialogTilstand.FørOpgave];
        }

        // Hvis opgaven er færdig, så returner OpgaveFuldført dialog
        if (ErOpgaveFærdig)
        {
            return _dialoger[DialogTilstand.OpgaveFuldført];
        }

        // Afvis en opgave hvis en anden opgave er aktiv
        if (spilStyrer.NuværendeOpgave != null && spilStyrer.NuværendeOpgave != Opgave)
        {
            return _dialoger[DialogTilstand.EnAndenPersonsOpgaveErAktiv];
        }

        // Hvis spilleren ikke har fået denne NPC's opgave, tildeles den
        if (spilStyrer.NuværendeOpgave == null)
        {
            spilStyrer.SætNuværendeOpgave(Opgave);

            // Hvis opgaven løses blot ved at snakke med NPCen, så fuldføre vi den med det samme
            if (Opgave.LøsesVedSamtale)
            {
                Opgave.MarkerSomFuldført();
                ErOpgaveFærdig = true;
                spilStyrer.FuldførNuværendeOpgave();
            }

            return _dialoger[DialogTilstand.FørOpgave];
        }

        if (Opgave.ErFuldført || (Opgave.PåkrævetGenstand != null && Opgave.HarGenstandTilOpgave(spilStyrer.Spiller)))
        {
            Opgave.MarkerSomFuldført();
            ErOpgaveFærdig = true;
            spilStyrer.FuldførNuværendeOpgave();
            return _dialoger[DialogTilstand.OpgaveFuldført];
        }

        // Hvis opgaven ikke er færdig, returner vi bare OpgaveAktiv dialog
        return _dialoger[DialogTilstand.OpgaveAktiv];
    }
}
