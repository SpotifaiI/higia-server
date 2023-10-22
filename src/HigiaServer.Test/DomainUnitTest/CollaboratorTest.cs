namespace HigiaServer.Test.DomainUnitTest;

public class CollaboratorTest
{
    public static readonly string FristName = "Primeiro Nome";
    public static readonly string LastName = "Sobre Nome";
    public static readonly string Address = "email.exemplo@gmail.com";
    public static readonly string PhoneNumber = "47 994324914";
    public static readonly DateTimeOffset Birthday = DateTimeOffset.Now.AddYears(-18);
    public static readonly Administrator Administrator = new(FristName, LastName, Address, PhoneNumber, Birthday);

    [Fact(DisplayName = "Create Collaborator With Valid State")]
    public void CreateCollaborator_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Collaborator(FristName, LastName, Address, PhoneNumber, Birthday, Administrator);
        action.Should().NotThrow<DomainExeptionValidation>();
    }
}
