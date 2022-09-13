using KaartNS;
public class Attractie : KaartItem
{
    private int? _minimaleLente {get; set;}
    private int _angstLevel {get; set;}
    private string? _naam {get; set;}

    public Attractie(Kaart k, Coordinaat c):base(k,c){}

    public override char Karakter {get;}
    public int? MinimaleLengte {get; set;}
    public int AngstLevel {get; set;}
    public string? Naam {get; set;}
}