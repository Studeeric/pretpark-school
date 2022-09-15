namespace AuthenticatieNS
{
    public class Gebruiker
    {
        public string Wachtwoord {get; set;}
        public string Email {get; set;}

        public VerificatieToken? Token {get; set;}

        public Gebruiker(string wachtwoord, string email){
            Wachtwoord = wachtwoord;
            Email = email;
            Token = new VerificatieToken();
        }

        public Boolean Geverifieerd()
        {
            if (Token == null)
            {
                return true;
            }
            return false;
        }
    }
}