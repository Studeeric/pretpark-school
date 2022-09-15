namespace PretparkTests;
using AuthenticatieNS;

public class TestMessengerService : IMessengerService
{
    public bool Send(string message, string adres)
    {
        return true;
    }
}