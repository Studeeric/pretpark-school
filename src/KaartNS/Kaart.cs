namespace KaartNS;
public class Kaart
{
    public readonly int Breedte;
    public readonly int Hoogte;
    public List<KaartItem> _Items = new List<KaartItem>();
    public List<Pad> _Pad = new List<Pad>();

    public Kaart(int breedte, int hoogte)
    {
        Breedte = breedte;
        Hoogte = hoogte;
    }

    public void Teken(Tekener t)
    {
        foreach (Pad pad in _Pad)
        {
            t.Teken(pad);
        }
        foreach (KaartItem item in _Items)
        {
            t.Teken(item);
        }
    }

    public void VoegItemToe(KaartItem item)
    {
        _Items.Add(item);
    }

    public void VoegPadToe(Pad pad)
    {
        _Pad.Add(pad);
    }
}