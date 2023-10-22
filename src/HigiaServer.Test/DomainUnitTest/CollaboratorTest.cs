namespace HigiaServer.Test.DomainUnitTest;

public class CollaboratorTest
{
    private static readonly string FristName = "Primeiro Nome";
    private static readonly string LastName = "Sobre Nome";
    private static readonly string Address = "email.exemplo@gmail.com";
    private static readonly string PhoneNumber = "47 994324914";
    private static readonly DateTimeOffset Birthday = DateTimeOffset.Now.AddYears(-18);
    private readonly Administrator _administrator;

    public CollaboratorTest()
    {
        _administrator = new Administrator(FristName, LastName, Address, PhoneNumber, Birthday);
    }

    [Fact(DisplayName = "Create Collaborator With Valid State")]
    public void CreateCollaborator_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Collaborator(FristName, LastName, Address, PhoneNumber, Birthday, _administrator);
        action.Should().NotThrow<DomainExeptionValidation>();
    }
}