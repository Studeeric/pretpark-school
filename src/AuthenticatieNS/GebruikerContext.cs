namespace AuthenticatieNS
{
    public class GebruikerContext : IContext
    {
        public List<Gebruiker> _Gebruikers = new List<Gebruiker>();

        public int AantalGebruikers()
        {
            return _Gebruikers.Count();
        }

        public Gebruiker GetGebruiker(int i)
        {
            return _Gebruikers[i];
        }

        public void NieuweGebruiker(string Wachtwoord, string Email)
        {
            _Gebruikers.Add(new Gebruiker(Wachtwoord, Email));
        }

        public List<Gebruiker> GetAlleGebruikers(){
            return _Gebruikers;
        }
    }
}