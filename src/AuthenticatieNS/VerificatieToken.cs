namespace AuthenticatieNS
{
    public class VerificatieToken
    {
        public string token {get; set;}
        public DateTime verloopDatum {get; set;}

        public VerificatieToken()
        {
            token = "token";
            verloopDatum = DateTime.Today.AddDays(3);
        }
    }
}