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

    [Fact(DisplayName = "Create Administrator Short First Name")]
    public void CreateAdministrator_WithShortFirstName_ResultObjectInvalidState()
    {
        Action action = () => new Administrator("A", LastName, Address, PhoneNumber, Birthday);
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid first name, too short, minimum 3 characters");
    }

    [Theory(DisplayName = "Create Administrator With Null Or Empty First Name")]
    [InlineData(null)]
    [InlineData("")]
    public void CreateAdministrator_WithNullEmptyFistName_ResultObjectInvalidState(string firstName)
    {
        Action action = () => new Administrator(firstName, LastName, Address, PhoneNumber, Birthday);
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid first name, valid first name is required");
    }

    [Fact(DisplayName = "Create Administrator Short Last Name")]
    public void CreateAdmintrator_WithShortLastName_ResultObjectInvalidState()
    {
        Action action = () => new Administrator(FristName, "A", Address, PhoneNumber, Birthday);
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid last name, too short, minimum 3 characters");
    }

    [Theory(DisplayName = "Create Administrator With Null Or Empty Last Name")]
    [InlineData(null)]
    [InlineData("")]
    public void CreateAdministrator_WithNullEmptyLastName_ResultObjectInvalidState(string lastName)
    {
        Action action = () => new Administrator(FristName, lastName, Address, PhoneNumber, Birthday);
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid last name, valid last name is required");
    }

    [Theory(DisplayName = "Create Administrator With Invalid Address")]
    [InlineData("email.exemplo")]
    [InlineData("email.exemplo@")]
    [InlineData("email.exemplo@gmail")]
    [InlineData("email.exemplo@gmail.")]
    [InlineData("")]
    [InlineData(null)]
    public void CreateAdministrator_WithInvalidAddress_ResultObjectInvalidState(string address)
    {
        Action action = () => new Administrator(FristName, LastName, address, PhoneNumber, Birthday);
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid email address, valid email address is required");
    }

    [Fact(DisplayName = "Create Administrator With Invalid Birthday")]
    public void CreateAdministrator_WithInvalidBirthday_ResultObjectInvalidState()
    {
        Action action = () => new Administrator(FristName, LastName, Address, PhoneNumber, DateTimeOffset.Now.AddYears(-17));
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid birthday, minimum age is 18 years old");
    }

    [Theory(DisplayName = "Create Administrator With Invalid Number Phone")]
    [InlineData(null)]
    [InlineData("11 9943249141891")]
    [InlineData("43 994324914a")]
    [InlineData("")]
    public void CreateAdministrator_WithInvalidNumberPhone_ResultObjectInvalidState(string numberPhone)
    {
        Action action = () => new Administrator(FristName, LastName, Address, numberPhone, Birthday);
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid number phone, valid number phone is required");
    }

}
