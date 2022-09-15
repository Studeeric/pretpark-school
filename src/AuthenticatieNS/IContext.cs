namespace AuthenticatieNS
{
    public interface IContext
    {
        public void NieuweGebruiker(string mail, string wachtwoord);
        public Gebruiker GetGebruiker(int i);
        public int AantalGebruikers();
        public List<Gebruiker> GetAlleGebruikers();

    }
}