namespace AuthenticatieNS
{
    public class VerificatieToken
    {
        public string? token {get; set;}
        public DateTime verloopDatum {get; set;}

        public VerificatieToken()
        {
            token = "blablabla";
            verloopDatum = DateTime.Today;
            verloopDatum.AddDays(3);
        }
    }
}