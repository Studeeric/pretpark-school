namespace AuthenticatieNS
{
    public class GebruikerContext
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
    }
}