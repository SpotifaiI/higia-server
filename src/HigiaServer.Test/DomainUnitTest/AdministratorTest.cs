namespace HigiaServer.Test.DomainUnitTest;

public class AdministratorTest
{
    public static readonly string FristName = "Primeiro Nome";
    public static readonly string LastName = "Sobre Nome";
    public static readonly string Address = "email.exemplo@gmail.com";
    public static readonly string PhoneNumber = "47 994324914";
    public static readonly DateTimeOffset Birthday = DateTimeOffset.Now.AddYears(-18);

    [Fact(DisplayName = "Create Administrator With Valid State")]
    public void CreateAdministrator_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Administrator(FristName, LastName, Address, PhoneNumber, Birthday);
        action.Should().NotThrow<DomainExeptionValidation>();
    }
}
