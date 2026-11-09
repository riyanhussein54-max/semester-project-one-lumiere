public class Opgave
{
    private string OpgaveBeskrivelse;
    private bool OpgaveStatus;

    public Opgave(string OpgaveBeskrivelse, bool OpgaveStatus)
    {
        this.OpgaveBeskrivelse = OpgaveBeskrivelse;
        this.OpgaveStatus = OpgaveStatus;
    }

    public void CheckStatus()
    {
        Console.WriteLine("Opgavestatus: " + OpgaveStatus);
    }
}
