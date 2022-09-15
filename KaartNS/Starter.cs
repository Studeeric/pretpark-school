namespace KaartNS;
using AuthenticatieNS;

public class Starter
{
    public static void Main(string[] args)
    {
        Week2OpdrachtDeel1();
    }

    public static void Week1Opdracht()
    {
        Kaart k = new Kaart(30, 30);
        Pad p1 = new Pad();
        p1.van = new Coordinaat(2, 5);
        p1.van = new Coordinaat(12, 30);
        k.VoegPadToe(p1);
        Pad p2 = new Pad();
        p2.van = new Coordinaat(26, 4);
        p2.naar = new Coordinaat(10, 5);
        k.VoegPadToe(p2);
        k.VoegItemToe(new Attractie(k, new Coordinaat(15, 15)));
        k.VoegItemToe(new Attractie(k, new Coordinaat(20, 15)));
        k.VoegItemToe(new Attractie(k, new Coordinaat(5, 18)));
        k.Teken(new ConsoleTekener());
        new ConsoleTekener().SchrijfOp(new Coordinaat(0, k.Hoogte + 1), "Deze kaart is schaal 1:1000");
        Console.Read();
    }

    public static void Week2OpdrachtDeel1()
    {
        GebruikerService gs = new GebruikerService();
        Console.WriteLine("Maak uw account aan.");
        string mail = EchteInvoer("Voer uw email in:");
        string wachtwoord = EchteInvoer("Voer uw wachtwoord in:");
        Gebruiker gebruiker = gs.Registreer(mail, wachtwoord);
        Console.WriteLine("Uw account is aangemaakt.");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Log in.");
        mail = EchteInvoer("Voer uw email in:");
        wachtwoord = EchteInvoer("Voer uw wachtwoord in:");
        Console.WriteLine("Gebruiker die probeert in te loggen: " + mail);
        gs.Verifieer(mail, "blablabla");
        Console.WriteLine("Gebruiker wordt geverifieerd: " + gebruiker.Geverifieerd());
        Console.WriteLine("Inlogpoging succesvol: " + gs.Login(mail, wachtwoord));
        Console.Read();
    }

    public static string EchteInvoer(string vraag)
    {
        String? s = null;
        Console.WriteLine(vraag);
        while (string.IsNullOrWhiteSpace(s = Console.ReadLine()))
        {
            Console.WriteLine(vraag);
        }
        return s;
    }
}