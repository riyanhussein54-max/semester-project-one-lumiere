public class Objekt
{
    public Objekt(ObjektType type, int række, int søjle)
    {
        Position = (række, søjle);
        Type = type;
    }

    public ObjektType Type { get; private set; }
    public (int række, int søjle) Position { get; set; }
    public string Navn => Type.ToString();

    public void Tilintetgør() { }
}
