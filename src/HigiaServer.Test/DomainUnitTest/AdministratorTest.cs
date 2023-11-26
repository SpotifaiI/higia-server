namespace HigiaServer.Test.DomainUnitTest;

public class AdministratorTest
{
    public static readonly string Name = "Name";
    public static readonly string Address = "email.exemplo@gmail.com";
    public static readonly string PhoneNumber = "47 994324914";
    public static readonly DateTime Birthday = DateTime.Now.AddYears(-18);

    [Fact(DisplayName = "Create Administrator With Valid State")]
    public void CreateAdministrator_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Administrator(Name, Address, PhoneNumber, Birthday);
        action.Should().NotThrow<DomainExeptionValidation>();
    }
}