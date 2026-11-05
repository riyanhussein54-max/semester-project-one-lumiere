
public class TypeWriter
{
    string text;
    int Speed;
    public TypeWriter(string text, int Speed)
    {
        this.text = text;
        this.Speed = Speed;
    }
    public void Writing()
    {
        char[] Letter = text.ToCharArray();
        for (int i = 0; i < Letter.Length; i++)
        {
            Console.Write(Letter[i]);
            Thread.Sleep(Speed);
        }
        Console.Write("\n");
    }
}
