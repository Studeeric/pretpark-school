namespace KaartNS;
public abstract class KaartItem : Tekenbaar
{
    private Coordinaat _locatie;
    private Kaart? kaart;

    public KaartItem(Kaart kaart, Coordinaat _locatie)
    {
        if (_locatie.x < kaart.Breedte && _locatie.y < kaart.Hoogte && _locatie.x >= 0 && _locatie.y >= 0)
        {
            this.kaart = kaart;
            this._locatie = _locatie;
        }
    }

    public Coordinaat Locatie
    {
        get => _locatie;
        set
        {
            if (kaart != null)
            {
                if ((value.x >= 0) && (value.x <= kaart.Breedte) && (value.y >= 0) && (value.y <= kaart.Hoogte))
                {
                    _locatie = value;
                }
            }
        }
    }

    public abstract char Karakter { get; }

    public void TekenConsole(ConsoleTekener t)
    {
        t.SchrijfOp(Locatie, "A");
    }
}