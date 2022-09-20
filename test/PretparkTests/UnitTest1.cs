namespace PretparkTests;
using AuthenticatieNS;
using Moq;

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
        Gebruiker gebruiker = new Gebruiker("w", "p");
        if (gebruiker.Token != null)
        {
            gebruiker.Token.verloopDatum = gebruiker.Token.verloopDatum.AddDays(-4);
        }

        // Act
        bool x = service.Verifieer("TestMail", "token");

        // Assert
        Assert.False(x);
    }

    [Theory]
    [InlineData("email", "wachtwoord")]
    public void TestLoginLuktNietZonderVerificatieMoq(string email, string wachtwoord)
    {
        // Arrange
        var moqContext = new Mock<IContext>();
        var moqService = new Mock<IMessengerService>();
        Gebruiker gebruiker = new Gebruiker(email, wachtwoord);
        moqContext.Setup(x => x.GetAlleGebruikers()).Returns(new List<Gebruiker>{gebruiker});

        GebruikerService service = new GebruikerService(moqService.Object, moqContext.Object);

        // Act
        bool poging = service.Login(email, wachtwoord);

        // Assert
        Assert.False(poging);      
    }

    [Theory]
    [InlineData("email", "wachtwoord")]
    public void TestLoginLuktWelMetVerificatieMoq(string email, string wachtwoord)
    {
        // Arrange
        var moqService = new Mock<IMessengerService>();
        var moqContext = new Mock<IContext>();
        Gebruiker gebruiker = new Gebruiker(email, wachtwoord);
        gebruiker.Token = null;
        moqContext.Setup(x => x.GetAlleGebruikers()).Returns(new List<Gebruiker>{gebruiker});

        GebruikerService service = new GebruikerService(moqService.Object, moqContext.Object);

        // Act
        bool poging = service.Login(email, wachtwoord);

        // Assert
        Assert.True(poging);  
    }

    [Theory]
    [InlineData("email", "wachtwoord", "token")]
    public void TestVerificatieFoutDatumVerlopenMoq(string email, string wachtwoord, string token)
    {
        // Arrange
        var moqService = new Mock<IMessengerService>();
        var moqContext = new Mock<IContext>();
        Gebruiker gebruiker = new Gebruiker(email, wachtwoord);
        gebruiker.Token.token = token;
        gebruiker.Token.verloopDatum = gebruiker.Token.verloopDatum.AddDays(-4);
        moqContext.Setup(x => x.GetAlleGebruikers()).Returns(new List<Gebruiker>{gebruiker});

        GebruikerService service = new GebruikerService(moqService.Object, moqContext.Object);

        // Act
        bool x = service.Verifieer(email, token);

        // Assert
        Assert.False(x);
    }
}