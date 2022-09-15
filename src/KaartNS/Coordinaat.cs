namespace KaartNS;
public struct Coordinaat
{
    public readonly int x;
    public readonly int y;

    public Coordinaat(int x, int y)
    {
      this.x = x;
      this.y = y;  
    }

    public static Coordinaat operator+(Coordinaat c1, Coordinaat c2)
    {
        return new Coordinaat(c1.x + c2.x, c1.y + c2.y);
    }
}