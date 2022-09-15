namespace PretparkTests;

using System.Collections.Generic;
using AuthenticatieNS;

public class TestContext : IContext
{
    public List<Gebruiker> lijst = new List<Gebruiker>();
    
    public int AantalGebruikers()
    {
        return lijst.Count();
    }

    public List<Gebruiker> GetAlleGebruikers()
    {
        return lijst;
    }

    public Gebruiker GetGebruiker(int i)
    {
        return lijst[i];
    }

    public void NieuweGebruiker(string mail, string wachtwoord)
    {
        lijst.Add(new Gebruiker(mail, wachtwoord));
    }
}