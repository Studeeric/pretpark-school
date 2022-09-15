namespace KaartNS;
public static class FloatExtension
{
    public static string metSuffixen(this float f)
    {
        if (f > 1000)
        {
            f /= 1000;
            return string.Format("{0:0.0}K", f);
        }
        else
        {
            return "" + f;
        }
    }
}