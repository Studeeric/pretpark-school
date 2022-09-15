namespace KaartNS;
public class Pad : Tekenbaar
{
    public Coordinaat van { get; set; }
    public Coordinaat naar { get; set; }
    private float? lengteBerekend;
    public float Lengte()
    {
        if (!lengteBerekend.HasValue)
            lengteBerekend = (float)Math.Sqrt((van.x - naar.x) * (van.x - naar.x) + (van.y - naar.y) * (van.y - naar.y));
        return lengteBerekend.Value;
    }
    public void TekenConsole(ConsoleTekener t)
    {
        for (int i = 0; i < (int)Lengte(); i++)
        {
            float factor = i / Lengte();
            t.SchrijfOp(new Coordinaat((int)Math.Round(van.x + (naar.x - van.x) * factor), (int)Math.Round(van.y + (naar.y - van.y) * factor)), "#");
        }
        t.SchrijfOp(new Coordinaat((int)Math.Round(van.x + (naar.x - van.x) * .5), (int)Math.Round(van.y + (naar.y - van.y) * .5)), (1000 * Lengte()).metSuffixen());
    }
}