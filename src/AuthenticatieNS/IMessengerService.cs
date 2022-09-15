namespace AuthenticatieNS
{
    public interface IMessengerService
    {
        public bool Send(string message, string adres);
    }
}