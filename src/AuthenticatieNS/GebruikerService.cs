namespace AuthenticatieNS
{
    public class GebruikerService
    {
        public IMessengerService service;
        public IContext context;

        public GebruikerService(IMessengerService service, IContext context)
        {
            this.service = service;
            this.context = context;
        }

        public Gebruiker Registreer(string email, string wachtwoord)
        {
            if (service.Send("Je account is gemaakt.", email))
            {
                context.NieuweGebruiker(email, wachtwoord);
                return context.GetGebruiker(context.AantalGebruikers() - 1);
            }
            else
            {
                return new Gebruiker("Nope", "Nope");
            }
        }

        public Boolean Login(string email, string wachtwoord)
        {
            foreach (Gebruiker g in context.GetAlleGebruikers())
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
            foreach (Gebruiker g in context.GetAlleGebruikers())
            {
                if (g.Token != null && g.Email.Equals(email))
                {
                    if (g.Token.token == token && g.Token.verloopDatum >= DateTime.Today)
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