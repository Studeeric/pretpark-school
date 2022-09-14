namespace AuthenticatieNS
{
    public class GebruikerService
    {
        public EmailService es = new EmailService();
        public GebruikerContext gc = new GebruikerContext();
        public Gebruiker Registreer(string email, string wachtwoord)
        {
            if (es.Email("Je account is gemaakt.", email)){
                gc.NieuweGebruiker(wachtwoord, email);
                for (int i = 0; i >= gc.AantalGebruikers(); i++)
                {
                    if (gc.GetGebruiker(i).Email == email)
                    {
                        return gc.GetGebruiker(i);
                    }
                }
                return null;
            } else
            {
                return null;
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
                if (g.Email == email && g.Token.token == token)
                {
                    g.Token.token = null;
                    return true;
                }
            }
            return false;
        }
    }
}