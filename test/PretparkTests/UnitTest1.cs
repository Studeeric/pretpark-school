namespace PretparkTests;
using AuthenticatieNS;

public class UnitTest1
{
    [Fact]
    public void TestLoginLuktNietZonderVerificatie()
    {
        // Arrange
        GebruikerService service = new GebruikerService(new TestMessengerService(), new TestContext());
        Gebruiker gebruiker = service.Registreer("TestMail", "TestWachtwoord");

        // Act
        bool poging = service.Login("TestMail", "TestWachtwoord");

        // Assert
        Assert.False(poging);       
    }

    [Fact]
    public void TestLoginLuktWelMetVerificatie()
    {
        // Arrange
        GebruikerService service = new GebruikerService(new TestMessengerService(), new TestContext());
        Gebruiker gebruiker = service.Registreer("TestMail", "TestWachtwoord");

        // Act
        bool x = service.Verifieer("TestMail", "token");
        bool poging = service.Login("TestMail", "TestWachtwoord");

        // Assert
        Assert.True(poging);  
    }

    [Fact]
    public void TestVerificatieFoutDatumVerlopen()
    {
        // Arrange
        GebruikerService service = new GebruikerService(new TestMessengerService(), new TestContext());
        Gebruiker gebruiker = service.Registreer("TestMail", "TestWachtwoord");
        gebruiker.Token.verloopDatum = gebruiker.Token.verloopDatum.AddDays(-4);

        // Act
        bool x = service.Verifieer("TestMail", "token");

        // Assert
        Assert.False(x);
    }
}