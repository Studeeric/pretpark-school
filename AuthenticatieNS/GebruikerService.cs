namespace AuthenticatieNS
{
    public class GebruikerService
    {
        public EmailService es = new EmailService();
        public GebruikerContext gc = new GebruikerContext();
        public Gebruiker Registreer(string email, string wachtwoord)
        {
            if (es.Email("Je account is gemaakt.", email))
            {
                gc.NieuweGebruiker(wachtwoord, email);
                return gc.GetGebruiker(gc.AantalGebruikers() - 1);
            }
            else
            {
                return new Gebruiker("Nope", "Nope");
            }
        }

        public Boolean Login(string email, string wachtwoord)
        {
            foreach (Gebruiker g in gc._Gebruikers)
            {
                if (g.Email == email && g.Wachtwoord == wachtwoord && g.Geverifieerd())
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean Verifieer(string email, string token)
        {
            foreach (Gebruiker g in gc._Gebruikers)
            {
                if (g.Token != null && g.Email == email)
                {
                    if (g.Token.token == token)
                    {
                        g.Token = null;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}