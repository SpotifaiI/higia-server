namespace HigiaServer.Test.DomainUnitTest;

public class BaseUserEntityTest
{
    public static readonly string FristName = "Primeiro Nome";
    public static readonly string LastName = "Sobre Nome";
    public static readonly string Address = "email.exemple@gmail.com";
    public static readonly string PhoneNumber = "47 994324914";
    public static readonly DateTimeOffset Birthday = DateTimeOffset.Now.AddYears(-18);

    private readonly BaseUserEntity_EntityTest BaseUserEntity;
    public BaseUserEntityTest()
    {
        BaseUserEntity = new BaseUserEntity_EntityTest(FristName, LastName, Address, PhoneNumber, Birthday);
    }

    [Fact(DisplayName = "Create BaseUserEntity With Valid State")]
    public void CreateBaseUserEntity_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new BaseUserEntity_EntityTest(FristName, LastName, Address, PhoneNumber, Birthday);
        action.Should().NotThrow<DomainExeptionValidation>();
    }

    [Fact(DisplayName = "Create BaseUserEntity Short First Name")]
    public void CreateBaseUserEntity_WithShortFirstName_ResultObjectInvalidState()
    {
        Action action = () => new BaseUserEntity_EntityTest("A", LastName, Address, PhoneNumber, Birthday);
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid first name, too short, minimum 3 characters");
    }

    [Theory(DisplayName = "Create BaseUserEntity With Null Or Empty First Name")]
    [InlineData(null)]
    [InlineData("")]
    public void CreateBaseUserEntity_WithNullEmptyFistName_ResultObjectInvalidState(string firstName)
    {
        Action action = () => new BaseUserEntity_EntityTest(firstName, LastName, Address, PhoneNumber, Birthday);
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid first name, valid first name is required");
    }

    [Fact(DisplayName = "Create BaseUserEntity Short Last Name")]
    public void CreateAdmintrator_WithShortLastName_ResultObjectInvalidState()
    {
        Action action = () => new BaseUserEntity_EntityTest(FristName, "A", Address, PhoneNumber, Birthday);
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid last name, too short, minimum 3 characters");
    }

    [Theory(DisplayName = "Create BaseUserEntity With Null Or Empty Last Name")]
    [InlineData(null)]
    [InlineData("")]
    public void CreateBaseUserEntity_WithNullEmptyLastName_ResultObjectInvalidState(string lastName)
    {
        Action action = () => new BaseUserEntity_EntityTest(FristName, lastName, Address, PhoneNumber, Birthday);
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid last name, valid last name is required");
    }

    [Theory(DisplayName = "Create BaseUserEntity With Invalid Address")]
    [InlineData("email.exemple")]
    [InlineData("email.exemple@")]
    [InlineData("email.exemple@gmail")]
    [InlineData("email.exemple@gmail.")]
    [InlineData("")]
    [InlineData(null)]
    public void CreateBaseUserEntity_WithInvalidAddress_ResultObjectInvalidState(string address)
    {
        Action action = () => new BaseUserEntity_EntityTest(FristName, LastName, address, PhoneNumber, Birthday);
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid email address, valid email address is required");
    }

    [Fact(DisplayName = "Create BaseUserEntity With Invalid Birthday")]
    public void CreateBaseUserEntity_WithInvalidBirthday_ResultObjectInvalidState()
    {
        Action action = () => new BaseUserEntity_EntityTest(FristName, LastName, Address, PhoneNumber, DateTimeOffset.Now.AddYears(-17));
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid birthday, minimum age is 18 years old");
    }

    [Theory(DisplayName = "Create BaseUserEntity With Invalid Number Phone")]
    [InlineData(null)]
    [InlineData("11 9943249141891")]
    [InlineData("43 994324914a")]
    [InlineData("")]
    public void CreateBaseUserEntity_WithInvalidNumberPhone_ResultObjectInvalidState(string numberPhone)
    {
        Action action = () => new BaseUserEntity_EntityTest(FristName, LastName, Address, numberPhone, Birthday);
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid number phone, valid number phone is required");
    }

    [Fact(DisplayName = "Update Number Phone To BaseUserEntity With Valid State")]
    public void UpdateNumberPhoneToBaseUserEntity_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => BaseUserEntity.UpdateNumberPhoneToUser("47 994324914");
        action.Should().NotThrow<DomainExeptionValidation>();
    }

    [Theory(DisplayName = "Update Number Phone To BaseUserEntity With Invalid Number Phone")]
    [InlineData(null)]
    [InlineData("11 9943249141891")]
    [InlineData("43 994324914a")]
    [InlineData("")]
    public void UpdateNumberPhoneToBaseUserEntity_WithInvalidNumberPhone_ResultObjectInvalidState(string numberPhone)
    {
        Action action = () => BaseUserEntity.UpdateNumberPhoneToUser(numberPhone);
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid number phone, valid number phone is required");
    }

    [Theory(DisplayName = "Update Address To BaseUserEntity With Valid State")]
    [InlineData("email.exemple")]
    [InlineData("email.exemple@")]
    [InlineData("email.exemple@gmail")]
    [InlineData("email.exemple@gmail.")]
    [InlineData("")]
    [InlineData(null)]
    public void UpdateAddressToBaseUserEntity_WithInvalidAddress_ResultObjectInvalidState(string address)
    {
        Action action = () => BaseUserEntity.UpdateAdressToUser(address);
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid email address, valid email address is required");
    }

    [Fact(DisplayName = "Update Address To BaseUserEntity Last Modified Should Be Updated")]
    public void UpdateAddressToBaseUserEntity_LastModifiedShouldBeUpdated()
    {
        var oldDate = BaseUserEntity.LastModified;
        BaseUserEntity.UpdateAdressToUser("email.exemple@gmail.com");
        Assert.True(BaseUserEntity.LastModified > oldDate);
    }

    [Fact(DisplayName = "Update Number Phone To BaseUserEntity Last Modified Should Be Updated")]
    public void UpdateNumberPhoneToBaseUserEntity_LastModifiedShouldBeUpdated()
    {
        var oldDate = BaseUserEntity.LastModified;
        BaseUserEntity.UpdateNumberPhoneToUser("47 994324914");
        Assert.True(BaseUserEntity.LastModified > oldDate);
    }

}

public class BaseUserEntity_EntityTest : BaseUserEntity
{
    public BaseUserEntity_EntityTest(string firstName, string lastName, string address, string phoneNumber, DateTimeOffset birthday) 
        : base(firstName, lastName, address, phoneNumber, birthday) 
        { 

        }
}
