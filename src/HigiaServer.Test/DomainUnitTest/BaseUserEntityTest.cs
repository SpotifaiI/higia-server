namespace HigiaServer.Test.DomainUnitTest;

public class BaseUserEntityTest
{
    private static readonly string Name = "Name";
    private static readonly string Address = "email.exemple@gmail.com";
    private static readonly string PhoneNumber = "47 994324914";
    private static readonly DateTime Birthday = DateTime.Now.AddYears(-18);

    private readonly BaseUserEntity_TestEntity _baseUserEntity;

    public BaseUserEntityTest()
    {
        _baseUserEntity = new BaseUserEntity_TestEntity(Name, Address, PhoneNumber, Birthday);
    }

    [Fact(DisplayName = "Create BaseUserEntity With Valid State")]
    public void CreateBaseUserEntity_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new BaseUserEntity_TestEntity(Name, Address, PhoneNumber, Birthday);
        action.Should().NotThrow<DomainExeptionValidation>();
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
        Action action = () => new BaseUserEntity_TestEntity(Name, address, PhoneNumber, Birthday);
        action.Should().Throw<DomainExeptionValidation>()
            .WithMessage("Invalid email address, valid email address is required");
    }

    [Fact(DisplayName = "Create BaseUserEntity With Invalid Birthday")]
    public void CreateBaseUserEntity_WithInvalidBirthday_ResultObjectInvalidState()
    {
        Action action = () =>
            new BaseUserEntity_TestEntity(Name, Address, PhoneNumber, DateTime.Now.AddYears(-17));
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid birthday, minimum age is 18 years old");
    }

    [Theory(DisplayName = "Create BaseUserEntity With Invalid Number Phone")]
    [InlineData(null)]
    [InlineData("11 9943249141891")]
    [InlineData("43 994324914a")]
    [InlineData("")]
    public void CreateBaseUserEntity_WithInvalidNumberPhone_ResultObjectInvalidState(string numberPhone)
    {
        Action action = () => new BaseUserEntity_TestEntity(Name, Address, numberPhone, Birthday);
        action.Should().Throw<DomainExeptionValidation>()
            .WithMessage("Invalid number phone, valid number phone is required");
    }

    [Theory(DisplayName = "Create BaseUserEntity With Invalid Name")]
    [InlineData("")]
    [InlineData(null)]
    public void CreateBaseUserEntity_WithInvalidName_ResultObjectInvalidState(string name)
    {
        Action action = () => new BaseUserEntity_TestEntity(name, Address, PhoneNumber, Birthday);
        action.Should().Throw<DomainExeptionValidation>()
            .WithMessage("Invalid name, valid name is required");
    }
}

public class BaseUserEntity_TestEntity : BaseUserEntity
{
    public BaseUserEntity_TestEntity(string name, string address, string phoneNumber,
        DateTime birthday)
        : base(name, address, phoneNumber, birthday)
    {}
}